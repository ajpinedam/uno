# DevServer MCP — Manual Test Checklist

Manual QA for the `uno-devserver mcp` feature (`src/Uno.UI.DevServer.Cli/Mcp/`). Covers registration CLI and runtime MCP proxy across VS Code, Antigravity, Cursor, and Rider + Junie.

Related PR: unoplatform/uno#23103 (profile audit — removes `--force-roots-fallback` from `extraArgs` for several clients; changes `junie-rider` config path).

---

## 0. Preconditions

- [ ] CLI built from the branch under test and installed:
  - [ ] `cd src/Uno.UI.DevServer.Cli && dotnet pack -c Release -o ./nupkg`
  - [ ] `dotnet tool uninstall -g Uno.DevServer` (if previously installed)
  - [ ] `dotnet tool install -g Uno.DevServer --add-source ./nupkg --prerelease`
  - [ ] `uno-devserver --version` returns the expected local build
- [ ] Record CLI branch/SHA under test: `__________________`
- [ ] Is PR #23103 merged into the CLI under test? Yes / No (affects `junie-rider` path and `--force-roots-fallback` expectations)
- [ ] Throwaway test solution created at a stable path (e.g. `C:\temp\uno-mcp-test\`), references `Uno.WinUI.DevServer`
- [ ] `dnx --version` works in the shell the IDEs inherit
- [ ] Pre-snapshot taken of config files about to be touched:
  - [ ] `<workspace>/.vscode/mcp.json` and `~/.vscode/mcp.json`
  - [ ] `~/.gemini/antigravity/mcp_config.json`
  - [ ] `<workspace>/.cursor/mcp.json` and `~/.cursor/mcp.json`
  - [ ] `<workspace>/.idea/mcpServers.json` (or `.junie/mcp/mcp.json` post-#23103)

---

## 1. CLI baseline (IDE-independent)

- [ ] `uno-devserver mcp status --json` runs and returns valid JSON
- [ ] `uno-devserver mcp install copilot-vscode --dry-run --workspace <testdir>` shows path + payload, writes nothing
- [ ] Invalid client name -> exit code `1`
- [ ] Missing required argument -> exit code `2`
- [ ] Successful run -> exit code `0`

### Flags

- [ ] `--channel prerelease` -> written `args` include `--prerelease`
- [ ] `--tool-version 6.0.0-dev.123` -> written `args` include `--version 6.0.0-dev.123`
- [ ] `--channel` + `--tool-version` together -> exit code `2`
- [ ] `--servers UnoApp` -> only UnoApp written
- [ ] `--servers UnoDocs` -> only UnoDocs written
- [ ] `--all-ides` install + uninstall round-trip cleans all detected clients
- [ ] `--all-scopes` uninstall removes entries from secondary config paths (verify by planting one manually first)

### Duplicate detection

- [ ] Manually plant a second Uno entry under a different key in the same file -> `mcp status` reports the duplicate warning

---

## 2. Per-IDE cycle

Repeat steps 1–15 for each IDE. Copy the Evidence block per IDE at the bottom.

### Common cycle

1. [ ] Close the IDE; snapshot existing MCP config
2. [ ] `cd <workspace> && uno-devserver mcp install <client-id>`
3. [ ] `uno-devserver mcp status` reports `UnoApp` and `UnoDocs` as `registered`
4. [ ] Config file written at the expected profile path
5. [ ] `extraArgs` in the written config does **not** contain `--force-roots-fallback` (post-#23103 clients only — see table below)
6. [ ] Open the IDE on the workspace
7. [ ] IDE's MCP panel lists both servers and they reach connected / tool-listing state
8. [ ] Call `uno_health` -> returns a health report (not `Degraded`)
9. [ ] Call `uno_platform_docs_search` with query "Hot Reload" -> returns results (validates UnoDocs HTTP path)
10. [ ] Start the Uno app (F5 / `dotnet run`)
11. [ ] Call `uno_app_get_runtime_info` -> returns PID/OS/platform
12. [ ] Call `uno_app_get_screenshot` -> returns image
13. [ ] Roots behavior matches expectation for this IDE (see per-IDE row below)
14. [ ] `uno-devserver mcp uninstall <client-id>` removes entries; other unrelated MCP entries in the same file are preserved
15. [ ] Re-install with `--json` -> output matches file contents written

### Post-#23103 clients that must NOT emit `--force-roots-fallback`

- [ ] `gemini-antigravity`
- [ ] `claude-desktop`
- [ ] `jetbrains-air`
- [ ] `junie-rider`
- [ ] `windsurf`

---

### 2.1 VS Code (GitHub Copilot) — `copilot-vscode`

- [ ] GitHub Copilot + Copilot Chat installed, MCP-capable version
- [ ] Write target: `<workspace>/.vscode/mcp.json`, root key `servers`, `"type": "stdio"` on UnoApp
- [ ] Roots-capable: `uno_app_initialize` **not** exposed; workspace auto-detected
- [ ] MCP servers visible via Command Palette -> MCP: List Servers
- [ ] Complete common cycle above

### 2.2 Google Antigravity — `gemini-antigravity`

- [ ] Write target: `~/.gemini/antigravity/mcp_config.json` (user scope only, no workspace file)
- [ ] Roots NOT supported: `uno_app_initialize` **is** exposed
- [ ] First-turn flow requires calling `uno_app_initialize` with workspace path before other `uno_app_*` tools
- [ ] Complete common cycle above

### 2.3 Cursor — `cursor`

- [ ] Write target: `<workspace>/.cursor/mcp.json`
- [ ] Install/uninstall are file-based (Cursor CLI is read-only — expected)
- [ ] MCP visible in Cursor Settings -> MCP
- [ ] Roots-capable: `uno_app_initialize` not exposed
- [ ] Complete common cycle above

### 2.4 Rider + Junie — `junie-rider`

- [ ] Write target matches CLI branch:
  - [ ] Pre-#23103: `<workspace>/.idea/mcpServers.json`
  - [ ] Post-#23103: `<workspace>/.junie/mcp/mcp.json` (and `~/.junie/mcp/mcp.json`)
- [ ] Junie plugin installed (plain Rider has no MCP client)
- [ ] Roots NOT supported: `uno_app_initialize` exposed, initialize flow required
- [ ] Complete common cycle above

---

## 3. Runtime-path regressions

- [ ] **Roots auto-detect — capable client** (VS Code): DevServer trace log shows roots received; `uno_app_initialize` absent from tool list
- [ ] **Roots auto-detect — non-capable client** (Antigravity or Junie): `uno_app_initialize` present; workspace resolved after agent calls it
- [ ] **`tools/list_changed`**: open IDE chat before starting the Uno app, then start the app — tool list refreshes to include `uno_app_*` without reopening the session
- [ ] **Crash recovery**: kill `Uno.UI.RemoteControl.Host` while IDE is connected — proxy reconnects within ~15s (up to 3 attempts); after 3 failures `uno_health` reports `Degraded`
- [ ] **Multi-solution workspace**: nested `.sln` <=3 levels deep appears in `uno_health.DiscoveredSolutions`

Enabling trace logs from the IDE-side config (append to `args`): `-l trace -fl %TEMP%/uno-mcp-{Date}.log`

---

## 4. Evidence template (copy per IDE)

```
IDE:                                    CLI branch/SHA:
Client id:
Config path written:                    Matches profile? Y/N
Contains --force-roots-fallback?        Y/N  (expected N for antigravity/claude-desktop/jetbrains-air/junie-rider/windsurf post-#23103)
uno_health:                             OK / Degraded / no response
uno_platform_docs_search:               OK / fail
uno_app_get_runtime_info:               OK / fail
uno_app_get_screenshot:                 OK / fail
Roots behavior as expected:             Y/N
Uninstall clean:                        Y/N
Notes / log path:
```
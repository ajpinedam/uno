# Feature Specification: Native AOT support for macOS app bundle packaging

**Feature Branch**: `dev/anpi/publishaot_app`
**Created**: 2026-08-11
**Status**: Draft
**GitHub Issue**: [unoplatform/uno#24047](https://github.com/unoplatform/uno/issues/24047)
**Input**: User description: "Is it possible to PublishAOT targeting Skia with `-p:PackageFormat=app`? It works fine if I don't PublishAot or package it, but not together."

## Background *(context)*

Uno Platform 6.6 supports [Native AOT deployment](https://platform.uno/docs/articles/features/native-aot.html) on macOS Skia Desktop, but the macOS packaging pipeline (`PackageFormat=app|pkg|dmg`) fails when combined with `-p:PublishAot=true`:

```bash
# works
dotnet publish -f net10.0-desktop -r osx-arm64 -p:PublishAot=true
# works
dotnet publish -f net10.0-desktop -r osx-arm64 -p:PackageFormat=app
# fails
dotnet publish -f net10.0-desktop -r osx-arm64 -p:PublishAot=true -p:PackageFormat=app
```

The bundling pipeline (`Uno.Sdk.Extras.Publish.MacOS.targets` / `GenerateAppBundle` task, shipped in the public `Uno.Sdk.Extras` NuGet package) is hard-wired to the CoreCLR self-contained hosting model:

1. It discards the published apphost executable and compiles a custom Objective-C host with clang, linking `-lcoreclr` against `libcoreclr.dylib` from the publish output.
2. That host boots the app via `coreclr_initialize()` / `coreclr_execute_assembly()` on `$(AssemblyName).dll`, redirecting `APP_CONTEXT_BASE_DIRECTORY` to `Contents/Resources` where managed assemblies and content are copied.

A Native AOT publish contains none of those artifacts (no `libcoreclr.dylib`, no `$(AssemblyName).dll`, no `runtimeconfig.json`/`deps.json`), so the clang link step fails (`ld: library 'coreclr' not found`, surfaced as "Unable to compile the native app executable.").

The custom host exists only because a CoreCLR app has no real native executable to place in `Contents/MacOS` — a Native AOT publish produces exactly that, so the AOT path can be simpler: use the AOT binary as the bundle executable directly.

## User Scenarios & Testing *(mandatory)*

### User Story 1 - Package a Native AOT app as an app bundle (Priority: P1)

A developer publishes their Skia Desktop app with Native AOT and packages it as a macOS app bundle in a single command, obtaining a launchable `.app` with AOT startup performance.

**Why this priority**: This is the core gap — Native AOT on macOS is effectively unusable for shipping today because the only distribution format cannot be produced from AOT output.

**Independent Test**: Run `dotnet publish -f net10.0-desktop -r osx-arm64 -p:PublishAot=true -p:PackageFormat=app` on a macOS machine and double-click the produced `.app`.

**Acceptance Scenarios**:

1. **Given** an Uno Skia Desktop app, **When** publishing with `-p:PublishAot=true -p:PackageFormat=app -r osx-arm64` (or `osx-x64`), **Then** the build succeeds and produces `{APPNAME}.app` under `bin/Release/{TFM}/{RID}/publish/`.
2. **Given** the produced bundle, **When** launched via Finder or `open`, **Then** the app starts, the window renders, and content assets (images, fonts, `appsettings`) load correctly.
3. **Given** the produced bundle, **When** copied to a macOS machine without any .NET runtime installed, **Then** the app launches and runs.

---

### User Story 2 - Sign, package, and notarize the AOT bundle for distribution (Priority: P2)

A developer produces a signed `.app`, wraps it in a `.pkg` installer or `.dmg` disk image, and notarizes it with Apple — the same distribution flow already documented for CoreCLR bundles.

**Why this priority**: An unsigned local bundle is only useful for testing; real distribution requires the signing/notarization chain to work over the AOT binary.

**Independent Test**: Run the documented publish command with `-p:CodesignKey=...` (and `-p:PackageFormat=pkg|dmg` plus the respective signing keys), then verify with `codesign --verify` and a notarization round-trip.

**Acceptance Scenarios**:

1. **Given** a valid signing identity, **When** publishing an AOT bundle with `-p:CodesignKey={identity}`, **Then** signing succeeds (replacing the linker's ad-hoc signature) and `codesign --verify --deep` passes.
2. **Given** `-p:PackageFormat=pkg` or `dmg` with the respective signing keys, **When** publishing with AOT enabled, **Then** the installer/disk image is produced containing the AOT `.app`.
3. **Given** `-p:UnoMacOSNotarizeKeychainProfile={profile}`, **When** publishing, **Then** Apple notarization succeeds.

---

### User Story 3 - Documentation reflects AOT packaging support (Priority: P3)

A developer reading the macOS publishing docs learns that `PublishAot` can be combined with `PackageFormat`, including any behavioral differences from the CoreCLR path.

**Why this priority**: Discoverability — without docs, the capability stays invisible; but it delivers no value before P1/P2 exist.

**Independent Test**: Review `doc/articles/uno-publishing-desktop-macos.md` and `uno-publishing-desktop-macos-advanced.md` for AOT guidance.

**Acceptance Scenarios**:

1. **Given** the macOS publishing docs, **When** a developer looks up Native AOT, **Then** the docs show the combined command and state which CoreCLR-only options do not apply under AOT.

---

### Edge Cases

- Publishing AOT without a RID: the existing "fat bundles not supported" error ([unoplatform/uno#17137](https://github.com/unoplatform/uno/issues/17137)) must still be raised.
- The AOT publish output includes a `.dSYM` debug-symbol directory (when `StripSymbols=true`, the default): it must not be swept into the bundle as resources.
- CoreCLR-only options (`UnoMacOSIncludeCreateDump`, `UnoMacOSIncludeExtraClrGC`, `UnoMacOSIncludeNativeDebugging`, `UnoMacOSIncludeDebugSymbols`) reference files that do not exist under AOT: they must be ignored gracefully, not fail the build.
- The execute permission on the copied AOT binary must survive the copy into `Contents/MacOS` (explicit `chmod +x` if needed).
- A custom `Info.plist` with an explicit `CFBundleExecutable` must keep matching the copied executable name (`$(AssemblyName)`).
- `StripSymbols=false` publishes an unstripped binary and no `.dSYM`: bundling must still work.
- The manual `UnoPublishFatBundle` / `UnoMergeBundles` targets (lipo merge of two single-arch bundles) with AOT binaries: out of scope for v1, but must not regress for CoreCLR.

## Requirements *(mandatory)*

### Functional Requirements

- **FR-001**: When `PublishAot=true` and `PackageFormat` is `app`, `pkg`, or `dmg`, bundle generation MUST succeed without requiring CoreCLR artifacts (`libcoreclr.dylib`, `$(AssemblyName).dll`, `runtimeconfig.json`, `deps.json`).
- **FR-002**: The pipeline MUST use the AOT-produced native executable as the bundle's `CFBundleExecutable` and MUST NOT compile the custom CoreCLR host in that case.
- **FR-003**: All runtime-required files (native dylibs such as `libUnoNativeMac.dylib` and SkiaSharp, plus content assets) MUST be laid out so the AOT binary's default probing finds them — i.e. relative to the executable's directory, which is `AppContext.BaseDirectory` under AOT — with no app-code or Uno-runtime changes required for asset resolution.
- **FR-004**: The bundled executable MUST retain execute permissions.
- **FR-005**: The `.dSYM` output MUST be excluded from the bundle contents.
- **FR-006**: CoreCLR-only pruning/inclusion options MUST be no-ops under AOT rather than errors.
- **FR-007**: Code signing (`CodesignKey`), hardened runtime, and custom entitlements MUST work over the AOT binary; the default entitlements for AOT bundles SHOULD omit `com.apple.security.cs.allow-jit`.
- **FR-008**: `PackageFormat=pkg` and `dmg` MUST wrap the AOT-produced `.app` exactly as they wrap CoreCLR bundles, including notarization support.
- **FR-009**: Existing CoreCLR (non-AOT) bundling behavior MUST remain byte-for-byte unchanged in layout and options.
- **FR-010**: The macOS publishing documentation in this repository MUST be updated to cover the AOT + `PackageFormat` combination and its differences.

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: `dotnet publish -f net10.0-desktop -r osx-arm64 -p:PublishAot=true -p:PackageFormat=app` exits 0 and produces a `.app` bundle (today it fails at the clang host-compile step).
- **SC-002**: The produced bundle launches and renders on a clean macOS machine with no .NET runtime installed, with assets and fonts loading.
- **SC-003**: `codesign --verify --deep --strict` passes on a signed AOT bundle, and a notarization submission is accepted.
- **SC-004**: A CoreCLR bundle produced before and after the change has an identical file layout (no regression to the existing path).
- **SC-005**: The AOT bundle retains the startup-time advantage of the unbundled AOT publish (same binary, no added host indirection).

## Assumptions

- Native AOT *runtime* support for macOS Skia Desktop already works (Uno 6.6+, `doc/articles/features/native-aot.md`); this feature only addresses packaging.
- The implementation lives in the packaging tasks shipped via the public `Uno.Sdk.Extras` NuGet package and is tracked downstream; this repository carries the spec and the documentation updates.
- For AOT bundles, the entire publish output (executable, dylibs, content) is placed in `Contents/MacOS`, mirroring the flat publish layout that AOT already uses on every desktop target. Asset resolution needs no Uno change because `Package.GetInstalledPath()` (`src/Uno.UWP/ApplicationModel/Package.Other.cs`) falls back to `AppContext.BaseDirectory` when `Assembly.Location` is empty, as it is under AOT. Ecosystem precedent exists for this layout passing signing and notarization.
- Fat (x64+arm64) bundles remain unsupported, matching the existing single-RID requirement.
- Windows and Linux `PackageFormat` paths are unaffected.

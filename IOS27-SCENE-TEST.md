# iOS 27 scene life cycle test (Apple silicon)

> Temporary file for testing branch `dev/anpi/fix.ios.scene.lifecycle`. Delete it before opening the PR.

Apps built with the iOS 27 SDK must use the UIKit scene life cycle, or iOS 27 refuses to launch them (#25510). This branch makes Uno 6.8 adopt it. Here we check three things on iOS 27:

1. An app built from this branch with Xcode 27 launches, and its window is hosted by the Uno scene delegate.
2. Scenes turn on by themselves when the app is built with a version 27 SDK, with no Info.plist key.
3. A stock Uno 6.8 app built with Xcode 27 fails, and the same app with the branch's assembly works.

Run every block in the same terminal: later steps reuse the variables set by earlier ones.

## 1. Prerequisites

- An Apple silicon Mac with Xcode 27 and the iOS 27 simulator runtime.
- A .NET 10 SDK whose iOS workload has both a `net9.0` pack and a `net10.0_27.x` pack:

  ```bash
  dotnet --version
  ls "$(dirname "$(readlink -f "$(which dotnet)")")/packs" | grep -E '^Microsoft\.iOS\.Sdk\.net(9\.0|10\.0)_'
  ```

  If no `Microsoft.iOS.Sdk.net10.0_27.x` pack is listed, run `sudo dotnet workload update`, or `sudo dotnet workload install ios`. The exact versions move with each workload release. For example, workload 27.1.10018 ships `net10.0_27.1` and `net9.0_26.5`.

Point the build at Xcode 27. `DEVELOPER_DIR` is read by `xcrun` and by the .NET iOS build, without changing `xcode-select`. Don't set `MD_APPLE_SDK_ROOT`: the iOS 27 pack warns that it's deprecated.

```bash
export DEVELOPER_DIR=/Applications/Xcode.app/Contents/Developer   # change to the Xcode 27 app
xcodebuild -version                                               # must print Xcode 27.x
```

Pick an iPhone simulator on iOS 27 and boot it:

```bash
xcrun simctl list devices available | grep -A20 -- '-- iOS 27'
export UDID=PASTE-THE-UDID   # an iPhone on iOS 27, from the list above
xcrun simctl boot $UDID; open -a Simulator
```

Set up a scratch folder outside the repo and a re-sign helper. A simulator app must be re-signed after a file inside it changes:

```bash
export W=$HOME/scene27-test; mkdir -p $W
resign() { codesign --force --sign - --preserve-metadata=entitlements --timestamp=none "$1" >/dev/null; }
```

## 2. Get the branch

```bash
git clone https://github.com/unoplatform/uno.git ~/uno-scene27   # or reuse an existing clone
cd ~/uno-scene27
git fetch https://github.com/ajpinedam/uno.git dev/anpi/fix.ios.scene.lifecycle
git switch -c dev/anpi/fix.ios.scene.lifecycle FETCH_HEAD
export REPO=$PWD

cat > $REPO/src/crosstargeting_override.props <<'EOF'
<Project>
  <PropertyGroup>
    <UnoTargetFrameworkOverride>net9.0-ios</UnoTargetFrameworkOverride>
    <UnoFastDevBuild>true</UnoFastDevBuild>
  </PropertyGroup>
</Project>
EOF
```

## 3. Test A: SamplesApp from the branch

The 6.8 Skia iOS runtime is built for `net9.0-ios`, so this head builds that way. UIKit doesn't look at the .NET version. It checks the SDK the app was linked against, which is Xcode 27's.

The simulator runtime is passed with `UnoSampleAppRuntimeIdentifiers`, which sets it for the app only. A `-p:RuntimeIdentifier` on the command line also reaches the DevServer host project, and on a clean clone the build fails with `MSB3030: Could not copy the file ".../Uno.UI.RemoteControl.Host/obj/Debug/net9.0/apphost"`.

```bash
cd $REPO/src/SamplesApp/SamplesApp.Skia.netcoremobile
dotnet restore SamplesApp.Skia.netcoremobile.csproj -p:UnoSampleAppRuntimeIdentifiers=iossimulator-arm64 -p:NuGetAudit=false
dotnet build SamplesApp.Skia.netcoremobile.csproj -f net9.0-ios --no-restore -c Debug \
  -p:UnoSampleAppRuntimeIdentifiers=iossimulator-arm64 -p:ValidateXcodeVersion=false -p:NuGetAudit=false \
  -p:UNO_DISABLE_ANALYZERS_IN_SAMPLES=true
export SAMPLES_APP=$PWD/bin/Debug/net9.0-ios/iossimulator-arm64/SamplesApp.app
plutil -p $SAMPLES_APP/Info.plist | grep -E 'DTPlatformVersion|DTSDKName|DTXcode"|UnoUseSceneLifecycle'
```

Check that `DTPlatformVersion` is `27.x` and `UnoUseSceneLifecycle` is `true`. If it shows `26.x`, the build used another Xcode, so fix `DEVELOPER_DIR` and rebuild.

Make three copies of the app, one per setting of the Info.plist key:

| Copy | `UnoUseSceneLifecycle` | Expected |
|---|---|---|
| `samples-on` | `true`, as committed | Launches under scenes |
| `samples-default` | removed | Launches under scenes, because the app was built with a version 27 SDK |
| `samples-off` | `false` | iOS refuses to launch it. This is what the opt-out does on a version 27 SDK. |

```bash
rm -rf $W/samples-*.app
cp -R $SAMPLES_APP $W/samples-on.app
cp -R $SAMPLES_APP $W/samples-default.app && plutil -remove UnoUseSceneLifecycle $W/samples-default.app/Info.plist && resign $W/samples-default.app
cp -R $SAMPLES_APP $W/samples-off.app && plutil -replace UnoUseSceneLifecycle -bool NO $W/samples-off.app/Info.plist && resign $W/samples-off.app
```

Run the runtime test `Given_Window.When_Scene_Lifecycle_Window_Hosted_In_Application_Scene` in each copy. The filter is passed in base64. The app writes an NUnit XML file when the run ends:

```bash
B=uno.platform.samplesapp.skia
F=$(printf 'Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml.Given_Window.When_Scene_Lifecycle_Window_Hosted_In_Application_Scene' | base64)
runtest() {
  R=$W/rt-$1.xml; rm -f $R
  xcrun simctl terminate $UDID $B 2>/dev/null; xcrun simctl uninstall $UDID $B 2>/dev/null
  xcrun simctl install $UDID $W/samples-$1.app
  SIMCTL_CHILD_UITEST_RUNTIME_AUTOSTART_RESULT_FILE=$R SIMCTL_CHILD_UITEST_RUNTIME_TESTS_FILTER=$F xcrun simctl launch $UDID $B
  for i in $(seq 1 60); do [ -s $R ] && break; sleep 5; done
  if [ -s $R ]; then
    python3 - $R <<'EOF'
import re, sys
raw = open(sys.argv[1], 'rb').read()
s = raw.decode('utf-16') if raw[:2] in (b'\xff\xfe', b'\xfe\xff') else raw.decode('utf-8-sig')
for m in re.finditer(r'<test-case [^>]*?name="([^"]*)"[^>]*?result="([^"]*)"', s): print(m.group(2), m.group(1))
for m in re.finditer(r'<message><!\[CDATA\[(.*?)\]\]>', s, re.S): print('  message:', m.group(1)[:400])
EOF
  else
    echo "no result file for $1"
  fi
}
runtest on
runtest default
runtest off
```

Expected:
- `on` and `default` print `Passed When_Scene_Lifecycle_Window_Hosted_In_Application_Scene`.
- `off` prints `no result file`, because the app never started. Save the reason iOS gives:

  ```bash
  xcrun simctl spawn $UDID log show --last 10m --style compact --predicate 'process == "SamplesApp"' | grep -i -m10 scene
  ```

Then check `samples-on` by hand:

```bash
xcrun simctl install $UDID $W/samples-on.app && xcrun simctl launch $UDID $B
```

- The samples list appears, and a sample opens.
- Rotate the device (Device > Rotate Left), and the layout follows.
- Open Settings (`xcrun simctl launch $UDID com.apple.Preferences`), then launch the app again. It comes back as you left it.

Optional: repeat `runtest on` and `runtest default` on an iPad simulator on iOS 27 (change `UDID`).

## 4. Test B: a template app, stock and with the branch

This is what a customer sees. `Uno.Sdk` 6.8.0-dev.66 uses Uno 6.8.0-dev.222. Its UI code and SDK targets are identical to this branch's base. So swapping only the assembly this branch changes gives an exact before and after.

### B.1 Build the native renderer's assembly from the branch

Test A already built the Skia one, at `$REPO/src/Uno.UI.Runtime.Skia.AppleUIKit/bin/Debug/net9.0-ios18.0/Uno.UI.Runtime.Skia.AppleUIKit.dll`. The native one is `Uno.UI.dll` for `net10.0-ios26.0`:

```bash
cd $REPO/src
sed -i '' 's|<UnoTargetFrameworkOverride>net9.0-ios<|<UnoTargetFrameworkOverride>net10.0-ios<|' crosstargeting_override.props
dotnet restore Uno.UI/Uno.UI.netcoremobile.csproj -p:NuGetAudit=false
dotnet build Uno.UI/Uno.UI.netcoremobile.csproj -f net10.0-ios26.0 --no-restore -p:ValidateXcodeVersion=false -p:NuGetAudit=false
ls -la $REPO/src/Uno.UI.Runtime.Skia.AppleUIKit/bin/Debug/net9.0-ios18.0/Uno.UI.Runtime.Skia.AppleUIKit.dll \
       $REPO/src/Uno.UI/bin/Uno.UI.netcoremobile/Debug/net10.0-ios26.0/Uno.UI.dll
```

To rebuild SamplesApp later, set the override back to `net9.0-ios` and restore again.

### B.2 Create the apps

```bash
mkdir -p $W/apps && cd $W/apps
dotnet new install Uno.Templates@6.7.30
dotnet new unoapp -o SceneTest -preset blank -platforms ios -tfm net10.0 -renderer skia
dotnet new unoapp -o SceneTestNative -preset blank -platforms ios -tfm net10.0 -renderer native
sed -i '' 's/"Uno.Sdk": "[^"]*"/"Uno.Sdk": "6.8.0-dev.66"/' SceneTest/global.json SceneTestNative/global.json
grep -h TargetFrameworks SceneTest/SceneTest/SceneTest.csproj SceneTestNative/SceneTestNative/SceneTestNative.csproj
```

The target framework should be `net10.0-ios`, which picks the newest iOS pack, `27.x`.

In `SceneTestNative/SceneTestNative/Platforms/iOS/Main.iOS.cs`, change `.App(() => new App())` to `.App(CreateApp)`, and add `private static App CreateApp() => new App();` to the class. On 6.x a lambda makes the native host construct `Application` instead of `App`, and the app stalls on its splash screen. That's a separate bug.

### B.3 Check the `Uno.Sdk` minimum OS version

The stock SDK sets `SupportedOSPlatformVersion` to 14.2, and the iOS 27 pack requires at least 15.0:

```bash
cd $W/apps
dotnet build SceneTest/SceneTest/SceneTest.csproj -f net10.0-ios -p:RuntimeIdentifier=iossimulator-arm64 -p:ValidateXcodeVersion=false 2>&1 | grep -iE 'error|SupportedOSPlatformVersion' | head -5
```

Expected: the build fails with an error about the minimum version. Save the message.

Now put the branch's SDK targets over the cached package. Keep a backup, which section 6 restores:

```bash
SDKT=~/.nuget/packages/uno.sdk/6.8.0-dev.66/targets
[ -d $W/uno.sdk-targets.bak ] || cp -R $SDKT $W/uno.sdk-targets.bak
cp $REPO/src/Uno.Sdk/targets/{Uno.Sdk.After.targets,Uno.Common.iOS.targets,Uno.Common.MacCatalyst.targets} $SDKT/
dotnet build SceneTest/SceneTest/SceneTest.csproj -f net10.0-ios -p:RuntimeIdentifier=iossimulator-arm64 -p:ValidateXcodeVersion=false -v:n 2>&1 | grep -E 'rather than the Uno default|error|Build succeeded' | head -5
```

Expected: `Build succeeded`, and the message `SupportedOSPlatformVersion is 15.0 rather than the Uno default of 14.2, which this ios SDK no longer supports. …`.

### B.4 Build both apps and make stock and patched copies

```bash
cd $W/apps
for P in SceneTest SceneTestNative; do
  dotnet build $P/$P/$P.csproj -f net10.0-ios -c Debug -p:RuntimeIdentifier=iossimulator-arm64 -p:ValidateXcodeVersion=false || break
done
SK=$W/apps/SceneTest/SceneTest/bin/Debug/net10.0-ios/iossimulator-arm64/SceneTest.app
NA=$W/apps/SceneTestNative/SceneTestNative/bin/Debug/net10.0-ios/iossimulator-arm64/SceneTestNative.app
plutil -p $SK/Info.plist | grep DTPlatformVersion; plutil -p $NA/Info.plist | grep DTPlatformVersion   # 27.x

rm -rf $W/skia-*.app $W/native-*.app
cp -R $SK $W/skia-stock.app
cp -R $SK $W/skia-patched.app && cp $REPO/src/Uno.UI.Runtime.Skia.AppleUIKit/bin/Debug/net9.0-ios18.0/Uno.UI.Runtime.Skia.AppleUIKit.dll $W/skia-patched.app/ && resign $W/skia-patched.app
cp -R $NA $W/native-stock.app
cp -R $NA $W/native-patched.app && cp $REPO/src/Uno.UI/bin/Uno.UI.netcoremobile/Debug/net10.0-ios26.0/Uno.UI.dll $W/native-patched.app/ && resign $W/native-patched.app
```

### B.5 Launch each copy

```bash
try() {   # $1 = copy name, $2 = bundle id
  xcrun simctl terminate $UDID $2 2>/dev/null; xcrun simctl uninstall $UDID $2 2>/dev/null
  xcrun simctl install $UDID $W/$1.app && xcrun simctl launch $UDID $2 >/dev/null
  sleep 10
  xcrun simctl io $UDID screenshot $W/$1.png >/dev/null 2>&1
  # A running app has a numeric PID in the first column.
  if xcrun simctl spawn $UDID launchctl list | awk -v b="$2" 'index($3, b) && $1 ~ /^[0-9]+$/' | grep -q .; then echo "$1: running"; else echo "$1: NOT running"; fi
}
try skia-stock com.companyname.scenetest
try skia-patched com.companyname.scenetest
try native-stock com.companyname.scenetestnative
try native-patched com.companyname.scenetestnative
```

Expected:
- Both `stock` copies are `NOT running`. Save the reason, as in Test A, with `process == "SceneTest"` or `process == "SceneTestNative"`.
- Both `patched` copies are `running`, and their screenshots in `$W` show the "Hello Uno Platform" page.

For each patched copy, also open Settings and come back, and rotate the device, as in Test A.

### B.6 Optional: native launch from a URL

Only the native renderer runs its own launch code when the scene connects. A cold start from a URL must raise `OnActivated` alone, as before. To check:

1. Add a URL scheme to `SceneTestNative/SceneTestNative/Platforms/iOS/Info.plist`:

   ```bash
   PL=$W/apps/SceneTestNative/SceneTestNative/Platforms/iOS/Info.plist
   /usr/libexec/PlistBuddy -c 'Add :CFBundleURLTypes array' -c 'Add :CFBundleURLTypes:0 dict' \
     -c 'Add :CFBundleURLTypes:0:CFBundleURLSchemes array' -c 'Add :CFBundleURLTypes:0:CFBundleURLSchemes:0 string scenetest' $PL
   ```

2. In `App.xaml.cs`:
   - Move the body of `OnLaunched` into a `CreateWindow(string arguments)` method, and call it from `OnLaunched`.
   - Override `OnActivated(Windows.ApplicationModel.Activation.IActivatedEventArgs args)` to call `CreateWindow("")` when `MainWindow` is null. Write the type's full name: a `using Windows.ApplicationModel.Activation;` makes `LaunchActivatedEventArgs` ambiguous with `Microsoft.UI.Xaml.LaunchActivatedEventArgs` (`CS0104`).
   - Log both events to a file:

     ```csharp
     static void Log(string m) => File.AppendAllText(
         Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "scenetest.log"),
         $"{DateTime.Now:HH:mm:ss.fff} {m}\n");
     // OnLaunched:  Log($"OnLaunched args='{args.Arguments}'");
     // OnActivated: Log($"OnActivated kind={args.Kind} previous={args.PreviousExecutionState}");
     ```

3. Rebuild with `--no-incremental`, with the branch's `Uno.Sdk` targets still in place (B.3). An incremental build keeps the old `Info.plist`, without the URL scheme:

   ```bash
   cd $W/apps
   dotnet build SceneTestNative/SceneTestNative/SceneTestNative.csproj -f net10.0-ios -c Debug \
     -p:RuntimeIdentifier=iossimulator-arm64 -p:ValidateXcodeVersion=false --no-incremental
   plutil -p $NA/Info.plist | grep -A4 CFBundleURLTypes   # must list scenetest
   ```

   Then make the `native-stock` and `native-patched` copies again (B.4), and for each copy (`C=native-patched`, then `C=native-stock`):

   ```bash
   N=com.companyname.scenetestnative
   xcrun simctl uninstall $UDID $N 2>/dev/null; xcrun simctl install $UDID $W/$C.app
   xcrun simctl openurl $UDID 'scenetest://cold'                                      # tap "Open" in the prompt
   sleep 8; xcrun simctl openurl $UDID 'scenetest://warm'                           # tap "Open" again
   sleep 3; cat "$(xcrun simctl get_app_container $UDID $N data)/Documents/scenetest.log"
   ```

Expected for `native-patched`: `OnActivated kind=Protocol previous=NotRunning` for the cold URL, with no `OnLaunched`, then `OnActivated kind=Protocol previous=Running` for the warm one. `native-stock` doesn't launch at all.

## 5. Optional: a physical device

The re-signing above works only on the simulator. On a device on iOS 27:

1. Build SamplesApp (Test A) with `-p:UnoSampleAppRuntimeIdentifiers=ios-arm64`, for both the restore and the build, and your signing identity: `-p:CodesignKey="Apple Development: …"` and `-p:CodesignProvision=…`, or automatic provisioning.
2. Install it with `xcrun devicectl device install app --device <id> <path to SamplesApp.app>`.
3. Launch it, and check that the samples list appears.

## 6. Clean up

```bash
rm -rf ~/.nuget/packages/uno.sdk/6.8.0-dev.66/targets && cp -R $W/uno.sdk-targets.bak ~/.nuget/packages/uno.sdk/6.8.0-dev.66/targets
for b in uno.platform.samplesapp.skia com.companyname.scenetest com.companyname.scenetestnative; do xcrun simctl uninstall $UDID $b; done
```

## 7. What to report

Record the versions:

```bash
xcodebuild -version; xcrun simctl list runtimes | grep 'iOS 27'; dotnet --version; dotnet workload list | grep -i ios
```

Then fill in this table, adding any failure message you saved:

| Check | Expected | Result |
|---|---|---|
| A: `DTPlatformVersion` of SamplesApp | 27.x | |
| A: runtime test, key `true` | Passed | |
| A: runtime test, key removed | Passed | |
| A: key `false` | Not launched, scene life cycle error | |
| A: samples list, rotation, background and back | Works | |
| B.3: stock `Uno.Sdk` build | Fails on the minimum version | |
| B.3: branch `Uno.Sdk` targets | Builds with 15.0 and the message | |
| B.5: Skia stock / patched | Not running / running | |
| B.5: native stock / patched | Not running / running | |
| B.6: native cold URL / warm URL (optional) | `OnActivated` NotRunning only / `OnActivated` Running | |
| Device (optional) | Launches | |

## Troubleshooting

- **`DTPlatformVersion` is 26.x:** another Xcode was used. Check `DEVELOPER_DIR` and `xcodebuild -version` in the same terminal. If `MD_APPLE_SDK_ROOT` is set in your shell, unset it, as the build still reads it.
- **`NETSDK1005` (assets file has no target):** restore again with the same override and target framework as the build.
- **`MSB3030` on `Uno.UI.RemoteControl.Host/.../apphost`:** SamplesApp was built with `-p:RuntimeIdentifier`. Use `-p:UnoSampleAppRuntimeIdentifiers` instead, and restore again.
- **Xcode version error:** add `-p:ValidateXcodeVersion=false`. The `net9.0` and `26.0` packs expect an older Xcode.
- **Linker error `MT0180` or a native link failure:** add `-p:MtouchLink=SdkOnly`.
- **A URL opens another app:** two installed apps share the `scenetest` scheme. Uninstall the other one.

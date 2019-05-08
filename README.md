# xamarin-ui-fabric-ios
Xamarin binding for [Office UI Fabric for iOS](https://github.com/OfficeDev/ui-fabric-ios) `v0.2.2`.

## How to build the binding and run the sample

1. `cd` into `external` folder.
2. run `make` (You will need to have [CocoaPods](https://cocoapods.org) installed).
3. The `OfficeUIFabric.framework` fat framework will be generated.
4. Go and open [OfficeUIFabricDemos.sln](samples/OfficeUIFabricDemos/OfficeUIFabricDemos.sln).
5. Hit build and enjoy!

### TODO for your own project

Since this library is built with Swift you need to add the Swift support libraries to your Xamarin app,
if you copy the following **msbuild** script into your app's csproj as show in [OfficeUIFabricDemos.csproj](samples/OfficeUIFabricDemos/OfficeUIFabricDemos/OfficeUIFabricDemos.csproj)
(look at the very bottom of the file) you should be fine to build and deploy your app.

```xml
  <PropertyGroup>
    <_SwiftySwiftMasterAfterTargets>_CodesignNativeLibraries</_SwiftySwiftMasterAfterTargets>
    <_SwiftySwiftMasterDependsOnTargets>_SwiftySwiftCopySwiftDependencies</_SwiftySwiftMasterDependsOnTargets>
    <_XcodeToolChainRelativeToSdkRoot>/../../../../../Toolchains/XcodeDefault.xctoolchain/</_XcodeToolChainRelativeToSdkRoot>
    <_TargetPlatform Condition=" '$(Platform)' == 'iPhoneSimulator' ">iphonesimulator</_TargetPlatform>
    <_TargetPlatform Condition=" '$(Platform)' == 'iPhone' ">iphoneos</_TargetPlatform>
    <_SwiftySwiftRemoteMirror Condition=" '$(Configuration)' != 'Debug' "></_SwiftySwiftRemoteMirror>
    <_SwiftySwiftRemoteMirror Condition=" '$(Configuration)' == 'Debug' ">--resource-library libswiftRemoteMirror.dylib</_SwiftySwiftRemoteMirror>
  </PropertyGroup>
  <Target Name="_SwiftySwiftMasterTarget" Condition="'$(_SwiftySwiftMasterDependsOnTargets)'!=''" AfterTargets="$(_SwiftySwiftMasterAfterTargets)" DependsOnTargets="$(_SwiftySwiftMasterDependsOnTargets);_DetectSigningIdentity" />
  <Target Name="_SwiftySwiftCopySwiftDependencies" Condition="!Exists('$(_AppBundlePath)Frameworks/libswiftCore.dylib')">
    <Message Text="Copying Swift Frameworks dependencies for $(_NativeExecutable) to the $(_AppBundlePath)Frameworks folder." />
    <Exec Condition="'$(_CodeSigningKey)' != ''" SessionId="$(BuildSessionId)" Command="$(_SdkRoot)$(_XcodeToolChainRelativeToSdkRoot)usr/bin/swift-stdlib-tool --copy --verbose --sign '$(_CodeSigningKey)' --scan-executable '$(_NativeExecutable)' --scan-folder '$(_AppBundlePath)Frameworks/' --scan-folder '$(_AppBundlePath)PlugIns/' --platform '$(_TargetPlatform)' --toolchain '$(_SdkRoot)$(_XcodeToolChainRelativeToSdkRoot)' --destination '$(_AppBundlePath)Frameworks/' $(_SwiftySwiftRemoteMirror) --unsigned-destination '$(DeviceSpecificIntermediateOutputPath)/SwiftSupport' --strip-bitcode --strip-bitcode-tool '$(_SdkRoot)$(_XcodeToolChainRelativeToSdkRoot)usr/bin/bitcode_strip' --emit-dependency-info '$(DeviceSpecificIntermediateOutputPath)/SwiftStdLibToolInputDependencies.dep'" />
    <Exec Condition="'$(_CodeSigningKey)' == ''" SessionId="$(BuildSessionId)" Command="$(_SdkRoot)$(_XcodeToolChainRelativeToSdkRoot)usr/bin/swift-stdlib-tool --copy --verbose                             --scan-executable '$(_NativeExecutable)' --scan-folder '$(_AppBundlePath)Frameworks/' --scan-folder '$(_AppBundlePath)PlugIns/' --platform '$(_TargetPlatform)' --toolchain '$(_SdkRoot)$(_XcodeToolChainRelativeToSdkRoot)' --destination '$(_AppBundlePath)Frameworks/' $(_SwiftySwiftRemoteMirror) --unsigned-destination '$(DeviceSpecificIntermediateOutputPath)/SwiftSupport' --strip-bitcode --strip-bitcode-tool '$(_SdkRoot)$(_XcodeToolChainRelativeToSdkRoot)usr/bin/bitcode_strip' --emit-dependency-info '$(DeviceSpecificIntermediateOutputPath)/SwiftStdLibToolInputDependencies.dep'" />
  </Target>
  <Target Name="_SwiftySwiftCopySwiftSupport" Condition="'$(ArchiveOnBuild)'=='true'" AfterTargets="Archive">
    <Message Text="Copying SwiftSupport folder from $(DeviceSpecificIntermediateOutputPath)/SwiftSupport to $(ArchiveDir)/SwiftSupport folder." />
    <Ditto
        SessionId="$(BuildSessionId)"
        Condition="'$(IsMacEnabled)' == 'true'"
        ToolExe="$(DittoExe)"
        ToolPath="$(DittoPath)"
        Source="$(DeviceSpecificIntermediateOutputPath)/SwiftSupport"
        Destination="$(ArchiveDir)/SwiftSupport" />
  </Target>
```

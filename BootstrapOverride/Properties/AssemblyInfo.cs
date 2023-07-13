using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using MelonLoader;
using BootstrapOverride;

[assembly: AssemblyTitle(nameof(BootstrapOverride))]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(null!)]
[assembly: AssemblyProduct(nameof(BootstrapOverride))]
[assembly: AssemblyCopyright("Copyright (c) 2023 Frederick (Millzy) Mills")]
[assembly: AssemblyTrademark(null!)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("0.1.0.0")]
[assembly: AssemblyFileVersion("0.1.0")]
[assembly: NeutralResourcesLanguage("en")]

[assembly: MelonInfo(
    typeof(Mod),
    nameof(BootstrapOverride),
    "0.1.0",
    "Millzy",
    $"https://github.com/MillzyDev/MenuSkip/releases/latest/download/{nameof(BootstrapOverride)}.zip"
)]
[assembly: MelonID($"dev.millzy.{nameof(BootstrapOverride)}")]
[assembly: MelonGame("Stress Level Zero", "BONELAB")]
[assembly: MelonIncompatibleAssemblies("MenuSkipper")]

[assembly: VerifyLoaderVersion("0.5.7")]

[assembly: HarmonyDontPatchAll]

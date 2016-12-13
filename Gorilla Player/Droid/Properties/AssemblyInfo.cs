using System.Reflection;
using System.Runtime.CompilerServices;
using Android.App;
using UXDivers.Gorilla.Droid;

// Information about this assembly is defined by the following attributes.
// Change them to the values specific to your project.

[assembly: AssemblyTitle (AssemblyGlobal.ProductLine + " - " + "Generic Player (Android)")]
[assembly: AssemblyDescription (AssemblyGlobal.ProductLine + " - " + "Generic Player (Android)")]
[assembly: AssemblyConfiguration (AssemblyGlobal.Configuration)]
[assembly: AssemblyCompany (AssemblyGlobal.Company)]
[assembly: AssemblyProduct (AssemblyGlobal.ProductLine + " - " + "Generic Player (Android)")]
[assembly: AssemblyCopyright (AssemblyGlobal.Copyright)]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion (AssemblyGlobal.AssemblyVersion)]

// The following attributes are used to specify the signing key for the assembly,
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]

#if DEBUG
[assembly: Android.App.Application(Debuggable=true, Icon = "@drawable/icon")]
#else
[assembly: Android.App.Application(Debuggable=false, Icon = "@drawable/icon")]
#endif

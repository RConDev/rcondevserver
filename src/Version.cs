using System.Reflection;

[assembly: AssemblyProduct("RCon Development Server")]
[assembly: AssemblyCompany("RCon Development")]
[assembly: AssemblyCopyright("Copyright © 2012-2013 RCon Development Server")]
[assembly: AssemblyTrademark("")]

#if DEBUG

[assembly: AssemblyConfiguration("Debug")]
#else
    [assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyVersion("0.7.0.0")]
[assembly: AssemblyFileVersion("0.7.0.0")]
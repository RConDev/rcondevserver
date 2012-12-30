using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("RConDevServer.Protocol.Dice.Battlefield3")]
[assembly: AssemblyDescription("RCon Protocol for Battlefield 3")]


// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("5a294309-e6aa-4cff-8d5d-8cef8694b2c0")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log.config", Watch = true)]

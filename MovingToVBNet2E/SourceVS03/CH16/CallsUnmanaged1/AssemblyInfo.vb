Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Security.Permissions


' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("CallsUnmanaged")> 
<Assembly: AssemblyDescription("App that calls unmanaged class")> 
<Assembly: AssemblyCompany("Desaware Inc.")> 
<Assembly: AssemblyProduct("Moving to VB.NET")> 
<Assembly: AssemblyCopyright("Copyright ©2001-2003 by Desaware Inc.")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM

<Assembly: Guid("bfcf1f4c-be33-4661-807e-af81a4ad90c2")>

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:

<Assembly: AssemblyVersionAttribute("1.0.0.0")> 
<Assembly: AssemblyKeyFile("..\..\testkeys.snk")> 


' Try with and without the following line
'<Assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum, Flags:=SecurityPermissionFlag.UnmanagedCode)> 

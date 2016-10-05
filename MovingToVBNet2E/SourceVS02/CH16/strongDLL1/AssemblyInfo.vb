Imports System.Reflection
Imports System.Runtime.InteropServices


' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("StrongDLL1")> 
<Assembly: AssemblyDescription("Strong named DLL V1")> 
<Assembly: AssemblyCompany("Desaware Inc.")> 
<Assembly: AssemblyProduct("Moving to VB.NET")> 
<Assembly: AssemblyCopyright("Copyright ©2001 by Desaware Inc.")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM

<Assembly: Guid("4331a3a2-8382-4ddd-bf60-fdf904967161")>

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:
<Assembly: AssemblyKeyFile("testkeys.snk")> 
#If V1 Then
<Assembly: AssemblyVersion("1.0.0.0")> 
#End If
#If V2 Then
<Assembly: AssemblyVersion("1.0.0.2")> 
#End If

' Reflection and attributes example
' Copyright ©2001 by Desaware Inc. All Rights Reserved

Imports System.Reflection
' Reflection sample program
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Module Module1

    Sub ShowMembers(ByVal ThisType As Type)
        Dim Index As Integer
        Dim idx2 As Integer
        Dim members() As MemberInfo
        ' Find all of the field members for ThisType
        ' You could search for methods, properties, interfaces, etc. as well.
        ' Find both private and public instance members (but not static)
        members = ThisType.FindMembers(MemberTypes.Field, BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.NonPublic, Type.FilterName, "*")
        For index = 0 To ubound(Members)
            Dim fi As FieldInfo
            ' Since we know it's a field, it's safe to cast to FieldInfo here.
            fi = CType(Members(Index), FieldInfo)
            ' Pull the name and the type of the field
            Console.Write("  Member: " + members(Index).Name + " Type:" + fi.FieldType.ToString())
            ' And read the field attribute to determine if it's public or private
            If (fi.Attributes And FieldAttributes.Public) <> 0 Then
                Console.WriteLine(" - is Public")
            End If
            If (fi.Attributes And FieldAttributes.Private) <> 0 Then
                Console.WriteLine(" - is Private")
            End If
            ' This will be added in the next example
            ' ShowCustomAttributes(fi.GetCustomAttributes())
        Next Index



    End Sub

    Sub AssemblyTypes()
        Dim TypeIndex As Integer
        Dim A As System.Reflection.Assembly
        Dim ATypes() As Type
        ' We're going to explore the current assembly
        A = A.GetExecutingAssembly()
        ' Find all the types exposed by this assembly
        ATypes = A.GetTypes()
        For TypeIndex = 0 To UBound(ATypes)
            ' Note the full name of each type
            Console.WriteLine("Type: " + ATypes(TypeIndex).FullName)
            ' If it's an enumeration, list the enumeration values
            If ATypes(TypeIndex).IsEnum Then
                Dim EnumStrings() As String
                ' Get the names
                EnumStrings = System.Enum.GetNames(ATypes(TypeIndex))
                Console.WriteLine("   Enumeration names are: ")
                Dim estemp As String
                For Each estemp In EnumStrings
                    ' Display the names, and each value
                    Console.WriteLine("     " + estemp + " = " + System.Enum.Format(ATypes(TypeIndex), System.Enum.Parse(ATypes(TypeIndex), estemp), "D"))
                Next
            End If
            ' For nested types (which represent those defined by the programmer within the assembly)
            ' Show all of the members
            If ATypes(TypeIndex).MemberType = MemberTypes.NestedType Then
                ' Show the custom attributes - This will be added in the next example
                ' ShowCustomAttributes(ATypes(TypeIndex).GetCustomAttributes())
                ShowMembers(ATypes(TypeIndex))
            End If
            Console.WriteLine()
        Next

    End Sub


    Sub Main()
        AssemblyTypes()
        Console.ReadLine()

    End Sub

End Module


' Reflection and attributes example
' Copyright ©2001 by Desaware Inc. All Rights Reserved

Imports System.Reflection
Module Module1

    Sub ShowEnum(ByVal ThisType As Type)
        Dim q As Char = controlchars.Quote
        If ThisType.IsEnum Then
            Dim EnumStrings() As String
            ' Get the names
            EnumStrings = System.Enum.GetNames(ThisType)
            'Console.WriteLine("   Enumeration names are: ")
            Dim estemp As String
            For Each estemp In EnumStrings
                ' Display the names, and each value
                Console.WriteLine(q + ThisType.FullName + q + "," + q + estemp + q + ",Enum," + q + CInt(System.Enum.Parse(ThisType, estemp)).ToString() + q)
            Next
        End If

    End Sub

    Sub ShowMembers(ByVal ThisType As Type)
        Dim Index As Integer
        Dim idx2 As Integer
        Dim members() As MemberInfo
        If ThisType.IsEnum Then
            ShowEnum(ThisType)
        End If

        members = ThisType.FindMembers(MemberTypes.All, BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.Static, Type.FilterName, "*")
        For index = 0 To ubound(Members)

            Console.Write(controlchars.quote + ThisType.Fullname() + controlchars.quote + "," + controlchars.quote + Members(index).Name)
            If Members(Index).MemberType() = MemberTypes.Method Then
                ' It's a method
                Dim mt As MethodInfo
                Dim params() As ParameterInfo
                Dim pi As ParameterInfo
                Dim pnum As Integer
                mt = CType(members(Index), MethodInfo)
                params = mt.GetParameters()
                Console.Write("(")
                For pnum = 0 To UBound(params)
                    pi = params(pnum)
                    If pnum <> 0 Then Console.Write(",")
                    Console.Write(pi.ParameterType.Name)
                Next
                Console.Write(")")
            End If

            Console.Write(Controlchars.Quote + "," + controlchars.quote + System.Enum.GetName(GetType(System.Reflection.MemberTypes), Members(Index).MemberType()) + controlchars.quote + "," + ControlChars.Quote + ControlChars.Quote)
            Console.WriteLine()
        Next index
    End Sub

    Sub AssemblyTypes()
        Dim TypeIndex As Integer
        Dim A As System.Reflection.Assembly
        Dim ATypes() As Type
        Dim sep As String = controlchars.Quote + "," + controlchars.Quote
        ' We're going to explore the current assembly
        A = A.LoadWithPartialName("Microsoft.VisualBasic")
        ' A = A.LoadFrom("c:\somedll.dll")
        ' Find all the types exposed by this assembly
        Console.WriteLine(Controlchars.Quote + "Namespace" + sep + "Member" + sep + "MemberType" + sep + "EnumValue" + controlchars.Quote)

        ATypes = A.GetTypes()
        For TypeIndex = 0 To UBound(ATypes)
            ' Note the full name of each type
            'Console.WriteLine("Type: " + ATypes(TypeIndex).FullName)
            ' If it's an enumeration, list the enumeration values

            If ATypes(TypeIndex).IsEnum Then
                ShowEnum(ATypes(TypeIndex))
            End If

            ' For nested types (which represent those defined by the programmer within the assembly)
            ' Show all of the members
            If ATypes(TypeIndex).MemberType = MemberTypes.NestedType Then
                ' Show the custom attributes - This will be added in the next example
                ' ShowCustomAttributes(ATypes(TypeIndex).GetCustomAttributes())
                ShowMembers(ATypes(TypeIndex))
            End If

            If ATypes(TypeIndex).MemberType = MemberTypes.TypeInfo Then
                ' Show the custom attributes - This will be added in the next example
                ' ShowCustomAttributes(ATypes(TypeIndex).GetCustomAttributes())
                ShowMembers(ATypes(TypeIndex))
            End If

        Next

    End Sub


    Sub Main()
        AssemblyTypes()

    End Sub

End Module

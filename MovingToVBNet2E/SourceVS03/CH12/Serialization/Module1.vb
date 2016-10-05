' Simple serialization example
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Imports System.Runtime.Serialization

<Serializable()> Public Class SerializationTest

    Public m_MyString As String
    Public m_MyInteger As Integer

    Public Function DumpToSoap(ByVal sc As SerializationTest) As String
        Dim ms As New System.IO.MemoryStream()
        Dim sf As New Formatters.Soap.SoapFormatter()
        ' Serialize the class into the memory stream
        sf.Serialize(ms, sc)
        ms.Flush()
        ' Read the stream out into a string
        ms.Seek(0, IO.SeekOrigin.Begin)
        Dim tr As New System.IO.StreamReader(ms)
        Dim res As String
        res = tr.ReadToEnd()
        ms.Close()
        Return res
    End Function

    Public Shared Function GetFromSoap(ByVal soapstring As String) As SerializationTest
        Dim ms As New System.IO.MemoryStream()
        Dim sw As New System.IO.StreamWriter(ms)
        ' Write the string into a memorystream
        sw.Write(soapstring)
        sw.Flush()
        ms.Flush()
        ms.Seek(0, IO.SeekOrigin.Begin)
        Dim sc As SerializationTest
        ' Load the object from the Soap description
        Dim sf As New Formatters.Soap.SoapFormatter()
        sc = CType(sf.Deserialize(ms), SerializationTest)
        ms.Close()
        Return (sc)
    End Function

End Class


Module Module1

    Sub Main()
        Dim st As New SerializationTest()
        st.m_MyInteger = 5
        st.m_MyString = "A test string"

        Dim soapstring As String
        soapstring = st.DumpToSoap(st)
        Console.WriteLine(soapstring)
        st = serializationtest.GetFromSoap(soapstring)
        console.WriteLine("Results after object is loaded")
        console.WriteLine(st.m_MyString & "  " & CStr(st.m_MyInteger))
        console.ReadLine()

    End Sub

End Module

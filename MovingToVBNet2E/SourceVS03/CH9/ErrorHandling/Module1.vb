' Error Handling example
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved
Imports System.IO
Module Module1

    Const ShowErrors As Boolean = True
    Const ThrowOnBadFormat As Boolean = True

    Sub Main()
        Dim FileToRead As String
        Try
            ' Putting everything in a Try Block allows catching Exit Sub easily
            FileToRead = CurDir + "\TestFile.txt"
            Dim TestFile As FileStream
            Try
                TestFile = New FileStream(FileToRead, FileMode.Open, FileAccess.Read)
            Catch E As FileNotFoundException
                ' If the file isn't found (typically the case), create a new one
                Try
                    TestFile = New FileStream(FileToRead, FileMode.Create, FileAccess.ReadWrite)
                    Dim Writer As New StreamWriter(TestFile)
                    Writer.WriteLine("8")
                    Writer.WriteLine("7")
                    Writer.WriteLine("0")
                    Writer.WriteLine("ABC")
                    Writer.WriteLine("5")
                    ' Don't forget to Flush!!!!                    
                    Writer.Flush()
                    TestFile.Seek(0, SeekOrigin.Begin)
                Catch CantCreate As Exception
                    ' Unlikely to happen with this example
                    Console.WriteLine("Can't create or write the file")
                    Exit Sub
                End Try
            Catch E2 As Exception
                Console.WriteLine("Some other errror occurred")
                ' Note: Exit Sub does not avoid Finally blocks!
                Exit Sub
            End Try

            ' If we got this far, the TestFile is open

            Try
                Dim Reader As New StreamReader(TestFile)
                Do
                    Dim I As Integer, S As String
                    Dim Result As Integer
                    Try
                        S = Reader.ReadLine()
                        I = CInt(S)
                        Result = 100 \ I
                        Console.WriteLine(Result)
                    Catch DivByZero As System.DivideByZeroException
                        If Not ShowErrors Then Exit Try
                        Console.WriteLine("** Divide by zero **")

                    Catch BadConversion As System.InvalidCastException
                        If ShowErrors Then Console.WriteLine("** " + S + " is not a number **")
                        If ThrowOnBadFormat Then Throw New System.InvalidCastException("My own exception happened here", BadConversion)

                    Catch OtherErrors As Exception
                        ' This catch block is meaningless!
                        Throw OtherErrors
                    End Try
                Loop While Reader.Peek <> -1
            Catch E As Exception
                ' How you might catch an error coming from another assembly
                Console.WriteLine(ControlChars.CrLf + "An internal error occurred")
                Console.WriteLine("Message: " + E.Message)
                Console.WriteLine("Source Message: " + E.InnerException.Message)
                Dim F As Integer, S As New StackTrace(E)
                Console.WriteLine("StackFrame: ")
                For f = 0 To S.FrameCount - 1
                    Console.WriteLine(S.GetFrame(f).ToString())
                Next F
            Finally
                ' We're virtually certain to close ok
                TestFile.Close()
                ' Delete could fail though due to security
                File.Delete(FileToRead)
            End Try

        Catch Unhandled As Exception
            ' Just in case we overlooked something here.
            ' YOU should control which errors are propagated outward!
            Console.WriteLine("An unhandled exception occurred " + Unhandled.Message)
        Finally
            Console.ReadLine()
        End Try
    End Sub

End Module

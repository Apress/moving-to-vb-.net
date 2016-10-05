' Probe example
' Copyright ©2001-2003 by Desaware Inc.

Imports System.Net
Public Class ProbeForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    ' Allow access to UI elements from other thread. Windows will marshal to the context
    Friend WithEvents listBox1 As System.Windows.Forms.ListBox
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents cmdProbe As System.Windows.Forms.Button
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents statusBar1 As System.Windows.Forms.StatusBar

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.cmdProbe = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.listBox1 = New System.Windows.Forms.ListBox()
        Me.statusBar1 = New System.Windows.Forms.StatusBar()
        Me.SuspendLayout()
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(88, 16)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(184, 20)
        Me.txtIP.TabIndex = 1
        Me.txtIP.Text = ""
        '
        'cmdProbe
        '
        Me.cmdProbe.Location = New System.Drawing.Point(112, 48)
        Me.cmdProbe.Name = "cmdProbe"
        Me.cmdProbe.Size = New System.Drawing.Size(64, 24)
        Me.cmdProbe.TabIndex = 3
        Me.cmdProbe.Text = "Probe"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(32, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(56, 23)
        Me.label1.TabIndex = 2
        Me.label1.Text = "IP:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'listBox1
        '
        Me.listBox1.Location = New System.Drawing.Point(16, 88)
        Me.listBox1.Name = "listBox1"
        Me.listBox1.Size = New System.Drawing.Size(256, 160)
        Me.listBox1.TabIndex = 0
        '
        'statusBar1
        '
        Me.statusBar1.Location = New System.Drawing.Point(0, 253)
        Me.statusBar1.Name = "statusBar1"
        Me.statusBar1.Size = New System.Drawing.Size(292, 20)
        Me.statusBar1.TabIndex = 5
        Me.statusBar1.Text = "statusBar1"
        '
        'ProbeForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.statusBar1, Me.cmdProbe, Me.label1, Me.txtIP, Me.listBox1})
        Me.Name = "ProbeForm"
        Me.Text = "port prober"
        Me.ResumeLayout(False)

    End Sub


#End Region
    Private ProbingThread As Threading.Thread    Private ProberClass As SocketProber    Private Sub cmdProbe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProbe.Click        If cmdProbe().Text = "Stop" Then
            ProberClass.StopTheThread = True
            ProbingThread.Join()
            cmdProbe().Text = "Probe"
            ProbingThread = Nothing
            ProberClass = Nothing
            Exit Sub
        End If
        ProberClass = New SocketProber()
        ProberClass.TheForm = Me
        ProbingThread = New System.Threading.Thread(New Threading.ThreadStart(AddressOf ProberClass.SubThreadEntry))
        cmdProbe().Text = "Stop"
        listBox1().Items.Clear()

        ProbingThread.Start()
    End Sub

    Friend Function GetIP() As String
        Return txtIP.Text
    End Function

    Friend Sub SetStatus(ByVal s As String)
        Me.statusBar1.Text = s
    End Sub

    Friend Sub AddToList(ByVal s As String)
        listBox1.Items.Add(s)
    End Sub
End Class

Delegate Function fNoParams() As String
Delegate Sub fSetString(ByVal s As String)

Class SocketProber
    Friend TheForm As ProbeForm    Friend StopTheThread As Boolean    Public Sub SubThreadEntry()        Dim s As Sockets.Socket
        Dim ip As IPAddress
        Dim ep As IPEndPoint
        Dim textfp As fNoParams = AddressOf TheForm.GetIP

        ip = IPAddress.Parse(CStr(TheForm.Invoke(textfp)))
        Dim portnumber As Integer
        For portnumber = 1 To &H7FFF
            Dim fpstat As fSetString = AddressOf TheForm.SetStatus
            TheForm.Invoke(fpstat, New String() {"Checking port: " & Str(portnumber)})
            ep = New IPEndPoint(ip, portnumber)
            s = New Sockets.Socket(Sockets.AddressFamily.InterNetwork, Sockets.SocketType.Stream, Sockets.ProtocolType.Tcp)
            Try
                s.Connect(ep)
                Dim plist As fSetString = AddressOf TheForm.AddToList
                TheForm.Invoke(plist, New String() {"Connected to port " & Str(portnumber)})
            Catch ex As Exception
                debug.WriteLine("Failed port " & Str(portnumber) & " - " & ex.Message)
            End Try

            s.Close()
            If StopTheThread Then Exit Sub ' Request to terminate
        Next
    End Sub
End Class
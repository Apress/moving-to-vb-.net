' DirectMember sample program
' Copyright ©2001 by Desaware Inc. - All Rights Reserved

Imports System.Reflection
Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        LoadTreeview()
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
    Friend WithEvents treeView1 As System.Windows.Forms.TreeView

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.treeView1 = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'treeView1
        '
        Me.treeView1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.treeView1.ImageIndex = -1
        Me.treeView1.Location = New System.Drawing.Point(8, 16)
        Me.treeView1.Name = "treeView1"
        Me.treeView1.SelectedImageIndex = -1
        Me.treeView1.Size = New System.Drawing.Size(448, 200)
        Me.treeView1.Sorted = True
        Me.treeView1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(467, 248)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.treeView1})
        Me.Name = "Form1"
        Me.Text = "View Direct Members of Objects"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Function StripType(ByVal s As String) As String
        Dim spacepos As Integer
        spacepos = InStr(s, " ")
        If spacepos > 0 Then Return Mid$(s, spacepos + 1)
        Return (s)
    End Function

    Private Sub LoadTreeview()
        Dim asm As [Assembly]
        Dim asmtypes() As Type
        Dim ThisType As Type
        asm = Reflection.Assembly.GetAssembly(GetType(System.Windows.Forms.Form))
        asmtypes = asm.GetTypes()
        For Each ThisType In asmtypes
            If ThisType.IsClass And ThisType.IsPublic Then
                Dim tn As New TreeNode(ThisType.Name)
                Dim members(), mi As MemberInfo
                treeView1.Nodes.Add(tn)
                members = ThisType.GetMembers(BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.Static)
                For Each mi In members
                    Dim methinfo As MethodInfo
                    Select Case mi.MemberType
                        Case MemberTypes.Method
                            methinfo = CType(mi, MethodInfo)
                            If Not methinfo.IsSpecialName Then
                                tn.Nodes.Add(StripType(mi.ToString))
                            End If
                        Case MemberTypes.Event
                            tn.Nodes.Add(StripType(mi.ToString) & " event")
                        Case Else
                            tn.Nodes.Add(StripType(mi.ToString))
                    End Select
                Next
            End If
        Next
    End Sub


End Class

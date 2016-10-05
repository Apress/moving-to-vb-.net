' Inheritance derivation list and interface lists
' Copyright ©2001-2003 by Desaware Inc.
Imports System.Diagnostics
Imports System.Reflection
Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim AssemblyList() As System.Reflection.Assembly
    Dim AllObjects As New ArrayList()   ' List of all objects


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ' Hold on to a list of all assemblies loaded into this app domain
        Dim ReferencedNames() As AssemblyName
        Dim AName As AssemblyName
        ' First get a list of all the assemblies referenced
        ReferencedNames = System.Reflection.Assembly.GetExecutingAssembly.GetReferencedAssemblies()
        ' Try to load each assembly - ignore errors on assemblies already loaded
        For Each AName In ReferencedNames
            Try
                AppDomain.CurrentDomain.Load(AName)
            Catch e As Exception
                System.Diagnostics.Debug.WriteLine("Could not load " & AName.Name)
            End Try
        Next
        ' Now get a list of all the loaded assemblies
        AssemblyList = AppDomain.CurrentDomain.GetAssemblies()
        GetAllObjectAndInterfaceNames()
        cmdScan().Enabled = True
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
    Friend WithEvents listBox1 As System.Windows.Forms.ListBox
    Friend WithEvents cmdScan As System.Windows.Forms.Button
    Friend WithEvents txtClass As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents listBox2 As System.Windows.Forms.ListBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents cmdCopy As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cmdScan = New System.Windows.Forms.Button()
        Me.txtClass = New System.Windows.Forms.TextBox()
        Me.listBox1 = New System.Windows.Forms.ListBox()
        Me.listBox2 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'cmdCopy
        '
        Me.cmdCopy.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdCopy.Location = New System.Drawing.Point(272, 40)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(64, 24)
        Me.cmdCopy.TabIndex = 6
        Me.cmdCopy.Text = "Copy"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(16, 200)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(176, 16)
        Me.label2.TabIndex = 5
        Me.label2.Text = "Derived or implemented by:"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(16, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(40, 16)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Class:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdScan
        '
        Me.cmdScan.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdScan.Enabled = False
        Me.cmdScan.Location = New System.Drawing.Point(92, 40)
        Me.cmdScan.Name = "cmdScan"
        Me.cmdScan.Size = New System.Drawing.Size(64, 24)
        Me.cmdScan.TabIndex = 3
        Me.cmdScan.Text = "Scan"
        '
        'txtClass
        '
        Me.txtClass.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtClass.Location = New System.Drawing.Point(64, 16)
        Me.txtClass.Name = "txtClass"
        Me.txtClass.Size = New System.Drawing.Size(336, 20)
        Me.txtClass.TabIndex = 0
        Me.txtClass.Text = "System."
        '
        'listBox1
        '
        Me.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.listBox1.Location = New System.Drawing.Point(16, 72)
        Me.listBox1.Name = "listBox1"
        Me.listBox1.Size = New System.Drawing.Size(384, 121)
        Me.listBox1.TabIndex = 2
        '
        'listBox2
        '
        Me.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.listBox2.Location = New System.Drawing.Point(16, 216)
        Me.listBox2.Name = "listBox2"
        Me.listBox2.Size = New System.Drawing.Size(384, 95)
        Me.listBox2.Sorted = True
        Me.listBox2.TabIndex = 4
        '
        'Form1
        '
        Me.AcceptButton = Me.cmdScan
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(411, 328)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCopy, Me.label2, Me.listBox2, Me.cmdScan, Me.listBox1, Me.label1, Me.txtClass})
        Me.Name = "Form1"
        Me.Text = "Derivation List"
        Me.ResumeLayout(False)

    End Sub


#End Region


    Private Sub cmdScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScan.Click        Dim oi As ObjectInfo
        Dim col As Collection
        Try
            listBox1().Items.Clear()
            listBox2().Items.Clear()
            oi = Me.GetInfoForObject(txtClass().Text)
            If Not oi Is Nothing Then
                Dim S As String
                ' Update the text box with the correct casing for the object name (search is case insensitive)
                txtClass().Text = oi.ObjectName
                ' List derivation tree
                For Each S In oi.DerivationList
                    listBox1().Items.Insert(0, S)
                Next
                listBox1().Items.Add("Interfaces:")
                Dim T As Type
                ' List implemented interfaces
                For Each T In oi.ImplementsList
                    listBox1().Items.Add(T.FullName)
                Next
                ' List all objects that inherit from this one
                col = WhoInheritsFrom(oi.ObjectName)
                For Each S In col
                    listBox2().Items.Add(S)
                Next
                ' List all objects that implement this one
                '(only appliable to interfaces, but will return Nothing if
                ' object is not an interface)
                col = WhoImplements(oi.ObjectName)
                For Each S In col
                    listBox2().Items.Add(S)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message & txtClass().Text)
        End Try
    End Sub
    ' The ObjectInfo class contains the derivation list and list of implemented interfaces
    ' for an object
    Class ObjectInfo
        Public DerivationList As New ArrayList(2) ' Names of base classes in reverse order
        Public ImplementsList() As Type ' Type references to implemented interfaces
        Public ObjectName As String

        ' Loads the object based on the type name. Assumes it is in assembly UseAssembly
        Public Sub LoadObject(ByVal objname As String, ByVal UseAssembly As [Assembly])
            Dim T As Type
            T = UseAssembly.GetType(objname, False, True)
            If T Is Nothing Then
                ' Should never happen
                Throw (New Exception("Unable to obtain type for object"))
            End If
            ImplementsList = T.GetInterfaces()
            ' Note the order of insertion
            Do While Not T Is Nothing
                DerivationList.Insert(0, T.FullName)
                T = T.BaseType
            Loop
            ObjectName = objname
        End Sub

        ' Returns True if the derivedclass is a base class to this one.
        Public Function IsDerivedFrom(ByVal derivedclass As String) As Boolean
            Dim S As String
            For Each S In DerivationList
                If S = derivedclass Then Return (True)
            Next
        End Function

        ' Returns true if ImplementedInterface is implemented by this interface
        Public Function ImplementsInterface(ByVal ImplementedInterface As String) As Boolean
            Dim T As Type
            For Each T In ImplementsList
                If ImplementedInterface = T.FullName Then Return (True)
            Next
        End Function

    End Class

    ' Loads the AllObjects array with ObjectInfo class for an object
    Public Sub LoadTypeInfo(ByVal T As Type, ByVal A As [Assembly])
        Dim TypeArray() As Type
        ' If type info is to a nested assembly (nested namespace), call recursively for
        ' each nested type
        If T.IsNestedAssembly Then
            TypeArray = T.GetNestedTypes
            Dim T2 As Type
            For Each T2 In TypeArray
                LoadTypeInfo(T2, A)
            Next
        End If
        ' We're including interfaces, enumerations, classes and primitives
        If T.IsInterface Or T.IsEnum Or T.IsClass Or T.IsPrimitive Then
            Dim NewObject As New ObjectInfo()
            NewObject.LoadObject(T.FullName, A)
            AllObjects.Add(NewObject)
        End If

    End Sub

    ' Loads the AllObjects array with ObjectInfo class for all objects.
    ' Searches all loaded assemblies
    Public Sub GetAllObjectAndInterfaceNames()
        Dim A As [Assembly]
        Dim TypeArray() As Type
        Dim T As Type
        For Each A In AssemblyList
            Debug.WriteLine(A.FullName)
            Debug.WriteLine(A.ToString())
            TypeArray = A.GetTypes()
            For Each T In TypeArray
                LoadTypeInfo(T, A)
            Next
        Next
        Debug.WriteLine("Total objects: " & CStr(AllObjects.Count))
    End Sub

    ' Finds the object info for a specified object (by name). Case insensitive
    ' We could probably have used keys to speed this up:-)
    Public Function GetInfoForObject(ByVal ObjectName As String) As ObjectInfo
        Dim oi As ObjectInfo
        For Each oi In AllObjects
            If LCase(oi.ObjectName) = LCase(ObjectName) Then
                Return (oi)
            End If
        Next
    End Function

    ' Searches through entire object list to build a list of objects that inherit
    ' from the specified class
    Public Function WhoInheritsFrom(ByVal baseclass As String) As Collection
        Dim col As New Collection()
        Dim oi As ObjectInfo
        For Each oi In AllObjects
            If oi.IsDerivedFrom(baseclass) Then
                col.Add(oi.ObjectName)
            End If
        Next
        Return (col)
    End Function

    ' Searches through entire object list to build a list of objects that implement
    ' from the specified interface
    Public Function WhoImplements(ByVal InterfaceName As String) As Collection
        Dim col As New Collection()
        Dim oi As ObjectInfo
        For Each oi In AllObjects
            If oi.ImplementsInterface(InterfaceName) Then
                col.Add(oi.ObjectName)
            End If
        Next
        Return (col)
    End Function

    ' Copies the implemented or interface list to the clipboard    Private Sub cmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy.Click        Dim S As String
        Dim t As New System.Text.StringBuilder()
        For Each S In listBox2().Items
            t.Append(S)
            t.Append(ControlChars.CrLf)
        Next
        Clipboard.SetDataObject(t.ToString())
    End Sub

End Class

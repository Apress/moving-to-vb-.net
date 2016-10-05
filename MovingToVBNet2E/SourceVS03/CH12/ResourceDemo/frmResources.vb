' Resource Demo example
' Copyright ©2003 by Desaware Inc.
Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        If MsgBox("Simulate UK Culture", MsgBoxStyle.YesNo, "Culture") = MsgBoxResult.Yes Then
            System.Threading.Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("en-GB")
        End If
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdPickItUp As System.Windows.Forms.Button
    Friend WithEvents cmdShowResourceInfo As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdPickItUp = New System.Windows.Forms.Button
        Me.cmdShowResourceInfo = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = CType(resources.GetObject("Label1.AccessibleDescription"), String)
        Me.Label1.AccessibleName = CType(resources.GetObject("Label1.AccessibleName"), String)
        Me.Label1.Anchor = CType(resources.GetObject("Label1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = CType(resources.GetObject("Label1.AutoSize"), Boolean)
        Me.Label1.Dock = CType(resources.GetObject("Label1.Dock"), System.Windows.Forms.DockStyle)
        Me.Label1.Enabled = CType(resources.GetObject("Label1.Enabled"), Boolean)
        Me.Label1.Font = CType(resources.GetObject("Label1.Font"), System.Drawing.Font)
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = CType(resources.GetObject("Label1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label1.ImageIndex = CType(resources.GetObject("Label1.ImageIndex"), Integer)
        Me.Label1.ImeMode = CType(resources.GetObject("Label1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.Point)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = CType(resources.GetObject("Label1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label1.Size = CType(resources.GetObject("Label1.Size"), System.Drawing.Size)
        Me.Label1.TabIndex = CType(resources.GetObject("Label1.TabIndex"), Integer)
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.TextAlign = CType(resources.GetObject("Label1.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label1.Visible = CType(resources.GetObject("Label1.Visible"), Boolean)
        '
        'cmdPickItUp
        '
        Me.cmdPickItUp.AccessibleDescription = CType(resources.GetObject("cmdPickItUp.AccessibleDescription"), String)
        Me.cmdPickItUp.AccessibleName = CType(resources.GetObject("cmdPickItUp.AccessibleName"), String)
        Me.cmdPickItUp.Anchor = CType(resources.GetObject("cmdPickItUp.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdPickItUp.BackgroundImage = CType(resources.GetObject("cmdPickItUp.BackgroundImage"), System.Drawing.Image)
        Me.cmdPickItUp.Dock = CType(resources.GetObject("cmdPickItUp.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdPickItUp.Enabled = CType(resources.GetObject("cmdPickItUp.Enabled"), Boolean)
        Me.cmdPickItUp.FlatStyle = CType(resources.GetObject("cmdPickItUp.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdPickItUp.Font = CType(resources.GetObject("cmdPickItUp.Font"), System.Drawing.Font)
        Me.cmdPickItUp.Image = CType(resources.GetObject("cmdPickItUp.Image"), System.Drawing.Image)
        Me.cmdPickItUp.ImageAlign = CType(resources.GetObject("cmdPickItUp.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdPickItUp.ImageIndex = CType(resources.GetObject("cmdPickItUp.ImageIndex"), Integer)
        Me.cmdPickItUp.ImeMode = CType(resources.GetObject("cmdPickItUp.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdPickItUp.Location = CType(resources.GetObject("cmdPickItUp.Location"), System.Drawing.Point)
        Me.cmdPickItUp.Name = "cmdPickItUp"
        Me.cmdPickItUp.RightToLeft = CType(resources.GetObject("cmdPickItUp.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdPickItUp.Size = CType(resources.GetObject("cmdPickItUp.Size"), System.Drawing.Size)
        Me.cmdPickItUp.TabIndex = CType(resources.GetObject("cmdPickItUp.TabIndex"), Integer)
        Me.cmdPickItUp.Text = resources.GetString("cmdPickItUp.Text")
        Me.cmdPickItUp.TextAlign = CType(resources.GetObject("cmdPickItUp.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdPickItUp.Visible = CType(resources.GetObject("cmdPickItUp.Visible"), Boolean)
        '
        'cmdShowResourceInfo
        '
        Me.cmdShowResourceInfo.AccessibleDescription = CType(resources.GetObject("cmdShowResourceInfo.AccessibleDescription"), String)
        Me.cmdShowResourceInfo.AccessibleName = CType(resources.GetObject("cmdShowResourceInfo.AccessibleName"), String)
        Me.cmdShowResourceInfo.Anchor = CType(resources.GetObject("cmdShowResourceInfo.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdShowResourceInfo.BackgroundImage = CType(resources.GetObject("cmdShowResourceInfo.BackgroundImage"), System.Drawing.Image)
        Me.cmdShowResourceInfo.Dock = CType(resources.GetObject("cmdShowResourceInfo.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdShowResourceInfo.Enabled = CType(resources.GetObject("cmdShowResourceInfo.Enabled"), Boolean)
        Me.cmdShowResourceInfo.FlatStyle = CType(resources.GetObject("cmdShowResourceInfo.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdShowResourceInfo.Font = CType(resources.GetObject("cmdShowResourceInfo.Font"), System.Drawing.Font)
        Me.cmdShowResourceInfo.Image = CType(resources.GetObject("cmdShowResourceInfo.Image"), System.Drawing.Image)
        Me.cmdShowResourceInfo.ImageAlign = CType(resources.GetObject("cmdShowResourceInfo.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdShowResourceInfo.ImageIndex = CType(resources.GetObject("cmdShowResourceInfo.ImageIndex"), Integer)
        Me.cmdShowResourceInfo.ImeMode = CType(resources.GetObject("cmdShowResourceInfo.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdShowResourceInfo.Location = CType(resources.GetObject("cmdShowResourceInfo.Location"), System.Drawing.Point)
        Me.cmdShowResourceInfo.Name = "cmdShowResourceInfo"
        Me.cmdShowResourceInfo.RightToLeft = CType(resources.GetObject("cmdShowResourceInfo.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdShowResourceInfo.Size = CType(resources.GetObject("cmdShowResourceInfo.Size"), System.Drawing.Size)
        Me.cmdShowResourceInfo.TabIndex = CType(resources.GetObject("cmdShowResourceInfo.TabIndex"), Integer)
        Me.cmdShowResourceInfo.Text = resources.GetString("cmdShowResourceInfo.Text")
        Me.cmdShowResourceInfo.TextAlign = CType(resources.GetObject("cmdShowResourceInfo.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdShowResourceInfo.Visible = CType(resources.GetObject("cmdShowResourceInfo.Visible"), Boolean)
        '
        'PictureBox1
        '
        Me.PictureBox1.AccessibleDescription = CType(resources.GetObject("PictureBox1.AccessibleDescription"), String)
        Me.PictureBox1.AccessibleName = CType(resources.GetObject("PictureBox1.AccessibleName"), String)
        Me.PictureBox1.Anchor = CType(resources.GetObject("PictureBox1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Dock = CType(resources.GetObject("PictureBox1.Dock"), System.Windows.Forms.DockStyle)
        Me.PictureBox1.Enabled = CType(resources.GetObject("PictureBox1.Enabled"), Boolean)
        Me.PictureBox1.Font = CType(resources.GetObject("PictureBox1.Font"), System.Drawing.Font)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.ImeMode = CType(resources.GetObject("PictureBox1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PictureBox1.Location = CType(resources.GetObject("PictureBox1.Location"), System.Drawing.Point)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.RightToLeft = CType(resources.GetObject("PictureBox1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PictureBox1.Size = CType(resources.GetObject("PictureBox1.Size"), System.Drawing.Size)
        Me.PictureBox1.SizeMode = CType(resources.GetObject("PictureBox1.SizeMode"), System.Windows.Forms.PictureBoxSizeMode)
        Me.PictureBox1.TabIndex = CType(resources.GetObject("PictureBox1.TabIndex"), Integer)
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Text = resources.GetString("PictureBox1.Text")
        Me.PictureBox1.Visible = CType(resources.GetObject("PictureBox1.Visible"), Boolean)
        '
        'Form1
        '
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PictureBox1, Me.cmdShowResourceInfo, Me.cmdPickItUp, Me.Label1})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "Form1"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdShowResourceInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowResourceInfo.Click
        ' You can get a list of the resource files available
        Dim resourcenames() As String = Reflection.Assembly.GetExecutingAssembly.GetManifestResourceNames()
        Dim msgtext As New System.Text.StringBuilder
        Dim s As String
        For Each s In resourcenames
            msgtext.Append(s)
            msgtext.Append(ControlChars.CrLf)
        Next
        MsgBox(msgtext.ToString, MsgBoxStyle.OKOnly, "Resource in assembly")
    End Sub

    Private Sub PickUpBook()
        Throw New MagicException("TRUNK")
    End Sub

    Private Sub cmdPickItUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPickItUp.Click
        Try
            PickUpBook()
        Catch ex As MagicException
            ' Note the message will be localized
            MsgBox(ex.Message)
        Catch exother As Exception
            MsgBox("Fatal error: " & exother.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Here's how you pull an image out of the resource
        Dim rm As New Resources.ResourceManager("ResourceDemo.OtherResources", Me.GetType.Assembly)
        PictureBox1.Image = CType(rm.GetObject("IMAGE1"), Image)
    End Sub

End Class

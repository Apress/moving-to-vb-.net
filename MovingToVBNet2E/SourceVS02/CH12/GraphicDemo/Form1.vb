' Graphic Demo
' Copyright ©2001 by Desaware Inc.
Public Class Form1
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
    Friend WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdDraw As System.Windows.Forms.Button
    Friend WithEvents pictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdBitmap As System.Windows.Forms.Button
    Friend WithEvents cmdGradient As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdBitmap = New System.Windows.Forms.Button()
        Me.pictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmdDraw = New System.Windows.Forms.Button()
        Me.cmdGradient = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdBitmap
        '
        Me.cmdBitmap.Location = New System.Drawing.Point(24, 64)
        Me.cmdBitmap.Name = "cmdBitmap"
        Me.cmdBitmap.TabIndex = 3
        Me.cmdBitmap.Text = "Bitmap"
        '
        'pictureBox2
        '
        Me.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBox2.Location = New System.Drawing.Point(176, 184)
        Me.pictureBox2.Name = "pictureBox2"
        Me.pictureBox2.Size = New System.Drawing.Size(176, 80)
        Me.pictureBox2.TabIndex = 2
        Me.pictureBox2.TabStop = False
        '
        'pictureBox1
        '
        Me.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pictureBox1.Location = New System.Drawing.Point(136, 16)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(216, 144)
        Me.pictureBox1.TabIndex = 0
        Me.pictureBox1.TabStop = False
        '
        'cmdDraw
        '
        Me.cmdDraw.Location = New System.Drawing.Point(24, 24)
        Me.cmdDraw.Name = "cmdDraw"
        Me.cmdDraw.TabIndex = 1
        Me.cmdDraw.Text = "Draw"
        '
        'cmdGradient
        '
        Me.cmdGradient.Location = New System.Drawing.Point(24, 104)
        Me.cmdGradient.Name = "cmdGradient"
        Me.cmdGradient.TabIndex = 4
        Me.cmdGradient.Text = "Gradient"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(371, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdGradient, Me.cmdBitmap, Me.pictureBox2, Me.cmdDraw, Me.pictureBox1})
        Me.Name = "Form1"
        Me.Text = "Graphics Test"
        Me.ResumeLayout(False)

    End Sub


#End Region
    Private Sub cmdDraw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDraw.Click        Dim g As Graphics
        Dim b As SolidBrush = New SolidBrush(color.Beige)   ' Can also draw from library of stock brushes
        g = pictureBox1().CreateGraphics() ' Get the graphics object
        g.FillRectangle(b, pictureBox1().ClientRectangle)
        ' Constructor that allows quick modification of existing font
        Dim f As Font = New Font(Me.Font, FontStyle.Bold)
        g.DrawString("Some Text", f, brushes.Black, 10, 10)
        g.DrawRectangle(pens.Blue, 50, 50, 50, 50)
        g.DrawLine(pens.Red, 50, 50, 150, 150)
        g.Dispose() ' Don't forget to dispose!
        b.Dispose()
        f.Dispose()

    End Sub

    Private Sub cmdBitmap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBitmap.Click        Dim g, g2 As Graphics
        g = pictureBox1().CreateGraphics()
        Dim bm As New Bitmap(pictureBox1().ClientRectangle.Width, pictureBox1().ClientRectangle.Height, g)

        g2 = graphics.FromImage(bm)
        dwgraphics.CopyImage(g, g2, pictureBox1().ClientRectangle.Width, pictureBox1().ClientRectangle.Height)

        g2.DrawLine(pens.Green, 60, 50, 160, 150)
        bm.SetPixel(1, 1, color.Red)
        bm.SetPixel(1, 2, color.Blue)
        bm.SetPixel(1, 3, color.Green)

        g = graphics.FromHwnd(pictureBox2().Handle) ' Another way to get a graphics object
        Dim g3 As Graphics = graphics.FromHwnd(pictureBox2().Handle)
        g3.DrawImage(bm, 0, 0, pictureBox2().DisplayRectangle.Width, pictureBox2().DisplayRectangle.Height)
        g.Dispose()
        g2.Dispose()
        g3.Dispose()
        bm.Dispose()

    End Sub

    Private Sub cmdGradient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGradient.Click        Dim lb As New Drawing2D.LinearGradientBrush(Me.DisplayRectangle, color.Blue, color.Red, Drawing2D.LinearGradientMode.Horizontal)
        Dim g As Graphics = Me.CreateGraphics()
        g.FillRectangle(lb, Me.DisplayRectangle)
        lb.Dispose()
        g.Dispose()
    End Sub


    Public Class dwGraphics
        Shared Sub CopyImage(ByVal Source As System.Drawing.Graphics, ByVal Dest As System.Drawing.Graphics, ByVal Width As Integer, ByVal Height As Integer)
            Dim dhdc, shdc As IntPtr
            dhdc = Dest.GetHdc
            shdc = Source.GetHdc
            BitBlt(dhdc, 0, 0, Width, Height, shdc, 0, 0, SRCCOPY)
            Dest.ReleaseHdc(dhdc)
            Source.ReleaseHdc(shdc)
        End Sub
    End Class


End Class


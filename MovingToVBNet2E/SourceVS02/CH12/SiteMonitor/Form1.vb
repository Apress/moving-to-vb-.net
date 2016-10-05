' Async programming example
' Copyright ©2003 by Desaware Inc.

Imports System.Net
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lstStatus As System.Windows.Forms.ListBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtSites As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtSites = New System.Windows.Forms.TextBox()
        Me.lstStatus = New System.Windows.Forms.ListBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'txtSites
        '
        Me.txtSites.Location = New System.Drawing.Point(16, 24)
        Me.txtSites.Multiline = True
        Me.txtSites.Name = "txtSites"
        Me.txtSites.Size = New System.Drawing.Size(176, 200)
        Me.txtSites.TabIndex = 0
        Me.txtSites.Text = "http://www.desaware.com" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "http://www.apress.com" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "http://www.microsoft.com" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "http://" & _
        "www.ibm.com" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "http://www.netscape.com"
        '
        'lstStatus
        '
        Me.lstStatus.Location = New System.Drawing.Point(216, 24)
        Me.lstStatus.Name = "lstStatus"
        Me.lstStatus.Size = New System.Drawing.Size(248, 199)
        Me.lstStatus.TabIndex = 1
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(504, 253)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstStatus, Me.txtSites})
        Me.Name = "Form1"
        Me.Text = "Site Monitor"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim SiteList As New ArrayList()

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim sitestring As String
        Dim sites As SiteInfo
        SyncLock SiteList.SyncRoot
            For Each sites In SiteList
                Try
                    ' If it's still in the collection, abort the old request
                    sites.httpwr.Abort()
                Catch
                End Try
            Next
            SiteList.Clear()
        End SyncLock

        ' Build the new siteinfo
        For Each sitestring In txtSites.Lines
            SiteList.Add(New SiteInfo(sitestring))
        Next

        lstStatus.Items.Clear()
        For Each sites In SiteList
            sites.httpwr.BeginGetResponse(AddressOf RequestComplete, sites)
        Next
    End Sub

 
    Public Sub RequestComplete(ByVal iar As IAsyncResult)
        Dim AddToListCaller As New AddToListProc(AddressOf AddToList)
        Dim response As HttpWebResponse
        Dim si As SiteInfo = CType(iar.AsyncState, SiteInfo)
        response = CType(si.httpwr.EndGetResponse(iar), HttpWebResponse)
        If response.StatusCode = HttpStatusCode.OK Then
            Me.Invoke(AddToListCaller, New String() {"Site " & si.SiteURL & " is active"})
            si.IsValid = True
        Else
            Me.Invoke(AddToListCaller, New String() {"Site " & si.SiteURL & " was not ok"})
        End If

        ' You can look at the retrieved data here
        SyncLock SiteList.SyncRoot
            SiteList.Remove(iar.AsyncState)
        End SyncLock
    End Sub

    Delegate Sub AddToListProc(ByVal s As String)

    Public Sub AddToList(ByVal s As String)
        lstStatus.Items.Add(s)
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        Dim sites As SiteInfo
        Timer1.Enabled = False

        ' Clean up old requests
        For Each sites In SiteList
            Try
                ' If it's still in the collection, abort the old request
                sites.httpwr.Abort()
            Catch
            End Try
        Next

    End Sub
End Class



Public Class SiteInfo
    Public SiteURL As String
    Public IsValid As Boolean
    Public httpwr As HttpWebRequest
    Public Sub New(ByVal sitename As String)
        SiteURL = sitename
        httpwr = CType(HttpWebRequest.Create(sitename), HttpWebRequest)
    End Sub
End Class
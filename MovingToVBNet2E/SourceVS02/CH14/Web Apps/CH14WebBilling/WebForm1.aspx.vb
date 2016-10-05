Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected WithEvents txtName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHours As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents LastEntryLabel As System.Web.UI.WebControls.Label
    Protected WithEvents CurrentEntryLabel As System.Web.UI.WebControls.Label
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents cmdAddEntry As System.Web.UI.WebControls.Button

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected Sub Page_Init(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private BillingInfo As MovingToVBNet.Billing.BillingComponent

    Private LastEntryInfo As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BillingInfo = New MovingToVBNet.Billing.BillingComponent()
        Dim dv As New DataView(BillingInfo.Info.Tables(0))
        DataGrid1.DataSource = dv
        DataGrid1.DataBind()
        If Page.IsPostBack Then
            LastEntryInfo = CType(Session("LastEntry"), String)
            LastEntryLabel.Text = "Prior entry: " & LastEntryInfo
        End If
    End Sub

    Private Sub cmdAddEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddEntry.Click
        BillingInfo.AddRecord(txtName.Text, CInt(txtHours.Text), txtDescription.Text)
        Session("LastEntry") = txtName.Text & ": " & txtHours.Text & " hours - " & txtDescription.Text
        CurrentEntryLabel.Text = "Current entry: " & txtName.Text & ": " & txtHours.Text & " hours - " & txtDescription.Text
        txtHours.Text = ""
        txtDescription.Text = ""

        ' Update grid
        Dim dv As New DataView(BillingInfo.Info.Tables(0))
        DataGrid1.DataSource = dv
        DataGrid1.DataBind()

    End Sub

    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        MyBase.Render(writer)
        writer.WriteLine("Here is some extra text ")
    End Sub

    Private Sub WebForm1_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
        BillingInfo.Dispose()
    End Sub

End Class

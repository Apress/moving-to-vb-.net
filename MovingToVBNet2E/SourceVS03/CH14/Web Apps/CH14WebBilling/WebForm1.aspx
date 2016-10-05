<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="CH14WebBilling.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<H1>
				Billing Records
			</H1>
			<P>
				Name:<asp:textbox id="txtName" runat="server"></asp:textbox></P>
			<P>
				Hours:<asp:textbox id="txtHours" runat="server"></asp:textbox>
				<asp:rangevalidator id="RangeValidator1" runat="server" ErrorMessage="Enter time between 0.1 and 200 hours" ControlToValidate="txtHours" MaximumValue="200" MinimumValue=".1" Type="Double" EnableClientScript="False"></asp:rangevalidator>
			</P>
			<P>
				Description:<asp:textbox id="txtDescription" runat="server"></asp:textbox></P>
			<P>
				<asp:label id="CurrentEntryLabel" runat="server"></asp:label>
			</P>
			<P>
				<asp:label id="LastEntryLabel" runat="server"></asp:label>
			</P>
			<P>
				<asp:button id="cmdAddEntry" runat="server" Height="24px" Width="91px" Text="Add"></asp:button>
			</P>
			<P>
				Current Billing Summary:
			</P>
			<P>
				<asp:DataGrid id="DataGrid1" runat="server"></asp:DataGrid>
			</P>
		</form>	</body>
</HTML>

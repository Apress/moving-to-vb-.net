' Billing Component
' Copyright ©2001-2003 by Desaware Inc. All Rights Reserved

Public Class BillingComponent


    Inherits System.ComponentModel.Component

#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        OpenXML()

    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            Cleanup()   ' Only cleanup the dataset on true Dispose. Dataset may be gone on Finalize
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        Else
            MyBase.Dispose(disposing)
        End If
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Private myds As New DataSet()
    Private xmllocation As String

    Public Sub OpenXML()
        Dim loc As String
        ' Be sure you have set permission for ASPNET to access these two files from web
        ' Look first in appdomain directory (works for web)
        xmllocation = AppDomain.CurrentDomain.BaseDirectory
        If Not IO.File.Exists(xmllocation & "billingset.xsd") Then
            ' If not there, try the parent directory (works for bin)
            If xmllocation.EndsWith("\") Then
                xmllocation = xmllocation.Remove(Len(xmllocation) - 1, 1)
            End If
            xmllocation = IO.Directory.GetParent(xmllocation).ToString & "\"
        End If

        Try
            myds.ReadXmlSchema(xmllocation & "billingset.xsd")
            Try
                myds.ReadXml(xmllocation & "BillingData.xml")
            Catch ex As Security.SecurityException
                Throw ex
            Catch e As Exception
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub AddRecord(ByVal Name As String, ByVal Hours As Double, ByVal Description As String)
        Dim dr As DataRow
        dr = myds.Tables(0).NewRow
        dr.Item(0) = Name
        dr.Item(1) = Hours
        dr.Item(2) = Description
        myds.Tables(0).Rows.Add(dr)
        ' We want the dataset to be up to date
        myds.AcceptChanges()
    End Sub

    Private Sub Cleanup()
        myds.AcceptChanges()
        myds.WriteXml(xmllocation & "BillingData.xml", XmlWriteMode.IgnoreSchema)
    End Sub

    Public ReadOnly Property Info() As DataSet
        Get
            Return myds
        End Get
    End Property

End Class

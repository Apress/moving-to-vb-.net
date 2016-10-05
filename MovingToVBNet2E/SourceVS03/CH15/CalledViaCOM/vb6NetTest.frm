VERSION 5.00
Begin VB.Form frmVB6NetTest 
   Caption         =   "Calling .NET component"
   ClientHeight    =   3195
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   3195
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdEarly 
      Caption         =   "Early Bound"
      Height          =   495
      Left            =   2520
      TabIndex        =   1
      Top             =   600
      Width           =   1215
   End
   Begin VB.CommandButton cmdLate 
      Caption         =   "Late Bound"
      Height          =   495
      Left            =   600
      TabIndex        =   0
      Top             =   600
      Width           =   1335
   End
End
Attribute VB_Name = "frmVB6NetTest"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdLate_Click()
    Dim c As Object
    Set c = CreateObject("CalledViaCOM.CallFromCOM")
    MsgBox c.TimesTwo(5), vbInformation, "Result from CallFromCOM"
    Set c = CreateObject("CalledViaCOM.CallFromCOMDispatch")
    MsgBox c.TimesTwo(5), vbInformation, "Result from CallFromCOMDispatch"
    Set c = CreateObject("CalledViaCOM.CallFromCOMDual")
    MsgBox c.TimesTwo(5), vbInformation, "Result from CallFromCOMDual"
End Sub

Private Sub cmdEarly_Click()
On Error Resume Next
    Dim c As New CalledViaCOM.CallFromCOM
    Dim c2 As New CalledViaCOM.CallFromCOMDispatch
    Dim c3 As New CalledViaCOM.CallFromCOMDual
    MsgBox c.TimesTwo(5), vbInformation, "Result from CallFromCOM"
    MsgBox c3.TimesTwo(5), vbInformation, "Result from CallFromCOMDual"
End Sub

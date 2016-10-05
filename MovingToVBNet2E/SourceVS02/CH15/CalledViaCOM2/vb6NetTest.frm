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
    Set c = CreateObject("CalledViaCOM2.CallFromCOM2")
    MsgBox c.TimesFour(5), vbInformation, "Result from CalledViaCOM2"
    Set c = CreateObject("CalledViaCOM2.CallFromCOM2Dual")
    MsgBox c.TimesFour(5), vbInformation, "Result from CalledViaCOM2Dual"
End Sub

Private Sub cmdEarly_Click()
    On Error Resume Next
    Dim c As New CallFromCOM2
    Dim c2 As New CallFromCOM2Dual
    MsgBox c.TimesFour(5), vbInformation, "Result from CallFromCOM2"
    MsgBox c2.TimesFour(5), vbInformation, "Result from CallFromCOM2Dual"
    Debug.Print c.BadWay(8)
End Sub

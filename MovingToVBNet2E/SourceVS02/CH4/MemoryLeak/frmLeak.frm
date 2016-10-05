VERSION 5.00
Begin VB.Form frmLeak 
   Caption         =   "Memory Leak"
   ClientHeight    =   3180
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4485
   LinkTopic       =   "Form1"
   ScaleHeight     =   3180
   ScaleWidth      =   4485
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdExecute 
      Caption         =   "Execute"
      Height          =   555
      Left            =   1440
      TabIndex        =   0
      Top             =   720
      Width           =   1365
   End
End
Attribute VB_Name = "frmLeak"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub cmdExecute_Click()
   Dim col As New Collection
   Dim myobject As New Class1
   Dim counter As Long
   For counter = 1 To 1000
      Set myobject.HoldingCollection = col
      col.Add myobject
   Next counter
End Sub

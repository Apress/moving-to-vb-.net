VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "SampleClass1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
' Sample of component accessed from .NET
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Option Explicit


Private Declare Function GetCurrentThreadId Lib "kernel32" () As Long

Public Function TimesTwo(ByVal x As Long) As Long
    TimesTwo = x * 2
End Function

Public Function TrimString(ByVal s As String) As String
    TrimString = Trim(s)
End Function

Public Function GetThisThreadId() As Long
    GetThisThreadId = GetCurrentThreadId()
End Function


' ADO Example
' Copyright ©2001-2003 by Desaware Inc.
Imports System.Data
Public Class TVListingDB
    Public TVTable As New DataTable("TVListing")

    Public Sub New()
        Dim showcol As New DataColumn("Name", GetType(String))
        Dim showtime As New DataColumn("Time", GetType(String))
        ' Don't allow null values
        showcol.AllowDBNull = False
        showtime.AllowDBNull = False

        TVTable.Columns.Add(showcol)
        TVTable.Columns.Add(showtime)
    End Sub

    Public Sub LoadInitialData()
        Dim newRow As DataRow

        newRow = TVTable.NewRow()
        newRow.Item(0) = "Star Trek"
        newRow.Item(1) = "13:00"
        TVTable.Rows.Add(newRow)
        newRow = TVTable.NewRow()
        newRow.Item("Name") = "Babylon 5"
        newRow.Item("Time") = "14:00"
        TVTable.Rows.Add(newRow)
        newRow = TVTable.NewRow()
        newRow("Name") = "BattleShip Galactica"
        newRow("Time") = "15:00"
        Debug.WriteLine("Before adding, Row is: " & newRow.RowState.ToString)
        TVTable.Rows.Add(newRow)
        Debug.WriteLine("Before accepting to table, Row is: " & newRow.RowState.ToString)
        TVTable.AcceptChanges()
        Debug.WriteLine("Before modification, Row is: " & newRow.RowState.ToString)
        newRow("Time") = "15:30"
        Debug.WriteLine("Before accepting changes, Row is: " & newRow.RowState.ToString)
        newRow.AcceptChanges()
        debug.WriteLine(TVTable.Rows.Count)
    End Sub


    Public Function GetDataSet() As DataSet
        Dim ds As New DataSet()
        ds.Tables.Add(TVTable)
        Return ds
    End Function

End Class

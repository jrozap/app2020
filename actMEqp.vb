Public Class ActMEqp
    Public DataEqpDS As New System.Data.DataSet
    Public connStr As System.Data.OleDb.OleDbConnection
    Public SQLCmd As System.Data.OleDb.OleDbDataAdapter
    Public CodEqpM As Integer


    Private Sub dataEqp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ActMEqp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MasterAPVDataSet.MasterEqp' table. You can move, or remove it, as needed.
        Me.MasterEqpTableAdapter.Fill(Me.MasterAPVDataSet.MasterEqp)
        connStr = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\jrozap\Documents\Steel Design Co\Analisis Precios Unitarios\DB APVWIN Ver 10.1.001\DB Master Tables APV\MasterAPV.MDB;Persist Security Info=False")
        SQLCmd = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM MasterEqp ORDER BY Codigo", connStr)
        connStr.Open()
        SQLCmd.Fill(DataEqpDS)
    End Sub

    Private Sub EqpLData_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles EqpLData.MouseClick
        CodEqpA = EqpLData.CurrentCell.Value
        SQLCmd = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM MasterEqp WHERE Codigo =" + CStr(CodEqpM) + " ORDER BY Codigo", connStr)

        EqpDataF.Show()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub
End Class
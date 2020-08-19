Public Class ActEqpComp
    Public DataEqCDS As New System.Data.DataSet
    Public connStrEC As System.Data.OleDb.OleDbConnection
    Public SQLCmdEC As System.Data.OleDb.OleDbDataAdapter
    Public CodEqpC As Integer
    Public CodigoIn As Integer


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MasterAPVDataSet.EqpCompuesto' table. You can move, or remove it, as needed.
        Me.EqpCompuestoTableAdapter.Fill(Me.MasterAPVDataSet.EqpCompuesto)
        connStrEC = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\jrozap\Documents\Steel Design Co\Analisis Precios Unitarios\DB APVWIN Ver 10.1.001\DB Master Tables APV\MasterAPV.MDB;Persist Security Info=False")
        SQLCmdEC = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM EqpCompuesto ORDER BY CodInterno", connStrEC)
        connStrEC.Open()
        SQLCmdEC.Fill(DataEqCDS)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub EqpCompuestoBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EqpCompuestoBindingSource.CurrentChanged

    End Sub

    Private Sub MaskedTextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pEne.TextChanged
        Dim val As Decimal = 0

        If Decimal.TryParse(pEne.Text, val) Then
            pEne.Text = val.ToString("N2")
        Else
            pEne.Text = ""
        End If

    End Sub
End Class
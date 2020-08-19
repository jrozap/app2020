Public Class ActMedObr
    Public fila As Object
    Public CantPartStr As String
    Public RendPartStr As String
    Public PUPartStr As String
    Public PAPartStr As String
    Public PTPartstr As String
    Public partida As Object

    'Parametros Dataset
    Public ConStr As New OleDb.OleDbConnection
    Public DBProvider As String
    Public DBSource As String
    Public DBPath As String
    Public DBName As String

    'Variables para Materiales (DataGrid)
    Public DSetMaterial As New DataSet
    Public DAMaterial As OleDb.OleDbDataAdapter
    Public cmdSQLMt As String

    'Variables para Equipos (DataGrid)
    Public DSetEquipos As New DataSet
    Public DAEquipos As OleDb.OleDbDataAdapter
    Public cmdSQLEq As String

    'Variables para Mano de Obra (DataGrid)
    Public DSetMdO As New DataSet
    Public DAMdO As OleDb.OleDbDataAdapter
    Public cmdSQLMO As String

    'Variables para Transporte (DataGrid)
    Public DSetTrn As New DataSet
    Public DATrans As OleDb.OleDbDataAdapter
    Public cmdSQLTrn As String


    Private Sub ActMedObr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PartObr._PartObr' table. You can move, or remove it, as needed.
        Me.PartObrTableAdapter.Fill(Me.PartObr._PartObr)
        'TODO: This line of code loads data into the 'ComputosTR.ComputoTR' table. You can move, or remove it, as needed.
        Me.ComputoTRTableAdapter.Fill(Me.ComputosTR.ComputoTR)
        'TODO: This line of code loads data into the 'ComputosMO.ComputoMO' table. You can move, or remove it, as needed.
        Me.ComputoMOTableAdapter.Fill(Me.ComputosMO.ComputoMO)
        'TODO: This line of code loads data into the 'ComputosEqp.ComputoEQ' table. You can move, or remove it, as needed.
        Me.ComputoEQTableAdapter.Fill(Me.ComputosEqp.ComputoEQ)
        'TODO: This line of code loads data into the 'ComputosMat.ComputoMT' table. You can move, or remove it, as needed.
        Me.ComputoMTTableAdapter.Fill(Me.ComputosMat.ComputoMT)

        DBProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"
        DBPath = "C:\Users\jrozap\Documents\Steel Design Co\Analisis Precios Unitarios\APV 32-bit\APP2020.NET\APP2020\APP2020"
        DBName = "\MasterAPV.MDB"
        DBSource = "Data Source = " & DBPath & DBName
        ConStr.ConnectionString = DBProvider & DBSource
        ConStr.Open()

        CodObr.Text = PartObr.Tables("partobr").Rows(1).Item("cod-obr-apu")
        DescObr.Text = PartObr.Tables("partobr").Rows(1).Item("desc-obr")

        fila = DataGridView1.CurrentCell.RowIndex
        NPart.Text = CStr(PartObr.Tables("partobr").Rows(fila).Item("num-par-apu"))
        MDescPart.Text = CStr(PartObr.Tables("partobr").Rows(fila).Item("MiniDescripcion"))
        COVENINp.Text = CStr(PartObr.Tables("partobr").Rows(fila).Item("CodigoCovenin"))
        TextPart.Text = CStr(PartObr.Tables("partobr").Rows(fila).Item("PartidaTexto"))
        CantPartStr = CDbl(PartObr.Tables("partobr").Rows(fila).Item("can-apr-apu")).ToString("#,##0.00;(#,##0.00);Zero")
        CantPart.Text = CantPartStr
        UndPart.Text = CStr(PartObr.Tables("partobr").Rows(fila).Item("und-par-apu"))
        RendPartStr = CDbl(PartObr.Tables("partobr").Rows(fila).Item("ren-par-apu")).ToString("#,##0.00;(#,##0.00);Zero")
        RendPart.Text = RendPartStr
        PUPartStr = CDbl(PartObr.Tables("partobr").Rows(fila).Item("pun-par-apu")).ToString("#,##0.00;(#,##0.00);Zero")
        PUPart.Text = PUPartStr
        PAPartStr = CDbl(PartObr.Tables("partobr").Rows(fila).Item("pun-adp-apu")).ToString("#,##0.00;(#,##0.00);Zero")
        PAPart.Text = PAPartStr
        PTPartstr = CDbl(PartObr.Tables("partobr").Rows(fila).Item("ptot-pr-apu")).ToString("#,##0.00;(#,##0.00);Zero")
        PTPart.Text = PTPartstr

        'Materiales de la Partida 1
        partida = PartObr.Tables("partobr").Rows(fila).Item("num-par-apu")

        cmdSQLMt = "SELECT * FROM ComputoMT WHERE NumeroPartida = " + CStr(partida) + " ORDER BY Codigo"
        DAMaterial = New OleDb.OleDbDataAdapter(cmdSQLMt, ConStr)
        DAMaterial.Fill(DSetMaterial, "ComputoMT")

        MatGrid.DataSource = DSetMaterial.Tables(0)
        MatGrid.Refresh()

        'Equipos de la Partida 1
        partida = PartObr.Tables("partobr").Rows(fila).Item("num-par-apu")

        cmdSQLEq = "SELECT * FROM ComputoEQ WHERE NumeroPartida = " + CStr(partida) + " ORDER BY Codigo"
        DAEquipos = New OleDb.OleDbDataAdapter(cmdSQLEq, ConStr)
        DAEquipos.Fill(DSetEquipos, "ComputoEQ")

        EqpDGrid.DataSource = DSetEquipos.Tables(0)
        EqpDGrid.Refresh()

        'Mano Obra de la Partida 1
        partida = PartObr.Tables("partobr").Rows(fila).Item("num-par-apu")

        cmdSQLMO = "SELECT * FROM ComputoMO WHERE NumeroPartida = " + CStr(partida) + " ORDER BY Codigo"
        DAMdO = New OleDb.OleDbDataAdapter(cmdSQLMO, ConStr)
        DAMdO.Fill(DSetMdO, "ComputoMO")

        MODGrid.DataSource = DSetMdO.Tables(0)
        MODGrid.Refresh()

        'Transportes de la Partida 1
        partida = PartObr.Tables("partobr").Rows(fila).Item("num-par-apu")

        cmdSQLTrn = "SELECT * FROM ComputoTR WHERE NumeroPartida = " + CStr(partida) + " ORDER BY Codigo"
        DATrans = New OleDb.OleDbDataAdapter(cmdSQLTrn, ConStr)
        DATrans.Fill(DSetTrn, "ComputoTR")

        TransDGrid.DataSource = DSetTrn.Tables(0)
        TransDGrid.Refresh()

        Button5.AutoEllipsis = True
        Button5.Select()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescObr.TextChanged

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        fila = DataGridView1.CurrentCell.RowIndex
        NPart.Text = CStr(PartObr.Tables("partobr").Rows(fila).Item("num-par-apu"))
        MDescPart.Text = CStr(PartObr.Tables("partobr").Rows(fila).Item("MiniDescripcion"))
        COVENINp.Text = CStr(PartObr.Tables("partobr").Rows(fila).Item("CodigoCovenin"))
        TextPart.Text = CStr(PartObr.Tables("partobr").Rows(fila).Item("PartidaTexto"))
        CantPartStr = CDbl(PartObr.Tables("partobr").Rows(fila).Item("can-apr-apu")).ToString("#,##0.00;(#,##0.00);Zero")
        CantPart.Text = CantPartstr
        UndPart.Text = CStr(PartObr.Tables("partobr").Rows(fila).Item("und-par-apu"))
        RendPartStr = CDbl(PartObr.Tables("partobr").Rows(fila).Item("ren-par-apu")).ToString("#,##0.00;(#,##0.00);Zero")
        RendPart.Text = RendPartStr
        PUPartStr = CDbl(PartObr.Tables("partobr").Rows(fila).Item("pun-par-apu")).ToString("#,##0.00;(#,##0.00);Zero")
        PUPart.Text = PUPartStr
        PAPartStr = CDbl(PartObr.Tables("partobr").Rows(fila).Item("pun-adp-apu")).ToString("#,##0.00;(#,##0.00);Zero")
        PAPart.Text = PAPartStr
        PTPartstr = CDbl(PartObr.Tables("partobr").Rows(fila).Item("ptot-pr-apu")).ToString("#,##0.00;(#,##0.00);Zero")
        PTPart.Text = PTPartstr

        'Materiales de la Partida
        MatGrid.DataSource.clear()
        MatGrid.Refresh()
        partida = PartObr.Tables("partobr").Rows(fila).Item("num-par-apu")

        cmdSQLMt = "SELECT * FROM ComputoMT WHERE NumeroPartida = " + CStr(partida) + " ORDER BY Codigo"
        DAMaterial = New OleDb.OleDbDataAdapter(cmdSQLMt, ConStr)
        DAMaterial.Fill(DSetMaterial, "ComputoMT")

        MatGrid.DataSource = DSetMaterial.Tables(0)
        MatGrid.Refresh()

        'Equipos de la Partida
        EqpDGrid.DataSource.clear()
        EqpDGrid.Refresh()
        partida = PartObr.Tables("partobr").Rows(fila).Item("num-par-apu")

        cmdSQLEq = "SELECT * FROM ComputoEQ WHERE NumeroPartida = " + CStr(partida) + " ORDER BY Codigo"
        DAEquipos = New OleDb.OleDbDataAdapter(cmdSQLEq, ConStr)
        DAEquipos.Fill(DSetEquipos, "ComputoEQ")

        EqpDGrid.DataSource = DSetEquipos.Tables(0)
        EqpDGrid.Refresh()

        'Mano Obra de la Partida
        MODGrid.DataSource.clear()
        MODGrid.Refresh()
        partida = PartObr.Tables("partobr").Rows(fila).Item("num-par-apu")

        cmdSQLMO = "SELECT * FROM ComputoMO WHERE NumeroPartida = " + CStr(partida) + " ORDER BY Codigo"
        DAMdO = New OleDb.OleDbDataAdapter(cmdSQLMO, ConStr)
        DAMdO.Fill(DSetMdO, "ComputoMO")

        MODGrid.DataSource = DSetMdO.Tables(0)
        MODGrid.Refresh()

        'Transportes de la Partida
        TransDGrid.DataSource.clear()
        TransDGrid.Refresh()
        partida = PartObr.Tables("partobr").Rows(fila).Item("num-par-apu")

        cmdSQLTrn = "SELECT * FROM ComputoTR WHERE NumeroPartida = " + CStr(partida) + " ORDER BY Codigo"
        DATrans = New OleDb.OleDbDataAdapter(cmdSQLTrn, ConStr)
        DATrans.Fill(DSetTrn, "ComputoTR")

        TransDGrid.DataSource = DSetTrn.Tables(0)
        TransDGrid.Refresh()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        CompMed.Top = 1170
        CompMed.Left = 366
        CompMed.Visible = True
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

    End Sub
End Class
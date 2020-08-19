Public Class PartCovenin
    Public nRecords As Integer
    Public nPartCOV As Integer
    Public CCell As Object

    'Parametros Dataset
    Public ConStr As New OleDb.OleDbConnection
    Public DBProvider As String
    Public DBSource As String
    Public DBPath As String
    Public DBName As String

    'Variables para Partidas (DataGrid)
    Public DSetParCOV As New DataSet
    Public DAPartCOV As OleDb.OleDbDataAdapter
    Public cmdSQLParC As String

    Private Sub PartCovenin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PCovenin.PartidasCOVENIN' table. You can move, or remove it, as needed.
        Me.PartidasCOVENINTableAdapter.Fill(Me.PCovenin.PartidasCOVENIN)

        DBProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"
        DBPath = "C:\Users\jrozap\Documents\Steel Design Co\Analisis Precios Unitarios\APV 32-bit\APP2020.NET\APP2020\APP2020"
        DBName = "\MasterAPV.MDB"
        DBSource = "Data Source = " & DBPath & DBName
        ConStr.ConnectionString = DBProvider & DBSource
        ConStr.Open()

        nRecords = PCovenin.Tables("PartidasCOVENIN").Rows.Count
        nPartCOV = PCovenin.Tables("PartidasCOVENIN").Rows.Count - 1

        CCell = PGCovenin.CurrentCell.RowIndex

        CCovenin.Text = PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("CodigoCovenin")
        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("MiniDescripcion").Equals(DBNull.Value) Then
            MDescCov.Text = ""
        Else
            MDescCov.Text = PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("MiniDescripcion")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("MiniDescripcion").Equals(DBNull.Value) Then
            DescCov.Text = ""
        Else
            DescCov.Text = PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("Descripcion1") & PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("Descripcion2") & PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("Descripcion3")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("EsTitulo") = True Then
            TituloChk.Checked = True
        Else
            TituloChk.Checked = False
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("Unidad").Equals(DBNull.Value) Then
            UCovenin.Text = ""
        Else
            UCovenin.Text = PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("Unidad")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("Rendimiento").Equals(DBNull.Value) Then
            RCovenin.Text = ""
        Else
            RCovenin.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("Rendimiento")).ToString("#,##0.0000;(#,##0.0000);0.0000")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PUBsS").Equals(DBNull.Value) Then
            BsCovenin.Text = "0.00"
        Else
            BsCovenin.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PUBsS")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PUUSD").Equals(DBNull.Value) Then
            USDCov.Text = "0.00"
        Else
            USDCov.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PUUSD")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotMat").Equals(DBNull.Value) Then
            CTMatC.Text = "0.00"
        Else
            CTMatC.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotMat")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PrcMat").Equals(DBNull.Value) Then
            pINCMt.Text = "0.00"
        Else
            pINCMt.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PrcMat")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotEqp").Equals(DBNull.Value) Then
            CTEqpC.Text = "0.00"
        Else
            CTEqpC.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotEqp")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PcrEqp").Equals(DBNull.Value) Then
            pINCEq.Text = "0.00"
        Else
            pINCEq.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PcrEqp")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotMdO").Equals(DBNull.Value) Then
            CTMdOC.Text = "0.00"
        Else
            CTMdOC.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotMdO")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PrcMdO").Equals(DBNull.Value) Then
            pINCMo.Text = "0.00"
        Else
            pINCMo.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PrcMdO")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotTrans").Equals(DBNull.Value) Then
            CTTrnC.Text = "0.00"
        Else
            CTTrnC.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotTrans")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PrcTrans").Equals(DBNull.Value) Then
            pINCTr.Text = "0.00"
        Else
            pINCTr.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PrcTrans")).ToString("#,##0.00;(#,##0.00);0.00")
        End If
    End Sub

    Private Sub PGCovenin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PGCovenin.Click
        CCell = PGCovenin.CurrentCell.RowIndex

        CCovenin.Text = PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("CodigoCovenin")

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("MiniDescripcion").Equals(DBNull.Value) Then
            MDescCov.Text = ""
        Else
            MDescCov.Text = PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("MiniDescripcion")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("MiniDescripcion").Equals(DBNull.Value) Then
            DescCov.Text = ""
        Else
            DescCov.Text = PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("Descripcion1") & PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("Descripcion2") & PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("Descripcion3")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("EsTitulo") = True Then
            TituloChk.Checked = True
        Else
            TituloChk.Checked = False
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("Unidad").Equals(DBNull.Value) Then
            UCovenin.Text = ""
        Else
            UCovenin.Text = PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("Unidad")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("Rendimiento").Equals(DBNull.Value) Then
            RCovenin.Text = ""
        Else
            RCovenin.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("Rendimiento")).ToString("#,##0.0000;(#,##0.0000);0.0000")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PUBsS").Equals(DBNull.Value) Then
            BsCovenin.Text = "0.00"
        Else
            BsCovenin.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PUBsS")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PUUSD").Equals(DBNull.Value) Then
            USDCov.Text = "0.00"
        Else
            USDCov.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PUUSD")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotMat").Equals(DBNull.Value) Then
            CTMatC.Text = "0.00"
        Else
            CTMatC.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotMat")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PrcMat").Equals(DBNull.Value) Then
            pINCMt.Text = "0.00"
        Else
            pINCMt.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PrcMat")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotEqp").Equals(DBNull.Value) Then
            CTEqpC.Text = "0.00"
        Else
            CTEqpC.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotEqp")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PcrEqp").Equals(DBNull.Value) Then
            pINCEq.Text = "0.00"
        Else
            pINCEq.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PcrEqp")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotMdO").Equals(DBNull.Value) Then
            CTMdOC.Text = "0.00"
        Else
            CTMdOC.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotMdO")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PrcMdO").Equals(DBNull.Value) Then
            pINCMo.Text = "0.00"
        Else
            pINCMo.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PrcMdO")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotTrans").Equals(DBNull.Value) Then
            CTTrnC.Text = "0.00"
        Else
            CTTrnC.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("TotTrans")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        If PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PrcTrans").Equals(DBNull.Value) Then
            pINCTr.Text = "0.00"
        Else
            pINCTr.Text = CDbl(PCovenin.Tables("PartidasCOVENIN").Rows(CCell).Item("PrcTrans")).ToString("#,##0.00;(#,##0.00);0.00")
        End If
    End Sub
End Class
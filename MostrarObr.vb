Public Class MostrarObr
    Public precioBsS As Double
    Public precioUSD As Double
    Public LoadChk As Boolean
    Public fila As Object
    Public CantPartStr As String
    Public RendPartStr As String
    Public PUPartStr As String
    Public PAPartStr As String
    Public PTPartstr As String
    Public partida As Object
    Public nRecords As Integer
    Public CodObr As String
    Public CodPart As String
    Public CodObrA As String
    Public CodObrE As Integer
    Public CodPartE As String
    Public idx As Integer
    Public codAnt As String
    Public idxTabla As Integer
    Public elem As Integer
    Public ParGrdE As Object
    Public codigoP As String
    Public desPart As String
    Public MDesPart As String
    Public nPartd As String
    Public cCov As String
    Public pTexto As String
    Public cant As String
    Public und As String
    Public rend As String
    Public PUnit As String
    Public Padop As String
    Public TotP As String
    Public recs As Integer
    Public pRec As Integer
    Public NpartObr As Integer
    Public NRecMat As Integer
    Public NRecEqp As Integer
    Public NRecMdO As Integer
    Public NRecTrn As Integer
    Public TotMatP As Double
    Public TotEqpP As Double
    Public TotalEqp As Double
    Public TotMdOP As Double
    Public TotJrnP As Double
    Public TotBnoP As Double
    Public STotMDO As Double
    Public FCASVal As Double = 247
    Public MtoFCAS As Double
    Public BonoAlm As Double = 0.0
    Public MtoBAlm As Double
    Public TotTrnP As Double
    Public CostDir As Double
    Public PrecioU As Double
    Public TotalGP As Double
    Public Utilidad As Double = 10
    Public Administracion As Double = 15
    Public Util As Double
    Public Admi As Double
    Public PrAdm As Double
    Public PrCDA As Double
    Public prUti As Double
    Public firstTime As Boolean = True
    Public PTotPart As Double
    Public totCstObr As Double
    Public CodigoObr As String

    'Parametros Dataset
    Public ConStr As New OleDb.OleDbConnection
    Public DBProvider As String
    Public DBSource As String
    Public DBPath As String
    Public DBName As String


    'Variables para Obras
    Public DSetObras As New DataSet
    Public DAObras As OleDb.OleDbDataAdapter
    Public cmdSQLObra As String

    'Variables para Partidas (DataGrid)
    Public DSetPartidas As New DataSet
    Public DAPartidas As OleDb.OleDbDataAdapter
    Public cmdSQLPart As String

    Private Sub MostrarObr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 'ObrasAPO.obras' table. You can move, or remove it, as needed.
        Me.ObrasTableAdapter.Fill(Me.ObrasAPO.obras)
        'TODO: This line of code loads data into the 'AnPartidas._AnPartidas' table. You can move, or remove it, as needed.
        Me.AnPartidasTableAdapter.Fill(Me.AnPartidas._AnPartidas)

        DBProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"
        DBPath = "C:\Users\jrozap\Documents\Steel Design Co\Analisis Precios Unitarios\APV 32-bit\APP2020.NET\APP2020\APP2020"
        DBName = "\MasterAPV.MDB"
        DBSource = "Data Source = " & DBPath & DBName
        ConStr.ConnectionString = DBProvider & DBSource
        ConStr.Open()

        firstTime = True
        LoadChk = True

        nRecords = ObrasAPO.Tables("obras").Rows.Count
        NpartObr = ObrasAPO.Tables("obras").Rows.Count - 1

        For idx = 0 To nRecords - 1
            CodObr = ObrasAPO.Tables("obras").Rows(idx).Item("cod-obr")
            ComboBox1.Items.Insert(idx, CodObr)
        Next
        ComboBox1.SelectedIndex = 0
        RadioButton1.Checked = True
        CodigoObr = ComboBox1.Items.Item(0)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim interval As Double
        Dim valLoad As Double

        If Not firstTime Then
            'Clear DataSet: Partidas
            PartidasGrid.DataSource.clear()
            PartidasGrid.Refresh()
        Else
            firstTime = False
        End If

        totCstObr = 0

        elem = ComboBox1.SelectedIndex
        CodObr = ObrasAPO.Tables("obras").Rows(elem).Item("cod-obr")
        If ObrasAPO.Tables("obras").Rows(elem).Item("desc-obr").Equals(DBNull.Value) Then
            DescObr.Text = ""
        Else
            DescObr.Text = CStr(ObrasAPO.Tables("obras").Rows(elem).Item(1))
        End If

        cmdSQLPart = "SELECT * FROM AnPartidas WHERE [cod-obr-apu] = '" & CStr(CodObr) & "' ORDER BY [cod-obr-apu], [num-par-apu]"
        DAPartidas = New OleDb.OleDbDataAdapter(cmdSQLPart, ConStr)
        DAPartidas.Fill(DSetPartidas, "PartO")

        NRecMat = DSetPartidas.Tables("PartO").Rows.Count
        NRecs.Text = CInt(NRecMat).ToString("#,##0;(#,##0);0")
        interval = 100 / NRecMat
        valLoad = 0

        PartidasGrid.DataSource = DSetPartidas.Tables("PartO")
        PartidasGrid.Refresh()

        PartidasGrid.Rows(0).Selected = True

        For idx = 0 To (NRecMat - 1)
            PTotPart = Me.PartidasGrid.Item(16, idx).Value
            totCstObr = totCstObr + PTotPart
            valLoad = valLoad + interval
            PartLoad.Value = valLoad
        Next

        CostoObr.Text = CDbl(totCstObr).ToString("#,##0.00;(#,##0.00);0.00")
        CstAdopObr.Text = CDbl(totCstObr).ToString("#,##0.00;(#,##0.00);0.00")
    End Sub

    Private Sub PartidasGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PartidasGrid.CellClick

        ParGrdE = Me.PartidasGrid.Item(0, e.RowIndex).Value - 1
        If DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("num-par-apu").Equals(DBNull.Value) Then
            nPartd = ""
        Else
            nPartd = CStr(DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("num-par-apu"))
        End If
        If DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("Descripcion1").Equals(DBNull.Value) Then
            desPart = ""
        Else
            desPart = CStr(DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("Descripcion1") & DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("Descripcion2") & DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("Descripcion3"))
        End If
        If DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("MiniDescripcion").Equals(DBNull.Value) Then
            MDesPart = ""
        Else
            MDesPart = CStr(DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("MiniDescripcion"))
        End If
        If DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("CodigoCovenin").Equals(DBNull.Value) Then
            cCov = ""
        Else
            cCov = DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("CodigoCovenin")
        End If
        If (DSetPartidas.Tables("PartO").Rows(ParGrdE).Item(7)).Equals(DBNull.Value) Then
            pTexto = ""
        Else
            pTexto = CStr(DSetPartidas.Tables("PartO").Rows(ParGrdE).Item(7))
        End If
        If DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("can-apr-apu").Equals(DBNull.Value) Then
            cant = ""
        Else
            cant = CDbl(DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("can-apr-apu")).ToString("#,##0.00;(#,##0.00);0.00")
        End If
        If DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("und-par-apu").Equals(DBNull.Value) Then
            und = ""
        Else
            und = CStr(DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("und-par-apu"))
        End If
        If DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("ren-par-apu").Equals(DBNull.Value) Then
            rend = ""
        Else
            rend = CDbl(DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("ren-par-apu")).ToString("#,##0.00;(#,##0.00);0.00")
        End If
        If DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("pun-ana-apu").Equals(DBNull.Value) Then
            PUnit = ""
        Else
            PUnit = CDbl(DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("pun-ana-apu")).ToString("#,##0.00;(#,##0.00);0.00")
        End If
        If DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("pun-adp-apu").Equals(DBNull.Value) Then
            Padop = ""
        Else
            Padop = CDbl(DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("pun-adp-apu")).ToString("#,##0.00;(#,##0.00);0.00")
        End If
        If DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("tot-gen-apu").Equals(DBNull.Value) Then
            TotP = ""
        Else
            TotP = CDbl(DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("tot-gen-apu")).ToString("#,##0.00;(#,##0.00);0.00")
        End If

        NPart.Text = nPartd
        MDescPart.Text = MDesPart
        DescPart.Text = desPart
        COVENINp.Text = cCov
        TextPart.Text = pTexto
        CantPart.Text = cant
        UndPart.Text = und
        RendPart.Text = rend
        PUPart.Text = PUnit
        PAPart.Text = Padop
        PTPart.Text = TotP

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CodigoObr = ComboBox1.Items.Item(ComboBox1.SelectedIndex)
        AnalPUnit.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        CodigoObr = ComboBox1.Items.Item(ComboBox1.SelectedIndex)
        PreGObr.Show()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

        precioBsS = CDbl(totCstObr)

        If LoadChk Then
            LoadChk = False
        Else
            If RadioButton1.Checked Then
                RadioButton2.Checked = False

                precioBsS = CDbl(precioUSD) * 9.85

                CostoObr.Text = CDbl(precioBsS).ToString("#,##0.00;(#,##0.00);0.00")
                CstAdopObr.Text = CDbl(precioBsS).ToString("#,##0.00;(#,##0.00);0.00")
            End If
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged

        precioBsS = CDbl(totCstObr)

        If LoadChk Then
            LoadChk = False
        Else
            If RadioButton2.Checked Then
                RadioButton1.Checked = False

                precioUSD = CDbl(precioBsS) / 9.85

                CostoObr.Text = CDbl(precioUSD).ToString("#,##0.00;(#,##0.00);0.00")
                CstAdopObr.Text = CDbl(precioUSD).ToString("#,##0.00;(#,##0.00);0.00")
            End If
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        NvaPart.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub
End Class
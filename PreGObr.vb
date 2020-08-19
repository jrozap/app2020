Public Class PreGObr
    Public FirstT As Boolean = True
    Public obrCD As String
    Public idxF As Integer
    Public partidaIdx As Integer
    Public fila As Object
    Public CantPartStr As String
    Public RendPartStr As String
    Public PUPartStr As String
    Public PAPartStr As String
    Public PTPartstr As String
    Public partida As Object
    Public nRecords As Integer
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
    Public totPAP As Double

    Public PTotPart As Double
    Public totCstObr As Double

    'Parametros Dataset
    Public ConStr As New OleDb.OleDbConnection
    Public DBProvider As String
    Public DBSource As String
    Public DBPath As String
    Public DBName As String

    'Variables para Partidas (DataGrid)
    Public DSetPartidas As New DataSet
    Public DAPart As OleDb.OleDbDataAdapter
    Public cmdSQLPart As String

    'Variables para Obras
    Public DSetObras As New DataSet
    Public DAObras As OleDb.OleDbDataAdapter
    Public cmdSQLObra As String

    Private Sub PreGObr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ObrasAPO.obras' table. You can move, or remove it, as needed.
        Me.ObrasTableAdapter.Fill(Me.ObrasAPO.obras)
        'TODO: This line of code loads data into the 'AnPartidas._AnPartidas' table. You can move, or remove it, as needed.
        Me.AnPartidasTableAdapter.Fill(Me.AnPartidas._AnPartidas)

        Dim OValue As Object

        DBProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"
        DBPath = "C:\Users\jrozap\Documents\Steel Design Co\Analisis Precios Unitarios\APV 32-bit\APP2020.NET\APP2020\APP2020"
        DBName = "\MasterAPV.MDB"
        DBSource = "Data Source = " & DBPath & DBName
        ConStr.ConnectionString = DBProvider & DBSource
        ConStr.Open()
        obrCD = MostrarObr.CodigoObr

        'Partidas de la Obra
        cmdSQLPart = "SELECT * FROM AnPartidas WHERE [cod-obr-apu] = '" & CStr(obrCD) & "' ORDER BY [cod-obr-apu], [num-par-apu] "
        DAPart = New OleDb.OleDbDataAdapter(cmdSQLPart, ConStr)
        DAPart.Fill(DSetPartidas, "PObr")

        codAnt = ""
        idxTabla = 0
        nRecords = 0
        nRecords = DSetPartidas.Tables("PObr").Rows.Count
        NpartObr = DSetPartidas.Tables("PObr").Rows.Count - 1

        CObr.Text = MostrarObr.CodigoObr
        OValue = MostrarObr.ParGrdE
        For idx = 0 To nRecords - 1
            If DSetPartidas.Tables("PObr").Rows(idx).Item("cod-obr-apu") = CObr.Text Then
                partidaIdx = idx + CInt(OValue)
                idxF = idx
                Exit For
            End If
        Next

        elem = partidaIdx
        DescObr.Text = MostrarObr.DescObr.Text
    End Sub

    Private Sub DescObr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DescObr.TextChanged
        totCstObr = 0

        If FirstT Then
            FirstT = False
        Else
            PartGridP.DataSource.clear()
            PartGridP.Refresh()
        End If

        cmdSQLPart = "SELECT * FROM AnPartidas WHERE [cod-obr-apu] = '" & CStr(obrCD) & "' ORDER BY [num-par-apu]"
        DAPart = New OleDb.OleDbDataAdapter(cmdSQLPart, ConStr)
        DAPart.Fill(DSetPartidas, "PartO")

        NRecMat = DSetPartidas.Tables("PartO").Rows.Count
        NRecs.Text = CInt(NRecMat).ToString("#,##0;(#,##0);0")

        PartGridP.DataSource = DSetPartidas.Tables("PartO")
        PartGridP.Refresh()

        ParGrdE = DSetPartidas.Tables("PartO").Rows(0).Item("num-par-apu") - 1

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
        If DSetPartidas.Tables("PartO").Rows(ParGrdE).Item(7).Equals(DBNull.Value) Then
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

        totPAP = CDbl(DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("pun-adp-apu")) * CDbl(DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("can-apr-apu"))
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
        PATPart.Text = totPAP.ToString("#,##0.00;(#,##0.00);0.00")
        PTPart.Text = TotP

        For idx = 0 To (NRecMat - 1)
            PTotPart = Me.PartGridP.Item(9, idx).Value
            totCstObr = totCstObr + PTotPart
        Next

        CostoObr.Text = CDbl(totCstObr).ToString("#,##0.00;(#,##0.00);0.00")
    End Sub

    Private Sub PartGridP_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PartGridP.CellClick
        totCstObr = 0

        ParGrdE = Me.PartGridP.Item(0, e.RowIndex).Value - 1

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
        If DSetPartidas.Tables("PartO").Rows(ParGrdE).Item(7).Equals(DBNull.Value) Then
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

        totPAP = CDbl(DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("pun-adp-apu")) * CDbl(DSetPartidas.Tables("PartO").Rows(ParGrdE).Item("can-apr-apu"))
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
        PATPart.Text = totPAP.ToString("#,##0.00;(#,##0.00);0.00")
        PTPart.Text = TotP

        For idx = 0 To (NRecMat - 1)
            PTotPart = Me.PartGridP.Item(9, idx).Value
            totCstObr = totCstObr + PTotPart
        Next

        CostoObr.Text = CDbl(totCstObr).ToString("#,##0.00;(#,##0.00);0.00")
    End Sub
End Class
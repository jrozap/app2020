Public Class AnalPUnit
    Public idxF As Integer
    Public fila As Object
    Public CantPartStr As String
    Public RendPartStr As String
    Public PUPartStr As String
    Public PAPartStr As String
    Public PTPartstr As String
    Public partida As Object
    Public nRecords As Integer
    Public CodPart As String
    Public idx As Integer
    Public codAnt As String
    Public idxTabla As Integer
    Public elem As Integer
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
    Public obraIdx As Integer
    Public partidaIdx As Integer
    Public TGPDollar As Double
    Public TGADollar As Double
    Public PUUSD As Double
    Public PAUSD As Double

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

    Private Sub AnalPUnit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim OValue As Object

        DBProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"
        DBPath = "C:\Users\jrozap\Documents\Steel Design Co\Analisis Precios Unitarios\APV 32-bit\APP2020.NET\APP2020\APP2020"
        DBName = "\MasterAPV.MDB"
        DBSource = "Data Source = " & DBPath & DBName
        ConStr.ConnectionString = DBProvider & DBSource
        ConStr.Open()

        'Partidas de la Obra
        cmdSQLPart = "SELECT * FROM PartObr ORDER BY [cod-obr-apu], [num-par-apu] "
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

        DescObr.Text = MostrarObr.DescObr.Text
        elem = partidaIdx

    End Sub

    Private Sub PartSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartSig.Click
        Dim lastpart As Boolean

        If elem < NpartObr Or elem < idxF Then
            lastpart = False
            elem = elem + 1
            CostDir = 0
            Util = 0
            Admi = 0
            PrAdm = 0
            PrCDA = 0
            prUti = 0
            PrecioU = 0
            TotalGP = 0
        Else
            MessageBox.Show("No existen mas Partidas en la obra: " & CStr(DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("desc-obr")) & " - " & DSetPartidas.Tables("PObr").Rows(idx).Item("cod-obr-apu"))
            lastpart = True
        End If

        If Not lastpart Then
            If DSetPartidas.Tables("PObr").Rows(elem).Item("desc-obr").Equals(DBNull.Value) Then
                DescObr.Text = ""
            Else
                DescObr.Text = CStr(DSetPartidas.Tables("PObr").Rows(elem).Item("desc-obr"))
            End If
            If DSetPartidas.Tables("PObr").Rows(elem).Item("num-par-apu").Equals(DBNull.Value) Then
                nPartd = ""
            Else
                nPartd = CStr(DSetPartidas.Tables("PObr").Rows(elem).Item("num-par-apu"))
            End If
            If DSetPartidas.Tables("PObr").Rows(elem).Item("Descripcion1").Equals(DBNull.Value) Then
                desPart = ""
            Else
                desPart = CStr(DSetPartidas.Tables("PObr").Rows(elem).Item("Descripcion1") & DSetPartidas.Tables("PObr").Rows(elem).Item("Descripcion2") & DSetPartidas.Tables("PObr").Rows(elem).Item("Descripcion3"))
            End If
            If DSetPartidas.Tables("PObr").Rows(elem).Item("MiniDescripcion").Equals(DBNull.Value) Then
                MDesPart = ""
            Else
                MDesPart = CStr(DSetPartidas.Tables("PObr").Rows(elem).Item("MiniDescripcion"))
            End If
            If DSetPartidas.Tables("PObr").Rows(elem).Item("CodigoCovenin").Equals(DBNull.Value) Then
                cCov = ""
            Else
                cCov = DSetPartidas.Tables("PObr").Rows(elem).Item("CodigoCovenin")
            End If
            If DSetPartidas.Tables("PObr").Rows(elem).Item(10).Equals(DBNull.Value) Then
                pTexto = ""
            Else
                pTexto = CStr(DSetPartidas.Tables("PObr").Rows(elem).Item(10))
            End If
            If DSetPartidas.Tables("PObr").Rows(elem).Item("can-apr-apu").Equals(DBNull.Value) Then
                cant = ""
            Else
                cant = CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("can-apr-apu")).ToString("#,##0.00;(#,##0.00);0.00")
            End If
            If DSetPartidas.Tables("PObr").Rows(elem).Item("und-par-apu").Equals(DBNull.Value) Then
                und = ""
            Else
                und = CStr(DSetPartidas.Tables("PObr").Rows(elem).Item("und-par-apu"))
            End If
            If DSetPartidas.Tables("PObr").Rows(elem).Item("ren-par-apu").Equals(DBNull.Value) Then
                rend = ""
            Else
                rend = CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("ren-par-apu")).ToString("#,##0.00;(#,##0.00);0.00")
            End If
            If DSetPartidas.Tables("PObr").Rows(elem).Item("pun-ana-apu").Equals(DBNull.Value) Then
                PUnit = ""
            Else
                PUnit = CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("pun-ana-apu")).ToString("#,##0.00;(#,##0.00);0.00")
            End If
            If DSetPartidas.Tables("PObr").Rows(elem).Item("pun-adp-apu").Equals(DBNull.Value) Then
                Padop = ""
            Else
                Padop = CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("pun-adp-apu")).ToString("#,##0.00;(#,##0.00);0.00")
            End If
            If DSetPartidas.Tables("PObr").Rows(elem).Item("tot-gen-apu").Equals(DBNull.Value) Then
                TotP = ""
            Else
                TotP = CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("tot-gen-apu")).ToString("#,##0.00;(#,##0.00);0.00")
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

            'Materiales de la Partida
            MatGrid.DataSource.clear()
            MatGrid.Refresh()

            'Equipos de la Partida
            EqpDGrid.DataSource.clear()
            EqpDGrid.Refresh()

            'Mano Obra de la Partida
            MODGrid.DataSource.clear()
            MODGrid.Refresh()

            'Transportes de la Partida
            TransDGrid.DataSource.clear()
            TransDGrid.Refresh()

            'Materiales de la Partida
            partida = nPartd

            cmdSQLMt = "SELECT * FROM MatPU WHERE [num-par-apu] = " + CStr(partida) + " AND [cod-obr-apu] = '" + CStr(MostrarObr.CodigoObr) + "' ORDER BY [num-par-apu],[cod-mat-apu]"
            DAMaterial = New OleDb.OleDbDataAdapter(cmdSQLMt, ConStr)
            DAMaterial.Fill(DSetMaterial, "MatPU")

            NRecMat = DSetMaterial.Tables("MatPU").Rows.Count
            MatGrid.DataSource = DSetMaterial.Tables(0)
            MatGrid.Refresh()

            TotMatP = 0
            For idx = 0 To NRecMat - 1
                TotMatP = TotMatP + DSetMaterial.Tables("MatPU").Rows(idx).Item("tot-mat-apu")
            Next
            TMat.Text = CDbl(TotMatP).ToString("#,##0.00;(#,##0.00);0.00")

            'Equipos de la Partida
            partida = nPartd

            cmdSQLEq = "SELECT * FROM EqpPU WHERE [num-par-apu] = " + CStr(partida) + " AND [cod-obr-apu] = '" + CStr(MostrarObr.CodigoObr) + "' ORDER BY [num-par-apu], [cod-eqp-apu]"
            DAEquipos = New OleDb.OleDbDataAdapter(cmdSQLEq, ConStr)
            DAEquipos.Fill(DSetEquipos, "EquipoPU")

            NRecEqp = DSetEquipos.Tables("EquipoPU").Rows.Count
            EqpDGrid.DataSource = DSetEquipos.Tables(0)
            EqpDGrid.Refresh()

            TotEqpP = 0
            TotalEqp = 0
            For idx = 0 To NRecEqp - 1
                TotEqpP = TotEqpP + DSetEquipos.Tables("EquipoPU").Rows(idx).Item("ceq-apu-tot")
            Next
            TotalEqp = TotEqpP / rend
            TEqp.Text = CDbl(TotalEqp).ToString("#,##0.00;(#,##0.00);0.00")

            'Mano Obra de la Partida
            partida = nPartd

            cmdSQLMO = "SELECT * FROM MdOPU WHERE [num-par-apu] = " + CStr(partida) + " AND [cod-obr-apu] = '" + CStr(MostrarObr.CodigoObr) + "' ORDER BY [num-par-apu], [cod-mob-apu]"
            DAMdO = New OleDb.OleDbDataAdapter(cmdSQLMO, ConStr)
            DAMdO.Fill(DSetMdO, "MdObraPU")

            NRecMdO = DSetMdO.Tables("MdObraPU").Rows.Count
            MODGrid.DataSource = DSetMdO.Tables(0)
            MODGrid.Refresh()

            TotMdOP = 0
            STotMDO = 0
            MtoFCAS = 0
            MtoBAlm = 0
            TotJrnP = 0
            TotBnoP = 0
            For idx = 0 To NRecMdO - 1
                TotJrnP = TotJrnP + DSetMdO.Tables("MdObraPU").Rows(idx).Item("tot-jrn-apu")
                TotBnoP = TotBnoP + DSetMdO.Tables("MdObraPU").Rows(idx).Item("tot-bno-apu")
            Next
            STotMDO = TotJrnP + TotBnoP
            STMObra.Text = CDbl(STotMDO).ToString("#,##0.00;(#,##0.00);0.00")
            MtoFCAS = STotMDO * (FCASVal / 100)
            pFCAS.Text = CDbl(FCASVal).ToString("#,##0.00;(#,##0.00);0.00")
            FCAS.Text = CDbl(MtoFCAS).ToString("#,##0.00;(#,##0.00);0.00")
            MtoBAlm = 0
            BonoA.Text = CDbl(MtoBAlm).ToString("#,##0.00;(#,##0.00);0.00")
            TotMdOP = (STotMDO + MtoFCAS + MtoBAlm) / rend
            TMdO.Text = CDbl(TotMdOP).ToString("#,##0.00;(#,##0.00);0.00")

            'Transportes de la Partida
            partida = nPartd

            cmdSQLTrn = "SELECT * FROM TraPU WHERE [num-par-apu] = " + CStr(partida) + " AND [cod-obr-apu] = '" + CStr(MostrarObr.CodigoObr) + "' ORDER BY [num-par-apu], [cod-trn-apu]"
            DATrans = New OleDb.OleDbDataAdapter(cmdSQLTrn, ConStr)
            DATrans.Fill(DSetTrn, "TranspPU")

            NRecTrn = DSetTrn.Tables("TranspPU").Rows.Count
            TransDGrid.DataSource = DSetTrn.Tables(0)
            TransDGrid.Refresh()

            TotTrnP = 0
            For idx = 0 To NRecTrn - 1
                TotTrnP = TotTrnP + DSetTrn.Tables("TranspPU").Rows(idx).Item("tot-trn-apu")
            Next
            TTrans.Text = CDbl(TotTrnP).ToString("#,##0.00;(#,##0.00);0.00")

            CostDir = TotMatP + TotTrnP + TotalEqp + TotMdOP
            CostoD.Text = CDbl(CostDir).ToString("#,##0.00;(#,##0.00);0.00")
            Util = Utilidad / 100
            Admi = Administracion / 100
            PrAdm = CostDir * Admi
            PrCDA = CostDir + PrAdm
            prUti = PrCDA * Util
            PrecioU = PrCDA + prUti
            UnitPrice.Text = CDbl(PrecioU).ToString("#,##0.00;(#,##0.00);0.00")
            TotalGP = PrecioU * cant
            TotGPart.Text = CDbl(TotalGP).ToString("#,##0.00;(#,##0.00);0.00")

            'Mostrar los montos totales de la partida en US Dollars
            TGPDollar = TotalGP / 9.85
            TGADollar = (CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("pun-adp-apu")) * cant) / 9.85
            PUUSD = PrecioU / 9.85
            PAUSD = CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("pun-adp-apu")) / 9.85

            PUDollar.Text = CDbl(PUUSD).ToString("#,##0.00;(#,##0.00);0.00")
            PADollar.Text = CDbl(PAUSD).ToString("#,##0.00;(#,##0.00);0.00")
            QPart.Text = CDbl(cant).ToString("#,##0.00;(#,##0.00);0.00")
            PTPDollar.Text = CDbl(TGPDollar).ToString("#,##0.00;(#,##0.00);0.00")
            PAPDollar.Text = CDbl(TGADollar).ToString("#,##0.00;(#,##0.00);0.00")
        End If
    End Sub

    Private Sub PartAnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartAnt.Click

        If elem > 0 Or elem > idxF Then
            elem = elem - 1
            CostDir = 0
            Util = 0
            Admi = 0
            PrAdm = 0
            PrCDA = 0
            prUti = 0
            PrecioU = 0
            TotalGP = 0
        Else
            MessageBox.Show("No existen mas Partidas en la obra: " & CStr(DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("desc-obr")) & " - " & DSetPartidas.Tables("PObr").Rows(idx).Item("cod-obr-apu"))
        End If

        If DSetPartidas.Tables("PObr").Rows(elem).Item("desc-obr").Equals(DBNull.Value) Then
            DescObr.Text = ""
        Else
            DescObr.Text = CStr(DSetPartidas.Tables("PObr").Rows(elem).Item("desc-obr"))
        End If
        If DSetPartidas.Tables("PObr").Rows(elem).Item("num-par-apu").Equals(DBNull.Value) Then
            nPartd = ""
        Else
            nPartd = CStr(DSetPartidas.Tables("PObr").Rows(elem).Item("num-par-apu"))
        End If
        If DSetPartidas.Tables("PObr").Rows(elem).Item("Descripcion1").Equals(DBNull.Value) Then
            desPart = ""
        Else
            desPart = CStr(DSetPartidas.Tables("PObr").Rows(elem).Item("Descripcion1") & DSetPartidas.Tables("PObr").Rows(elem).Item("Descripcion2") & DSetPartidas.Tables("PObr").Rows(elem).Item("Descripcion3"))
        End If
        If DSetPartidas.Tables("PObr").Rows(elem).Item("MiniDescripcion").Equals(DBNull.Value) Then
            MDesPart = ""
        Else
            MDesPart = CStr(DSetPartidas.Tables("PObr").Rows(elem).Item("MiniDescripcion"))
        End If
        If DSetPartidas.Tables("PObr").Rows(elem).Item("CodigoCovenin").Equals(DBNull.Value) Then
            cCov = ""
        Else
            cCov = DSetPartidas.Tables("PObr").Rows(elem).Item("CodigoCovenin")
        End If
        If DSetPartidas.Tables("PObr").Rows(elem).Item(10).Equals(DBNull.Value) Then
            pTexto = ""
        Else
            pTexto = CStr(DSetPartidas.Tables("PObr").Rows(elem).Item(10))
        End If
        If DSetPartidas.Tables("PObr").Rows(elem).Item("can-apr-apu").Equals(DBNull.Value) Then
            cant = ""
        Else
            cant = CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("can-apr-apu")).ToString("#,##0.00;(#,##0.00);0.00")
        End If
        If DSetPartidas.Tables("PObr").Rows(elem).Item("und-par-apu").Equals(DBNull.Value) Then
            und = ""
        Else
            und = CStr(DSetPartidas.Tables("PObr").Rows(elem).Item("und-par-apu"))
        End If
        If DSetPartidas.Tables("PObr").Rows(elem).Item("ren-par-apu").Equals(DBNull.Value) Then
            rend = ""
        Else
            rend = CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("ren-par-apu")).ToString("#,##0.00;(#,##0.00);0.00")
        End If
        If DSetPartidas.Tables("PObr").Rows(elem).Item("pun-ana-apu").Equals(DBNull.Value) Then
            PUnit = ""
        Else
            PUnit = CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("pun-ana-apu")).ToString("#,##0.00;(#,##0.00);0.00")
        End If
        If DSetPartidas.Tables("PObr").Rows(elem).Item("pun-adp-apu").Equals(DBNull.Value) Then
            Padop = ""
        Else
            Padop = CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("pun-adp-apu")).ToString("#,##0.00;(#,##0.00);0.00")
        End If
        If DSetPartidas.Tables("PObr").Rows(elem).Item("tot-gen-apu").Equals(DBNull.Value) Then
            TotP = ""
        Else
            TotP = CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("tot-gen-apu")).ToString("#,##0.00;(#,##0.00);0.00")
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

        'Materiales de la Partida
        MatGrid.DataSource.clear()
        MatGrid.Refresh()

        partida = nPartd

        cmdSQLMt = "SELECT * FROM MatPU WHERE [num-par-apu] = " + CStr(partida) + " AND [cod-obr-apu] = '" + CStr(MostrarObr.CodigoObr) + "' ORDER BY [num-par-apu], [cod-mat-apu]"
        DAMaterial = New OleDb.OleDbDataAdapter(cmdSQLMt, ConStr)
        DAMaterial.Fill(DSetMaterial, "MatPU")

        NRecMat = DSetMaterial.Tables("MatPU").Rows.Count
        MatGrid.DataSource = DSetMaterial.Tables(0)
        MatGrid.Refresh()

        TotMatP = 0
        For idx = 0 To NRecMat - 1
            TotMatP = TotMatP + DSetMaterial.Tables("MatPU").Rows(idx).Item("tot-mat-apu")
        Next
        TMat.Text = CDbl(TotMatP).ToString("#,##0.00;(#,##0.00);0.00")

        'Equipos de la Partida
        EqpDGrid.DataSource.clear()
        EqpDGrid.Refresh()

        partida = nPartd

        cmdSQLEq = "SELECT * FROM EqpPU WHERE [num-par-apu] = " + CStr(partida) + " AND [cod-obr-apu] = '" + CStr(MostrarObr.CodigoObr) + "' ORDER BY [num-par-apu], [cod-eqp-apu]"
        DAEquipos = New OleDb.OleDbDataAdapter(cmdSQLEq, ConStr)
        DAEquipos.Fill(DSetEquipos, "EquipoPU")

        NRecEqp = DSetEquipos.Tables("EquipoPU").Rows.Count
        EqpDGrid.DataSource = DSetEquipos.Tables(0)
        EqpDGrid.Refresh()

        TotEqpP = 0
        TotalEqp = 0
        For idx = 0 To NRecEqp - 1
            TotEqpP = TotEqpP + DSetEquipos.Tables("EquipoPU").Rows(idx).Item("ceq-apu-tot")
        Next
        TotalEqp = TotEqpP / rend
        TEqp.Text = CDbl(TotalEqp).ToString("#,##0.00;(#,##0.00);0.00")

        'Mano Obra de la Partida
        MODGrid.DataSource.clear()
        MODGrid.Refresh()

        partida = nPartd

        cmdSQLMO = "SELECT * FROM MdOPU WHERE [num-par-apu] = " + CStr(partida) + " AND [cod-obr-apu] = '" + CStr(MostrarObr.CodigoObr) + "' ORDER BY [num-par-apu], [cod-mob-apu]"
        DAMdO = New OleDb.OleDbDataAdapter(cmdSQLMO, ConStr)
        DAMdO.Fill(DSetMdO, "MdObraPU")

        NRecMdO = DSetMdO.Tables("MdObraPU").Rows.Count
        MODGrid.DataSource = DSetMdO.Tables(0)
        MODGrid.Refresh()

        TotMdOP = 0
        STotMDO = 0
        MtoFCAS = 0
        MtoBAlm = 0
        TotJrnP = 0
        TotBnoP = 0
        For idx = 0 To NRecMdO - 1
            TotJrnP = TotJrnP + DSetMdO.Tables("MdObraPU").Rows(idx).Item("tot-jrn-apu")
            TotBnoP = TotBnoP + DSetMdO.Tables("MdObraPU").Rows(idx).Item("tot-bno-apu")
        Next
        STotMDO = TotJrnP + TotBnoP
        STMObra.Text = CDbl(STotMDO).ToString("#,##0.00;(#,##0.00);0.00")
        MtoFCAS = STotMDO * (FCASVal / 100)
        pFCAS.Text = CDbl(FCASVal).ToString("#,##0.00;(#,##0.00);0.00")
        FCAS.Text = CDbl(MtoFCAS).ToString("#,##0.00;(#,##0.00);0.00")
        MtoBAlm = 0
        BonoA.Text = CDbl(MtoBAlm).ToString("#,##0.00;(#,##0.00);0.00")
        TotMdOP = (STotMDO + MtoFCAS + MtoBAlm) / rend
        TMdO.Text = CDbl(TotMdOP).ToString("#,##0.00;(#,##0.00);0.00")

        'Transportes de la Partida
        TransDGrid.DataSource.clear()
        TransDGrid.Refresh()

        partida = nPartd

        cmdSQLTrn = "SELECT * FROM TraPU WHERE [num-par-apu] = " + CStr(partida) + " AND [cod-obr-apu] = '" + CStr(MostrarObr.CodigoObr) + "' ORDER BY [num-par-apu], [cod-trn-apu]"
        DATrans = New OleDb.OleDbDataAdapter(cmdSQLTrn, ConStr)
        DATrans.Fill(DSetTrn, "TranspPU")

        NRecTrn = DSetTrn.Tables("TranspPU").Rows.Count
        TransDGrid.DataSource = DSetTrn.Tables(0)
        TransDGrid.Refresh()

        TotTrnP = 0
        For idx = 0 To NRecTrn - 1
            TotTrnP = TotTrnP + DSetTrn.Tables("TranspPU").Rows(idx).Item("tot-trn-apu")
        Next
        TTrans.Text = CDbl(TotTrnP).ToString("#,##0.00;(#,##0.00);0.00")

        CostDir = TotMatP + TotTrnP + TotalEqp + TotMdOP
        CostoD.Text = CDbl(CostDir).ToString("#,##0.00;(#,##0.00);0.00")
        Util = Utilidad / 100
        Admi = Administracion / 100
        PrAdm = CostDir * Admi
        PrCDA = CostDir + PrAdm
        prUti = PrCDA * Util
        PrecioU = PrCDA + prUti
        UnitPrice.Text = CDbl(PrecioU).ToString("#,##0.00;(#,##0.00);0.00")
        TotalGP = PrecioU * cant
        TotGPart.Text = CDbl(TotalGP).ToString("#,##0.00;(#,##0.00);0.00")

        'Mostrar los montos totales de la partida en US Dollars
        TGPDollar = TotalGP / 9.85
        TGADollar = (CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("pun-adp-apu")) * cant) / 9.85
        PUUSD = PrecioU / 9.85
        PAUSD = CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("pun-adp-apu")) / 9.85

        PUDollar.Text = CDbl(PUUSD).ToString("#,##0.00;(#,##0.00);0.00")
        PADollar.Text = CDbl(PAUSD).ToString("#,##0.00;(#,##0.00);0.00")
        QPart.Text = CDbl(cant).ToString("#,##0.00;(#,##0.00);0.00")
        PTPDollar.Text = CDbl(TGPDollar).ToString("#,##0.00;(#,##0.00);0.00")
        PAPDollar.Text = CDbl(TGADollar).ToString("#,##0.00;(#,##0.00);0.00")
    End Sub

    Private Sub DescObr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescObr.TextChanged

        CostDir = 0
        Util = 0
        Admi = 0
        PrAdm = 0
        PrCDA = 0
        prUti = 0
        PrecioU = 0
        TotalGP = 0

        If DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("desc-obr").Equals(DBNull.Value) Then
            DescObr.Text = ""
        Else
            DescObr.Text = CStr(DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("desc-obr"))
        End If
        If DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("num-par-apu").Equals(DBNull.Value) Then
            nPartd = ""
        Else
            nPartd = CStr(DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("num-par-apu"))
        End If
        If DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("Descripcion1").Equals(DBNull.Value) Then
            desPart = ""
        Else
            desPart = CStr(DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("Descripcion1") & DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("Descripcion2") & DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("Descripcion3"))
        End If
        If DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("MiniDescripcion").Equals(DBNull.Value) Then
            MDesPart = ""
        Else
            MDesPart = CStr(DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("MiniDescripcion"))
        End If
        If DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("CodigoCovenin").Equals(DBNull.Value) Then
            cCov = ""
        Else
            cCov = DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("CodigoCovenin")
        End If
        If DSetPartidas.Tables("PObr").Rows(partidaIdx).Item(10).Equals(DBNull.Value) Then
            pTexto = ""
        Else
            pTexto = CStr(DSetPartidas.Tables("PObr").Rows(partidaIdx).Item(10))
        End If
        If DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("can-apr-apu").Equals(DBNull.Value) Then
            cant = ""
        Else
            cant = CDbl(DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("can-apr-apu")).ToString("#,##0.00;(#,##0.00);0.00")
        End If
        If DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("und-par-apu").Equals(DBNull.Value) Then
            und = ""
        Else
            und = CStr(DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("und-par-apu"))
        End If
        If DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("ren-par-apu").Equals(DBNull.Value) Then
            rend = ""
        Else
            rend = CDbl(DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("ren-par-apu")).ToString("#,##0.00;(#,##0.00);0.00")
        End If
        If DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("pun-ana-apu").Equals(DBNull.Value) Then
            PUnit = ""
        Else
            PUnit = CDbl(DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("pun-ana-apu")).ToString("#,##0.00;(#,##0.00);0.00")
        End If
        If DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("pun-adp-apu").Equals(DBNull.Value) Then
            Padop = ""
        Else
            Padop = CDbl(DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("pun-adp-apu")).ToString("#,##0.00;(#,##0.00);0.00")
        End If
        If DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("tot-gen-apu").Equals(DBNull.Value) Then
            TotP = ""
        Else
            TotP = CDbl(DSetPartidas.Tables("PObr").Rows(partidaIdx).Item("tot-gen-apu")).ToString("#,##0.00;(#,##0.00);0.00")
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

        'Materiales de la Partida
        partida = nPartd

        cmdSQLMt = "SELECT * FROM MatPU WHERE [num-par-apu] = " + CStr(partida) + " AND [cod-obr-apu] ='" + CStr(MostrarObr.CodigoObr) + "' ORDER BY [num-par-apu], [cod-mat-apu]"
        DAMaterial = New OleDb.OleDbDataAdapter(cmdSQLMt, ConStr)
        DAMaterial.Fill(DSetMaterial, "MatPU")

        NRecMat = DSetMaterial.Tables("MatPU").Rows.Count
        MatGrid.DataSource = DSetMaterial.Tables(0)
        MatGrid.Refresh()

        TotMatP = 0
        For idx = 0 To NRecMat - 1
            TotMatP = TotMatP + DSetMaterial.Tables("MatPU").Rows(idx).Item("tot-mat-apu")
        Next
        TMat.Text = CDbl(TotMatP).ToString("#,##0.00;(#,##0.00);0.00")

        'Equipos de la Partida
        partida = nPartd

        cmdSQLEq = "SELECT * FROM EqpPU WHERE [num-par-apu] = " + CStr(partida) + " AND [cod-obr-apu] = '" + CStr(MostrarObr.CodigoObr) + "' ORDER BY [num-par-apu], [cod-eqp-apu]"
        DAEquipos = New OleDb.OleDbDataAdapter(cmdSQLEq, ConStr)
        DAEquipos.Fill(DSetEquipos, "EquipoPU")

        NRecEqp = DSetEquipos.Tables("EquipoPU").Rows.Count
        EqpDGrid.DataSource = DSetEquipos.Tables(0)
        EqpDGrid.Refresh()

        TotEqpP = 0
        TotalEqp = 0
        For idx = 0 To NRecEqp - 1
            TotEqpP = TotEqpP + DSetEquipos.Tables("EquipoPU").Rows(idx).Item("ceq-apu-tot")
        Next
        TotalEqp = TotEqpP / rend
        TEqp.Text = CDbl(TotalEqp).ToString("#,##0.00;(#,##0.00);0.00")

        'Mano Obra de la Partida
        partida = nPartd

        cmdSQLMO = "SELECT * FROM MdOPU WHERE [num-par-apu] = " + CStr(partida) + " AND [cod-obr-apu] = '" + CStr(MostrarObr.CodigoObr) + "' ORDER BY [num-par-apu], [cod-mob-apu]"
        DAMdO = New OleDb.OleDbDataAdapter(cmdSQLMO, ConStr)
        DAMdO.Fill(DSetMdO, "MdObraPU")

        NRecMdO = DSetMdO.Tables("MdObraPU").Rows.Count
        MODGrid.DataSource = DSetMdO.Tables(0)
        MODGrid.Refresh()

        TotMdOP = 0
        STotMDO = 0
        MtoFCAS = 0
        MtoBAlm = 0
        TotJrnP = 0
        TotBnoP = 0
        For idx = 0 To NRecMdO - 1
            TotJrnP = TotJrnP + DSetMdO.Tables("MdObraPU").Rows(idx).Item("tot-jrn-apu")
            TotBnoP = TotBnoP + DSetMdO.Tables("MdObraPU").Rows(idx).Item("tot-bno-apu")
        Next
        STotMDO = TotJrnP + TotBnoP
        STMObra.Text = CDbl(STotMDO).ToString("#,##0.00;(#,##0.00);0.00")
        MtoFCAS = STotMDO * (FCASVal / 100)
        pFCAS.Text = CDbl(FCASVal).ToString("#,##0.00;(#,##0.00);0.00")
        FCAS.Text = CDbl(MtoFCAS).ToString("#,##0.00;(#,##0.00);0.00")
        MtoBAlm = 0
        BonoA.Text = CDbl(MtoBAlm).ToString("#,##0.00;(#,##0.00);0.00")
        TotMdOP = (STotMDO + MtoFCAS + MtoBAlm) / rend
        TMdO.Text = CDbl(TotMdOP).ToString("#,##0.00;(#,##0.00);0.00")

        'Transportes de la Partida
        partida = nPartd

        cmdSQLTrn = "SELECT * FROM TraPU WHERE [num-par-apu] = " + CStr(partida) + " AND [cod-obr-apu] = '" + CStr(MostrarObr.CodigoObr) + "' ORDER BY [num-par-apu], [cod-trn-apu]"
        DATrans = New OleDb.OleDbDataAdapter(cmdSQLTrn, ConStr)
        DATrans.Fill(DSetTrn, "TranspPU")

        NRecTrn = DSetTrn.Tables("TranspPU").Rows.Count
        TransDGrid.DataSource = DSetTrn.Tables(0)
        TransDGrid.Refresh()

        TotTrnP = 0
        For idx = 0 To NRecTrn - 1
            TotTrnP = TotTrnP + DSetTrn.Tables("TranspPU").Rows(idx).Item("tot-trn-apu")
        Next
        TTrans.Text = CDbl(TotTrnP).ToString("#,##0.00;(#,##0.00);0.00")

        CostDir = TotMatP + TotTrnP + TotalEqp + TotMdOP
        CostoD.Text = CDbl(CostDir).ToString("#,##0.00;(#,##0.00);0.00")
        Util = Utilidad / 100
        Admi = Administracion / 100
        PrAdm = CostDir * Admi
        PrCDA = CostDir + PrAdm
        prUti = PrCDA * Util
        PrecioU = PrCDA + prUti
        UnitPrice.Text = CDbl(PrecioU).ToString("#,##0.00;(#,##0.00);0.00")
        TotalGP = PrecioU * cant
        TotGPart.Text = CDbl(TotalGP).ToString("#,##0.00;(#,##0.00);0.00")

        'Mostrar los montos totales de la partida en US Dollars
        TGPDollar = TotalGP / 9.85
        TGADollar = (CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("pun-adp-apu")) * cant) / 9.85
        PUUSD = PrecioU / 9.85
        PAUSD = CDbl(DSetPartidas.Tables("PObr").Rows(elem).Item("pun-adp-apu")) / 9.85

        PUDollar.Text = CDbl(PUUSD).ToString("#,##0.00;(#,##0.00);0.00")
        PADollar.Text = CDbl(PAUSD).ToString("#,##0.00;(#,##0.00);0.00")
        QPart.Text = CDbl(cant).ToString("#,##0.00;(#,##0.00);0.00")
        PTPDollar.Text = CDbl(TGPDollar).ToString("#,##0.00;(#,##0.00);0.00")
        PAPDollar.Text = CDbl(TGADollar).ToString("#,##0.00;(#,##0.00);0.00")
    End Sub
End Class
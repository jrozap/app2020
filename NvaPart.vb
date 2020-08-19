Public Class NvaPart

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
    Public CodObr As String
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
    Public firstTime As Boolean
    Public LoadChk As Boolean
    Public recObr As Integer
    Public obrIdx As Integer

    'Parametros Dataset
    Public ConStr As New OleDb.OleDbConnection
    Public DBProvider As String
    Public DBSource As String
    Public DBPath As String
    Public DBName As String

    'Variables para Partidas (COVENIN)
    Public DSetPCov As New DataSet
    Public DAPCov As OleDb.OleDbDataAdapter
    Public cmdSQLPCov As String

    'Variables para Partidas (MasterPart)
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

    Private Sub ChkMaster_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMaster.CheckedChanged
        If ChkMaster.Checked Then
            ChkCOVENIN.Checked = False
            ChkOtraOb.Checked = False
            CBCovenin.Enabled = False
            CBObras.Enabled = False
            CBOtraOb.Enabled = False
        Else
            If Not ChkCOVENIN.Checked Then
                CBCovenin.Enabled = True
                CBObras.Enabled = True
                CBOtraOb.Enabled = True
            End If
            If Not ChkOtraOb.Checked Then
                CBCovenin.Enabled = True
                CBObras.Enabled = True
                CBOtraOb.Enabled = True
            End If
        End If

        'Carga de codigos de partidas del maestro APP

        nRecords = MasterPart.Tables("MasterPartidas").Rows.Count
        NpartObr = MasterPart.Tables("MasterPartidas").Rows.Count - 1

        For idx = 0 To nRecords - 1
            CodPart = MasterPart.Tables("MasterPartidas").Rows(idx).Item("CodParL")
            CBMaster.Items.Insert(idx, CodPart)
        Next
    End Sub

    Private Sub ChkCOVENIN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCOVENIN.CheckedChanged
        If ChkCOVENIN.Checked Then
            ChkMaster.Checked = False
            ChkOtraOb.Checked = False
            CBMaster.Enabled = False
            CBOtraOb.Enabled = False
            CBObras.Enabled = False
        Else
            If Not ChkMaster.Checked Then
                CBMaster.Enabled = True
                CBObras.Enabled = True
                CBOtraOb.Enabled = True
            End If
            If Not ChkOtraOb.Checked Then
                CBMaster.Enabled = True
                CBObras.Enabled = True
                CBOtraOb.Enabled = True
            End If
        End If

        'Carga de codigos de partidas de la Norma COVENIN

        nRecords = PCovenin.Tables("PartidasCOVENIN").Rows.Count
        NpartObr = PCovenin.Tables("PartidasCOVENIN").Rows.Count - 1

        For idx = 0 To nRecords - 1
            CodPart = PCovenin.Tables("PartidasCOVENIN").Rows(idx).Item("CodigoCovenin")
            CBCovenin.Items.Insert(idx, CodPart)
        Next
    End Sub

    Private Sub ChkOtraOb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkOtraOb.CheckedChanged
        If ChkOtraOb.Checked Then
            ChkCOVENIN.Checked = False
            ChkMaster.Checked = False
            CBCovenin.Enabled = False
            CBMaster.Enabled = False
        Else
            If Not ChkMaster.Checked Then
                CBCovenin.Enabled = True
                CBMaster.Enabled = True
            End If
            If Not ChkOtraOb.Checked Then
                CBCovenin.Enabled = True
                CBMaster.Enabled = True
            End If
        End If

        'Carga de codigos de partidas desde otra Obra

        recObr = ObrasAPO.Tables("obras").Rows.Count
        obrIdx = ObrasAPO.Tables("obras").Rows.Count - 1

        For idx = 0 To recObr - 1
            If idx = 0 Then
                CodObr = ObrasAPO.Tables("obras").Rows(idx).Item("cod-obr")
            End If
            CodPart = ObrasAPO.Tables("obras").Rows(idx).Item("cod-obr")
            CBObras.Items.Insert(idx, CodPart)
        Next


        partida = nPartd

        cmdSQLPart = "SELECT * FROM PartObr WHERE [cod-obr-apu] = '" + CStr(CodObr) + "' ORDER BY [cod-obr-apu]"
        DAPart = New OleDb.OleDbDataAdapter(cmdSQLPart, ConStr)
        DAPart.Fill(DSetPartidas, "PartObra")
        CBObras.Text = CodObr

        nRecords = DSetPartidas.Tables(0).Rows.Count
        NpartObr = DSetPartidas.Tables(0).Rows.Count - 1

        For idx = 0 To nRecords - 1
            CodPart = DSetPartidas.Tables(0).Rows(idx).Item("cod-par-m")
            CBOtraOb.Items.Insert(idx, CodPart)
        Next
    End Sub

    Private Sub CBMaster_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBMaster.SelectedIndexChanged
        elem = CBMaster.SelectedIndex

        If MasterPart.Tables("MasterPartidas").Rows(elem).Item("MiniDescripcion").Equals(DBNull.Value) Then
            MiniDesc.Text = ""
        Else
            MiniDesc.Text = MasterPart.Tables("MasterPartidas").Rows(elem).Item("MiniDescripcion")
        End If
        If MasterPart.Tables("MasterPartidas").Rows(elem).Item("Descripcion1").Equals(DBNull.Value) Then
            DescTot.Text = ""
        Else
            DescTot.Text = MasterPart.Tables("MasterPartidas").Rows(elem).Item("Descripcion1") & MasterPart.Tables("MasterPartidas").Rows(elem).Item("Descripcion2") & MasterPart.Tables("MasterPartidas").Rows(elem).Item("Descripcion3")
        End If
        MedUnit.Text = MasterPart.Tables("MasterPartidas").Rows(elem).Item("Unidad")
        RendU.Text = CDbl(MasterPart.Tables("MasterPartidas").Rows(elem).Item("Rendimiento")).ToString("#,##0.0000;(#,##0.0000);0.0000")
        CostoBs.Text = CDbl(MasterPart.Tables("MasterPartidas").Rows(elem).Item("PrecioUnitario")).ToString("#,##0.00;(#,##0.00);0.00")
        CostoUSD.Text = CDbl(MasterPart.Tables("MasterPartidas").Rows(elem).Item("PrecioUnitario2Mon")).ToString("#,##0.00;(#,##0.00);0.00")

        If Not firstTime Then
            'Clear DataSet: Partidas
            MatGrid.DataSource.clear()
            MatGrid.Refresh()
            TransGrid.DataSource.clear()
            TransGrid.Refresh()
            EqpGrid.DataSource.clear()
            EqpGrid.Refresh()
            MdOGrid.DataSource.clear()
            MdOGrid.Refresh()
        Else
            firstTime = False
        End If

        'TODO: This line of code loads data into the 'MasterMat.MasterMaterial' table. You can move, or remove it, as needed.
        Me.MasterMaterialTableAdapter.Fill(Me.MasterMat.MasterMaterial)
        'TODO: This line of code loads data into the 'MasterTrans._MasterTrans' table. You can move, or remove it, as needed.
        Me.MasterTransTableAdapter.Fill(Me.MasterTrans._MasterTrans)
        'TODO: This line of code loads data into the 'MasterEqp._MasterEqp' table. You can move, or remove it, as needed.
        Me.MasterEqpTableAdapter.Fill(Me.MasterEqp._MasterEqp)
        'TODO: This line of code loads data into the 'MasterMdO.MasterManoObra' table. You can move, or remove it, as needed.
        Me.MasterManoObraTableAdapter.Fill(Me.MasterMdO.MasterManoObra)

        partida = MasterPart.Tables("MasterPartidas").Rows(elem).Item("CodParL")

        'Materiales
        cmdSQLMt = "SELECT * FROM MatPU WHERE [cod-par-m] ='" + CStr(partida) + "' ORDER BY [cod-par-m], [cod-mat-apu]"
        DAMaterial = New OleDb.OleDbDataAdapter(cmdSQLMt, ConStr)
        DAMaterial.Fill(DSetMaterial, "MatPU")

        MatGrid.DataSource = DSetMaterial.Tables(0)
        MatGrid.Refresh()

        'Transportes
        cmdSQLTrn = "SELECT * FROM TraPU WHERE [cod-par-m] ='" + CStr(partida) + "' ORDER BY [num-par-apu], [cod-trn-apu]"
        DATrans = New OleDb.OleDbDataAdapter(cmdSQLTrn, ConStr)
        DATrans.Fill(DSetTrn, "TranspPU")

        TransGrid.DataSource = DSetTrn.Tables(0)
        TransGrid.Refresh()

        'Equipos
        cmdSQLEq = "SELECT * FROM EqpPU WHERE [cod-par-m] ='" + CStr(partida) + "' ORDER BY [num-par-apu], [cod-eqp-apu]"
        DAEquipos = New OleDb.OleDbDataAdapter(cmdSQLEq, ConStr)
        DAEquipos.Fill(DSetEquipos, "EquipoPU")

        EqpGrid.DataSource = DSetEquipos.Tables(0)
        EqpGrid.Refresh()

        'Mano de Obra
        cmdSQLMO = "SELECT * FROM MdOPU WHERE [cod-par-m] ='" + CStr(partida) + "' ORDER BY [num-par-apu], [cod-mob-apu]"
        DAMdO = New OleDb.OleDbDataAdapter(cmdSQLMO, ConStr)
        DAMdO.Fill(DSetMdO, "MdObraPU")

        MdOGrid.DataSource = DSetMdO.Tables(0)
        MdOGrid.Refresh()
    End Sub

    Private Sub NvaPart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 'MasterPart.MasterPartidas' table. You can move, or remove it, as needed.
        Me.MasterPartTableAdapter.Fill(Me.MasterPart.MasterPartidas)
        'TODO: This line of code loads data into the 'PCovenin.PartidasCOVENIN' table. You can move, or remove it, as needed.
        Me.PartidasCOVENINTableAdapter.Fill(Me.PCovenin.PartidasCOVENIN)
        'TODO: This line of code loads data into the 'PCovenin.PartidasCOVENIN' table. You can move, or remove it, as needed.
        Me.ObrasTableAdapter.Fill(Me.ObrasAPO.obras)

        DBProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"
        DBPath = "C:\Users\jrozap\Documents\Steel Design Co\Analisis Precios Unitarios\APV 32-bit\APV2020.NET\APV2020\APV2020"
        DBName = "\MasterAPV.MDB"
        DBSource = "Data Source = " & DBPath & DBName
        ConStr.ConnectionString = DBProvider & DBSource
        ConStr.Open()

        firstTime = True
        LoadChk = True
    End Sub

    Private Sub CBObras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBObras.SelectedIndexChanged
        Dim interval As Double
        Dim valLoad As Double

        If Not firstTime Then
            'Clear DataSet: Partidas
            MatGrid.DataSource.clear()
            MatGrid.Refresh()
            TransGrid.DataSource.clear()
            TransGrid.Refresh()
            EqpGrid.DataSource.clear()
            EqpGrid.Refresh()
            MdOGrid.DataSource.clear()
            MdOGrid.Refresh()
        Else
            firstTime = False
        End If

    End Sub

    Private Sub MaterialPUBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
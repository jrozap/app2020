Public Class DatosObr
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
    Public NObrSis As Integer
    Public Padop As String
    Public TotP As String
    Public recs As Integer
    Public pRec As Integer
    Public FCASVal As Double
    Public ObrProp As String
    Public TObr As String
    Public pFCAS As String
    Public Admin As String
    Public Util As String
    Public IVA As String
    Public RndObr As String
    Public digRD As Integer
    Public digR As String
    Public cPart As String
    Public CSAnal As String
    Public DMat As String
    Public FBParAPO As String
    Public FBMatAPO As String
    Public FBEqpAPO As String
    Public FBMdOAPO As String
    Public FBTrnAPO As String
    Public FBParCIV As String
    Public FBMatCIV As String
    Public FBEqpCIV As String
    Public FBMdOCIV As String
    Public FBTrnCIV As String
    Public FBParLNG As String
    Public FBMatLNG As String
    Public FBEqpLNG As String
    Public FBMdOLNG As String
    Public FBTrnLNG As String
    Public DBParAPO As String
    Public DBMatAPO As String
    Public DBEqpAPO As String
    Public DBMdOAPO As String
    Public DBTrnAPO As String
    Public DBParCIV As String
    Public DBMatCIV As String
    Public DBEqpCIV As String
    Public DBMdOCIV As String
    Public DBTrnCIV As String
    Public DBParLNG As String
    Public DBMatLNG As String
    Public DBEqpLNG As String
    Public DBMdOLNG As String
    Public DBTrnLNG As String
    Public IFirma As String
    Public IRevisa As String
    Public NFirma As String
    Public NRevisa As String

    'Parametros Dataset
    Public ConStr As New OleDb.OleDbConnection
    Public DBProvider As String
    Public DBSource As String
    Public DBPath As String
    Public DBName As String

    'Dataset para Obras
    Public DSetObras As New DataSet
    Public DAObras As OleDb.OleDbDataAdapter
    Public cmdSQLObra As String

    Private Sub DatosObr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ObrasAPO.obras' table. You can move, or remove it, as needed.
        Me.ObrasTableAdapter.Fill(Me.ObrasAPO.obras)

        DBProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"
        DBPath = "C:\Users\jrozap\Documents\Steel Design Co\Analisis Precios Unitarios\APV 32-bit\APP2020.NET\APP2020\APP2020"
        DBName = "\MasterAPV.MDB"
        DBSource = "Data Source = " & DBPath & DBName
        ConStr.ConnectionString = DBProvider & DBSource
        ConStr.Open()

        cmdSQLObra = "SELECT * FROM obras ORDER BY [cod-obr]"
        DAObras = New OleDb.OleDbDataAdapter(cmdSQLObra, ConStr)
        DAObras.Fill(DSetObras, "obras")

        nRecords = ObrasAPO.Tables("obras").Rows.Count
        NObrSis = ObrasAPO.Tables("obras").Rows.Count - 1

        For idx = 0 To nRecords - 1
            CodObr = ObrasAPO.Tables("obras").Rows(idx).Item("cod-obr")
            ObrasCB.Items.Insert(idx, CodObr)
        Next
        ObrasCB.SelectedIndex = 0
    End Sub
    Private Sub ObrasCB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObrasCB.SelectedIndexChanged

        elem = ObrasCB.SelectedIndex
        CodObr = ObrasAPO.Tables("obras").Rows(elem).Item("cod-obr")
        If ObrasAPO.Tables("obras").Rows(elem).Item("desc-obr").Equals(DBNull.Value) Then
            DescObr.Text = ""
        Else
            DescObr.Text = CStr(ObrasAPO.Tables("obras").Rows(elem).Item(1))
        End If

        ObrProp = CStr(DSetObras.Tables("obras").Rows(elem).Item("Propietario"))
        TObr = CStr(DSetObras.Tables("obras").Rows(elem).Item("Obra"))
        pFCAS = CDbl(DSetObras.Tables("obras").Rows(elem).Item("FCAS")).ToString("#,##0.00;(#,##0.00);0.00")
        Admin = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Administracion")).ToString("#,##0.00;(#,##0.00);0.00")
        Util = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Utilidad")).ToString("#,##0.00;(#,##0.00);0.00")
        IVA = CDbl(DSetObras.Tables("obras").Rows(elem).Item("IVA")).ToString("#,##0.00;(#,##0.00);0.00")
        digRD = CInt(DSetObras.Tables("obras").Rows(elem).Item("Dig_Rend"))
        digR = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Dig_Rend")).ToString("#,##0;(#,##0);0")
        Select Case digRD
            Case Is = 1
                RndObr = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Rendimiento")).ToString("#,##0.0;(#,##0.0);0.0")
            Case Is = 2
                RndObr = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Rendimiento")).ToString("#,##0.00;(#,##0.00);0.00")
            Case Is = 3
                RndObr = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Rendimiento")).ToString("#,##0.000;(#,##0.000);0.000")
            Case Is = 4
                RndObr = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Rendimiento")).ToString("#,##0.0000;(#,##0.0000);0.0000")
            Case Is = 5
                RndObr = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Rendimiento")).ToString("#,##0.00000;(#,##0.00000);0.00000")
        End Select
        cPart = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Cant_Part")).ToString("#,##0.00;(#,##0.00);0.00")
        CSAnal = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Cant_Analisis")).ToString("#,##0.00;(#,##0.00);0.00")
        DMat = CStr(DSetObras.Tables("obras").Rows(elem).Item("Div_Mat"))
        FBParAPO = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBPRAPO")).ToString("dd/MM/yyyy")
        FBMatAPO = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMTAPO")).ToString("dd/MM/yyyy")
        FBEqpAPO = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBEQAPO")).ToString("dd/MM/yyyy")
        FBMdOAPO = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMOAPO")).ToString("dd/MM/yyyy")
        FBTrnAPO = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBTRAPO")).ToString("dd/MM/yyyy")
        FBParCIV = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBPRCIV")).ToString("dd/MM/yyyy")
        FBMatCIV = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMTCIV")).ToString("dd/MM/yyyy")
        FBEqpCIV = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBEQCIV")).ToString("dd/MM/yyyy")
        FBMdOCIV = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMOCIV")).ToString("dd/MM/yyyy")
        FBTrnCIV = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBTRCIV")).ToString("dd/MM/yyyy")
        FBParLNG = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBPRLulo")).ToString("dd/MM/yyyy")
        FBMatLNG = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMTLulo")).ToString("dd/MM/yyyy")
        FBEqpLNG = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBEQLulo")).ToString("dd/MM/yyyy")
        FBMdOLNG = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMOLulo")).ToString("dd/MM/yyyy")
        DBParAPO = CStr(DSetObras.Tables("obras").Rows(elem).Item("BasePRAPO"))
        DBMatAPO = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMTAPO"))
        DBEqpAPO = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseEQAPO"))
        DBMdOAPO = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMOAPO"))
        DBTrnAPO = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseTRAPO"))
        DBParCIV = CStr(DSetObras.Tables("obras").Rows(elem).Item("BasePRCIV"))
        DBMatCIV = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMTCIV"))
        DBEqpCIV = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseEQCIV"))
        DBMdOCIV = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMOCIV"))
        DBTrnCIV = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseTRCIV"))
        DBParLNG = CStr(DSetObras.Tables("obras").Rows(elem).Item("BasePRLulo"))
        DBMatLNG = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMTLulo"))
        DBEqpLNG = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseEQLulo"))
        DBMdOLNG = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMOLulo"))
        IFirma = CStr(DSetObras.Tables("obras").Rows(elem).Item("IngFirma"))
        NFirma = CDbl(DSetObras.Tables("obras").Rows(elem).Item("CIV_Firma")).ToString("#,##0;(#,##0);0")
        IRevisa = CStr(DSetObras.Tables("obras").Rows(elem).Item("IngRevisa"))
        NRevisa = CDbl(DSetObras.Tables("obras").Rows(elem).Item("CIV_Revisa")).ToString("#,##0;(#,##0);0")

        PropObr.Text = ObrProp
        TipoObra.Text = TObr
        FCAS.Text = pFCAS
        PAdm.Text = Admin
        PUtil.Text = Util
        pIVA.Text = IVA
        RendObr.Text = RndObr
        DigRend.Text = digR
        CantPart.Text = cPart
        CantSAnal.Text = CSAnal
        DivMat.Text = DMat
        FeBPRAPO.Text = FBParAPO
        FeBMTAPO.Text = FBMatAPO
        FeBEQAPO.Text = FBEqpAPO
        FeBMOAPO.Text = FBMdOAPO
        FeBTRAPO.Text = FBTrnAPO
        FeBPRCIV.Text = FBParCIV
        FeBMTCIV.Text = FBMatCIV
        FeBEQCIV.Text = FBEqpCIV
        FeBMOCIV.Text = FBMdOCIV
        FeBTRCIV.Text = FBTrnCIV
        FeBPRLulo.Text = FBParLNG
        FeBMTLulo.Text = FBMatLNG
        FeBEQLulo.Text = FBEqpLNG
        FeBMOLulo.Text = FBMdOLNG
        DscBPRAPO.Text = DBParAPO
        DscBMTAPO.Text = DBMatAPO
        DscBEQAPO.Text = DBEqpAPO
        DscBMOAPO.Text = DBMdOAPO
        DscBTRAPO.Text = DBTrnAPO
        DscBPRCIV.Text = DBParCIV
        DscBMTCIV.Text = DBMatCIV
        DscBEQCIV.Text = DBEqpCIV
        DscBMOCIV.Text = DBMdOCIV
        DscBTRCIV.Text = DBTrnCIV
        DscBPRLulo.Text = DBParLNG
        DscBMTLulo.Text = DBMatLNG
        DscBEQLulo.Text = DBEqpLNG
        DscBMOLulo.Text = DBMdOLNG
        IngFirmaObr.Text = IFirma
        CIVFirma.Text = NFirma
        IngRevision.Text = IRevisa
        CIVRevisa.Text = NRevisa

        If CStr(DSetObras.Tables("obras").Rows(elem).Item("Moneda_P")) = "Bs.S" Then
            Bolivar.Checked = True
        Else
            Bolivar.Checked = False
        End If
        If CStr(DSetObras.Tables("obras").Rows(elem).Item("Moneda_S")) = "USD" Then
            USDollar.Checked = True
        Else
            USDollar.Checked = False
        End If
    End Sub

    Private Sub ObrAnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObrAnt.Click
        If elem > 0 Then
            elem = elem - 1
        Else
            MessageBox.Show("No existen mas Obras en el Sistema")
        End If

        CodObr = ObrasAPO.Tables("obras").Rows(elem).Item("cod-obr")
        ObrasCB.Text = CodObr
        If ObrasAPO.Tables("obras").Rows(elem).Item("desc-obr").Equals(DBNull.Value) Then
            DescObr.Text = ""
        Else
            DescObr.Text = CStr(ObrasAPO.Tables("obras").Rows(elem).Item(1))
        End If

        ObrProp = CStr(DSetObras.Tables("obras").Rows(elem).Item("Propietario"))
        TObr = CStr(DSetObras.Tables("obras").Rows(elem).Item("Obra"))
        pFCAS = CDbl(DSetObras.Tables("obras").Rows(elem).Item("FCAS")).ToString("#,##0.00;(#,##0.00);0.00")
        Admin = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Administracion")).ToString("#,##0.00;(#,##0.00);0.00")
        Util = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Utilidad")).ToString("#,##0.00;(#,##0.00);0.00")
        IVA = CDbl(DSetObras.Tables("obras").Rows(elem).Item("IVA")).ToString("#,##0.00;(#,##0.00);0.00")
        digRD = CInt(DSetObras.Tables("obras").Rows(elem).Item("Dig_Rend"))
        digR = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Dig_Rend")).ToString("#,##0;(#,##0);0")
        Select Case digRD
            Case Is = 1
                RndObr = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Rendimiento")).ToString("#,##0.0;(#,##0.0);0.0")
            Case Is = 2
                RndObr = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Rendimiento")).ToString("#,##0.00;(#,##0.00);0.00")
            Case Is = 3
                RndObr = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Rendimiento")).ToString("#,##0.000;(#,##0.000);0.000")
            Case Is = 4
                RndObr = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Rendimiento")).ToString("#,##0.0000;(#,##0.0000);0.0000")
            Case Is = 5
                RndObr = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Rendimiento")).ToString("#,##0.00000;(#,##0.00000);0.00000")
        End Select
        cPart = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Cant_Part")).ToString("#,##0.00;(#,##0.00);0.00")
        CSAnal = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Cant_Analisis")).ToString("#,##0.00;(#,##0.00);0.00")
        DMat = CStr(DSetObras.Tables("obras").Rows(elem).Item("Div_Mat"))
        FBParAPO = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBPRAPO")).ToString("dd/MM/yyyy")
        FBMatAPO = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMTAPO")).ToString("dd/MM/yyyy")
        FBEqpAPO = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBEQAPO")).ToString("dd/MM/yyyy")
        FBMdOAPO = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMOAPO")).ToString("dd/MM/yyyy")
        FBTrnAPO = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBTRAPO")).ToString("dd/MM/yyyy")
        FBParCIV = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBPRCIV")).ToString("dd/MM/yyyy")
        FBMatCIV = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMTCIV")).ToString("dd/MM/yyyy")
        FBEqpCIV = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBEQCIV")).ToString("dd/MM/yyyy")
        FBMdOCIV = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMOCIV")).ToString("dd/MM/yyyy")
        FBTrnCIV = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBTRCIV")).ToString("dd/MM/yyyy")
        FBParLNG = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBPRLulo")).ToString("dd/MM/yyyy")
        FBMatLNG = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMTLulo")).ToString("dd/MM/yyyy")
        FBEqpLNG = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBEQLulo")).ToString("dd/MM/yyyy")
        FBMdOLNG = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMOLulo")).ToString("dd/MM/yyyy")
        DBParAPO = CStr(DSetObras.Tables("obras").Rows(elem).Item("BasePRAPO"))
        DBMatAPO = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMTAPO"))
        DBEqpAPO = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseEQAPO"))
        DBMdOAPO = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMOAPO"))
        DBTrnAPO = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseTRAPO"))
        DBParCIV = CStr(DSetObras.Tables("obras").Rows(elem).Item("BasePRCIV"))
        DBMatCIV = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMTCIV"))
        DBEqpCIV = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseEQCIV"))
        DBMdOCIV = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMOCIV"))
        DBTrnCIV = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseTRCIV"))
        DBParLNG = CStr(DSetObras.Tables("obras").Rows(elem).Item("BasePRLulo"))
        DBMatLNG = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMTLulo"))
        DBEqpLNG = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseEQLulo"))
        DBMdOLNG = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMOLulo"))
        IFirma = CStr(DSetObras.Tables("obras").Rows(elem).Item("IngFirma"))
        NFirma = CDbl(DSetObras.Tables("obras").Rows(elem).Item("CIV_Firma")).ToString("#,##0;(#,##0);0")
        IRevisa = CStr(DSetObras.Tables("obras").Rows(elem).Item("IngRevisa"))
        NRevisa = CDbl(DSetObras.Tables("obras").Rows(elem).Item("CIV_Revisa")).ToString("#,##0;(#,##0);0")

        PropObr.Text = ObrProp
        TipoObra.Text = TObr
        FCAS.Text = pFCAS
        PAdm.Text = Admin
        PUtil.Text = Util
        pIVA.Text = IVA
        RendObr.Text = RndObr
        DigRend.Text = digR
        CantPart.Text = cPart
        CantSAnal.Text = CSAnal
        DivMat.Text = DMat
        FeBPRAPO.Text = FBParAPO
        FeBMTAPO.Text = FBMatAPO
        FeBEQAPO.Text = FBEqpAPO
        FeBMOAPO.Text = FBMdOAPO
        FeBTRAPO.Text = FBTrnAPO
        FeBPRCIV.Text = FBParCIV
        FeBMTCIV.Text = FBMatCIV
        FeBEQCIV.Text = FBEqpCIV
        FeBMOCIV.Text = FBMdOCIV
        FeBTRCIV.Text = FBTrnCIV
        FeBPRLulo.Text = FBParLNG
        FeBMTLulo.Text = FBMatLNG
        FeBEQLulo.Text = FBEqpLNG
        FeBMOLulo.Text = FBMdOLNG
        DscBPRAPO.Text = DBParAPO
        DscBMTAPO.Text = DBMatAPO
        DscBEQAPO.Text = DBEqpAPO
        DscBMOAPO.Text = DBMdOAPO
        DscBTRAPO.Text = DBTrnAPO
        DscBPRCIV.Text = DBParCIV
        DscBMTCIV.Text = DBMatCIV
        DscBEQCIV.Text = DBEqpCIV
        DscBMOCIV.Text = DBMdOCIV
        DscBTRCIV.Text = DBTrnCIV
        DscBPRLulo.Text = DBParLNG
        DscBMTLulo.Text = DBMatLNG
        DscBEQLulo.Text = DBEqpLNG
        DscBMOLulo.Text = DBMdOLNG
        IngFirmaObr.Text = IFirma
        CIVFirma.Text = NFirma
        IngRevision.Text = IRevisa
        CIVRevisa.Text = NRevisa

        If CStr(DSetObras.Tables("obras").Rows(elem).Item("Moneda_P")) = "Bs.S" Then
            Bolivar.Checked = True
        Else
            Bolivar.Checked = False
        End If
        If CStr(DSetObras.Tables("obras").Rows(elem).Item("Moneda_S")) = "USD" Then
            USDollar.Checked = True
        Else
            USDollar.Checked = False
        End If
    End Sub

    Private Sub ObrSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObrSig.Click
        Dim lastObr As Boolean

        If elem < NObrSis Then
            lastObr = False
            elem = elem + 1
        Else
            MessageBox.Show("No existen mas Obras en el Sistema")
            lastObr = True
        End If

        If Not lastObr Then
            CodObr = ObrasAPO.Tables("obras").Rows(elem).Item("cod-obr")
            ObrasCB.Text = CodObr
            If ObrasAPO.Tables("obras").Rows(elem).Item("desc-obr").Equals(DBNull.Value) Then
                DescObr.Text = ""
            Else
                DescObr.Text = CStr(ObrasAPO.Tables("obras").Rows(elem).Item(1))
            End If

            ObrProp = CStr(DSetObras.Tables("obras").Rows(elem).Item("Propietario"))
            TObr = CStr(DSetObras.Tables("obras").Rows(elem).Item("Obra"))
            pFCAS = CDbl(DSetObras.Tables("obras").Rows(elem).Item("FCAS")).ToString("#,##0.00;(#,##0.00);0.00")
            Admin = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Administracion")).ToString("#,##0.00;(#,##0.00);0.00")
            Util = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Utilidad")).ToString("#,##0.00;(#,##0.00);0.00")
            IVA = CDbl(DSetObras.Tables("obras").Rows(elem).Item("IVA")).ToString("#,##0.00;(#,##0.00);0.00")
            digRD = CInt(DSetObras.Tables("obras").Rows(elem).Item("Dig_Rend"))
            digR = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Dig_Rend")).ToString("#,##0;(#,##0);0")
            Select Case digRD
                Case Is = 1
                    RndObr = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Rendimiento")).ToString("#,##0.0;(#,##0.0);0.0")
                Case Is = 2
                    RndObr = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Rendimiento")).ToString("#,##0.00;(#,##0.00);0.00")
                Case Is = 3
                    RndObr = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Rendimiento")).ToString("#,##0.000;(#,##0.000);0.000")
                Case Is = 4
                    RndObr = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Rendimiento")).ToString("#,##0.0000;(#,##0.0000);0.0000")
                Case Is = 5
                    RndObr = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Rendimiento")).ToString("#,##0.00000;(#,##0.00000);0.00000")
            End Select
            cPart = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Cant_Part")).ToString("#,##0.00;(#,##0.00);0.00")
            CSAnal = CDbl(DSetObras.Tables("obras").Rows(elem).Item("Cant_Analisis")).ToString("#,##0.00;(#,##0.00);0.00")
            DMat = CStr(DSetObras.Tables("obras").Rows(elem).Item("Div_Mat"))
            FBParAPO = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBPRAPO")).ToString("dd/MM/yyyy")
            FBMatAPO = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMTAPO")).ToString("dd/MM/yyyy")
            FBEqpAPO = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBEQAPO")).ToString("dd/MM/yyyy")
            FBMdOAPO = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMOAPO")).ToString("dd/MM/yyyy")
            FBTrnAPO = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBTRAPO")).ToString("dd/MM/yyyy")
            FBParCIV = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBPRCIV")).ToString("dd/MM/yyyy")
            FBMatCIV = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMTCIV")).ToString("dd/MM/yyyy")
            FBEqpCIV = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBEQCIV")).ToString("dd/MM/yyyy")
            FBMdOCIV = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMOCIV")).ToString("dd/MM/yyyy")
            FBTrnCIV = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBTRCIV")).ToString("dd/MM/yyyy")
            FBParLNG = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBPRLulo")).ToString("dd/MM/yyyy")
            FBMatLNG = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMTLulo")).ToString("dd/MM/yyyy")
            FBEqpLNG = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBEQLulo")).ToString("dd/MM/yyyy")
            FBMdOLNG = CDate(DSetObras.Tables("obras").Rows(elem).Item("FecBMOLulo")).ToString("dd/MM/yyyy")
            DBParAPO = CStr(DSetObras.Tables("obras").Rows(elem).Item("BasePRAPO"))
            DBMatAPO = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMTAPO"))
            DBEqpAPO = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseEQAPO"))
            DBMdOAPO = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMOAPO"))
            DBTrnAPO = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseTRAPO"))
            DBParCIV = CStr(DSetObras.Tables("obras").Rows(elem).Item("BasePRCIV"))
            DBMatCIV = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMTCIV"))
            DBEqpCIV = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseEQCIV"))
            DBMdOCIV = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMOCIV"))
            DBTrnCIV = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseTRCIV"))
            DBParLNG = CStr(DSetObras.Tables("obras").Rows(elem).Item("BasePRLulo"))
            DBMatLNG = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMTLulo"))
            DBEqpLNG = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseEQLulo"))
            DBMdOLNG = CStr(DSetObras.Tables("obras").Rows(elem).Item("BaseMOLulo"))
            IFirma = CStr(DSetObras.Tables("obras").Rows(elem).Item("IngFirma"))
            NFirma = CDbl(DSetObras.Tables("obras").Rows(elem).Item("CIV_Firma")).ToString("#,##0;(#,##0);0")
            IRevisa = CStr(DSetObras.Tables("obras").Rows(elem).Item("IngRevisa"))
            NRevisa = CDbl(DSetObras.Tables("obras").Rows(elem).Item("CIV_Revisa")).ToString("#,##0;(#,##0);0")

            PropObr.Text = ObrProp
            TipoObra.Text = TObr
            FCAS.Text = pFCAS
            PAdm.Text = Admin
            PUtil.Text = Util
            pIVA.Text = IVA
            RendObr.Text = RndObr
            DigRend.Text = digR
            CantPart.Text = cPart
            CantSAnal.Text = CSAnal
            DivMat.Text = DMat
            FeBPRAPO.Text = FBParAPO
            FeBMTAPO.Text = FBMatAPO
            FeBEQAPO.Text = FBEqpAPO
            FeBMOAPO.Text = FBMdOAPO
            FeBTRAPO.Text = FBTrnAPO
            FeBPRCIV.Text = FBParCIV
            FeBMTCIV.Text = FBMatCIV
            FeBEQCIV.Text = FBEqpCIV
            FeBMOCIV.Text = FBMdOCIV
            FeBTRCIV.Text = FBTrnCIV
            FeBPRLulo.Text = FBParLNG
            FeBMTLulo.Text = FBMatLNG
            FeBEQLulo.Text = FBEqpLNG
            FeBMOLulo.Text = FBMdOLNG
            DscBPRAPO.Text = DBParAPO
            DscBMTAPO.Text = DBMatAPO
            DscBEQAPO.Text = DBEqpAPO
            DscBMOAPO.Text = DBMdOAPO
            DscBTRAPO.Text = DBTrnAPO
            DscBPRCIV.Text = DBParCIV
            DscBMTCIV.Text = DBMatCIV
            DscBEQCIV.Text = DBEqpCIV
            DscBMOCIV.Text = DBMdOCIV
            DscBTRCIV.Text = DBTrnCIV
            DscBPRLulo.Text = DBParLNG
            DscBMTLulo.Text = DBMatLNG
            DscBEQLulo.Text = DBEqpLNG
            DscBMOLulo.Text = DBMdOLNG
            IngFirmaObr.Text = IFirma
            CIVFirma.Text = NFirma
            IngRevision.Text = IRevisa
            CIVRevisa.Text = NRevisa

            If CStr(DSetObras.Tables("obras").Rows(elem).Item("Moneda_P")) = "Bs.S" Then
                Bolivar.Checked = True
            Else
                Bolivar.Checked = False
            End If
            If CStr(DSetObras.Tables("obras").Rows(elem).Item("Moneda_S")) = "USD" Then
                USDollar.Checked = True
            Else
                USDollar.Checked = False
            End If
        End If
    End Sub
End Class
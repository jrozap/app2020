Option Explicit On
Module init_Module
    '-------------------------------------------------------------------------------------------------------------------------------'
    '    Component        :  init_module
    '    Project          :  APVWIN2020
    '
    '    Description      :  Modulo inicial del APP2020
    '    Owner            :  JR Sistemas24, Co.
    '    Programmed by    :  Ing. Jaime Manuel Roza Pedreira
    '
    '    Modified         :  20/04/2020
    '--------------------------------------------------------------------------------------------------------------------------------'

    Public Const DB_Path As String = "D:\Documentos Jroza\Documents\JR Sistemas\Desarrollo Software\Proyecto APVWIN2017 IMACA\DB APVWIN Ver 10.1.001"

    Public PrevProc As Long
    Public lArray() As String
    Public work_Obr As String
    Public folder As String
    Public connection_Str As String
    Public file_Str As String
    Public file_type_F As String
    Public Unit As String
    Public BD_file_T As String
    Public BD_Config_APV As String
    Public BD_file_STR As String
    Public DB_config_Query As String
    Public DB_mdb_File As String

    Public baseMaterialUse As String
    Public baseEquiposUse As String
    Public baseManoObraUse As String
    Public basePartidasUse As String
    Public FechaMATB As Date
    Public FechaEQPB As Date
    Public FechaMOB As Date
    Public FechaPARTB As Date
    Public monedaP As String
    Public monedaS As String

    Public Const TheZeroMask = "000-00-0000"           'The mask numbers frmFind
    Public Const TheMask = "###-##-####"               'The mask numbers frmFind

    Public MyOrderBYSQL As String
    Public SaveTheActualPosition As Integer
    Public pAdmin As Double
    Public pUtil As Double
    Public pIVA As Double
    Public pFCAS As Double
    Public lastPart As Integer
    Public cod_Obra As String
    Public file_Source As String
    Public file_Target As String

    Public total_MO_General As Double
    Public total_Material_G As Double
    Public total_Transporte_G As Double
    Public total_Equipos_G As Double
    Public CodEqpA As String

    Public Sub main()
        Dim Scoope As String

        Scoope = " 'Generales'"
        DB_config_Query = "SELECT * FROM ConfGenAPV WHERE Obra='GENERAL'"
        DB_mdb_File = DB_Path + "\DB Master Tables APV\MasterAPV.mdb"
        APP2020Is.Show()
        APP2020Mp.Show()
    End Sub
End Module

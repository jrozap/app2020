Public Class ActValObr
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click

    End Sub

    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub ActValObr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MasterAPVDataSet.Valuaciones' table. You can move, or remove it, as needed.
        Me.ValuacionesTableAdapter.Fill(Me.MasterAPVDataSet.Valuaciones)
        Dim archivo As String 'Declaramos una variable de tipo String para definir la ruta al archivo

        archivo = "C:\Users\jrozap\Documents\Steel Design Co\Analisis Precios Unitarios\DB APVWIN Ver 10.1.001\Excel" & "\Valuacion.xlsx" 'Asignamos la ruta
    End Sub

End Class
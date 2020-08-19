Public Class ActListMO

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MasterAPVDataSet1.MasterManoObra' table. You can move, or remove it, as needed.
        Me.MasterManoObraTableAdapter.Fill(Me.MasterAPVDataSet1.MasterManoObra)

    End Sub
End Class
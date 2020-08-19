Public Class ActMMat

    Private Sub ActMMat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MasterAPVDataSet3.MasterMaterial' table. You can move, or remove it, as needed.
        Me.MasterMaterialTableAdapter.Fill(Me.MasterAPVDataSet3.MasterMaterial)

    End Sub
End Class
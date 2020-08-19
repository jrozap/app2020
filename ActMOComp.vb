Public Class ActMOComp

    Private Sub ActMOComp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MasterAPVDataSet2.MObraC' table. You can move, or remove it, as needed.
        Me.MObraCTableAdapter.Fill(Me.MasterAPVDataSet2.MObraC)

    End Sub
End Class
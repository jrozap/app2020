Public Class ChkPrcIn

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MasterAPVDataSet6.APUObr' table. You can move, or remove it, as needed.
        Me.MatDatosOTableAdapter1.Fill(Me.DataSet7.MatDatosO)
        'TODO: This line of code loads data into the 'MasterAPVDataSet.APUObr' table. You can move, or remove it, as needed.
        Me.EqpDtosOTableAdapter1.Fill(Me.DataSet8.EqpDtosO)
        'TODO: This line of code loads data into the 'MasterAPVDataSet.APUObr' table. You can move, or remove it, as needed.
        Me.MdODatosOTableAdapter1.Fill(Me.DataSet9.MdODatosO)
        'TODO: This line of code loads data into the 'MasterAPVDataSet.APUObr' table. You can move, or remove it, as needed.
        Me.TranspDatosOTableAdapter1.Fill(Me.DataSet10.TranspDatosO)

    End Sub

    Private Sub APUObrBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
Public Class IndicesPAC
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        RadioButton2.Checked = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        RadioButton1.Checked = False
    End Sub

    Private Sub IndicesPAC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MasterAPVDataSet4.IndPAC' table. You can move, or remove it, as needed.
        Me.IndPACTableAdapter.Fill(Me.MasterAPVDataSet4.IndPAC)

        RadioButton1.Capture = True
        RadioButton1.Checked = True

        IPACy.Text = CStr(MasterAPVDataSet4.IndPAC.Rows(1).Item("AÑO"))
    End Sub
End Class
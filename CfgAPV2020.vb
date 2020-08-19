Public Class CfgAPP2020

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        PictureBox4.Visible = False
        PictureBox3.Visible = True
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        PictureBox3.Visible = False
        PictureBox4.Visible = True
    End Sub

    Private Sub CheckBox8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox8.CheckedChanged
        If CheckBox8.Checked = True Then
            Panel10.Visible = False
        Else
            Panel10.Visible = True
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fecha_act As Date
        Dim mes_act As String

        fecha_act = Today()
        mes_act = Mid(CStr(fecha_act), 4, 1)
        Select Case mes_act
            Case Is = "1"
                Mes_ProcM.Text = "Enero"
            Case Is = "2"
                Mes_ProcM.Text = "Febrero"
            Case Is = "3"
                Mes_ProcM.Text = "Marzo"
            Case Is = "4"
                Mes_ProcM.Text = "Abril"
            Case Is = "5"
                Mes_ProcM.Text = "Mayo"
            Case Is = "6"
                Mes_ProcM.Text = "Junio"
            Case Is = "7"
                Mes_ProcM.Text = "Julio"
            Case Is = "8"
                Mes_ProcM.Text = "Agosto"
            Case Is = "9"
                Mes_ProcM.Text = "Septiembre"
            Case Is = "10"
                Mes_ProcM.Text = "Octubre"
            Case Is = "11"
                Mes_ProcM.Text = "Noviembre"
            Case Is = "12"
                Mes_ProcM.Text = "Diciembre"
        End Select
        CheckBox8.Checked = False
    End Sub

    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click

    End Sub

    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBPaths.Click

    End Sub

    Private Sub Panel20_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel20.Paint

    End Sub

    Private Sub Panel18_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel18.Paint

    End Sub
End Class
Public NotInheritable Class APP2020Is
    Public Time_count As Integer
    Const INTERVALO_EN_MINUTOS As Integer = 1

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub APP2020Is_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).
        Timer1.Interval = 60
        Timer1.Enabled = True
        Time_count = 0
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ' variable estática para acumular la cantidad de segundos
        Static Temp_Seg As Long
        ' incrementa
        Temp_Seg = Temp_Seg + 1
        ' comprueba que los segundos no sea igual a la cantidad de minutos que queremos , en este caso 5 minutos
        If (Temp_Seg * 60) >= (INTERVALO_EN_MINUTOS * 60) * 60 Then
            ' reestablece
            Timer1.Enabled = False
            APP2020Mp.Show()
        End If
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
End Class
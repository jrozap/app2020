Partial Class MaterialPU
    Partial Class MatPUDataTable

        Private Sub MatPUDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DescripcionColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

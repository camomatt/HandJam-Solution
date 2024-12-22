Public Class DeckExportSettings
    Private Sub ExportButton_Click(sender As Object, e As EventArgs) Handles ExportButton.Click
        If NameTextBox.TextLength = 0 Then
            MessageBox.Show("No deck name specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        ElseIf RowsNumericUpDown.Value = vbEmpty Then
            MessageBox.Show("Invalid row value. There must be at least 2 rows and no more than 7 rows.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        ElseIf ColumnsNumericUpDown.Value = vbEmpty Then
            MessageBox.Show("Invalid column value. There must be at least 2 columns and no more than 7 columns.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            DialogResult = DialogResult.OK
            Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Show Advanced" Then
            DeckSettingsGroupBox.Height = 1144
            Height *= 2

            Dim p As New Point With {
                .X = ExportButton.Location.X,
                .Y = DeckSettingsGroupBox.Location.Y + DeckSettingsGroupBox.Height + 6
            }
            ExportButton.Location = p

            Button1.Text = "Hide Advanced"
        Else
            DeckSettingsGroupBox.Height = 18
            Height /= 2

            Dim p As New Point With {
                .X = ExportButton.Location.X,
                .Y = DeckSettingsGroupBox.Location.Y + DeckSettingsGroupBox.Height + 6
            }
            ExportButton.Location = p

            Button1.Text = "Show Advanced"
        End If
    End Sub
End Class
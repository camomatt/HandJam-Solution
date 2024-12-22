Public Class FileNameFormatter
    Dim setget As SettersAndGetters = Form1.setget
    Private Sub FileNameFormatter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim colLen As Integer = setget.RPControls.GetUpperBound(1)
        For i As Integer = 0 To colLen - 1
            ComboBox1.Items.Add(setget.RPControls(0, i))
        Next
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If clicked, do stuff then close
        Close()
    End Sub
End Class
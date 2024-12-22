Public Class CardProperties
    Private Sub CardProperties_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.setget.CardProperties(0) <> Nothing Then WidthNumericUpDown.Value = Form1.setget.CardProperties(0)
        If Form1.setget.CardProperties(1) <> Nothing Then HeightNumericUpDown.Value = Form1.setget.CardProperties(1)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub
End Class
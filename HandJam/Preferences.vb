Option Strict On
Option Explicit On

Public Class Preferences
    Private Sub Preferences_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim filepath As String = My.Computer.FileSystem.CurrentDirectory & "\preferences.ini"
        Dim fileContents As String = My.Computer.FileSystem.ReadAllText(filepath)
        Dim searchTerms As String() = {"""w"": ", """h"": "}
        Dim values As String() = {String.Empty}

        For Each s In searchTerms
            Dim searchIndex As Integer = fileContents.IndexOf(s)
            If searchIndex = -1 Then
                '("Preferences file was not found. Default values will be set.")
                Return
            End If
            Dim searchStartIndex As Integer = searchIndex + s.Length
            Dim searchEndIndex1 As Integer = fileContents.IndexOf(","c, searchIndex)
            Dim searchEndIndex2 As Integer = fileContents.IndexOf(vbCrLf, searchIndex)
            If searchEndIndex2 > 0 And searchEndIndex1 > searchEndIndex2 Then
                searchEndIndex1 = searchEndIndex2
            End If
            Dim substring As String = fileContents.Substring(searchStartIndex, searchEndIndex1 - searchStartIndex)
            values(values.Length - 1) = substring
            ReDim Preserve values(values.Length)
        Next

        WindowWidthNumericUpDown.Value = CType(values(0), Integer)
        WindowHeightNumericUpDown.Value = CType(values(1), Integer)

    End Sub
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim filepath As String = My.Computer.FileSystem.CurrentDirectory & "\preferences.ini"
        Dim fileContents As String = "{" & vbNewLine &
            vbTab & """General"": [" & vbNewLine &
            vbTab & vbTab & """Window Size"": {" & vbNewLine &
            vbTab & vbTab & vbTab & """w"": " & WindowWidthNumericUpDown.Value.ToString & "," & vbNewLine &
            vbTab & vbTab & vbTab & """h"": " & WindowHeightNumericUpDown.Value.ToString & vbNewLine &
            vbTab & vbTab & "}" & vbNewLine &
            vbTab & "]," & vbNewLine & vbTab & """Locations"": [" & vbNewLine &
            vbTab & vbTab & vbNewLine &
            vbTab & "]" & vbNewLine &
            "}"
        My.Computer.FileSystem.WriteAllText(filepath, fileContents, False)
        Close()
    End Sub

    Private Sub AutoFillButton_Click(sender As Object, e As EventArgs) Handles AutoFillButton.Click
        WindowWidthNumericUpDown.Value = Form1.Width
        WindowHeightNumericUpDown.Value = Form1.Height
    End Sub

    '=======================
    '====== SUB/FUNC =======
    '=======================

End Class
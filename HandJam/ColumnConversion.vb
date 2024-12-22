Public Class ColumnConversion
    Dim setget As SettersAndGetters = Form1.setget

    Private Sub ColumnConversion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ImportedColumnsListBox.Items.AddRange(setget._ImportHeaders)

        'Probably want to change it from scanning the DataGridView to scanning the RPControls
        FillExistingColumnsListBox()
    End Sub

    Private Sub AddExistingColumnButton_Click(sender As Object, e As EventArgs) Handles AddExistingColumnButton.Click
        Form1.AddControlButton_Click(sender, e)
        FillExistingColumnsListBox()
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        'If clicked, do stuff then close
        Close()
    End Sub

    Private Sub FillExistingColumnsListBox()
        'Empty the box first
        EmptyExistingColumnsListBox()

        Dim colLen As Integer = setget.RPControls.GetUpperBound(1)
        For i As Integer = 0 To colLen - 1
            ExistingColumnsListBox.Items.Add(setget.RPControls(0, i))
        Next

        'Whenever box is filled, check to see if there are greater than or equal columns
        'if so, enable button ok
        If ExistingColumnsListBox.Items.Count >= ImportedColumnsListBox.Items.Count Then
            OKButton.Enabled = True
        End If
    End Sub

    Private Sub EmptyExistingColumnsListBox()
        For i As Integer = ExistingColumnsListBox.Items.Count To 1 Step -1
            ExistingColumnsListBox.Items.RemoveAt(i - 1)
        Next
    End Sub

    Private Sub AddImportedColumnButton_Click(sender As Object, e As EventArgs) Handles AddImportedColumnButton.Click
        Dim name As String = InputBox("Enter a name for the new column: ", "New Column")

        'If an item is selected, add to the box at the selected index
        If ImportedColumnsListBox.SelectedIndex > -1 Then
            ImportedColumnsListBox.Items.Insert(ImportedColumnsListBox.SelectedIndex, name)
        Else
            ImportedColumnsListBox.Items.Add(name)
        End If
    End Sub

    Private Sub RemoveImportedColumnButton_Click(sender As Object, e As EventArgs) Handles RemoveImportedColumnButton.Click
        If ImportedColumnsListBox.SelectedIndex > -1 Then
            ImportedColumnsListBox.Items.RemoveAt(ImportedColumnsListBox.SelectedIndex)
        End If
    End Sub

    Private Sub MoveUpImportedColumnButton_Click(sender As Object, e As EventArgs) Handles MoveUpImportedColumnButton.Click
        Dim index As Integer = ImportedColumnsListBox.SelectedIndex
        Dim temp As Object

        If index - 1 > -1 Then
            temp = ImportedColumnsListBox.Items(index - 1)
            ImportedColumnsListBox.Items(index - 1) = ImportedColumnsListBox.Items(index)
            ImportedColumnsListBox.Items(index) = temp
            ImportedColumnsListBox.SelectedIndex = ImportedColumnsListBox.SelectedIndex - 1
        End If
    End Sub

    Private Sub MoveDownImportedColumnButton_Click(sender As Object, e As EventArgs) Handles MoveDownImportedColumnButton.Click
        Dim index As Integer = ImportedColumnsListBox.SelectedIndex
        Dim temp As Object

        If index > -1 And index < ImportedColumnsListBox.Items.Count - 1 Then
            temp = ImportedColumnsListBox.Items(index)
            ImportedColumnsListBox.Items(index) = ImportedColumnsListBox.Items(index + 1)
            ImportedColumnsListBox.Items(index + 1) = temp
            ImportedColumnsListBox.SelectedIndex = ImportedColumnsListBox.SelectedIndex + 1
        End If
    End Sub

    Private Sub RemoveExistingColumnButton_Click(sender As Object, e As EventArgs) Handles RemoveExistingColumnButton.Click
        If ExistingColumnsListBox.SelectedIndex > -1 Then
            Form1.RemoveControl(ExistingColumnsListBox.SelectedIndex)
            FillExistingColumnsListBox()
        End If
    End Sub

    Private Sub MoveUpExistingColumnButton_Click(sender As Object, e As EventArgs) Handles MoveUpExistingColumnButton.Click
        Dim index As Integer = ExistingColumnsListBox.SelectedIndex
        If index - 1 > -1 Then
            Form1.TableLayoutPanelMoveRow(Form1.ControlsTableLayoutPanel, ExistingColumnsListBox.SelectedIndex - 1)
            FillExistingColumnsListBox()
        End If
    End Sub

    Private Sub MoveDownExistingColumnButton_Click(sender As Object, e As EventArgs) Handles MoveDownExistingColumnButton.Click
        Dim index As Integer = ExistingColumnsListBox.SelectedIndex
        If index > -1 And index < ExistingColumnsListBox.Items.Count - 1 Then
            Form1.TableLayoutPanelMoveRow(Form1.ControlsTableLayoutPanel, ExistingColumnsListBox.SelectedIndex)
            FillExistingColumnsListBox()
        End If
    End Sub
End Class
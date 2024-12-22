Option Explicit On
Option Strict On

Public Class Conditions
    '===================
    '=== GLOBAL VARS ===
    '===================
    Dim subsAndFuncs As New SharedSubsAndFuncs
    Dim setget As SettersAndGetters = Form1.setget

    Private Sub Conditions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set default value for OperatorsComboBox
        OperatorComboBox.SelectedIndex = 0

        'Get a list of labels
        'new function in sharedsubsandfunctions
        Dim labelColl As Object() = subsAndFuncs.GetListOfStrings(setget)

        Value1ControlComboBox.Items.AddRange(labelColl)
        'Value2ControlComboBox.Items.AddRange(labelColl)
        TargetControlComboBox.Items.AddRange(labelColl)
        'SourceControlComboBox.Items.AddRange(labelColl)

        'Load conditions from the conditions setget (to-do)
        Dim conditionsRows As Integer = setget.Conditions.GetUpperBound(1)
        If conditionsRows < 1 Then Return

        For i As Integer = 0 To conditionsRows - 1
            ConditionsDataGridView.Rows.Add()
            For j As Integer = 0 To 8
                ConditionsDataGridView.Rows(i).Cells(j).Value = setget.Conditions(j, i).ToString
            Next
        Next
    End Sub

    Private Sub Value1ControlComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Value1ControlComboBox.SelectedIndexChanged
        FillComboBoxes(Value1ControlComboBox, Value1AttributeComboBox)
    End Sub

    Private Sub Value2ControlComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Value2ControlComboBox.SelectedIndexChanged
        FillComboBoxes(Value2ControlComboBox, Value2AttributeComboBox)
    End Sub

    Private Sub Value2RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles Value2ControlRadioButton.CheckedChanged, Value2StaticRadioButton.CheckedChanged
        ChangeComboBoxes(Value2ControlComboBox, Value2AttributeComboBox, Value2ControlRadioButton)
    End Sub

    Private Sub TargetControlComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TargetControlComboBox.SelectedIndexChanged
        FillComboBoxes(TargetControlComboBox, TargetAttributeComboBox)
    End Sub

    Private Sub SourceRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles SourceControlRadioButton.CheckedChanged, SourceStaticRadioButton.CheckedChanged
        ChangeComboBoxes(SourceControlComboBox, SourceAttributeComboBox, SourceControlRadioButton)
    End Sub

    Private Sub SourceControlComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SourceControlComboBox.SelectedIndexChanged
        FillComboBoxes(SourceControlComboBox, SourceAttributeComboBox)
    End Sub

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        'Various conditions need to be met for the AddButton to function, including... (to-do)
        'Value1 + Attribute has a selection
        'Target + Attribute has a selection
        'If Value2 is Control, must have a selection
        'If Source is Control, must have a selection

        'This can allow modular implementation of additional comboboxes. Requires comboboxes to be renamed and matched to datagridview headers (to-do)
        'Dim ind As Integer = 0
        'For Each c In ParametersGroupBox.Controls
        '    If c.GetType() = GetType(ComboBox) Then
        '        ReDim Preserve stringArr(ind + 1)
        '        stringArr(ind) = CType(c, ComboBox).Text
        '        ind += 1
        '    End If
        'Next

        Dim row As Object()
        ReDim row(ConditionsDataGridView.Columns.Count)
        Dim value2Att, sourceAtt As String

        If Value2ControlRadioButton.Checked = True Then
            value2Att = Value2AttributeComboBox.Text
        Else
            value2Att = String.Empty
        End If

        If SourceControlRadioButton.Checked = True Then
            sourceAtt = SourceAttributeComboBox.Text
        Else
            sourceAtt = String.Empty
        End If

        Dim strArray As String() = {
            Value1ControlComboBox.Text,
            Value1AttributeComboBox.Text,
            OperatorComboBox.Text,
            Value2ControlComboBox.Text,
            value2Att,
            TargetControlComboBox.Text,
            TargetAttributeComboBox.Text,
            SourceControlComboBox.Text,
            sourceAtt
            }

        Dim i As Integer = 0
        For Each s In strArray
            row(i) = s
            i += 1
        Next

        ConditionsDataGridView.Rows.Add(strArray)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub FillComboBoxes(mainCb As ComboBox, attCb As ComboBox)
        'Empty the attribute box before doing anything. This can be optimized later by comparing the previous type to the newly selected type (to-do)
        attCb.Items.Clear()

        'Fill the attribute box if a value is selected in Value1ControlComboBox
        If mainCb.Text <> String.Empty Then
            'Find the associated type based on the label from the setget
            Dim colCount As Integer = setget.RPControls.GetUpperBound(1)
            For r As Integer = 0 To colCount - 1
                If setget.RPControls(0, r).ToString.ToLower = mainCb.Text.ToLower Then
                    attCb.Items.Add("value")
                    attCb.Items.AddRange(subsAndFuncs.GetListOfAttributesByType(setget.RPControls(1, r).ToString.ToLower))
                    r = colCount 'leave the for loop
                End If
            Next

            If attCb.Items.Count < 1 Then
                MessageBox.Show("Unable to find attributes for selected label.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                attCb.Items.Clear()
            End If
        Else
            attCb.Items.Clear()
        End If
    End Sub

    Private Sub ChangeComboBoxes(mainCb As ComboBox, attCb As ComboBox, contRb As RadioButton)
        If contRb.Checked = True Then
            'If control, set DropDownList for Value2ControlComboBox AND enable Value2AttributeComboBox AND refill the box. Maybe remove the clear (to-do)
            mainCb.Items.Clear()
            mainCb.Items.AddRange(subsAndFuncs.GetListOfStrings(setget))
            mainCb.DropDownStyle = ComboBoxStyle.DropDownList
        Else
            'If static, set DropDown for Value2ControlComboBox AND disable Value2AttributeComboBox AND clear the box AND clear the attribute box
            mainCb.Items.Clear()
            attCb.Items.Clear()
            mainCb.DropDownStyle = ComboBoxStyle.DropDown
        End If
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        ConditionsDataGridView.Rows.Remove(ConditionsDataGridView.SelectedRows(0))
    End Sub
End Class
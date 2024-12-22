Option Strict On
Option Explicit On

Public Class AddObjectForm
    '===================
    '=== GLOBAL VARS ===
    '===================
    'Dim setget As New SettersAndGetters
    Dim subsAndFuncs As New SharedSubsAndFuncs

    '======================
    '====== ON LOAD =======
    '======================

    Private Sub AddControlForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Select()
        ImageRadioButton_CheckedChanged(sender, e)
        If directoryTextBox.Text <> String.Empty Then
            PopulateDefaultImageComboBox()
        End If
        Height = Form1.Height

        'populate alignment
        If AlignmentComboBox.Text = String.Empty Then
            AlignmentComboBox.SelectedIndex = 0
        End If
    End Sub

    '=======================
    '====== CONTROLS =======
    '=======================
    ' OBJECT TYPE GROUPBOX
    '----------------------
    Private Sub TextRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles TextRadioButton.CheckedChanged
        If TextRadioButton.Checked = True Then
            Button1.Enabled = True
            TextDetailsGroupBox.Enabled = True
            DetectSizeCheckBox.Checked = False
            DetectSizeCheckBox.Enabled = False
        Else
            TextDetailsGroupBox.Enabled = False
        End If
    End Sub
    Private Sub ImageRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles ImageRadioButton.CheckedChanged
        If ImageRadioButton.Checked = True Then
            If directoryTextBox.Text <> String.Empty Then
                Button1.Enabled = True
            Else
                Button1.Enabled = False
            End If

            SelectableGroupBox.Enabled = True
            DetectSizeCheckBox.Enabled = True
            ImageGroupBox.Enabled = True
        Else
            SelectableGroupBox.Enabled = False
            ImageGroupBox.Enabled = False
        End If
        YesRadioButton_CheckedChanged(sender, e)
    End Sub
    Private Sub ShapeRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles ShapeRadioButton.CheckedChanged
        If ShapeRadioButton.Checked = True Then
            ShapeGroupBox.Enabled = True
            DetectSizeCheckBox.Checked = False
            DetectSizeCheckBox.Enabled = False
        Else
            ShapeGroupBox.Enabled = False
        End If
    End Sub

    ' SELECTABLE GROUPBOX
    '--------------------
    Private Sub YesRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles YesRadioButton.CheckedChanged
        'Button1.Enabled = False
        'directoryTextBox.Text = String.Empty
        If YesRadioButton.Checked = True Then
            ImageGroupBox.Text = "Image Details"
            SubfoldersCheckBox.Enabled = True
        Else
            ImageGroupBox.Text = "Image File"
        End If
    End Sub
    Private Sub NoRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles NoRadioButton.CheckedChanged
        Button1.Enabled = False
        'directoryTextBox.Text = String.Empty
        If NoRadioButton.Checked = True Then
            ImageGroupBox.Text = "Image"
            SubfoldersCheckBox.Enabled = False
        End If
    End Sub

    ' TEXT DETAILS GROUPBOX
    '-----------------------
    Private Sub MultilineCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles MultilineCheckBox.CheckedChanged
        If MultilineCheckBox.Checked = True Then
            MultlineNumericUpDown.Enabled = True
        Else
            MultlineNumericUpDown.Enabled = False
        End If
    End Sub
    Private Sub MainFontButton_Click(sender As Object, e As EventArgs) Handles MainFontButton.Click
        FontDialog1.ShowDialog()
        MainFontTextBox.Text = FontDialog1.Font.ToString
    End Sub
    Private Sub MainColorButton_Click(sender As Object, e As EventArgs) Handles MainColorButton.Click
        MainFontColorDialog.ShowDialog()
        MainColorTextBox.Text = MainFontColorDialog.Color.ToString
    End Sub
    Private Sub ShadowCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ShadowCheckBox.CheckedChanged
        If ShadowCheckBox.Checked = True Then
            ShadowGroupBox.Enabled = True
        Else
            ShadowGroupBox.Enabled = False
        End If
    End Sub
    Private Sub ShadowColorButton_Click(sender As Object, e As EventArgs) Handles ShadowColorButton.Click
        ShadowFontColorDialog.ShowDialog()
        ShadowColorTextBox.Text = ShadowFontColorDialog.Color.ToString
    End Sub

    ' IMAGE DETAILS GROUPBOX
    '------------------------
    Private Sub BrowseButton_Click(sender As Object, e As EventArgs) Handles BrowseButton.Click
        If NoRadioButton.Checked = True Then
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.CurrentDirectory

            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                directoryTextBox.Text = OpenFileDialog1.FileName
            End If
        Else
            FolderBrowserDialog1.SelectedPath = My.Computer.FileSystem.CurrentDirectory

            If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
                directoryTextBox.Text = FolderBrowserDialog1.SelectedPath
                PopulateDefaultImageComboBox()
            End If
        End If
    End Sub
    Private Sub SubfoldersCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles SubfoldersCheckBox.CheckedChanged
        If directoryTextBox.Text <> String.Empty Then
            PopulateDefaultImageComboBox()
        End If
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles directoryTextBox.TextChanged
        If directoryTextBox.TextLength >= 1 Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles DetectSizeCheckBox.CheckedChanged
        If DetectSizeCheckBox.Checked = True Then
            SizeGroupBox.Enabled = False
        Else
            SizeGroupBox.Enabled = True
        End If
    End Sub

    ' SHAPE DETAILS GROUPBOX
    '------------------------
    Private Sub ShapeComboBox_TextUpdate(sender As Object, e As EventArgs) Handles ShapeComboBox.TextChanged
        If ShapeComboBox.Text <> String.Empty Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub
    Private Sub OutlineColorButton_Click(sender As Object, e As EventArgs) Handles OutlineColorButton.Click
        OutlineColorDialog.ShowDialog()
        OutlineColorTextBox.Text = OutlineColorDialog.Color.ToString
    End Sub
    Private Sub FillColorButton_Click(sender As Object, e As EventArgs) Handles FillColorButton.Click
        FillColorDialog.ShowDialog()
        FillColorTextBox.Text = FillColorDialog.Color.ToString
    End Sub

    ' OK BUTTON
    '-----------
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.TextLength = 0 Then
            MessageBox.Show("No object name specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            DialogResult = DialogResult.OK
            Close()
        End If
    End Sub

    '=======================
    '====== SUB/FUNC =======
    '=======================

    Public Function SelectedRadioButton(g As GroupBox) As Control
        For Each c In GroupBox1.Controls.OfType(Of RadioButton)
            If c.Checked Then
                Return c
            End If
        Next
        Return New Control
    End Function

    Private Sub PopulateDefaultImageComboBox()
        Dim list As Object() = subsAndFuncs.GetListOfFilesFromDirectory(directoryTextBox.Text, CBool(SubfoldersCheckBox.CheckState))
        DefaultImageComboBox.Items.Clear()
        'DefaultImageComboBox.Text = String.Empty
        DefaultImageComboBox.Items.AddRange(list)
    End Sub

    '=======================
    '====== TOOLTIPS =======
    '=======================

    Private Sub ToolTip_MouseEnter(sender As Object, e As EventArgs) Handles SelectableGroupBox.MouseEnter, DetectSizeCheckBox.MouseEnter, MultilineCheckBox.MouseEnter, MainAlphaLabel.MouseEnter, ShadowAlphaLabel.MouseEnter, OutlineAlphaLabel.MouseEnter, FillAlphaLabel.MouseEnter
        Cursor = Cursors.Help
    End Sub
    Private Sub ToolTip_MouseLeave(sender As Object, e As EventArgs) Handles SelectableGroupBox.MouseLeave, DetectSizeCheckBox.MouseLeave, MultilineCheckBox.MouseLeave, MainAlphaLabel.MouseLeave, ShadowAlphaLabel.MouseLeave, OutlineAlphaLabel.MouseLeave, FillAlphaLabel.MouseLeave
        Cursor = Cursors.Default
    End Sub
    Private Sub GroupBox2_MouseHover(sender As Object, e As EventArgs) Handles SelectableGroupBox.MouseHover
        ToolTip1.SetToolTip(SelectableGroupBox, "Yes: Will create a combobox in the editor and textbox in the card template configurator. Good for images that change often (art, gems, etc.)" & vbNewLine & "No: Will create a textbox in the card template configurator. Good for images that don't change often (banner, background, etc.")
    End Sub
    Private Sub DetectSizeCheckBox_MouseHover(sender As Object, e As EventArgs) Handles DetectSizeCheckBox.MouseHover
        ToolTip1.SetToolTip(DetectSizeCheckBox, "Enabling this option will allow HandJam to use the image's native resolution. Disabling this option will force HandJam to use a resolution of your choosing." & vbNewLine & vbNewLine & "Note: This option is only available for images.")
    End Sub
    Private Sub MultilineCheckBox_MouseHover(sender As Object, e As EventArgs) Handles MultilineCheckBox.MouseHover
        ToolTip1.SetToolTip(MultilineCheckBox, "Enabling this option will create a multi-line textbox control instead of a single-line control. This is a quality of life option and does not affect how the text is rendered in the image.")
    End Sub
    Private Sub AlphaLabel_MouseHover(sender As Object, e As EventArgs) Handles MainAlphaLabel.MouseHover, OutlineAlphaLabel.MouseHover, FillAlphaLabel.MouseHover
        ToolTip1.SetToolTip(MultilineCheckBox, "Alpha is the transparency of an object. The alpha value can range from 0 (invisible) to 255 (opaque).")
    End Sub
End Class
Option Strict On
Option Explicit On
Imports System.Security

'=================================
'= = = THE BIG OL TO-DO LIST = = =
'=================================
'Add "Conditions" that will make elements bahave based on the values of other elemnets
'   example: if "GoldText" value is over 299, change "GoldImg" to "Gold_6.png"
'Change "Card Types" to "Presets"
'Fully implement "Presets"
'   The only thing that changes is the default values. Everything else (including conditions) stays the same.
'Add card list loading
'   Controls
'Stop overwriting existing values with the default value whenever changing a control
'Add text alignment options
'Add image transparency
'Blend modes
'Add deck export
'   Ask for dimensions (auto-filled to recommended), export all images, concatenate images into sheets, ask for sheet URLs, ask for card back.

Public Class Form1
    '===================
    '=== GLOBAL VARS ===
    '===================
    Public setget As New SettersAndGetters
    Dim subsAndFuncs As New SharedSubsAndFuncs
    Dim SELECTED_ROW As Integer = -1

    '=======================
    '====== FORM LOAD ======
    '=======================

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'I want to die
        'This is essential to allowing the card render to update with keypresses.
        KeyPreview = False

        'set the row and col to the setget.rpcontrols
        ReDim setget.RPControls(18, 0) 'to-do, make this modular
        ReDim setget.Conditions(9, 0)
        ReDim setget.CardProperties(2)
        setget.CardProperties(0) = 1
        setget.CardProperties(1) = 1

        'set form according to preferences
        Dim filepath As String = My.Computer.FileSystem.CurrentDirectory & "\preferences.ini"
        Dim fileContents As String = My.Computer.FileSystem.ReadAllText(filepath)
        Dim searchTerms As String() = {"""w"": ", """h"": "}
        Dim values As String() = {String.Empty}

        'This can be cleaned pretty good
        For Each s In searchTerms
            Dim searchIndex As Integer = fileContents.IndexOf(s)
            If searchIndex = -1 Then
                MessageBox.Show("Preferences file was not found. Default values will be set.", "Preferences File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

        Width = CType(values(0), Integer)
        Height = CType(values(1), Integer)

        'set default combobox
        'CardTypeComboBox.SelectedIndex = 0

    End Sub

    '========================
    '====== MENU STRIP ======
    '========================
    Private Sub ImportCardListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportCardListToolStripMenuItem.Click
        Dim fileWindow As OpenFileDialog = New OpenFileDialog()
        Dim filePath As String

        fileWindow.Title = "Import Card List"
        fileWindow.InitialDirectory = My.Computer.FileSystem.CurrentDirectory
        fileWindow.Filter = "Handjam Card List (*.hcl)|*.hcl|JavaScript Files (*.js)|*.js" 'Tab Delimited Files (*.txt)|*.txt|Comma Seperated Files (*.csv)|*.csv
        fileWindow.FilterIndex = 2
        fileWindow.RestoreDirectory = True

        If fileWindow.ShowDialog() = DialogResult.OK Then
            filePath = fileWindow.FileName
            If filePath.ToLower.EndsWith(".js") Then
                JSFileDataLoader(filePath)
            ElseIf filePath.ToLower.EndsWith(".hcl") Then
                HCLFileDataLoader(filePath)
            Else
                MessageBox.Show("The selected file has an unsupported file extension.", "Invalid File Extension", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub CardListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CardListToolStripMenuItem.Click
        Dim saveFileDialog As New SaveFileDialog With {
            .DefaultExt = "js",
            .Filter = "JavaScript Files (*.js)|*.js",
            .InitialDirectory = My.Computer.FileSystem.CurrentDirectory,
            .Title = "Export Handjam Card List"
        }

        'Open a file save dialog
        Dim filePath As String
        Dim fileContents As String = String.Empty
        If saveFileDialog.ShowDialog = DialogResult.OK Then
            filePath = saveFileDialog.FileName

            'Collect data from DataGridView to fileContents
            For Each r As DataGridViewRow In DataGridView1.Rows
                fileContents &= RowToCardFormat(r) & "," & vbLf
            Next
            fileContents = fileContents.TrimEnd(CType(vbNewLine, Char()))
            fileContents = fileContents.TrimEnd(","c)

            'Export data from fileContents to file
            My.Computer.FileSystem.WriteAllText(filePath, fileContents, False)
        End If
    End Sub

    Function RowToCardFormat(r As DataGridViewRow) As String
        Dim data As String = "{"c & vbLf
        Dim header As String = String.Empty
        Dim value As String = String.Empty
        For Each c As DataGridViewCell In r.Cells
            header = DataGridView1.Columns.Item(c.ColumnIndex).HeaderText
            If c.Value IsNot Nothing Then value = c.Value.ToString

            data &= vbTab & """" & header & """: """ & value & """," & vbLf

            header = String.Empty
            value = String.Empty
        Next
        data &= "}"c

        Return data
    End Function

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim saveFileDialog As New SaveFileDialog With {
            .DefaultExt = "hct",
            .Filter = "Handjam Card Template (*.hct)|*.hct",
            .InitialDirectory = My.Computer.FileSystem.CurrentDirectory,
            .Title = "Export Handjam Card Template"
        }

        'Open a file save dialog
        If saveFileDialog.ShowDialog = DialogResult.OK Then
            Dim fileContents As String = "[Card Properties]" & vbLf
            Dim filePath As String = saveFileDialog.FileName

            'Collect data from setget.CardProperties to fileContents
            fileContents &= "{" & vbLf &
                vbTab & """width"": " & setget.CardProperties(0) & vbLf &
                vbTab & """height"": " & setget.CardProperties(1) & vbLf &
                "}"

            'Collect data from setget.rpcontrols to fileContents
            fileContents = fileContents & vbLf & vbLf & "[Controls]" & vbLf
            Dim coll As String() = {}
            Dim elementsCount As Integer = setget._RPControls.Length
            Dim colsCount As Integer = setget._RPControls.GetUpperBound(0)
            Dim rowsCount As Integer = setget._RPControls.GetUpperBound(1)
            For j As Integer = 0 To rowsCount - 1
                fileContents &= "{" & vbLf

                coll = subsAndFuncs.GetListOfAttributesByType(setget.RPControls(1, j).ToString.ToLower)

                For i As Integer = 0 To colsCount
                    'if there's nothing here, go to the next control
                    If setget._RPControls(i, j) IsNot Nothing Then
                        fileContents &= vbTab & """" & coll(i) & """: " & setget._RPControls(i, j).ToString & vbLf
                    Else
                        i = colsCount
                    End If
                Next
                fileContents &= "}," & vbLf
            Next
            'remove final comma
            fileContents = fileContents.Trim(CChar(vbLf), ","c) & vbLf & vbLf & "[Conditions]" & vbLf

            'Collect data from setget.conditions to fileContents
            'Stole code from above partly (to-do)
            coll = {"value1", "value1attribute", "operator", "value2", "value2attribute", "target", "targetattribute", "source", "sourceattribute"}
            elementsCount = setget._Conditions.Length
            colsCount = setget._Conditions.GetUpperBound(0)
            rowsCount = setget._Conditions.GetUpperBound(1)
            For k As Integer = 0 To rowsCount - 1
                fileContents &= "{" & vbLf
                For l As Integer = 0 To colsCount - 1
                    If setget._Conditions(l, k) IsNot Nothing Then
                        fileContents &= vbTab & """" & coll(l) & """: " & setget._Conditions(l, k).ToString & vbLf
                    Else
                        l = colsCount
                    End If
                Next
                fileContents &= "}," & vbLf
            Next
            'remove final comma
            fileContents = fileContents.Trim(CChar(vbLf), ","c)

            'Export data from fileContents to file
            My.Computer.FileSystem.WriteAllText(filePath, fileContents, False)
        End If
    End Sub

    Private Sub LoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem.Click
        Dim openFileDialog As New OpenFileDialog With {
            .DefaultExt = "hct",
            .Filter = "Handjam Card List (*.hct)|*.hct",
            .InitialDirectory = My.Computer.FileSystem.CurrentDirectory,
            .Title = "Import Handjam Card Template"
        }

        'Open a file open dialog
        If openFileDialog.ShowDialog = DialogResult.OK Then
            'Set wait cursor
            Cursor = Cursors.WaitCursor

            'clear the old data (if there is any)
            For r As Integer = ControlsTableLayoutPanel.RowCount - 2 To 0 Step -1
                TableLayoutPanelRemoveRow(ControlsTableLayoutPanel, r)
            Next
            ReDim setget.CardProperties(2)
            ReDim setget.RPControls(setget.RPControls.GetUpperBound(0), 0)
            ReDim setget.Conditions(setget.Conditions.GetUpperBound(0), 0)

            Dim fileContents As String = My.Computer.FileSystem.ReadAllText(openFileDialog.FileName)

            'parse the data
            Dim data As Object() = {}
            Dim cardPropertiesTerm As String = "[Card Properties]"
            Dim cardPropertiesIndex As Integer = fileContents.IndexOf(cardPropertiesTerm) + cardPropertiesTerm.Length
            Dim widthTerm As String = """width"": "
            Dim heightTerm As String = """height"": "
            Dim widthStart As Integer = fileContents.IndexOf(widthTerm, cardPropertiesIndex) + widthTerm.Length
            Dim widthEnd As Integer = fileContents.IndexOf(vbLf, widthStart)
            Dim widthValue As String = fileContents.Substring(widthStart, widthEnd - widthStart)
            Dim heightStart As Integer = fileContents.IndexOf(heightTerm, cardPropertiesIndex) + widthTerm.Length
            Dim heightEnd As Integer = fileContents.IndexOf(vbLf, heightStart)
            Dim heightValue As String = fileContents.Substring(heightStart, heightEnd - heightStart)
            ReDim setget.CardProperties(2)
            setget.CardProperties(0) = CInt(widthValue)
            setget.CardProperties(1) = CInt(heightValue)

            Dim controlsIndex As Integer = fileContents.IndexOf("[Controls]")
            Dim conditionsIndex As Integer = fileContents.IndexOf("[Conditions]")
            Dim controlStart As Integer = fileContents.IndexOf("{"c, controlsIndex)
            Dim controlEnd As Integer = fileContents.IndexOf("}"c, controlStart)
            Dim headerStart As Integer = 0
            Dim headerEnd As Integer = 0
            Dim headerEndSearchTerm As String = """: "
            Dim header As String = String.Empty
            Dim valueStart As Integer = 0
            Dim valueEnd As Integer = 0
            Dim value As String = String.Empty

            headerStart = fileContents.IndexOf(""""c, controlStart)
            headerEnd = fileContents.IndexOf(headerEndSearchTerm, headerStart)

            While controlStart < controlEnd And controlStart <> -1 And controlEnd <> -1
                'If headers are within the control
                While headerStart < controlEnd And headerEnd < controlEnd And headerStart <> -1 And headerEnd <> -1
                    header = fileContents.Substring(headerStart + 1, headerEnd - headerStart - 1)

                    valueStart = headerEnd + headerEndSearchTerm.Length
                    valueEnd = fileContents.IndexOf(vbLf, headerEnd)
                    value = fileContents.Substring(valueStart, valueEnd - valueStart)

                    ReDim Preserve data(data.Length)
                    data(data.Length - 1) = value

                    headerStart = fileContents.IndexOf(""""c, headerEnd + 1)
                    If headerStart <> -1 Then
                        headerEnd = fileContents.IndexOf(headerEndSearchTerm, headerStart + 1)
                    End If
                End While

                'If the header reads "text", "image", or "shape", handle it differently
                Select Case data(1).ToString.ToLower
                    Case "text"
                        'get font real quick lol
                        Dim raw As String = CStr(data(9))
                        Dim font As Font = GetFont(raw)

                        AddControlToTable(ControlsTableLayoutPanel,
                                          CStr(data(0)),
                                          CInt(data(2)),
                                          CInt(data(3)),
                                          CBool(data(4)),
                                          CInt(data(5)),
                                          CInt(data(6)),
                                          CBool(data(7)),
                                          CInt(data(8)),
                                          font,
                                          GetColor(CStr(data(10))), 'CType(data(10), Color)
                                          CInt(data(11)),
                                          CStr(data(12)),
                                          CBool(data(13)),
                                          GetColor(CStr(data(14))), 'CType(data(14), Color)
                                          CInt(data(15)),
                                          CInt(data(16)),
                                          CInt(data(17)),
                                          CStr(data(18))
                                          )
                    Case "image"
                        AddControlToTable(ControlsTableLayoutPanel,
                                          CStr(data(0)),
                                          CInt(data(2)),
                                          CInt(data(3)),
                                          CBool(data(4)),
                                          CInt(data(5)),
                                          CInt(data(6)),
                                          CStr(data(7)),
                                          CBool(data(8)),
                                          CStr(data(9))
                                          )
                    Case "shape"
                        AddControlToTable(ControlsTableLayoutPanel,
                                          CStr(data(0)),
                                          CInt(data(2)),
                                          CInt(data(3)),
                                          CBool(data(4)),
                                          CInt(data(5)),
                                          CInt(data(6)),
                                          CStr(data(7)),
                                          GetColor(CStr(data(8))), 'CType(data(8), Color)
                                          CInt(data(9)),
                                          CInt(data(10)),
                                          GetColor(CStr(data(11))), 'CType(data(11), Color)
                                          CInt(data(12))
                                          )
                End Select
                ReDim data(0)
                data = {}

                controlStart = fileContents.IndexOf("{"c, controlEnd + 1)
                If controlStart <> -1 And controlStart < conditionsIndex Then
                    'If there is an open bracket and it isn't part of conditions, find the close bracket
                    controlEnd = fileContents.IndexOf("}"c, controlStart + 1)
                End If
            End While

            'Handle conditions from this point forward (to-do)
            ReDim setget.Conditions(9, 0) 'to-do: make modular
            Dim conditionsRows As Integer = 0

            'parse the data
            If conditionsIndex = -1 Then Return
            controlStart = fileContents.IndexOf("{"c, conditionsIndex)
            If controlStart = -1 Then Return
            controlEnd = fileContents.IndexOf("}"c, controlStart)
            headerStart = fileContents.IndexOf(""""c, controlStart + 1)
            headerEnd = fileContents.IndexOf(""": ", headerStart + 1)
            headerEndSearchTerm = """: "
            header = String.Empty
            valueStart = 0
            valueEnd = 0
            value = String.Empty

            'to-do: this re-uses code from above
            While controlStart < controlEnd And controlStart <> -1 And controlEnd <> -1
                'If headers are within the control
                While headerStart < controlEnd And headerEnd < controlEnd And headerStart <> -1 And headerEnd <> -1
                    header = fileContents.Substring(headerStart + 1, headerEnd - headerStart - 1)

                    valueStart = headerEnd + headerEndSearchTerm.Length
                    valueEnd = fileContents.IndexOf(vbLf, headerEnd)
                    value = fileContents.Substring(valueStart, valueEnd - valueStart)

                    ReDim Preserve data(data.Length)
                    data(data.Length - 1) = value

                    headerStart = fileContents.IndexOf(""""c, headerEnd + 1)
                    If headerStart <> -1 Then
                        headerEnd = fileContents.IndexOf(headerEndSearchTerm, headerStart + 1)
                    End If
                End While

                conditionsRows = setget.Conditions.GetUpperBound(1) + 1
                ReDim Preserve setget.Conditions(9, conditionsRows)
                For i As Integer = 0 To 8
                    setget.Conditions(i, conditionsRows - 1) = data(i)
                Next

                ReDim data(0)
                data = {}

                controlStart = fileContents.IndexOf("{"c, controlEnd + 1)
                If controlStart <> -1 Then
                    controlEnd = fileContents.IndexOf("}"c, controlStart + 1)
                End If
            End While

            'Set default cursor
            Cursor = Cursors.Default

            'Run a quick image process now that everything is loaded
            PictureBox1.Image = ProcessImageLoop()
        End If
    End Sub

    Private Function GetFont(s As String) As Font
        Dim nameIndexSpecifier As String = "Name="
        Dim sizeIndexSpecifier As String = "Size="
        Dim nameStart As Integer = s.IndexOf("Name=") + nameIndexSpecifier.Length
        Dim sizeStart As Integer = s.IndexOf("Size=") + sizeIndexSpecifier.Length

        Dim name As String = s.Substring(nameStart, s.IndexOf(","c) - nameStart)
        Dim size As Integer = CInt(s.Substring(sizeStart, s.IndexOf(",", sizeStart) - sizeStart))

        If s.Contains("Bold=True") And s.Contains("Italic=True") Then
            Return New Font(name, size, FontStyle.Bold Or FontStyle.Italic)
        ElseIf s.Contains("Bold=True") Then
            Return New Font(name, size, FontStyle.Bold)
        ElseIf s.Contains("Italic=True") Then
            Return New Font(name, size, FontStyle.Italic)
        Else
            Return New Font(name, size)
        End If
    End Function

    Private Function GetColor(s As String) As Color
        If s.Contains("R=") Then 'if it's argb then
            Dim aStart As Integer = s.IndexOf("A=") + 2
            Dim rStart As Integer = s.IndexOf("R=") + 2
            Dim gStart As Integer = s.IndexOf("G=") + 2
            Dim bStart As Integer = s.IndexOf("B=") + 2
            Dim a As Integer = CInt(s.Substring(aStart, s.IndexOf(","c, aStart) - aStart))
            Dim r As Integer = CInt(s.Substring(rStart, s.IndexOf(","c, rStart) - rStart))
            Dim g As Integer = CInt(s.Substring(gStart, s.IndexOf(","c, gStart) - gStart))
            Dim b As Integer = CInt(s.Substring(bStart, s.IndexOf("]"c, bStart) - bStart))


            Return Color.FromArgb(a, r, g, b)
        Else 'if its just a word then
            Dim cStart As Integer = s.IndexOf("["c)
            Dim cEnd As Integer = s.IndexOf("]"c)
            Dim clr As String = s.Substring(cStart + 1, cEnd - cStart - 1)

            Return Color.FromName(clr)
        End If
    End Function

    Private Sub SingleCardImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SingleCardImageToolStripMenuItem.Click
        'Dim s As String = InputBox("Enter a name for this card image: ", "Asign Filename")

        'If s = CardTypeComboBox.Text And CardTypeComboBox.Items.Count <> 0 Then
        '    MessageBox.Show("No duplicate names allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        'ElseIf s <> String.Empty Then
        '    CardTypeComboBox.Items.Add(s)
        '    CardTypeComboBox.SelectedIndex = CardTypeComboBox.Items.IndexOf(s)
        '    EditButton.Enabled = True
        '    AddControlButton.Enabled = True
        '    RemoveCardTypeButton.Enabled = True
        'End If

        Dim saveFileDialog As New SaveFileDialog With {
            .DefaultExt = "png",
            .Filter = "Portable Network Graphics (*.png)|*.png",
            .InitialDirectory = My.Computer.FileSystem.CurrentDirectory,
            .Title = "Export Single Card Image"
        }

        'Open a file save dialog
        If saveFileDialog.ShowDialog = DialogResult.OK Then
            Dim filePath As String
            filePath = saveFileDialog.FileName

            PictureBox1.Image.Save(filePath, Imaging.ImageFormat.Png)
        End If
    End Sub

    Private Sub AllCardImagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllCardImagesToolStripMenuItem.Click
        'This function is also used in deck export, therefor it's been moved to its own function
        ExportAllCards()
    End Sub

    Private Sub ExportAllCards()
        Dim saveLocationDialog As New FolderBrowserDialog With {
            .SelectedPath = My.Computer.FileSystem.CurrentDirectory
        }

        'Open a file save dialog
        If saveLocationDialog.ShowDialog <> DialogResult.OK Then
            MessageBox.Show("Export Aborted", "The export process has been aborted.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'Select the variable to name the images after
        Dim FileNameFormatter As New FileNameFormatter
        If FileNameFormatter.ShowDialog() <> DialogResult.OK Then
            MessageBox.Show("Export Aborted", "The export process has been aborted.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'Save each image to the selected location utilizing the specified control naming scheme
        Dim selectedControl As Integer = FileNameFormatter.ComboBox1.SelectedIndex
        Dim filePath As String = String.Empty
        Dim cardImage As New PictureBox With {
            .Width = setget.CardProperties(0),
            .Height = setget.CardProperties(1)
        }

        For Each r As DataGridViewRow In DataGridView1.Rows
            filePath = saveLocationDialog.SelectedPath & "\" & r.Cells(selectedControl).Value.ToString & ".png"
            cardImage.Image = ProcessImageLoop(r.Index) 'ProcessImage(r.Index)
            cardImage.Image.Save(filePath, Imaging.ImageFormat.Png)
        Next
    End Sub

    'Private Function GetFontByString(ByVal sFont As String) As Font
    '    sFont = sFont.Substring(1, sFont.Length - 2)
    '    sFont = Replace(sFont, ",", vbNullString)
    '    sFont = Replace(sFont, "Font:", vbNullString)
    '    Dim sElement() As String = Split(sFont, " ")
    '    Dim sSingle() As String
    '    Dim sValue As String
    '    Dim FontName As String
    '    Dim FontSize As Single
    '    Dim FontStyle As FontStyle = Drawing.FontStyle.Regular
    '    Dim FontUnit As GraphicsUnit = GraphicsUnit.Point
    '    Dim gdiCharSet As Byte
    '    Dim gdiVerticalFont As Boolean

    '    For Each sValue In sElement
    '        sValue = Trim(sValue)
    '        sSingle = Split(sValue, "=")
    '        If sSingle.GetUpperBound(0) > 0 Then
    '            If sSingle(0) = "Name" Then
    '                FontName = sSingle(1)
    '            ElseIf sSingle(0) = "Size" Then
    '                FontSize = CSng(sSingle(1))
    '            ElseIf sSingle(0) = "Units" Then
    '                FontUnit = CType(CInt(sSingle(1)), GraphicsUnit)
    '            ElseIf sSingle(0) = "GdiCharSet" Then
    '                FontName = CStr(CByte(sSingle(1)))
    '            ElseIf sSingle(0) = "GdiVerticalFont" Then
    '                FontName = CStr(CBool(sSingle(1)))
    '            End If
    '        End If
    '    Next
    '    Return New Font(FontName, FontSize, FontStyle, FontUnit, gdiCharSet, gdiVerticalFont)
    'End Function

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub PreferencesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreferencesToolStripMenuItem.Click
        Preferences.ShowDialog()
    End Sub

    '=======================
    '===== LEFT PANEL ======
    '=======================
    '- - - - BUTTONS - - - -
    '-----------------------
    Private Sub AddCardButton_Click(sender As Object, e As EventArgs) Handles AddCardButton.Click
        If ControlsTableLayoutPanel.RowCount < 1 Then 'includes header and empty last row
            Return
        End If

        Dim maxRows As Integer = ControlsTableLayoutPanel.RowCount - 2
        Dim coll As String() = {}

        For i As Integer = 0 To maxRows
            ReDim Preserve coll(i + 1)
            coll(i) = ControlsTableLayoutPanel.GetControlFromPosition(1, i).Text 'old value 3
        Next

        If DataGridView1.Columns.Count >= 1 Then
            DataGridView1.Rows.Add(coll)
        End If
    End Sub

    Private Sub EditCardButton_Click(sender As Object, e As EventArgs) Handles EditCardButton.Click
        Dim maxRows As Integer = ControlsTableLayoutPanel.RowCount - 2

        'For each cell in DataGridView, edit each control in ControlsTableLayoutPanel
        For i As Integer = 0 To maxRows
            If DataGridView1.SelectedRows(0).Cells(i).Value IsNot Nothing Then
                ControlsTableLayoutPanel.GetControlFromPosition(1, i).Text = DataGridView1.SelectedRows(0).Cells(i).Value.ToString
            Else
                ControlsTableLayoutPanel.GetControlFromPosition(1, i).Text = String.Empty
            End If
        Next
    End Sub

    Private Sub RemoveCardButton_Click(sender As Object, e As EventArgs) Handles RemoveCardButton.Click
        For Each r As DataGridViewRow In DataGridView1.SelectedRows
            DataGridView1.Rows.Remove(r)
        Next
    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count <= 0 Then
            RemoveCardButton.Enabled = False
            EditCardButton.Enabled = False
        ElseIf DataGridView1.SelectedRows.Count = 1 Then
            RemoveCardButton.Enabled = True
            EditCardButton.Enabled = True
        Else
            RemoveCardButton.Enabled = True
            EditCardButton.Enabled = False
        End If
    End Sub

    '=========================
    '====== RIGHT PANEL ======
    '=========================
    '- - - - - BUTTONS - - - -
    '-------------------------

    Private Sub NewCardTypeButton_Click(sender As Object, e As EventArgs) Handles NewCardTypeButton.Click

        'CHECK FOR DUPLICATES BEFORE ADDING
        Dim s As String = InputBox("Enter a name for this card type: ", "New Card Type")

        If s = CardTypeComboBox.Text And CardTypeComboBox.Items.Count <> 0 Then
            MessageBox.Show("No duplicate names allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        ElseIf s <> String.Empty Then
            CardTypeComboBox.Items.Add(s)
            CardTypeComboBox.SelectedIndex = CardTypeComboBox.Items.IndexOf(s)
            EditButton.Enabled = True
            AddControlButton.Enabled = True
            RemoveCardTypeButton.Enabled = True
        End If
    End Sub

    Private Sub RemoveCardTypeButton_Click(sender As Object, e As EventArgs) Handles RemoveCardTypeButton.Click
        'There must be a card type selected. This button should be greyed out, tho.
        If CardTypeComboBox.SelectedIndex < 0 Then
            Return
        End If
        Dim oldIndex As Integer = CardTypeComboBox.SelectedIndex
        CardTypeComboBox.Items.RemoveAt(oldIndex)

        Dim cnt As Integer = CardTypeComboBox.Items.Count

        If cnt > 0 Then
            CardTypeComboBox.SelectedIndex = 0
        Else
            EditButton.Enabled = False
            AddControlButton.Enabled = False
            RemoveCardTypeButton.Enabled = False
        End If
    End Sub

    Private Sub EditButton_Click(sender As Object, e As EventArgs) Handles EditButton.Click
        'There must be a card type selected. This button should be greyed out, tho.
        If CardTypeComboBox.SelectedIndex < 0 Then
            Return
        End If

        Dim s As String = InputBox("Enter a new name for this card type: ", "Change Card Type Name")
        'Dim dup As Integer = CardTypeComboBox.Items.IndexOf(s)

        If s = CardTypeComboBox.Text Then
            MessageBox.Show("No duplicate names allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        ElseIf s <> String.Empty Then
            CardTypeComboBox.Items(CardTypeComboBox.SelectedIndex) = s
        End If
    End Sub

    Sub AddControlButton_Click(sender As Object, e As EventArgs) Handles AddControlButton.Click
        Dim addForm As New AddObjectForm()
        addForm.Location = LocationToRightOf(Me, addForm)
        addForm.Text = "Add Control"

        'Don't create a control and labels if the image isn't selectable (w.NoRadioButton.Checked = False)
        If addForm.ShowDialog() = DialogResult.OK And addForm.NoRadioButton.Checked = False Then
            Dim s As TextBox = addForm.TextBox1
            Dim c As Control = addForm.SelectedRadioButton(addForm.GroupBox1)

            'Check for dupes
            Dim maxRows As Integer = ControlsTableLayoutPanel.RowCount - 2
            For i As Integer = 0 To maxRows
                If ControlsTableLayoutPanel.GetControlFromPosition(0, i).Text = s.Text Then 'old value 2
                    MessageBox.Show("No duplicate names allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End If
            Next

            '-------------------
            'Set/Create Controls

            'Dim del As Label = NewDeleteLabel(s)
            'ControlsTableLayoutPanel.Controls.Add(del)

            'Dim cl As Label = NewChangeLabel()
            'ControlsTableLayoutPanel.Controls.Add(cl)

            Dim lab As Label = NewControlLabel(s)
            ControlsTableLayoutPanel.Controls.Add(lab)

            Dim nc As New Control
            Select Case c.Text
                Case "Image"
                    'If this is a selectable image
                    If addForm.YesRadioButton.Checked = True Then
                        nc = NewComboBoxControl(addForm.directoryTextBox.Text, addForm.SubfoldersCheckBox.Checked)
                        nc.Text = addForm.DefaultImageComboBox.Text

                        'add control to setget
                        AddToSetget(s.Text,
                                   CInt(addForm.xNumericUpDown.Value),
                                   CInt(addForm.yNumericUpDown.Value),
                                   addForm.DetectSizeCheckBox.Checked,
                                   CInt(addForm.widthNumericUpDown.Value),
                                   CInt(addForm.heightNumericUpDown.Value),
                                   addForm.directoryTextBox.Text,
                                   addForm.SubfoldersCheckBox.Checked,
                                   addForm.DefaultImageComboBox.Text)
                    End If
                Case "Text"
                    nc = NewTextBoxControl(CInt(addForm.MultlineNumericUpDown.Value), addForm.MultilineCheckBox.Checked)
                    nc.Text = addForm.DefaultTextBox.Text

                    'add control to setget
                    AddToSetget(s.Text,
                               CInt(addForm.xNumericUpDown.Value),
                               CInt(addForm.yNumericUpDown.Value),
                               addForm.DetectSizeCheckBox.Checked,
                               CInt(addForm.widthNumericUpDown.Value),
                               CInt(addForm.heightNumericUpDown.Value),
                               addForm.MultilineCheckBox.Checked,
                               CInt(addForm.MultlineNumericUpDown.Value),
                               addForm.FontDialog1.Font,
                               addForm.MainFontColorDialog.Color,
                               CInt(addForm.MainAlphaNumericUpDown.Value),
                               addForm.AlignmentComboBox.Text,
                               addForm.ShadowCheckBox.Checked,
                               addForm.ShadowFontColorDialog.Color,
                               CInt(addForm.ShadowAlphaNumericUpDown.Value),
                               CInt(addForm.DistanceNumericUpDown.Value),
                               CInt(addForm.RotationNumericUpDown.Value),
                               addForm.DefaultTextBox.Text)
                Case "Shape"
                    nc = NewLabelControl("[Shape Object]") 'a label control is being created with the sole purpose of taking space

                    AddToSetget(s.Text,
                               CInt(addForm.xNumericUpDown.Value),
                               CInt(addForm.yNumericUpDown.Value),
                               addForm.DetectSizeCheckBox.Checked,
                               CInt(addForm.widthNumericUpDown.Value),
                               CInt(addForm.heightNumericUpDown.Value),
                               addForm.ShapeComboBox.Text,
                               addForm.OutlineColorDialog.Color,
                               CInt(addForm.OutlineAlphaNumericUpDown.Value),
                               CInt(addForm.ThicknessNumericUpDown.Value),
                               addForm.FillColorDialog.Color,
                               CInt(addForm.FillAlphaNumericUpDown.Value))
                Case Else
            End Select
            ControlsTableLayoutPanel.Controls.Add(nc)

            'Add new field to DataGridView
            DataGridView1.Columns.Add(s.Text, s.Text)

            ControlsTableLayoutPanel.RowCount += 1

            AddCardButton.Enabled = True
        End If
        PictureBox1.Image = ProcessImageLoop()
    End Sub

    '-------------------------
    '- - DYNAMIC CONTROLS  - -
    '- - - - - - - - - - - - -

    ''' <summary>
    ''' Accepts the row index associated with the control and changes the row in the ControlsTableLayoutPanel.
    ''' </summary>
    ''' <param name="row">Control's row index.</param>
    Private Sub EditControl(row As Integer) '(sender As Object, e As EventArgs)
        Dim addForm As New AddObjectForm()
        addForm.Location = LocationToRightOf(Me, addForm)
        addForm.Text = "Change Control"

        '--------------------------------
        'Set preset values in the addForm


        'Dim row As Integer = ControlsTableLayoutPanel.GetPositionFromControl(CType(sender, Control)).Row

        'Set object name from label
        addForm.TextBox1.Text = CStr(setget.RPControls(0, row))

        'Set values for position/size
        addForm.xNumericUpDown.Value = CDec(setget.RPControls(2, row))
        addForm.yNumericUpDown.Value = CDec(setget.RPControls(3, row))
        addForm.DetectSizeCheckBox.Checked = CBool(setget.RPControls(4, row))
        addForm.widthNumericUpDown.Value = CDec(setget.RPControls(5, row))
        addForm.heightNumericUpDown.Value = CDec(setget.RPControls(6, row))

        'Set remaining values based on object type
        Select Case setget.RPControls(1, row).ToString
            Case "text"
                addForm.TextRadioButton.Checked = True

                addForm.MultilineCheckBox.Checked = CBool(setget.RPControls(7, row))
                addForm.MultlineNumericUpDown.Value = CInt(setget.RPControls(8, row))
                addForm.FontDialog1.Font = CType(setget.RPControls(9, row), Font)
                addForm.MainFontTextBox.Text = addForm.FontDialog1.Font.ToString
                addForm.MainFontColorDialog.Color = CType(setget.RPControls(10, row), Color)
                addForm.MainColorTextBox.Text = addForm.MainFontColorDialog.Color.ToString
                addForm.MainAlphaNumericUpDown.Value = CInt(setget.RPControls(11, row))
                addForm.AlignmentComboBox.SelectedIndex = addForm.AlignmentComboBox.Items.IndexOf(CStr(setget.RPControls(12, row)))
                addForm.ShadowCheckBox.Checked = CBool(setget.RPControls(13, row))
                addForm.ShadowGroupBox.Enabled = CBool(setget.RPControls(13, row))
                addForm.ShadowFontColorDialog.Color = CType(setget.RPControls(14, row), Color)
                addForm.ShadowColorTextBox.Text = addForm.ShadowFontColorDialog.Color.ToString
                addForm.ShadowAlphaNumericUpDown.Value = CInt(setget.RPControls(15, row))
                addForm.DistanceNumericUpDown.Value = CInt(setget.RPControls(16, row))
                addForm.RotationNumericUpDown.Value = CInt(setget.RPControls(17, row))
                addForm.DefaultTextBox.Text = CStr(setget.RPControls(18, row))
            Case "image"
                addForm.ImageRadioButton.Checked = True

                addForm.directoryTextBox.Text = CStr(setget.RPControls(7, row))
                addForm.SubfoldersCheckBox.Checked = CBool(setget.RPControls(8, row))
                addForm.DefaultImageComboBox.Text = CStr(setget.RPControls(9, row))
            Case "shape"
                addForm.ShapeRadioButton.Checked = True

                addForm.ShapeComboBox.Text = CStr(setget.RPControls(7, row))
                addForm.OutlineColorDialog.Color = CType(setget.RPControls(8, row), Color)
                addForm.OutlineColorTextBox.Text = addForm.OutlineColorDialog.Color.ToString
                addForm.OutlineAlphaNumericUpDown.Value = CInt(setget.RPControls(9, row))
                addForm.ThicknessNumericUpDown.Value = CInt(setget.RPControls(10, row))
                addForm.FillColorDialog.Color = CType(setget.RPControls(11, row), Color)
                addForm.FillColorTextBox.Text = addForm.FillColorDialog.Color.ToString
                addForm.FillAlphaNumericUpDown.Value = CInt(setget.RPControls(12, row))
            Case Else
                MessageBox.Show("Error in Form1.vb at line 331. Object type was not found. Setting to text as the default value.", "Object Type Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select

        '--------------
        'Change control

        'Don't change a control if the image isn't selectable (w.NoRadioButton.Checked = False)
        If addForm.ShowDialog() = DialogResult.OK And addForm.NoRadioButton.Checked = False Then
            Dim s As TextBox = addForm.TextBox1
            Dim c As Control = addForm.SelectedRadioButton(addForm.GroupBox1)

            'Check for dupes
            Dim maxRows As Integer = ControlsTableLayoutPanel.RowCount - 2
            For i As Integer = 0 To maxRows
                If ControlsTableLayoutPanel.GetControlFromPosition(0, i).Text = s.Text And i <> row Then 'if text matches, let it happen 'old value 2
                    MessageBox.Show("No duplicate names allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End If
            Next

            Dim lbl As Control = ControlsTableLayoutPanel.GetControlFromPosition(0, row) 'old value 2
            Dim oc As Control = ControlsTableLayoutPanel.GetControlFromPosition(1, row) 'old value 3
            lbl.Text = s.Text
            lbl.Anchor = AnchorStyles.Left
            lbl.Size = TextRenderer.MeasureText(s.Text, s.Font)
            lbl.MaximumSize = TextRenderer.MeasureText(s.Text, s.Font)
            DataGridView1.Columns.Item(row).HeaderText = s.Text

            Dim nc As New Control
            Select Case c.Text
                Case "Image"
                    'If this is a selectable image
                    If addForm.YesRadioButton.Checked = True Then
                        nc = NewComboBoxControl(addForm.directoryTextBox.Text, addForm.SubfoldersCheckBox.Checked)
                        nc.TabIndex = oc.TabIndex
                        nc.Text = addForm.DefaultImageComboBox.Text

                        'edit control in setget
                        EditSetget(row,
                                   s.Text,
                                   CInt(addForm.xNumericUpDown.Value),
                                   CInt(addForm.yNumericUpDown.Value),
                                   addForm.DetectSizeCheckBox.Checked,
                                   CInt(addForm.widthNumericUpDown.Value),
                                   CInt(addForm.heightNumericUpDown.Value),
                                   addForm.directoryTextBox.Text,
                                   addForm.SubfoldersCheckBox.Checked,
                                   addForm.DefaultImageComboBox.Text)
                    End If
                Case "Text"
                    nc = NewTextBoxControl(CInt(addForm.MultlineNumericUpDown.Value), addForm.MultilineCheckBox.Checked)
                    nc.TabIndex = oc.TabIndex
                    nc.Text = addForm.DefaultTextBox.Text

                    'edit control in setget
                    EditSetget(row,
                               s.Text,
                               CInt(addForm.xNumericUpDown.Value),
                               CInt(addForm.yNumericUpDown.Value),
                               CBool(addForm.DetectSizeCheckBox.Checked),
                               CInt(addForm.widthNumericUpDown.Value),
                               CInt(addForm.heightNumericUpDown.Value),
                               addForm.MultilineCheckBox.Checked,
                               CInt(addForm.MultlineNumericUpDown.Value),
                               addForm.FontDialog1.Font,
                               addForm.MainFontColorDialog.Color,
                               CInt(addForm.MainAlphaNumericUpDown.Value),
                               addForm.AlignmentComboBox.Text,
                               addForm.ShadowCheckBox.Checked,
                               addForm.ShadowFontColorDialog.Color,
                               CInt(addForm.ShadowAlphaNumericUpDown.Value),
                               CInt(addForm.DistanceNumericUpDown.Value),
                               CInt(addForm.RotationNumericUpDown.Value),
                               addForm.DefaultTextBox.Text)
                Case "Shape"
                    nc = NewLabelControl("[Shape Object]") 'the label control exists only to take up space
                    nc.TabIndex = oc.TabIndex

                    EditSetget(row,
                                s.Text,
                               CInt(addForm.xNumericUpDown.Value),
                               CInt(addForm.yNumericUpDown.Value),
                               addForm.DetectSizeCheckBox.Checked,
                               CInt(addForm.widthNumericUpDown.Value),
                               CInt(addForm.heightNumericUpDown.Value),
                               addForm.ShapeComboBox.Text,
                               addForm.OutlineColorDialog.Color,
                               CInt(addForm.OutlineAlphaNumericUpDown.Value),
                               CInt(addForm.ThicknessNumericUpDown.Value),
                               addForm.FillColorDialog.Color,
                               CInt(addForm.FillAlphaNumericUpDown.Value))
                Case Else
            End Select
            'Dim del As Label = NewDeleteLabel(s)
            'Dim cl As Label = NewChangeLabel()
            Dim lab As Label = NewControlLabel(s)

            TableLayoutPanelChangeRow(ControlsTableLayoutPanel, row, {lab, nc})
            'TableLayoutPanelChangeRow(ControlsTableLayoutPanel, row, {del, cl, lab, nc})
            'ControlsTableLayoutPanel.Controls.Remove(oc)
            'ControlsTableLayoutPanel.Controls.Add(nc, 3, row)

        ElseIf addForm.NoRadioButton.Checked = True Then
            'Selectable was set as no, therefor delete this row. We'll try stealing X_Click for now. Clean this up (to-do)
            'X_Click(sender, e)
        End If

        PictureBox1.Image = ProcessImageLoop() '(sender, e)
    End Sub
    Private Sub X_MouseHover(sender As Object, e As EventArgs)
        Dim t As ToolTip = ToolTip1
        t.SetToolTip(CType(sender, Control), "Remove this row")
    End Sub
    Private Sub CL_MouseHover(sender As Object, e As EventArgs)
        Dim t As ToolTip = ToolTip1
        t.SetToolTip(CType(sender, Control), "Change this row")
    End Sub
    Private Sub Lab_MouseHover(sender As Object, e As EventArgs)
        Dim t As ToolTip = ToolTip1
        Dim s As Control = CType(sender, Control)
        t.SetToolTip(s, s.Text)
    End Sub
    ''' <summary>
    ''' Accepts the row index associated with the control and changes the row in the ControlsTableLayoutPanel.
    ''' </summary>
    ''' <param name="row"></param>
    Public Sub RemoveControl(row As Integer) '(sender As Object, e As EventArgs) to-do: add to shared subsandfuncs

        If MessageBox.Show("Are you sure you want to delete this control?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            'Dim row As Integer = ControlsTableLayoutPanel.GetPositionFromControl(CType(sender, Control)).Row
            Dim lbl As Control = ControlsTableLayoutPanel.GetControlFromPosition(0, row) 'old value 2

            'TableLayoutPanelRemoveRow(ControlsTableLayoutPanel, CType(sender, Control))
            'TableLayoutPanelRemoveRow(ControlsTableLayoutPanel, lbl)
            TableLayoutPanelRemoveRow(ControlsTableLayoutPanel, row)
            'RemoveFromSetget(lbl.Text)
            RemoveFromSetget(row)
            PictureBox1.Image = ProcessImageLoop()
        End If
    End Sub
    Private Sub Lab_Click(sender As Object, e As EventArgs)
        'Get the index of the item that's being clicked
        Dim ind As Integer = 0
        Dim length As Integer = subsAndFuncs.GetListOfStrings(setget).Length
        Dim found As Boolean = False

        For Each i In subsAndFuncs.GetListOfStrings(setget)
            If i.ToString <> CType(sender, Label).Text And found = False Then
                ind += 1
            ElseIf found = False Then
                found = True
                'If the index is the first or last of the table, don't allow move up/down
                If ind = 0 AndAlso length <> 1 Then
                    ContextMenuStrip1.Items.Add("Move Down")
                ElseIf length = 1 Then
                    'do nothing, no moves that can happen
                ElseIf ind = length - 1 Then
                    ContextMenuStrip1.Items.Add("Move Up")
                Else
                    ContextMenuStrip1.Items.Add("Move Up")
                    ContextMenuStrip1.Items.Add("Move Down")
                End If
            End If
        Next

        ContextMenuStrip1.Items.Add("Edit")
        ContextMenuStrip1.Items.Add("Remove")

        'Display context strip
        Dim p As Point
        p.X = 0
        p.Y = 0
        SELECTED_ROW = ind
        ContextMenuStrip1.Show(CType(sender, Control), 0, 0)
    End Sub

    Private Sub ContextMenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked
        ContextMenuStrip1.Hide()

        Select Case e.ClickedItem.Text
            Case "Move Up"
                TableLayoutPanelMoveRow(ControlsTableLayoutPanel, SELECTED_ROW - 1)
            Case "Move Down"
                TableLayoutPanelMoveRow(ControlsTableLayoutPanel, SELECTED_ROW)
            Case "Edit"
                EditControl(SELECTED_ROW)
            Case "Remove"
                RemoveControl(SELECTED_ROW)
        End Select
    End Sub

    Private Sub ContextMenuStrip1_Closed(sender As Object, e As ToolStripDropDownClosedEventArgs) Handles ContextMenuStrip1.Closed
        ContextMenuStrip1.Items.Clear()
    End Sub

    '=======================
    '======= HELP ==========
    '=======================

    Private Sub OnlineDocumentationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnlineDocumentationToolStripMenuItem.Click
        Process.Start("https://docs.google.com/document/d/1eAV5YUvVgpbYspLzo9hXNn7NAkxLpCpi_UNx7E-oerM/edit#heading=h.jw8avvdcf48c")
    End Sub

    Private Sub URealmsForumTopicToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles URealmsForumTopicToolStripMenuItem.Click
        Process.Start("https://forums.urealms.com/discussion/6648/")
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    '=======================
    '====== SUB/FUNC =======
    '=======================

    ''' <summary>
    ''' Returns a point to the right of the source form.
    ''' </summary>
    ''' <param name="source">The source form.</param>
    ''' <param name="target">The form that is being moved to the right of the source form.</param>
    ''' <remarks></remarks>
    Private Function LocationToRightOf(source As Form, target As Form) As Point
        Dim loc As Point
        loc.X = source.Width + source.Location.X
        loc.Y = source.Location.Y

        'if the window goes off screen at all, revert to 0,0
        If loc.X + target.Width >= Screen.PrimaryScreen.WorkingArea.Width Then 'Or loc.Y + target.Height >= Screen.PrimaryScreen.WorkingArea.Height 
            loc.X = 0
            loc.Y = 0
        End If
        Return loc
    End Function

    ''' <summary>
    ''' Returns a label used for deleting a row from the ControlsTableLayoutPanel.
    ''' </summary>
    ''' <param name="s">Textbox containing control name.</param>
    ''' <remarks></remarks>
    Private Function NewDeleteLabel(s As TextBox) As Label
        Dim del As New Label With {
                .Anchor = AnchorStyles.None,
                .ForeColor = Color.Red,
                .Size = TextRenderer.MeasureText(s.Text, s.Font),
                .Text = "x"
            }
        AddHandler del.Click, AddressOf X_Click
        AddHandler del.MouseHover, AddressOf X_MouseHover
        Return del
    End Function
    Private Sub X_Click(sender As Object, e As EventArgs)
        RemoveControl(SELECTED_ROW)
    End Sub

    ''' <summary>
    ''' Returns a label used for changing a control from the ControlsTableLayoutPanel.
    ''' </summary>
    ''' <remarks></remarks>
    Private Function NewChangeLabel() As Label
        Dim cl As New Label With {
                .Anchor = AnchorStyles.None,
                .ForeColor = Color.Yellow,
                .Height = 20,
                .Image = My.Resources.change_icon_20,
                .Width = 20
            }
        AddHandler cl.Click, AddressOf CL_Click
        AddHandler cl.MouseHover, AddressOf CL_MouseHover
        Return cl
    End Function
    Private Sub CL_Click(sender As Object, e As EventArgs)
        EditControl(SELECTED_ROW)
    End Sub

    ''' <summary>
    ''' Returns a label that represents the control from the ControlsTableLayoutPanel.
    ''' </summary>
    ''' <param name="s">Textbox containing control name.</param>
    ''' <remarks></remarks>
    Private Function NewControlLabel(s As TextBox) As Label
        Dim lab As New Label With {
                .Anchor = AnchorStyles.Left,
                .MaximumSize = TextRenderer.MeasureText(s.Text, s.Font),
                .Size = TextRenderer.MeasureText(s.Text, s.Font),
                .Text = s.Text,
                .AutoSize = False
            }
        AddHandler lab.Click, AddressOf Lab_Click
        AddHandler lab.MouseHover, AddressOf Lab_MouseHover
        Return lab
    End Function

    ''' <summary>
    ''' Returns a New TextBox control for ControlsTableLayoutPanel. Intended for type Text.
    ''' </summary>
    ''' <param name="ln">The number of lines in a multi-line control.</param>
    ''' <param name="ml">Multi-line control. True or false.</param>
    ''' <remarks></remarks>
    Private Function NewTextBoxControl(ln As Integer, ml As Boolean) As TextBox
        Dim sc As ScrollBars = ScrollBars.None
        'Dim ml As Boolean = False
        'Dim ln As Integer = CInt(addForm.MultlineNumericUpDown.Value)
        Dim boxHeight As Integer = 20
        If ml = True Then
            sc = ScrollBars.Vertical
            boxHeight *= ln
        End If
        Dim ds As DockStyle = DockStyle.Top
        Dim sz As New Size With {
            .Width = 40,
            .Height = 20
        }
        Dim newTB As New TextBox With {
            .Dock = ds,
            .Height = boxHeight,
            .MinimumSize = sz,
            .Multiline = ml,
            .ScrollBars = sc
        }
        AddHandler newTB.TextChanged, AddressOf NewTB_TextChanged
        Return newTB
    End Function
    Private Sub NewTB_TextChanged(sender As Object, e As EventArgs)
        PictureBox1.Image = ProcessImageLoop()
    End Sub

    ''' <summary>
    ''' Returns a New ComboBox control for ControlsTableLayoutPanel. Intended for type Images.
    ''' </summary>
    ''' <param name="dir">Directory that images will be taken from.</param>
    ''' <param name="subdir">Subdirectories enabled. True or false.</param>
    ''' <remarks></remarks>
    Private Function NewComboBoxControl(dir As String, subdir As Boolean) As ComboBox
        'Dim dir As String = addForm.directoryTextBox.Text
        'Dim subdir As Boolean = addForm.SubfoldersCheckBox.Checked
        Dim newCB As New ComboBox 'idk why I have to do it like this

        Dim list As Object() = subsAndFuncs.GetListOfFilesFromDirectory(dir, subdir)
        newCB.Items.AddRange(list)
        newCB.Dock = DockStyle.Fill

        AddHandler newCB.KeyUp, AddressOf NewCB_ProcessImage
        AddHandler newCB.SelectionChangeCommitted, AddressOf NewCB_SelectionChangeCommitted

        Return newCB
    End Function
    Private Sub NewCB_ProcessImage(sender As Object, e As EventArgs)
        PictureBox1.Image = ProcessImageLoop()
    End Sub
    Private Sub NewCB_SelectionChangeCommitted(sender As Object, e As EventArgs)
        'Google doesn't do shit for finding out why events fire in a delayed fashion FUCK THIS BULLSHIT
        SendKeys.Send("{HELP}")
    End Sub

    ''' <summary>
    ''' Returns a New Label control for ControlsTableLayoutPanel. Intended for type Shapes.
    ''' </summary>
    ''' <param name="s">Text that acts as a placeholder for a textbox or combobox.</param>
    ''' <remarks></remarks>
    Private Function NewLabelControl(s As String) As Label
        Dim newL As New Label With {
            .Dock = DockStyle.Fill,
            .Text = s,
            .TextAlign = ContentAlignment.MiddleCenter
        }

        Return newL
    End Function
    ''' <summary>
    ''' Assistant function for ProcessConditions. Retrieves the NewValue for specified control, target, or source.
    ''' </summary>
    ''' <param name="labelColl">Collection of labels in Controls Table.</param>
    ''' <param name="i">Index of active Conditions form control.</param>
    ''' <param name="targetIndex">The active target index being processed by ProcessConditions.</param>
    ''' <param name="newArray">The new array where the overwritten properties are stored.</param>
    ''' <param name="r">The row within the DataGridView that is being rendered.</param>
    ''' <remarks></remarks>
    Private Function ProcessConditionsGetNewValue(labelColl As Object(), i As Integer, targetIndex As Integer, newArray As Object(,), Optional r As Integer = -1) As String

        'Retrieve the name of the control being targeted, the property being compared, and its position in the Control Table 
        Dim objName As String = setget.Conditions(i, targetIndex).ToString
        Dim objProperty As String = setget.Conditions(i + 1, targetIndex).ToString.ToLower
        Dim objIndex As Integer = Array.IndexOf(labelColl, objName)
        Dim objNewValue As String = String.Empty

        'If the property's value is the target, assign that value to control1NewValue.
        If objIndex = -1 Then 'This is a specific situation for just the "source" property in conditions
            objNewValue = objName
        ElseIf objProperty = "value" Then
            If r = -1 Then 'If we're taking the value from the Controls Table (r is -1 by default)
                objNewValue = TableLayoutPanelGetCell(ControlsTableLayoutPanel, objIndex, 1).Text
            Else
                objNewValue = DataGridView1.Rows(r).Cells(objIndex).Value.ToString
            End If
        ElseIf objProperty <> String.Empty Then
            Dim propertyColl As String() = subsAndFuncs.GetListOfAttributesByType(newArray(1, objIndex).ToString)
            Dim objPropertyIndex As Integer = Array.IndexOf(propertyColl, objProperty)
            objNewValue = newArray(objPropertyIndex, objIndex).ToString
        End If

        Return objNewValue
    End Function

    ''' <summary>
    ''' Processes the user defined conditions. Accepts an input array and the card's index, then returns a condition-corrected array. Adds a new element to the end of the array: value. 
    ''' </summary>
    ''' <param name="inputArray">The array to run against.</param>
    ''' <param name="r">The DataGridView row index of the card being processed.</param>
    ''' <remarks></remarks>
    Private Function ProcessConditions(inputArray As Object(,), Optional r As Integer = -1) As Object(,)

        'Get a list of target names from setget.Conditions and copy setget.RPControls to a temporary array
        Dim targetColl As Object() = subsAndFuncs.GetListOfStrings(setget.Conditions, 5)
        Dim newArray As Object(,)
        ReDim newArray(inputArray.GetUpperBound(0) + 1, inputArray.GetUpperBound(1)) 'Adding "value" to the end of the newArray later
        Array.Copy(inputArray, newArray, inputArray.Length)

        'Make a list of control names from setget.RPControls
        Dim labelColl As Object() = subsAndFuncs.GetListOfStrings(setget)

        'Initialize variables used for duration of processing
        Dim labelIndex As Integer = 0
        Dim targetIndex As Integer = 0
        Dim propertyIndex As Integer
        Dim propertyColl As String()
        Dim control1NewValue, control2NewValue,
            targetName, targetNewValue, targetProperty,
            sourceNewValue, oper As String
        Dim flag As Boolean = False

        control2NewValue = String.Empty 'set as empty in case never filled
        sourceNewValue = String.Empty

        'For each of the targets, if any of the target names match a control label, overwrite the control's properties
        While targetIndex < targetColl.Count

            'Retrieve the new value for control1 and the operator based on the targetIndex
            control1NewValue = ProcessConditionsGetNewValue(labelColl, 0, targetIndex, newArray, r)
            oper = setget.Conditions(2, targetIndex).ToString.ToLower

            'If there is no control2 property, skip this portion, as control2Name is *actually* a value... or something (to-do)
            If setget.Conditions(3, targetIndex) IsNot Nothing AndAlso setget.Conditions(3, targetIndex).ToString <> String.Empty Then
                control2NewValue = ProcessConditionsGetNewValue(labelColl, 3, targetIndex, newArray, r)
            End If

            'Retrieve the new value for target
            targetNewValue = ProcessConditionsGetNewValue(labelColl, 5, targetIndex, newArray, r)
            targetName = setget.Conditions(5, targetIndex).ToString
            targetProperty = setget.Conditions(6, targetIndex).ToString.ToLower

            'If there is no source, skip this portion
            If setget.Conditions(7, targetIndex) IsNot Nothing Then
                sourceNewValue = ProcessConditionsGetNewValue(labelColl, 7, targetIndex, newArray, r)
            End If

            While labelIndex < labelColl.Count
                Console.WriteLine("Current targetName: " & targetName)
                If targetName = labelColl(labelIndex).ToString Then 'targets(targetIndex)
                    'target and control match. Compare and replace if condition is met
                    Dim tv1, tv2 As Integer
                    Select Case oper.ToLower
                        Case ">"
                            If Integer.TryParse(control1NewValue, tv1) = True AndAlso Integer.TryParse(control2NewValue, tv2) = True AndAlso CInt(control1NewValue) > CInt(control2NewValue) Then flag = True
                        Case ">="
                            If Integer.TryParse(control1NewValue, tv1) = True AndAlso Integer.TryParse(control2NewValue, tv2) = True AndAlso CInt(control1NewValue) >= CInt(control2NewValue) Then flag = True
                        Case "="
                            If control1NewValue = control2NewValue Then
                                flag = True
                            End If
                        Case "<="
                            If Integer.TryParse(control1NewValue, tv1) = True AndAlso Integer.TryParse(control2NewValue, tv2) = True AndAlso CInt(control1NewValue) <= CInt(control2NewValue) Then flag = True
                        Case "<"
                            If Integer.TryParse(control1NewValue, tv1) = True AndAlso Integer.TryParse(control2NewValue, tv2) = True AndAlso CInt(control1NewValue) < CInt(control2NewValue) Then flag = True
                        Case "IsEmpty".ToLower
                            If control1NewValue = String.Empty Then flag = True
                        Case "IsNotEmpty".ToLower
                            If control1NewValue <> String.Empty Then flag = True
                        Case Else
                            MessageBox.Show("Error in Form1.vb in ProcessImage(). Invalid operator selected for conditions", "Object Type Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Select

                    'If the condition isn't met, don't continue

                    'Replace old with new value
                    'If we're changing value, do that and then move on
                    If targetProperty = "value" And flag = True Then

                        'If we're adjusting values in the Controls Table, replace control's text
                        If r = -1 Then
                            TableLayoutPanelGetCell(ControlsTableLayoutPanel, labelIndex, 1).Text = sourceNewValue 'replaced source
                        Else
                            'Assign the new value to the end of newArray and change DataGridView cell
                            newArray(inputArray.GetUpperBound(0) + 1, labelIndex) = sourceNewValue 'GOD I HATE THIS PROGRAM
                            DataGridView1.Rows(r).Cells(labelIndex).Value = sourceNewValue
                        End If

                    ElseIf flag = True Then

                        'Get the property index for rpcontrols
                        propertyColl = subsAndFuncs.GetListOfAttributesByType(newArray(1, labelIndex).ToString)
                        propertyIndex = Array.IndexOf(propertyColl, targetProperty)

                        'Overwrite property
                        Console.WriteLine("Replacing " & targetName & "'s " & targetProperty & " from " & newArray(propertyIndex, labelIndex).ToString & " to " & sourceNewValue)
                        newArray(propertyIndex, labelIndex) = sourceNewValue 'rreplaced source

                    End If

                    'go to the next target
                    labelIndex = labelColl.Count
                    flag = False
                End If
                labelIndex += 1
            End While
            labelIndex = 0
            targetIndex += 1
        End While

        Return newArray
    End Function

    ''' <summary>
    ''' Sets up a loop for processing the image based on utilizing the Controls Table or the DataGridView. 
    ''' </summary>
    ''' <param name="r">Row index from DataGridView.</param>
    ''' <remarks></remarks>
    Private Function ProcessImageLoop(Optional r As Integer = -1) As Bitmap
        'Use wait cursor to help identify that the process is running
        Cursor = Cursors.WaitCursor

        '===============
        ' - VARIABLES -
        '---------------

        'Initialize drawing elements
        Dim drawsurface As New Bitmap(setget.CardProperties(0), setget.CardProperties(1))
        Dim g As Graphics = Graphics.FromImage(drawsurface)

        '====================
        ' - RUN CONDITIONS -
        '--------------------

        'Conditions need to be set prior to processing the image.
        Dim RPControlsCopy As Object(,) = ProcessConditions(setget.RPControls, r)

        '===================
        ' - PROCESS IMAGE -
        '-------------------

        'Draw each element of the selected row
        If r = -1 Then
            'Utilize Controls Table
            For row As Integer = 0 To ControlsTableLayoutPanel.RowCount - 2
                Dim tempControl As Control = TableLayoutPanelGetCell(ControlsTableLayoutPanel, row, 1)
                ProcessImage(RPControlsCopy, g, drawsurface, tempControl, row)
            Next
        Else
            'Utilize DataGridView
            For Each cell As DataGridViewCell In DataGridView1.Rows(r).Cells
                ProcessImage(RPControlsCopy, g, drawsurface, , , cell) 'blank space for unused control
            Next
        End If

        'Reset the cursor
        Cursor = Cursors.Default

        'Return the drawsurface
        Return drawsurface
    End Function

    ''' <summary>
    ''' Process a new image by a specified row index from DataGridView. No row specified indiciates using the Controls Table. Outputs a drawSurface, Bitmap type.
    ''' </summary>
    ''' <param name="cell">Fuck you.</param>
    ''' <remarks></remarks>
    Private Sub ProcessImage(RPControlsCopy As Object(,), ByRef g As Graphics, ByRef drawSurface As Bitmap, Optional tempControl As Control = Nothing, Optional tableRow As Integer = -1, Optional cell As DataGridViewCell = Nothing) 'Private Sub As Bitmap
        '=============================
        ' - NOTATION FOR DEVELOPERS - 
        '-----------------------------

        'ProcessImage takes user input from the DataGridView as opposed to the Controls table and generates a single image. This allows for exporting the cards without "physically" manipulating form controls or showing changes to the user's PictureBox. The intended use of this function is for mass exporting of cards.

        '====================
        ' - RUN CONDITIONS -
        '--------------------

        'Conditions need to be set prior to processing the image.
        'Dim RPControlsCopy As Object(,) = ProcessConditions(setget.RPControls, r)

        '===============
        ' - VARIABLES -
        '---------------

        'Initialize drawing elements
        'Dim cardImage As New PictureBox
        'Dim drawsurface As New Bitmap(setget.CardProperties(0), setget.CardProperties(1))
        'Dim g As Graphics = Graphics.FromImage(drawsurface)

        'Initialize common elements of each control type
        Dim lt, ty As String                'Label Text, Type (Text, Image, Shape)
        Dim x, y, w, h As Integer           'x, y, width, height
        Dim ds As Boolean                   'Detect Size

        'Initialize text elements
        Dim sh As Boolean                   'Shadow
        Dim mA, sA, d As Integer            'Main Alpha, Shadow Alpha, Distance
        Dim rot As Double                   'Rotation (double required for pi formula)
        Dim font As Font
        Dim mC, sC As Color                 'Main Color, Shadow Color
        Dim al As String                    'Alignment

        'Initialize image elements
        Dim dir, filePath As String         'Directory, filePath
        Dim sd As Boolean                   'Subdirectories

        'Initialize shape elements
        Dim s As String                     'Shape
        Dim oC, fC As Color                 'Outline Color, Fill Color
        Dim t, oA, fA As Integer            'Thickness, Outline Alpha, Fill Alpha

        '===================
        ' - PROCESS IMAGE -
        '-------------------

        'Draw each element of the selected row
        'Because the Controls Table is expected to be in the same order as the DataGridView, colIndex is used for both selecting cells from the DataGridView and viewing the properties of each control in the Controls Table.

        Dim colIndex As Integer
        'For Each cell As DataGridViewCell In DataGridView1.Rows(r).Cells
        If cell Is Nothing Then
            colIndex = tableRow
        Else
            colIndex = cell.ColumnIndex
        End If

        'Set values of common elements
        lt = RPControlsCopy(0, colIndex).ToString
        ty = RPControlsCopy(1, colIndex).ToString
        x = CInt(RPControlsCopy(2, colIndex))
        y = CInt(RPControlsCopy(3, colIndex))
        ds = CBool(RPControlsCopy(4, colIndex))
        w = CInt(RPControlsCopy(5, colIndex))
        h = CInt(RPControlsCopy(6, colIndex))

        Select Case ty.ToLower
                '==========
                ' - TEXT - 
                '----------
            Case "Text".ToLower
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit 'I don't know what this is for

                'Set values of text elements
                font = CType(RPControlsCopy(9, colIndex), Font)
                mC = CType(RPControlsCopy(10, colIndex), Color)
                mA = CInt(RPControlsCopy(11, colIndex))
                al = RPControlsCopy(12, colIndex).ToString
                sh = CBool(RPControlsCopy(13, colIndex))

                'Convert mC and mA to a drawbrush
                Dim db As New SolidBrush(Color.Black) With {
                        .Color = Color.FromArgb(mA, mC.R, mC.G, mC.B)
                    }

                'Convert al to a StringFormat
                Dim sf As StringFormat = StringFormat.GenericTypographic
                Select Case al
                    Case "TopLeft"
                        sf.LineAlignment = StringAlignment.Near
                        sf.Alignment = StringAlignment.Near
                    Case "TopCenter"
                        sf.LineAlignment = StringAlignment.Near
                        sf.Alignment = StringAlignment.Center
                    Case "TopRight"
                        sf.LineAlignment = StringAlignment.Near
                        sf.Alignment = StringAlignment.Far
                    Case "MiddleLeft"
                        sf.LineAlignment = StringAlignment.Center
                        sf.Alignment = StringAlignment.Near
                    Case "MiddleCenter"
                        sf.LineAlignment = StringAlignment.Center
                        sf.Alignment = StringAlignment.Center
                    Case "MiddleRight"
                        sf.LineAlignment = StringAlignment.Center
                        sf.Alignment = StringAlignment.Far
                    Case "BottomLeft"
                        sf.LineAlignment = StringAlignment.Far
                        sf.Alignment = StringAlignment.Near
                    Case "BottomCenter"
                        sf.LineAlignment = StringAlignment.Far
                        sf.Alignment = StringAlignment.Center
                    Case "BottomRight"
                        sf.LineAlignment = StringAlignment.Far
                        sf.Alignment = StringAlignment.Far
                    Case Else
                End Select

                'If width or height aren't specified, assign to the image's entirety (subtracting positioning)
                If w = 0 Then
                    w = drawSurface.Width - x
                End If
                If h = 0 Then
                    h = drawSurface.Height - y
                End If

                'Convert x, y, w, h to rectangle
                Dim pnt As New Point(x, y)
                Dim sz As New Size(w, h)
                Dim rect As New Rectangle(pnt, sz)

                If sh = True Then 'if shadow is real
                    sC = CType(RPControlsCopy(14, colIndex), Color)
                    sA = CInt(RPControlsCopy(15, colIndex))
                    d = CInt(RPControlsCopy(16, colIndex))
                    rot = CInt(RPControlsCopy(17, colIndex))

                    'Convert sC and sA to a drawbrush
                    Dim sDb As New SolidBrush(Color.Black) With {
                            .Color = Color.FromArgb(sA, sC.R, sC.G, sC.B)
                        }

                    'Adjust pnt to account for dis and rot
                    'dis = hypotenus
                    'rot = angle
                    rot *= Math.PI / 180
                    pnt.X += d * CInt(Math.Cos(rot))
                    pnt.Y += d * CInt(Math.Sin(rot))
                    Dim sRect As New Rectangle(pnt, sz)

                    'Draw Shadow
                    If cell Is Nothing Then
                        'Data coming from Controls Table
                        g.DrawString(tempControl.Text, font, sDb, sRect, sf)
                    Else
                        'Data is coming from DataGridView
                        g.DrawString(cell.Value.ToString, font, sDb, sRect, sf)
                    End If
                End If

                'Draw Main
                If cell Is Nothing Then
                    'Data coming from Controls Table
                    g.DrawString(tempControl.Text, font, db, rect, sf)
                Else
                    'Data is coming from DataGridView
                    g.DrawString(cell.Value.ToString, font, db, rect, sf)
                End If

                '===========
                ' - IMAGE - 
                '-----------
            Case "Image".ToLower
                'Set values of image element
                dir = RPControlsCopy(7, colIndex).ToString
                sd = CBool(RPControlsCopy(8, colIndex))

                filePath = String.Empty 'init to empty in case image doesn't exist

                If cell Is Nothing Then
                    'Data coming from Controls Table
                    filePath = GetImageFilePath(dir, sd, tempControl.Text)
                Else
                    'Data is coming from DataGridView
                    filePath = GetImageFilePath(dir, sd, cell.Value.ToString)
                End If

                'If the image exists, resume with processing
                If filePath <> String.Empty Then

                    'Create a bitmap for the image
                    Dim img As New Bitmap(filePath, True)

                    'If detect size is true, set size according to provided image. Otherwise, leave them as they were already set.
                    If CBool(RPControlsCopy(4, colIndex)) = True Then
                        w = img.Width
                        h = img.Height
                    End If

                    'Draw Image
                    g.DrawImage(img, x, y, w, h)
                    img.Dispose()
                End If

                '===========
                ' - SHAPE - 
                '-----------
            Case "Shape".ToLower
                'Set values of shape element
                s = RPControlsCopy(7, colIndex).ToString
                oC = CType(RPControlsCopy(8, colIndex), Color)
                oA = CInt(RPControlsCopy(9, colIndex))
                t = CInt(RPControlsCopy(10, colIndex))
                fC = CType(RPControlsCopy(11, colIndex), Color)
                Integer.TryParse(RPControlsCopy(12, colIndex).ToString, fA)

                'Process according to the shape specified
                Select Case s.ToLower
                    Case "Rectangle".ToLower

                        'If width or height aren't specified, assign to the image's entirety (subtracting positioning)
                        If w = 0 Then
                            w = drawSurface.Width - x
                        End If
                        If h = 0 Then
                            h = drawSurface.Height - y
                        End If

                        'Convert oC and oA to a pen
                        Dim oP As New Pen(Color.Black) With {
                                .Color = Color.FromArgb(oA, oC.R, oC.G, oC.B),
                                .Width = t
                            }

                        'Convert fC and fA to a drawbrush
                        Dim fDb As New SolidBrush(Color.Black) With {
                                .Color = Color.FromArgb(fA, fC.R, fC.G, fC.B)
                            }

                        'Convert coordinates, width, and height to a rectangle
                        Dim pnt As New Point(x, y)
                        Dim sz As New Size(w, h)
                        Dim rect As New Rectangle(pnt, sz)

                        'Draw rectangle
                        g.FillRectangle(fDb, rect)
                        g.DrawRectangle(oP, rect)
                    Case Else
                        MessageBox.Show("The shape """ & s & """ is not supported.", "Unsupported Shape", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select

                '==========
                ' - ELSE - 
                '----------
            Case Else
                MessageBox.Show("Error in Form1.vb in ProcessImage(). Object type was not found in Select Case statement. Discovered item: " & RPControlsCopy(1, colIndex).ToString.ToLower, "Object Type Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
        'Next

        'Return drawSurface
    End Sub

    'to-do: move this
    Private Function GetImageFilePath(dir As String, sf As Boolean, fileName As String) As String
        'If the directory doesn't exist, display error and return an empty string
        If FileIO.FileSystem.DirectoryExists(dir) = False Then
            MessageBox.Show("The following directory does not exist and files cannot be retrieved." & vbNewLine & vbNewLine & dir, "Directory Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return String.Empty
        End If

        'If the filename is empty, just return it
        If fileName = String.Empty Then Return String.Empty

        'If the filename exists as explicitly written, return that explicit path
        Dim filePath As String = dir & "\" & fileName
        If My.Computer.FileSystem.FileExists(filePath) = True Then Return filePath

        'If the filename doesn't exist as explicitly written, find it and return that explicit path
        Dim so As FileIO.SearchOption = FileIO.SearchOption.SearchAllSubDirectories
        If sf = False Then so = FileIO.SearchOption.SearchTopLevelOnly
        Dim filePaths As ObjectModel.ReadOnlyCollection(Of String) = FileIO.FileSystem.GetFiles(dir, so, "*" & fileName & "*")
        If filePaths.Count > 0 AndAlso filePaths(0) IsNot Nothing Then Return filePaths(0).ToString

        'If the filename still doesn't return anything, return an empty string
        Return String.Empty
    End Function

    ''' <summary>
    ''' Removes the specified row from the table by saving the following rows, removing the current and following rows, then reinserting the following rows.
    ''' </summary>
    ''' <param name="tlp">TableLayoutPanel containing the desired row.</param>
    ''' <param name="c">Control belonging to the desired row.</param>
    ''' <remarks></remarks>
    Private Sub TableLayoutPanelRemoveRow(ByRef tlp As TableLayoutPanel, ByRef c As Control)
        'Save all rows that follow first.
        Dim rowCollCnt As Integer = 0
        Dim rowStart As Integer = tlp.GetPositionFromControl(c).Row 'returns the INDEX of the row
        Dim rowCnt As Integer = tlp.RowCount - (tlp.GetRow(c) + 1)
        Dim rowColl As Object()() = {}

        'Add the rows that follow (if any) to the collection
        For rowPos As Integer = rowStart + 1 To tlp.RowCount - 2
            rowCollCnt += 1
            ReDim Preserve rowColl(rowCollCnt)
            rowColl(rowCollCnt - 1) = TableLayoutPanelGetRow(tlp, rowPos)
        Next

        'Remove the current row and all following rows.
        DataGridView1.Columns.RemoveAt(SELECTED_ROW)
        For rowPos As Integer = tlp.RowCount - 1 To rowStart Step -1
            TableLayoutPanelRemoveRowSub(tlp, rowPos)
        Next

        'Add the rows back.
        For Each i In rowColl
            If i IsNot Nothing Then
                TableLayoutPanelAddRowBack(tlp, i)
            End If
        Next
        tlp.RowCount += 1
    End Sub

    ''' <summary>
    ''' Removes the specified row from the table by saving the following rows, removing the current and following rows, then reinserting the following rows.
    ''' </summary>
    ''' <param name="tlp">TableLayoutPanel containing the desired row.</param>
    ''' <param name="r">Row belonging to the TableLayoutPanel.</param>
    ''' <remarks></remarks>
    Private Sub TableLayoutPanelRemoveRow(ByRef tlp As TableLayoutPanel, ByRef r As Integer)
        'Save all rows that follow first.
        Dim rowCollCnt As Integer = 0
        Dim rowStart As Integer = r 'returns the INDEX of the row
        Dim rowCnt As Integer = tlp.RowCount - (r + 1)
        Dim rowColl As Object()() = {}

        'Add the rows that follow (if any) to the collection
        For rowPos As Integer = rowStart + 1 To tlp.RowCount - 2
            rowCollCnt += 1
            ReDim Preserve rowColl(rowCollCnt)
            rowColl(rowCollCnt - 1) = TableLayoutPanelGetRow(tlp, rowPos)
        Next

        'Remove the current row and all following rows.
        DataGridView1.Columns.RemoveAt(r)
        For rowPos As Integer = tlp.RowCount - 1 To rowStart Step -1
            TableLayoutPanelRemoveRowSub(tlp, rowPos)
        Next

        'Add the rows back.
        For Each i In rowColl
            If i IsNot Nothing Then
                TableLayoutPanelAddRowBack(tlp, i)
            End If
        Next
        tlp.RowCount += 1
    End Sub

    ''' <summary>
    ''' Moves the provided row down in the table by saving the following rows, then removing the provided and following rows. While reinserting the rows, the provided row is inserted right before the final row is inserted.
    ''' </summary>
    ''' <param name="tlp">TableLayoutPanel containing the desired row.</param>
    ''' <param name="row">The row's index (the one being moved down).</param>
    ''' <remarks></remarks>
    Public Sub TableLayoutPanelMoveRow(ByRef tlp As TableLayoutPanel, row As Integer) 'to-do, move to shared subs and funcs
        'Save all rows that follow first.
        Dim rowCollCnt As Integer = 0
        Dim rowStart As Integer = row 'returns the INDEX of the row
        Dim rowCnt As Integer = tlp.RowCount - (rowStart + 1)
        Dim rowColl As Object()() = {}
        Dim srcRow As Object() = TableLayoutPanelGetRow(tlp, row)
        Dim trgRow As Object() = TableLayoutPanelGetRow(tlp, row + 1)

        'Add the rows that follow (if any) to the collection
        For rowPos As Integer = rowStart + 2 To tlp.RowCount - 2
            rowCollCnt += 1
            ReDim Preserve rowColl(rowCollCnt)
            rowColl(rowCollCnt - 1) = TableLayoutPanelGetRow(tlp, rowPos)
        Next

        'Remove the current row and all following rows.
        For rowPos As Integer = tlp.RowCount - 1 To rowStart Step -1
            TableLayoutPanelRemoveRowSub(tlp, rowPos)
        Next

        'Add the rows back And swap columns
        TableLayoutPanelAddRowBack(tlp, trgRow)
        TableLayoutPanelAddRowBack(tlp, srcRow)
        For Each i In rowColl
            If i IsNot Nothing Then
                TableLayoutPanelAddRowBack(tlp, i)
            End If
        Next

        Dim colInd As Integer = 0
        For i As Integer = 0 To DataGridView1.Columns.Count - 1
            'if the moving row's label matches, track its index
            If TableLayoutPanelGetCell(tlp, row, 0).Text.ToLower = DataGridView1.Columns.Item(i).HeaderText.ToLower Then
                colInd = i
            End If
        Next

        DataGridView1.Columns.Item(colInd).DisplayIndex = row
        'DataGridView1.Columns.Item(row).DisplayIndex = row

        'Swap the setgets
        Dim rowLen As Integer = setget.RPControls.GetUpperBound(0)
        Dim temp As Object = Nothing
        For ind As Integer = 0 To rowLen - 1
            temp = setget.RPControls(ind, row)
            setget.RPControls(ind, row) = setget.RPControls(ind, row + 1)
            setget.RPControls(ind, row + 1) = temp
        Next

        tlp.RowCount += 1
    End Sub

    ''' <summary>
    ''' Changes the selected row by removing it and all following rows, inserting the replacement row, and then reinserting all following rows.
    ''' </summary>
    ''' <param name="tlp">TableLayoutPanel containing the desired row.</param>
    ''' <param name="row">The row's index.</param>
    ''' <param name="newRow">Replacement row.</param>
    ''' <remarks></remarks>
    Private Sub TableLayoutPanelChangeRow(ByRef tlp As TableLayoutPanel, row As Integer, newRow As Object())
        'Save all rows that follow first.
        Dim rowCollCnt As Integer = 0
        Dim rowCnt As Integer = tlp.RowCount - (row + 1)
        Dim rowColl As Object()() = {}

        'Add the rows that follow (if any) to the collection
        For rowPos As Integer = row + 1 To tlp.RowCount - 2
            rowCollCnt += 1
            ReDim Preserve rowColl(rowCollCnt)
            rowColl(rowCollCnt - 1) = TableLayoutPanelGetRow(tlp, rowPos)
        Next

        'Remove the current row and all following rows.
        For rowPos As Integer = tlp.RowCount - 1 To row Step -1
            TableLayoutPanelRemoveRowSub(tlp, rowPos)
        Next

        'Add the rows back.
        TableLayoutPanelAddRowBack(ControlsTableLayoutPanel, newRow)
        For Each i In rowColl
            If i IsNot Nothing Then
                TableLayoutPanelAddRowBack(tlp, i)
            End If
        Next
        tlp.RowCount += 1
    End Sub

    ''' <summary>
    ''' Returns a collection of controls present at the specified control's row.
    ''' </summary>
    ''' <param name="tlp">TableLayoutPanel containing the desired row.</param>
    ''' <param name="c">Control belonging to the desired row.</param>
    ''' <remarks></remarks>
    Private Function TableLayoutPanelGetRow(ByRef tlp As TableLayoutPanel, c As Control) As Object()
        Dim rowPos As Integer = tlp.GetRow(c)
        Dim colCnt As Integer = tlp.ColumnCount
        Dim row As Object()
        ReDim Preserve row(colCnt)

        For colPos As Integer = 0 To colCnt - 1
            row(colPos) = tlp.GetControlFromPosition(colPos, rowPos)
        Next

        Return row
    End Function

    ''' <summary>
    ''' Returns a collection of controls present at the specified row.
    ''' </summary>
    ''' <param name="tlp">TableLayoutPanel containing the desired row.</param>
    ''' <param name="r">The desired row.</param>
    ''' <remarks></remarks>
    Private Function TableLayoutPanelGetRow(ByRef tlp As TableLayoutPanel, r As Integer) As Object()
        Dim rowPos As Integer = r
        Dim colCnt As Integer = tlp.ColumnCount
        Dim row As Object()
        ReDim Preserve row(colCnt)

        For colPos As Integer = 0 To colCnt - 1
            row(colPos) = tlp.GetControlFromPosition(colPos, rowPos)
        Next

        Return row
    End Function

    ''' <summary>
    ''' Returns a cell present in the specified TableLayoutPanel, at the specified row and col.
    ''' </summary>
    ''' <param name="tlp">TableLayoutPanel containing the desired row.</param>
    ''' <param name="r">The desired row.</param>
    ''' <param name="c">The desired col.</param>
    ''' <remarks></remarks>
    Private Function TableLayoutPanelGetCell(ByRef tlp As TableLayoutPanel, r As Integer, c As Integer) As Control
        Return CType(TableLayoutPanelGetRow(tlp, r)(c), Control)
    End Function

    ''' <summary>
    ''' Removes the specified row from the TableLayoutPanel. Only handles the removal of a single row, intended for use on final row of table.
    ''' </summary>
    ''' <param name="tlp">TableLayoutPanel containing the desired row.</param>
    ''' <param name="r">The desired row's position.</param>
    ''' <remarks></remarks>
    Private Sub TableLayoutPanelRemoveRowSub(ByRef tlp As TableLayoutPanel, r As Integer)
        'If DataGridView1.Columns.Count > r AndAlso DataGridView1.Columns(r) IsNot Nothing Then
        '    DataGridView1.Columns.RemoveAt(r)
        'End If

        For i As Integer = 3 To 0 Step -1
            tlp.Controls.Remove(tlp.GetControlFromPosition(i, r))
        Next

        tlp.RowCount -= 1
    End Sub

    ''' <summary>
    ''' Adds a row to the TableLayoutPanel
    ''' </summary>
    ''' <param name="tlp">TableLayoutPanel to insert the row into.</param>
    ''' <param name="r">Row control collection.</param>
    ''' <remarks></remarks>
    Private Sub TableLayoutPanelAddRow(ByRef tlp As TableLayoutPanel, r As Object())
        Dim s As String = CType(r(0), Control).Text 'old value 2
        tlp.RowCount += 1
        For Each i In r
            tlp.Controls.Add(CType(i, Control))
        Next
        DataGridView1.Columns.Add(CType(r(0), Control).Text, CType(r(0), Control).Text) 'old values 2
    End Sub

    ''' <summary>
    ''' Adds a row to the TableLayoutPanel
    ''' </summary>
    ''' <param name="tlp">TableLayoutPanel to insert the row into.</param>
    ''' <param name="r">Row control collection.</param>
    ''' <remarks></remarks>
    Private Sub TableLayoutPanelAddRowBack(ByRef tlp As TableLayoutPanel, r As Object())
        Dim s As String = CType(r(0), Control).Text 'old value 2
        tlp.RowCount += 1
        For Each i In r
            tlp.Controls.Add(CType(i, Control))
        Next
        'DataGridView1.Columns.Add(CType(r(0), Control).Text, CType(r(0), Control).Text) 'old values 2
    End Sub

    ''' <summary>
    ''' Adds a text control to the setget array
    ''' </summary>
    ''' <param name="lt">Label text.</param>
    ''' <param name="x">X coordinate.</param>
    ''' <param name="y">Y coordinate.</param>
    ''' <param name="ds">Detect size, true or false.</param>
    ''' <param name="w">Element width.</param>
    ''' <param name="h">Element height.</param>
    ''' <param name="ml">Multi-line, true or false.</param>
    ''' <param name="ln">Number of lines.</param>
    ''' <param name="f">Text font.</param>
    ''' <param name="mC">Text color.</param>
    ''' <param name="mA">Text alpha (transparency).</param>
    ''' <param name="al">Alignment.</param>
    ''' <param name="sB">Shadow, true or false.</param>
    ''' <param name="sC">Text shadow color.</param>
    ''' <param name="sA">Text shadow alpha (transparency).</param>
    ''' <param name="dis">Text shadow distance from text.</param>
    ''' <param name="rot">Text shadow rotation from text.</param>
    ''' <param name="def">Default text.</param>
    ''' <remarks></remarks>
    Private Sub AddToSetget(lt As String, x As Integer, y As Integer, ds As Boolean, w As Integer, h As Integer, ml As Boolean, ln As Integer, f As Font, mC As Color, mA As Integer, al As String, sB As Boolean, sC As Color, sA As Integer, dis As Integer, rot As Integer, def As String)
        Dim rowLen As Integer = setget.RPControls.GetUpperBound(0)
        Dim colLen As Integer = setget.RPControls.GetUpperBound(1)
        Dim addInd As Integer = 0
        Dim coll As Object() = {lt, "text", x, y, ds, w, h, ml, ln, f, mC, mA, al, sB, sC, sA, dis, rot, def} 'added "text" to coll 20230130, rmv if fucked

        'Add a new col to add everything to
        colLen += 1
        ReDim Preserve setget.RPControls(rowLen, colLen)

        For Each i In coll
            setget.RPControls(addInd, colLen - 1) = i
            addInd += 1
        Next
    End Sub

    ''' <summary>
    ''' Adds an image control to the setget array
    ''' </summary>
    ''' <param name="lt">Label text.</param>
    ''' <param name="x">X coordinate.</param>
    ''' <param name="y">Y coordinate.</param>
    ''' <param name="ds">Detect size, true or false.</param>
    ''' <param name="w">Element width.</param>
    ''' <param name="h">Element height.</param>
    ''' <param name="dir">Directory path.</param>
    ''' <param name="sf">Include subdirectories, true or false.</param>
    ''' <param name="def">Default image.</param>
    ''' <remarks></remarks>
    Private Sub AddToSetget(lt As String, x As Integer, y As Integer, ds As Boolean, w As Integer, h As Integer, dir As String, sf As Boolean, def As String)
        Dim rowLen As Integer = setget.RPControls.GetUpperBound(0)
        Dim colLen As Integer = setget.RPControls.GetUpperBound(1)
        Dim addInd As Integer = 0
        Dim coll As Object() = {lt, "image", x, y, ds, w, h, dir, sf, def} 'added "image" to coll 20230130, rmv if fucked

        'Add a new col to add everything to
        colLen += 1
        ReDim Preserve setget.RPControls(rowLen, colLen)

        For Each i In coll
            setget.RPControls(addInd, colLen - 1) = i
            addInd += 1
        Next
    End Sub

    ''' <summary>
    ''' Adds a shape control to the setget array
    ''' </summary>
    ''' <param name="lt">Label text.</param>
    ''' <param name="x">X coordinate.</param>
    ''' <param name="y">Y coordinate.</param>
    ''' <param name="ds">Detect size, true or false.</param>
    ''' <param name="w">Element width.</param>
    ''' <param name="h">Element height.</param>
    ''' <param name="s">Shape.</param>
    ''' <param name="oC">Outline color.</param>
    ''' <param name="oA">Outline alpha.</param>
    ''' <param name="t">Outline line thickness</param>
    ''' <param name="fC">Fill color.</param>
    ''' <param name="fA">Fill alpha.</param>
    ''' <remarks></remarks>
    Private Sub AddToSetget(lt As String, x As Integer, y As Integer, ds As Boolean, w As Integer, h As Integer, s As String, oC As Color, oA As Integer, t As Integer, fC As Color, fA As Integer)
        Dim rowLen As Integer = setget.RPControls.GetUpperBound(0)
        Dim colLen As Integer = setget.RPControls.GetUpperBound(1)
        Dim addInd As Integer = 0
        Dim coll As Object() = {lt, "shape", x, y, ds, w, h, s, oC, oA, t, fC, fA}

        'Add a new col to add everything to
        colLen += 1
        ReDim Preserve setget.RPControls(rowLen, colLen)

        For Each i In coll
            setget.RPControls(addInd, colLen - 1) = i
            addInd += 1
        Next
    End Sub

    ''' <summary>
    ''' Edits an existing text control in the setget array by utilizing the provided row index.
    ''' </summary>
    ''' <param name="r">TableLayoutPanel row index.</param>
    ''' <param name="lt">Label text.</param>
    ''' <param name="x">X coordinate.</param>
    ''' <param name="y">Y coordinate.</param>
    ''' <param name="ds">Detect size, true or false.</param>
    ''' <param name="w">Element width.</param>
    ''' <param name="h">Element height.</param>
    ''' <param name="ml">Multi-line, true or false.</param>
    ''' <param name="ln">Number of lines.</param>
    ''' <param name="f">Text font.</param>
    ''' <param name="mC">Text color.</param>
    ''' <param name="mA">Text alpha (transparency).</param>
    ''' <param name="al">Alignment.</param>
    ''' <param name="sB">Shadow, true or false.</param>
    ''' <param name="sC">Text shadow color.</param>
    ''' <param name="sA">Text shadow alpha (transparency).</param>
    ''' <param name="dis">Text shadow distance from text.</param>
    ''' <param name="rot">Text shadow rotation from text.</param>
    ''' <param name="def">Default text.</param>
    ''' <remarks></remarks>
    Private Sub EditSetget(r As Integer, lt As String, x As Integer, y As Integer, ds As Boolean, w As Integer, h As Integer, ml As Boolean, ln As Integer, f As Font, mC As Color, mA As Integer, al As String, sB As Boolean, sC As Color, sA As Integer, dis As Integer, rot As Integer, def As String)
        Dim coll As Object() = {lt, "text", x, y, ds, w, h, ml, ln, f, mC, mA, al, sB, sC, sA, dis, rot, def} 'added "text" to coll 20230130, rmv if fucked

        For i As Integer = 0 To coll.Length - 1
            setget.RPControls(i, r) = coll(i)
        Next
    End Sub

    ''' <summary>
    ''' Edits an existing image control in the setget array by utilizing the provided row index.
    ''' </summary>
    ''' <param name="r">TableLayoutPanel row index.</param>
    ''' <param name="lt">Label text.</param>
    ''' <param name="x">X coordinate.</param>
    ''' <param name="y">Y coordinate.</param>
    ''' <param name="ds">Detect size, true or false.</param>
    ''' <param name="w">Element width.</param>
    ''' <param name="h">Element height.</param>
    ''' <param name="dir">Directory path.</param>
    ''' <param name="sf">Include subdirectories, true or false.</param>
    ''' <param name="def">Default image.</param>
    ''' <remarks></remarks>
    Private Sub EditSetget(r As Integer, lt As String, x As Integer, y As Integer, ds As Boolean, w As Integer, h As Integer, dir As String, sf As Boolean, def As String)
        Dim coll As Object() = {lt, "image", x, y, ds, w, h, dir, sf, def} 'added "image" to coll 20230130, rmv if fucked

        For i As Integer = 0 To coll.Length - 1
            setget.RPControls(i, r) = coll(i)
        Next
    End Sub

    ''' <summary>
    ''' Edits an existing shape control in the setget array by utilizing the provided row index.
    ''' </summary>
    ''' <param name="r">TableLayoutPanel row index.</param>
    ''' <param name="lt">Label text.</param>
    ''' <param name="x">X coordinate.</param>
    ''' <param name="y">Y coordinate.</param>
    ''' <param name="ds">Detect size, true or false.</param>
    ''' <param name="w">Element width.</param>
    ''' <param name="h">Element height.</param>
    ''' <param name="s">Shape.</param>
    ''' <param name="oC">Outline color.</param>
    ''' <param name="oA">Outline alpha.</param>
    ''' <param name="t">Outline line thickness</param>
    ''' <param name="fC">Fill color.</param>
    ''' <param name="fA">Fill alpha.</param>
    ''' <remarks></remarks>
    Private Sub EditSetget(r As Integer, lt As String, x As Integer, y As Integer, ds As Boolean, w As Integer, h As Integer, s As String, oC As Color, oA As Integer, t As Integer, fC As Color, fA As Integer)
        Dim coll As Object() = {lt, "shape", x, y, ds, w, h, s, oC, oA, t, fC, fA}

        For i As Integer = 0 To coll.Length - 1
            setget.RPControls(i, r) = coll(i)
        Next
    End Sub

    ''' <summary>
    ''' Removes a row from the setget by searching for the associated label. Less efficient and can probably be deleted (to-do).
    ''' </summary>
    ''' <param name="lt">Label text.</param>
    ''' <remarks></remarks>
    Private Sub RemoveFromSetget(lt As String)
        'This function can probably be deleted (to-do).
        Dim rowLen As Integer = setget.RPControls.GetUpperBound(0)
        Dim colLen As Integer = setget.RPControls.GetUpperBound(1)
        Dim found As Boolean = False
        'Find the desired item's index in the array

        'Search array for label text that matches
        For i As Integer = 0 To colLen
            If found = True OrElse lt = setget.RPControls(0, i).ToString Then 'If the label was/is found,
                For j As Integer = 0 To rowLen - 1 'Remove the desired row from the array by shifting all items up
                    If i < colLen - 1 Then 'if i is less than the max col index then copy the next col down to it
                        setget.RPControls(j, i) = setget.RPControls(j, i + 1)
                        found = True
                    Else 'if it's equal, then we're done here. resize the array, removing the current index
                        ReDim Preserve setget.RPControls(rowLen, i) 'removes everything including the specified index
                        Return
                    End If
                Next
            End If
        Next
        'If nothing matches, fuck yourself I guess

    End Sub

    ''' <summary>
    ''' Removes a row from the setget by searching for the associated TableLayoutPanel row.
    ''' </summary>
    ''' <param name="r">TableLayoutPanel row index.</param>
    ''' <remarks></remarks>
    Private Sub RemoveFromSetget(r As Integer)
        Dim rowLen As Integer = setget.RPControls.GetUpperBound(0)
        Dim colLen As Integer = setget.RPControls.GetUpperBound(1)
        Dim colInd As Integer = r 'subtract the number of header rows

        For i As Integer = colInd To colLen - 2
            For j As Integer = 0 To rowLen - 1
                setget.RPControls(j, i) = setget.RPControls(j, i + 1)
            Next
        Next
        ReDim Preserve setget.RPControls(rowLen, colLen - 1)
    End Sub

    ''' <summary>
    ''' Receives data from the file and inserts it into the DataGridView. This method requires a file of the ".js" extension.
    ''' </summary>
    ''' <param name="filepath">Path of file being extracted.</param>
    ''' <remarks></remarks>

    Private Sub JSFileDataLoader(filepath As String)
        If filepath.ToLower.EndsWith(".js") <> True Then
            MessageBox.Show("Error in JSFileDataLoader: unexpected file extension. Aborting import process.", "Invalid File Extension", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

        Cursor = Cursors.WaitCursor

        'receive file contents
        Dim fileContents As String = My.Computer.FileSystem.ReadAllText(filepath)

        '--------------------------------------
        'collect all headers from file contents
        'Dim headers As String() = {}
        Dim cardStart As Integer = fileContents.IndexOf("{"c)
        Dim cardEnd As Integer = fileContents.IndexOf("}"c)
        Dim i As Integer = cardStart

        Dim headerStart, headerEnd As Integer 'cardStart, cardEnd, 
        Dim foundHeader As String = String.Empty
        Dim alreadyExists As Boolean = False

        While i < cardEnd
            If cardStart <> -1 And cardEnd <> -1 Then
                headerStart = fileContents.IndexOf(""""c, i)
                headerEnd = fileContents.IndexOf(""""c, headerStart + 1)

                If headerStart > cardEnd Then
                    cardStart = fileContents.IndexOf("{"c, i)
                    cardEnd = fileContents.IndexOf("}"c, cardStart)
                ElseIf headerStart <> -1 And headerEnd <> -1 Then
                    'if header doesn't match any existing entries, add to list
                    foundHeader = fileContents.Substring(headerStart + 1, headerEnd - headerStart - 1)
                    For Each item In setget.ImportHeaders
                        If item IsNot Nothing AndAlso item.ToLower = foundHeader Then
                            alreadyExists = True
                        End If
                    Next
                    If alreadyExists = False Then
                        ReDim Preserve setget.ImportHeaders(setget.ImportHeaders.Length)
                        setget.ImportHeaders(setget.ImportHeaders.Length - 1) = foundHeader
                    Else
                        alreadyExists = False
                    End If

                    i = fileContents.IndexOf(vbLf, headerEnd)
                End If
            End If
            i += 1
        End While

        '--------------------------------------
        'if headers don't match the DataGridView, warn that something ain't right, buddy
        'eventually we want to add a "conversion" feature so that incompatibility can be resolved on the spot
        'this can almost entirely be shared with HCLFileDataLoader, as the headers should be stored the same in setget (to-do)
        i = 0
        Dim allMatch As Boolean = True
        For Each col As DataGridViewColumn In DataGridView1.Columns
            If allMatch = True AndAlso col IsNot Nothing AndAlso setget.ImportHeaders(i) IsNot Nothing AndAlso col.HeaderText.ToLower <> setget.ImportHeaders(i).ToLower Then
                allMatch = False
            End If
        Next
        Dim colConv As New ColumnConversion
        colConv.ShowDialog()

        '--------------------------------------
        'if headers are sufficiently matched, go ahead with importing data to datagridview
        Dim headerI As Integer = 0 'index inside of filecontents
        Dim headerJ As Integer = 0 'index inside of setget
        Dim header As String = String.Empty
        Dim valueStartI As Integer = 0
        Dim valueEndI As Integer = 0
        Dim value As String = String.Empty
        Dim row As String() = {}
        ReDim row(colConv.ImportedColumnsListBox.Items.Count)

        If colConv.DialogResult = DialogResult.OK Then

            cardStart = fileContents.IndexOf("{"c)
            cardEnd = fileContents.IndexOf("}"c)
            i = cardStart

            While i < cardEnd
                If i <> -1 And cardEnd <> -1 Then
                    'add a DataGridView row
                    For Each h In colConv.ImportedColumnsListBox.Items 'setget._ImportHeaders
                        If h IsNot Nothing AndAlso h.ToString <> String.Empty Then
                            header = """" & h.ToString & """: "
                            headerJ = colConv.ImportedColumnsListBox.Items.IndexOf(h) 'GetIndexOfHeader(setget.ImportHeaders, h)

                            'if the header is contained within the card, process its value
                            headerI = fileContents.IndexOf(header, i)
                            If headerI <> -1 Then
                                'skip the quotation mark if it's the first character of the value
                                valueStartI = headerI + header.Length
                                valueEndI = fileContents.IndexOf(vbLf, headerI)
                                If fileContents.Chars(valueStartI) = """" Then
                                    valueStartI += 1
                                    valueEndI -= 1
                                End If

                                'IF the header exists within the card
                                If headerI < cardEnd Then
                                    value = fileContents.Substring(valueStartI, valueEndI - valueStartI - 1)
                                    row(headerJ) = value
                                End If
                            End If
                        End If
                    Next
                End If
                DataGridView1.Rows.Add(row)
                ReDim row(colConv.ImportedColumnsListBox.Items.Count)

                i = fileContents.IndexOf("{"c, cardEnd)
                If i = -1 Then
                    cardEnd = -1
                Else
                    cardEnd = fileContents.IndexOf("}"c, i)
                End If
            End While
        End If

        '--------------------------------------
        'clean up after yourself u dirty animal
        ReDim setget.ImportHeaders(0)
        setget.ImportHeaders = {}
        Cursor = Cursors.Default
    End Sub

    ''' <summary>
    ''' Receives data from the file and inserts it into the DataGridView. This method requires a file of the ".hcl" extension.
    ''' </summary>
    ''' <param name="filepath">Path of file being extracted.</param>
    ''' <remarks></remarks>

    Private Sub HCLFileDataLoader(filepath As String)
        If filepath.ToLower.EndsWith(".hcl") <> True Then
            MessageBox.Show("Error in HCLFileDataLoader: unexpected file extension. Aborting import process.", "Invalid File Extension", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

        Cursor.Current = Cursors.WaitCursor
        Dim fileContents As String = My.Computer.FileSystem.ReadAllText(filepath)


        Cursor.Current = Cursors.Default
    End Sub

    ''' <summary>
    ''' Accepts a String array and returns the index of the given String. Returns a -1 if not found.
    ''' </summary>
    ''' <param name="list">List of strings.</param>
    ''' <param name="s">Desired string.</param>
    Private Function GetIndexOfHeader(ByVal list As String(), ByVal s As String) As Integer
        Dim index As Integer = 0
        For Each i In list
            If i = s Then
                Return index
            Else
                index += 1
            End If
        Next
        Return -1
    End Function

    ''' <summary>
    ''' Adds a text control to the table, setget, and datagridview.
    ''' </summary>
    ''' <param name="tlp">Destination TableLayoutPanel.</param>
    ''' <param name="lt">Label text.</param>
    ''' <param name="x">X coordinate.</param>
    ''' <param name="y">Y coordinate.</param>
    ''' <param name="ds">Detect size, true or false.</param>
    ''' <param name="w">Element width.</param>
    ''' <param name="h">Element height.</param>
    ''' <param name="ml">Multi-line, true or false.</param>
    ''' <param name="ln">Number of lines.</param>
    ''' <param name="f">Text font.</param>
    ''' <param name="mC">Text color.</param>
    ''' <param name="mA">Text alpha (transparency).</param>
    ''' <param name="al">Alignment.</param>
    ''' <param name="sB">Shadow, true or false.</param>
    ''' <param name="sC">Text shadow color.</param>
    ''' <param name="sA">Text shadow alpha (transparency).</param>
    ''' <param name="dis">Text shadow distance from text.</param>
    ''' <param name="rot">Text shadow rotation from text.</param>
    ''' <param name="def">Default text.</param>
    ''' <remarks></remarks>
    Private Sub AddControlToTable(tlp As TableLayoutPanel, lt As String, x As Integer, y As Integer, ds As Boolean, w As Integer, h As Integer, ml As Boolean, ln As Integer, f As Font, mC As Color, mA As Integer, al As String, sB As Boolean, sC As Color, sA As Integer, dis As Integer, rot As Integer, def As String)
        'check for dupes at some point

        Dim tb As New TextBox With {
            .Text = lt
        }
        Dim lab As Label = NewControlLabel(tb)
        ControlsTableLayoutPanel.Controls.Add(lab)

        Dim nc As Control = NewTextBoxControl(ln, ml)
        nc.Text = def

        'add control to setget
        AddToSetget(lt,
                        x,
                        y,
                        ds,
                        w,
                        h,
                        ml,
                        ln,
                        f,
                        mC,
                        mA,
                        al,
                        sB,
                        sC,
                        sA,
                        dis,
                        rot,
                        def)
        tlp.Controls.Add(nc)

        'Add new field to DataGridView
        DataGridView1.Columns.Add(lt, lt)

        tlp.RowCount += 1
    End Sub

    ''' <summary>
    ''' Adds an image control to the table, setget, and datagridview.
    ''' </summary>
    ''' <param name="tlp">Destination TableLayoutPanel.</param>
    ''' <param name="lt">Label text.</param>
    ''' <param name="x">X coordinate.</param>
    ''' <param name="y">Y coordinate.</param>
    ''' <param name="ds">Detect size, true or false.</param>
    ''' <param name="w">Element width.</param>
    ''' <param name="h">Element height.</param>
    ''' <param name="dir">Directory path.</param>
    ''' <param name="sf">Include subdirectories, true or false.</param>
    ''' <param name="def">Default image.</param>
    ''' <remarks></remarks>
    Private Sub AddControlToTable(tlp As TableLayoutPanel, lt As String, x As Integer, y As Integer, ds As Boolean, w As Integer, h As Integer, dir As String, sf As Boolean, def As String)
        'check for dupes at some point

        Dim tb As New TextBox With {
            .Text = lt
        }
        Dim lab As Label = NewControlLabel(tb)
        ControlsTableLayoutPanel.Controls.Add(lab)

        Dim nc As Control = NewComboBoxControl(dir, sf)
        nc.Text = def

        'add control to setget
        AddToSetget(lt,
                        x,
                        y,
                        ds,
                        w,
                        h,
                        dir,
                        sf,
                        def)
        tlp.Controls.Add(nc)

        'Add new field to DataGridView
        DataGridView1.Columns.Add(lt, lt)

        tlp.RowCount += 1
    End Sub

    ''' <summary>
    ''' Adds a shape control to the table, setget, and datagridview.
    ''' </summary>
    ''' <param name="lt">Label text.</param>
    ''' <param name="x">X coordinate.</param>
    ''' <param name="y">Y coordinate.</param>
    ''' <param name="ds">Detect size, true or false.</param>
    ''' <param name="w">Element width.</param>
    ''' <param name="h">Element height.</param>
    ''' <param name="s">Shape.</param>
    ''' <param name="oC">Outline color.</param>
    ''' <param name="oA">Outline alpha.</param>
    ''' <param name="t">Outline line thickness</param>
    ''' <param name="fC">Fill color.</param>
    ''' <param name="fA">Fill alpha.</param>
    ''' <remarks></remarks>
    Private Sub AddControlToTable(tlp As TableLayoutPanel, lt As String, x As Integer, y As Integer, ds As Boolean, w As Integer, h As Integer, s As String, oC As Color, oA As Integer, t As Integer, fC As Color, fA As Integer)
        'check for dupes at some point

        Dim tb As New TextBox With {
            .Text = lt
        }
        Dim lab As Label = NewControlLabel(tb)
        ControlsTableLayoutPanel.Controls.Add(lab)

        Dim nc As Control = NewLabelControl("[Shape Object]") 'the label control exists only to take up space

        'add control to setget
        AddToSetget(lt,
                        x,
                        y,
                        ds,
                        w,
                        h,
                        s,
                        oC,
                        oA,
                        t,
                        fC,
                        fA)
        tlp.Controls.Add(nc)

        'Add new field to DataGridView
        DataGridView1.Columns.Add(lt, lt)

        tlp.RowCount += 1
    End Sub

    Private Sub ConditionsButton_Click(sender As Object, e As EventArgs) Handles ConditionsButton.Click
        Dim conditions As New Conditions

        If conditions.ShowDialog() = DialogResult.OK Then
            ReDim setget.Conditions(9, 0)
            Dim condCol As Integer = 0
            For Each r As DataGridViewRow In conditions.ConditionsDataGridView.Rows
                For Each c As DataGridViewCell In r.Cells
                    setget.Conditions(condCol, setget.Conditions.GetUpperBound(1)) = c.Value.ToString
                    condCol += 1
                Next
                condCol = 0
                ReDim Preserve setget.Conditions(9, setget.Conditions.GetUpperBound(1) + 1)
            Next

            'when pressed, handle this in either the conditions form or here
            'handling will add the contents of the gridview to a "Conditions" array in setget
            'whenever the image is processed, it will refer to this "Conditions" array for alterations and override values based on it
            'Conditions should be saved with the template, as not every template should have the same conditions.
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cardProperties As New CardProperties

        If cardProperties.ShowDialog() = DialogResult.OK Then
            ReDim setget.CardProperties(2)

            setget.CardProperties(0) = CInt(cardProperties.WidthNumericUpDown.Value)
            setget.CardProperties(1) = CInt(cardProperties.HeightNumericUpDown.Value)
        End If
    End Sub

    Private Sub CardDeckToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CardDeckToolStripMenuItem.Click
        'open deck export window
        Dim deckExportSettings As New DeckExportSettings

        If deckExportSettings.ShowDialog() <> DialogResult.OK Then
            MessageBox.Show("Export Aborted", "Deck export operation aborted.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        'retrieve deck name and dimensions
        Dim deckName As String = deckExportSettings.NameTextBox.Text
        Dim rows As Integer = CInt(deckExportSettings.RowsNumericUpDown.Value)
        Dim columns As Integer = CInt(deckExportSettings.ColumnsNumericUpDown.Value)

        'create new deck text
        Dim source As String = "{" & vbNewLine &
            vbTab & """SaveName"": """"," & vbNewLine &
            vbTab & """Date"": """"," & vbNewLine &
            vbTab & """VersionNumber"": """"," & vbNewLine &
            vbTab & """GameMode"": """"," & vbNewLine &
            vbTab & """GameType"": """"," & vbNewLine &
            vbTab & """GameComplexity"": """"," & vbNewLine &
            vbTab & """Tags"": []," & vbNewLine &
            vbTab & """Gravity"": 0.5," & vbNewLine &
            vbTab & """PlayArea"": 0.5," & vbNewLine &
            vbTab & """Table"": """"," & vbNewLine &
            vbTab & """Sky"": """"," & vbNewLine &
            vbTab & """Note"": """"," & vbNewLine &
            vbTab & """TabStates"": {}," & vbNewLine &
            vbTab & """LuaScript"": """"," & vbNewLine &
            vbTab & """LuaScriptState"": """"," & vbNewLine &
            vbTab & """XmlUI"": """"," & vbNewLine &
            vbTab & """ObjectStates"": [" & vbNewLine &
            vbTab & vbTab & "{" & vbNewLine &
            vbTab & vbTab & vbTab & """GUID"": ""," & vbNewLine &
            vbTab & vbTab & vbTab & """Name"": ""DeckCustom""," & vbNewLine &
            vbTab & vbTab & vbTab & """Transform"": {" & vbNewLine &
            vbTab & vbTab & vbTab & vbTab & """posX"" 1.43949883E-05," & vbNewLine &
            vbTab & vbTab & vbTab & vbTab & """posY"" 1.770505," & vbNewLine &
            vbTab & vbTab & vbTab & vbTab & """posZ"" -0.0228565745," & vbNewLine &
            vbTab & vbTab & vbTab & vbTab & """rotX"" 0.8464598," & vbNewLine &
            vbTab & vbTab & vbTab & vbTab & """rotY"" 180.001648," & vbNewLine &
            vbTab & vbTab & vbTab & vbTab & """rotZ"" 179.9998," & vbNewLine &
            vbTab & vbTab & vbTab & vbTab & """scaleX"" 0.693170249," & vbNewLine &
            vbTab & vbTab & vbTab & vbTab & """scaleY"" 1.0," & vbNewLine &
            vbTab & vbTab & vbTab & vbTab & """scaleZ"": 0.693170249" & vbNewLine &
            vbTab & vbTab & vbTab & "}," & vbNewLine &
            vbTab & vbTab & vbTab & """Nickname"": """"," & vbNewLine &
            vbTab & vbTab & vbTab & """Description"": """"," & vbNewLine &
            vbTab & vbTab & vbTab & """GMNotes"": """"," & vbNewLine &
            vbTab & vbTab & vbTab & """ColorDiffuse"": {" & vbNewLine &
            vbTab & vbTab & vbTab & vbTab & """r"": 0.713235259," & vbNewLine &
            vbTab & vbTab & vbTab & vbTab & """g"": 0.713235259," & vbNewLine &
            vbTab & vbTab & vbTab & vbTab & """b"": 0.713235259" & vbNewLine &
            vbTab & vbTab & vbTab & "}," & vbNewLine &
            vbTab & vbTab & vbTab & """LayoutGroupSortIndex"": 0," & vbNewLine &
            vbTab & vbTab & vbTab & """Value"": 0," & vbNewLine &
            vbTab & vbTab & vbTab & """Locked"": false," & vbNewLine &
            vbTab & vbTab & vbTab & """Grid"": true," & vbNewLine &
            vbTab & vbTab & vbTab & """Snap"": true," & vbNewLine &
            vbTab & vbTab & vbTab & """IgnoreFoW"": false," & vbNewLine &
            vbTab & vbTab & vbTab & """MeasureMovement"": false," & vbNewLine &
            vbTab & vbTab & vbTab & """DragSelectable"": true," & vbNewLine &
            vbTab & vbTab & vbTab & """Autoraise"": true," & vbNewLine &
            vbTab & vbTab & vbTab & """Sticky"": true," & vbNewLine &
            vbTab & vbTab & vbTab & """Tooltip"": true," & vbNewLine &
            vbTab & vbTab & vbTab & """GridProjection"": false," & vbNewLine &
            vbTab & vbTab & vbTab & """HideWhenFaceDown"": true," & vbNewLine &
            vbTab & vbTab & vbTab & """Hands"": false," & vbNewLine &
            vbTab & vbTab & vbTab & """SidewaysCard"": false," & vbNewLine &
            vbTab & vbTab & vbTab & """DeckIDs"": [" & vbNewLine

        'There's got to be a better way of doing this (to-do)
        'Adding a number for each unique card
        'Formatting goes as follows: ABB (A = sheet, BB = card # (1-70))
        Dim maxCount As Integer = rows * columns
        Dim cardCount As Integer = DataGridView1.Rows.Count
        Dim numOfSheets As Integer = 1

        While numOfSheets > 0
            For i As Integer = 1 To cardCount
                source &= vbTab & vbTab & vbTab & vbTab & ((numOfSheets * 100) + i).ToString
            Next
            cardCount -= maxCount
            If cardCount < 0 Then
                numOfSheets = 0
                source &= vbNewLine
            Else
                numOfSheets += 1
                source &= "," & vbNewLine
            End If
        End While

        'Export images into sheets (to-do)
        ExportAllCards()


        'Prompt user for uploaded sheet URL (to-do)

        'Add more hardcoded text
        source &= vbTab & vbTab & vbTab & "]," & vbNewLine &
            vbTab & vbTab & vbTab & """CustomDeck"": {" & vbNewLine

        'Add each individual sheet and its child cards
        For j As Integer = 1 To numOfSheets
            source &= vbTab & vbTab & vbTab & vbTab & """" & j & """: {" & vbNewLine &
                 vbTab & vbTab & vbTab & vbTab & vbTab & """FaceURL"": "
            'insert sheet URL

        Next
    End Sub
End Class

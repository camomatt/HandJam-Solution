<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColumnConversion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ExistingColumnsGroupBox = New System.Windows.Forms.GroupBox()
        Me.RemoveExistingColumnButton = New System.Windows.Forms.Button()
        Me.AddExistingColumnButton = New System.Windows.Forms.Button()
        Me.MoveDownExistingColumnButton = New System.Windows.Forms.Button()
        Me.MoveUpExistingColumnButton = New System.Windows.Forms.Button()
        Me.ExistingColumnsListBox = New System.Windows.Forms.ListBox()
        Me.ImportedColumnsGroupBox = New System.Windows.Forms.GroupBox()
        Me.RemoveImportedColumnButton = New System.Windows.Forms.Button()
        Me.AddImportedColumnButton = New System.Windows.Forms.Button()
        Me.MoveDownImportedColumnButton = New System.Windows.Forms.Button()
        Me.MoveUpImportedColumnButton = New System.Windows.Forms.Button()
        Me.ImportedColumnsListBox = New System.Windows.Forms.ListBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.ExistingColumnsGroupBox.SuspendLayout()
        Me.ImportedColumnsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExistingColumnsGroupBox
        '
        Me.ExistingColumnsGroupBox.Controls.Add(Me.RemoveExistingColumnButton)
        Me.ExistingColumnsGroupBox.Controls.Add(Me.AddExistingColumnButton)
        Me.ExistingColumnsGroupBox.Controls.Add(Me.MoveDownExistingColumnButton)
        Me.ExistingColumnsGroupBox.Controls.Add(Me.MoveUpExistingColumnButton)
        Me.ExistingColumnsGroupBox.Controls.Add(Me.ExistingColumnsListBox)
        Me.ExistingColumnsGroupBox.Location = New System.Drawing.Point(13, 13)
        Me.ExistingColumnsGroupBox.Name = "ExistingColumnsGroupBox"
        Me.ExistingColumnsGroupBox.Size = New System.Drawing.Size(201, 253)
        Me.ExistingColumnsGroupBox.TabIndex = 0
        Me.ExistingColumnsGroupBox.TabStop = False
        Me.ExistingColumnsGroupBox.Text = "Existing Columns"
        '
        'RemoveExistingColumnButton
        '
        Me.RemoveExistingColumnButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveExistingColumnButton.ForeColor = System.Drawing.Color.Red
        Me.RemoveExistingColumnButton.Location = New System.Drawing.Point(171, 48)
        Me.RemoveExistingColumnButton.Name = "RemoveExistingColumnButton"
        Me.RemoveExistingColumnButton.Size = New System.Drawing.Size(23, 23)
        Me.RemoveExistingColumnButton.TabIndex = 4
        Me.RemoveExistingColumnButton.Text = "-"
        Me.RemoveExistingColumnButton.UseVisualStyleBackColor = True
        '
        'AddExistingColumnButton
        '
        Me.AddExistingColumnButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddExistingColumnButton.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.AddExistingColumnButton.Location = New System.Drawing.Point(171, 19)
        Me.AddExistingColumnButton.Name = "AddExistingColumnButton"
        Me.AddExistingColumnButton.Size = New System.Drawing.Size(23, 23)
        Me.AddExistingColumnButton.TabIndex = 3
        Me.AddExistingColumnButton.Text = "+"
        Me.AddExistingColumnButton.UseVisualStyleBackColor = True
        '
        'MoveDownExistingColumnButton
        '
        Me.MoveDownExistingColumnButton.Location = New System.Drawing.Point(171, 106)
        Me.MoveDownExistingColumnButton.Name = "MoveDownExistingColumnButton"
        Me.MoveDownExistingColumnButton.Size = New System.Drawing.Size(23, 23)
        Me.MoveDownExistingColumnButton.TabIndex = 2
        Me.MoveDownExistingColumnButton.Text = "🡇"
        Me.MoveDownExistingColumnButton.UseVisualStyleBackColor = True
        '
        'MoveUpExistingColumnButton
        '
        Me.MoveUpExistingColumnButton.Location = New System.Drawing.Point(171, 77)
        Me.MoveUpExistingColumnButton.Name = "MoveUpExistingColumnButton"
        Me.MoveUpExistingColumnButton.Size = New System.Drawing.Size(23, 23)
        Me.MoveUpExistingColumnButton.TabIndex = 1
        Me.MoveUpExistingColumnButton.Text = "🡅"
        Me.MoveUpExistingColumnButton.UseVisualStyleBackColor = True
        '
        'ExistingColumnsListBox
        '
        Me.ExistingColumnsListBox.FormattingEnabled = True
        Me.ExistingColumnsListBox.Location = New System.Drawing.Point(7, 20)
        Me.ExistingColumnsListBox.Name = "ExistingColumnsListBox"
        Me.ExistingColumnsListBox.Size = New System.Drawing.Size(158, 225)
        Me.ExistingColumnsListBox.TabIndex = 0
        '
        'ImportedColumnsGroupBox
        '
        Me.ImportedColumnsGroupBox.Controls.Add(Me.RemoveImportedColumnButton)
        Me.ImportedColumnsGroupBox.Controls.Add(Me.AddImportedColumnButton)
        Me.ImportedColumnsGroupBox.Controls.Add(Me.MoveDownImportedColumnButton)
        Me.ImportedColumnsGroupBox.Controls.Add(Me.MoveUpImportedColumnButton)
        Me.ImportedColumnsGroupBox.Controls.Add(Me.ImportedColumnsListBox)
        Me.ImportedColumnsGroupBox.Location = New System.Drawing.Point(220, 13)
        Me.ImportedColumnsGroupBox.Name = "ImportedColumnsGroupBox"
        Me.ImportedColumnsGroupBox.Size = New System.Drawing.Size(201, 253)
        Me.ImportedColumnsGroupBox.TabIndex = 5
        Me.ImportedColumnsGroupBox.TabStop = False
        Me.ImportedColumnsGroupBox.Text = "Imported Columns"
        '
        'RemoveImportedColumnButton
        '
        Me.RemoveImportedColumnButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveImportedColumnButton.ForeColor = System.Drawing.Color.Red
        Me.RemoveImportedColumnButton.Location = New System.Drawing.Point(171, 48)
        Me.RemoveImportedColumnButton.Name = "RemoveImportedColumnButton"
        Me.RemoveImportedColumnButton.Size = New System.Drawing.Size(23, 23)
        Me.RemoveImportedColumnButton.TabIndex = 4
        Me.RemoveImportedColumnButton.Text = "-"
        Me.RemoveImportedColumnButton.UseVisualStyleBackColor = True
        '
        'AddImportedColumnButton
        '
        Me.AddImportedColumnButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddImportedColumnButton.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.AddImportedColumnButton.Location = New System.Drawing.Point(171, 19)
        Me.AddImportedColumnButton.Name = "AddImportedColumnButton"
        Me.AddImportedColumnButton.Size = New System.Drawing.Size(23, 23)
        Me.AddImportedColumnButton.TabIndex = 3
        Me.AddImportedColumnButton.Text = "+"
        Me.AddImportedColumnButton.UseVisualStyleBackColor = True
        '
        'MoveDownImportedColumnButton
        '
        Me.MoveDownImportedColumnButton.Location = New System.Drawing.Point(171, 106)
        Me.MoveDownImportedColumnButton.Name = "MoveDownImportedColumnButton"
        Me.MoveDownImportedColumnButton.Size = New System.Drawing.Size(23, 23)
        Me.MoveDownImportedColumnButton.TabIndex = 2
        Me.MoveDownImportedColumnButton.Text = "🡇"
        Me.MoveDownImportedColumnButton.UseVisualStyleBackColor = True
        '
        'MoveUpImportedColumnButton
        '
        Me.MoveUpImportedColumnButton.Location = New System.Drawing.Point(171, 77)
        Me.MoveUpImportedColumnButton.Name = "MoveUpImportedColumnButton"
        Me.MoveUpImportedColumnButton.Size = New System.Drawing.Size(23, 23)
        Me.MoveUpImportedColumnButton.TabIndex = 1
        Me.MoveUpImportedColumnButton.Text = "🡅"
        Me.MoveUpImportedColumnButton.UseVisualStyleBackColor = True
        '
        'ImportedColumnsListBox
        '
        Me.ImportedColumnsListBox.FormattingEnabled = True
        Me.ImportedColumnsListBox.Location = New System.Drawing.Point(7, 20)
        Me.ImportedColumnsListBox.Name = "ImportedColumnsListBox"
        Me.ImportedColumnsListBox.Size = New System.Drawing.Size(158, 225)
        Me.ImportedColumnsListBox.TabIndex = 0
        '
        'OKButton
        '
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OKButton.Enabled = False
        Me.OKButton.Location = New System.Drawing.Point(179, 272)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 6
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'ColumnConversion
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 301)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.ImportedColumnsGroupBox)
        Me.Controls.Add(Me.ExistingColumnsGroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ColumnConversion"
        Me.ShowIcon = False
        Me.Text = "Column Matching"
        Me.ExistingColumnsGroupBox.ResumeLayout(False)
        Me.ImportedColumnsGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ExistingColumnsGroupBox As GroupBox
    Friend WithEvents RemoveExistingColumnButton As Button
    Friend WithEvents AddExistingColumnButton As Button
    Friend WithEvents MoveDownExistingColumnButton As Button
    Friend WithEvents MoveUpExistingColumnButton As Button
    Friend WithEvents ExistingColumnsListBox As ListBox
    Friend WithEvents ImportedColumnsGroupBox As GroupBox
    Friend WithEvents RemoveImportedColumnButton As Button
    Friend WithEvents AddImportedColumnButton As Button
    Friend WithEvents MoveDownImportedColumnButton As Button
    Friend WithEvents MoveUpImportedColumnButton As Button
    Friend WithEvents ImportedColumnsListBox As ListBox
    Friend WithEvents OKButton As Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Conditions
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
        Me.ConditionsDataGridView = New System.Windows.Forms.DataGridView()
        Me.Value1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Value1Attribute = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comparison = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Value2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Value2Attribute = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Target = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TargetAttribute = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Source = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SourceAttribute = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Value1ControlComboBox = New System.Windows.Forms.ComboBox()
        Me.ParametersGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SourceStaticRadioButton = New System.Windows.Forms.RadioButton()
        Me.SourceControlRadioButton = New System.Windows.Forms.RadioButton()
        Me.Value2GroupBox = New System.Windows.Forms.GroupBox()
        Me.Value2StaticRadioButton = New System.Windows.Forms.RadioButton()
        Me.Value2ControlRadioButton = New System.Windows.Forms.RadioButton()
        Me.SourceAttributeComboBox = New System.Windows.Forms.ComboBox()
        Me.SourceControlComboBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TargetAttributeComboBox = New System.Windows.Forms.ComboBox()
        Me.TargetControlComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Value2AttributeComboBox = New System.Windows.Forms.ComboBox()
        Me.Value2ControlComboBox = New System.Windows.Forms.ComboBox()
        Me.OperatorComboBox = New System.Windows.Forms.ComboBox()
        Me.Value1AttributeComboBox = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.AddButton = New System.Windows.Forms.Button()
        Me.EditButton = New System.Windows.Forms.Button()
        Me.RemoveButton = New System.Windows.Forms.Button()
        CType(Me.ConditionsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ParametersGroupBox.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Value2GroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ConditionsDataGridView
        '
        Me.ConditionsDataGridView.AllowUserToAddRows = False
        Me.ConditionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ConditionsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Value1, Me.Value1Attribute, Me.Comparison, Me.Value2, Me.Value2Attribute, Me.Target, Me.TargetAttribute, Me.Source, Me.SourceAttribute})
        Me.ConditionsDataGridView.Location = New System.Drawing.Point(12, 227)
        Me.ConditionsDataGridView.Name = "ConditionsDataGridView"
        Me.ConditionsDataGridView.ReadOnly = True
        Me.ConditionsDataGridView.Size = New System.Drawing.Size(491, 154)
        Me.ConditionsDataGridView.TabIndex = 1
        '
        'Value1
        '
        Me.Value1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Value1.HeaderText = "Value1"
        Me.Value1.Name = "Value1"
        Me.Value1.ReadOnly = True
        Me.Value1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Value1.Width = 65
        '
        'Value1Attribute
        '
        Me.Value1Attribute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.Value1Attribute.HeaderText = "Value1Attribute"
        Me.Value1Attribute.Name = "Value1Attribute"
        Me.Value1Attribute.ReadOnly = True
        Me.Value1Attribute.Width = 5
        '
        'Comparison
        '
        Me.Comparison.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Comparison.HeaderText = "Comparison"
        Me.Comparison.Name = "Comparison"
        Me.Comparison.ReadOnly = True
        Me.Comparison.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Comparison.Width = 20
        '
        'Value2
        '
        Me.Value2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Value2.HeaderText = "Value2"
        Me.Value2.Name = "Value2"
        Me.Value2.ReadOnly = True
        Me.Value2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Value2.Width = 65
        '
        'Value2Attribute
        '
        Me.Value2Attribute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.Value2Attribute.HeaderText = "Value2Attribute"
        Me.Value2Attribute.Name = "Value2Attribute"
        Me.Value2Attribute.ReadOnly = True
        Me.Value2Attribute.Width = 5
        '
        'Target
        '
        Me.Target.HeaderText = "Target"
        Me.Target.Name = "Target"
        Me.Target.ReadOnly = True
        Me.Target.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'TargetAttribute
        '
        Me.TargetAttribute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.TargetAttribute.HeaderText = "TargetAttribute"
        Me.TargetAttribute.Name = "TargetAttribute"
        Me.TargetAttribute.ReadOnly = True
        Me.TargetAttribute.Width = 5
        '
        'Source
        '
        Me.Source.HeaderText = "Source"
        Me.Source.Name = "Source"
        Me.Source.ReadOnly = True
        Me.Source.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'SourceAttribute
        '
        Me.SourceAttribute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.SourceAttribute.HeaderText = "SourceAttribute"
        Me.SourceAttribute.Name = "SourceAttribute"
        Me.SourceAttribute.ReadOnly = True
        Me.SourceAttribute.Width = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "If"
        '
        'Value1ControlComboBox
        '
        Me.Value1ControlComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Value1ControlComboBox.FormattingEnabled = True
        Me.Value1ControlComboBox.Location = New System.Drawing.Point(44, 120)
        Me.Value1ControlComboBox.Name = "Value1ControlComboBox"
        Me.Value1ControlComboBox.Size = New System.Drawing.Size(110, 21)
        Me.Value1ControlComboBox.TabIndex = 2
        '
        'ParametersGroupBox
        '
        Me.ParametersGroupBox.Controls.Add(Me.Label8)
        Me.ParametersGroupBox.Controls.Add(Me.Label9)
        Me.ParametersGroupBox.Controls.Add(Me.Label10)
        Me.ParametersGroupBox.Controls.Add(Me.Label11)
        Me.ParametersGroupBox.Controls.Add(Me.Label6)
        Me.ParametersGroupBox.Controls.Add(Me.Label7)
        Me.ParametersGroupBox.Controls.Add(Me.Label5)
        Me.ParametersGroupBox.Controls.Add(Me.Label4)
        Me.ParametersGroupBox.Controls.Add(Me.GroupBox2)
        Me.ParametersGroupBox.Controls.Add(Me.Value2GroupBox)
        Me.ParametersGroupBox.Controls.Add(Me.SourceAttributeComboBox)
        Me.ParametersGroupBox.Controls.Add(Me.SourceControlComboBox)
        Me.ParametersGroupBox.Controls.Add(Me.Label3)
        Me.ParametersGroupBox.Controls.Add(Me.TargetAttributeComboBox)
        Me.ParametersGroupBox.Controls.Add(Me.TargetControlComboBox)
        Me.ParametersGroupBox.Controls.Add(Me.Label2)
        Me.ParametersGroupBox.Controls.Add(Me.Value2AttributeComboBox)
        Me.ParametersGroupBox.Controls.Add(Me.Value2ControlComboBox)
        Me.ParametersGroupBox.Controls.Add(Me.OperatorComboBox)
        Me.ParametersGroupBox.Controls.Add(Me.Value1AttributeComboBox)
        Me.ParametersGroupBox.Controls.Add(Me.Value1ControlComboBox)
        Me.ParametersGroupBox.Controls.Add(Me.Label1)
        Me.ParametersGroupBox.Location = New System.Drawing.Point(13, 13)
        Me.ParametersGroupBox.Name = "ParametersGroupBox"
        Me.ParametersGroupBox.Size = New System.Drawing.Size(490, 208)
        Me.ParametersGroupBox.TabIndex = 0
        Me.ParametersGroupBox.TabStop = False
        Me.ParametersGroupBox.Text = "Parameters"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(412, 165)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Attribute"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(296, 165)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Source"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(160, 165)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Attribute"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(44, 165)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Target"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(412, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Attribute"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(296, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Value 2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(160, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Attribute"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Value 1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SourceStaticRadioButton)
        Me.GroupBox2.Controls.Add(Me.SourceControlRadioButton)
        Me.GroupBox2.Location = New System.Drawing.Point(398, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(86, 67)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Source Type"
        '
        'SourceStaticRadioButton
        '
        Me.SourceStaticRadioButton.AutoSize = True
        Me.SourceStaticRadioButton.Location = New System.Drawing.Point(7, 43)
        Me.SourceStaticRadioButton.Name = "SourceStaticRadioButton"
        Me.SourceStaticRadioButton.Size = New System.Drawing.Size(52, 17)
        Me.SourceStaticRadioButton.TabIndex = 1
        Me.SourceStaticRadioButton.Text = "Static"
        Me.SourceStaticRadioButton.UseVisualStyleBackColor = True
        '
        'SourceControlRadioButton
        '
        Me.SourceControlRadioButton.AutoSize = True
        Me.SourceControlRadioButton.Checked = True
        Me.SourceControlRadioButton.Location = New System.Drawing.Point(7, 20)
        Me.SourceControlRadioButton.Name = "SourceControlRadioButton"
        Me.SourceControlRadioButton.Size = New System.Drawing.Size(58, 17)
        Me.SourceControlRadioButton.TabIndex = 0
        Me.SourceControlRadioButton.TabStop = True
        Me.SourceControlRadioButton.Text = "Control"
        Me.SourceControlRadioButton.UseVisualStyleBackColor = True
        '
        'Value2GroupBox
        '
        Me.Value2GroupBox.Controls.Add(Me.Value2StaticRadioButton)
        Me.Value2GroupBox.Controls.Add(Me.Value2ControlRadioButton)
        Me.Value2GroupBox.Location = New System.Drawing.Point(306, 19)
        Me.Value2GroupBox.Name = "Value2GroupBox"
        Me.Value2GroupBox.Size = New System.Drawing.Size(86, 67)
        Me.Value2GroupBox.TabIndex = 6
        Me.Value2GroupBox.TabStop = False
        Me.Value2GroupBox.Text = "Value 2 Type"
        '
        'Value2StaticRadioButton
        '
        Me.Value2StaticRadioButton.AutoSize = True
        Me.Value2StaticRadioButton.Location = New System.Drawing.Point(7, 43)
        Me.Value2StaticRadioButton.Name = "Value2StaticRadioButton"
        Me.Value2StaticRadioButton.Size = New System.Drawing.Size(52, 17)
        Me.Value2StaticRadioButton.TabIndex = 1
        Me.Value2StaticRadioButton.Text = "Static"
        Me.Value2StaticRadioButton.UseVisualStyleBackColor = True
        '
        'Value2ControlRadioButton
        '
        Me.Value2ControlRadioButton.AutoSize = True
        Me.Value2ControlRadioButton.Checked = True
        Me.Value2ControlRadioButton.Location = New System.Drawing.Point(7, 20)
        Me.Value2ControlRadioButton.Name = "Value2ControlRadioButton"
        Me.Value2ControlRadioButton.Size = New System.Drawing.Size(58, 17)
        Me.Value2ControlRadioButton.TabIndex = 0
        Me.Value2ControlRadioButton.TabStop = True
        Me.Value2ControlRadioButton.Text = "Control"
        Me.Value2ControlRadioButton.UseVisualStyleBackColor = True
        '
        'SourceAttributeComboBox
        '
        Me.SourceAttributeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SourceAttributeComboBox.FormattingEnabled = True
        Me.SourceAttributeComboBox.Location = New System.Drawing.Point(413, 181)
        Me.SourceAttributeComboBox.Name = "SourceAttributeComboBox"
        Me.SourceAttributeComboBox.Size = New System.Drawing.Size(71, 21)
        Me.SourceAttributeComboBox.TabIndex = 21
        '
        'SourceControlComboBox
        '
        Me.SourceControlComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SourceControlComboBox.FormattingEnabled = True
        Me.SourceControlComboBox.Location = New System.Drawing.Point(297, 181)
        Me.SourceControlComboBox.Name = "SourceControlComboBox"
        Me.SourceControlComboBox.Size = New System.Drawing.Size(110, 21)
        Me.SourceControlComboBox.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(262, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "="
        '
        'TargetAttributeComboBox
        '
        Me.TargetAttributeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TargetAttributeComboBox.FormattingEnabled = True
        Me.TargetAttributeComboBox.Location = New System.Drawing.Point(160, 181)
        Me.TargetAttributeComboBox.Name = "TargetAttributeComboBox"
        Me.TargetAttributeComboBox.Size = New System.Drawing.Size(71, 21)
        Me.TargetAttributeComboBox.TabIndex = 15
        '
        'TargetControlComboBox
        '
        Me.TargetControlComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TargetControlComboBox.FormattingEnabled = True
        Me.TargetControlComboBox.Location = New System.Drawing.Point(44, 181)
        Me.TargetControlComboBox.Name = "TargetControlComboBox"
        Me.TargetControlComboBox.Size = New System.Drawing.Size(110, 21)
        Me.TargetControlComboBox.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Then"
        '
        'Value2AttributeComboBox
        '
        Me.Value2AttributeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Value2AttributeComboBox.FormattingEnabled = True
        Me.Value2AttributeComboBox.Location = New System.Drawing.Point(413, 120)
        Me.Value2AttributeComboBox.Name = "Value2AttributeComboBox"
        Me.Value2AttributeComboBox.Size = New System.Drawing.Size(71, 21)
        Me.Value2AttributeComboBox.TabIndex = 10
        '
        'Value2ControlComboBox
        '
        Me.Value2ControlComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Value2ControlComboBox.FormattingEnabled = True
        Me.Value2ControlComboBox.Location = New System.Drawing.Point(297, 120)
        Me.Value2ControlComboBox.Name = "Value2ControlComboBox"
        Me.Value2ControlComboBox.Size = New System.Drawing.Size(110, 21)
        Me.Value2ControlComboBox.TabIndex = 8
        '
        'OperatorComboBox
        '
        Me.OperatorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OperatorComboBox.FormattingEnabled = True
        Me.OperatorComboBox.Items.AddRange(New Object() {">", ">=", "=", "<=", "<", "IsEmpty", "IsNotEmpty"})
        Me.OperatorComboBox.Location = New System.Drawing.Point(237, 120)
        Me.OperatorComboBox.Name = "OperatorComboBox"
        Me.OperatorComboBox.Size = New System.Drawing.Size(54, 21)
        Me.OperatorComboBox.TabIndex = 5
        '
        'Value1AttributeComboBox
        '
        Me.Value1AttributeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Value1AttributeComboBox.FormattingEnabled = True
        Me.Value1AttributeComboBox.Location = New System.Drawing.Point(160, 120)
        Me.Value1AttributeComboBox.Name = "Value1AttributeComboBox"
        Me.Value1AttributeComboBox.Size = New System.Drawing.Size(71, 21)
        Me.Value1AttributeComboBox.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(428, 387)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'AddButton
        '
        Me.AddButton.Location = New System.Drawing.Point(13, 387)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.Size = New System.Drawing.Size(75, 23)
        Me.AddButton.TabIndex = 2
        Me.AddButton.Text = "Add"
        Me.AddButton.UseVisualStyleBackColor = True
        '
        'EditButton
        '
        Me.EditButton.Location = New System.Drawing.Point(92, 387)
        Me.EditButton.Name = "EditButton"
        Me.EditButton.Size = New System.Drawing.Size(75, 23)
        Me.EditButton.TabIndex = 3
        Me.EditButton.Text = "Edit"
        Me.EditButton.UseVisualStyleBackColor = True
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(173, 387)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(75, 23)
        Me.RemoveButton.TabIndex = 4
        Me.RemoveButton.Text = "Remove"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'Conditions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 421)
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.EditButton)
        Me.Controls.Add(Me.AddButton)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ParametersGroupBox)
        Me.Controls.Add(Me.ConditionsDataGridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Conditions"
        Me.ShowIcon = False
        Me.Text = "Conditions"
        Me.TopMost = True
        CType(Me.ConditionsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ParametersGroupBox.ResumeLayout(False)
        Me.ParametersGroupBox.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Value2GroupBox.ResumeLayout(False)
        Me.Value2GroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ConditionsDataGridView As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Value1ControlComboBox As ComboBox
    Friend WithEvents ParametersGroupBox As GroupBox
    Friend WithEvents Value2GroupBox As GroupBox
    Friend WithEvents Value2StaticRadioButton As RadioButton
    Friend WithEvents Value2ControlRadioButton As RadioButton
    Friend WithEvents SourceAttributeComboBox As ComboBox
    Friend WithEvents SourceControlComboBox As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TargetAttributeComboBox As ComboBox
    Friend WithEvents TargetControlComboBox As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Value2AttributeComboBox As ComboBox
    Friend WithEvents Value2ControlComboBox As ComboBox
    Friend WithEvents OperatorComboBox As ComboBox
    Friend WithEvents Value1AttributeComboBox As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents AddButton As Button
    Friend WithEvents EditButton As Button
    Friend WithEvents RemoveButton As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SourceStaticRadioButton As RadioButton
    Friend WithEvents SourceControlRadioButton As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Value1 As DataGridViewTextBoxColumn
    Friend WithEvents Value1Attribute As DataGridViewTextBoxColumn
    Friend WithEvents Comparison As DataGridViewTextBoxColumn
    Friend WithEvents Value2 As DataGridViewTextBoxColumn
    Friend WithEvents Value2Attribute As DataGridViewTextBoxColumn
    Friend WithEvents Target As DataGridViewTextBoxColumn
    Friend WithEvents TargetAttribute As DataGridViewTextBoxColumn
    Friend WithEvents Source As DataGridViewTextBoxColumn
    Friend WithEvents SourceAttribute As DataGridViewTextBoxColumn
End Class

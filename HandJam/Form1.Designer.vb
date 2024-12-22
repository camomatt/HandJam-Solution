<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportCardListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CardListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CardDeckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllCardImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SingleCardImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CardTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OnlineDocumentationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.URealmsForumTopicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.EditCardButton = New System.Windows.Forms.Button()
        Me.RemoveCardButton = New System.Windows.Forms.Button()
        Me.AddCardButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PrimaryTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.AddControlButton = New System.Windows.Forms.Button()
        Me.EditButton = New System.Windows.Forms.Button()
        Me.CardTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.NewCardTypeButton = New System.Windows.Forms.Button()
        Me.RemoveCardTypeButton = New System.Windows.Forms.Button()
        Me.ConditionsButton = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ControlsTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PrimaryTableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(624, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportCardListToolStripMenuItem, Me.ExportToolStripMenuItem, Me.CardTemplateToolStripMenuItem, Me.PreferencesToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ImportCardListToolStripMenuItem
        '
        Me.ImportCardListToolStripMenuItem.Name = "ImportCardListToolStripMenuItem"
        Me.ImportCardListToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ImportCardListToolStripMenuItem.Text = "Import Card List..."
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CardListToolStripMenuItem, Me.CardDeckToolStripMenuItem, Me.AllCardImagesToolStripMenuItem, Me.SingleCardImageToolStripMenuItem})
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'CardListToolStripMenuItem
        '
        Me.CardListToolStripMenuItem.Name = "CardListToolStripMenuItem"
        Me.CardListToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CardListToolStripMenuItem.Text = "Card List..."
        '
        'CardDeckToolStripMenuItem
        '
        Me.CardDeckToolStripMenuItem.Name = "CardDeckToolStripMenuItem"
        Me.CardDeckToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CardDeckToolStripMenuItem.Text = "Card Deck..."
        '
        'AllCardImagesToolStripMenuItem
        '
        Me.AllCardImagesToolStripMenuItem.Name = "AllCardImagesToolStripMenuItem"
        Me.AllCardImagesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AllCardImagesToolStripMenuItem.Text = "All Card Images"
        '
        'SingleCardImageToolStripMenuItem
        '
        Me.SingleCardImageToolStripMenuItem.Name = "SingleCardImageToolStripMenuItem"
        Me.SingleCardImageToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SingleCardImageToolStripMenuItem.Text = "Single Card Image"
        '
        'CardTemplateToolStripMenuItem
        '
        Me.CardTemplateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.CardTemplateToolStripMenuItem.Name = "CardTemplateToolStripMenuItem"
        Me.CardTemplateToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CardTemplateToolStripMenuItem.Text = "Card Template"
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LoadToolStripMenuItem.Text = "Load..."
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveToolStripMenuItem.Text = "Save..."
        '
        'PreferencesToolStripMenuItem
        '
        Me.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem"
        Me.PreferencesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PreferencesToolStripMenuItem.Text = "Preferences..."
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogsToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'LogsToolStripMenuItem
        '
        Me.LogsToolStripMenuItem.Enabled = False
        Me.LogsToolStripMenuItem.Name = "LogsToolStripMenuItem"
        Me.LogsToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.LogsToolStripMenuItem.Text = "Logs..."
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OnlineDocumentationToolStripMenuItem, Me.URealmsForumTopicToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'OnlineDocumentationToolStripMenuItem
        '
        Me.OnlineDocumentationToolStripMenuItem.Enabled = False
        Me.OnlineDocumentationToolStripMenuItem.Name = "OnlineDocumentationToolStripMenuItem"
        Me.OnlineDocumentationToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.OnlineDocumentationToolStripMenuItem.Text = "Online Documentation..."
        '
        'URealmsForumTopicToolStripMenuItem
        '
        Me.URealmsForumTopicToolStripMenuItem.Enabled = False
        Me.URealmsForumTopicToolStripMenuItem.Name = "URealmsForumTopicToolStripMenuItem"
        Me.URealmsForumTopicToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.URealmsForumTopicToolStripMenuItem.Text = "URealms Forum Topic..."
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.AboutToolStripMenuItem.Text = "About..."
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 299)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(624, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.EditCardButton)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RemoveCardButton)
        Me.SplitContainer1.Panel1.Controls.Add(Me.AddCardButton)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Panel1MinSize = 205
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2MinSize = 410
        Me.SplitContainer1.Size = New System.Drawing.Size(624, 275)
        Me.SplitContainer1.SplitterDistance = 205
        Me.SplitContainer1.TabIndex = 2
        '
        'EditCardButton
        '
        Me.EditCardButton.Enabled = False
        Me.EditCardButton.Location = New System.Drawing.Point(70, 6)
        Me.EditCardButton.Name = "EditCardButton"
        Me.EditCardButton.Size = New System.Drawing.Size(62, 23)
        Me.EditCardButton.TabIndex = 3
        Me.EditCardButton.Text = "Edit"
        Me.EditCardButton.UseVisualStyleBackColor = True
        '
        'RemoveCardButton
        '
        Me.RemoveCardButton.Enabled = False
        Me.RemoveCardButton.Location = New System.Drawing.Point(138, 6)
        Me.RemoveCardButton.Name = "RemoveCardButton"
        Me.RemoveCardButton.Size = New System.Drawing.Size(62, 23)
        Me.RemoveCardButton.TabIndex = 2
        Me.RemoveCardButton.Text = "Remove"
        Me.RemoveCardButton.UseVisualStyleBackColor = True
        '
        'AddCardButton
        '
        Me.AddCardButton.Location = New System.Drawing.Point(2, 6)
        Me.AddCardButton.Name = "AddCardButton"
        Me.AddCardButton.Size = New System.Drawing.Size(62, 23)
        Me.AddCardButton.TabIndex = 1
        Me.AddCardButton.Text = "Add"
        Me.AddCardButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 32)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(197, 238)
        Me.DataGridView1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.MinimumSize = New System.Drawing.Size(415, 275)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.PictureBox1)
        Me.SplitContainer2.Panel1MinSize = 205
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.PrimaryTableLayoutPanel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ControlsTableLayoutPanel)
        Me.SplitContainer2.Panel2MinSize = 205
        Me.SplitContainer2.Size = New System.Drawing.Size(415, 275)
        Me.SplitContainer2.SplitterDistance = 205
        Me.SplitContainer2.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(203, 273)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PrimaryTableLayoutPanel
        '
        Me.PrimaryTableLayoutPanel.ColumnCount = 3
        Me.PrimaryTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.PrimaryTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.PrimaryTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.PrimaryTableLayoutPanel.Controls.Add(Me.AddControlButton, 0, 2)
        Me.PrimaryTableLayoutPanel.Controls.Add(Me.EditButton, 2, 1)
        Me.PrimaryTableLayoutPanel.Controls.Add(Me.CardTypeComboBox, 0, 0)
        Me.PrimaryTableLayoutPanel.Controls.Add(Me.NewCardTypeButton, 0, 1)
        Me.PrimaryTableLayoutPanel.Controls.Add(Me.RemoveCardTypeButton, 1, 1)
        Me.PrimaryTableLayoutPanel.Controls.Add(Me.ConditionsButton, 2, 2)
        Me.PrimaryTableLayoutPanel.Controls.Add(Me.Button1, 1, 2)
        Me.PrimaryTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.PrimaryTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.PrimaryTableLayoutPanel.MaximumSize = New System.Drawing.Size(0, 100)
        Me.PrimaryTableLayoutPanel.Name = "PrimaryTableLayoutPanel"
        Me.PrimaryTableLayoutPanel.RowCount = 3
        Me.PrimaryTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.PrimaryTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.PrimaryTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.PrimaryTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.PrimaryTableLayoutPanel.Size = New System.Drawing.Size(204, 100)
        Me.PrimaryTableLayoutPanel.TabIndex = 1
        '
        'AddControlButton
        '
        Me.AddControlButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddControlButton.AutoSize = True
        Me.AddControlButton.Location = New System.Drawing.Point(3, 68)
        Me.AddControlButton.Name = "AddControlButton"
        Me.AddControlButton.Size = New System.Drawing.Size(61, 23)
        Me.AddControlButton.TabIndex = 0
        Me.AddControlButton.Text = "Add Ctrl"
        Me.AddControlButton.UseVisualStyleBackColor = True
        '
        'EditButton
        '
        Me.EditButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditButton.Enabled = False
        Me.EditButton.Location = New System.Drawing.Point(138, 33)
        Me.EditButton.Name = "EditButton"
        Me.EditButton.Size = New System.Drawing.Size(63, 23)
        Me.EditButton.TabIndex = 4
        Me.EditButton.Text = "Edit"
        Me.EditButton.UseVisualStyleBackColor = True
        '
        'CardTypeComboBox
        '
        Me.CardTypeComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrimaryTableLayoutPanel.SetColumnSpan(Me.CardTypeComboBox, 3)
        Me.CardTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CardTypeComboBox.Enabled = False
        Me.CardTypeComboBox.FormattingEnabled = True
        Me.CardTypeComboBox.Location = New System.Drawing.Point(3, 4)
        Me.CardTypeComboBox.MinimumSize = New System.Drawing.Size(60, 0)
        Me.CardTypeComboBox.Name = "CardTypeComboBox"
        Me.CardTypeComboBox.Size = New System.Drawing.Size(198, 21)
        Me.CardTypeComboBox.TabIndex = 1
        '
        'NewCardTypeButton
        '
        Me.NewCardTypeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewCardTypeButton.AutoSize = True
        Me.NewCardTypeButton.Enabled = False
        Me.NewCardTypeButton.Location = New System.Drawing.Point(3, 33)
        Me.NewCardTypeButton.Name = "NewCardTypeButton"
        Me.NewCardTypeButton.Size = New System.Drawing.Size(61, 23)
        Me.NewCardTypeButton.TabIndex = 2
        Me.NewCardTypeButton.Text = "Add"
        Me.NewCardTypeButton.UseVisualStyleBackColor = True
        '
        'RemoveCardTypeButton
        '
        Me.RemoveCardTypeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RemoveCardTypeButton.AutoSize = True
        Me.RemoveCardTypeButton.Enabled = False
        Me.RemoveCardTypeButton.Location = New System.Drawing.Point(70, 33)
        Me.RemoveCardTypeButton.Name = "RemoveCardTypeButton"
        Me.RemoveCardTypeButton.Size = New System.Drawing.Size(62, 23)
        Me.RemoveCardTypeButton.TabIndex = 3
        Me.RemoveCardTypeButton.Text = "Remove"
        Me.RemoveCardTypeButton.UseVisualStyleBackColor = True
        '
        'ConditionsButton
        '
        Me.ConditionsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConditionsButton.Location = New System.Drawing.Point(138, 68)
        Me.ConditionsButton.Name = "ConditionsButton"
        Me.ConditionsButton.Size = New System.Drawing.Size(63, 23)
        Me.ConditionsButton.TabIndex = 5
        Me.ConditionsButton.Text = "Conditions"
        Me.ConditionsButton.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(70, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(62, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Card Properties"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ControlsTableLayoutPanel
        '
        Me.ControlsTableLayoutPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ControlsTableLayoutPanel.AutoScroll = True
        Me.ControlsTableLayoutPanel.ColumnCount = 2
        Me.ControlsTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.ControlsTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.ControlsTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ControlsTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ControlsTableLayoutPanel.Location = New System.Drawing.Point(0, 105)
        Me.ControlsTableLayoutPanel.Name = "ControlsTableLayoutPanel"
        Me.ControlsTableLayoutPanel.RowCount = 1
        Me.ControlsTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.ControlsTableLayoutPanel.Size = New System.Drawing.Size(204, 168)
        Me.ControlsTableLayoutPanel.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 321)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(640, 360)
        Me.Name = "Form1"
        Me.Text = "HandJam"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PrimaryTableLayoutPanel.ResumeLayout(False)
        Me.PrimaryTableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents ImportCardListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CardListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CardDeckToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllCardImagesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SingleCardImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CardTemplateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PreferencesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OnlineDocumentationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents URealmsForumTopicToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents AddControlButton As Button
    Friend WithEvents ControlsTableLayoutPanel As TableLayoutPanel
    Friend WithEvents CardTypeComboBox As ComboBox
    Friend WithEvents NewCardTypeButton As Button
    Friend WithEvents RemoveCardTypeButton As Button
    Friend WithEvents EditButton As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents EditCardButton As Button
    Friend WithEvents RemoveCardButton As Button
    Friend WithEvents AddCardButton As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PrimaryTableLayoutPanel As TableLayoutPanel
    Friend WithEvents ConditionsButton As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Button1 As Button
End Class

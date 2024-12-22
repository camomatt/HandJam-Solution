<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CardProperties
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.WidthNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.HeightNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.WidthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeightNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.HeightNumericUpDown)
        Me.GroupBox1.Controls.Add(Me.WidthNumericUpDown)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(135, 72)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dimensions"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(40, 90)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Width"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Height"
        '
        'WidthNumericUpDown
        '
        Me.WidthNumericUpDown.Location = New System.Drawing.Point(51, 18)
        Me.WidthNumericUpDown.Maximum = New Decimal(New Integer() {3840, 0, 0, 0})
        Me.WidthNumericUpDown.Name = "WidthNumericUpDown"
        Me.WidthNumericUpDown.Size = New System.Drawing.Size(52, 20)
        Me.WidthNumericUpDown.TabIndex = 2
        Me.WidthNumericUpDown.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'HeightNumericUpDown
        '
        Me.HeightNumericUpDown.Location = New System.Drawing.Point(51, 44)
        Me.HeightNumericUpDown.Maximum = New Decimal(New Integer() {3840, 0, 0, 0})
        Me.HeightNumericUpDown.Name = "HeightNumericUpDown"
        Me.HeightNumericUpDown.Size = New System.Drawing.Size(52, 20)
        Me.HeightNumericUpDown.TabIndex = 3
        Me.HeightNumericUpDown.Value = New Decimal(New Integer() {700, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(109, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "px"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(109, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "px"
        '
        'CardProperties
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(158, 119)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CardProperties"
        Me.Text = "Card Properties"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.WidthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeightNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents HeightNumericUpDown As NumericUpDown
    Friend WithEvents WidthNumericUpDown As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    'Inherits System.Windows.Forms.Form
    Inherits MaterialSkin.Controls.MaterialForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.btnStartBot = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.btnStopBot = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.lblStatus = New MaterialSkin.Controls.MaterialLabel()
        Me.radio60s = New MaterialSkin.Controls.MaterialRadioButton()
        Me.radio2Hrs = New MaterialSkin.Controls.MaterialRadioButton()
        Me.radio6Hrs = New MaterialSkin.Controls.MaterialRadioButton()
        Me.radio12Hrs = New MaterialSkin.Controls.MaterialRadioButton()
        Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 147)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(537, 445)
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = ""
        '
        'btnStartBot
        '
        Me.btnStartBot.Depth = 0
        Me.btnStartBot.Location = New System.Drawing.Point(12, 110)
        Me.btnStartBot.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnStartBot.Name = "btnStartBot"
        Me.btnStartBot.Primary = True
        Me.btnStartBot.Size = New System.Drawing.Size(119, 31)
        Me.btnStartBot.TabIndex = 3
        Me.btnStartBot.Text = "Start Bot"
        Me.btnStartBot.UseVisualStyleBackColor = True
        '
        'btnStopBot
        '
        Me.btnStopBot.Depth = 0
        Me.btnStopBot.Location = New System.Drawing.Point(137, 110)
        Me.btnStopBot.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnStopBot.Name = "btnStopBot"
        Me.btnStopBot.Primary = True
        Me.btnStopBot.Size = New System.Drawing.Size(119, 31)
        Me.btnStopBot.TabIndex = 4
        Me.btnStopBot.Text = "Stop Bot"
        Me.btnStopBot.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Depth = 0
        Me.lblStatus.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(12, 86)
        Me.lblStatus.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(108, 19)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "MaterialLabel1"
        '
        'radio60s
        '
        Me.radio60s.AutoSize = True
        Me.radio60s.Depth = 0
        Me.radio60s.Font = New System.Drawing.Font("Roboto", 10.0!)
        Me.radio60s.Location = New System.Drawing.Point(268, 110)
        Me.radio60s.Margin = New System.Windows.Forms.Padding(0)
        Me.radio60s.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.radio60s.MouseState = MaterialSkin.MouseState.HOVER
        Me.radio60s.Name = "radio60s"
        Me.radio60s.Ripple = True
        Me.radio60s.Size = New System.Drawing.Size(61, 30)
        Me.radio60s.TabIndex = 6
        Me.radio60s.TabStop = True
        Me.radio60s.Text = "60(s)"
        Me.radio60s.UseVisualStyleBackColor = True
        '
        'radio2Hrs
        '
        Me.radio2Hrs.AutoSize = True
        Me.radio2Hrs.Depth = 0
        Me.radio2Hrs.Font = New System.Drawing.Font("Roboto", 10.0!)
        Me.radio2Hrs.Location = New System.Drawing.Point(334, 110)
        Me.radio2Hrs.Margin = New System.Windows.Forms.Padding(0)
        Me.radio2Hrs.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.radio2Hrs.MouseState = MaterialSkin.MouseState.HOVER
        Me.radio2Hrs.Name = "radio2Hrs"
        Me.radio2Hrs.Ripple = True
        Me.radio2Hrs.Size = New System.Drawing.Size(66, 30)
        Me.radio2Hrs.TabIndex = 7
        Me.radio2Hrs.TabStop = True
        Me.radio2Hrs.Text = "2(hrs)"
        Me.radio2Hrs.UseVisualStyleBackColor = True
        '
        'radio6Hrs
        '
        Me.radio6Hrs.AutoSize = True
        Me.radio6Hrs.Depth = 0
        Me.radio6Hrs.Font = New System.Drawing.Font("Roboto", 10.0!)
        Me.radio6Hrs.Location = New System.Drawing.Point(402, 110)
        Me.radio6Hrs.Margin = New System.Windows.Forms.Padding(0)
        Me.radio6Hrs.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.radio6Hrs.MouseState = MaterialSkin.MouseState.HOVER
        Me.radio6Hrs.Name = "radio6Hrs"
        Me.radio6Hrs.Ripple = True
        Me.radio6Hrs.Size = New System.Drawing.Size(66, 30)
        Me.radio6Hrs.TabIndex = 8
        Me.radio6Hrs.TabStop = True
        Me.radio6Hrs.Text = "6(hrs)"
        Me.radio6Hrs.UseVisualStyleBackColor = True
        '
        'radio12Hrs
        '
        Me.radio12Hrs.AutoSize = True
        Me.radio12Hrs.Depth = 0
        Me.radio12Hrs.Font = New System.Drawing.Font("Roboto", 10.0!)
        Me.radio12Hrs.Location = New System.Drawing.Point(469, 110)
        Me.radio12Hrs.Margin = New System.Windows.Forms.Padding(0)
        Me.radio12Hrs.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.radio12Hrs.MouseState = MaterialSkin.MouseState.HOVER
        Me.radio12Hrs.Name = "radio12Hrs"
        Me.radio12Hrs.Ripple = True
        Me.radio12Hrs.Size = New System.Drawing.Size(74, 30)
        Me.radio12Hrs.TabIndex = 9
        Me.radio12Hrs.TabStop = True
        Me.radio12Hrs.Text = "12(hrs)"
        Me.radio12Hrs.UseVisualStyleBackColor = True
        '
        'MaterialLabel1
        '
        Me.MaterialLabel1.AutoSize = True
        Me.MaterialLabel1.Depth = 0
        Me.MaterialLabel1.Font = New System.Drawing.Font("Nirmala UI", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaterialLabel1.ForeColor = System.Drawing.Color.Blue
        Me.MaterialLabel1.Location = New System.Drawing.Point(11, 66)
        Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel1.Name = "MaterialLabel1"
        Me.MaterialLabel1.Size = New System.Drawing.Size(196, 20)
        Me.MaterialLabel1.TabIndex = 10
        Me.MaterialLabel1.Text = "Coded by, Jason Manceaux"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Noto Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(13, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 18)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "VERSION: 1.0.0  |  June 06, 2024"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 615)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MaterialLabel1)
        Me.Controls.Add(Me.radio12Hrs)
        Me.Controls.Add(Me.radio6Hrs)
        Me.Controls.Add(Me.radio2Hrs)
        Me.Controls.Add(Me.radio60s)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnStopBot)
        Me.Controls.Add(Me.btnStartBot)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(563, 615)
        Me.MinimumSize = New System.Drawing.Size(563, 615)
        Me.Name = "Form1"
        Me.Text = "Bulletproof - Selinium Inventory Auto Fetch"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents btnStartBot As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents btnStopBot As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents lblStatus As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents radio60s As MaterialSkin.Controls.MaterialRadioButton
    Friend WithEvents radio2Hrs As MaterialSkin.Controls.MaterialRadioButton
    Friend WithEvents radio6Hrs As MaterialSkin.Controls.MaterialRadioButton
    Friend WithEvents radio12Hrs As MaterialSkin.Controls.MaterialRadioButton
    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents Label1 As Label
End Class

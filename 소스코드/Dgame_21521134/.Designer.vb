<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.stage1L = New System.Windows.Forms.Label()
        Me.scriptTimer = New System.Windows.Forms.Timer(Me.components)
        Me.openTimer = New System.Windows.Forms.Timer(Me.components)
        Me.zergTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ghostTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.gameTimer = New System.Windows.Forms.Timer(Me.components)
        Me.stage5 = New System.Windows.Forms.Timer(Me.components)
        Me.lifeLabel = New System.Windows.Forms.Label()
        Me.timerLabel = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 14
        '
        'stage1L
        '
        Me.stage1L.AutoSize = True
        Me.stage1L.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.stage1L.Font = New System.Drawing.Font("굴림", 50.0!)
        Me.stage1L.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.stage1L.Location = New System.Drawing.Point(170, 631)
        Me.stage1L.Name = "stage1L"
        Me.stage1L.Size = New System.Drawing.Size(0, 67)
        Me.stage1L.TabIndex = 0
        '
        'scriptTimer
        '
        Me.scriptTimer.Enabled = True
        Me.scriptTimer.Interval = 2500
        '
        'openTimer
        '
        Me.openTimer.Interval = 80
        '
        'zergTimer
        '
        Me.zergTimer.Interval = 14
        '
        'ghostTimer
        '
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 740)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1124, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'gameTimer
        '
        Me.gameTimer.Interval = 14
        '
        'stage5
        '
        Me.stage5.Interval = 14
        '
        'lifeLabel
        '
        Me.lifeLabel.AutoSize = True
        Me.lifeLabel.BackColor = System.Drawing.SystemColors.Desktop
        Me.lifeLabel.Font = New System.Drawing.Font("굴림", 40.0!)
        Me.lifeLabel.ForeColor = System.Drawing.SystemColors.Control
        Me.lifeLabel.Location = New System.Drawing.Point(231, 194)
        Me.lifeLabel.Name = "lifeLabel"
        Me.lifeLabel.Size = New System.Drawing.Size(0, 54)
        Me.lifeLabel.TabIndex = 3
        '
        'timerLabel
        '
        Me.timerLabel.AutoSize = True
        Me.timerLabel.BackColor = System.Drawing.SystemColors.Desktop
        Me.timerLabel.Font = New System.Drawing.Font("굴림", 40.0!)
        Me.timerLabel.ForeColor = System.Drawing.SystemColors.Control
        Me.timerLabel.Location = New System.Drawing.Point(231, 397)
        Me.timerLabel.Name = "timerLabel"
        Me.timerLabel.Size = New System.Drawing.Size(0, 54)
        Me.timerLabel.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1124, 762)
        Me.Controls.Add(Me.timerLabel)
        Me.Controls.Add(Me.lifeLabel)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.stage1L)
        Me.DoubleBuffered = True
        Me.Location = New System.Drawing.Point(10, 10)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents stage1L As Label
    Friend WithEvents scriptTimer As Timer
    Friend WithEvents openTimer As Timer
    Friend WithEvents zergTimer As Timer
    Friend WithEvents ghostTimer As Timer
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents gameTimer As Timer
    Friend WithEvents stage5 As Timer
    Friend WithEvents lifeLabel As Label
    Friend WithEvents timerLabel As Label
End Class

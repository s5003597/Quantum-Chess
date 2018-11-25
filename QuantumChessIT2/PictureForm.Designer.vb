<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PictureForm
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
        Me.chessBox = New System.Windows.Forms.PictureBox()
        CType(Me.chessBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chessBox
        '
        Me.chessBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chessBox.Image = Global.QuantumChessIT2.My.Resources.Resources.chesspieces
        Me.chessBox.Location = New System.Drawing.Point(0, 0)
        Me.chessBox.Name = "chessBox"
        Me.chessBox.Size = New System.Drawing.Size(329, 292)
        Me.chessBox.TabIndex = 0
        Me.chessBox.TabStop = False
        '
        'PictureForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 292)
        Me.Controls.Add(Me.chessBox)
        Me.Name = "PictureForm"
        Me.Text = "PictureForm"
        CType(Me.chessBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents chessBox As PictureBox
End Class

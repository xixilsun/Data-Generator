Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmSyMsg
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbCount As System.Windows.Forms.ProgressBar

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbCount = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.MenuText
        Me.lblStatus.Location = New System.Drawing.Point(0, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(230, 34)
        Me.lblStatus.TabIndex = 0
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.Transparent
        Me.lblCount.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCount.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.SystemColors.MenuText
        Me.lblCount.Location = New System.Drawing.Point(0, 0)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(230, 23)
        Me.lblCount.TabIndex = 1
        Me.lblCount.Text = "text"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pbCount)
        Me.Panel1.Controls.Add(Me.lblCount)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(230, 54)
        Me.Panel1.TabIndex = 2
        '
        'pbCount
        '
        Me.pbCount.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbCount.Location = New System.Drawing.Point(0, 35)
        Me.pbCount.Name = "pbCount"
        Me.pbCount.Size = New System.Drawing.Size(230, 19)
        Me.pbCount.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbCount.TabIndex = 2
        '
        'FrmSyMsg
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(230, 91)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblStatus)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "FrmSyMsg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Status"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private m_ActiveAnimation As Boolean = False

#Region "Property"
    Public WriteOnly Property ActiveAnimation() As Boolean
        Set(ByVal value As Boolean)
            m_ActiveAnimation = value
        End Set
    End Property

    'Public WriteOnly Property ProgressMax() As Short
    '    Set(ByVal value As Short)
    '        m_ProgMax = False
    '    End Set
    'End Property
#End Region

    Protected Sub S_SetDefault(ByVal oMsg As String)
        With lblStatus
            .Font = New Font("Tahoma", 8, FontStyle.Regular)
            .ForeColor = Color.Black
            .Text = oMsg
            .Dock = DockStyle.Top
            .TextAlign = ContentAlignment.TopCenter
            .Width = Len(oMsg)
        End With

        With Me
            .BackColor = Color.GhostWhite
            .Width = lblStatus.Width
            lblStatus.Height = 34

            If Not m_ActiveAnimation Then
                .Height = lblStatus.Height + 5
                Panel1.Visible = False
            Else
                With lblCount
                    .Font = New Font("Tahoma", 7, FontStyle.Regular)
                    .ForeColor = Color.DimGray
                    .Dock = DockStyle.Top
                    .TextAlign = ContentAlignment.BottomCenter
                End With

                With pbCount
                    .Style = ProgressBarStyle.Blocks
                    .Step = 1
                    .Value = 0
                    .Height = 15
                    .Dock = DockStyle.Bottom
                    .BackColor = Color.AliceBlue
                    .ForeColor = Color.DarkSlateBlue
                End With

                Panel1.Height = 44
                .Height = lblStatus.Height + Panel1.Height + 25
                lblCount.Visible = True
                pbCount.Visible = True
            End If

            .ControlBox = False
            .Text = ""
            .ShowInTaskbar = False
            .TopMost = True
            .Show()
        End With
    End Sub

    Public Overloads Sub Show(ByVal Message As String)
        S_SetDefault(Message)
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Public Overloads Sub SetCount(ByVal Message As String)
        lblCount.Text = Message
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Public Overloads Sub SetProgressBar()
        If Not pbCount.Value >= pbCount.Maximum Then
            pbCount.Value += 1
        Else
            pbCount.Value = 0
        End If

        System.Windows.Forms.Application.DoEvents()
    End Sub

    Public Overloads Sub ReSetProgressBar(ByVal oMax As Integer)
        pbCount.Minimum = 0
        pbCount.Value = 0
        pbCount.Maximum = oMax
        System.Windows.Forms.Application.DoEvents()
    End Sub
End Class

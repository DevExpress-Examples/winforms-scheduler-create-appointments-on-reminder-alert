Namespace ReminderCustomActions
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
			Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
			Dim timeRuler3 As New DevExpress.XtraScheduler.TimeRuler()
			Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			Me.memoEdit1 = New DevExpress.XtraEditors.MemoEdit()
			Me.progressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
			Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
			Me.schedulerDataStorage1 = New DevExpress.XtraScheduler.SchedulerDataStorage(Me.components)
			Me.timer1 = New System.Windows.Forms.Timer(Me.components)
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panelControl1.SuspendLayout()
			CType(Me.memoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.progressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.schedulerDataStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' panelControl1
			' 
			Me.panelControl1.Controls.Add(Me.simpleButton1)
			Me.panelControl1.Controls.Add(Me.memoEdit1)
			Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
			Me.panelControl1.Location = New System.Drawing.Point(0, 0)
			Me.panelControl1.Name = "panelControl1"
			Me.panelControl1.Size = New System.Drawing.Size(584, 48)
			Me.panelControl1.TabIndex = 0
			' 
			' simpleButton1
			' 
			Me.simpleButton1.Location = New System.Drawing.Point(12, 12)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(233, 23)
			Me.simpleButton1.TabIndex = 1
            Me.simpleButton1.Text = "Create Appointment Series with Reminder"
            ' 
            ' memoEdit1
            ' 
            Me.memoEdit1.Dock = System.Windows.Forms.DockStyle.Right
			Me.memoEdit1.Location = New System.Drawing.Point(269, 2)
			Me.memoEdit1.Name = "memoEdit1"
			Me.memoEdit1.Size = New System.Drawing.Size(313, 44)
			Me.memoEdit1.TabIndex = 0
			' 
			' progressBarControl1
			' 
			Me.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.progressBarControl1.Location = New System.Drawing.Point(0, 423)
			Me.progressBarControl1.Name = "progressBarControl1"
			Me.progressBarControl1.Properties.DisplayFormat.FormatString = " {0} seconds left"
			Me.progressBarControl1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
			Me.progressBarControl1.Properties.PercentView = False
			Me.progressBarControl1.Properties.ShowTitle = True
			Me.progressBarControl1.Size = New System.Drawing.Size(584, 18)
			Me.progressBarControl1.TabIndex = 1
			' 
			' schedulerControl1
			' 
			Me.schedulerControl1.AllowDrop = False
			Me.schedulerControl1.DataStorage = Me.schedulerDataStorage1
			Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.schedulerControl1.Location = New System.Drawing.Point(0, 48)
			Me.schedulerControl1.Name = "schedulerControl1"
			Me.schedulerControl1.Size = New System.Drawing.Size(584, 375)
			Me.schedulerControl1.Start = New Date(2016, 6, 23, 0, 0, 0, 0)
			Me.schedulerControl1.TabIndex = 2
			Me.schedulerControl1.Text = "schedulerControl1"
			Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
			Me.schedulerControl1.Views.FullWeekView.Enabled = True
			Me.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2)
			Me.schedulerControl1.Views.WeekView.Enabled = False
			Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3)
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(584, 441)
			Me.Controls.Add(Me.schedulerControl1)
			Me.Controls.Add(Me.progressBarControl1)
			Me.Controls.Add(Me.panelControl1)
			Me.Name = "Form1"
			Me.Text = "Custom form, custom fields and custom actions on reminder alert"
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.panelControl1.ResumeLayout(False)
			CType(Me.memoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.progressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.schedulerDataStorage1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private panelControl1 As DevExpress.XtraEditors.PanelControl
		Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton
		Private memoEdit1 As DevExpress.XtraEditors.MemoEdit
		Private progressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
		Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
		Private schedulerDataStorage1 As DevExpress.XtraScheduler.SchedulerDataStorage
		Private timer1 As System.Windows.Forms.Timer
	End Class
End Namespace


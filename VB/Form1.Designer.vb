Namespace CustomFormFieldsReminder

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

'#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim timeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.carSchedulingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.carsDBDataSet = New CustomFormFieldsReminder.CarsDBDataSet()
            Me.carsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.memoAptInfo = New DevExpress.XtraEditors.MemoEdit()
            Me.btnCreateAppReminder = New DevExpress.XtraEditors.SimpleButton()
            Me.carSchedulingTableAdapter = New CustomFormFieldsReminder.CarsDBDataSetTableAdapters.CarSchedulingTableAdapter()
            Me.carsTableAdapter = New CustomFormFieldsReminder.CarsDBDataSetTableAdapters.CarsTableAdapter()
            Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
            CType((Me.schedulerControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.schedulerStorage1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.carSchedulingBindingSource), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.carsDBDataSet), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.carsBindingSource), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.panelControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelControl1.SuspendLayout()
            CType((Me.memoAptInfo.Properties), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.schedulerControl1.Location = New System.Drawing.Point(0, 57)
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.Size = New System.Drawing.Size(707, 322)
            Me.schedulerControl1.Start = New System.DateTime(2008, 7, 14, 0, 0, 0, 0)
            Me.schedulerControl1.Storage = Me.schedulerStorage1
            Me.schedulerControl1.TabIndex = 0
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
            AddHandler Me.schedulerControl1.EditAppointmentFormShowing, New DevExpress.XtraScheduler.AppointmentFormEventHandler(AddressOf Me.schedulerControl1_EditAppointmentFormShowing)
            AddHandler Me.schedulerControl1.AppointmentViewInfoCustomizing, New DevExpress.XtraScheduler.AppointmentViewInfoCustomizingEventHandler(AddressOf Me.schedulerControl1_AppointmentViewInfoCustomizing)
            ' 
            ' schedulerStorage1
            ' 
            Me.schedulerStorage1.Appointments.CustomFieldMappings.Add(New DevExpress.XtraScheduler.AppointmentCustomFieldMapping("CustomPrice", "Price"))
            Me.schedulerStorage1.Appointments.DataSource = Me.carSchedulingBindingSource
            Me.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
            Me.schedulerStorage1.Appointments.Mappings.Description = "Description"
            Me.schedulerStorage1.Appointments.Mappings.[End] = "EndTime"
            Me.schedulerStorage1.Appointments.Mappings.Label = "Label"
            Me.schedulerStorage1.Appointments.Mappings.Location = "Location"
            Me.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
            Me.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
            Me.schedulerStorage1.Appointments.Mappings.ResourceId = "CarId"
            Me.schedulerStorage1.Appointments.Mappings.Start = "StartTime"
            Me.schedulerStorage1.Appointments.Mappings.Status = "Status"
            Me.schedulerStorage1.Appointments.Mappings.Subject = "Subject"
            Me.schedulerStorage1.Appointments.Mappings.Type = "EventType"
            Me.schedulerStorage1.Resources.DataSource = Me.carsBindingSource
            Me.schedulerStorage1.Resources.Mappings.Caption = "Model"
            Me.schedulerStorage1.Resources.Mappings.Id = "ID"
            Me.schedulerStorage1.Resources.Mappings.Image = "Picture"
            AddHandler Me.schedulerStorage1.ReminderAlert, New DevExpress.XtraScheduler.ReminderEventHandler(AddressOf Me.schedulerStorage1_ReminderAlert)
            AddHandler Me.schedulerStorage1.AppointmentsChanged, New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf Me.schedulerStorage1_AppointmentsChanged)
            AddHandler Me.schedulerStorage1.AppointmentsInserted, New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf Me.schedulerStorage1_AppointmentsChanged)
            AddHandler Me.schedulerStorage1.AppointmentsDeleted, New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf Me.schedulerStorage1_AppointmentsChanged)
            ' 
            ' carSchedulingBindingSource
            ' 
            Me.carSchedulingBindingSource.DataMember = "CarScheduling"
            Me.carSchedulingBindingSource.DataSource = Me.carsDBDataSet
            ' 
            ' carsDBDataSet
            ' 
            Me.carsDBDataSet.DataSetName = "CarsDBDataSet"
            Me.carsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' carsBindingSource
            ' 
            Me.carsBindingSource.DataMember = "Cars"
            Me.carsBindingSource.DataSource = Me.carsDBDataSet
            ' 
            ' panelControl1
            ' 
            Me.panelControl1.Controls.Add(Me.memoAptInfo)
            Me.panelControl1.Controls.Add(Me.btnCreateAppReminder)
            Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
            Me.panelControl1.Location = New System.Drawing.Point(0, 0)
            Me.panelControl1.Name = "panelControl1"
            Me.panelControl1.Size = New System.Drawing.Size(707, 57)
            Me.panelControl1.TabIndex = 1
            ' 
            ' memoAptInfo
            ' 
            Me.memoAptInfo.Dock = System.Windows.Forms.DockStyle.Right
            Me.memoAptInfo.Location = New System.Drawing.Point(262, 2)
            Me.memoAptInfo.Name = "memoAptInfo"
            Me.memoAptInfo.Size = New System.Drawing.Size(443, 53)
            Me.memoAptInfo.TabIndex = 1
            ' 
            ' btnCreateAppReminder
            ' 
            Me.btnCreateAppReminder.Location = New System.Drawing.Point(12, 12)
            Me.btnCreateAppReminder.Name = "btnCreateAppReminder"
            Me.btnCreateAppReminder.Size = New System.Drawing.Size(215, 23)
            Me.btnCreateAppReminder.TabIndex = 0
            Me.btnCreateAppReminder.Text = "Create Appointment Series with Reminder"
            AddHandler Me.btnCreateAppReminder.Click, New System.EventHandler(AddressOf Me.btnCreateAppReminder_Click)
            ' 
            ' carSchedulingTableAdapter
            ' 
            Me.carSchedulingTableAdapter.ClearBeforeFill = True
            ' 
            ' carsTableAdapter
            ' 
            Me.carsTableAdapter.ClearBeforeFill = True
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(707, 379)
            Me.Controls.Add(Me.schedulerControl1)
            Me.Controls.Add(Me.panelControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            AddHandler Me.Load, New System.EventHandler(AddressOf Me.Form1_Load)
            CType((Me.schedulerControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.schedulerStorage1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.carSchedulingBindingSource), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.carsDBDataSet), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.carsBindingSource), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.panelControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelControl1.ResumeLayout(False)
            CType((Me.memoAptInfo.Properties), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

'#End Region
        Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl

        Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage

        Private panelControl1 As DevExpress.XtraEditors.PanelControl

        Private carsDBDataSet As CustomFormFieldsReminder.CarsDBDataSet

        Private carSchedulingBindingSource As System.Windows.Forms.BindingSource

        Public carSchedulingTableAdapter As CustomFormFieldsReminder.CarsDBDataSetTableAdapters.CarSchedulingTableAdapter

        Private carsBindingSource As System.Windows.Forms.BindingSource

        Private carsTableAdapter As CustomFormFieldsReminder.CarsDBDataSetTableAdapters.CarsTableAdapter

        Private btnCreateAppReminder As DevExpress.XtraEditors.SimpleButton

        Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel

        Private memoAptInfo As DevExpress.XtraEditors.MemoEdit
    End Class
End Namespace

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraEditors
Imports System.Data.OleDb

Namespace CustomFormFieldsReminder

    Public Partial Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            AddHandler schedulerControl1.SelectedAppointments.CollectionChanged, New DevExpress.Utils.CollectionChangedEventHandler(Of Appointment)(AddressOf SelectedAppointments_CollectionChanged)
            schedulerControl1.OptionsBehavior.ShowRemindersForm = False
            schedulerControl1.OptionsBehavior.RemindersFormDefaultAction = RemindersFormDefaultAction.Custom
            schedulerControl1.ActiveViewType = SchedulerViewType.Day
            schedulerControl1.DayView.DayCount = 2
            schedulerControl1.DayView.ResourcesPerPage = 2
            schedulerControl1.GroupType = SchedulerGroupType.Resource
            schedulerControl1.OptionsView.ResourceHeaders.ImageSize = New Size(100, 50)
            schedulerControl1.OptionsView.ResourceHeaders.ImageSizeMode = HeaderImageSizeMode.ZoomImage
            schedulerControl1.Start = Date.Today
            ' TODO: This line of code loads data into the 'carsDBDataSet.Cars' table. You can move, or remove it, as needed.
            carsTableAdapter.Fill(carsDBDataSet.Cars)
            ' TODO: This line of code loads data into the 'carsDBDataSet.CarScheduling' table. You can move, or remove it, as needed.
            carSchedulingTableAdapter.Fill(carsDBDataSet.CarScheduling)
            AddHandler carSchedulingTableAdapter.Adapter.RowUpdated, New OleDbRowUpdatedEventHandler(AddressOf carSchedulingTableAdapter_RowUpdated)
        End Sub

        Private Sub schedulerControl1_EditAppointmentFormShowing(ByVal sender As Object, ByVal e As AppointmentFormEventArgs)
            Dim apt As Appointment = e.Appointment
            Dim openRecurrenceForm As Boolean = apt.IsRecurring AndAlso schedulerStorage1.Appointments.IsNewAppointment(apt)
            Dim f As MyAppointmentEditForm = New MyAppointmentEditForm(CType(sender, SchedulerControl), apt, openRecurrenceForm)
            Try
                f.LookAndFeel.ParentLookAndFeel = LookAndFeel.ParentLookAndFeel
                e.DialogResult = f.ShowDialog()
                e.Handled = True
                If apt.Type = AppointmentType.Pattern AndAlso schedulerControl1.SelectedAppointments.Contains(apt) Then schedulerControl1.SelectedAppointments.Remove(apt)
                schedulerControl1.Refresh()
            Finally
                f.Dispose()
            End Try
        End Sub

        Private Sub schedulerStorage1_AppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            carSchedulingTableAdapter.Update(carsDBDataSet)
            carsDBDataSet.AcceptChanges()
        End Sub

        Private Sub carSchedulingTableAdapter_RowUpdated(ByVal sender As Object, ByVal e As OleDbRowUpdatedEventArgs)
            If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
                Dim id As Integer = 0
                Using cmd As OleDbCommand = New OleDbCommand("SELECT @@IDENTITY", carSchedulingTableAdapter.Connection)
                    id = CInt(cmd.ExecuteScalar())
                End Using

                e.Row("ID") = id
            End If
        End Sub

        Private Sub btnCreateAppReminder_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim nowtime As Date = Date.Now.AddMinutes(16)
            Dim aptPattern As Appointment = schedulerStorage1.CreateAppointment(AppointmentType.Pattern)
            aptPattern.Subject = "Appointment with Reminder"
            aptPattern.Description = "Recurrence Appointment with reminder"
            aptPattern.Duration = TimeSpan.FromHours(2)
            aptPattern.ResourceId = schedulerStorage1.Resources(0).Id
            aptPattern.StatusId = CInt(AppointmentStatusType.Busy)
            aptPattern.LabelId = 1
            aptPattern.CustomFields("CustomPrice") = CDec(15.25)
            aptPattern.RecurrenceInfo.Type = RecurrenceType.Daily
            aptPattern.RecurrenceInfo.Periodicity = 2
            aptPattern.RecurrenceInfo.Range = RecurrenceRange.OccurrenceCount
            aptPattern.RecurrenceInfo.OccurrenceCount = 10
            aptPattern.RecurrenceInfo.Start = nowtime.AddDays(-4)
            aptPattern.HasReminder = True
            aptPattern.Reminder.TimeBeforeStart = TimeSpan.FromMinutes(15)
            schedulerStorage1.Appointments.Add(aptPattern)
        End Sub

        Private Sub schedulerStorage1_ReminderAlert(ByVal sender As Object, ByVal e As ReminderEventArgs)
            ' Create a new appointment
            Dim app As Appointment = schedulerStorage1.CreateAppointment(AppointmentType.Normal)
            app.Subject = "Created on alert from appointment w/Price = " & e.AlertNotifications(0).ActualAppointment.CustomFields("CustomPrice")
            app.Start = e.AlertNotifications(0).ActualAppointment.Start.AddHours(2)
            app.Duration = TimeSpan.FromHours(4)
            schedulerStorage1.Appointments.Add(app)
            ' Modify the appointment for which the alert is triggered
            e.AlertNotifications(0).ActualAppointment.LabelId = 3
            ' Prevent the event from being fired one more time
            e.AlertNotifications(0).ActualAppointment.Reminder.Dismiss()
        End Sub

        Private Sub schedulerControl1_AppointmentViewInfoCustomizing(ByVal sender As Object, ByVal e As AppointmentViewInfoCustomizingEventArgs)
            Dim apt As Appointment = e.ViewInfo.Appointment
            If apt.HasReminder AndAlso apt.Type = AppointmentType.Occurrence AndAlso apt.RecurrencePattern IsNot Nothing Then
                Dim pattern As Appointment = apt.RecurrencePattern
                Dim reminder As RecurringReminder = CType(pattern.Reminder, RecurringReminder)
                e.ViewInfo.ShowBell = reminder.AlertOccurrenceIndex <= apt.RecurrenceIndex
            End If
        End Sub

        Private Sub SelectedAppointments_CollectionChanged(ByVal sender As Object, ByVal e As DevExpress.Utils.CollectionChangedEventArgs(Of Appointment))
            memoAptInfo.Text = ""
            If schedulerControl1.SelectedAppointments.Count = 0 Then Return
            Dim apt As Appointment = schedulerControl1.SelectedAppointments(0)
            If apt IsNot Nothing AndAlso apt.IsRecurring Then
                Dim nextOcc As Appointment = apt.RecurrencePattern.GetOccurrence(apt.RecurrenceIndex + 1)
                memoAptInfo.Text = "The next occurrence has index " & nextOcc.RecurrenceIndex & " and Price=" & nextOcc.CustomFields("CustomPrice") & Microsoft.VisualBasic.Constants.vbCrLf
                If apt.HasReminder Then
                    memoAptInfo.Text += "The reminder alert starts at " & apt.Reminder.AlertTime
                End If
            End If
        End Sub
    End Class
End Namespace

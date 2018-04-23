Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraEditors

Namespace ReminderCustomActions
    Partial Public Class Form1
        Inherits XtraForm

        Private timeBeforeAlert As Integer = 15 ' seconds
        Private timeBeforeStart As Integer = 15 * 60 ' seconds
        Private checkInterval As Integer = 1 ' seconds

        Public Sub New()
            InitializeComponent()
            ' Create a custom field named CustomPrice. The Scheduler is not bound to a data source so the Price name is not used.
            schedulerStorage1.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("CustomPrice", "Price"))
            ' Subscribe to invoke a custom form.
            AddHandler schedulerControl1.EditAppointmentFormShowing, AddressOf SchedulerControl1_EditAppointmentFormShowing
            ' Subscribe to hide reminder icons for occurrences in the past.
            AddHandler schedulerControl1.AppointmentViewInfoCustomizing, AddressOf SchedulerControl1_AppointmentViewInfoCustomizing
            '  Subscribe to update appointment info displayed in the text box on the main form.
            AddHandler schedulerControl1.SelectedAppointments.CollectionChanged, AddressOf SelectedAppointments_CollectionChanged

'            #Region "#reminder_init"
            ' Handle this event to perform a custom action when a reminder alert is fired.
            AddHandler schedulerStorage1.ReminderAlert, AddressOf SchedulerStorage1_ReminderAlert
            ' Specify the interval at which the reminder is polled for alert.
            schedulerStorage1.RemindersCheckInterval = checkInterval * 1000
            ' Hide the reminder alert window.
            schedulerControl1.OptionsBehavior.ShowRemindersForm = False
'            #End Region ' #reminder_init

            schedulerControl1.ActiveViewType = SchedulerViewType.Day
            schedulerControl1.DayView.DayCount = 2

            schedulerControl1.Start = Date.Today
            schedulerControl1.DayView.TopRowTime = TimeSpan.FromHours(Date.Now.Hour)

            Me.timer1.Interval = 1000
            Me.progressBarControl1.Properties.Minimum = 0
            Me.progressBarControl1.Properties.Maximum = timeBeforeAlert
            Me.progressBarControl1.Position = timeBeforeAlert
            Me.progressBarControl1.Properties.Step = -1
            Me.progressBarControl1.Visible = False
            AddHandler Me.timer1.Tick, AddressOf Timer1_Tick
        End Sub

        Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
            Dim apTime As Date = Date.Now.AddSeconds(timeBeforeStart + timeBeforeAlert)
            Dim aptPattern As Appointment = schedulerStorage1.CreateAppointment(AppointmentType.Pattern)
            aptPattern.Subject = "Appointment with Reminder"
            aptPattern.Description = "Recurring appointment with reminder"
            aptPattern.Duration = TimeSpan.FromHours(2)
            aptPattern.StatusKey = CInt((AppointmentStatusType.Busy))
            aptPattern.LabelKey = 1
            aptPattern.CustomFields("CustomPrice") = CDec(15.25)

            aptPattern.RecurrenceInfo.Type = RecurrenceType.Daily
            aptPattern.RecurrenceInfo.Periodicity = 2
            aptPattern.RecurrenceInfo.Range = RecurrenceRange.OccurrenceCount
            aptPattern.RecurrenceInfo.OccurrenceCount = 10
            aptPattern.RecurrenceInfo.Start = apTime.AddDays(-4)

            aptPattern.HasReminder = True
            aptPattern.Reminder.TimeBeforeStart = TimeSpan.FromSeconds(timeBeforeStart)

            schedulerStorage1.Appointments.Add(aptPattern)

            Me.timer1.Start()
            Me.progressBarControl1.Visible = True
        End Sub
        #Region "#reminderalert"
        Private Sub SchedulerStorage1_ReminderAlert(ByVal sender As Object, ByVal e As ReminderEventArgs)
            ' Create a new appointment.
            Dim app As Appointment = schedulerStorage1.CreateAppointment(AppointmentType.Normal)
            app.Subject = String.Format("Created on alert from appointment w/Price = {0}", e.AlertNotifications(0).ActualAppointment.CustomFields("CustomPrice"))
            app.Start = e.AlertNotifications(0).ActualAppointment.Start.AddHours(2)
            app.Duration = TimeSpan.FromHours(4)
            schedulerStorage1.Appointments.Add(app)

            ' Modify the appointment for which the alert is triggered.
            e.AlertNotifications(0).ActualAppointment.LabelKey = 3

            ' Prevent the event from being fired one more time.
            e.AlertNotifications(0).ActualAppointment.Reminder.Dismiss()
        End Sub
        #End Region ' #reminderalert

        Private Sub SchedulerControl1_AppointmentViewInfoCustomizing(ByVal sender As Object, ByVal e As AppointmentViewInfoCustomizingEventArgs)
            Dim apt As Appointment = e.ViewInfo.Appointment
            If apt.HasReminder AndAlso apt.Type = AppointmentType.Occurrence AndAlso apt.RecurrencePattern IsNot Nothing Then
                Dim pattern As Appointment = apt.RecurrencePattern
                Dim reminder As RecurringReminder = CType(pattern.Reminder, RecurringReminder)
                e.ViewInfo.ShowBell = reminder.AlertOccurrenceIndex <= apt.RecurrenceIndex
            End If
        End Sub

        Private Sub SchedulerControl1_EditAppointmentFormShowing(ByVal sender As Object, ByVal e As AppointmentFormEventArgs)
            Dim apt As Appointment = e.Appointment
            Dim openRecurrenceForm As Boolean = apt.IsRecurring AndAlso schedulerStorage1.Appointments.IsNewAppointment(apt)

            Dim myForm As New MyAppointmentEditForm(DirectCast(sender, SchedulerControl), apt, openRecurrenceForm)
            Try
                myForm.LookAndFeel.ParentLookAndFeel = Me.LookAndFeel.ParentLookAndFeel
                e.DialogResult = myForm.ShowDialog()
                e.Handled = True
            Finally
                myForm.Dispose()
            End Try
        End Sub

        Private Sub btnCreateAppReminder_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim apTime As Date = Date.Now.AddSeconds(timeBeforeStart + timeBeforeAlert)
            Dim aptPattern As Appointment = schedulerStorage1.CreateAppointment(AppointmentType.Pattern)
            aptPattern.Subject = "Appointment with Reminder"
            aptPattern.Description = "Recurring appointment with reminder"
            aptPattern.Duration = TimeSpan.FromHours(2)
            aptPattern.StatusKey = CInt((AppointmentStatusType.Busy))
            aptPattern.LabelKey = 1
            aptPattern.CustomFields("CustomPrice") = CDec(15.25)

            aptPattern.RecurrenceInfo.Type = RecurrenceType.Daily
            aptPattern.RecurrenceInfo.Periodicity = 2
            aptPattern.RecurrenceInfo.Range = RecurrenceRange.OccurrenceCount
            aptPattern.RecurrenceInfo.OccurrenceCount = 10
            aptPattern.RecurrenceInfo.Start = apTime.AddDays(-4)

            aptPattern.HasReminder = True
            aptPattern.Reminder.TimeBeforeStart = TimeSpan.FromSeconds(timeBeforeStart)

            Me.timer1.Start()
            schedulerStorage1.Appointments.Add(aptPattern)
        End Sub


        ' Display selected appointment info in the text box on the main form.
        Private Sub SelectedAppointments_CollectionChanged(ByVal sender As Object, ByVal e As DevExpress.Utils.CollectionChangedEventArgs(Of Appointment))
            memoEdit1.Text = ""
            If schedulerControl1.SelectedAppointments.Count = 0 Then
                Return
            End If

            Dim apt As Appointment = schedulerControl1.SelectedAppointments(0)
            If apt IsNot Nothing AndAlso apt.IsRecurring Then
                Dim nextOcc As Appointment = apt.RecurrencePattern.GetOccurrence(apt.RecurrenceIndex + 1)
                memoEdit1.Text = String.Format("The next occurrence has index {0} and Price= {1} {2}", nextOcc.RecurrenceIndex, nextOcc.CustomFields("CustomPrice"), ControlChars.CrLf)
                If apt.HasReminder Then
                    memoEdit1.Text &= "The reminder alert starts at " & apt.Reminder.AlertTime
                End If
            End If
        End Sub

        Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs)
            If Me.progressBarControl1.Position > Me.progressBarControl1.Properties.Minimum Then
                Me.progressBarControl1.PerformStep()
            Else
                timer1.Stop()
                Me.progressBarControl1.Position = Me.progressBarControl1.Properties.Maximum
                Me.progressBarControl1.Visible = False
            End If
            Me.progressBarControl1.Update()
        End Sub

    End Class
End Namespace

Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.UI

Namespace CustomFormFieldsReminder

    Public Partial Class MyAppointmentEditForm
        Inherits DevExpress.XtraEditors.XtraForm

        Private control As SchedulerControl

        Private apt As Appointment

        Private openRecurrenceForm As Boolean = False

        Private suspendUpdateCount As Integer

        Private checkAllDay As DevExpress.XtraEditors.CheckEdit

        ' Note that the MyAppointmentFormController class is inherited from
        ' the AppointmentFormController one to add custom properties.
        ' See its declaration at the end of this file.
        Private controller As MyAppointmentFormController

        Public Sub New(ByVal control As SchedulerControl, ByVal apt As Appointment, ByVal openRecurrenceForm As Boolean)
            Me.openRecurrenceForm = openRecurrenceForm
            controller = New MyAppointmentFormController(control, apt)
            Me.apt = apt
            Me.control = control
            '
            ' Required for Windows Form Designer support
            '
            SuspendUpdate()
            InitializeComponent()
            ResumeUpdate()
            UpdateForm()
        '
        ' TODO: Add any constructor code after InitializeComponent call
        '
        End Sub

        Protected ReadOnly Property Appointments As AppointmentStorage
            Get
                Return control.Storage.Appointments
            End Get
        End Property

        Protected ReadOnly Property IsUpdateSuspended As Boolean
            Get
                Return suspendUpdateCount > 0
            End Get
        End Property

        Protected Sub SuspendUpdate()
            suspendUpdateCount += 1
        End Sub

        Protected Sub ResumeUpdate()
            If suspendUpdateCount > 0 Then suspendUpdateCount -= 1
        End Sub

        Private Sub btnAddRec_Click(ByVal sender As Object, ByVal e As EventArgs)
            OnRecurrenceButton()
        End Sub

        Private Sub OnRecurrenceButton()
            ShowRecurrenceForm()
        End Sub

        Private Sub ShowRecurrenceForm()
            If Not control.SupportsRecurrence Then Return
            ' Prepare to edit appointment's recurrence.
            Dim editedAptCopy As Appointment = controller.EditedAppointmentCopy
            Dim editedPattern As Appointment = controller.EditedPattern
            Dim patternCopy As Appointment = controller.PrepareToRecurrenceEdit()
            Dim dlg As AppointmentRecurrenceForm = New AppointmentRecurrenceForm(patternCopy, control.OptionsView.FirstDayOfWeek, controller)
            ' Required for skins support.
            dlg.LookAndFeel.ParentLookAndFeel = LookAndFeel.ParentLookAndFeel
            Dim result As DialogResult = dlg.ShowDialog(Me)
            dlg.Dispose()
            If result = DialogResult.Abort Then
                controller.RemoveRecurrence()
            ElseIf result = DialogResult.OK Then
                controller.ApplyRecurrence(patternCopy)
                If controller.EditedAppointmentCopy IsNot editedAptCopy Then UpdateForm()
            End If

            UpdateIntervalControls()
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Required to check appointment's conflicts.
            If Not controller.IsConflictResolved() Then Return
            controller.Subject = txSubject.Text
            controller.SetStatus(edStatus.Status)
            controller.SetLabel(edLabel.Label)
            controller.AllDay = checkAllDay.Checked
            controller.Start = dtStart.DateTime.Date + timeStart.Time.TimeOfDay
            controller.End = dtEnd.DateTime.Date + timeEnd.Time.TimeOfDay
            controller.ResourceIds.AddRange(appointmentResourcesEdit1.ResourceIds)
            controller.CustomPrice = calcPrice.Value
            ' Save all changes made to the appointment edited in a form.
            controller.ApplyChanges()
        End Sub

        Private Sub UpdateForm()
            SuspendUpdate()
            Try
                txSubject.Text = controller.Subject
                edStatus.Status = Appointments.Statuses(controller.StatusId)
                edLabel.Label = Appointments.Labels(controller.LabelId)
                dtStart.DateTime = controller.Start.Date
                dtEnd.DateTime = controller.End.Date
                timeStart.Time = Date.MinValue.AddTicks(controller.Start.TimeOfDay.Ticks)
                timeEnd.Time = Date.MinValue.AddTicks(controller.End.TimeOfDay.Ticks)
                checkAllDay.Checked = controller.AllDay
                edStatus.Storage = control.Storage
                edLabel.Storage = control.Storage
                appointmentResourcesEdit1.SchedulerControl = control
                Dim resourceIds As AppointmentResourceIdCollection = appointmentResourcesEdit1.ResourceIds
                resourceIds.BeginUpdate()
                Try
                    resourceIds.Clear()
                    resourceIds.AddRange(controller.ResourceIds)
                Finally
                    resourceIds.EndUpdate()
                End Try

                Dim canEditResource As Boolean = controller.CanEditResource
                appointmentResourcesEdit1.Enabled = canEditResource
                lblResource.Enabled = canEditResource
                calcPrice.Value = controller.CustomPrice
            Finally
                ResumeUpdate()
            End Try

            UpdateIntervalControls()
        End Sub

        Private Sub MyAppointmentEditForm_Activated(ByVal sender As Object, ByVal e As EventArgs)
            ' Required to show the recurrence form.
            If openRecurrenceForm Then
                openRecurrenceForm = False
                OnRecurrenceButton()
            End If
        End Sub

        Private Sub dtStart_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Not IsUpdateSuspended Then controller.Start = dtStart.DateTime.Date + timeStart.Time.TimeOfDay
            UpdateIntervalControls()
        End Sub

        Protected Overridable Sub UpdateIntervalControls()
            If IsUpdateSuspended Then Return
            SuspendUpdate()
            Try
                dtStart.EditValue = controller.Start.Date
                dtEnd.EditValue = controller.End.Date
                timeStart.EditValue = controller.Start.TimeOfDay
                timeEnd.EditValue = controller.End.TimeOfDay
                dtStart.Enabled = Not controller.AllDay
                dtEnd.Enabled = Not controller.AllDay
                timeStart.Enabled = Not controller.AllDay
                timeEnd.Enabled = Not controller.AllDay
            Finally
                ResumeUpdate()
            End Try
        End Sub

        Private Sub timeStart_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Not IsUpdateSuspended Then controller.Start = dtStart.DateTime.Date + timeStart.Time.TimeOfDay
            UpdateIntervalControls()
        End Sub

        Private Sub timeEnd_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            If IsUpdateSuspended Then Return
            If IsIntervalValid() Then
                controller.End = dtEnd.DateTime + timeEnd.Time.TimeOfDay
            Else
                timeEnd.EditValue = controller.End.TimeOfDay
            End If
        End Sub

        Private Sub dtEnd_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            If IsUpdateSuspended Then Return
            If IsIntervalValid() Then
                controller.End = dtEnd.DateTime + timeEnd.Time.TimeOfDay
            Else
                dtEnd.EditValue = controller.End.Date
            End If
        End Sub

        Private Function IsIntervalValid() As Boolean
            Dim start As Date = dtStart.DateTime + timeStart.Time.TimeOfDay
            Dim [end] As Date = dtEnd.DateTime + timeEnd.Time.TimeOfDay
            Return [end] >= start
        End Function

        Private Sub checkAllDay_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            controller.AllDay = checkAllDay.Checked
            If Not IsUpdateSuspended Then UpdateAppointmentStatus()
            UpdateIntervalControls()
        End Sub

        Private Sub UpdateAppointmentStatus()
            Dim currentStatus As AppointmentStatus = edStatus.Status
            Dim newStatus As AppointmentStatus = controller.UpdateAppointmentStatus(currentStatus)
            If newStatus IsNot currentStatus Then edStatus.Status = newStatus
        End Sub
    End Class

    Public Class MyAppointmentFormController
        Inherits AppointmentFormController

        Public Property CustomPrice As Decimal
            Get
                Return If(EditedAppointmentCopy.CustomFields("CustomPrice") IsNot Nothing, CDec(EditedAppointmentCopy.CustomFields("CustomPrice")), 0)
            End Get

            Set(ByVal value As Decimal)
                EditedAppointmentCopy.CustomFields("CustomPrice") = value
            End Set
        End Property

        Private Property SourceCustomPrice As Decimal
            Get
                Return CDec(SourceAppointment.CustomFields("CustomPrice"))
            End Get

            Set(ByVal value As Decimal)
                SourceAppointment.CustomFields("CustomPrice") = value
            End Set
        End Property

        Public Sub New(ByVal control As SchedulerControl, ByVal apt As Appointment)
            MyBase.New(control, apt)
        End Sub

        Public Overrides Function IsAppointmentChanged() As Boolean
            If MyBase.IsAppointmentChanged() Then Return True
            Return SourceCustomPrice <> CustomPrice
        End Function

        Protected Overrides Sub ApplyCustomFieldsValues()
            SourceCustomPrice = CustomPrice
        End Sub
    End Class
End Namespace

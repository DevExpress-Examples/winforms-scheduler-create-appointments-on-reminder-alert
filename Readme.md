<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128633552/18.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E382)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WinForms Scheduler - Create an appointment with custom fields, reccurrence, and reminders

* Run the project.
* Click the **Create Appointment Series with Reminder** button.
* The alert will be fired in 15 seconds. Before this happens, open the newly created appointment, change its "Price" value, and save your changes.

![WinForms Scheduler Control](https://raw.githubusercontent.com/DevExpress-Examples/custom-form-custom-fields-and-custom-actions-on-reminder-alert-e382/18.1.3%2B/media/winforms-scheduler-reminder-alert.gif)

The example demonstrates how to:

* Create an appointment with custom fields, reccurrence, and reminders.

  ```csharp
  private void btnCreateAppReminder_Click(object sender, EventArgs e) {
      DateTime apTime = DateTime.Now.AddSeconds(timeBeforeStart + timeBeforeAlert);
      Appointment aptPattern = schedulerDataStorage1.CreateAppointment(AppointmentType.Pattern);
      aptPattern.Subject = "Appointment with Reminder";
      aptPattern.Description = "Recurring appointment with reminder";
      aptPattern.Duration = TimeSpan.FromHours(2);
      aptPattern.StatusKey = (int)AppointmentStatusType.OutOfOffice;
      aptPattern.LabelKey = 2;
      aptPattern.CustomFields["CustomPrice"] = (decimal)15.25;
      aptPattern.Start = DateTime.Now;
      aptPattern.RecurrenceInfo.Type = RecurrenceType.Daily;
      aptPattern.RecurrenceInfo.Periodicity = 2;
      aptPattern.RecurrenceInfo.Range = RecurrenceRange.OccurrenceCount;
      aptPattern.RecurrenceInfo.OccurrenceCount = 10;
      aptPattern.RecurrenceInfo.Start = apTime.AddDays(-4);
      aptPattern.HasReminder = true;
      aptPattern.Reminder.TimeBeforeStart = TimeSpan.FromSeconds(timeBeforeStart);
      schedulerDataStorage1.Appointments.Add(aptPattern);
      this.timer1.Start();
      this.progressBarControl1.Visible = true;
  }
  ```
* Handle reminders.

  ```csharp
  private void SchedulerDataStorage1_ReminderAlert(object sender, ReminderEventArgs e) {
      // Create a new appointment.
      Appointment app = schedulerDataStorage1.CreateAppointment(AppointmentType.Normal);
      app.Subject = "Created on alert from appointment w/Price = " + e.AlertNotifications[0].ActualAppointment.CustomFields["CustomPrice"];
      app.Start = e.AlertNotifications[0].ActualAppointment.Start.AddHours(2);
      app.Duration = TimeSpan.FromHours(4);
      schedulerDataStorage1.Appointments.Add(app);
      e.AlertNotifications[0].ActualAppointment.LabelKey = 3;
      // Prevent the event from being fired one more time.
      e.AlertNotifications[0].ActualAppointment.Reminder.Dismiss();
  }
  ```
* Create and display a custom edit form.
  
  ```csharp
  private void SchedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e) {
      SchedulerControl scheduler = sender as SchedulerControl;
      Appointment apt = e.Appointment;
      bool openRecurrenceForm = apt.IsRecurring && scheduler.DataStorage.Appointments.IsNewAppointment(apt);
      MyAppointmentEditForm myForm = new MyAppointmentEditForm(scheduler, apt, openRecurrenceForm);
      try {
          myForm.LookAndFeel.ParentLookAndFeel = this.LookAndFeel.ParentLookAndFeel;
          e.DialogResult = myForm.ShowDialog();
          e.Handled = true;
      } finally {
          myForm.Dispose();
      }
  ```
* Access custom fields for occurrences.


## Documentation

* [Appointments](https://docs.devexpress.com/WindowsForms/1753/controls-and-libraries/scheduler/appointments)
* [Reminders for Appointments](https://docs.devexpress.com/WindowsForms/1778/controls-and-libraries/scheduler/appointments/reminders-for-appointments)

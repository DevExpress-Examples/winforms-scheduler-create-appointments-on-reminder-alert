using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraEditors;

namespace ReminderCustomActions {
    public partial class Form1 : XtraForm {
        int timeBeforeAlert = 15; /* seconds */
        int timeBeforeStart = 15 * 60; /* seconds */
        int checkInterval = 1; /* seconds */

        public Form1() {
            InitializeComponent();
            // Create a custom field named CustomPrice. The Scheduler is not bound to a data source so the Price name is not used.
            schedulerStorage1.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("CustomPrice", "Price"));
            // Subscribe to invoke a custom form.
            schedulerControl1.EditAppointmentFormShowing += SchedulerControl1_EditAppointmentFormShowing;
            // Subscribe to hide reminder icons for occurrences in the past.
            schedulerControl1.AppointmentViewInfoCustomizing += SchedulerControl1_AppointmentViewInfoCustomizing;
            // Subscribe to update appointment info displayed in the text box on the main form.
            schedulerControl1.SelectedAppointments.CollectionChanged += new DevExpress.Utils.CollectionChangedEventHandler<Appointment>(SelectedAppointments_CollectionChanged);

            #region #reminder_init
            // Handle this event to perform a custom action when a reminder alert is fired.
            schedulerStorage1.ReminderAlert += SchedulerStorage1_ReminderAlert;
            // Specify the interval at which the reminder is polled for alert.
            schedulerStorage1.RemindersCheckInterval = checkInterval * 1000;
            // Hide the reminder alert window.
            schedulerControl1.OptionsBehavior.ShowRemindersForm = false;
            #endregion #reminder_init

            schedulerControl1.ActiveViewType = SchedulerViewType.Day;
            schedulerControl1.DayView.DayCount = 2;

            schedulerControl1.Start = DateTime.Today;
            schedulerControl1.DayView.TopRowTime = TimeSpan.FromHours(DateTime.Now.Hour);

            this.timer1.Interval = 1000;
            this.progressBarControl1.Properties.Minimum = 0;
            this.progressBarControl1.Properties.Maximum = timeBeforeAlert;
            this.progressBarControl1.Position = timeBeforeAlert;
            this.progressBarControl1.Properties.Step = -1;
            this.progressBarControl1.Visible = false;
            this.timer1.Tick += Timer1_Tick;
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            DateTime apTime = DateTime.Now.AddSeconds(timeBeforeStart + timeBeforeAlert);
            Appointment aptPattern = schedulerStorage1.CreateAppointment(AppointmentType.Pattern);
            aptPattern.Subject = "Appointment with Reminder";
            aptPattern.Description = "Recurring appointment with reminder";
            aptPattern.Duration = TimeSpan.FromHours(2);
            aptPattern.StatusKey = (int)AppointmentStatusType.OutOfOffice;
            aptPattern.LabelKey = 2;
            aptPattern.CustomFields["CustomPrice"] = (decimal)15.25;

            aptPattern.RecurrenceInfo.Type = RecurrenceType.Daily;
            aptPattern.RecurrenceInfo.Periodicity = 2;
            aptPattern.RecurrenceInfo.Range = RecurrenceRange.OccurrenceCount;
            aptPattern.RecurrenceInfo.OccurrenceCount = 10;
            aptPattern.RecurrenceInfo.Start = apTime.AddDays(-4);

            aptPattern.HasReminder = true;
            aptPattern.Reminder.TimeBeforeStart = TimeSpan.FromSeconds(timeBeforeStart);

            schedulerStorage1.Appointments.Add(aptPattern);

            this.timer1.Start();
            this.progressBarControl1.Visible = true;
        }
        #region #reminderalert
        private void SchedulerStorage1_ReminderAlert(object sender, ReminderEventArgs e) {
            // Create a new appointment.
            Appointment app = schedulerStorage1.CreateAppointment(AppointmentType.Normal);
            app.Subject = "Created on alert from appointment w/Price = " + e.AlertNotifications[0].ActualAppointment.CustomFields["CustomPrice"];
            app.Start = e.AlertNotifications[0].ActualAppointment.Start.AddHours(2);
            app.Duration = TimeSpan.FromHours(4);
            schedulerStorage1.Appointments.Add(app);

            // Modify the appointment for which the alert is triggered.
            e.AlertNotifications[0].ActualAppointment.LabelKey = 3;

            // Prevent the event from being fired one more time.
            e.AlertNotifications[0].ActualAppointment.Reminder.Dismiss();
        }
        #endregion #reminderalert

        private void SchedulerControl1_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e) {
            Appointment apt = e.ViewInfo.Appointment;
            if (apt.HasReminder && apt.Type == AppointmentType.Occurrence && apt.RecurrencePattern != null) {
                Appointment pattern = apt.RecurrencePattern;
                RecurringReminder reminder = (RecurringReminder)pattern.Reminder;
                e.ViewInfo.ShowBell = reminder.AlertOccurrenceIndex <= apt.RecurrenceIndex;
            }
        }

        private void SchedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e) {
            Appointment apt = e.Appointment;
            bool openRecurrenceForm = apt.IsRecurring && schedulerStorage1.Appointments.IsNewAppointment(apt);

            MyAppointmentEditForm myForm = new MyAppointmentEditForm((SchedulerControl)sender, apt, openRecurrenceForm);
            try {
                myForm.LookAndFeel.ParentLookAndFeel = this.LookAndFeel.ParentLookAndFeel;
                e.DialogResult = myForm.ShowDialog();
                e.Handled = true;
            }
            finally {
                myForm.Dispose();
            }
        }

        private void btnCreateAppReminder_Click(object sender, EventArgs e) {
            DateTime apTime = DateTime.Now.AddSeconds(timeBeforeStart + timeBeforeAlert);
            Appointment aptPattern = schedulerStorage1.CreateAppointment(AppointmentType.Pattern);
            aptPattern.Subject = "Appointment with Reminder";
            aptPattern.Description = "Recurring appointment with reminder";
            aptPattern.Duration = TimeSpan.FromHours(2);
            aptPattern.StatusKey = (int)AppointmentStatusType.Busy;
            aptPattern.LabelKey = 1;
            aptPattern.CustomFields["CustomPrice"] = (decimal)15.25;

            aptPattern.RecurrenceInfo.Type = RecurrenceType.Daily;
            aptPattern.RecurrenceInfo.Periodicity = 2;
            aptPattern.RecurrenceInfo.Range = RecurrenceRange.OccurrenceCount;
            aptPattern.RecurrenceInfo.OccurrenceCount = 10;
            aptPattern.RecurrenceInfo.Start = apTime.AddDays(-4);

            aptPattern.HasReminder = true;
            aptPattern.Reminder.TimeBeforeStart = TimeSpan.FromSeconds(timeBeforeStart);

            this.timer1.Start();
            schedulerStorage1.Appointments.Add(aptPattern);
        }


        // Display selected appointment info in the text box on the main form.
        void SelectedAppointments_CollectionChanged(object sender, DevExpress.Utils.CollectionChangedEventArgs<Appointment> e) {
            memoEdit1.Text = "";
            if (schedulerControl1.SelectedAppointments.Count == 0) return;

            Appointment apt = schedulerControl1.SelectedAppointments[0];
            if (apt != null && apt.IsRecurring) {
                Appointment nextOcc = apt.RecurrencePattern.GetOccurrence(apt.RecurrenceIndex + 1);
                memoEdit1.Text = "The next occurrence has index " + nextOcc.RecurrenceIndex + " and Price=" + nextOcc.CustomFields["CustomPrice"]
                    + "\r\n";
                if (apt.HasReminder) {
                    memoEdit1.Text += "The reminder alert starts at " + apt.Reminder.AlertTime;
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            if (this.progressBarControl1.Position > this.progressBarControl1.Properties.Minimum) {
                this.progressBarControl1.PerformStep();
            }            else {
                timer1.Stop();
                this.progressBarControl1.Position = this.progressBarControl1.Properties.Maximum;
                this.progressBarControl1.Visible = false;
            }
            this.progressBarControl1.Update();
        }

    }
}

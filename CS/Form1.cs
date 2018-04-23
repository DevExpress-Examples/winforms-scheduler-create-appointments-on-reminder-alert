using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraEditors;
using System.Data.OleDb;

namespace CustomFormFieldsReminder {
    public partial class Form1 : XtraForm {
        public Form1() {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e) {

            schedulerControl1.SelectedAppointments.CollectionChanged+=new DevExpress.Utils.CollectionChangedEventHandler<Appointment>(SelectedAppointments_CollectionChanged);

            schedulerControl1.OptionsBehavior.ShowRemindersForm = false;
            schedulerControl1.OptionsBehavior.RemindersFormDefaultAction = RemindersFormDefaultAction.Custom;

            schedulerControl1.ActiveViewType = SchedulerViewType.Day;
            schedulerControl1.DayView.DayCount = 2;
            schedulerControl1.DayView.ResourcesPerPage = 2;
            schedulerControl1.GroupType = SchedulerGroupType.Resource;
            schedulerControl1.OptionsView.ResourceHeaders.ImageSize = new Size(100, 50);
            schedulerControl1.OptionsView.ResourceHeaders.ImageSizeMode = HeaderImageSizeMode.ZoomImage;

            schedulerControl1.Start = DateTime.Today;
            
            // TODO: This line of code loads data into the 'carsDBDataSet.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.carsDBDataSet.Cars);
            // TODO: This line of code loads data into the 'carsDBDataSet.CarScheduling' table. You can move, or remove it, as needed.
            this.carSchedulingTableAdapter.Fill(this.carsDBDataSet.CarScheduling);
            this.carSchedulingTableAdapter.Adapter.RowUpdated += new OleDbRowUpdatedEventHandler(carSchedulingTableAdapter_RowUpdated);

        }



        private void schedulerControl1_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e) {
            Appointment apt = e.Appointment;
            bool openRecurrenceForm = apt.IsRecurring && schedulerStorage1.Appointments.IsNewAppointment(apt);

            MyAppointmentEditForm f = new MyAppointmentEditForm((SchedulerControl)sender, apt, openRecurrenceForm);
            try {
                f.LookAndFeel.ParentLookAndFeel = this.LookAndFeel.ParentLookAndFeel;
                e.DialogResult = f.ShowDialog();
                e.Handled = true;

                if (apt.Type == AppointmentType.Pattern && schedulerControl1.SelectedAppointments.Contains(apt))
                    schedulerControl1.SelectedAppointments.Remove(apt);

                schedulerControl1.Refresh();
            }
            finally {
            f.Dispose();
            }
        }

        private void schedulerStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e) {
            carSchedulingTableAdapter.Update(this.carsDBDataSet);
            this.carsDBDataSet.AcceptChanges();
        }

        private void carSchedulingTableAdapter_RowUpdated(object sender, OleDbRowUpdatedEventArgs e) {
            if(e.Status == UpdateStatus.Continue && e.StatementType == StatementType.Insert) {
                int id = 0;
                using(OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY", carSchedulingTableAdapter.Connection)) {
                    id = (int)cmd.ExecuteScalar();
                }
                e.Row["ID"] = id;
            }
        }
        private void btnCreateAppReminder_Click(object sender, EventArgs e) {
            DateTime nowtime = DateTime.Now.AddMinutes(16);
            Appointment aptPattern = schedulerStorage1.CreateAppointment(AppointmentType.Pattern);
            aptPattern.Subject = "Appointment with Reminder";
            aptPattern.Description = "Recurrence Appointment with reminder";
            aptPattern.Duration = TimeSpan.FromHours(2);
            aptPattern.ResourceId = schedulerStorage1.Resources[0].Id;
            aptPattern.StatusId = (int)AppointmentStatusType.Busy;
            aptPattern.LabelId = 1;
            aptPattern.CustomFields["CustomPrice"] = (decimal)15.25;

            aptPattern.RecurrenceInfo.Type = RecurrenceType.Daily;
            aptPattern.RecurrenceInfo.Periodicity = 2;
            aptPattern.RecurrenceInfo.Range = RecurrenceRange.OccurrenceCount;
            aptPattern.RecurrenceInfo.OccurrenceCount = 10;
            aptPattern.RecurrenceInfo.Start = nowtime.AddDays(-4);

            aptPattern.HasReminder = true;
            aptPattern.Reminder.TimeBeforeStart = TimeSpan.FromMinutes(15);


            schedulerStorage1.Appointments.Add(aptPattern);
        }

        private void schedulerStorage1_ReminderAlert(object sender, ReminderEventArgs e) {
            // Create a new appointment
            Appointment app = schedulerStorage1.CreateAppointment(AppointmentType.Normal);
            app.Subject = "Created on alert from appointment w/Price = " + e.AlertNotifications[0].ActualAppointment.CustomFields["CustomPrice"];
            app.Start = e.AlertNotifications[0].ActualAppointment.Start.AddHours(2);
            app.Duration = TimeSpan.FromHours(4);
            schedulerStorage1.Appointments.Add(app);

            // Modify the appointment for which the alert is triggered
            e.AlertNotifications[0].ActualAppointment.LabelId = 3;

            // Prevent the event from being fired one more time
            e.AlertNotifications[0].ActualAppointment.Reminder.Dismiss();
        }

        private void schedulerControl1_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e) {
            Appointment apt = e.ViewInfo.Appointment;
            if (apt.HasReminder && apt.Type == AppointmentType.Occurrence && apt.RecurrencePattern != null) {
                Appointment pattern = apt.RecurrencePattern;
                RecurringReminder reminder = (RecurringReminder)pattern.Reminder;
                e.ViewInfo.ShowBell = reminder.AlertOccurrenceIndex <= apt.RecurrenceIndex;
            }
        }


        void SelectedAppointments_CollectionChanged(object sender, DevExpress.Utils.CollectionChangedEventArgs<Appointment> e) {
            memoAptInfo.Text = "";
            if (schedulerControl1.SelectedAppointments.Count == 0) return;

            Appointment apt = schedulerControl1.SelectedAppointments[0];            
            if (apt != null && apt.IsRecurring) {
                Appointment nextOcc = apt.RecurrencePattern.GetOccurrence(apt.RecurrenceIndex + 1);
                memoAptInfo.Text = "The next occurrence has index " + nextOcc.RecurrenceIndex + " and Price=" + nextOcc.CustomFields["CustomPrice"]
                    + "\r\n";
                if (apt.HasReminder) {
                    memoAptInfo.Text += "The reminder alert starts at " + apt.Reminder.AlertTime;                
                }

               }
            



        }
       
    }
}
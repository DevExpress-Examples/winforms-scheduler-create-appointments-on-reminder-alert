<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128633552/17.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E382)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/ReminderCustomActions/Form1.cs) (VB: [Form1.vb](./VB/ReminderCustomActions/Form1.vb))
* [MyAppointmentEditForm.cs](./CS/ReminderCustomActions/Forms/MyAppointmentEditForm.cs) (VB: [MyAppointmentEditForm.vb](./VB/ReminderCustomActions/Forms/MyAppointmentEditForm.vb))
* [Program.cs](./CS/ReminderCustomActions/Program.cs) (VB: [Program.vb](./VB/ReminderCustomActions/Program.vb))
<!-- default file list end -->
# Custom form, custom fields and custom actions on reminder alert


<p>The problem:</p>
<p>Here is what I want to do:</p>
<p>1) Create an appointment with custom fields and an alarm<br> 2) Add an occurrence for that appointment with alarm as well<br> 3) Prevent the alarm from showing and insert my own code for all occurrences<br> 4) Being able to access the custom fields data for all occurrences<br> 5) Dismiss the handled recurrent appointment</p>
<p>The solution:</p>
<p>Run the attached project. Click the "Create appointment with reminder" button. See the appointment series created at a current time of the day. The alert will be fired in 15 seconds by default. Before it happens, open the newly created today's appointment, change its "Price" value and save it. When the reminder is triggered, a new appointment is created with a Subject line informing of the changed value for the Price custom field.</p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-create-appointments-on-reminder-alert&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-create-appointments-on-reminder-alert&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->

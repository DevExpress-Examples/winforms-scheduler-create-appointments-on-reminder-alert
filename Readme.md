<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E382)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [MyAppointmentEditForm.cs](./CS/Forms/MyAppointmentEditForm.cs) (VB: [MyAppointmentEditForm.vb](./VB/Forms/MyAppointmentEditForm.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
<!-- default file list end -->
# Custom form, custom fields and custom actions on reminder alert


<p>The problem:</p>
<p>Here is what I want to do:</p>
<p>1) Create an appointment with custom fields and an alarm<br> 2) Add an occurrence for that appointment with alarm as well<br> 3) Prevent the alarm from showing and insert my own code for all occurrences<br> 4) Being able to access the custom fields data for all occurrences<br> 5) Dismiss the handled recurrent appointment</p>
<p>The solution:</p>
<p>Run the attached project. Click the "Create appointment with reminder" button. See the appointment series created at a current time of the day. The alert will be fired in 15 seconds by default. Before it happens, open the newly created today's appointment, change its "Price" value and save it. When the reminder is triggered, a new appointment is created with a Subject line informing of the changed value for the Price custom field.</p>

<br/>



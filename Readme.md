<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs)
* [MyAppointmentEditForm.cs](./CS/Forms/MyAppointmentEditForm.cs)
<!-- default file list end -->
# Custom form, custom fields and custom actions on reminder alert


<p>The problem:</p>
<p>Here is what I want to do:</p>
<p>1) Create an appointment with custom fields and an alarm<br> 2) Add an occurrence for that appointment with alarm as well<br> 3) Prevent the alarm from showing and insert my own code for all occurrences<br> 4) Being able to access the custom fields data for all occurrences<br> 5) Dismiss the handled recurrent appointment</p>
<p>The solution:</p>
<p>Run the attached project. Click the "Create appointment with reminder" button. See the appointment series created at a current time of the day. The alert will be fired in 15 seconds by default. Before it happens, open the newly created today's appointment, change its "Price" value and save it. When the reminder is triggered, a new appointment is created with a Subject line informing of the changed value for the Price custom field.</p>

<br/>



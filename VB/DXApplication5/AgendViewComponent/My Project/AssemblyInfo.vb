' Developer Express Code Central Example:
' How to display appointments in Agenda View by using the GridControl component
' 
' In fact, the Agenda view is a list of upcoming events grouped by the
' appointment's date. This list can be displayed in the GridControl component
' (https://documentation.devexpress.com/#WindowsForms/CustomDocument3464).
' 
' This
' example demonstrates how to implement this behavior.
' 
' 
' Switching between the
' SchedulerControl's view and a GridControl instance (used as an AgendaView) is
' implemented by switching the visibility of the SchedulerControl and GridControl
' instances.
' 
' Since multi-day appointments should be displayed as several
' GridView rows (such appointments should be displayed in each "Day" group in
' accordance with the appointment's duration), we used a separate
' AgendaAppointment class to store the appointment's data.
' 
' To get existing
' appointments from the SchedulerStorage and generate a corresponding collection
' of AgendaAppointment instances, the SchedulerStorage.GetAppointments
' (https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerSchedulerStorageBase_GetAppointmentstopic1830)
' method is used.
' 
' By default, a month interval is used to fetch appointments for
' the AgendaView.
' 
' 
' Please see the "Implementation Details" (click the
' corresponding link below this text) to learn more about technical aspects of
' this approach implementation.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E5186


Imports Microsoft.VisualBasic
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.
<Assembly: AssemblyTitle("AgendViewComponent")>
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyConfiguration("")>
<Assembly: AssemblyCompany("")>
<Assembly: AssemblyProduct("AgendViewComponent")>
<Assembly: AssemblyCopyright("Copyright ©  2014")>
<Assembly: AssemblyTrademark("")>
<Assembly: AssemblyCulture("")>

' Setting ComVisible to false makes the types in this assembly not visible 
' to COM components.  If you need to access a type in this assembly from 
' COM, set the ComVisible attribute to true on that type.
<Assembly: ComVisible(False)>

' The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("ef931ae8-4cf8-4caa-bb95-de8f616bc53b")>

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:
' [assembly: AssemblyVersion("1.0.*")]
<Assembly: AssemblyVersion("1.0.0.0")>
<Assembly: AssemblyFileVersion("1.0.0.0")>

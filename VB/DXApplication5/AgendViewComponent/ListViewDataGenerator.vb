Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraScheduler
Imports System.ComponentModel
Imports System.Drawing

Namespace ListViewComponent
	Public NotInheritable Class ListViewDataGenerator
		Private Sub New()
		End Sub
		Public Shared Function GenerateResourcesCollection(ByVal storage As SchedulerStorage) As Object
			Return storage.Resources.Items
		End Function

		Public Shared Function GenerateListViewAppointmentCollection(ByVal storage As AppointmentStorage, ByVal sourceAppointments As AppointmentBaseCollection, ByVal dayOfWeek As DayOfWeek) As Object
			Dim listViewAppointments As New BindingList(Of ListViewAppointment)()
			For Each appointment As Appointment In sourceAppointments
				listViewAppointments.Add(CreateListViewAppointment(storage, appointment, dayOfWeek))

			Next appointment
			Return listViewAppointments
		End Function

		Public Shared Function CreateListViewAppointment(ByVal storage As AppointmentStorage, ByVal sourceAppointment As Appointment, ByVal dayOfWeek As DayOfWeek) As ListViewAppointment
			Dim listViewAppointment As New ListViewAppointment()
			listViewAppointment.ListViewDate = sourceAppointment.Start

			listViewAppointment.ListViewSubject = sourceAppointment.Subject
			listViewAppointment.ListViewRecurrencePattern = RecurrenceInfo.GetDescription(sourceAppointment, dayOfWeek)
			listViewAppointment.ListViewIsRecurring = sourceAppointment.IsRecurring
			listViewAppointment.ListViewDuration = sourceAppointment.Duration.ToString()
			listViewAppointment.ListViewAppointmentID = sourceAppointment.Id
			listViewAppointment.ListViewLocation = sourceAppointment.Location
			listViewAppointment.ListViewStatus = storage.Statuses(sourceAppointment.StatusId)

			listViewAppointment.ListViewLabel = storage.Labels(sourceAppointment.LabelId).Color
			listViewAppointment.SourceAppointment = sourceAppointment
			Return listViewAppointment
		End Function
	End Class

	' ListView appointment
	Public Class ListViewAppointment
		Public Property ListViewStatus() As AppointmentStatus
		Public Property ListViewSubject() As String
		Public Property ListViewDuration() As String
		Public Property ListViewLocation() As String
		Public Property ListViewRecurrencePattern() As String
		Public Property ListViewIsRecurring() As Boolean
		Public Property ListViewDate() As DateTime
		Public Property ListViewLabel() As Color
		Public Property SourceAppointment() As Appointment
		Public Property ListViewAppointmentID() As Object
	End Class
End Namespace

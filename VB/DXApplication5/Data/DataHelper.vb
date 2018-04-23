Imports Microsoft.VisualBasic
Imports DevExpress.XtraScheduler
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq

Namespace DXApplication5
	Public NotInheritable Class DataHelper


		Private Shared Users() As String = { "Peter Dolan", "Ryan Fischer", "Andrew Miller", "Tom Hamlett", "Jerry Campbell", "Carl Lucas", "Mark Hamilton", "Steve Lee" }

		Private Sub New()
		End Sub
		Public Shared Sub FillResources(ByVal storage As SchedulerStorage, ByVal count As Integer)

			Dim cnt As Integer = Math.Min(count, Users.Length)
			For i As Integer = 1 To cnt
				Dim resource As Resource = storage.CreateResource(i)
				resource.Caption = Users(i - 1)
				storage.Resources.Add(resource)
			Next i
		End Sub

		Public Shared Sub GenerateEvents(ByVal storage As SchedulerStorage, ByVal count As Integer)

			For i As Integer = 0 To count - 1
				Dim resource As Resource = storage.Resources(i)
				Dim subjPrefix As String = resource.Caption & "'s "
				If i Mod 2 = 0 Then
					storage.Appointments.Add(CreateEvent(storage, subjPrefix & "meeting", resource.Id, 2, 5))
					storage.Appointments.Add(CreateEvent(storage, subjPrefix & "travel", resource.Id, 3, 6))
					storage.Appointments.Add(CreateEvent(storage, subjPrefix & "phone call", resource.Id, 0, 10))
				Else
					storage.Appointments.Add(CreateRecurrentEvent(storage, subjPrefix & "meeting", resource.Id, 2, 5))
				End If
			Next i
		End Sub
		Private Shared Function CreateRecurrentEvent(ByVal storage As SchedulerStorage, ByVal subject As String, ByVal resourceId As Object, ByVal status As Integer, ByVal label As Integer) As Appointment
			Dim apt As Appointment = storage.CreateAppointment(AppointmentType.Pattern)
			apt.Subject = subject
			apt.ResourceId = resourceId
			apt.Start = DateTime.Today.AddHours(9).AddMinutes(30)
			apt.End = apt.Start.AddHours(2)
			apt.StatusId = status
			apt.LabelId = label

			apt.RecurrenceInfo.Type = RecurrenceType.Daily
			apt.RecurrenceInfo.Start = apt.Start
			apt.RecurrenceInfo.Periodicity = 5
			apt.RecurrenceInfo.Range = RecurrenceRange.EndByDate
			apt.RecurrenceInfo.End = apt.RecurrenceInfo.Start.AddMonths(1)
			Return apt
		End Function

		Private Shared Function CreateEvent(ByVal storage As SchedulerStorage, ByVal subject As String, ByVal resourceId As Object, ByVal status As Integer, ByVal label As Integer) As Appointment
			Dim apt As Appointment = storage.CreateAppointment(AppointmentType.Normal)
			apt.Subject = subject
			apt.ResourceId = resourceId
			apt.Start = DateTime.Today.AddHours(9).AddMinutes(30)
			apt.End = apt.Start.AddHours(2)
			apt.StatusId = status
			apt.LabelId = label
			Return apt
		End Function
	End Class
End Namespace

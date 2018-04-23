Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid

Namespace ListViewComponent
	Partial Public Class ListViewControl
		Inherits UserControl
		#Region "Fields"
		Private OwnerScheduler As SchedulerControl
		Private appointmentImages As ImageCollection
		Private reStatus As RepositoryItemImageComboBox
		#End Region
        Public Sub New(ByVal scheduler As SchedulerControl)
            InitializeComponent()
            OwnerScheduler = scheduler

            appointmentImages = DevExpress.Utils.Controls.ImageHelper.CreateImageCollectionFromResources("AppointmentImages.png", System.Reflection.Assembly.GetExecutingAssembly(), New Size(15, 15))
            reStatus = TryCast(GridControlAppointments.RepositoryItems.Add("ImageComboBoxEdit"), RepositoryItemImageComboBox)
            gridViewAppointments.Columns("ListViewStatus").ColumnEdit = reStatus

        End Sub



		#Region "Methods"
		Private Function FindRow(ByVal apt As Appointment, <System.Runtime.InteropServices.Out()> ByRef dataSource As BindingList(Of ListViewAppointment)) As ListViewAppointment
			dataSource = TryCast(gridViewAppointments.DataSource, BindingList(Of ListViewAppointment))
			Return dataSource.Where(Function(listViewApt) listViewApt.ListViewAppointmentID = apt.Id).FirstOrDefault()
		End Function
		Public Sub DeleteAppointment(ByVal apt As Appointment)
			Dim dataSource As BindingList(Of ListViewAppointment)
			Dim result As ListViewAppointment = FindRow(apt, dataSource)

			If result IsNot Nothing Then
				dataSource.Remove(result)
			End If

		End Sub

		Public Sub ChangeAppointment(ByVal apt As Appointment)
			DeleteAppointment(apt)
			Dim datasource As BindingList(Of ListViewAppointment) =TryCast(gridViewAppointments.DataSource, BindingList(Of ListViewAppointment))
			datasource.Add(ListViewDataGenerator.CreateListViewAppointment(OwnerScheduler.Storage.Appointments, apt, OwnerScheduler.FirstDayOfWeek))
		End Sub
		Private Function GetFilteredAppointments(ByVal interval As TimeInterval) As AppointmentBaseCollection
			Dim aptCollection As AppointmentBaseCollection = OwnerScheduler.Storage.GetAppointments(interval)
			Dim copyCollection As New AppointmentBaseCollection()
			For i As Integer = 0 To aptCollection.Count - 1
				If aptCollection(i).Type <> AppointmentType.Occurrence Then
					copyCollection.Add(aptCollection(i))
				Else
					If (Not copyCollection.Contains(aptCollection(i).RecurrencePattern)) Then
						copyCollection.Add(aptCollection(i).RecurrencePattern)
					End If
				End If
			Next i

			Return copyCollection
		End Function
		Private Sub InitializeGridControlAppointments()
			Dim sourceAppointmentCollection As AppointmentBaseCollection = GetFilteredAppointments(New TimeInterval(DateTime.MinValue, DateTime.MaxValue))
			GridControlAppointments.DataSource = ListViewDataGenerator.GenerateListViewAppointmentCollection(OwnerScheduler.Storage.Appointments, sourceAppointmentCollection, OwnerScheduler.FirstDayOfWeek)
		End Sub
		Public Sub SetSearchControl(ByVal searchControl As SearchControl)
			InitializeGridControlAppointments()
			searchControl.Client = GridControlAppointments

			gridViewAppointments.ExpandAllGroups()

			CreateCustomColorsForStatuses(reStatus)
		End Sub
		Private Function GetLightenColor(ByVal inColor As Color, ByVal inAmount As Double) As Color
			Return Color.FromArgb(inColor.A, CInt(Fix(Math.Min(255, inColor.R + 255 * inAmount))), CInt(Fix(Math.Min(255, inColor.G + 255 * inAmount))), CInt(Fix(Math.Min(255, inColor.B + 255 * inAmount))))
		End Function

		Private Sub CreateCustomColorsForStatuses(ByVal riImageComboBox As RepositoryItemImageComboBox)
			For Each status As AppointmentStatus In OwnerScheduler.Storage.Appointments.Statuses
				riImageComboBox.Items.Add(New ImageComboBoxItem(status.Color.ToString(), status))
			Next status

			Dim imagesColors As New ImageList()
			riImageComboBox.SmallImages = imagesColors

			For Each item As ImageComboBoxItem In riImageComboBox.Items
				Dim iWidth As Integer = 16
				Dim iHeight As Integer = 16
				Dim bmp As New Bitmap(iWidth, iHeight)
				Using g As Graphics = Graphics.FromImage(bmp)
					g.DrawRectangle(New Pen(Color.Black, 2), 0, 0, iWidth, iHeight)
					g.FillRectangle(New SolidBrush((TryCast(item.Value, AppointmentStatus)).Color), 1, 1, iWidth - 2, iHeight - 2)

				End Using
				imagesColors.Images.Add(bmp)
				item.ImageIndex = imagesColors.Images.Count - 1
			Next item
		End Sub

		#End Region


		#Region "Event Handlers"
		Private Sub gridViewAppointments_CustomUnboundColumnData(ByVal sender As Object, ByVal e As CustomColumnDataEventArgs) Handles gridViewAppointments.CustomUnboundColumnData
			Dim currentApt As Appointment = (TryCast(e.Row, ListViewAppointment)).SourceAppointment
			If e.Column.FieldName = "gridColumnReminder" AndAlso e.IsGetData AndAlso currentApt.HasReminder Then
				e.Value = appointmentImages.Images(4)
			End If
		End Sub

		Private Sub gridViewAppointments_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridViewAppointments.RowStyle
			Dim currentView As GridView = TryCast(sender, GridView)
			If (Not currentView.IsGroupRow(e.RowHandle)) Then
				Dim currentAppointment As ListViewAppointment = TryCast((TryCast(sender, GridView)).GetRow(e.RowHandle), ListViewAppointment)
				e.Appearance.BackColor = currentAppointment.ListViewLabel
			End If
		End Sub

		Private Sub gridViewAppointments_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles gridViewAppointments.PopupMenuShowing
			If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
				Dim currentView As GridView = TryCast(sender, GridView)
				Dim agendaAppointment As ListViewAppointment = TryCast(currentView.GetRow(e.HitInfo.RowHandle), ListViewAppointment)
				ListViewMenuBuilder.GenerateContextMenu(Me, e.Menu, OwnerScheduler, agendaAppointment.SourceAppointment)
			End If
			If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.EmptyRow Then
				If e.Menu Is Nothing Then
					e.Menu = New DevExpress.XtraGrid.Menu.GridViewMenu(TryCast(sender, GridView))
				End If
				ListViewMenuBuilder.GenerateContextMenu(Me, e.Menu, OwnerScheduler, Nothing)
			End If
		End Sub

		Private Sub gridViewAppointments_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles gridViewAppointments.CustomDrawCell
			Dim view As GridView = TryCast(sender, GridView)
			If e.RowHandle = view.FocusedRowHandle Then
				If (Not view.IsGroupRow(e.RowHandle)) Then
					Dim currentAppointment As ListViewAppointment = TryCast((TryCast(sender, GridView)).GetRow(e.RowHandle), ListViewAppointment)
					e.Appearance.BackColor = GetLightenColor(currentAppointment.ListViewLabel, 0.1)
				End If
			End If
		End Sub

		Private Sub gridViewAppointments_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles gridViewAppointments.DoubleClick
			Dim currentView As GridView = TryCast(sender, GridView)
			If (Not currentView.IsGroupRow(currentView.FocusedRowHandle)) Then
				ListViewMenuBuilder.Scheduler = OwnerScheduler
				Dim listViewAppointment As ListViewAppointment = TryCast(currentView.GetRow(currentView.FocusedRowHandle), ListViewAppointment)
				ListViewMenuBuilder.CurrentAppointment = listViewAppointment.SourceAppointment
				ListViewMenuBuilder.ViewControl = Me
				ListViewMenuBuilder.OnOpenCurrentAppointment(Nothing, Nothing)
			End If
		End Sub
		Private Sub gridViewAppointments_CustomColumnDisplayText(ByVal sender As Object, ByVal e As CustomColumnDisplayTextEventArgs) Handles gridViewAppointments.CustomColumnDisplayText
			If e.IsForGroupRow Then
				Dim groupSummary As GridGroupSummaryItem = TryCast(gridViewAppointments.GroupSummary(0), GridGroupSummaryItem)
				Dim groupSummaryValue As Object = gridViewAppointments.GetGroupSummaryValue(e.GroupRowHandle, groupSummary)
				e.DisplayText = If(e.DisplayText = String.Empty, String.Format("{0}: none: {1} items", e.Column.Caption, Convert.ToInt32(groupSummaryValue)), String.Format("{0}: {1}: {2} items", e.Column.Caption, e.DisplayText, Convert.ToInt32(groupSummaryValue)))

			End If
		End Sub

		#End Region 


	End Class
End Namespace

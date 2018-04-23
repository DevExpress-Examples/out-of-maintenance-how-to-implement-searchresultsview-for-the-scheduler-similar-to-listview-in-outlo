Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors

Namespace ListViewComponent
	Partial Public Class GoToDateDialog
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Property SelectedDate() As DateTime
			Get
				Return dateEditGoToDate.DateTime
			End Get
			Set(ByVal value As DateTime)
				dateEditGoToDate.EditValue = value
			End Set
		End Property
	End Class
End Namespace

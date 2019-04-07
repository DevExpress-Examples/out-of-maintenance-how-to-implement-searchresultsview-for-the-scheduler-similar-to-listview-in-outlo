Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraScheduler
Imports DevExpress.Utils
Imports DevExpress.Data.Filtering

Namespace DXApplication5
    Public Class CustomSchedulerControl
        Inherits SchedulerControl
        Implements ISearchControlClient
#Region "ISearchControlClient Members"

        Public Sub ApplyFindFilter(ByVal searchInfo As SearchInfoBase) Implements ISearchControlClient.ApplyFindFilter
            If searchInfo Is Nothing Then
                Return
            End If
            Dim si As SchedulerSearchInfo = TryCast(searchInfo, SchedulerSearchInfo)
            Dim filterCondition As FilterCondition = si.FilterCondition
            Dim searchtext As String = si.SearchText

            If searchtext Is Nothing Then
                ResetFilter()
                Return
            End If

            Dim filterCriteria As CriteriaOperator = PrepareFilter(searchtext, filterCondition)
            Me.Storage.Appointments.Filter = filterCriteria.ToString()
        End Sub

        Private Sub ResetFilter()
            If Me.Storage IsNot Nothing Then
                Me.Storage.Appointments.Filter = Nothing
            End If
        End Sub
        Private Function PrepareFilter(ByVal searchString As String, ByVal condition As FilterCondition) As CriteriaOperator
            Select Case condition
                Case FilterCondition.Contains
                    Return GroupOperator.Or(New FunctionOperator(FunctionOperatorType.Contains, "Subject", searchString), New FunctionOperator(FunctionOperatorType.Contains, "Location", searchString))
                Case FilterCondition.StartsWith
                    Return GroupOperator.Or(New FunctionOperator(FunctionOperatorType.StartsWith, New OperandProperty("Subject"), searchString), New FunctionOperator(FunctionOperatorType.StartsWith, New OperandProperty("Location"), searchString))
                Case FilterCondition.Like
                    Return GroupOperator.Or(New FunctionOperator(FunctionOperatorType.Contains, New OperandProperty("Subject"), searchString), New FunctionOperator(FunctionOperatorType.Contains, New OperandProperty("Location"), searchString))
                Case FilterCondition.Default
                    Return GroupOperator.Or(New FunctionOperator(FunctionOperatorType.Contains, New OperandProperty("Subject"), searchString), New FunctionOperator(FunctionOperatorType.Contains, New OperandProperty("Location"), searchString))
                Case FilterCondition.Equals
                    Return GroupOperator.Or(New BinaryOperator("Subject", searchString, BinaryOperatorType.Equal), New BinaryOperator("Location", searchString, BinaryOperatorType.Equal))
                Case Else
                    Return Nothing
            End Select

        End Function


        Public Function CreateSearchProvider() As SearchControlProviderBase Implements ISearchControlClient.CreateSearchProvider
            Return New SchedulerSearchProvider()
        End Function
        Private srchControl As ISearchControl
        Public ReadOnly Property IsAttachedToSearchControl() As Boolean Implements ISearchControlClient.IsAttachedToSearchControl
            Get
                Return srchControl IsNot Nothing
            End Get
        End Property

        Public Sub SetSearchControl(ByVal searchControl As ISearchControl) Implements ISearchControlClient.SetSearchControl
            If srchControl Is searchControl Then
                Return
            End If
            ResetFilter()
            srchControl = searchControl
        End Sub

#End Region
    End Class
End Namespace

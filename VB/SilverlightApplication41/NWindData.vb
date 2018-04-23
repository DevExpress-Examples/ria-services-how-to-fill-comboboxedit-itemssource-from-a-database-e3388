Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports SilverlightApplication41.Web
Imports System.Threading
Imports System.ServiceModel.DomainServices.Client

Namespace SilverlightApplication41
	Public NotInheritable Class NWindData
		Private Shared Event loaded As EventHandler
		Private Shared loadingDone As Boolean
		Private Shared loadingDoneUnlock As New AutoResetEvent(True) ' mutex, protect loadingDone and loaded
		Private Shared loadingStarted As Boolean
		Private Shared loadingStartedUnlock As New AutoResetEvent(True) ' mutex, protect loadingStarted
		Private Shared dc As New NWindContext()
		Private Shared tablesCount As Integer = 0
		Private Shared tablesLoaded As Integer = 0
		Private Sub New()
		End Sub
		Public Shared Sub Load()
			loadingStartedUnlock.WaitOne()
			If (Not loadingStarted) Then
				loadingStarted = True
				Dim thread As New Thread(New ThreadStart(AddressOf StartLoading))
				thread.Start()
			End If
			loadingStartedUnlock.Set()
			loadingDoneUnlock.WaitOne()
			If loadingDone Then
				RaiseEvent loaded(GetType(NWindData), EventArgs.Empty)
				loadedEvent = Nothing
			End If
			loadingDoneUnlock.Set()
		End Sub
		Private Shared Sub StartLoading()
			tablesCount = 1
			dc.Load(dc.GetProductsQuery(), New Action(Of LoadOperation(Of Product))(AddressOf TLoaded), Nothing)
		End Sub
		Public Shared Custom Event LoadedEv As EventHandler
			AddHandler(ByVal value As EventHandler)
				loadingDoneUnlock.WaitOne()
				AddHandler loaded, value
				loadingDoneUnlock.Set()
			End AddHandler
			RemoveHandler(ByVal value As EventHandler)
				loadingDoneUnlock.WaitOne()
				RemoveHandler loaded, value
				loadingDoneUnlock.Set()
			End RemoveHandler
			RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
			End RaiseEvent
		End Event

		Private Shared Sub TLoaded(ByVal op As LoadOperation(Of Product))
			TableLoaded()
		End Sub
		Private Shared Sub TableLoaded()
'INSTANT VB TODO TASK: Assignments within expressions are not supported in VB.NET
'ORIGINAL LINE: if (++tablesLoaded >= tablesCount)
			If ++tablesLoaded >= tablesCount Then
				loadingDoneUnlock.WaitOne()
				loadingDone = True
				If loadedEvent IsNot Nothing Then
					RaiseEvent loaded(GetType(NWindData), EventArgs.Empty)
					loadedEvent = Nothing
				End If
				loadingDoneUnlock.Set()
			End If
		End Sub
		Public Shared ReadOnly Property Products() As EntitySet(Of Product)
			Get
				Return dc.Products
			End Get
		End Property
	End Class
End Namespace

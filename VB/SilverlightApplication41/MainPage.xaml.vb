Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Controls
Imports System.Windows
Imports System.Collections


Namespace SilverlightApplication41
	Partial Public Class MainPage
		Inherits UserControl

		Public Shared ReadOnly ProductsProperty As DependencyProperty = DependencyProperty.Register("Products", GetType(IEnumerable), GetType(MainPage), New PropertyMetadata(Nothing))

		Public Property Products() As IEnumerable
			Get
				Return CType(GetValue(ProductsProperty), IEnumerable)
			End Get
			Set(ByVal value As IEnumerable)
				SetValue(ProductsProperty, value)
			End Set
		End Property

		Public Sub New()
			InitializeComponent()
			DataContext = Me

			AddHandler NWindData.LoadedEv, AddressOf NWindData_Loaded
			NWindData.Load()
		End Sub

		Private Sub NWindData_Loaded(ByVal sender As Object, ByVal e As EventArgs)
			Products = NWindData.Products
		End Sub
	End Class
End Namespace
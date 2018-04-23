Imports Microsoft.VisualBasic
	Imports System
	Imports System.Collections.Generic
	Imports System.ComponentModel
	Imports System.ComponentModel.DataAnnotations
	Imports System.Linq
	Imports System.ServiceModel.DomainServices.Hosting
	Imports System.ServiceModel.DomainServices.Server
Namespace SilverlightApplication41.Web


	' The MetadataTypeAttribute identifies ProductMetadata as the class
	' that carries additional metadata for the Product class.
	<MetadataTypeAttribute(GetType(Product.ProductMetadata))> _
	Partial Public Class Product

		' This class allows you to attach custom attributes to properties
		' of the Product class.
		'
		' For example, the following marks the Xyz property as a
		' required property and specifies the format for valid values:
		'    [Required]
		'    [RegularExpression("[A-Z][A-Za-z0-9]*")]
		'    [StringLength(32)]
		'    public string Xyz { get; set; }
		Friend NotInheritable Class ProductMetadata

			' Metadata classes are not meant to be instantiated.
			Private Sub New()
			End Sub

			Private privateCategoryID? As Integer
			Public Property CategoryID() As Integer?
				Get
					Return privateCategoryID
				End Get
				Set(ByVal value? As Integer)
					privateCategoryID = value
				End Set
			End Property

			Private privateDiscontinued As Boolean
			Public Property Discontinued() As Boolean
				Get
					Return privateDiscontinued
				End Get
				Set(ByVal value As Boolean)
					privateDiscontinued = value
				End Set
			End Property

			Private privateProductID As Integer
			Public Property ProductID() As Integer
				Get
					Return privateProductID
				End Get
				Set(ByVal value As Integer)
					privateProductID = value
				End Set
			End Property

			Private privateProductName As String
			Public Property ProductName() As String
				Get
					Return privateProductName
				End Get
				Set(ByVal value As String)
					privateProductName = value
				End Set
			End Property

			Private privateQuantityPerUnit As String
			Public Property QuantityPerUnit() As String
				Get
					Return privateQuantityPerUnit
				End Get
				Set(ByVal value As String)
					privateQuantityPerUnit = value
				End Set
			End Property

			Private privateReorderLevel? As Short
			Public Property ReorderLevel() As Short?
				Get
					Return privateReorderLevel
				End Get
				Set(ByVal value? As Short)
					privateReorderLevel = value
				End Set
			End Property

			Private privateSupplierID? As Integer
			Public Property SupplierID() As Integer?
				Get
					Return privateSupplierID
				End Get
				Set(ByVal value? As Integer)
					privateSupplierID = value
				End Set
			End Property

			Private privateUnitPrice? As Decimal
			Public Property UnitPrice() As Decimal?
				Get
					Return privateUnitPrice
				End Get
				Set(ByVal value? As Decimal)
					privateUnitPrice = value
				End Set
			End Property

			Private privateUnitsInStock? As Short
			Public Property UnitsInStock() As Short?
				Get
					Return privateUnitsInStock
				End Get
				Set(ByVal value? As Short)
					privateUnitsInStock = value
				End Set
			End Property

			Private privateUnitsOnOrder? As Short
			Public Property UnitsOnOrder() As Short?
				Get
					Return privateUnitsOnOrder
				End Get
				Set(ByVal value? As Short)
					privateUnitsOnOrder = value
				End Set
			End Property
		End Class
	End Class
End Namespace

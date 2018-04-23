
namespace SilverlightApplication41.Web {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies ProductMetadata as the class
    // that carries additional metadata for the Product class.
    [MetadataTypeAttribute(typeof(Product.ProductMetadata))]
    public partial class Product {

        // This class allows you to attach custom attributes to properties
        // of the Product class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ProductMetadata {

            // Metadata classes are not meant to be instantiated.
            private ProductMetadata() {
            }

            public Nullable<int> CategoryID { get; set; }

            public bool Discontinued { get; set; }

            public int ProductID { get; set; }

            public string ProductName { get; set; }

            public string QuantityPerUnit { get; set; }

            public Nullable<short> ReorderLevel { get; set; }

            public Nullable<int> SupplierID { get; set; }

            public Nullable<decimal> UnitPrice { get; set; }

            public Nullable<short> UnitsInStock { get; set; }

            public Nullable<short> UnitsOnOrder { get; set; }
        }
    }
}

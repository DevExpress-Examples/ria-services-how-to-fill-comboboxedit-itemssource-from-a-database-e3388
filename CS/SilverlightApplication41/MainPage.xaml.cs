using System;
using System.Windows.Controls;
using System.Windows;
using System.Collections;


namespace SilverlightApplication41 {
    public partial class MainPage : UserControl {

        public static readonly DependencyProperty ProductsProperty =
            DependencyProperty.Register("Products", typeof(IEnumerable), typeof(MainPage), new PropertyMetadata(null));

        public IEnumerable Products {
            get { return (IEnumerable)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }

        public MainPage() {
            InitializeComponent();
            DataContext = this;

            NWindData.Loaded += new EventHandler(NWindData_Loaded);
            NWindData.Load();
        }

        void NWindData_Loaded(object sender, EventArgs e) {
            Products = NWindData.Products;
        }
    }
}
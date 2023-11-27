using LopushokApp.ApplicationData;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LopushokApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Product _product;
        public AddEditPage(Product product)
        {
            InitializeComponent();
            _product = product;
            DataContext = _product;

            ProductTypeComboBox.Items.Add("Тип продукта");
            foreach(var type in DbWorker.GetContext().ProductType)
            {
                ProductTypeComboBox.Items.Add(type.name);
            }

            if (product.productArcticle == null )
            {
                ProductTypeComboBox.SelectedIndex = 0;
            }
            else
            {
                ProductType typeOfProduct = DbWorker.GetContext().ProductType.FirstOrDefault(x => x.productTypeId == product.productTypeId);
                ProductTypeComboBox.SelectedItem = typeOfProduct.name;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProductTypeComboBox.SelectedIndex > 0)
                {
                    ProductType selectedProductType = DbWorker.GetContext().ProductType.FirstOrDefault(x => x.name == ProductTypeComboBox.Text);
                    _product.productTypeId = selectedProductType.productTypeId;
                }
                else
                {
                    MessageBox.Show("chosse product type");
                }
                DbWorker.GetContext().Product.AddOrUpdate(_product);
                DbWorker.GetContext().SaveChanges();
                MessageBox.Show("succes");
            }
            catch
            {
                MessageBox.Show("something get wrong, mb u tryin to change PK");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.mainFrame.Navigate(new ProductsPage());
        }
    }
}

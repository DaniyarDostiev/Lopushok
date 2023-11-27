using LopushokApp.ApplicationData;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();

            SortComboBox.Items.Add("Сортировка");
            SortComboBox.Items.Add("Название воз.");
            SortComboBox.Items.Add("Название уб.");
            SortComboBox.Items.Add("Цех воз.");
            SortComboBox.Items.Add("Цех уб.");
            SortComboBox.Items.Add("Мин. цена воз.");
            SortComboBox.Items.Add("Мин. цена уб.");
            SortComboBox.SelectedIndex = 0;

            FilterComboBox.Items.Add("Все типы");
            foreach (var type in DbWorker.GetContext().ProductType)
            {
                FilterComboBox.Items.Add(type.name);
            }
            FilterComboBox.SelectedIndex = 0;
        }

        private void UpdateList()
        {
            List<Product> products = DbWorker.GetContext().Product.Where(x => x.name.Contains(FinderTextBox.Text)).ToList();

            if (SortComboBox.SelectedIndex > 0)
            {
                if (SortComboBox.SelectedItem.Equals("Название воз."))
                {
                    products = products.OrderBy(x => x.name).ToList();
                }
                else if (SortComboBox.SelectedItem.Equals("Название уб."))
                {
                    products = products.OrderByDescending(x => x.name).ToList();
                }
                else if (SortComboBox.SelectedItem.Equals("Цех воз."))
                {
                    products = products.OrderBy(x => x.numberOfManufacture).ToList();
                }
                else if (SortComboBox.SelectedItem.Equals("Цех уб."))
                {
                    products = products.OrderByDescending(x => x.numberOfManufacture).ToList();
                }
                else if (SortComboBox.SelectedItem.Equals("Мин. цена воз."))
                {
                    products = products.OrderBy(x => x.minPriceForAgent).ToList();
                }
                else if (SortComboBox.SelectedItem.Equals("Мин. цена уб."))
                {
                    products = products.OrderByDescending(x => x.minPriceForAgent).ToList();
                }
            }


            if (FilterComboBox.SelectedIndex > 0)
            {
                ProductType selectedType = DbWorker.GetContext().ProductType.FirstOrDefault(x => x.name.Equals(FilterComboBox.SelectedItem.ToString()));
                products = products.Where(x => x.productTypeId == selectedType.productTypeId).ToList();
            }

            ProductsDataGrid.ItemsSource = products;
        }



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.mainFrame.Navigate(new AddEditPage(new Product()));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = ProductsDataGrid.SelectedItem as Product;
            try
            {
                var needToDel = DbWorker.GetContext().ProductMaterial.Where(x => x.productArtcile.Equals(selectedProduct.productArcticle)).ToList();
                DbWorker.GetContext().ProductMaterial.RemoveRange(needToDel);
                DbWorker.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DbWorker.GetContext().Product.Remove(selectedProduct);
            DbWorker.GetContext().SaveChanges();
            MessageBox.Show("succes");
            UpdateList();
            //try
            //{
            //    DbWorker.GetContext().Product.Remove(selectedProduct);
            //    DbWorker.GetContext().SaveChanges();
            //    MessageBox.Show("succes");
            //    UpdateList();
            //}
            //catch
            //{
            //    MessageBox.Show("error");
            //}
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = ProductsDataGrid.SelectedItem as Product;
            AppFrame.mainFrame.Navigate(new AddEditPage(selectedProduct));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DbWorker.GetContext().SaveChanges();
                MessageBox.Show("succes");
                UpdateList();
            }
            catch
            {
                MessageBox.Show("exception");
            }
        }

        private void FinderTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }
    }
}

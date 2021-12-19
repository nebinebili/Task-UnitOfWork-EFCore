using Microsoft.EntityFrameworkCore;
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
using UnitofWork_GenericRepo_EFTask.Context;
using UnitofWork_GenericRepo_EFTask.Models;
using UnitofWork_GenericRepo_EFTask.UnitOfWork.Concrete;
using UnitofWork_GenericRepo_EFTask.Views;

namespace UnitofWork_GenericRepo_EFTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UnitofWork unitofWork;
        public MainWindow()
        {
            InitializeComponent();
            unitofWork = new UnitofWork(new MyDbContext());
            datagrid_category.ItemsSource = unitofWork.CategoryRepo.GetAll().Include(b => b.Books).ToList();
        }

        void Refresh()
        {
            datagrid_category.ItemsSource = unitofWork.CategoryRepo.GetAll().Include(b => b.Books).ToList();
        }

        private void btn_books_Click(object sender, RoutedEventArgs e)
        {
            var category = datagrid_category.SelectedItem as Category;
            var result = unitofWork.BookRepo.Query(p => p.CategoryId == category.Id).ToList();
            datagrid_book.ItemsSource = result;
        }

        private void btn_addCategory_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.grid_category.Visibility = Visibility.Visible;
            addWindow.ShowDialog();
            Refresh();
        }

        private void btn_removeCategory_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid_category.SelectedIndex != -1)
            {
                unitofWork.CategoryRepo.Remove(datagrid_category.SelectedItem as Category);
                unitofWork.Complete();
                Refresh();
                datagrid_book.ItemsSource = null;
            }
            else MessageBox.Show("Select Category!");
            
        }

        private void btn_addproduct_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.grid_product.Visibility = Visibility.Visible;
            addWindow.ShowDialog();
        }

        private void btn_removeproduct_Click(object sender, RoutedEventArgs e)
        {
            
            if(datagrid_book.SelectedIndex != -1)
            {
               unitofWork.BookRepo.Remove(datagrid_book.SelectedItem as Book);
               unitofWork.Complete();
               datagrid_book.ItemsSource = null;
               MessageBox.Show("Remove Book Succesffuly!");
            }
            else
                MessageBox.Show("Select Book!");

        }

        private void btn_editCategory_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid_category.SelectedIndex != -1)
            {
                AddWindow addWindow = new AddWindow();
                addWindow.grid_category.Visibility = Visibility.Visible;
                var category = datagrid_category.SelectedItem as Category;
                addWindow.txb_nameCategory.Text = category.Name;
                addWindow.Category = category;
                addWindow._Update = true;
                addWindow.ShowDialog();
                Refresh();
            }
            else MessageBox.Show("Select Category!");
        }

        private void btn_editproduct_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid_book.SelectedIndex != -1)
            {
                AddWindow addWindow = new AddWindow();
                addWindow.grid_product.Visibility = Visibility.Visible;
                var book = datagrid_book.SelectedItem as Book;
                addWindow.txb_nameP.Text = book.Name;
                addWindow.txb_price.Text = book.Price.ToString();
                addWindow.txb_quantity.Text = book.Quantity.ToString();
                addWindow.txb_categoryId.Text = book.CategoryId.ToString();
                addWindow.Book = book;
                addWindow._Update = true;
                addWindow.ShowDialog();
            }
            else MessageBox.Show("Select Book!");
            
        }
    }
}

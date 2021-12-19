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
using System.Windows.Shapes;
using UnitofWork_GenericRepo_EFTask.Context;
using UnitofWork_GenericRepo_EFTask.Models;
using UnitofWork_GenericRepo_EFTask.UnitOfWork.Concrete;

namespace UnitofWork_GenericRepo_EFTask.Views
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        UnitofWork unitofWork;
        public bool _Update { get; set; }
        public Category Category { get; set; }
        public Book  Book { get; set; }

        public AddWindow()
        {
            InitializeComponent();
            unitofWork = new UnitofWork(new MyDbContext());
            Category = new Category();
            Book = new Book();
        }

        private void btn_okCate_Click(object sender, RoutedEventArgs e)
        {
            if (!_Update)
            {
                try
                {
                    if (!string.IsNullOrEmpty(txb_nameCategory.Text))
                    {
                        unitofWork.CategoryRepo.Add(new Category() { Name = txb_nameCategory.Text });
                        ((MainWindow)Application.Current.MainWindow).datagrid_category.ItemsSource = unitofWork.CategoryRepo.GetAll().Include(b => b.Books).ToList();
                    }
                    else  MessageBox.Show("Fill Info");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(_Update==true)
            {
                try
                {
                    if (!string.IsNullOrEmpty(txb_nameCategory.Text))
                    {
                        Category.Name = txb_nameCategory.Text;
                        unitofWork.CategoryRepo.Update(Category);
                        MessageBox.Show("Update Successfully!");
                    }
                    else MessageBox.Show("Fill Info");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);   
                }
                
            }
            unitofWork.Complete();

        }

        private void btn_cancelC_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_cancelP_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_okProduct_Click(object sender, RoutedEventArgs e)
        {
            if (!_Update)
            {
                try
                {
                    if (!string.IsNullOrEmpty(txb_nameP.Text) || !string.IsNullOrEmpty(txb_price.Text) ||
                         !string.IsNullOrEmpty(txb_quantity.Text) || !string.IsNullOrEmpty(txb_categoryId.Text))
                    {
                        unitofWork.BookRepo.Add(new Book() { Name = txb_nameP.Text, Price = decimal.Parse(txb_price.Text), Quantity = int.Parse(txb_quantity.Text), CategoryId = int.Parse(txb_categoryId.Text) });
                        MessageBox.Show("Add Succesfully");
                    }
                    else MessageBox.Show("Fill Info");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (_Update)
            {
                try
                {
                    if (!string.IsNullOrEmpty(txb_nameP.Text) || !string.IsNullOrEmpty(txb_price.Text) || 
                        !string.IsNullOrEmpty(txb_quantity.Text) || !string.IsNullOrEmpty(txb_categoryId.Text))
                    {
                        Book.Name = txb_nameP.Text;
                        Book.Price = decimal.Parse(txb_price.Text);
                        Book.Quantity = int.Parse(txb_quantity.Text);
                        Book.CategoryId = int.Parse(txb_categoryId.Text);
                        unitofWork.BookRepo.Update(Book);
                        MessageBox.Show("Update Successfully!");
                    }
                    else MessageBox.Show("Fill Info");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            unitofWork.Complete();
        }
    }
}

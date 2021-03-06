﻿using System.Windows;
using System.Windows.Controls;
using OrdersRegistration.DbRepository;
using MahApps.Metro.Controls;
using OrdersRegistration.Validation;
using System.Linq;

namespace OrdersRegistration.WPF
{
    /// <summary>
    /// Interaction logic for EditOrder.xaml
    /// </summary>
    public partial class EditOrder : MetroWindow
    {
        private Model.Order _editOrder = new Model.Order();
        private IStorable<Model.Order> _orderStorage;

        /// <summary>
        /// Ctor
        /// </summary>
        public EditOrder(Model.Order editOrder, IStorable<Model.Order> orderStorage)
        {
            _editOrder = editOrder;
            _orderStorage = orderStorage;

            InitializeComponent();
            
            SetToTextbox();
        }

        /// <summary>
        /// Przepisanie danych wybranego zleceniodawcy do textBox'ów
        /// </summary>
        private void SetToTextbox()
        {
            CustomerStorage _customerStorage = new CustomerStorage();

            foreach (var i in _customerStorage.Read())
            {
                if (i.Name == _editOrder.Customer.Name)
                {
                    comboBoxSelectCustomer.Items.Insert(0, i);
                    comboBoxSelectCustomer.Text = i.Name;
                }
                else
                {
                    comboBoxSelectCustomer.Items.Add(i);
                }
            }

            textBoxEditOrdername.Text = _editOrder.Name;
            textBoxEditComments.Text = _editOrder.Comments;
            textBoxEditOrderPrice.Text = string.Format("{0:0.00}", _editOrder.Price);
            dateEditOrderPicker.SelectedDate = _editOrder.Date;
            checkBoxIsPaid.IsChecked = _editOrder.IsPaid;
        }

        /// <summary>
        /// Wybór zleceniodawcy
        /// </summary>
        private void comboBoxSelectCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _editOrder.Customer = (Model.Customer)comboBoxSelectCustomer.SelectedItem;
        }

        /// <summary>
        /// Edycja nazwy zlecenia
        /// </summary>
        private void tbEditOrdername_TextChanged(object sender, TextChangedEventArgs e)
        {
            _editOrder.Name = textBoxEditOrdername.Text;
        }

        /// <summary>
        /// Edycja komentarza (opcjonalnie)
        /// </summary>
        private void tbEditComments_TextChanged(object sender, TextChangedEventArgs e)
        {
            _editOrder.Comments = textBoxEditComments.Text;
        }

        /// <summary>
        /// Edycja daty zlecenia
        /// </summary>
        private void dateEditOrderPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _editOrder.Date = dateEditOrderPicker.SelectedDate.Value;
        }

        /// <summary>
        /// Edycja 'czy zapłacono'
        /// </summary>
        private void checkBoxIsPaid_Click(object sender, RoutedEventArgs e)
        {
            _editOrder.IsPaid = checkBoxIsPaid.IsChecked.Value;
        }

        /// <summary>
        /// Aktualizacja danych wybranego zleceniodawcy (Button)
        /// </summary>
        private void btnEditAddOrder_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEditOrdername.Text != "" && _editOrder.Date != null && textBoxEditOrderPrice.Text != "" && _editOrder.Customer.ID != 0)
            {
                _orderStorage.Update(_editOrder);
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Musisz uzupełnić pola oznaczone GWIAZDKĄ!", "Uwaga!");
            }
        }

        /// <summary>
        /// Edycja kwoty zlecenia
        /// </summary>
        private void textBoxEditOrderPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            
            decimal price;
            if (decimal.TryParse(textBoxEditOrderPrice.Text, out price))
            {
                _editOrder.Price = price;
            }  
            else
            {
                MessageBox.Show("Musisz podać cyfry!", "Uwaga!");
                textBoxEditOrderPrice.Clear();
            }
        }
    }
}

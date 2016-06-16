﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using OrdersRegistration.DbRepository;
using System.Collections.Generic;

namespace OrdersRegistration.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private IStorable<Model.Order> _orderStorage;
        private IStorable<Model.Customer> _customerStorage;
        private OrderListFilter orderListFilter = new OrderListFilter();
        private List<Model.Order> _isPaidList = new List<Model.Order>();
        private int ordersCount;
        private DateTime dateFrom;
        private DateTime dateTo;
        private Model.Customer selectedCustomer = null;
        private Model.Order orderIsPaid = new Model.Order();

        /// <summary>
        /// Ctor
        /// </summary>
        public MainWindow(IStorable<Model.Order> orderStorage, IStorable<Model.Customer> customerStorage)
        {
            _orderStorage = orderStorage;
            _customerStorage = customerStorage;
            InitializeComponent();
            storageTest();   
            SetToComboBoxCustomerFilter();
            ComboBoxOrdersOnPage();
            InitializeValues();          
        }

        private void Order_PropertyChanged(object sender, EventArgs e)
        {
            Model.Order _newOrder = (Model.Order)dataGrid.SelectedItem;

            if (!_isPaidList.Contains(_newOrder))
            {
                _isPaidList.Add(_newOrder);
                buttonIsPaid.IsEnabled = true;
            }
            else
            {
                _isPaidList.Remove(_newOrder);
                if (_isPaidList.Count == 0)
                {
                    buttonIsPaid.IsEnabled = false;
                }
            }
        }

        private void InitializeValues()
        {
            ordersCount = 20; 

            DateTime today = DateTime.Today;
            dateFrom = today.AddMonths(-1);
            dateTo = today.AddMonths(1);

            datePickerFrom.SelectedDate = dateFrom;
            datePickerTo.SelectedDate = dateTo;

            comboBoxOrdersOnPage.SelectedValue = "---Wszystkie zlecenia---"; //wyzwala zdarzenie comboBoxOrdersOnPage_SelectionChanged
        }

        /// <summary>
        /// Dodanie testowych zleceniodawców
        /// </summary>
        public void storageTest()
        {
            Model.Customer customer1 = new Model.Customer { ID = 1, Name = "Arek" };
            _customerStorage.Create(customer1);
            Model.Customer customer2 = new Model.Customer { ID = 2, Name = "Piotrek" };
            _customerStorage.Create(customer2);
            Model.Customer customer3 = new Model.Customer { ID = 3, Name = "Zenek" };
            _customerStorage.Create(customer3);

            //Model.Order order1 = new Model.Order { ID = 1, Name = "bubu", Comments = "tralala", Price = 143, IsPaid = true, Customer = customer1, Date = DateTime.Now };
            //_orderStorage.Create(order1);
            //Model.Order order2 = new Model.Order { ID = 2, Name = "zasd", Comments = "ijijij", Price = 443, IsPaid = false, Customer = customer2, Date = DateTime.Now };
            //_orderStorage.Create(order2);
        }

        /// <summary>
        /// Metoda odświeżania (czytania) listy zamówień
        /// </summary>
        public void RefreshOrderList()
        {
            if (selectedCustomer == null)
            {
                var items = orderListFilter.GetOrderListDateFromTo(dateFrom, dateTo, ordersCount);
                foreach (var i in items)
                {
                    i.IsPaidEvent += Order_PropertyChanged;
                }
                dataGrid.ItemsSource = items;
            }
            else
            {
                var items = orderListFilter.GetOrderListDateFromTo(dateFrom, dateTo, ordersCount, selectedCustomer);
                foreach (var i in items)
                {
                    i.IsPaidEvent += Order_PropertyChanged;
                }
                dataGrid.ItemsSource = items;
            }
        }

        /// <summary>
        /// Dodanie nowego zamówienia (Button)
        /// </summary>
        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            if (_customerStorage.Read().Count() != 0)
            {
                AddOrder addOrder = new AddOrder(_orderStorage, _customerStorage);

                bool? result = addOrder.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    ComboBoxItemsCount();
                    RefreshOrderList();
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Ponieważ nie ma jeszcze zdefiniowanego żadnego ZLECENIODAWCY, dodaj go teraz !", "Uwaga", MessageBoxButton.OK);

                if (result == MessageBoxResult.OK)
                {
                    MenuItemAddCustomer_Click(this, e);
                }           
            }           
        }

        /// <summary>
        /// Edycja zamówienia (Menu)
        /// </summary>
        private void MenuItem_EditOrder(object sender, RoutedEventArgs e)
        {
            Model.Order selectedOrder = (Model.Order)dataGrid.SelectedItem;

            if (selectedOrder != null)
            {
                EditOrder editOrder = new EditOrder(selectedOrder, _orderStorage);

                bool? result = editOrder.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    RefreshOrderList();
                }
            }
            else
            {
                MessageBox.Show("Nie zaznaczono żadnego zlecenia!");
            }
        }

        /// <summary>
        /// Usuwanie zamówienia (Menu)
        /// </summary>
        private void MenuItem_DeleteOrder(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Model.Order orderToDelete = (Model.Order)dataGrid.SelectedItem;

                MessageBoxResult result = MessageBox.Show("Czy chcesz usunąć zlecenie: " + orderToDelete.Name + "\nod klienta " + orderToDelete.Customer.Name + "?", "Uwaga!", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    _orderStorage.Delete(orderToDelete);
                    RefreshOrderList();
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano zlecenia!");
            }
        }

        /// <summary>
        /// Dodanie nowego zleceniodawcy (Menu)
        /// </summary>
        private void MenuItemAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer(_customerStorage);
            addCustomer.ShowDialog();

            foreach (var i in _customerStorage.Read())
            {
                comboBoxCustomerFilter.Items.Add(i);
            }
        }

        /// <summary>
        /// Edycja zleceniodawcy (Menu)
        /// </summary>
        private void MenuItem_EditCustomer(object sender, RoutedEventArgs e)
        {
            EditCustomer editCustomer = new EditCustomer(_customerStorage);

            bool? result = editCustomer.ShowDialog();
            if (result.HasValue && result.Value)
            {
                RefreshOrderList();
            }
        }

        /// <summary>
        /// O autorze (Menu)
        /// </summary>
        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutApplication aboutApplication = new AboutApplication();
            aboutApplication.Show();
        }

        /// <summary>
        /// Zamykanie aplikacji
        /// </summary>
        private void MenuItemAppClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Umieszczenie obiektów Customer w comboBox (filtrowanie zleceń wg zleceniodawcy)
        /// </summary>
        private void SetToComboBoxCustomerFilter()
        {
            Model.Customer filterCustomer = new Model.Customer();
            filterCustomer.Name = "---Wszyscy zleceniodawcy---";
            comboBoxCustomerFilter.Items.Insert(0, filterCustomer);

            foreach (var i in _customerStorage.Read())
            {
                comboBoxCustomerFilter.Items.Add(i);
            }
        }

        /// <summary>
        /// Wybór zleceniodawcy w celu filtrowania zleceń
        /// </summary>
        private void comboBoxCustomerFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCustomer = (Model.Customer)comboBoxCustomerFilter.SelectedItem;

            if (selectedCustomer.Name == "---Wszyscy zleceniodawcy---")
            {
                selectedCustomer = null;
                RefreshOrderList();
            }
            else
            {
                RefreshOrderList();
            }
        }

        /// <summary>
        /// Dodawanie itemów do comboBoxOrdersOnPage
        /// </summary>
        private void ComboBoxOrdersOnPage()
        {
            comboBoxOrdersOnPage.Items.Add("---Wszystkie zlecenia---");
            comboBoxOrdersOnPage.Items.Add("10");
            comboBoxOrdersOnPage.Items.Add("20");
            comboBoxOrdersOnPage.Items.Add("30");
            comboBoxOrdersOnPage.Items.Add("40");
        }

        /// <summary>
        /// Wybór liczby wyświetlanych zleceń
        /// </summary>
        private void ComboBoxItemsCount()
        {
            switch (comboBoxOrdersOnPage.SelectedItem.ToString())
            {
                case ("---Wszystkie zlecenia---"):
                    ordersCount = _orderStorage.Read().Count();
                    RefreshOrderList();
                    break;
                case ("10"):
                    ordersCount = 1;
                    RefreshOrderList();
                    break;
                case ("20"):
                    ordersCount = 2;
                    RefreshOrderList();
                    break;
                case ("30"):
                    ordersCount = 3;
                    RefreshOrderList();
                    break;
                case ("40"):
                    ordersCount = 4;
                    RefreshOrderList();
                    break;
                default:
                    //ordersCount = 10;
                    //RefreshOrderList();
                    break;
            }
        }

        /// <summary>
        /// Wybór liczby wyświetlanych zleceń (zdarzenie)
        /// </summary>
        private void comboBoxOrdersOnPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItemsCount();
        }

        private void MenuSimpleStatistics_Click(object sender, RoutedEventArgs e)
        {
            if (_orderStorage.Read().Count() != 0)
            {
                SimpleStatistics simpleStatistics = new SimpleStatistics();
                simpleStatistics.Show();
            }
            else
            {
                MessageBox.Show("W bazie danych nie ma żadnych zleceń!", "Uwaga", MessageBoxButton.OK);
            }    
        }

        private void datePickerFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dateFrom = datePickerFrom.SelectedDate.Value;
            RefreshOrderList();
        }

        private void datePickerTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dateTo = datePickerTo.SelectedDate.Value;
            RefreshOrderList();
        }

        /// <summary>
        /// Akceptuj zapłacone zlecenia (Button)
        /// </summary>
        private void buttonIsPaid_Click(object sender, RoutedEventArgs e)
        {
            foreach (var i in _isPaidList)
            {
                _orderStorage.Update(i);
            }

            _isPaidList.Clear();
            buttonIsPaid.IsEnabled = false;
        }

        /// <summary>
        /// Metody odpowiedzialne za "pojedynczy click" w dataGrid
        /// </summary>
        private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridCell cell = (DataGridCell)sender;
            if (cell != null && !cell.IsEditing && !cell.IsReadOnly)
            {
                if (!cell.IsFocused)
                {
                    cell.Focus();
                }
                if (dataGrid.SelectionUnit != DataGridSelectionUnit.FullRow)
                {
                    if (!cell.IsSelected)
                    {
                        cell.IsSelected = true;
                    }
                }
                else
                {
                    DataGridRow row = FindVisualParent<DataGridRow>(cell);
                    if (row != null && !row.IsSelected)
                    {
                        row.IsSelected = true;
                    }
                }

            }
        }
        static T FindVisualParent<T>(UIElement element) where T : UIElement
        {
            UIElement parent = element;
            while (parent != null)
            {
                T correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }
                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }
            return null;
        }
    }
}

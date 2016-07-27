using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using OrdersRegistration.DbRepository;
using System.Collections.Generic;
using MahApps.Metro.Controls;
using System.IO;
using OrdersRegistration.WPF.Infrastructure;

namespace OrdersRegistration.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
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
        private IEnumerable<Model.Order> _orders;
        private string _settingsPath = "Settings.xml";
        private Settings settings = new Settings();

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
            ComboBoxItemsCount();
            
        }

        /// <summary>
        /// Dodawanie/usuwanie zleceń, w których zmieniono właściwość 'IsPaid', do tymczasowej listy w celu obsługi wprowadzonych zmian
        /// </summary>
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

        /// <summary>
        /// Wartości inicjalizujące
        /// </summary>
        private void InitializeValues()
        {
            if (File.Exists(_settingsPath))
            {
                settings = XMLSerialization.Deserialization(_settingsPath);
            }
            else
            {
                settings.DefaultSettings();
            }
            
            ordersCount = settings.OrdersCount.Count;
            datePickerFrom.SelectedDate = DateTime.Today.AddMonths(settings.DateFrom);
            datePickerTo.SelectedDate = DateTime.Today.AddMonths(settings.DateTo);
            comboBoxOrdersOnPage.Text = settings.OrdersCount.Text;
        }

        /// <summary>
        /// Dodanie testowych zleceniodawców
        /// </summary>
        public void storageTest()
        {
            //Model.Customer customer1 = new Model.Customer { ID = 1, Name = "Arek", Mail = "arek@wp.pl", PhoneNumber = "501234966" };
            //_customerStorage.Create(customer1);
            //Model.Customer customer2 = new Model.Customer { ID = 2, Name = "Piotrek", Mail = "piotr@gmail.com", PhoneNumber = "542883463" };
            //_customerStorage.Create(customer2);
            //Model.Customer customer3 = new Model.Customer { ID = 3, Name = "Zenek", Mail = "zenon@o2.pl", PhoneNumber = "602345966" };
            //_customerStorage.Create(customer3);

            //Model.Order order1 = new Model.Order { Name = "Nagranie lektorskie", Comments = "Zrealizować jak najszybciej!", Price = 150m, IsPaid = true, Customer = customer1, Date = new DateTime(2016, 6, 12) };
            //_orderStorage.Create(order1);
            //Model.Order order2 = new Model.Order { Name = "Realizacja usług masteringowych", Comments = "Posłużyć się kompresorem firmy Waves", Price = 1200m, IsPaid = false, Customer = customer2, Date = DateTime.Now.Date };
            //_orderStorage.Create(order2);
        }

        /// <summary>
        /// Metoda odświeżania (czytania) listy zamówień
        /// </summary>
        public void RefreshOrderList()
        {
            if (selectedCustomer == null)
            {
                _orders = orderListFilter.GetOrderListDateFromTo(dateFrom, dateTo, ordersCount);
                foreach (var i in _orders)
                {
                    i.IsPaidEvent += Order_PropertyChanged;
                }
                
                GridIsPaidDisable();
                dataGrid.ItemsSource = _orders;
                OrdersNonPaidRowStyle();
            }
            else
            {
                _orders = orderListFilter.GetOrderListDateFromTo(dateFrom, dateTo, ordersCount, selectedCustomer);
                foreach (var i in _orders)
                {
                    i.IsPaidEvent += Order_PropertyChanged;
                }
                
                GridIsPaidDisable();
                dataGrid.ItemsSource = _orders;
                OrdersNonPaidRowStyle();
            }
        }

        /// <summary>
        /// Dodanie nowego zamówienia (Button)
        /// </summary>
        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            ListNotEmptyCheck();

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
                MessageBoxResult result = MessageBox.Show("Ponieważ nie ma jeszcze zdefiniowanego żadnego ZLECENIODAWCY, dodaj go teraz !", "Uwaga!", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {
                    MenuItemAddCustomer_Click(this, e);
                    btnAddOrder_Click(this, e);
                }
                else
                {
                    return;
                }     
            }           
        }

        /// <summary>
        /// Edycja zlecenia (Menu)
        /// </summary>
        private void MenuItem_EditOrder(object sender, RoutedEventArgs e)
        {
            Model.Order selectedOrder = (Model.Order)dataGrid.SelectedItem;
            ListNotEmptyCheck();

            if (selectedOrder != null)
            {
                EditOrder editOrder = new EditOrder(selectedOrder, _orderStorage);

                bool? result = editOrder.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    _isPaidList.Clear();
                    buttonIsPaid.IsEnabled = false;
                    RefreshOrderList();
                }
            }
            else
            {
                MessageBox.Show("Nie zaznaczono żadnego zlecenia!", "Uwaga!");
            }
        }

        /// <summary>
        /// Usuwanie zamówienia (Menu)
        /// </summary>
        private void MenuItem_DeleteOrder(object sender, RoutedEventArgs e)
        {
            Model.Order orderToDelete = (Model.Order)dataGrid.SelectedItem;
            ListNotEmptyCheck();

            if (orderToDelete != null)
            {
                MessageBoxResult result = MessageBox.Show("Czy chcesz usunąć zlecenie: " + orderToDelete.Name + "\nod klienta " + orderToDelete.Customer.Name + "?", "Uwaga!", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _orderStorage.Delete(orderToDelete);
                    RefreshOrderList();
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano zlecenia!", "Uwaga!");
            }
        }

        /// <summary>
        /// Dodanie nowego zleceniodawcy (Menu)
        /// </summary>
        private void MenuItemAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer(_customerStorage);
            bool? result = addCustomer.ShowDialog();

            if (result.HasValue && result.Value)
            {
                comboBoxCustomerFilter.Items.Clear();
                SetToComboBoxCustomerFilter();
            }                    
        }

        /// <summary>
        /// Edycja zleceniodawcy (Menu)
        /// </summary>
        private void MenuItem_EditCustomer(object sender, RoutedEventArgs e)
        {
            ListNotEmptyCheck();

            EditCustomer editCustomer = new EditCustomer(_customerStorage);

            bool? result = editCustomer.ShowDialog();
            if (result.HasValue && result.Value)
            { 
                comboBoxCustomerFilter.Items.Clear();
                SetToComboBoxCustomerFilter();
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
            filterCustomer.Name = "Wszyscy zleceniodawcy";
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

            ListNotEmptyCheck();

            if (selectedCustomer.Name == "Wszyscy zleceniodawcy")
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
            comboBoxOrdersOnPage.Items.Add(settings.ordersAll);
            comboBoxOrdersOnPage.Items.Add(settings.orders10);
            comboBoxOrdersOnPage.Items.Add(settings.orders20);
            comboBoxOrdersOnPage.Items.Add(settings.orders30);
            comboBoxOrdersOnPage.Items.Add(settings.orders40);
            comboBoxOrdersOnPage.Text = settings.ordersAll.Text;
        }

        /// <summary>
        /// Wybór liczby wyświetlanych zleceń
        /// </summary>
        private void ComboBoxItemsCount()
        {
            ListNotEmptyCheck();

            OrdersCount count = (OrdersCount)comboBoxOrdersOnPage.SelectedItem;

            if (count.Count == 0)
            {
                ordersCount = _orderStorage.Read().Count();
            }
            else
            {
                ordersCount = count.Count;
            }

            RefreshOrderList();
        }

        /// <summary>
        /// Wybór liczby wyświetlanych zleceń (zdarzenie)
        /// </summary>
        private void comboBoxOrdersOnPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItemsCount();
        }

        /// <summary>
        /// Okno 'Statystyki' (menu)
        /// </summary>
        private void MenuSimpleStatistics_Click(object sender, RoutedEventArgs e)
        {
            if (_orderStorage.Read().Count() != 0)
            {
                SimpleStatistics simpleStatistics = new SimpleStatistics();
                simpleStatistics.Show();
            }
            else
            {
                MessageBox.Show("W bazie danych nie ma żadnych zleceń!", "Informacja", MessageBoxButton.OK);
            }    
        }

        /// <summary>
        /// Data wybrana w datePickerFrom do zmiennej dateFrom
        /// </summary>
        private void datePickerFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ListNotEmptyCheck();
            dateFrom = datePickerFrom.SelectedDate.Value;
            RefreshOrderList();
        }

        /// <summary>
        /// Data wybrana w datePickerTo do zmiennej dateTo
        /// </summary>
        private void datePickerTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ListNotEmptyCheck();
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
            RefreshOrderList();
        }

        ///// <summary>
        ///// Metody odpowiedzialne za "pojedynczy click" w dataGrid
        ///// </summary>
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

        /// <summary>
        /// Metoda sprawdzająca, czy w kolumnie 'IsPaid' (dataGrid) zaszły zmiany
        /// </summary>
        public void ListNotEmptyCheck()
        {
            if (_isPaidList.Count != 0)
            {
                MessageBoxResult result = MessageBox.Show("Zmieniono wartość pola 'Zapłacono'.\nZapisać zmiany?", "Nie zatwierdzono zmian!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    buttonIsPaid_Click(this, new RoutedEventArgs());
                }
                else
                {
                    _isPaidList.Clear();
                    RefreshOrderList(); 
                    buttonIsPaid.IsEnabled = false;
                }
            }
        }

        /// <summary>
        /// Zamykanie głównego okna
        /// </summary>
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ListNotEmptyCheck();
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Okno 'Ustawienia użytkownika' oraz serializacja ustawień i zapis do pliku
        /// </summary>
        private void MenuItem_Settings(object sender, RoutedEventArgs e)
        {
            ListNotEmptyCheck();

            UserSettings userSettings = new UserSettings();

            bool? result = userSettings.ShowDialog();
            if (result.HasValue && result.Value)
            {
                XMLSerialization.Serialization(userSettings.settings, _settingsPath);

                ordersCount = userSettings.settings.OrdersCount.Count;
                datePickerFrom.SelectedDate = DateTime.Today.AddMonths(userSettings.settings.DateFrom);
                datePickerTo.SelectedDate = DateTime.Today.AddMonths(userSettings.settings.DateTo);
                comboBoxOrdersOnPage.Text = userSettings.settings.OrdersCount.Text;

                ComboBoxItemsCount();
                RefreshOrderList();
            }
        }

        /// <summary>
        /// Metoda oznaczjąca kolorem czerwonym wszystkie nieopłacone zamówienia jednego użytkownika, których łączna suma przekracza 200 zł
        /// </summary>
        private void OrdersNonPaidRowStyle()
        {
            foreach (var i in _customerStorage.Read())
            {
                var result = _orderStorage.Read().Where(o => o.Customer.ID == i.ID && o.IsPaid == false).Sum(o => o.Price);
                if (result >= 200)
                {
                    var selectedItems = _orders.Where(o => o.Customer.ID == i.ID && o.IsPaid == false).ToList();

                    foreach (var j in selectedItems)
                    {
                        j.GridIsPaidColor = true;
                    }
                }
            }
        }

        /// <summary>
        /// Metoda ustawiająca właściwość 'IsEnabled' DataGridCheckBoxColumn na 'false', gdy opłacono zlecenie
        /// </summary>
        private void GridIsPaidDisable()
        {
            foreach (var i in _orders)
            {
                if (i.IsPaid == true)
                {
                    i.GridIsPaidEnabled = true;
                }
            }
        }
    }
}

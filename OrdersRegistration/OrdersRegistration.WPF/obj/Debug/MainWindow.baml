   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   Q MOrdersRegistration.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:OrdersRegistration.WPFOrdersRegistration.WPF 5   	   S OOrdersRegistration.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulleHclr-namespace:OrdersRegistration.Model;assembly=OrdersRegistration.ModelOrdersRegistration.Model 5   	   '   !OrdersRegistration.WPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   6local$clr-namespace:OrdersRegistration.WPF     5   	   ZModelHclr-namespace:OrdersRegistration.Model;assembly=OrdersRegistration.Model     5   	   -   5          � Title$  Orders Registration��5
   	   $��521.5��6%   $	��450��64   $	��760��6D      AccentColorBrush#���   6S   $��1q�6�   $��921.5��6�    � 
ResizeMode$ 	CanResize=�6�    � WindowStartupLocation$ CenterScreen=�6�   .��5      � $��0q�6    � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5         ��Name$ btnZlecenie��5      $��Dodaj zlecenie��6&   $��	0,0,15,34q�6?   $��45��6l   $��Bottom=�6x   $��Right=�6�   $	��135��6�   $��14(�6�   $��Segoe UI Black)�6�   
��� E��$��3q�6�   $��0��6  &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5   I      CanUserAddRows .  $��10,57,206,73q�6[      AutoGenerateColumns .  ��6   �� *Orders+ � 	Resources 5      *  $System.Windows.Controls.DataGridCell	 �� 
TargetType��%E   '        �� 5      "	  6   .�5      -   5        5      5      
   RowStyle
 5      �� 5      )  #System.Windows.Controls.DataGridRow"	  6    �� Triggers 5      �� 5       �� Binding 6&   �� *IsPaid+ �� Value true6A   .a�5      ��  �� Property � �� �� Value �	#FF7FB4616O   5      �� 5       6&   �� *GridIsPaidColor+ true6J   .a�5       ��  � �� �	#FFD664646O   5!      5#         Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Nr��6%      
IsReadOnly . $��12(�6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *ID+6[     5(      $
 Data��6%    .  64   �� *Date+ �� StringFormat$ {0:dd.MM.yyyy}��6l     5)      $ Zleceniodawca��6%    .  6=   �� *Customer.Name+6_     5*      $ Zlecenie��6%    .  68   �� *Name+6Q     5+      $ Kwota��6%    .  65   �� *Price+$ {0:#.00}��6h   4  .System.Windows.Controls.DataGridCheckBoxColumn  5,      $ 
Zapłacono��6)    6=   �� *IsPaid+ �� UpdateSourceTrigger$ PropertyChanged=�   	CellStyle 5-      �� 5.      "	  6     5/      �� 50   "    6.   �� *GridIsPaidEnabled+ true6T   .a�51   &   ��  � {� .  6R   52   #   54      56        57      $ Uwagi��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 64    .  6>   �� *
Comments+6[   59      o� 5:   
   -   5        $
��menu��5:      $��0,0,0,0q�6   $
��Left=�6,   $	��145��6G   $��30��6S   $	��Top=�6_   
��� E��.@�5;      m� $
��MENU��6   $��Center=�6%   
��� E��$��2q�6_   $��2��6s   .@�5<      m� -   5        $��Dodaj zlecenie��5<      63   m� 5=      -   5        $��Edytuj zlecenie��5=      64   m� 5>      -   5        $��Usuń zlecenie��5>      62   �� 5?      m� 5@      -	   5        $��Dodaj zleceniodawcę��5@      68   m� 5A      -
   5        $!��Edytuj/Usuń zleceniodawcę��5A      6>   �� 5B      m� 5C      -   5        $��
Ustawienia��5C      6/   �� 5D      m� 5E      -   5        $��	O autorze��5E      6.   m� 5F      -   5        $��Zamknij��5F       m� InputGestureText$ Alt + F4��6K   5G      m� 5H      $��
STATYSTYKI��6   $��Center=�6+   
��� E��$��2q�6e   $��3��6y   .@�5I      m� -   5        $��
Podstawowe��5I      6/   5J      5K      �� 5L   
   -   5        $ buttonIsPaid��5L      $��Akceptuj zapłacone��6'   $��Center=�6D   {�.  $��
0,0,15,111q�6x   $��35��6�   $	��140��6�   $��Bottom=�6�   $��Right=�6�   
��� E��$��1q�6  $��1��6"  �� 5M   
   -   5         ��Name$ comboBoxCustomerFilter��5M       �� Text$ Wybierz zleceniodawcę��6T    �� DisplayMemberPath$
 Name��6q    �� 
IsEditable .  �� 
IsReadOnly . $��Center=�6�   $��
0,0,15,422q�6�   $��22��6  $��Bottom=�6+  $��Right=�6F  $	��177��6b  
��� E��$��1q�6�  $��4��6�  ��63   �� *
Customer+6�  �� 5N   
   -   5        $ comboBoxOrdersOnPage��5N      $
 Text��6U   $ Liczba zleceń��6n   $��
0,0,15,353q�6�    .  . $��Center=�6�   $��22��6  $��Bottom=�6"  $��Right=�6=  $	��177��6Y  
��� E��$��1q�6}  $��5��6�  ��61   �� *OrdersCount+6�  (	  "System.Windows.Controls.DatePicker	  5O   
   -   5         	 Name$ datePickerFrom��5O      $��
0,0,15,266q�6-   $��24��6A   $��Bottom=�6M   $��Right=�6�   $	��119��6�   
��� E��$��1q�6�   $��6��6�   	  5P   
   -   5        $ datePickerTo��5P      $��
0,0,15,227q�6+   $��24��6v   $��Bottom=�6�   $��Right=�6�   $	��119��6�   
��� E��$��1q�6�   $��7��6�   5Q      5R      
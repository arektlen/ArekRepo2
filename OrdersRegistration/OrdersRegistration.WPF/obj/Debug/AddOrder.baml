   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   Q MOrdersRegistration.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:OrdersRegistration.WPFOrdersRegistration.WPF 5   	   %   OrdersRegistration.WPF.AddOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   6local$clr-namespace:OrdersRegistration.WPF     5   	     � Title$  Dodaj zlecenie��5	   	   $	��400��6    $	��400��6-    � WindowStartupLocation$ CenterScreen=�69      AccentColorBrush#���   6^   $��1q�6�    � 
ResizeMode$ NoResize=�6�   .��5
      � .+�5   
   �� -   5         ��Name$ comboBoxSelectCustomer��5   U    �� DisplayMemberPath$
 Name��6<   $��
50,0,0,288q�6u   $��Bottom=�6�   $
��Left=�6�   $	��275��6�   $��23��6   $��0��6   �� SelectedValue 6   ��  �� Path$ 	Customers�6  �� 5   
   -   5         ��Name$ textBoxOrdername��5      $��
50,0,0,229q�6,    �� TextWrapping$
 Wrap=�6@   $
��Left=�6z   $	��275��6�   $��23��6�   $��Bottom=�6�   $��1��6�   	 �� 	MaxLength$	 50��6�   �� 5   
   -   5        $ textBoxComments��5      $��
50,0,0,111q�6+   $
 Wrap=�6?   $
��Left=�6x   $	��275��6�   $��23��6�   $��Bottom=�6�   $��3��6�   $		 100��6�   �� 5   
   -   5        $ textBoxOrderPrice��5      $��
50,0,0,170q�6-   $
 Wrap=�6A   $
��Left=�6U   $��80��6p   $��23��6{   $��Bottom=�6�   $��2��6�   $	 15��6�   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        
  Name$
 dateOrderPicker��5      $��	50,0,0,51q�6.   $��24��6{   $��Bottom=�6�   $
��Left=�6�   $	��113��6�   $��4��6�      SelectedDateFormat$ Short=�6�   �� 5   
   -   5         ��Name$ labelAddCustomer��5      $��Wybierz zleceniodawcę��6*   $
��Left=�6J   $��
60,0,0,315q�6l   
�������$��26��6�   $��Bottom=�6�   $	��136��6�   $
��Left=�6�   �� 5   
   -   5        $ labelOrderName��5      $��Nazwa zlecenia��6(   $
��Left=�6A   $��
60,0,0,257q�6c   $��Bottom=�6w   $	��136��6�   
�������$��26��6�   $
��Left=�6�   �� 5   
   -   5        $ 
labelPrice��5      $��Kwota��6$   $
��Left=�64   $��
60,0,0,198q�6V   $��Bottom=�6j   $	��136��6�   
�������$��26��6�   $
��Left=�6�   �� 5   
   -	   5        $ labelComments��5      $��	Komentarz��6'   $
��Left=�6;   $��
60,0,0,139q�6]   $��Bottom=�6q   $	��136��6�   
�������$��26��6�   $
��Left=�6�   �� 5   
   -
   5        $ labelOrderDate��5      $��Data zlecenia��6(   $
��Left=�6@   $��	60,0,0,80q�6b   $��Bottom=�6u   $	��136��6�   
�������$��26��6�   $
��Left=�6�   �� 5   
   -   5         ��Name$ btnAddOrder��5      $��Dodaj zlecenie��6&   $��	0,0,39,35q�6?   $��Right=�6l   $	��120��6�   $��40��6�   $��Bottom=�6�   
��� E��$��2q�6�   $��5��6�   �� 5   
   -   5        $ labelPLN��5      $	��PLN��6"   $
��Left=�60   $��130,173,0,0q�6K   $	��Top=�6`   $��23��6x   �� 5   
   -   5        $ label��5      $��*��6   $
��Left=�6+   $��
325,42,0,0q�6F   $	��Top=�6Z   $��29��6r   �� 5   
   -   5        $ label1��5      $��*��6    $
��Left=�6,   $��325,102,0,0q�6G   $	��Top=�6\   �� 5   
   -   5        $ label2��5      $��*��6    $
��Left=�6,   $��130,161,0,0q�6G   $	��Top=�6\   5      5      
   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   Q MOrdersRegistration.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:OrdersRegistration.WPFOrdersRegistration.WPF 5   	   &    OrdersRegistration.WPF.EditOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   6local$clr-namespace:OrdersRegistration.WPF     5   	     � Title$  Edytuj zlecenie��5	   	   $	��400��6!   $	��400��6.      AccentColorBrush#���   6:   $��1q�6k    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�6�   .��5
      � .+�5   
   �� -   5         ��Name$ comboBoxSelectCustomer��5   S    �� DisplayMemberPath$
 Name��6:   $��
50,0,0,288q�6s   $��Bottom=�6�   $
��Left=�6�   $	��275��6�   $��23��6  $��0��6  ��6   ��  �� Path$ 	Customers�6  �� 5   
   -   5         ��Name$ textBoxEditOrdername��5      $��
50,0,0,229q�60    �� TextWrapping$
 Wrap=�6D   $
��Left=�6�   $	��275��6�   $��23��6�   $��Bottom=�6�   $��1��6�    �� 	MaxLength$ 50��6�   �� 5   
   -   5        $ textBoxEditComments��5      $��
50,0,0,111q�6/   $
 Wrap=�6C   $
��Left=�6�   $	��275��6�   $��23��6�   $��Bottom=�6�   $��4��6�   $	 100��6�   �� 5   
   -   5        $ textBoxEditOrderPrice��5      $��50,173,0,170q�61   $
 Wrap=�6G   $
��Left=�6[   $��80��6v   $��23��6�   $��2��6�   $ 15��6�   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        	  Name$	 dateEditOrderPicker��5      $��	50,0,0,51q�62   $��24��6�   $��Bottom=�6�   $
��Left=�6�   $	��113��6�   $��5��6�   �� 5   
   -   5        
 ��Name$
 labelSelectCustomer��5      $��Wybierz zleceniodawcę��6-   $
��Left=�6M   $��
60,0,0,315q�6o   
�������$��26��6�   $��Bottom=�6�   $	��136��6�   $
��Left=�6�   �� 5   
   -   5        $
 labelOrderName��5      $��Nazwa zlecenia��6(   $
��Left=�6A   $��
60,0,0,257q�6c   $��Bottom=�6w   $	��136��6�   
�������$��26��6�   $
��Left=�6�   �� 5   
   -   5        $
 
labelPrice��5      $��Kwota��6$   $
��Left=�64   $��
60,0,0,198q�6V   $��Bottom=�6j   $	��136��6�   
�������$��26��6�   $
��Left=�6�   �� 5   
   -	   5        $
 labelComments��5      $��	Komentarz��6'   $
��Left=�6;   $��
60,0,0,139q�6]   $��Bottom=�6q   $	��136��6�   
�������$��26��6�   $
��Left=�6�   �� 5   
   -
   5        $
 	labelDate��5      $��Data zlecenia��6#   $
��Left=�6;   $��	60,0,0,80q�6]   $��Bottom=�6p   $	��136��6�   
�������$��26��6�   $
��Left=�6�   �� 5   
   -   5         ��Name$ btnEditAddOrder��5      $��Edytuj zlecenie��6*   $��	0,0,39,35q�6D   $��Right=�6u   $	��120��6�   $��40��6�   $��Bottom=�6�   
��� E��$��2q�6�   $��6��6�   �� 5   
   -   5        $
 labelPLN��5      $	��PLN��6"   $
��Left=�60   $��130,173,0,0q�6K   $	��Top=�6`   $��23��6x   �� 5   
   -   5         ��Name$ checkBoxIsPaid��5      $��Czy zapłacono?��6+   $
��Left=�6D   $��176,176,0,0q�6_   $	��Top=�6t   
�������$��3��6�   �� 5   
   -   5        $
 label��5      $��*��6   $
��Left=�6+   $��
326,42,0,0q�6F   $	��Top=�6Z   �� 5   
   -   5        $
 label1��5      $��*��6    $
��Left=�6,   $��325,102,0,0q�6G   $	��Top=�6\   �� 5   
   -   5        $
 label2��5      $��*��6    $
��Left=�6,   $��130,162,0,0q�6G   $	��Top=�6\   5      5      
   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   Q MOrdersRegistration.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:OrdersRegistration.WPFOrdersRegistration.WPF 5   	   )   #OrdersRegistration.WPF.EditCustomer   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   6local$clr-namespace:OrdersRegistration.WPF     5   	     � Title$  Edytuj dane zleceniodawcy��5	   	   $	��300��6+   $	��300��68      AccentColorBrush#���   6D   $��1q�6u    � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ NoResize=�6�   .��5
      � .+�5   
   �� -   5         ��Name$ comboBoxEditCustomer��5   N    �� DisplayMemberPath$
 Name��65    �� Text$ Wybierz zleceniodawcę��6l    �� 
IsReadOnly .  �� 
IsEditable . $
��Left=�6�   $��	48,19,0,0q�6�   $	��Top=�6�   $	��194��6�   $��0��68  ��6   �� *	Customers+68  �� 5   
   -   5         ��Name$ textBoxEditCustomerName��5      $
��Left=�63   $��23��6N   $��	48,72,0,0q�6Z   	 �� TextWrapping$
	 Wrap=�6m   $	��Top=�6�   $	��194��6�   $��1��6�   
 �� 	MaxLength$
 50��6�   �� 5   
   -   5         ��Name$ btnEditCustomer��5      $��Edytuj��6*   $��Right=�6;   $��	0,0,25,16q�6W   $��87��6j    J� RenderTransformOrigin$ 
0.087,1.55&�6�   $��29��6�   
��� E��$��2q�6�   $��4��6�   $��Bottom=�6�   �� 5   
   -   5        $ btnDeleteCustomer��5      $��Usuń��6,   $
��Left=�6;   $��	25,0,0,16q�6V   $��87��6i   
��� E��$��2q�6�   $��5��6�   $��29��6�   $��Bottom=�6�   �� 5   
   -   5        $ textBoxEditCustomerMail��5      $
��Left=�63   $��23��6N   $��
48,125,0,0q�6Z   $
	 Wrap=�6n   $	��Top=�6�   $	��194��6�   $��2��6�   $
 50��6�   �� 5   
   -   5        $ textBoxEditCustomerPhone��5      $
��Left=�64   $��23��6O   $��
48,178,0,0q�6[   $
	 Wrap=�6o   $	��Top=�6�   $	��194��6�   $��3��6�   $
 30��6�   6�   �� 5   
   -   5         ��Name$ labelEditCustomerName��5      $��Edytuj nazwę��6/   $
��Left=�6F   $��	48,45,0,0q�6a   $	��Top=�6t   $��27��6�   $	��194��6�   $��Center=�6�   �� 5   
   -   5        $ labelEditCustomerMail��5      $��Edytuj E-mail��6/   $
��Left=�6G   $��	48,98,0,0q�6b   $	��Top=�6u   $��27��6�   $	��194��6�   $��Center=�6�   �� 5   
   -	   5        $ labelEditCustomerPhone��5      $��Edytuj numer telefonu��60   $
��Left=�6P   $��
48,151,0,0q�6k   $	��Top=�6   $��27��6�   $	��194��6�   $��Center=�6�   5      5      
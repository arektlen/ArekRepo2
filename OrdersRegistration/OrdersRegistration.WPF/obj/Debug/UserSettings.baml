   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   Q MOrdersRegistration.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:OrdersRegistration.WPFOrdersRegistration.WPF 5   	   )   #OrdersRegistration.WPF.UserSettings   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   6local$clr-namespace:OrdersRegistration.WPF     5   	     � Title$  Settings��5	   	   $	��300��6   $	��300��6'    � WindowStartupLocation$ CenterScreen=�63    � 
ResizeMode$ NoResize=�6X      AccentColorBrush#���   6n   $��1q�6�   .��5
      �  � RowDefinitions 5   
   �� 5      $	��269 �6   .+�5   
   �� -   5         ��Name$ comboBoxOrdersOnPage��5       �� DisplayMemberPath$
 Text��6U   $��
70,71,70,0q�6n   $	��Top=�6�   $��21��6�   ��61   �� *OrdersCount+6�   �� 5   
   -   5         ��Name$ labelDescription��5      $&�� Wprowadź preferowane ustawienia��6*   $��Center=�6T   $��16(�6v   $��	0,10,10,0q�6�   $	��Top=�6�   $��Right=�6�   $	��272��6�   �� 5   
   -   5         ��Name$ 
buttonSave��5      $��Zapisz��6%   $
��Left=�66   $��179,216,0,0q�6Q   $	��Top=�6f   $��75��6~   6�   �� 5   
   -   5        $ labelOrdersOnPage��5      $(��"Wybierz liczbę zleceń na stronie��6+   $��	0,40,10,0q�6V   $	��Top=�6i   $	��272��6�   $��Right=�6�   $��Center=�6�   �� 5   
   -   5        $ 	labelDate��5      $-��'Z jakiego okresu wyświetlać zlecenia?��6#   $��Center=�6S   $��
0,127,10,0q�6u   $	��Top=�6�   $��Right=�6�   $	��272��6�   �� 5   
   -   5        $ comboBoxDateFrom��5       �� Text$ M-cy WSTECZ��6-   	 �� 
IsEditable	 . 
 �� 
IsReadOnly
 . $
��Left=�6d   $��
10,158,0,0q�6   $	��Top=�6�   $	��129��6�   6�   �� 5   
   -   5        $ comboBoxDateTo��5      $ M-cy W PRZÓD��6+   	 . 
 . $
��Left=�6c   $��144,158,0,0q�6~   $	��Top=�6�   $	��138��6�   6�   5      5      
   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   Q MOrdersRegistration.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:OrdersRegistration.WPFOrdersRegistration.WPF 5   	   -   'OrdersRegistration.WPF.SimpleStatistics   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   6local$clr-namespace:OrdersRegistration.WPF     5   	     � Title$  
Statystyki��5	   	   $	��550��6   $	��350��6)    � 
ResizeMode$ NoResize=�65      AccentColorBrush#���   6K   $��1q�6|    � WindowStartupLocation$ CenterScreen=�6�   .��5
      � .+�5   
   �� -   5         ��Name$ labelOrdersCount��5      $��OGÓLNA liczba zleceń:��6*   $
��Left=�6J   $��	10,37,0,0q�6e   $	��Top=�6x   
�������6�   �� 5   
   -   5        $ labelOrdersCountResult��5      $�� ��60   $
��Left=�6;   $��
215,37,0,0q�6V   $	��Top=�6j   
�������6�   �� 5   
   -   5        $ labelOrdersCountMonth��5      $,��&Liczba zleceń w bieżącym MIESIĄCU:��6/   $
��Left=�6\   $��
10,193,0,0q�6w   $	��Top=�6�   
�������6�   �� 5   
   -   5        $ labelSumAllResult��5      $�� ��6+   $
��Left=�66   $��
215,68,0,0q�6Q   $	��Top=�6e   
�������6}   �� 5   
   -   5        $ labelSumAll��5      $��Na łączną kwotę:��6%   $
��Left=�6@   $��	10,68,0,0q�6[   $	��Top=�6n   
�������6�   �� 5   
   -   5        $ labelSumMonth��5      $��Na łączną kwotę:��6'   $
��Left=�6B   $��
10,224,0,0q�6]   $	��Top=�6q   
�������6�   �� 5   
   -   5        $! labelOrdersCountMonthResult��5      $�� ��65   $
��Left=�6@   $��215,193,0,0q�6[   $	��Top=�6p   
������� J� RenderTransformOrigin$ 1,0.038&�6�   �� 5   
   -   5        $ labelSumMonthResult��5      $�� ��6-   $
��Left=�68   $��215,224,0,0q�6S   $	��Top=�6h   
�������$ 	0.5,0.462&�6�   �� 5   
   -	   5         ��Name$ buttonOk��5      $��OK��6#   $��0,460,35,19q�60   $��Right=�6E   $��40��6x   $��14(�6�   
��� E��$��2q�6�   $	��105��6�   $��1��6�   �� 5   
   -
   5        $ buttonGeneratePdf��5      $��Generuj PDF��6,   $��35,460,0,19q�6B   $
��Left=�6W   $��40��6r   $��14(�6�   
��� E��$��2q�6�   $	��105��6�   $��2��6�   �� 5   
   -   5        $ labelOrdersNonPaid��5      $$��Liczba zleceń nieopłaconych:��6,   $
��Left=�6S   $��	10,99,0,0q�6n   $	��Top=�6�   
�������6�   �� 5   
   -   5        $ labelOrdersNonPaidResult��5      $�� ��62   $
��Left=�6=   $��
215,99,0,0q�6X   $	��Top=�6l   
�������$ 
0.5,-0.269&�6�   �� 5   
   -   5        $ labelSumAllNonPaid��5      $��Na łączną kwotę:��6,   $
��Left=�6G   $��
10,130,0,0q�6b   $	��Top=�6v   
�������6�   �� 5   
   -   5        $ labelSumAllNonPaidResult��5      $�� ��62   $
��Left=�6=   $��215,130,0,0q�6X   $	��Top=�6m   
�������$ 	0.5,0.577&�6�   �� 5   
   -   5        $ labelOrdersNonPaidInMonth��5      $$��Liczba zleceń nieopłaconych:��63   $
��Left=�6Z   $��
10,255,0,0q�6u   $	��Top=�6�   
�������6�   �� 5   
   -   5        $% labelOrdersNonPaidInMonthResult��5      $�� ��69   $
��Left=�6D   $��215,255,0,0q�6_   $	��Top=�6t   
�������$ 
0.5,-0.269&�6�   �� 5   
   -   5        $ labelSumAllNonPaidInMonth��5      $��Na łączną kwotę:��63   $
��Left=�6N   $��
10,286,0,0q�6i   $	��Top=�6}   
�������6�   �� 5   
   -   5        $% labelSumAllNonPaidInMonthResult��5      $�� ��69   $
��Left=�6D   $��215,286,0,0q�6_   $	��Top=�6t   
�������$ 	0.5,0.577&�6�   5      5      
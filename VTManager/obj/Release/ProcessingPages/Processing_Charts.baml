   M S B A M L   `   `   `  ���� D  @VTManager, Version=0.3.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:VTManager.InteractiveVTManager.Interactive  %clr-namespace:VTManager	VTManager  !    VTManager.Processing_Charts   3Interactive#clr-namespace:VTManager.Interactive  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:VTManager     -     N�Name$  processing_charts_page��$
��auto��$
��auto�� N� Title$ Processing_Charts��.���  � RowDefinitions �� $
��170* ��� $	��60* ��� $
��293* ��� $	��60* ��� $
��511* ��� $��4* ��� $��6* ��� $
��180* � � ColumnDefinitions �� $
��268* ��� $	��50* ��� $	��78* �.+��� ���#fff$��8��$��3���� ���#273049$��5��$��3���� -    ��Name$ page_header��$.��(Статистика за квартал��   page_header#���   � -    �Name$ 
main_costs��$��2��$��2��$��2�� �� ��  �� $
��264* ��� $	��50* ��� $
��264* �.+�)   #VTManager.Interactive.VTManagerStat  -     Name$ block1��   Target$/ )Радиоламп изготовлено��   Limit$
 9999��  -   $ block2��$7 1Коэффициент брака за смену��$ 6��$��2��� -   $ chart_items��$��4��$��3��.+��� 	 �� Orientation$	 
Horizontal=�$	��200��$	��Top=�$
��Left=�.+�*   $VTManager.Interactive.VTManagerChart  -   
  Name$
 vt_type1��   ItemName$ Пентодов�����#adb8d9   Color �#273049   	TextColor
 �����   MaxValue$
 4000Q�   Value$ 0Q�$��10q�$	��110��  -   $
 vt_type2��$ Триодов�����#adb8d9 �#273049
 �����$
 4000Q�$ 0Q�$��10q�$	��110��  -	   $
 vt_type3��$% Триодов-Гептодов�����#adb8d9 �#273049
 �����$
 4000Q�$ 0Q�$��10q�$	��110��  -
   $
 vt_type4��$! Двойных диодов�����#adb8d9 �#273049
 �����$
 2000Q�$ 0Q�$��10q�$	��110��  -   $
 vt_type5��$ Кенотронов�����#adb8d9 �#273049
 �����$
 1000Q�$ 0Q�$��10q�$	��110���� $%��Общие показатели��$��Calibri)�$��14(�$��Medium"����#273049$��1���� $=��7Показатели по типам радиоламп��$��Calibri)�$��14(�$��Medium"����#273049$��3��
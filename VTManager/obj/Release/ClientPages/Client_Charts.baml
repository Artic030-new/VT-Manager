   M S B A M L   `   `   `  ���� D  @VTManager, Version=0.3.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:VTManager	VTManager  =#clr-namespace:VTManager.InteractiveVTManager.Interactive  )    #VTManager.ClientPages.Client_Charts   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:VTManager     ;Interactive#clr-namespace:VTManager.Interactive     -   $
��auto��$
��auto��  N� Title$  Client_Charts��.���  � RowDefinitions �� $
��170* ��� $	��60* ��� $
��293* ��� $	��60* ��� $
��510* ��� $��4* ��� $��6* ��� $
��180* � � ColumnDefinitions �� $
��250* ��� $
��506* ��� $
��359* ��� $	��83* ��� $
��292* �.+��� ���#fff$��8��$��5���� ���#273049$��5��$��5���� -    ��Name$ page_header��$'��!Статистика продаж��   page_header#���   $��2��� -    �Name$ 
main_costs��$��2��$��5��$��2��$��0,0,80,0q� �� ��  �� $
��192* ��� $	��39* ��� $
��205* ��� $	��39* ��� $
��235* �.+�)   #VTManager.Interactive.VTManagerStat  -     Name$ block1��   Target$' !Радиоламп продано��   Limit$	 499��
�������  -   $ block2��$' !Заказов оформлено��$��2��$ 4��
�������  -   $ block3��$7 1Клиентов зарегистрировано��$��4��$ 1��
�������� -   $ chart_items��$��4��$��5�� �� $
��270* ��� $
��140* ��� $
��270* ��� $
��140* � �� $
��141* ��� $	��98* �.+���  �� Orientation$ 
Horizontal=�$	��110��$	��Top=�$
��Left=�$	��265��.+�*   $VTManager.Interactive.VTManagerChart  -   	  Name$	 vt_mark1��
   ItemName$

 6К4�����#D9CEAD   Color �#CDA11C   	TextColor �#273049   MaxValue$
 4000Q�   Value$ 0Q�$��10q�$	��110��  -	   $	 vt_mark2��$

 6К7�����#D9CEAD �#CDA11C �#273049$
 4000Q�$ 0Q�$��10q�$	��110���� $ 
Horizontal=�$	��110��$	��Top=�$
��Left=�$	��265��$��	0,115,0,0q�$��2��.+�  -
   $	 vt_mark3��$

 6Ж3�����#D9CEAD �#CDA11C �#273049$
 4000Q�$ 0Q�$��10q�$	��110��  -   $	 vt_mark4��$
 6С1П�����#D9CEAD �#CDA11C �#273049$
 4000Q�$	 777Q�$��10q�$	��110���� $ 
Horizontal=�$��2��$	��110��$	��Top=�$
��Left=�$	��265��.+�  -   $	 vt_type1��$
 Пентодов�����#adb8d9 �#273049
 �����$
 4000Q�$ 0Q�$��10q�$	��110��  -   $	 vt_type2��$
 Триодов�����#adb8d9 �#273049
 �����$
 4000Q�$ 0Q�$��10q�$	��110���� $ 
Horizontal=�$��2��$	��110��$	��Top=�$
��Left=�$	��265��$��	0,115,0,0q�$��2��.+�  -   $	 vt_type3��$!
 Двойных диодов�����#adb8d9 �#273049
 �����$
 4000Q�$ 0Q�$��10q�$	��110��  -   $	 vt_type4��$
 Кенотронов�����#adb8d9 �#273049
 �����$
 4000Q�$ 0Q�$��10q�$	��110���� $%��Общие показатели��$��Calibri)�$��14(�$��Medium"����#273049$��1��$��3���� $?��9Показатели по маркам радиоламп��$
��Left=�$��Center=�$��Calibri)�$��14(�$��Medium"����#273049$��3��$��10,0,0,0q��� $=��7Показатели по типам радиоламп��$
��Left=�$��Center=�$��Calibri)�$��14(�$��Medium"����#273049$��3��$��2��$��10,0,0,0q�
   M S B A M L   `   `   `  ���� D  @VTManager, Version=0.3.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:VTManager.ProcssingPagesVTManager.ProcssingPages  -    'VTManager.ProcssingPages.Processing_Add   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     8local&clr-namespace:VTManager.ProcssingPages     X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -   $
��auto��$
��auto��  N� Title$  Processing_Add�� � 	Resources    
bold_label �� 
TargetType �� Property  
NunitoBold �� Value  light_label  NunitoLight��%�   &	        7  &	 Q     7  �� " ��.���  � ��8   ��  � ��$ 18(���  � �� �#273049�� " ��.���  � ��8   ��  � ��$ 24(���  � �� �#273049.���  � RowDefinitions �� $	��71* ��� $
��141* ��� $	��40* ��� $
��175* ��� �� $	��47* ��� $
��125* � � ColumnDefinitions �� $
��435* ��� $
��100* ��� $
��256* �.+��� ���#fff$��7��$��3���� -    ��Name$ page_header��$,��&Создать рабочий план��  page_header#���  #���  $��3��$��10,10,-20,0q�$	��406��� -    �Name$ searching_items��$��1��$��1��$��10q� �� $
��134* ��� $
��137* ��� $
��145* � �� $��2* ��� $��2* �.+��� -   	 ��Name$	 select_vt_cbox��$��8q�$��45�����#273049$��Calibri)�$��Light"�$��18(�  rounded_combobox#���  �� -   $	 select_personal_cbox�����#adb8d9$��8q�$��Calibri)�$��Light"�$��18(����#273049$��1��$��45��#���  �� -   
 ��Name$
 shift_field��$��2��$��0��$��8q�$��45�����#adb8d9���#273049  rounded_textbox#��[   
rounded_tb#���  �� -   $
 
plan_field��$��1��$��8q�$��45�����#adb8d9���#273049#��[ #���  �� -   $
 count_field��$��1��$��8q�$��45�����#adb8d9���#273049#��[ #���  $��1���� -	    ��Name$ 
add_button��$��2��$��1��$��СОЗДАТЬ��$��42��$��0q�#���    rounded_button#���  $��8,8,36,8q��� $,��&Активные планы работ��#��[ $��16(����#273049$��2��$��10,0,0,0q�&   System.Windows.Controls.DataGrid  -
     Name$ unsolved_plans_dg��$��10,10,10,10q�$��3��$��3�� 	 DataGridStyle#��� 	  
 HeaderStyle   ColumnHeaderStyle# � 
   RowStyle   RowStyle# �    
CellsStyle   	CellStyle# �     GridLinesVisibility$
 None=�   
IsReadOnly . �� ���#273049$��4��$��3��� -   $ service_items��$��5�� �� $	��40* ���  �� $	��54* ��� $	��54* ��� $��3* ��� $
��104* ��� $��2* �.+��� -   $ export_button��  service_button#���  .��� -   $ export_button_grid�� �� $	��30* ��� $	��90* �.+�F� ���#273049��B� $����M23.1,14.5h-0.5c-0.3,0-0.5,0.2-0.5,0.5v5.4c0,1-0.8,1.8-1.8,1.8h-9.6c-1,0-1.8-0.8-1.8-1.8v-9.6c0-1,0.8-1.8,1.8-1.8h6.1c0.3,0,0.5-0.2,0.5-0.5V8.1c0-0.3-0.2-0.5-0.5-0.5h-6.1c-1.8,0-3.3,1.5-3.3,3.3v9.6c0,1.8,1.5,3.3,3.3,3.3h9.6c1.8,0,3.3-1.5,3.3-3.3V15C23.6,14.8,23.4,14.5,23.1,14.5z M23,7.2l-3.6,1.2c-0.4,0.2-0.6,0.7-0.2,1.1l0.8,0.8l-4.3,5.2c-0.3,0.3-0.2,0.8,0.1,1c0.3,0.3,0.8,0.2,1-0.1l4.2-5.1l0.6,0.6c0.3,0.3,0.9,0.2,1.1-0.2L23.8,8C24,7.5,23.5,7,23,7.2zC��� $��1��$��Выгрузить��$��Center=�$��Center=�#��[ ���#273049�� -   $ print_button��#���  $��1��.��� -   $ print_button_grid�� �� $	��30* ��� $	��90* �.+�F� ���#273049$
��Left=�$��Center=���B� $����M21.9,10.1h-0.6v-2l-4.5-4.5h-6.6v6.5H9c-1.5,0-2.8,1.2-2.8,2.8v7.1c0,1.5,1.2,2.8,2.8,2.8h12.9c1.5,0,2.8-1.2,2.8-2.8v-7.1C24.7,11.3,23.5,10.1,21.9,10.1z M11.2,4.6h5.2l3.9,3.9v1.6h-9.1V4.6z M23.2,19.9c0,0.7-0.6,1.3-1.3,1.3H9c-0.7,0-1.3-0.6-1.3-1.3v-7.1c0-0.7,0.6-1.3,1.3-1.3h12.9c0.7,0,1.3,0.6,1.3,1.3V19.9zM21.4,17.4H10.1c-0.4,0-0.8,0.4-0.8,0.8c0,0.4,0.4,0.8,0.8,0.8h11.3c0.4,0,0.8-0.4,0.8-0.8C22.2,17.7,21.8,17.4,21.4,17.4z M9.5,12.4c-1.4,0-1.4,2.2,0,2.2C10.9,14.6,10.9,12.4,9.5,12.4z M12.4,14.6c1.4,0,1.4-2.2,0-2.2C11,12.4,11,14.6,12.4,14.6z M17.2,6.8h-4.5c-0.1,0-0.3,0.1-0.3,0.3v0.5c0,0.1,0.1,0.3,0.3,0.3h4.5c0.1,0,0.3-0.1,0.3-0.3V7.1C17.4,6.9,17.3,6.8,17.2,6.8zC��� $��1��$��Печать��$��Center=�$��Center=�#��[ ���#273049�� -   $
 debug_textbox��{�. $y�Visible=�$��6��$��Calibri)�$��16(�$��Medium"�$��Italic$� �� TextWrapping$
 Wrap=�
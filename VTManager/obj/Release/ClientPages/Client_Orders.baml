   M S B A M L   `   `   `  ���� D  @VTManager, Version=0.3.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:VTManager.ClientPagesVTManager.ClientPages  )    #VTManager.ClientPages.Client_Orders   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:VTManager.ClientPages     X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -     N� Title$  Client_Orders��$
��auto��$
��auto��.���  � RowDefinitions �� $	��60* ��� $
��120* ��� $
��183* ��� �� $	��40* ��� $
��106* � � ColumnDefinitions �� $
��217* ��� $	��15* ��� $
��163* �.+��� ���#fff$��6��$��3���� ���#273049$��3��$��3��&   System.Windows.Controls.DataGrid  -     Name$ 	orders_dg��$��10,10,10,10q�$��2��$��3��   DataGridStyle#���     HeaderStyle   ColumnHeaderStyle# �    RowStyle   RowStyle# �    
CellsStyle   	CellStyle# �     GridLinesVisibility$
 None=�   
IsReadOnly . �� -   	 ��Name$	 page_header��$+��%Управление заказами��  page_header#���  � -   
 �Name$
 searching_items��$��1��$��1��$��10q� �� $	��67* ��� $	��68* ��� $	��72* � �� $��2* ��� $��2* �.+��� -    ��Name$ order_number_field��$��8q�$��45��$��0q����#adb8d9���#273049  rounded_textbox#��[   
rounded_tb#���  %  Xceed.Wpf.Toolkit.MaskedTextBox  -     Name$ order_date_field��$��1��$��0��$��8q�$��45��$��0q����#adb8d9   Mask$ 
0000-00-00�� �� 
CaretIndex$ 0�����#273049$��Calibri)�$��Light"�$��18(�$��Center=�$
��Left=�#��[ �� -   $ vt_field��$��2��$��0��$��8q�$��45�����#adb8d9���#273049#��[ #���  �� -   $ initials_field��$��2��$��1��$��8q�$��45�����#adb8d9���#273049#��[ #���  �� -	    ��Name$ search_button��$��2��$��1��$��
НАЙТИ��$��42��$��0q����#273049  
NunitoBold#���    rounded_button#���  $��8,8,36,8q�� -
   $
 service_items��$��4�� �� $	��40* ���  �� $
��205* ��� $
��203* ��� $��9* ��� $	��13* ��� $��4* �.+��� -   $ erase_button�� 	 service_button#��� 	 .��� -   $
 ban_button_grid�� �� $	��30* ��� $	��90* �.+�F� ���#273049��B� $����M13.5,15.3l4-4c0.3-0.3,0.3-0.8,0-1.1l-0.8-0.8c-0.3-0.3-0.8-0.3-1.1,0l-4,4l-4-4c-0.3-0.3-0.8-0.3-1.1,0  l-0.8,0.8c-0.3,0.3-0.3,0.8,0,1.1l4,4l-4,4c-0.3,0.3-0.3,0.8,0,1.1l0.8,0.8c0.3,0.3,0.8,0.3,1.1,0l4-4l4,4c0.3,0.3,0.8,0.3,1.1,0  l0.8-0.8c0.3-0.3,0.3-0.8,0-1.1L13.5,15.3zC��� $��1��$!��Отменить заказ��$��Center=�$��Center=����#273049�� -   $ done_button��#��� 	 $��1��.��� -   $
 done_button_grid�� �� $	��30* ��� $	��90* �.+�F� ���#273049$
��Left=�$��Center=���B� $����M20.4,5.3l-0.1-0.1c-0.5-0.5-1.2-0.5-1.6,0l-8,8.3l-4.9-5c-0.4-0.4-0.9-0.4-1.3,0L4,8.9c-0.4,0.4-0.4,1,0,1.3  l6,6.2c0.4,0.4,0.9,0.4,1.3,0l0.8-0.9L20.4,7C20.8,6.6,20.8,5.8,20.4,5.3zC��� $��1��$#��Завершить заказ��$��Center=�$��Center=����#273049�� -   $ debug_textbox��{�. $y�Visible=�$��Calibri)�$��16(�$��Medium"�$��Italic$�$��5�� �� TextWrapping$
 Wrap=�
   M S B A M L   `   `   `  ���� D  @VTManager, Version=0.3.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:VTManager.ClientPagesVTManager.ClientPages  )    #VTManager.ClientPages.Client_Manage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:VTManager.ClientPages     X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -   $
��auto��$
��auto��  N� Title$  Client_Manage��.���  � RowDefinitions �� $
��121* ��� $
��235* ��� $	��50* ��� $
��323* ��� $��2* ��� $	��80* ��� $
��213* � � ColumnDefinitions �� $
��217* ��� $	��15* ��� $
��163* �.+��� ���#fff$��7��$��3���� ���#273049$��4��$��3��&   System.Windows.Controls.DataGrid  -     Name$ 
clients_dg��$��10,10,10,10q�$��3��$��3��   DataGridStyle#���     HeaderStyle   ColumnHeaderStyle# �    RowStyle   RowStyle# �    
CellsStyle   	CellStyle# �     GridLinesVisibility$
 None=�   
IsReadOnly . �� -   	 ��Name$	 page_header��$-��'Управление клиентами��  page_header#���    
NunitoBold#���  $��3��$��10,10,-38,0q�$	��424��� -   
 �Name$
 searching_items��$��1��$��1��$��10q�$��1�� �� $
��134* ��� $
��137* ��� $
��145* � �� $��2* ��� $��2* �.+��� -    ��Name$ firstname_field��$��8q�$��45��$��0q����#adb8d9���#273049$��Calibri)�$��Light"�$��18(�$��Center=�$
��Left=�  rounded_textbox#��[ �� -   $ lastname_field��$��1��$��0��$��8q�$��45��$��0q����#adb8d9���#273049$��Calibri)�$��Light"�$��18(�$��Center=�$
��Left=�#��[ �� -   $ thirdname_field��$��2��$��0��$��8q�$��45��$��0q����#adb8d9���#273049$��Calibri)�$��Light"�$��18(�$��Center=�$
��Left=�#��[ �� -   $ email_field��$��2��$��1��$��8q�$��45��$��0q����#adb8d9���#273049$��Calibri)�$��Light"�$��18(�$��Center=�$
��Left=�#��[ �� -	    ��Name$ search_button��$��2��$��1��$��
НАЙТИ��$��42��$��0q�#���    rounded_button#���  $��8,8,36,8q�� -
   $
 service_items��$��5�� �� $	��40* ���  �� $
��205* ��� $
��203* ��� $��9* ��� $	��13* ��� $��4* �.+��� -   $ 
ban_button��  service_button#���  .��� -   $
 ban_button_grid�� �� $	��30* ��� $	��90* �.+�F� ���#273049��B� $����M17.8,17.8c0.2,0.2,0.5,0.2,0.7,0l3.2-3.2c0.2-0.2,0.2-0.5,0-0.7l-5.1-5.1c-0.2-0.2-0.5-0.2-0.7,0l-3.2,3.2   c-0.2,0.2-0.2,0.5,0,0.7l2,2L5,23.8c-0.3,0.3-0.2,1.1,0.1,1.5l0.2,0.4c0.3,0.3,0.8,0.1,1.1-0.2l9.2-9.8L17.8,17.8zM18.5,20L18.5,20c0.4,0.4,1.1,0.4,1.5,0l3.6-3.6c0.4-0.4,0.4-1.1,0-1.5s-1.1-0.4-1.5,0l-3.6,3.6   C18.1,18.9,18.1,19.6,18.5,20zM11.9,11.9l3.6-3.6c0.4-0.4,0.4-1.1,0-1.5s-1.1-0.4-1.5,0l-3.6,3.6c-0.4,0.4-0.4,1.1,0,1.5   C10.9,12.3,11.5,12.3,11.9,11.9zM26.6,24h-0.2v-1.1H14.8V24h-0.6c-0.5,0-1,0.4-1,1V26h14.3V25C27.6,24.4,27.1,24,26.6,24zC��� $��1��$/��)Заблокировать клиента��$��Center=�$��Center=����#273049�� -   $ 
sec_button��#���  $��1��.��� -   $
 sec_button_grid�� �� $	��30* ��� $	��90* �.+�F� ���#273049$
��Left=�$��Center=���B� $����M16,3.4c-2.4,0-4.4,2-4.4,4.4c0,0.9,0.3,1.8,0.8,2.5l-2,2.3L10,12.4C9.6,12,9,12,8.6,12.4l-0.7,0.8  c-0.4,0.4-0.3,1,0.1,1.4l0.3,0.3l-0.7,0.9l-1-1.1c-0.4-0.4-1.1-0.5-1.5-0.1l-0.6,0.6c-0.4,0.4-0.5,1.1-0.1,1.5l2,2.3  c0.1,0.1,0.2,0.2,0.4,0.3l0.1,0.1c0.5,0.5,1.4,0.4,1.9-0.1l6.2-7.1c0.4,0.1,0.8,0.2,1.2,0.2c2.4,0,4.4-2,4.4-4.4  C20.4,5.4,18.4,3.4,16,3.4z M16,9.3c-0.8,0-1.5-0.7-1.5-1.5s0.7-1.5,1.5-1.5s1.5,0.7,1.5,1.5S16.8,9.3,16,9.3zC��� $��1��$��Личные данные��$��Center=�$��Center=����#273049�� -   $ debug_textbox��{�. $y�Visible=�$��Calibri)�$��16(�$��Medium"�$��Italic$�$��6�� �� TextWrapping$
 Wrap=��� $#��Список клиентов��#��[ $��16(����#273049$��2��$��10,0,0,0q�
   M S B A M L   `   `   `  ���� D  @VTManager, Version=0.3.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:VTManager	VTManager      VTManager.AuthWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:VTManager     -     � WindowStartupLocation$  CenterScreen=� � Title$) #VT Manager | Авторизация��$	��340��$	��460�� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � Icon$ vt.png�� � 	Resources    
bold_label �� 
TargetType �� Property  
NunitoBold �� Value  light_label  NunitoLight��%�   &	        7  &	 Q     7  �� " ��.���  � ��8   ��  � ��$ 18(���  � �� �#EDEDED�� " ��.���  � ��8   ��  � ��$ 14(���  � �� �#EDEDED.��� ���#3c486c	 � RowDefinitions	 �� $	��54* ��� $
��101* ��� $	��15* �.+��� -   
 ��Name$
 authorize_label��#��[ $��32(�$&�� А В Т О Р И З А Ц И Я��$��center=�$��center=�$	��340��$��48��$��66,47,54,13q��� ���#333d5c �� RadiusX$ 16�� �� RadiusY$ 16��$��center=�$��center=�$	��282��$	��200��$��1��$��
93,8,85,24q�$��2��� -    �Name$ login_items��$��1��$��center=�$��center=�$	��252��$	��166��$��104,18q� � ColumnDefinitions �� $	��45* ��� $	��17* ��� $	��64* �	 �� -    ��Name$ 	row_login��$	��24* ��� -   $ row_password��$	��24* ��� -   $ row_login_button��$	��16* ��� $	��19* �.+��� -   $
 login_label��$��center=�$
��left=�$��Логин : ��$��32��$��0��$��75��$��0,7,0,9q�#���   �� $��1q�
������  �� CornerRadius$ 6�� �� Padding$ 4q�$��Center=�$��Center=�$��1��$��0�����#273049$	��4,3q�$��42��$	��154��$��2��._��� -    ��Name$ login_field��$	��144��$��32��$��center=�$��1��$��0��$��0q����#273049���#cecece#���  $��18(�$��0,4,0,-4q��� -	   $
 passsword_label��$��center=�$
��left=�$��Пароль : ��$��89��$��32��$��0��$��1��$��0,7,0,9q�#���   �� $��1q�
������ $ 6��$ 4q�$��Center=�$��Center=�$��1��$��1�����#273049$	��4,3q�$��42��$	��154��$��2��._�G� -
    G�Name$ password_field��$	��144��$��32��$��center=�$��1��$��1��$��0q����#273049���#cecece#���  $��18(�$��0,1,0,-1q��� -    ��Name$ login_button�� �� 	IsDefault . $��
ВОЙТИ��$��45��$��bottom=�$��0��$��3��$��3��$��72,0,80,-16q�$��	0,0,-2,-3q�#���    rounded_button#���  ���� *
LoginCmd+�� -    ��Name$ Border��$��28��$��28�����#273049$ 4��$
��Left=�$��4,2,0,2q�$��Center=�$��1q�$��1��$��2���� -    ��Name$
 keep��$�� ��$
��Left=�$��1��$��2��$	��Top=�  auth_checkbox#���   � LayoutTransform ��  �� ScaleX$ 2Q� �� ScaleY$ 2Q��� $��2��$��2��$!��Запомнить вход��$��Center=�#��[ $��0,2,0,36q�$��2��� -   $ header��$
��Left=�$��33��$	��Top=�$	��460�����#273049 �� $	��20* ��� $	��58* ��� $��7* ��� $��7* � J� InputBindings d�  d� MouseAction$ 	LeftClicke� �� Command ��  �� Path$ DragApplicationCmd�.+��� -   $
 header_label��$��center=�$��center=�$��96��$��30��$��
VT Manager��#���  $��2,2,2,1q��� -   $ close_button��$��x��
������ 
������ 
�������  close_buttons#���  #���  $��20(�$��3��$��
0, 0, 0, 4q����� $ CloseApplicationCmd�   close_button��%   &	       �� �� -   $ hide_button��$	��—��
������ 
������ 
�������$��2������ $ HideApplicationCmd�
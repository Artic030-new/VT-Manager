   M S B A M L   `   `   `  ���� D  @VTManager, Version=0.3.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:VTManager	VTManager      VTManager.VTManagerDialog   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:VTManager       � WindowStartupLocation$  CenterScreen=� � Title$ VTManagerDialog��$	��160��$	��250�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � 	Resources    FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background	 �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 rounded_button
 �� 
TargetType �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 N     &	 c     &	 x     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
     7   7  7  7  7  7 	 �� .���  � �� �� .R��� $��2q� . #��� ��$��1��$	 1 2R��� $	 	#FFDDDDDD���� $	 	#FF707070���� $	 	#FFBEE6FD���� $	 	#FF3C7FB1���� $	 	#FFC4E5F6���� $	 	#FF2C628B���� $	 	#FFF4F4F4���� $	 	#FFADB2B5���� $	 	#FF838383���� "
 ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 0q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��$ 8��#��z��#��z��#��z�� . $��	0,0,-29,0q�._��� $ contentPresenter��|�.  #��z��#��z����. # z #��z�� P�  �@��IsDefaulted . . ��� $ border��# � �� � ��P�  �@J�IsMouseOver . . ��� $ border�� � �� �#82a0f3�� $ border�� � �� �#82a0f3P�  � �� . . ��� $ border�� � �� �#82a0f3�� $ border�� � �� �#82a0f3P�  � {� .  . ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8   � ��.��� ���#3c486c � RowDefinitions �� $	��35* ��� $	��84* ��� $	��41* �.+�� $
��Left=�$��35��$	��Top=�$	��250�����#273049.+��� -    ��Name$ dialog_label��$��Label��$
��Left=�$	��Top=�$	��110��$��16(�$
��Bold"�$��0,4,0,0q����#FFF J� InputBindings d�  d� MouseAction$ 	LeftClicke� �� Command ��  �� Path$ DragApplicationCmd��� -    ��Name$ contained_info��$��center=�$��center=�$��48�� �� TextWrapping$
 Wrap=�$��TextBox��$	��188��$
��Bold"�$��16(�$��0q� �� 
IsReadOnly .  �� IsUndoEnabled .   �� TextAlignment$ Center=�
������ ���#FFF$��1��$��
32,29,30,7q��� $��OK��$
��Left=�$��	93,10,0,0q�$��2��$	��Top=�$��32��$��22�����#273049���#fff$
��Bold"�$��14(�#��� 
 ���� *OkCmd+�� ���#fff$��0��$��2��$��1��$��Bottom=�
   M S B A M L   `   `   `  ����H  Dtest_example6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:test_example6test_example6  5   	   C&clr-namespace:test_example6.Converterstest_example6.Converters  5   	       test_example6.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:test_example6     5   	   =
Converters&clr-namespace:test_example6.Converters     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � 	Resources 5      2   ,test_example6.Converters.IntToBrushConverter   IntToBrushConverter��%   &	          5   
   6)   5       � DataContext 5      �� 5   
    �� Path$
 Main�6     Locator �� Source# [ 6   .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��10q�6   $��Filter (ID Type)��6    $��Center=�6;   $��20(�6V   �� 5      $��10q�6   $	��200��6#   $��Center=�6/   $��40��6J    �� SelectedItem 6V   �� *SelectedIDType+��6~   �� *	IdTypes+	 �� UpdateSourceTrigger$	 PropertyChanged=�5      �� 5   
   $��1��6   $ 
Horizontal=�6%   $��Right=�6>   .+�5      �� $��10q�6   $	��150��6!   $��Center=�6-   $��40��6H   $��Act as Client��6T   $��20(�6l   
�����F���6z   �� *ClientBtnClickedCmd+6�   �� 5       $��10q�6   $	��150��6!   $��Center=�6-   $��40��6H   $��Act as Server��6T   $��20(�6l   
�����F���6z   �� *ServerBtnClickedCmd+6�   5"      &   System.Windows.Controls.DataGrid  5#   
   $��2��6   $��1��6'   
   AutoGenerateColumns
 .  ��6P   �� *
PersonList+   Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Firstname��6h   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	Firstname+$	 PropertyChanged=�6h     5'      $ Lastname��6f    6%   �� *
Lastname+$	 PropertyChanged=�6f     5(      $	 Age��6a    6%   �� *Age+$	 PropertyChanged=�6a     5)      $ Id��6`    6%   �� *Id+$	 PropertyChanged=�6`     5*      $ IdType��6d    6%   �� *IdType+$	 PropertyChanged=�6d   4  .System.Windows.Controls.DataGridTemplateColumn  5+      $ Rating��6)      CellTemplate 5,      �� 5-      .R�5.      �� $ 
Horizontal=�6)   .+�5/   "   �� ��6(   �� *Rating+A� 50   "   $��20��6*   $��20��66   ��6A   �� *Rating+ �� 	Converter# [  51      52      54      56      57      58      
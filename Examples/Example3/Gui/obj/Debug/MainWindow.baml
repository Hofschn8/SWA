   M S B A M L   `   `   `  ����>  :Gui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GuiGui  5   	       Gui.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Gui     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5	   
   ��    Locator �� Source# [   �� Path$
 Main�.��5
      �  � ColumnDefinitions 5   
   �� 5      $
��145* �6   �� 5      $
��141* �6   �� 5      $	��67* �6   �� 5      $
��439* �6    � RowDefinitions 5   
   �� 5      $	��59* �6   �� 5      $	��50* �6   �� 5      $
��310* �6   �� 5      $	��50* �6   .+�5   
   �� $��3��6   $��0��6!   $	��100��6.   $��40��6:   
�����_�
�������$��Start Generating��6p   ��6�   �� *StartGenerateCmd+�� 5   
   $��1��6   $��0��6   $��Waiting for:��6-   $
��Bold"�6D   �� 5   
   $��1��6   $��1��6   $��Ready:��6-   $
��Bold"�6>   �� 5   
   $��1��6   $��3��6   $��Details:��6-   $
��Bold"�6@   �� 5   
   $��2��6   $��0��6   ��6/   �� *ListOfWaitingItems+ �� UpdateSourceTrigger$ PropertyChanged=���5      �� 5       .R�5!      ��  �� Orientation$ Vertical=�6!   5"      ��5$      �� 5%      .R�5&      �� $ 
Horizontal=�6!   .+�5'      �� ��6    �� *Description+�� 5(      ��6    �� *RemainingTime+5)      5*      5,      �� 5.   
   $��2��6   $��1��6   ��6/   �� *ListOfReadyItems+$ PropertyChanged=� �� SelectedItem 6}   �� *SelectedItem+$ PropertyChanged=���5/      �� 50      .R�51      �� $ Vertical=�6!   52      ��54      �� 55      .R�56      �� $ 
Horizontal=�6!   .+�57      �� ��6    �� *Description+�� 58      ��6    �� *DeliveryTime+59      5:      5<      �� 5>   
   $��2��6   $��2��6!   $��40��6.   $��40��69   
�����_�
�������$��>>��6o   ��6|   �� *	DetailCmd+&   System.Windows.Controls.DataGrid  5@   
   $��3��6   $��2��6#   	   AutoGenerateColumns	 .  
   GridLinesVisibility$	
 All=�6�      HorizontalGridLinesBrush
 ��  �   VerticalGridLinesBrush
 ��  ���6L   �� *ShowDetailView.ListOfCargos+   Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Cargo Item��6a      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6u   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Item+   ClipboardContentBinding 6>   Z� 6u     5C      $ Weight��6c   $ * 6s    6%   �� *Weight+ 6@   Z� 6s     5D      $ Amount��6c   $ * 6s    6%   �� *Amount+ 6@   Z� 6s   5I      �� 5K   
   $��0��6   $��3��6!   $��4��6.   $	��400��6B   $��40��6N   
�����_�
�������$��Clear��6�   5N      5O      
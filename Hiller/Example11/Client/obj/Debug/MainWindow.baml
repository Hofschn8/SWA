   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	       Client.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 65   �� *Main+ �� Mode$ OneWay=�   Locator �� Source# [  .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��4* �6   �� 5      $��1* �6   .+�5   
   �� $��Connect��6   $��30��6#   $��50��6/   ��6:   �� *ConnectBtnClicked+�� 5   
   $��1��6   $��Center=�6"   $��Center=�6?   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� $	��Tag��6   $��80��6&   �� 5      $	��150��6   ��6&   �� *Tag+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5      $ 
Horizontal=�6   .+�5      �� $
��Time��6   $��80��6'   (  "System.Windows.Controls.DatePicker  5         SelectedDate 6   �� *Time+$ PropertyChanged=�5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Person��6   $��80��6)   �� 5      $	��150��6   ��6&   �� *Person+$ PropertyChanged=�5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Column��6   $��80��6)   �� 5      $	��150��6    �� SelectedItem 6'   �� *Column+$ PropertyChanged=���6l   �� *
ColumnList+5       5!      �� 5"   
   $��2��6   $	��100��6   $��30��6*   $
��Send��66   ��6E   �� *AddBtnClicked+5#      5$      
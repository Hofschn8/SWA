   M S B A M L   `   `   `  ����C  ?Example6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Example6Example6  5   	   9!clr-namespace:Example6.ConvertersExample6.Converters  5   	       Example6.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Example6     5   	   8
Converters!clr-namespace:Example6.Converters     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � 	Resources 5
      -   'Example6.Converters.IntToBrushConverter   IntToBrushConverter��%   &	          5   
   6)   5       � DataContext 5      �� 5   
     Locator �� Source# [ 6    �� Mode$ OneWay=�64    �� Path$
 Main�6B   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��4* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��30��6.   .+�5      �� $��Filter (ID Type)��6   �� 5      $	��100��6   ��6#   �� *
Filterlist+	 �� SelectedItem	 6F   �� *SelectedFilter+5      �� 5   
   $��1��6   $ 
Horizontal=�6%   $��40��6>   $��Right=�6J   .+�5      �� $��Act as Client��6   $��10q�6-   ��69   �� *ClientBtnCmd+�� 5      $��Act as Server��6   $��10q�6-   ��69   �� *ServerBtnCmd+5       &   System.Windows.Controls.DataGrid  5!   
   $��1��6   $��2��6    $��30q�64   
   AutoGenerateColumns
 .  ��6@   �� *
TmpPersons+   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Firstname��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	Firstname+ �� UpdateSourceTrigger$ PropertyChanged=�   ClipboardContentBinding 6h   Z� 5%        5&      $ Lastname��6e    6%   �� *
Lastname+ 6B   Z� 6e     5'      $	 Age��6`    6%   �� *Age+ 6=   Z� 6`     5(      $ Id��6e    6%   �� *
IDNumber+ 6B   Z� 6e   4  .System.Windows.Controls.DataGridTemplateColumn  5)      $ IDType��6L      ClipboardContentBinding 6)   Z�    CellEditingTemplate 5*      �� 5+      .R�5,      �� ��6'   �� *Main.Filterlist+# [ 	 6p   �� *IDType+6�   5-      5/        51      $ Rating��6L    6)   Z�    CellTemplate 52      �� 53      .R�54      A� $��20��6&   $��20��62   ��6=   �� *Rating+ �� 	Converter# [  55      57      59      5:      5;      
   M S B A M L   `   `   `  ����>  :Gui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GuiGui  5   	   -clr-namespace:Gui.ConverterGui.Converter  5   	       Gui.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Gui     5   	   1	Converterclr-namespace:Gui.Converter     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��700��6)    � 	Resources 5      -   'Gui.Converter.BoolToVisibilityConverter   BoolToVisibilityConverter��%   &	          5   
   6.   5       � DataContext 5      �� 5   
    �� Path$
 Main�6     Locator �� Source# [ 6   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $	��62* �6   �� 5      $	��62* �6   �� 5      $	��77* �6   �� 5      $
��280* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5      �� $��Act as Client��6   $��40��6-   $	��100��69   $��Right=�6E   $��5q�6a   ��6l   �� *ActClientCmd+�� 5      $��Act as Server��6   $��40��6-   $	��100��69   $��Right=�6E   $��5q�6a   ��6l   �� *ActServerCmd+5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��Right=�6;   .+�5      �� $��Prod.ID��6   $	��100��6&   $	��5,0q�62   �� 5       $
��Name��6   $	��100��6#   $	��5,0q�6/   �� 5!      $��Price��6   $	��100��6$   $	��5,0q�60   �� 5"      $
��Type��6   $	��100��6#   $��	5,0,111,0q�6/   5#      �� 5%   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   .+�5&      �� $��40��6   $	��100��6"   $	��5,0q�6.   ��6;   �� *ProdId+ �� UpdateSourceTrigger$ PropertyChanged=��� 5'      $��40��6   $	��100��6"   $	��5,0q�6.   ��6;   �� *Name+$ PropertyChanged=��� 5(      $��40��6   $	��100��6"   $	��5,0q�6.   ��6;   �� *Price+$ PropertyChanged=��� 5)      $��40��6   $	��100��6#   $	��5,0q�6/   ��6<   �� *Types+ �� SelectedItem 6Z   �� *Type+$ PropertyChanged=��� 5*      $	��Add��6   $��40��6#   $	��100��6/   $	��5,0q�6�   ��6;   �� *AddCmd+y�6V   �� *IsAddVisible+	 �� 	Converter#	 [  6�   5+      &   System.Windows.Controls.DataGrid  5-   
   $��3��6   
   AutoGenerateColumns
 .  $	��5,0q�6^   ��6<   �� *
Products+   Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Product ID��6f      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	ProductId+   ClipboardContentBinding 6C   Z� 6z     50      $
 Name��6a   $ * 6o    6%   �� *Name+ 6>   Z� 6o     51      $ Price��6b   $ * 6q    6%   �� *Price+ 6?   Z� 6q     52      $
 Type��6a   $ * 6o    6%   �� *Type+ 6>   Z� 6o   56      58      59      
   M S B A M L   `   `   `  ����>  :Gui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GuiGui  5   	   -clr-namespace:Gui.ViewModelGui.ViewModel  5   	   #clr-namespace:Gui.ViewGui.View  5   	       Gui.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Gui     5   	   *vmclr-namespace:Gui.ViewModel     5   	   (viewsclr-namespace:Gui.View     5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)    � DataContext 5   	   ��    Locator �� Source# [   �� Path$
 Main�.��5      �  � RowDefinitions 5   
   �� 5      $	��47* �6   �� 5      $
��372* �6    � ColumnDefinitions 5   
   �� 5      $��7* �6   �� 5      $
��125* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��1��6.   $��0��6>   .+�5      �� $
��Data��6   $	��100��6$   $��40��60   ��6<   �� *	DataCmd+�� 5      $��History��6   $	��100��6'   $��40��63   ��6?   �� *
HistoryCmd+5      �� 5   
   $��1��6   $��1��6&   ��66   �� *CurrentDetailView+ �� UpdateSourceTrigger$ PropertyChanged=� � 	Resources 5      	 �� DataType   Gui.ViewModel.DataVm   Gui.View.DataView   Gui.ViewModel.HistoryVm   Gui.View.HistoryView��%�   (��       5      *, +)(�� 2     5       *, +)�� 5      "	  6   .R�5        5      �� 5       "	  6   .R�5!        5"      5#      5&      5(      5)      
   M S B A M L   `   `   `  ����?  ;_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:_GUI_GUI  5   	   /clr-namespace:_GUI.ViewModel_GUI.ViewModel  5   	   1clr-namespace:_GUI.Converters_GUI.Converters  5   	       _GUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:_GUI     5   	   +bpclr-namespace:_GUI.ViewModel     5   	   4
Convertersclr-namespace:_GUI.Converters     5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)    � 	Resources 5      -  '_GUI.Converters.DoubleToColourConverter   DoubleToColourConverter*   $_GUI.Converters.TypToStringConverter  TypToStringConverter��%:   &	        &	        5   
   6-     5   
   6*   5       � DataContext 5      �� 5   
    �� Mode$ OneWay=�6    �� Path$
 Main�6      Locator �� Source# [ 6,   .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��4* �6   .+�5   
   �� $��0��6   $��20q�6%   .+�5      �� $��
Blueprints��6   �� 5      
���   �$��1q�6)   $	��300��6=   ._�5#      �� ��6   �� *
BluePrints+ �� SelectedItem 6=   �� *SelectedBluePrint+ 5$       �� DataType    _GUI.ViewModel.BluePrintVm��%�   (��       5%   '   *, +)�� 6   "  6'   .R�5&      �� .+�5'   "   A� 
��� � �$��20��67   $��20��6C   �� 5(   "   $	��Car��6(   5)      5*      5+      5,      5-      5.      �� 50   
   
���   �$��1q�6%   $��20q�69   $��1��6E   $	��300��6U   ._�51      � $��10q�6   	 � RowDefinitions	 52      �� 53      $��* �6$   �� 54      $��* �6$   �� 55      $��* �6$   �� 56      $��* �6$   �� 57      $��4* �6$    59      �� 5:      $	��22* �6'   �� 5;      $	��59* �6'   .+�5>      �� $��
Components��6   $��0��6-   $��Center=�6=   $��Center=�6Z   �� 5?      $
��Time��6   $��0��6'   $��1��67   $��Center=�6D   $��Center=�6a   �� 5@      $��Amount��6   $��0��6)   $��2��69   $��Center=�6F   $��Center=�6c   �� 5A      $��Completion Time��6   $��0��62   $��3��6B   $��Center=�6O   $��Center=�6l   �� 5B      $��Rating��6   $��0��6)   $��4��69   $��Center=�6F   $	��Top=�6c   �� 5D      $��1��6   $��0��6*   $	��200��67   $��30��6C   $
��Left=�6O   $��Center=�6j   ��6�   �� *SelectedBluePrint.Components+�� 5E      $��1��6   $��1��6*   $	��200��67   $��30��6C   $
��Left=�6O   $��Center=�6j   ��6�   �� *SelectedBluePrint.Time+�� 5F      $��1��6   $��2��6*   $	��200��67   $��30��6C   $
��Left=�6O   $��Center=�6j   ��6�   �� *SelectedBluePrint.Amount+�� 5G      $��1��6   $��3��6*   $	��200��67   $��30��6C   $
��Left=�6O   $��Center=�6j   ��6�   �� *" SelectedBluePrint.CompletionTime+A� 5H      $��1��6   $��4��6*   $��30��67   $��30��6B   $
��Left=�6N   $	��Top=�6i   ��6�   �� *SelectedBluePrint.Rating+
 �� 	Converter#
 [  5J      5K      5M      5N      
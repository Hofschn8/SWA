   M S B A M L   `   `   `  ����C  ?Example7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Example7Example7  5   	   9!clr-namespace:Example7.ConvertersExample7.Converters  5   	       Example7.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Example7     5   	   8
Converters!clr-namespace:Example7.Converters     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � 	Resources 5
      0   *Example7.Converters.DoubleToBrushConverter   DoubleToBrushConverter��%   &	          5   
   6,   5       � DataContext 5      �� 5   
    �� Mode$ OneWay=�6    �� Path$
 Main�6      Locator �� Source# [ 6,   .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $	��10* �6   .+�5   
   �� $��Start��6   $	��100��6!   $��30��6-   ��69   �� *StartServer+�� 5   
   $��
Blueprints��6   $��Center=�6%   $��Bottom=�6B   �� 5   
   $��1��6   $��10q�6   $	��150��6+   ��67   �� *
Blueprints+ �� SelectedItem 6Z   �� *SelectedItem+	 �� UpdateSourceTrigger$	 PropertyChanged=���5      �� 5      .R�5      �� ��6   �� *Description+5      5!      �� 5#   
   $��1��6   $��1��6"   $��Center=�62   .+�5$      �� 
 �� Orientation$
 
Horizontal=�6   .+�5%      �� $��Components: ��6   $	��150��6/   �� 5&      $	��200��6   ��6&   �� *SelectedItem.Components+5'      �� 5(      $
 
Horizontal=�6   .+�5)      �� $��Time: ��6   $	��150��6)   �� 5*      $	��200��6   ��6&   �� *SelectedItem.Starttime+5+      �� 5,      $
 
Horizontal=�6   .+�5-      �� $��Amount: ��6   $	��150��6+   �� 5.      $	��200��6   ��6&   �� *SelectedItem.Amount+5/      �� 50      $
 
Horizontal=�6   .+�51      �� $��Completion-Time: ��6   $	��150��64   �� 52      $	��200��6   ��6&   �� *SelectedItem.Completiontime+53      �� 54      $
 
Horizontal=�6   .+�55      �� $��Rating: ��6   $	��150��6+   A� 56      $��15��6   $��15��6%   ��61   �� *SelectedItem.Rating+ �� 	Converter# [  57      58      59      5:      
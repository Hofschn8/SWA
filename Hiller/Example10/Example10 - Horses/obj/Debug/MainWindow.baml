   M S B A M L   `   `   `  ����M  IExample10 - Horses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Example10___HorsesExample10___Horses  5   	   #    Example10___Horses.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Example10___Horses     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 65   �� *Main+ �� Mode$ OneWay=�   Locator �� Source# [  .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��8* �6   �� 5      $��2* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Server��6   $	��120��6&   $��10q�62   ��6>   �� *ServerClickedCmd+�� 5      $��Client��6   $	��120��6&   $��10q�62   ��6>   �� *ClientClickedCmd+5      �� 5   
   $��1��6   $��All About Horses��6    $��Center=�6;   $��Center=�6X   �� 5   
   $��1��6   $��1q�6   
���   �$	��200��6G   ._�5      �� $��0 10 0 0q�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $
��Name��6   �� 5      $	��150��6   ��6*   �� *SelectedName+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5      $ 
Horizontal=�6   $
��0 10q�66   .+�5      �� $��Speed��6   �� 5       $	��150��6   ��6*   �� *SelectedSpeed+$ PropertyChanged=�5!      �� 5"      $��Right=�6   $	��100��69   $��Bottom=�6E   .+�5#      �� $	��Add��6   ��6+   �� *AddClickedCmd+y�6M   �� *
Visibility+5$      5%      5'      �� 5(   
   $��1��6   $��1��6   $	��250��6/   ��6;   �� *Horses+��5)      �� 5*      .R�5+      �� $��1q�6   
���   � �� CornerRadius$ 25��6E   ._�5,      �� $ 
Horizontal=�6%   .+�5-      �� $��30��6%   $��1q�61   
���   �$ 5��6Y   
��������6�   �� *Speed+._�5.   "   �� $��Center=�6,   ��6I   �� *Name+5/      �� 50      $��./Foto/auto.jpg��6$   $��30��6=   $��50��6I   51      52      53      55      �� 56   
   $��2��6   $��1��6"   $ 
Horizontal=�62   $��Center=�6K   $��Center=�6h   .+�57      �� $��Fastest Horse:��6   �� 58      ��6   �� *FastestHorse+59      5:      5;      
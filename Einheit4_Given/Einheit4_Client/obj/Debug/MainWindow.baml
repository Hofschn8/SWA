   M S B A M L   `   `   `  ����J  FEinheit4_Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Einheit4_ClientEinheit4_Client  5   	        Einheit4_Client.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Einheit4_Client     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��600��6)    � DataContext 65   �� *Main+ �� Mode$ OneWay=�   Locator �� Source# [  .��5	      �  � RowDefinitions 5
   
   �� 5      $	��50* �6   �� 5      $
��100* �6   �� 5      $	��50* �6   �� 5      $
��170* �6   �� 5      $
��100* �6    � ColumnDefinitions 5   
   �� 5      $	��80* �6   �� 5      $
��150* �6   �� 5      $	��70* �6   �� 5      $
��150* �6   �� 5      $	��80* �6   .+�5   
   �� $��
Client ID:��6   $��0��6%   $��0��62   $��Right=�6B   $��Bottom=�6^   �� 5   
   $��0��6   $��1��6   $	��150��6/   $��30��6;   $
��Left=�6G   $��Bottom=�6b   ��6}   �� *
ClientId+�� 5   
   $��	Lastname:��6   $��1��6$   $��0��61   $��Right=�6A   $��Bottom=�6]   �� 5   
   $��1��6   $��1��6   $	��150��6/   $��30��6;   $
��Left=�6G   $��Bottom=�6b   ��6}   �� *
Lastname+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��	Semester:��6   $��1��6$   $��2��61   $��Right=�6A   $��Bottom=�6]   �� 5    
   $��1��6   $��3��6   $	��150��6/   $��30��6;   $
��Left=�6G   $��Bottom=�6b   ��6}   �� *
Semester+$ PropertyChanged=��� 5"   
   $	��Add��6   $��2��6   $��3��6,   $	��150��6<   $��30��6H   $��0,5,0,5q�6T   $
��Left=�6e   $��Bottom=�6�   ��6�   �� *AddStudentClickedCommand+�� 5$   
   $��Queue:��6   $��3��6!   $��0��6.   $��Right=�6>   $	��Top=�6Z   &   System.Windows.Controls.DataGrid  5&   
   $��3��6   $��1��6    $��3��60   $��5q�6D   ��6O   �� *
Students+$ PropertyChanged=��� 5(   
   $
��Send��6   $��4��6    $��3��6-   $	��150��6=   $��30��6I   $��0,5,0,5q�6U   $
��Left=�6f   $	��Top=�6�   ��6�   �� *SendClickedCommand+$ PropertyChanged=�5+      5,      
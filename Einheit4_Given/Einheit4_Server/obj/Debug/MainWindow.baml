   M S B A M L   `   `   `  ����J  FEinheit4_Server, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Einheit4_ServerEinheit4_Server  5   	        Einheit4_Server.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Einheit4_Server     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5	   	   ��    Locator �� Source# [   �� Path$
 Main�.��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      .+�5   
   �� $��25(�6   $��Connected Clients��6   $��Bottom=�6:   �� 5   
   $��1��6   ��6   �� *	Clients+ �� SelectedItem 6?   �� *SelectedClient+ �� UpdateSourceTrigger$ PropertyChanged=���5      �� 5      .R�5      �� $��1q�6   
���   � �� CornerRadius$ 5��6E   ._�5      �� 	 �� Orientation$	 
Horizontal=�6%   .+�5      �� $��20(�6$   ��62   �� *
ClientID+�� 5      $��20(�6$   ��62   �� *Submissions.Count+5      5      5      5      �� 5    
   $��1��6   $��1��6   ��6/   �� *SelectedClient.Submissions+��5!      �� 5"      .R�5#      �� $��2q�6   
�������$ 10��6E   ._�5$      �� ��6   �� *
Students+��5%      �� 5&      .R�5(   "   �� $	 
Horizontal=�6-   .+�5)   &   �� $��20(�6,   $��5q�6:   ��6E   �� *
Lastname+�� 5*   &   $��20(�6,   $��5q�6:   ��6E   �� *
Semester+5+   #   5-      5/      50      51      53      54      55      
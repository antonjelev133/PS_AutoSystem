   M S B A M L   `   `   `  ����J  FPS_project_auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PS_project_auto.ModelViewPS_project_auto.ModelView  5      $    PS_project_auto.View.PrintPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =	ViewModel'clr-namespace:PS_project_auto.ModelView     5        N� Title$  	PrintPage��5      $��310.15��6   $��325.94��6$   .��5
      � .+�5   
   �� $��35,31,36,42q�6U   ��6   �� *cars+ �� SelectedItem 60   �� *SelectedCar+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��
images.png��6    $��44��64   $��44��6?   $
��Left=�5   !   �� 5      $ Vertical=�6%   .+�5      �� $ 
Horizontal=�6)   .+�5   "   �� $��Марка: ��6,   �� 5   "   $
��Bold"�6C   ��6,   �� *MARK+6C   �� 5   "   $��, ��6,   �� 5   "   $��Модел: ��6,   �� 5   "   $
��Bold"�6C   ��6,   �� *MODEL+6C   5      �� 5      $ 
Horizontal=�6)   .+�5   "   �� $��(��6-   �� 5   "   $��	Underline{�5       
����  � � Cursor$
 Hand��60   ��5   ,   �� *REGISTRATION+5    0   �� 5!   "   $��)��6,   5#      5$      5%      5&      5(      �� 5)   
   $��Принтирай��6>   $
��Left=�6R   $��137,280,0,0q�6m   $	��Top=�6�   $��75��6�   ��6   �� *PrintToFileButtonCommand+6�   �� 5*   
   $`��ZИзберете автомобил и принтирайте данните за него��6   $
��Left=�6K   $	��Top=�6f   $
��Bold"�6~   5+      5,      
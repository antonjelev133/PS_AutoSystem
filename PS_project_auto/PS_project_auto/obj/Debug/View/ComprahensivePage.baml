   M S B A M L   `   `   `  ����J  FPS_project_auto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PS_project_auto.ModelViewPS_project_auto.ModelView  5      ,    &PS_project_auto.View.ComprahensivePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =	ViewModel'clr-namespace:PS_project_auto.ModelView     5        N� Title$  ComprahensivePage��5	      $��390.226��6   .��5      � $��10,0,0,0q�6   .+�5   
   �� $.��(Застрахователна цена:��6   $
��Left=�60   $��
214,62,0,0q�6K   $	��Top=�6_   �� 5   
   $/��)Дата на застраховката:��6   $
��Left=�61   $��214,121,0,0q�6L   $	��Top=�6a   �� 5   
   $��Крайна цена:��6   $
��Left=�6'   $��214,180,0,0q�6B   $	��Top=�6W   $��26��6o   �� 5   
   $
��Left=�63   $��23��6N   $��
214,93,0,0q�6Z    �� TextWrapping$
 Wrap=�6n   $	��Top=�6�   $	��135��6�   ��6   �� *InsurancePrice+6�   �� 5   
   $
��Left=�62   $��23��6M   $��214,152,0,0q�6Y   $
 Wrap=�6n   $	��Top=�6�   $	��135��6�   ��6   �� *InsuranceDate+6�   �� 5   
   $
��Left=�6=   $��23��6X   $��214,211,0,0q�6d   $
 Wrap=�6y   $	��Top=�6�   $	��135��6�   ��6   �� *
FinalPrice+ �� Mode$ TwoWay=�6�   �� 5   
   $��Автокаско��6   $
��Left=�6$   $��
222,17,0,0q�6?   $	��Top=�6S   �� 5   
   $��Застраховай��6<   $
��Left=�6R   $��249,257,0,0q�6m   $	��Top=�6�   $��75��6�   ��6   �� *InsuranceButtonCommand+6�   �� 5   
   $��10,17,192,23q�6U   ��6   �� *cars+ �� SelectedItem 60   �� *SelectedCar+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $ Vertical=�6%   .+�5      �� $��Car: ��6(   �� 5      $
��Bold"�6>   ��6(   �� *MARK+6>   �� 5      $�� ��6(   �� 5      $ Vertical=�6)   .+�5      �� $��Registration: ��6(   �� 5      $
��Bold"�6F   ��6(   �� *REGISTRATION+6F   5      5       5!      5"      5$      5&      5'      
   M S B A M L   `   `   `  ����[  WTFG_AIK_OscarJoseAbeldaFernandez, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Controls)TFG_AIK_OscarJoseAbeldaFernandez.Controls  5      =    7TFG_AIK_OscarJoseAbeldaFernandez.Controls.WelcomeWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5      <d2http://schemas.microsoft.com/expression/blend/2008   5      Ac7clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Controls   5      .��5      � .+�5   
   � -   5        $��OverlayGrid��5         OpacityBackgroundBrush#��[  6"   $y�Hidden=�6W   '  !System.Windows.VisualStateManager    VisualStateGroups  5      %  System.Windows.VisualStateGroup  5      -   5        TransitionStates��   States. 5         System.Windows.VisualState  -   5        
Normal��5   "     5      -   5        
FadeIn��   
Storyboard. 5      �� .��5      W�  W� From$ 0X�6.   	 W� To$ 1X�67    �� TargetProperty$ Opacity�6>    g� Duration$ 0:0:0.5D�6b   6w   T� 5      $ 
Visibility�6<   ..�5   "   i�  R� KeyTime$ 0:0:0��69    R� Value 5   &     System.Windows.Visibility 5   *   Visible=�6>   5   #   5      5      5        5      -   5        FadeOut��. 5      �� .��5      W� $ 1X�6.   $ 0X�67   $ Opacity�6>   $ 0:0:0.5D�6b   6w   T� 5       $ 
Visibility�6<   ..�5!   "   i� $ 0:0:0.5��69    5"   &    5#   *   
Hidden=�6=   5%   #   5&      5'      5(      5)      .+�5,      (� $
��1280��6   $
��1024��6'   $��60 60 60 60q�67   $��Center=�6L   $��Center=�6i   .��5-      � .+�5.      �� $��3q�6   
�������  	BlueBrush#��[ 6E   � 50      	 � ColumnDefinitions	 51      �� 52      $��* �6/   �� 53      $��* �6/   �� 54      $��* �6/   .+�57      � $��0��6   $��2��6/   .+�58      �� -   5        $
��Box1��58   $   $��Bocadillo.png��60   $��Stretch=�6G   $��Stretch=�6c   $
��Fill=�6�   �� 59      -   5        $
��Text��59   (   $��Center=�64   $��Center=�6Q   $��30(�6l   $��	0 0 0 -20q�6z   $
��Wrap=�6�   $	��600��6�   5:      � 5;      $��2��6   
 � RowDefinitions
 5<      �� 5=   "   $��* �60   �� 5>   "   $
��Auto �60   �� 5?   "   $
��Auto �60   .+�5B      �� 8   2TFG_AIK_OscarJoseAbeldaFernandez.Controls.GifImage   AnimatedSource$ NinaHablando.gif��6$   �� 5C      $��1��6(     ChooseLevel#���  65   
�������$��20(�6m   � 5D      $��2��6#   	 5E   "   �� 5F   &   $��* �67   �� 5G   &   $��* �67   �� 5H   &   $��* �67   .+�5K   "   8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -   5        $��0��5K   7     PromptMenu_Resume#��[ 6G   $��80��6�   $	��150��6�     Easy#���  6�     5L   "   -	   5        $��1��5L   7   #��[ 6G   $��80��6�   $	��150��6�    
 Medium#���  6�     5M   "   -
   5        $��2��5M   7   #��[ 6G   $��80��6�   $	��150��6�     Hard#���  6�   5O      5P      5R      5T      5U      5V      5X      5Y      
   M S B A M L   `   `   `  ����[  WTFG_AIK_OscarJoseAbeldaFernandez, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Styles'TFG_AIK_OscarJoseAbeldaFernandez.Styles  5   	   e7clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Controls)TFG_AIK_OscarJoseAbeldaFernandez.Controls  5   	   1    +TFG_AIK_OscarJoseAbeldaFernandez.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   5   	   ?s5clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Styles   5   	   Ac7clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Controls   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5      <d2http://schemas.microsoft.com/expression/blend/2008   5      -   5        $��TFGMainWindow��5   	      HeaderTitle  � Title#  �   5   	    � Icon$ Styles\Kinect.ico��5   	   $
��1280��5   	   $	��768��6    � WindowState$ 	Maximized=�6)    � WindowStyle$
 None=�6A    � Cursor$
 None��5   	   $��Segoe UI)�6   ��5      �� 5   
    �� ImageSource$E ?Resources/280859-fondos-de-pantalla-y-escritorio-abstractos.jpg��6    j� Stretch$
 None=�6c   .��5      � .+�5   
   4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion  -   5          Name$ kinectRegion��5         KinectSensor 6/   �� *KinectSensorChooser.Kinect+.��5      � -   5        $��KinectRegionGrid��5      .+�5      � -   5        $��ContentGrid��5      .+�5      � 	 � RowDefinitions	 5      �� 5      $
��Auto �6,   �� 5      $��* �6,   .+�5"      � $��0��6   $��
10 0 10 20q�6-   .+�5#      8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  $	��100��6r   $��Center=�6   $	��Top=�6�   
   PrimaryUserColor$
 	#FFD6D600��6�      DefaultUserColor$ 	#FFACB05B��6�      KinectRegion 61   ��  �� ElementName$ kinectRegion��6�   4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  5$      -   5        $��sensorChooserUI��5$   k   $��Center=�66   $	��Top=�6S   6k   :  4Microsoft.Kinect.Toolkit.Controls.KinectCircleButton  5%      -   5          CancelButtonStyle#��[ 5%   3   $	��100��6^   $	��100��6k   $	��Top=�6w   $��Right=�6�     OrangeGradientBrush   ContentForeground# [ 6�   #��[ 6�      ContentPressedForeground 6-  Z� �� 5&      -   5        $��	TitleLogo��5&   $   $	��Top=�65   $��Center=�6M   $��Resources/Titulo.png��6j   $��UniformToFill=�6�   $	��620��6�   $��0 40 0 0q�6�   � 5'      $��Center=�6(   $
��Left=�6C    � Orientation$ 
Horizontal=�6^   .+�5(   "   8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -   5        $	��100��5(   z   $	��100��6�   ��65   Z� ��6L   Z� ��5)   &   �� 5*   *   $ Resources/ingles.png��65   5,   #     5-   "   -	   5        $	��100��5-   z   $	��100��6�   $
��Left=�6�   ��65   Z� ��6L   Z� ��5.   &   �� 5/   *   $ Resources/español.png��65   51   #   52      54      � 57      $��10,20,10,20q�6   $��1��64    � ColumnDefinitions 58      �� 59   "   $	��100 �63   �� 5:   "   $
��Auto �63   �� 5;   "   $��* �63   .+�5?      � $��0��6#   $��Stretch=�63   $��Stretch=�6Q   $��10, 0, 10, 0q�6m   $y�Hidden=�6�   	 5@   "   �� 5A   &   $��* �64   �� 5B   &   $��10 �64   �� 5C   &   $��* �64   .+�5E   "   ?  9TFG_AIK_OscarJoseAbeldaFernandez.Styles.KinectHoverButton  ?   9TFG_AIK_OscarJoseAbeldaFernandez.Styles.KinectHoverButton   Click$ ScrollUpButtonClick��6{   $��0��66    " KinectHoverButtonScrollUpStyle#��[ 6C   {�6�   �� $ TFGMainWindow�� �� Path$ ScrollUpEnabled�  5F   "   $ ScrollDownButtonClick��6}   $��2��66    $  KinectHoverButtonScrollDownStyle#��[ 6C   {�6�   �� $ TFGMainWindow��$ ScrollDownEnabled�5G      :  4Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer  5J      -
   5        $#��experienceButtonsScrollViewer��5J   W   $��0��63   $��3��6C   $��Hidden=�6|   $��Disabled=�6�   $��
25 0 25 25q�6�   .��5K   "   � -   5         �Name$  experienceButtonsWrapPanel��5K   d   $��Center=�6,   $��Center=�6G   $ Vertical=�6�   .+�5M   &     $��1��69     MainMenuKinectTileButton#��[ 6E     5N   &   $��2��69   #��[ 6E     5O   &   $��3��69   #��[ 6E     5P   &   $��4��69   #��[ 6E   5Q   #   5R      � 5U      $��2��6#   $��Stretch=�63   $��Stretch=�6Q   $��10, 10, 10, 10q�6m   	 5V   "   �� 5W   &   $��* �64   �� 5X   &   $��10 �64   �� 5Y   &   $��* �64   .+�5[   "   �� $��0��6)   $��3��66   $��5q�6G   
������� J� Opacity$
 0.75Q�6o   $��Stretch=�6~   $��Stretch=�6�   $y�Hidden=�6�   ._�5\   &   �� -   5        $��ContentImage��5\   -   $$��JustForTestingSources\Logo.png��6A   5]   #   �� 5^   "   -   5        $��ContentDescription��5^   M   $y�Hidden=�6,   $��2��6@   $��Texto de prueba��6g   $��50(�6~   $��Segoe UI)�6�   $��Regular"�6�    �� TextAlignment$ Justify=�6�   $
��Wrap=�6�   ���#989898��5_   &   �� 5`   *    �� Color$ DarkGray��6:    �� Opacity$	 0.5Q�6K   6[   5b   #   5c      5d      5e      � 5f      -   5        $��HelpGrid��5f      ���	#FF091006$y�Hidden=�6B   '	  !System.Windows.VisualStateManager 	  VisualStateGroups 5g      %
  System.Windows.VisualStateGroup
  5h      -   5        TransitionStates�� 
  States. 5i   "      System.Windows.VisualState  -   5        
Normal��5i   .     5j   "   -   5        
FadeIn��   
Storyboard. 5k   &   �� .��5l   *   W�  W� From$ 0X�6:   	 W� To$ 1X�6C    �� TargetProperty$ Opacity�6J    g� Duration$ 0:0:0.5D�6n   6�   T� 5m   *   $ 
Visibility�6H   ..�5n   .   i�   R� KeyTime$  0:0:0��6E   ! R� Value! 5o   2     System.Windows.Visibility 5p   6   Visible=�6J   5r   /   5s   +   5t   '   5u   #     5v   "   -   5        FadeOut��. 5w   &   �� .��5x   *   W� $ 1X�6:   $ 0X�6C   $ Opacity�6J   $ 0:0:0.5D�6n   6�   T� 5y   *   $ 
Visibility�6H   ..�5z   .   i� $  0:0:0.5��6E   ! 5{   2    5|   6   
Hidden=�6I   5~   /   5   +   5�   '   5�   #   5�      	 5�      �� 5�      $��* �6,   �� 5�      $��5 �6,   �� 5�      $��* �6,    5�      �� 5�      �� 5�      $
��Auto �6/   �� 5�      $��5 �6/   �� 5�      $
��Auto �6/   �� 5�      .+�5�      � $��2��6   $��3��6/   
�������6@   � 5�      $��1��6   $��5��6,   
�������6@   �� 5�      $��0��6$   $��0��64     InteractionHelp#���  6A   $��25(�6j   $��Center=�6x   $��Center=�6�   $��10 10 10 10q�6�   $
��Wrap=�6�   
�������6�   �� 5�      $��0��6$   $��2��64     PointingHelp#���  6A   $��25(�6g   $��Center=�6u   $��Center=�6�   $��10 10 10 10q�6�   $
��Wrap=�6�   
�������6�   �� 5�      $��4��6$   $��0��64     	PressHelp#���  6A   $��25(�6d   $��Center=�6r   $��Center=�6�   $��10 10 10 10q�6�   $
��Wrap=�6�   
�������6�   �� 5�      $��4��6$   $��2��64    	 GripHelp#��� 	 6A   $��25(�6c   $��Center=�6q   $��Center=�6�   $��10 10 10 10q�6�   $
��Wrap=�6�   
�������6�   �� 5�      $��3��6    $��0��60   8   2TFG_AIK_OscarJoseAbeldaFernandez.Controls.GifImage"   AnimatedSource$+" %Resources/Help/PressKinectGesture.gif��6>   $	��300��6�   �� 5�      $��1��6    $��2��60   $." (Resources/Help/PointingKinectGesture.gif��6>   $	��300��6�   �� 5�      $��1��6    $��0��60   $." (Resources/Help/InteractKinectGesture.gif��6>   $	��300��6�   �� 5�      $��3��6    $��2��60   $*" $Resources/Help/GripKinectGesture.gif��6>   $	��300��6   5�        5�      -   5        $	��100��5�   V   $	��100��6c   $��Bottom=�6o   $��Right=�6�   $��	0 0 30 30q�6�   ��6)   Z� ��6@   Z� ��5�      �� 5�      $* $Resources/Help/icono-informacion.png��6)   5�      5�      � 5�      -   5        $��
OnExitGrid��5�       
 OpacityBackgroundBrush#��[
 6)   $y�Hidden=�6^   	 5�      �� 5�      $��* �6(   �� 5�      $��* �6(    5�      �� 5�      �� 5�      .+�5�      �� $��2��6    $��0��64     OnClosingMessage#���  6A   $��50(�6k   $��Center=�6y   $��Bottom=�6�   $��10 10 10 10q�6�   $
��Wrap=�6�   
�������6�     5�      -   5        $��0��5�   )   $��1��69   $
��Auto��6F   $
��Auto��6T   $��60 60 60 60q�6a     Yes#���  6v   $��75(�6�   
����������	#FF3A9743$	��150��6�   $	��250��6�   $��Right=�6  $	��Top=�6#    5�      -   5        $��1��5�   )   $��1��69   $
��Auto��6G   $
��Auto��6U   $��60 60 60 60q�6b     No#���  6w   $��75(�6�   
����������	#FFB64F4F$	��150��6�   $	��250��6�   $
��Left=�6  $	��Top=�6"  5�      5�      5�      5�      5�      
   M S B A M L   `   `   `  ����[  WTFG_AIK_OscarJoseAbeldaFernandez, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Controls)TFG_AIK_OscarJoseAbeldaFernandez.Controls  5      M    GTFG_AIK_OscarJoseAbeldaFernandez.Content.Experiences.TypeIdentification   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   5      Ac7clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Controls   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5      <d2http://schemas.microsoft.com/expression/blend/2008   5      $��Segoe UI)�5
      $��30(�5        � 	Resources  5         LoadStoryboard �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  UnloadStoryboard R� KeyTime  System.Windows.Visibility   Hidden R� Value��%G  &	        &	 �    �� 5   
   .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $
 grid��6�   .\�5        $ 0��6'   $	 0.1Q�63     5      $ 0:0:0.3��6'   $ 1Q�69   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $
 grid��6�   .\�5        $ 0��6'   $	 0.1Q�63     5      $ 0:0:0.3��6'   $ 1Q�69   5      5      �� 5   
   -   5        .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $
 grid��6�   .\�5        $ 0��6'   $ 1Q�63     5      $ 0:0:0.2��6'   $	 0.1Q�69   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $
 grid��6�   .\�5        $ 0��6'   $ 1Q�63     5      $ 0:0:0.2��6'   $	 0.1Q�69   5       T� 5!      $ (UIElement.Visibility)�6,   $
 grid��6_   ..�5"      i� $ 0:0:0.2��6)   # Z 6;   5#      5$      5%       � Triggers 5&      :� 5'   
   	 :� RoutedEvent$	 FrameworkElement.Loaded��6   .[�5(      �� -   5        
 ��Name$(
 "OnLoadedStoryboard_BeginStoryboard��5(      #��[  6J   5)      .��5,      � -   5         �Name$
 grid��5,       J� RenderTransformOrigin$ 0.5,0.5&�6   ���	#FF126FB0z�5-   
   V� 5.      .~�5/      �� �� 50      �� 51      T� 52      53      .+�55   
   � -   5        $��
DesingGrid��55       � ColumnDefinitions 56      �� 57      $��* �6#   $	��250��6-   �� 58      $��* �6#   �� 59      $��* �6#   $	��250��6-    � RowDefinitions 5;      �� 5<      �� 5=      .+�5?      � $��0��6   $��0��6#   $��20 20 20 20q�60   $	��400��6E   $	��400��6U   $��Stretch=�6d   $��Stretch=�6�   .+�5@      �� -   5        $
��Box1��5@      $-��'../TypeIdentification_Resources/Box.png��6$   $��Center=�6U   
 � Tag$ Integer��6p   �� 5A      $��Center=�6   $��Bottom=�69   $��60(�6T   $��	0 0 0 -20q�6b   	Integer6~   5B      � 5C      $��0��6   $��1��6#   $��20 20 20 20q�60   $	��400��6E   $	��400��6U   $��Stretch=�6d   $��Stretch=�6�   .+�5D      �� -   5        $
��Box2��5D      $-��'../TypeIdentification_Resources/Box.png��6$   $��Center=�6U   $ Float��6p   �� 5E      $��Center=�6   $��Bottom=�69   $��60(�6T   $��	0 0 0 -20q�6b   Float6|   5F      � 5G      $��2��6   $��0��6#   $��20 20 20 20q�60   $	��400��6E   $	��400��6U   $��Stretch=�6d   $��Stretch=�6�   .+�5H      �� -   5        $
��Box3��5H      $-��'../TypeIdentification_Resources/Box.png��6$   $��Center=�6U   $ String��6p   �� 5I      $��Center=�6   $��Bottom=�69   $��60(�6T   $��	0 0 0 -20q�6b   String6}   5J      � 5K      $��2��6   $��1��6#   $��20 20 20 20q�60   $	��400��6E   $	��400��6U   $��Stretch=�6d   $��Stretch=�6�   .+�5L      �� -   5        $
��Box4��5L      $-��'../TypeIdentification_Resources/Box.png��6$   $��Center=�6U   $ Boolean��6p   �� 5M      $��Center=�6   $��Bottom=�69   $��60(�6T   $��	0 0 0 -20q�6b   	Boolean6~   5N      �� 5O      -	   5        $��	SpawnZone��5O   5   $��1��6   $��2��6$   $:��4..\TypeIdentification_Resources\motherboard-wide.jpg��6F   $��UniformToFill=�6�   $��Stretch=�6�   $��Center=�6�   5P      � 5Q   
   -
   5        $��HandPointerGrid��5Q      5T      � 5U   
   -   5        $��LifeGrid��5U      $��Center=�6   $��Bottom=�6<   $��10 10 10 20q�6W   .+�5V      � -   5        $��	LifePanel��5V      $��75��6*   .+�5X      �� $.��(../TypeIdentification_Resources/Life.png��6   �� 5Y      $.��(../TypeIdentification_Resources/Life.png��6   �� 5Z      $.��(../TypeIdentification_Resources/Life.png��6   �� 5[      $.��(../TypeIdentification_Resources/Life.png��6   5\      5]      �� 5^   
   -   5        $��
ScoreLabel��5^      $��
0000000000��6&   $��10 20 10 10q�68   $��Center=�6M   $	��Top=�6j   $	��100(�6�   $
��Bold"�6�   $��Tempus Sans ITC)�6�   ��5_      �� 5`       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5a      �  � Color$ 	#FFFF7502��6#    � Offset$ 0Q�65   � 5b      $ 	#FFF5DF00��6#   $ 1Q�65   5c      5e      :   4TFG_AIK_OscarJoseAbeldaFernandez.Controls.PromptMenu  5f   
   -   5          Name$ 
PromptMenu��5f      =   7TFG_AIK_OscarJoseAbeldaFernandez.Controls.WelcomeWindow  5g   
   -   5          Name$ WelcomeMenu��5g      � 5h   
   -   5        $��	ScoreView��5h        OpacityBackgroundBrush#��[ 6    $y�Hidden=�6U   '  !System.Windows.VisualStateManager   VisualStateGroups 5i      %  System.Windows.VisualStateGroup  5j      -   5        TransitionStates��   States. 5k         System.Windows.VisualState  -   5        
Normal��5k   "     5l      -   5        
FadeIn��   
Storyboard. 5m      �� .��5n      W�  W� From$ 0X�6.   	 W� To$ 1X�67   $ Opacity�6>    g� Duration$ 0:0:0.5D�6b   6w   T� 5o      $ 
Visibility�6<   ..�5p   "   i� $ 0:0:0��69    5q   &    5r   *   Visible=�6>   5t   #   5u      5v      5w        5x      -   5        FadeOut��. 5y      �� .��5z      W� $ 1X�6.   $ 0X�67   $ Opacity�6>   $ 0:0:0.5D�6b   6w   T� 5{      $ 
Visibility�6<   ..�5|   "   i� $ 0:0:0.5��69    5}   &    5~   *   
Hidden=�6=   5�   #   5�      5�      5�      5�      .+�5�      �� $��5q�6   
���   �$��60 60 60 60q�6=   $	��600��6R   $
��1000��6b   ._�5�      �   BackgroundGradientBrush#��[ 6    5�      �� 5�      $
��Auto �6(   �� 5�      $��* �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   .+�5�      �� $��0��6      Archivements#���  6-   $��	10 5 10 1q�6S   $��50(�6f   �� 5�      $��1��6   $��2q�6*   
���   �$��	10 1 10 1q�6R   ._�5�      �� -   5        $��ScoreArchivementsText��5�   $   $��
Operations��6A    �� TextAlignment$ Justify=�6S   $
��Wrap=�6k   ���#989898$��
10 10 10 0q�6�   $��25(�6�   5�      �� 5�      $��2��6      
FinalScore#���  6-   $��	10 5 10 1q�6Q   $��50(�6e   �� 5�      $��3��6   $��2q�6*   
���   �$��	10 1 10 5q�6R   ._�5�      �� -   5        $��FinalScoreText��5�   $   $��1000000��6:   $ Center=�6I   $��Center=�6`   $
��Wrap=�6{   ���#989898$��
10 10 10 0q�6�   $
��Bold"�6�   $��ExtraExpanded&�6�   $��75(�6�   5�      � 5�      $��4��6    5�      �� 5�      �� 5�      .+�5�      8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -   5        $��0��5�   -     PromptMenu_BackToMenu#��[ 6=   $��Center=�6l   $��Center=�6�   $��70��6�     
BackToMenu#���  6�     5�      -   5        $��1��5�   -   #��[ 6=   $��Center=�6l   $��Center=�6�   $��70��6�    
 Replay#���  6�   5�      5�      5�      5�      5�      5�      
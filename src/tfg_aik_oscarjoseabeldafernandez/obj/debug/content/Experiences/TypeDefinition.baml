   M S B A M L   `   `   `  ����[  WTFG_AIK_OscarJoseAbeldaFernandez, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Controls)TFG_AIK_OscarJoseAbeldaFernandez.Controls  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5      I    CTFG_AIK_OscarJoseAbeldaFernandez.Content.Experiences.TypeDefinition   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   5      Ac7clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Controls   5      ?coll2clr-namespace:System.Collections;assembly=mscorlib   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5      <d2http://schemas.microsoft.com/expression/blend/2008   5      $��Segoe UI)�5      $��30(�5        � 	Resources  5         LoadStoryboard �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  UnloadStoryboard R� KeyTime  System.Windows.Visibility   Hidden R� Value��%G  &	        &	 �    �� 5   
   .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $
 grid��6�   .\�5        $ 0��6'   $	 0.1Q�63     5      $ 0:0:0.3��6'   $ 1Q�69   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $
 grid��6�   .\�5        $ 0��6'   $	 0.1Q�63     5      $ 0:0:0.3��6'   $ 1Q�69   5      5      �� 5   
   -   5        .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $
 grid��6�   .\�5        $ 0��6'   $ 1Q�63     5      $ 0:0:0.2��6'   $	 0.1Q�69   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $
 grid��6�   .\�5         $ 0��6'   $ 1Q�63     5!      $ 0:0:0.2��6'   $	 0.1Q�69   5"      T� 5#      $ (UIElement.Visibility)�6,   $
 grid��6_   ..�5$      i� $ 0:0:0.2��6)   # Z 6;   5%      5&      5'       � Triggers 5(      :� 5)   
   	 :� RoutedEvent$	 FrameworkElement.Loaded��6   .[�5*      �� -   5        
 ��Name$(
 "OnLoadedStoryboard_BeginStoryboard��5*      #��[  6J   5+      .��5.      � -   5         �Name$
 grid��5.       J� RenderTransformOrigin$ 0.5,0.5&�6   ��5/   
   �� 50       �� ImageSource$X R/TFG_AIK_OscarJoseAbeldaFernandez;component/Resources/fondos-de-pantalla-hd-3d.jpg��6   z�52   
   V� 53      .~�54      �� �� 55      �� 56      T� 57      58      .+�5:   
   �  � ColumnDefinitions 5;      �� 5<      $
��Auto �6#   �� 5=      $��* �6#   .+�5@      � -   5        $��
MemoryGrid��5@      $��0��6%   $	��500��65   $
��1280��6D   $��Right=�6U   $��Center=�6q   $��20 0 0 0q�6�    � RowDefinitions 5A      �� 5B      $
��Auto �6$   �� 5C      $��* �6$   .+�5F      �� $��0��6    �� TextAlignment$ Center=�6)   $
��Auto��6@   $��40(�6N   
������� 
 Memory#���  6o   �� 5G      $��1��6   
�������$��10q�6:   $��Center=�6O   $��Center=�6l   ._�5H      � -   5         �Name$ MemoryPanel��5H       $��5 5 5 5q�6X    � Orientation$ Vertical=�6i   .+�5J      8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton    MemoryCellTileButton#��[ 6-     5K      #��[ 6-     5L      #��[ 6-     5M      #��[ 6-     5N      #��[ 6-     5O      #��[ 6-     5P      #��[ 6-     5Q      #��[ 6-   5R      5S      5T      � 5V      -   5        $��QuestionsGrid��5V      $��1��6(   $��60 60 225 60q�68   
������� J� Opacity$
 0.75Q�6a    5X      �� 5Y      �� 5Z      �� 5[      �� 5\      �� 5]      .+�5`      � -   5        $��PrevQuestionsGrid��5`      $��0��60   $��60 0 0 0q�6=   $��Center=�6O   $
��Left=�6j    5a      �� 5b      �� 5c      .+�5e      �� $��0��6    
�������Texto meramente de prueba6[   �� 5f      $��1��6    
�������Texto meramente de prueba6[   �� 5g      $��2��6   $.��(../TypeDefinition_Resources/Red_tick.png��6-   $��80��6_   $��
 350 0 0 0q�6k   5h      � 5i      -   5        $��ActualQuestionsGrid��5i      $��1��62   $��60 0 0 0q�6?   $��Center=�6Q   $
��Left=�6l    5j      �� 5k      �� 5l      .+�5o      �� $��0��6    Texto meramente de prueba6H   �� 5p      $��1��6    Texto meramente de prueba6H   �� 5q      $��2��6   $0��*../TypeDefinition_Resources/Green_tick.png��6-   $��80��6a   $��
 350 0 0 0q�6m   5r      � 5s      -	   5        $��NextQuestionsGrid��5s      $��2��60   $��60 0 0 0q�6=   $��Center=�6O   $
��Left=�6j    5t      �� 5u      �� 5v      .+�5x      �� $��0��6    Texto meramente de prueba6H   �� 5y      $��1��6    Texto meramente de prueba6H   5z      5|      � 5}      -
   5        $��ConfirmGrid��5}      $��0��6&   $��Bottom=�66   $
��Left=�6Q   .+�5~      :  4Microsoft.Kinect.Toolkit.Controls.KinectCircleButton  -   5          OkButtonStyle#��[ 5~   '   6N   5      5�      �� 5�   
   -   5        $��TimeCounter��5�      $��0:0.0��6'   $��10 20 10 10q�64   $��Center=�6I   $	��Top=�6f   $��50(�6~     OrangeGradientBrush#��[ 6�   :   4TFG_AIK_OscarJoseAbeldaFernandez.Controls.PromptMenu  5�   
   -   5          Name$ 
PromptMenu��5�      =   7TFG_AIK_OscarJoseAbeldaFernandez.Controls.WelcomeWindow  5�   
   -   5          Name$ WelcomeMenu��5�      � 5�   
   -   5        $��	ScoreView��5�        OpacityBackgroundBrush#��[ 6    $y�Hidden=�6U   '  !System.Windows.VisualStateManager   VisualStateGroups 5�      %  System.Windows.VisualStateGroup  5�      -   5        TransitionStates��   States. 5�       	  System.Windows.VisualState	  -   5        
Normal��5�   "   	  5�      -   5        
FadeIn�� 	  
Storyboard. 5�      �� .��5�      W�  W� From$ 0X�6.   	 W� To$ 1X�67   $ Opacity�6>    g� Duration$ 0:0:0.5D�6b   6w   T� 5�      $ 
Visibility�6<   ..�5�   "   i� $ 0:0:0��69    5�   &    5�   *   Visible=�6>   5�   #   5�      5�      5�      	  5�      -   5        FadeOut��. 5�      �� .��5�      W� $ 1X�6.   $ 0X�67   $ Opacity�6>   $ 0:0:0.5D�6b   6w   T� 5�      $ 
Visibility�6<   ..�5�   "   i� $ 0:0:0.5��69    5�   &    5�   *   
Hidden=�6=   5�   #   5�      5�      5�      5�      .+�5�      �� $��5q�6   
���   �$��60 60 60 60q�6=   $	��600��6R   $
��1000��6b   ._�5�      �   BackgroundGradientBrush#��[ 6    5�      �� 5�      $
��Auto �6(   �� 5�      $��* �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   .+�5�      �� $��0��6      Archivements#���  6-   $��	10 5 10 1q�6S   $��50(�6f   �� 5�      $��1��6   $��2q�6*   
���   �$��	10 1 10 1q�6R   ._�5�      �� -   5        $��ScoreArchivementsText��5�   $   $��
Operations��6A   $ Justify=�6S   $
��Wrap=�6k   ���#989898$��
10 10 10 0q�6�   $��25(�6�   5�      �� 5�      $��2��6     	 
FinalScore#��� 	 6-   $��	10 5 10 1q�6Q   $��50(�6e   �� 5�      $��3��6   $��2q�6*   
���   �$��	10 1 10 5q�6R   ._�5�      �� -   5        $��ScoreFinalTimeText��5�   $   $��1000000��6>   $ Center=�6M   $��Center=�6d   $
��Wrap=�6   ���#989898$��
10 10 10 0q�6�   $
��Bold"�6�   $��ExtraExpanded&�6�   $��75(�6�   5�      � 5�      $��4��6    5�      �� 5�      �� 5�      .+�5�        -   5        $��0��5�   -    
 PromptMenu_BackToMenu#��[
 6=   $��Center=�6l   $��Center=�6�   $��70��6�     
BackToMenu#���  6�     5�      -   5        $��1��5�   -   #��[
 6=   $��Center=�6l   $��Center=�6�   $��70��6�    
 Replay#���  6�   5�      5�      5�      5�      5�      5�      
   M S B A M L   `   `   `  ���� [  WTFG_AIK_OscarJoseAbeldaFernandez, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Controls)TFG_AIK_OscarJoseAbeldaFernandez.Controls  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections H    BTFG_AIK_OscarJoseAbeldaFernandez.Content.Experiences.BinaryConvert   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   Ac7clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Controls   ?coll2clr-namespace:System.Collections;assembly=mscorlib   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   <d2http://schemas.microsoft.com/expression/blend/2008   $��Segoe UI)�$��30(�  � 	Resources     LoadStoryboard �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  UnloadStoryboard R� KeyTime  System.Windows.Visibility   Hidden R� Value��%�  &	        &	 @    �� .��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$
 grid��.\�  $ 0��$	 0.1Q�  $ 0:0:0.3��$ 1Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$
 grid��.\�  $ 0��$	 0.1Q�  $ 0:0:0.3��$ 1Q��� -   .��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$
 grid��.\�  $ 0��$ 1Q�  $ 0:0:0.2��$	 0.1Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$
 grid��.\�  $ 0��$ 1Q�  $ 0:0:0.2��$	 0.1Q�T� $ (UIElement.Visibility)�$
 grid��..�i� $ 0:0:0.2��# Z  � Triggers :� 	 :� RoutedEvent$	 FrameworkElement.Loaded��.[��� -   
 ��Name$(
 "OnLoadedStoryboard_BeginStoryboard��#��[  .��� -    �Name$
 grid�� J� RenderTransformOrigin$ 0.5,0.5&�  BackgroundGradientBrush#��[ z�V� .~��� �� �� T� .+��  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+�� -   $��Header��$��0��$��Center=�$��Center=� �� �� .+��� -   $��questionShow��$��1��$	��200(�$
��Bold"�$��Tempus Sans ITC)�$��Bottom=�$��Center=�235����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFFF7502�� � Offset$ 0Q�� $ 	#FFF5DF00��$ 1Q��� -   $��TimeCounter��$��0��$��0:0.0��$��Center=�$	��Top=�$	��100(�$��	0 10 0 20q�� -   $��	SubHeader��$��2�� � ColumnDefinitions �� �� �� �� �� �� �� �� �� $
��Auto ��� $	��430��.+��� $��0��$��Bottom=�$��Right=�$��75(�$��10 10 70 20q�2�� $��0��$��Bottom=�$��Right=�$��50(�$��10 10 40 60q�7�� $��1��$��Bottom=�$��Right=�$��75(�$��10 10 70 20q�2�� $��1��$��Bottom=�$��Right=�$��50(�$��10 10 40 60q�6�� $��2��$��Bottom=�$��Right=�$��75(�$��10 10 70 20q�2�� $��2��$��Bottom=�$��Right=�$��50(�$��10 10 40 60q�5�� $��3��$��Bottom=�$��Right=�$��75(�$��10 10 70 20q�2�� $��3��$��Bottom=�$��Right=�$��50(�$��10 10 40 60q�4�� $��4��$��Bottom=�$��Right=�$��75(�$��10 10 70 20q�2�� $��4��$��Bottom=�$��Right=�$��50(�$��10 10 40 60q�3�� $��5��$��Bottom=�$��Right=�$��75(�$��10 10 70 20q�2�� $��5��$��Bottom=�$��Right=�$��50(�$��10 10 40 60q�2�� $��6��$��Bottom=�$��Right=�$��75(�$��10 10 70 20q�2�� $��6��$��Bottom=�$��Right=�$��50(�$��10 10 40 60q�1�� $��7��$��Bottom=�$��Right=�$��75(�$��10 10 70 20q�2�� $��7��$��Bottom=�$��Right=�$��50(�$��10 10 40 60q�0�� $��8��$��Bottom=�$��Right=�$	��100(�$��
20 0 20 10q�=�� $��1��
���   �$��1q�$��10 10 10 10q�._�� -   $��
AnswerGrid��.+�� -	   $��ConversionGrid��$��	30 0 30 0q�$��Center=� �� �� �� �� �� �� �� �� �� $
��Auto ��� $	��350��.+�8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -
   $��0��  BitCellTileButton#��[ $��0��  -   $��1��#��[ $��0��  -   $��2��#��[ $��0��  -   $��3��#��[ $��0��  -   $��4��#��[ $��0��  -   $��5��#��[ $��0��  -   $��6��#��[ $��0��  -   $��7��#��[ $��0���� $��8��$��1��$��
20 0 20 10q�$��Center=�$��Center=�$	��100(�=  -   $��conversionSolution��$��9��  AnswerCellTileButton#��[ $	��000��:   4TFG_AIK_OscarJoseAbeldaFernandez.Controls.PromptMenu  -     Name$ 
PromptMenu��� -   $��	ScoreView��  OpacityBackgroundBrush#��[ $y�Hidden=�'  !System.Windows.VisualStateManager   VisualStateGroups %  System.Windows.VisualStateGroup  -   TransitionStates��   States.    System.Windows.VisualState  -   
Normal��  -   
FadeIn��   
Storyboard. �� .��W�  W� From$ 0X�	 W� To$ 1X�$ Opacity� g� Duration$ 0:0:0.5D�T� $ 
Visibility�..�i� $ 0:0:0��  Visible=�  -   FadeOut��. �� .��W� $ 1X�$ 0X�$ Opacity�$ 0:0:0.5D�T� $ 
Visibility�..�i� $ 0:0:0.5��  
Hidden=�.+��� $��5q�
���   �$��60 60 60 60q�._�� #��[  �� $
��Auto ��� $��* ��� $
��Auto ��� $��* ��� $��* �.+��� $��0��$��Archivements:��$��	10 5 10 1q�$	��100(��� $��1��$��2q�
���   �$��	10 1 10 1q�._��� -   $��ScoreArchivementsText��$��
Operations�� �� TextAlignment$ Justify=�$
��Wrap=����#989898$��
10 10 10 0q��� $��2��$��Final Score:��$��	10 5 10 1q�$	��100(��� $��3��$��2q�
���   �$��	10 1 10 5q�._��� -   $��ScoreFinalTimeText��$��1000000��$ Center=�$��Center=�$
��Wrap=����#989898$��
10 10 10 0q�$
��Bold"�$��ExtraExpanded&�$	��100(�� $��4�� �� �� .+�:  4Microsoft.Kinect.Toolkit.Controls.KinectCircleButton  -   $��0��  BackButtonStyle#��[ $��Center=�$��Center=�  -   $��1��  ReplayButtonStyle#��[ $��Center=�$��Center=�
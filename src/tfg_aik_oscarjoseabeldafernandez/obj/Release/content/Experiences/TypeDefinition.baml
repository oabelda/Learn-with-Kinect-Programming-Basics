   M S B A M L   `   `   `  ���� [  WTFG_AIK_OscarJoseAbeldaFernandez, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Controls)TFG_AIK_OscarJoseAbeldaFernandez.Controls  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections I    CTFG_AIK_OscarJoseAbeldaFernandez.Content.Experiences.TypeDefinition   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   Ac7clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Controls   ?coll2clr-namespace:System.Collections;assembly=mscorlib   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   <d2http://schemas.microsoft.com/expression/blend/2008   $��Segoe UI)�$��30(�  � 	Resources     LoadStoryboard �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  UnloadStoryboard R� KeyTime  System.Windows.Visibility   Hidden R� Value��%�  &	        &	 @    �� .��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$
 grid��.\�  $ 0��$	 0.1Q�  $ 0:0:0.3��$ 1Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$
 grid��.\�  $ 0��$	 0.1Q�  $ 0:0:0.3��$ 1Q��� -   .��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$
 grid��.\�  $ 0��$ 1Q�  $ 0:0:0.2��$	 0.1Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$
 grid��.\�  $ 0��$ 1Q�  $ 0:0:0.2��$	 0.1Q�T� $ (UIElement.Visibility)�$
 grid��..�i� $ 0:0:0.2��# Z  � Triggers :� 	 :� RoutedEvent$	 FrameworkElement.Loaded��.[��� -   
 ��Name$(
 "OnLoadedStoryboard_BeginStoryboard��#��[  .��� -    �Name$
 grid�� J� RenderTransformOrigin$ 0.5,0.5&�  BackgroundGradientBrush#��[ z�V� .~��� �� �� T� .+��  � ColumnDefinitions �� $��* ��� $��* �.+�� -   $��
MemoryGrid��$��0��$��20 20 20 20q�$	��900��$	��500��$��Stretch=�$��Stretch=� � RowDefinitions �� $
��Auto ��� $
��Auto �.+��� $��0�� �� TextAlignment$ Center=�$��0 5 0 0q�$
��Auto��$��75(�Memory�� $��1��
���   �$��10q�._�� -    �Name$ MemoryPanel��$��5 5 5 5q� � Orientation$ Vertical=�.+�8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton    MemoryCellTileButton#��[   #��[   #��[   #��[   #��[   #��[   #��[   #��[ � -   $��QuestionsGrid��$��1��$��60 60 225 60q� �� �� �� �� �� .+�� -   $��PrevQuestionsGrid��$��0��$��60 60 60 60q�$��Center=�$
��Left=� �� �� .+��� $��0��Texto meramente de prueba�� $��1��Texto meramente de prueba�� $��2��$.��(../TypeDefinition_Resources/Red_tick.png��$��80��$��
 350 0 0 0q�� -   $��ActualQuestionsGrid��$��1��$��60 0 0 0q�$��Center=�$
��Left=� �� �� .+��� $��0��Texto meramente de prueba�� $��1��Texto meramente de prueba�� $��2��$0��*../TypeDefinition_Resources/Green_tick.png��$��80��$��
 350 0 0 0q�� -	   $��NextQuestionsGrid��$��2��$��60 60 60 60q�$��Center=�$
��Left=� �� �� .+��� $��0��Texto meramente de prueba�� $��1��Texto meramente de prueba� -
   $��ConfirmGrid��$��0��$��Bottom=�$��Right=�.+�:  4Microsoft.Kinect.Toolkit.Controls.KinectCircleButton  -     OkButtonStyle#��[ �� -   $��TimeCounter��$��0:0.0��$��10 20 10 10q�$��Center=�$	��Top=�$��50(�:   4TFG_AIK_OscarJoseAbeldaFernandez.Controls.PromptMenu  -     Name$ 
PromptMenu��� -   $��	ScoreView��  OpacityBackgroundBrush#��[ $y�Hidden=�'  !System.Windows.VisualStateManager   VisualStateGroups %  System.Windows.VisualStateGroup  -   TransitionStates��   States.    System.Windows.VisualState  -   
Normal��  -   
FadeIn��   
Storyboard. �� .��W�  W� From$ 0X�	 W� To$ 1X�$ Opacity� g� Duration$ 0:0:0.5D�T� $ 
Visibility�..�i� $ 0:0:0��  Visible=�  -   FadeOut��. �� .��W� $ 1X�$ 0X�$ Opacity�$ 0:0:0.5D�T� $ 
Visibility�..�i� $ 0:0:0.5��  
Hidden=�.+��� $��5q�
���   �$��60 60 60 60q�._�� #��[  �� $
��Auto ��� $��* ��� $
��Auto ��� $��* ��� $��* �.+��� $��0��$��Archivements:��$��	10 5 10 1q�$	��100(��� $��1��$��2q�
���   �$��	10 1 10 1q�._��� -   $��ScoreArchivementsText��$��
Operations��$ Justify=�$
��Wrap=����#989898$��
10 10 10 0q��� $��2��$��Final Time Score:��$��	10 5 10 1q�$	��100(��� $��3��$��2q�
���   �$��	10 1 10 5q�._��� -   $��ScoreFinalTimeText��$��1000000��$ Center=�$��Center=�$
��Wrap=����#989898$��
10 10 10 0q�$
��Bold"�$��ExtraExpanded&�$	��100(�� $��4�� �� �� .+�  -   $��0��  BackButtonStyle#��[ $��Center=�$��Center=�  -   $��1��  ReplayButtonStyle#��[ $��Center=�$��Center=�
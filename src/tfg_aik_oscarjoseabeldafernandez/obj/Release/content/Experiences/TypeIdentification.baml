   M S B A M L   `   `   `  ���� [  WTFG_AIK_OscarJoseAbeldaFernandez, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Controls)TFG_AIK_OscarJoseAbeldaFernandez.Controls  M    GTFG_AIK_OscarJoseAbeldaFernandez.Content.Experiences.TypeIdentification   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   Ac7clr-namespace:TFG_AIK_OscarJoseAbeldaFernandez.Controls   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   <d2http://schemas.microsoft.com/expression/blend/2008   $��Segoe UI)�$��30(�  � 	Resources     LoadStoryboard �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  UnloadStoryboard R� KeyTime  System.Windows.Visibility   Hidden R� Value��%�  &	        &	 @    �� .��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$
 grid��.\�  $ 0��$	 0.1Q�  $ 0:0:0.3��$ 1Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$
 grid��.\�  $ 0��$	 0.1Q�  $ 0:0:0.3��$ 1Q��� -   .��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$
 grid��.\�  $ 0��$ 1Q�  $ 0:0:0.2��$	 0.1Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$
 grid��.\�  $ 0��$ 1Q�  $ 0:0:0.2��$	 0.1Q�T� $ (UIElement.Visibility)�$
 grid��..�i� $ 0:0:0.2��# Z  � Triggers :� 	 :� RoutedEvent$	 FrameworkElement.Loaded��.[��� -   
 ��Name$(
 "OnLoadedStoryboard_BeginStoryboard��#��[  .��� -    �Name$
 grid�� J� RenderTransformOrigin$ 0.5,0.5&�  BackgroundGradientBrush#��[ z�V� .~��� �� �� T� .+�� -   $��
DesingGrid�� � ColumnDefinitions �� $��* �$	��500���� $��* ��� $��* �$	��500�� � RowDefinitions �� �� .+�� $��0��$��0��$��20 20 20 20q�$	��400��$	��400��$��Stretch=�$��Stretch=�.+��� -   $
��Box1��$-��'../TypeIdentification_Resources/Box.png��$��Center=�
 � Tag$ Integer���� $��Center=�$��Bottom=�$��60(�$��	0 0 0 -20q�	Integer� $��0��$��1��$��20 20 20 20q�$	��400��$	��400��$��Stretch=�$��Stretch=�.+��� -   $
��Box2��$-��'../TypeIdentification_Resources/Box.png��$��Center=�$ Float���� $��Center=�$��Bottom=�$��60(�$��	0 0 0 -20q�Float� $��2��$��0��$��20 20 20 20q�$	��400��$	��400��$��Stretch=�$��Stretch=�.+��� -   $
��Box3��$-��'../TypeIdentification_Resources/Box.png��$��Center=�$ String���� $��Center=�$��Bottom=�$��60(�$��	0 0 0 -20q�String� $��2��$��1��$��20 20 20 20q�$	��400��$	��400��$��Stretch=�$��Stretch=�.+��� -   $
��Box4��$-��'../TypeIdentification_Resources/Box.png��$��Center=�$ Boolean���� $��Center=�$��Bottom=�$��60(�$��	0 0 0 -20q�	Boolean�� -	   $��	SpawnZone��$��1��$��2��$:��4..\TypeIdentification_Resources\motherboard-wide.jpg��$��UniformToFill=�$��Stretch=�$��Center=�� -
   $��HandPointerGrid��.+�� $��180,189,0,0q�$	��Top=�$
��Left=�.+�A� $	��150��$	��150��$��10��
���   �
�������� $��1008,402,0,0q�$	��Top=�$
��Left=�.+�A� $	��150��$	��150��$��10��
���   �
��������� $��Prueba��$��Center=�$��Center=�$��36(�$��Italic$�$��	20 0 20 0q�� $��528,990,0,-60q�$	��Top=�$
��Left=�.+�A� $	��150��$	��150��$��10��
���   �
�������� $��1608,729,0,0q�$	��Top=�$
��Left=�.+�A� $	��150��$	��150��$��10��
���   �
�������� -   $��LifeGrid��$��Center=�$��Bottom=�$��10 10 10 20q�.+�� -   $��	LifePanel��$��75��.+��� $.��(../TypeIdentification_Resources/Life.png���� $.��(../TypeIdentification_Resources/Life.png���� $.��(../TypeIdentification_Resources/Life.png���� $.��(../TypeIdentification_Resources/Life.png���� -   $��
ScoreLabel��$��
0000000000��$��10 20 10 10q�$��Center=�$	��Top=�$	��100(�$
��Bold"�$��Tempus Sans ITC)�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFFF7502�� � Offset$ 0Q�� $ 	#FFF5DF00��$ 1Q�:   4TFG_AIK_OscarJoseAbeldaFernandez.Controls.PromptMenu  -     Name$ 
PromptMenu��� -   $��	ScoreView��  OpacityBackgroundBrush#��[ $y�Hidden=�'  !System.Windows.VisualStateManager   VisualStateGroups %  System.Windows.VisualStateGroup  -   TransitionStates��   States.    System.Windows.VisualState  -   
Normal��  -   
FadeIn��   
Storyboard. �� .��W�  W� From$ 0X�	 W� To$ 1X�$ Opacity� g� Duration$ 0:0:0.5D�T� $ 
Visibility�..�i� $ 0:0:0��  Visible=�  -   FadeOut��. �� .��W� $ 1X�$ 0X�$ Opacity�$ 0:0:0.5D�T� $ 
Visibility�..�i� $ 0:0:0.5��  
Hidden=�.+��� $��5q�
���   �$��60 60 60 60q�._�� #��[  �� $
��Auto ��� $��* ��� $
��Auto ��� $��* ��� $��* �.+��� $��0��$��Archivements:��$��	10 5 10 1q�$	��100(��� $��1��$��2q�
���   �$��	10 1 10 1q�._��� -   $��ScoreArchivementsText��$��
Operations�� �� TextAlignment$ Justify=�$
��Wrap=����#989898$��
10 10 10 0q��� $��2��$��Final Score:��$��	10 5 10 1q�$	��100(��� $��3��$��2q�
���   �$��	10 1 10 5q�._��� -   $��FinalScoreText��$��1000000��$ Center=�$��Center=�$
��Wrap=����#989898$��
10 10 10 0q�$
��Bold"�$��ExtraExpanded&�$	��100(�� $��4�� �� �� .+�:  4Microsoft.Kinect.Toolkit.Controls.KinectCircleButton  -   $��0��  BackButtonStyle#��[ $��Center=�$��Center=�  -   $��1��  ReplayButtonStyle#��[ $��Center=�$��Center=�
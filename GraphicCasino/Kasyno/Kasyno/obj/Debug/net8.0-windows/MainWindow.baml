   M S B A M L   `   `   `  ����A  =Kasyno, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KasynoKasyno  5   	   C&clr-namespace:Kasyno.View.UserControlsKasyno.View.UserControls  6,   C&clr-namespace:Kasyno.View.UserControlsKasyno.View.UserControls  5   	       Kasyno.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Kasyno     5   	   ?usercontrols&clr-namespace:Kasyno.View.UserControls     6,   ?userControls&clr-namespace:Kasyno.View.UserControls     5   	   -   5          � Title$  Royal Casino��5	   	   $
��1000��6   $
��1650��6,    � Icon$ /coinslots.png��69    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	   .��5      � ��5   
   �� 5       �� ImageSource$ /background.jpg��6   5       � RowDefinitions 5   
   �� 5      $	��20* �6   6+   �� 5      $	��80* �6   6+   �� 5      $	��20* �6   6+   .+�5   
   �� $��0��6   $��0��6!   $��90(�61   $��Center=�6?   $��Center=�6\   $��Casino Regular)�6w   
���   � J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gold��6#   Royal Casino5   .   r� 5   
   	 r� Source$	 	theme.mp3?�6   
 r� LoadedBehavior$

 Play=�6*    r� Volume$	 0.1Q�6@   6O   r� 5   
   -   5        $��intro��5      $	 	intro.mp4?�6$    r� IsMuted$
 True��67   $

 Play=�6F   $��1��6\    K� ZIndex$	 999��6i   6~   '   !Kasyno.View.UserControls.MainMenu  5   
   -   5          Name$
 menu��5   >   $��1��6    $
|�True��6-   6N   �� 5    
   -   5        $��hideIntroButton��5       $��Center=�6(   $��center=�6C   $��30(�6`   
��� ���$��2��6�   $��Casino Regular)�6�   
���   �$��10q�6�   .��6�   
Skip intro6�   5!      5"      
   M S B A M L   `   `   `  ����  spotify-widget    spotify_widget.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  Widget_for_Spotify��5   	    � Title$ Spotify Widget��5   	   $	��120��5   	   $	��320��6    � AllowsTransparency$
 True��5   	    � WindowStyle$
 None=�5   	   
������  � Topmost$
 True��5	   	    � ShowInTaskbar$ False��5   	    � Icon$ /logo-icon.png��6   .��5      � .+�5   
   �� ���	#CC000000 �� CornerRadius$ 8��6(    �� Padding$ 10q�69      DropShadowEffect	 J� Effect#	 �   6F   ._�5      � 
 � ColumnDefinitions
 5      �� 5      $
��Auto �6'   �� 5      $��* �6'    � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      �� -   5         ��Name$ 
AlbumImage��5      $��80��5       $��80��6#   $��10q�5!      $��2��5"      $
}�True��5#      $��UniformToFill=�5$      �� 5'      -   5         ��Name$ 	TrackName��5'      $��Example Heading��5(      $��16(�5)      
�������$
��Bold"�5+      $��1��5,      $
��Wrap=�5-      $��
0,10,50,16q�60   $��2��6D   �� 51      -   5        $ 	AlbumName��51      $��Example Heading��52      $��12(�53      
�������$��1��55      $��1��56      $
��Wrap=�57      $��0,7,50,3q�58      �� 5;      -   5        $ 
ArtistName��5;      $��Example Heading��5<      $��10(�5=      
�������$��2��5?      $��Bottom=�5@      $��1��5A      $
��Wrap=�5B      $��
0,17,45,10q�5C      $��2��60   � 5F      -   5         �Name$ ProgressBar��5F      $��3��5G       � Minimum$ 0Q�5H       � Maximum$	 100Q�5I       � Value$ 0Q�5J      
���2�2�$��0q�5L      $��
10,20,12,0q�5M      $��2��62   �� 5P      -   5        $	��✕��5P       � Cursor$
 Hand��5Q      $��20��5R      $��20��6$   $
��Bold"�5S      
������ 
�������$��0q�5V      $
��Left=�5W      $	��Top=�5X      $��1��5Y       J� RenderTransformOrigin$ 0,0.6&�5Z   3   $��
170,10,0,0q�6Q   $��2��6e   5[      5\      5]      5^      
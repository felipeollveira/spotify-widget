   M S B A M L   `   `   `  ����   spotify-widget    spotify_widget.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$  Widget_for_Spotify�� � Title$ Spotify Widget��$	��120��$	��320�� � AllowsTransparency$
 True�� � WindowStyle$
 None=�
������  � Topmost$
 True�� � ShowInTaskbar$ False�� � Icon$ /logo-icon.png��.��� .+��� ���	#CC000000 �� CornerRadius$ 8�� �� Padding$ 10q�   DropShadowEffect	 J� Effect#	 �   ._�� 
 � ColumnDefinitions
 �� $
��Auto ��� $��* � � RowDefinitions �� $
��auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -    ��Name$ 
AlbumImage��$��80��$��80��$��10q�$��2��$
}�True��$��UniformToFill=��� -    ��Name$ 	TrackName��$��Example Heading��$��16(�
�������$
��Bold"�$��1��$
��Wrap=�$��
0,10,50,16q�$��2���� -   $ 	AlbumName��$��Example Heading��$��12(�
�������$��1��$��1��$
��Wrap=�$��0,7,50,3q��� -   $ 
ArtistName��$��Example Heading��$��10(�
�������$��2��$��Bottom=�$��1��$
��Wrap=�$��
0,17,45,10q�$��2��� -    �Name$ ProgressBar��$��3�� � Minimum$ 0Q� � Maximum$	 100Q� � Value$ 0Q�
���2�2�$��0q�$��
10,20,12,0q�$��2���� -   $	��✕�� � Cursor$
 Hand��$��20��$��20��$
��Bold"�
������ 
�������$��0q�$
��Left=�$	��Top=�$��1�� J� RenderTransformOrigin$ 0,0.6&�$��
170,10,0,0q�$��2��
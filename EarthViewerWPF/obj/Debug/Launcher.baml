   M S B A M L   `   `   `  ����  EarthViewerWPF    EarthViewerWPF.Launcher   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          �Name$  	Launcher1��5   a    � Title$ Earth Viewer Launcher 1.0��5   	   $	��420��6+   $	��680��68    � 
ResizeMode$ CanMinimize=�6D    � WindowStartupLocation$ CenterScreen=�6]   .��5      � .+�5	   
   �� -   5         ��Name$ backgroundImage��5	      $
��Left=�6)   $	��390��6D   $��
0,0,-6.4,0q�6Q   $	��Top=�6e   $	��680��6}   $*��$Resources/Images/panoramic earth.jpg��6�   $
��Fill=�6�   �� 5
   
   -   5         ��Name$ accountLoginBg��5
      $
��Left=�6(   $	��Top=�6C   $��
27,109,0,0q�6[   ���	#FF262626$	��174��6�   $	��175��6�    J� Opacity$	 0.5Q�6�   �� 5   
   -   5        $ titleHeader��5      $��Earth    Viewer��6%   $
��Left=�6?   $	��Top=�6Z   $��	22,30,0,0q�6r   $	��205��6�   $��Segoe)�6�   
�������$
��Bold"�6�   $��26(�6�   $��Center=�6�   �� 5   
   -   5        $ header��5      $��Account Login��6    $
��Left=�68   $��
37,112,0,0q�6S   $	��Top=�6g   
�������$��Calibri)�6�   $��10(�6�   �� 5   
   $
��Left=�6   $��90��6+   $��	60,46,0,0q�67   $	��Top=�6J   $��90��6b   $��Resources/Images/icon.png��6m   �� 5   
   -   5        $ usernameLabel��5      $��username��6'   $
��Left=�6:   $	��Top=�6U   $��
38,134,0,0q�6m   $��69��6�   $��Calibri)�6�   
�������$��14(�6�   
���   �$��26��6�   $��Center=�6�   $��Center=�6  �� 5   
   -   5        $ passwordLabel��5      $��password��6'   $
��Left=�6:   $	��Top=�6U   $��
38,196,0,0q�6m   $��69��6�   $��Calibri)�6�   
�������$��14(�6�   
���   �$��26��6�   $��Center=�6�   $��Center=�6  �� 5   
   -   5         ��Name$ usernameTextbox��5      $
��Left=�6+   $��23��6F   $��
37,161,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��149��6�   	 J� RenderTransformOrigin$	 0.5,0.5&�6�   ���	#FF262626
�������
 �� SelectionBrush

 �������6�   Z� 6�   G� 5   
   -	   5         G�Name$ passwordTextbox��5      $
��Left=�6/   $��
38,224,0,0q�6J   $	��Top=�6^   $	��149��6v   $��20��6�   ���	#FF262626 G� SelectionBrush
 �����
���������6�   Z� 6�   �� 5   
   -
   5         ��Name$ loginButton��5      $��Log In��6&   $
��Left=�67   $��
38,254,0,0q�6R   $	��Top=�6f   $��74��6~   ���	#FF262626 �� 	IsDefault . $��Calibri)�6�   
�������6�   �� 5   
   -   5        $ registerButton��5      $��Register��6)   $
��Left=�6<   $��112,254,0,0q�6W   $	��Top=�6l   $��74��6�   ���	#FF262626$��Calibri)�6�   
�������6�   �� 5   
   -   5        $ regCloseButton��5      $��Close��6)   $
��Left=�69   $��
37,324,0,0q�6T   $	��Top=�6h   $��74��6�   ���	#FF262626$��Calibri)�6�   
�������$	 0.5,0.5&�6�   $y�Hidden=�6   �� IsCancel . 6  �� 5   
   -   5        $ registerButton1��5      $��Register��6*   $
��Left=�6=   $��111,324,0,0q�6X   $	��Top=�6m   $��74��6�   ���	#FF262626$��Calibri)�6�   
�������$	 0.5,0.5&�6�   $y�Hidden=�6   . 6!  �� 5   
   -   5        $ regPasswordLabel��5      $��confirm password��6*   $
��Left=�6E   $	��Top=�6`   $��
38,256,0,0q�6x   $	��111��6�   $��Calibri)�6�   
�������$��14(�6�   
���   �$��26��6�   $��Center=�6�   $��Center=�6  $y�Hidden=�63  G� 5   
   -   5        $ regPasswordTextbox��5      $
��Left=�62   $��
38,284,0,0q�6M   $	��Top=�6a   $	��149��6y   $��20��6�   ���	#FF262626
 �����$y�Hidden=�6�   
���������6�   Z� 6�   �� 5   
   $
��Left=�6   $��107,156,0,0q�6+   $	��Top=�6@   5      5      
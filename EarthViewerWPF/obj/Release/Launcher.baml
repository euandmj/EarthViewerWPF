   M S B A M L   `   `   `  ����   EarthViewerWPF    EarthViewerWPF.Launcher   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     �Name$  	Launcher1�� � Title$ Earth Viewer Launcher 1.0��$	��420��$	��680�� � Icon$ Resources/Images/icon.png�� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=�.��� .+��� -    ��Name$ backgroundImage��$
��Left=�$	��390��$��
0,0,-6.4,0q�$	��Top=�$	��680��$*��$Resources/Images/panoramic earth.jpg��$
��Fill=��� -    ��Name$ accountLoginBg��$
��Left=�$	��Top=�$��
27,109,0,0q����	#FF262626$	��174��$	��175�� J� Opacity$	 0.5Q��� -   $ titleHeader��$��Earth    Viewer��$
��Left=�$	��Top=�$��	22,30,0,0q�$	��205��$��Segoe)�
�������$
��Bold"�$��26(�$��Center=��� -   $ header��$��Account Login��$
��Left=�$��
37,112,0,0q�$	��Top=�
�������$��Calibri)�$��10(��� $
��Left=�$��90��$��	60,46,0,0q�$	��Top=�$��90��$��Resources/Images/icon.png���� -   $ usernameLabel��$��username��$
��Left=�$	��Top=�$��
38,134,0,0q�$��69��$��Calibri)�
�������$��14(�
���   �$��26��$��Center=�$��Center=��� -   $ passwordLabel��$��password��$
��Left=�$	��Top=�$��
38,196,0,0q�$��69��$��Calibri)�
�������$��14(�
���   �$��26��$��Center=�$��Center=��� -    ��Name$ usernameTextbox��$
��Left=�$��23��$��
37,161,0,0q�	 �� TextWrapping$
	 Wrap=�$	��Top=�$	��149��
 J� RenderTransformOrigin$
 0.5,0.5&����	#FF262626
������� �� SelectionBrush
 �������Z� G� -	    G�Name$ passwordTextbox��$
��Left=�$��
38,224,0,0q�$	��Top=�$	��149��$��20�����	#FF262626 G� SelectionBrush
 �����
���������Z� �� -
    ��Name$ loginButton��$��Log In��$
��Left=�$��
38,254,0,0q�$	��Top=�$��74�����	#FF262626 �� 	IsDefault . $��Calibri)�
��������� -   $ registerButton��$��Register��$
��Left=�$��112,254,0,0q�$	��Top=�$��74�����	#FF262626$��Calibri)�
��������� -   $ regCloseButton��$��Close��$
��Left=�$��
37,324,0,0q�$	��Top=�$��74�����	#FF262626$��Calibri)�
�������$
 0.5,0.5&�$y�Hidden=� �� IsCancel . �� -   $ registerButton1��$��Register��$
��Left=�$��111,324,0,0q�$	��Top=�$��74�����	#FF262626$��Calibri)�
�������$
 0.5,0.5&�$y�Hidden=� . �� -   $ regPasswordLabel��$��confirm password��$
��Left=�$	��Top=�$��
38,256,0,0q�$	��111��$��Calibri)�
�������$��14(�
���   �$��26��$��Center=�$��Center=�$y�Hidden=�G� -   $ regPasswordTextbox��$
��Left=�$��
38,284,0,0q�$	��Top=�$	��149��$��20�����	#FF262626
 �����$y�Hidden=�
���������Z� �� $
��Left=�$��107,156,0,0q�$	��Top=�
   M S B A M L   `   `   `  ���� I  EEarthViewerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EarthViewerWPFEarthViewerWPF      EarthViewerWPF.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     /shapesclr-namespace:EarthViewerWPF       � Title$  Earth Viewer��$
��1280��$	��720�� � 
ResizeMode$ CanMinimize=� � Icon$ Resources/Images/icon.png�� � 	Resources ��%    .��� -   
������� J� IsManipulationEnabled . .+��� -    ��Name$ BackgroundImage��$
��Left=�$	��691��$	��Top=�$
��1280��$��	0,0,-8,-1q�$,��&/Resources/Textures/starBackground.png��$
��Fill=�'� -    '�Name$ viewport��$��-10,-8,10,0q� '� Camera =�  � Position$ 0,0,51�.x�g� -   	Light��	 g� Content	 h� .���� -   	light��
 �� Color$
 White��   EarthViewerWPF.Sphere  -   	Earth��   Material u�  u� Brush ��  �� ImageSource$+ %/Resources/Textures/politicalText.png�� "� 	Transform Y� -   transformGroup��.��� -   scaleTransform���� -	    ��Name$ 	sphereRec��
������ $��	0,-1,-6,0q�$
��Left=�$
��1280���� -
    ��Name$ InfoTextBox��$��Center=�$	��Top=�$��10q�$��24(�
���  ��$
��Bold"� J� RenderTransformOrigin$ 0.5,0.5&�z��� -   	InfoScale���� -    ��Name$ 	TouchLine��
���  ��$��2��$��307,24,327,31q��� -    ��Name$ detailsContainer��$
��Left=�$	��Top=�$��959,181,0,0q����	#FF262626$	��296��$	��292�� J� Opacity$	 0.5Q��� -   $ countryLabel��$��Country��$
��Left=�$	��Top=�$��69��$��Calibri)�
�������$��14(�
���   �$��26��$��Center=�$��Center=�$��970,190,0,0q��� -   $ countryText��$��
��$
��Left=�$��1084,190,0,0q�$	��Top=�$��Consolas)�$	��146��$��26��
�������$��15(��� -   $ capitalLabel��$��Capital��$
��Left=�$	��Top=�$��69��$��Calibri)�
�������$��14(�
���   �$��26��$��Center=�$��Center=�$��970,220,0,0q��� -   $ capitalText��$��
��$
��Left=�$��1084,221,0,0q�$	��Top=�$��Consolas)�$	��146�� J� 	AllowDrop .  $��26��
�������$��15(��� -   $ languageLabel��$��Language��$
��Left=�$	��Top=�$��69��$��Calibri)�
�������$��14(�
���   �$��26��$��Center=�$��Center=�$��970,251,0,0q��� -   $ languageText��$��
��$
��Left=�$��1084,251,0,0q�$	��Top=�$��Consolas)�$	��146�� .  $��26��
�������$��15(��� -   $ populationLabel��$��
Population��$
��Left=�$	��Top=�$��71��$��Calibri)�
�������$��14(�
���   �$��26��$��Center=�$��Center=�$��969,282,0,0q��� -   $ populationText��$��
��$
��Left=�$��1084,282,0,0q�$	��Top=�$��Consolas)�$	��146�� .  $��26��
�������$��15(��� -   $ 	areaLabel��$
��Area��$
��Left=�$	��Top=�$��69��$��Calibri)�
�������$��14(�
���   �$��26��$��Center=�$��Center=�$��970,313,0,0q��� -   $ areaText��$��
��$
��Left=�$��1084,313,0,0q�$	��Top=�$��Consolas)�$	��146�� .  $��26��
�������$��15(��� -   $ anthemLabel��$��Anthem��$
��Left=�$	��Top=�$��69��$��Calibri)�
�������$��14(�
���   �$��26��$��Center=�$��Center=�$��970,344,0,0q��� -   $ currencyLabel��$��Currency��$
��Left=�$	��Top=�$��69��$��Calibri)�
�������$��14(�
���   �$��26��$��Center=�$��Center=�$��970,375,0,0q��� -   $ currencyText��$��
��$
��Left=�$��1084,375,0,0q�$	��Top=�$��Consolas)�$	��146�� .  $��26��
�������$��15(��� -   $ gdpLabel��$	��GDP��$
��Left=�$	��Top=�$��69��$��Calibri)�
�������$��14(�
���   �$��26��$��Center=�$��Center=�$��970,406,0,0q��� -   $ gdpText��$��
��$
��Left=�$��1084,406,0,0q�$	��Top=�$��Consolas)�$	��146�� .  $��26��
�������$��15(��� -   $ religionLabel��$��Religion��$
��Left=�$	��Top=�$��69��$��Calibri)�
�������$��14(�
���   �$��26��$��Center=�$��Center=�$��970,437,0,0q��� -   $ religionText��$��
��$
��Left=�$��1084,437,0,0q�$	��Top=�$��Consolas)�$	��146�� .  $��26��
�������$��15(��� -    ��Name$ anthemButton��$
��play��$
��Left=�$��1098,350,0,0q�$	��Top=�$��51��$��20��$��Consolas)�
�������
���   ����	#FF707070�� -    $ anthemButtonStop��$
��stop��$
��Left=�$��1164,350,0,0q�$	��Top=�$��51��$��20��$��Consolas)�
���   �
���������Z� �� -!   $ bottomBarContainer��$
��Left=�$	��Top=�$��11,0,0,0q����	#FF262626$��25��$	��292��$	 0.5Q�$�� ���� -"   $ gamesBg��$�� ��$
��Left=�$��78,1,0,0q�$	��Top=����	#FF262626$��33��$��24��$y�Hidden=��� -#   $ 	gamesIcon��$
��Left=�$��24��$��78,1,0,0q�$	��Top=�$��34��$ ��Resources/UI/gamesIcon.png���� -$   $ 
settingsBg��$�� ��$
��Left=�$��31,0,0,0q�$	��Top=����	#FF262626$��25��$��25��$y�Hidden=��� -%   $ settingsIcon��$
��Left=�$��25��$��31,0,0,0q�$	��Top=�$��25��$��Resources/UI/cog.png���� -&   $ highScoresBg��$�� ��$
��Left=�$��	130,1,0,0q�$	��Top=����	#FF262626$��17��$��22��$y�Hidden=��� -'   $ highScoresIcon��$
��Left=�$��22��$��	130,1,0,0q�$	��Top=�$��17��$!��Resources/UI/highscores.png���� -(   $ 	powerBttn��$
��Left=�$��21��$��	253,1,0,0q�$	��Top=�$��19��$ ��Resources/UI/powerbttn.png���� -)   $ usernameLabel��$��username��$
��Left=�$	��Top=�$��72��$��20��$��Calibri)�
�������$��14(�
���   �$��	168,3,0,0q�$	��5,0q��� -*   $ settingsReset��$
��Left=�$��12��$��147,154,0,0q�$	��Top=�$��12��$��Resources/UI/upArrow.png��$
��Fill=�$y�Hidden=��� -+    ��Name$ ControlCheckBox��$��Disable touch input��$
��Left=�$	��Top=�$��	31,51,0,0q�
�������
���   �
�������$y�Hidden=��� -,   $ RotationResetButton��$��Reset Earth Rotation��$
��Left=�$	��Top=�$��	31,81,0,0q�
���   �
�������$y�Hidden=���Z� �� --    ��Name$ textureComboBox��$
��Left=�$	��Top=�$	��112��$��
31,117,0,0q�$y�Hidden=� �� SelectedIndex$ 0��.@��� $��	Political�� � ToolTip$# interaction and games enabled���� $��Earth��$$ interaction and games disabled���� -.   $ 
gameButton��$��
Countries ��$
��Left=�$��	31,63,0,0q�$	��Top=�$��75��
�������
���   �
���   �$y�Hidden=��� -/   $ countryGText��$
��Left=�$��489,641,0,0q�$
��Wrap=�$��Location��$	��Top=�$��48��$	��292��
������� �� TextAlignment$ Center=�$��36(����	#7F000000$y�Hidden=��� -0   $ 	timerText��$
��Left=�$��761,643,0,0q�$
��Wrap=�$	��Top=�
�������$	��30s��$y�Hidden=��� -1   $ recentScore1��$��Your Recent High Score: ��$
��Left=�$	��Top=�$	��174��$��Calibri)�
�������$��14(�
���   �$��26��$��
116,61,0,0q�$
��Left=�$��0,0,0,0q�$y�Hidden=��� -2   $ scoreLabel1��$��0��$
��Left=�$	��Top=�$��28��$��Calibri)�
�������$��14(�$��20��$��Center=�$��483,643,0,0q�$��Disabled=�$ 0.5,0.5&�$	��5,0q�$y�Hidden=���Z� �� -3   $ game2Button��$��Continents ��$
��Left=�$��	32,96,0,0q�$	��Top=�$��75��
�������
���   �
���   �$y�Hidden=��� -4   $ game2RecentScore��$��Your Recent High Score: ��$
��Left=�$	��Top=�$	��174��$��Calibri)�
�������$��14(�
���   �$��26��$��
117,94,0,0q�$
��Left=�$��0,0,0,0q�$y�Hidden=��� -5   $ leftSideDivider��$�� ��$
��Left=�$	��Top=�$��3��$��Calibri)�
�������$��14(�
���   �$	��125��$��Center=�$��Center=�$��
114,54,0,0q�$y�Hidden=��� -6   $ rightSideDivider��$�� ��$
��Left=�$	��Top=�$��3��$��Calibri)�
�������$��14(�
���   �$	��125��$��Center=�$��Center=�$��
201,54,0,0q�$y�Hidden=��� -7   $ gameModeLabelHs��$��	Game Mode��$
��Left=�$	��Top=�$��80��$��Calibri)�
�������
���   �$��26��$��Center=�$��Center=�$��	33,54,0,0q�$
��Bold"�$y�Hidden=��� -8   $ usernameLabelHs��$��Player��$
��Left=�$	��Top=�$��82��$��Calibri)�
�������
���   �$��26��$��Center=�$��Center=�$��
118,54,0,0q�$
��Bold"�$y�Hidden=��� -9   $ scoreLabelHs��$��Score��$
��Left=�$	��Top=�$��68��$��Calibri)�
�������
���   �$��26��$��Center=�$��Center=�$��
205,54,0,0q�$
��Bold"�$y�Hidden=��� -:   $ 	gameMode1��$��	Countries��$
��Left=�$	��Top=�$��80��$��Calibri)�
�������$��11(�
���   �$��26��$��Center=�$��Center=�$��	33,89,0,0q�$y�Hidden=��� -;   $ 	gamemode2��$��
Continents��$
��Left=�$	��Top=�$��80��$��Calibri)�
�������$��11(�
���   �$��26��$��Center=�$��Center=�$��
33,120,0,0q�$y�Hidden=��� -<   $ 	gameMode3��$��Capitals��$
��Left=�$	��Top=�$��80��$��Calibri)�
�������$��11(�
���   �$��26��$��Center=�$��Center=�$��
33,151,0,0q�$y�Hidden=��� -=   $ player1��$�� ��$
��Left=�$	��Top=�$��82��$��Calibri)�
�������$��11(�
���   �$��26��$��Center=�$��Center=�$��
118,89,0,0q�$y�Hidden=��� ->   $ player2��$�� ��$
��Left=�$	��Top=�$��82��$��Calibri)�
�������$��11(�
���   �$��26��$��Center=�$��Center=�$��118,120,0,0q�$y�Hidden=��� -?   $ player3��$�� ��$
��Left=�$	��Top=�$��82��$��Calibri)�
�������$��11(�
���   �$��26��$��Center=�$��Center=�$��118,151,0,0q�$y�Hidden=��� -@   $ score1��$�� ��$
��Left=�$	��Top=�$��68��$��Calibri)�
�������$��11(�
���   �$��26��$��Center=�$��Center=�$��
205,89,0,0q�$y�Hidden=��� -A   $ score2��$�� ��$
��Left=�$	��Top=�$��68��$��Calibri)�
�������$��11(�
���   �$��26��$��Center=�$��Center=�$��205,120,0,0q�$y�Hidden=��� -B   $ score3��$�� ��$
��Left=�$	��Top=�$��68��$��Calibri)�
�������$��11(�
���   �$��26��$��Center=�$��Center=�$��205,151,0,0q�$y�Hidden=��� -C   $ settingsReset_Copy��$
��Left=�$��12��$��153,188,0,0q�$	��Top=�$��12��$��Resources/UI/upArrow.png��$
��Fill=�$y�Hidden=�
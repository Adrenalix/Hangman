   M S B A M L   `   `   `  ����  HangmanGame    HangmanGame.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Hangman��5   	   $	��650��6   $	��525��6&    � Icon$ Resources/Stickman.ico��5   	      BackgroundBrush#��[  5   	    � 	Resources 5	   
     GradientBrush �� 
StartPoint �� EndPoint � Color � Offset��%R  &	       �� 5   
   $	 0,0&�64   $	 1,0&�6E   .��5      � $	 Red��6   $ 0Q�6'   � 5      $ Orange��6   $	 0.2Q�6*   � 5      $ Yellow��6   $	 0.4Q�6*   � 5      $ Green��6   $	 0.6Q�6)   � 5      $
 Blue��6   $	 0.8Q�6(   � 5      $ Violet��6   $ 1Q�6*   5      5      .��5      � .+�5   
   �� -   5        $��guessedLettersTextBlock��5      $
��Left=�63   $	��Top=�6N   $��	10,10,0,0q�6f   $��16(�6y   $
��Wrap=�6�   $	��100��6�   �� 5   
   $��Center=�6   $	��Top=�61   $��40(�6I   $��0,10,0,0q�6W   #��[ 6i   	HANGMAN5      �� 5   
   -   5        $��wordTextBlock��5      $��Center=�6)   $	��Top=�6F   $��30(�6^   $��0,65,0,0q�6l   �� 5!   
   -   5        $��hangmanCanvas��5!      $	��180��6&   $	��200��62   $��Center=�6?   $	��Top=�6\   $��0,140,100,0q�6t   .+�5#      �� 	 �� X1$ 60��6   	 �� Y1$ 20��6   		 �� X2$		 140��6#   	
 �� Y2$
 20��6,   
���   �$��4��6C   �� 5$      $	 140��6   $ 20��6   $		 140��6$   $
 50��6-   
���   �$��4��6D   �� 5%      $ 60��6   $ 20��6   $	 60��6#   $	
 230��6+   
���   �$��4��6C   �� 5&      $ 20��6   $	 230��6   $		 100��6$   $	
 230��6-   
���   �$��4��6E   A� 5)      -   5        $
��head��5)      $��40��6"   $��40��6-    �� Left$	 120��69   
 �� Top$ 50��6K   
���   �$��3��6j   $y�Hidden=�6~   �� 5+      -   5        $
��body��5+      $	 140��6   $ 90��6(   $		 140��60   $	
 150��69   
���   �$��3��6Q   $y�Hidden=�6e   �� 5-      -   5        $��leftArm��5-      $	 140��6"   $	 120��6+   $		 120��64   $	
 100��6=   
���   �$��3��6U   $y�Hidden=�6i   �� 5.      -   5        $��rightArm��5.      $	 140��6#   $	 120��6,   $		 160��65   $	
 100��6>   
���   �$��3��6V   $y�Hidden=�6j   �� 50      -   5        $��leftLeg��50      $	 140��6"   $	 150��6+   $		 120��64   $	
 180��6=   
���   �$��3��6U   $y�Hidden=�6i   �� 51      -	   5        $��rightLeg��51      $	 140��6#   $	 150��6,   $		 160��65   $	
 180��6>   
���   �$��3��6V   $y�Hidden=�6j   52      �� 56   
   -
   5        $��guessButton��56      $��Guess!��6$   $��Center=�65   $��Bottom=�6R   $��0,0,0,40q�6m   $	��150��6   $��30��6�   6�   �� 58   
   -   5        $��restartButton��58      $��Restart��6&   $��Center=�68   $��Bottom=�6U   $��0,0,0,40q�6p   $	��150��6�   $��30��6�   $y�	Collapsed=�6�   6�   �� 5:   
   $��Center=�6   $��Bottom=�6.   $��0,0,0,80q�6I   $	��150��6[   $��40��6g    �� CornerRadius$ 10��6s   
������� �� Padding$ 5q�6�   ._�5;      �� -   5        $��guessTextBox��5;      $��0q�6*   
������ $��Center=�6W   $��Center=�6y   $��16(�6�   6�   5<      �� 5>   
   -   5        $��messageTextBlock��5>      $��Center=�6,   $��Bottom=�6I   $��	0,0,0,150q�6d   $��16(�6w   5?      5@      
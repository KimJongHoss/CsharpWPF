   M S B A M L   `   `   `  ����J  FColorSliderPrac, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ColorSliderPracColorSliderPrac  5   	        ColorSliderPrac.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ColorSliderPrac     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � -   5         �Name$ MainGrid��5	      .+�5
   
   �� $��
Color Type��6   $��54,16,54,260q�6'   .��5      � .+�5      	� -   5         	�Name$ originalButton��5      $��Original��66   $
��Left=�6I   $��Center=�6d   $��19��6   $��	105,0,0,0q�6�    	� 	GroupName$ 1��6�    d� 	IsChecked$
 TrueY�6�   	� 5      -   5        $ GrayToneButton��5      $��	Gray Tone��66   $��Center=�6J   $��Center=�6g   $��19��6�   $ 1��6�   6�   	� 5      -   5        $ InvertButton��5      $��Invert��64   $
��Left=�6E   $��Center=�6`   $��19��6{   $��	510,0,0,0q�6�   $ 1��6�   6�   5      5      �� 5   
   -   5         ��Name$ 	redSlider��5       � Maximum$	 255Q�6$    �� TickPlacement$ BottomRight=�62    �� TickFrequency$ 5Q�6N   	 �� IsSnapToTickEnabled$
	 True��6`   $
��Left=�6{   $��Center=�6�   $	��196��6�   $��17��6�   $��90,0,0,0q�6�   �� 5   
   -   5        
 ��Name$
 lable1��5      $	��Red��6    $
��Left=�6.   $��54,0,0,0q�6I   $��Center=�6[    J� RenderTransformOrigin$ 
0.379,1.36&�6v   �� 5   
   $��0��6   $
��Left=�6   $��
87,222,0,0q�67   $	��Top=�6K   �� 5   
   $	��255��6   $
��Left=�6   $��266,226,0,0q�69   $	��Top=�6N   �� 5   
   -   5        $ GreenSlider��5      $	 255Q�6&   $ BottomRight=�64   $ 5Q�6P   $
	 True��6b   $
��Left=�6}   $��
90,281,0,0q�6�   $	��Top=�6�   $	��196��6�   $��17��6�   6�   �� 5   
   -   5        $
 lable2��5      $��Green��6    $
��Left=�60   $��
43,277,0,0q�6K   $	��Top=�6_   $ 
0.379,1.36&�6w   �� 5   
   $��0��6   $
��Left=�6   $��
87,302,0,0q�67   $	��Top=�6K   $ 0.638,0.162&�6c   �� 5   
   $	��255��6   $
��Left=�6   $��264,297,0,0q�69   $	��Top=�6N   �� 5   
   -	   5        $ 
BlueSlider��5      $	 255Q�6%   $ BottomRight=�63   $ 5Q�6O   $
	 True��6a   $
��Left=�6|   $��
90,358,0,0q�6�   $	��Top=�6�   $	��201��6�   $��17��6�   6�   �� 5   
   -
   5        $
 lable3��5      $
��Blue��6    $
��Left=�6/   $��
48,353,0,0q�6J   $	��Top=�6^   $ 
0.379,1.36&�6v   �� 5   
   $��0��6   $
��Left=�6   $��
87,380,0,0q�67   $	��Top=�6K   $ 0.638,0.162&�6c   �� 5   
   $	��255��6   $
��Left=�6   $��260,374,0,0q�69   $	��Top=�6N   �� 5   
   -   5        $
 redLabel��5      $��0��6"   $
��Left=�6.   $��
88,178,0,0q�6I   $	��Top=�6]   $ -1.324,0.806&�6u   �� 5   
   -   5        $
 
GreenLabel��5      $��0��6$   $
��Left=�60   $��
88,253,0,0q�6K   $	��Top=�6_   �� 5    
   -   5        $
 	BlueLabel��5       $��0��6#   $
��Left=�6/   $��
87,331,0,0q�6J   $	��Top=�6^   5"      5#      
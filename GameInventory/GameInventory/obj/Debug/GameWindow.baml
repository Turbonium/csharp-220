   M S B A M L   `   `   `  ����H  DGameInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:GameInventoryGameInventory  5   	       GameInventory.GameWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:GameInventory     5   	   -   5          � Title$  Game Details��5   	   $	��400��6   $	��240��6*    +� FocusedElement 5	   	   ��  �� ElementName$ uxTitle��.��5      � -   5         �Name$ uxGrid��5       � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��0��6$   $��Right=�61   Game Title:6Z   �� 5   
   -   5         ��Name$ uxTitle��5      $��1��6@   $��0��6P   ��6#   �� *	GameTitle+6_   �� 5!   
   $��0��6   $��1��6$   $��Right=�61   
Game Type:6Y   �� 5"   
   -   5        $ uxType��5"      $��1��6"   $��1��62   6A   �� 5#   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��1��6>   .+�5$      	� -   5         	�Name$ 	uxDigital��5$      	 d� 	IsChecked$
	 trueY�6-   $�� 5,1,1,1q�6>   .��6Q   	Digital6Z   	� 5%      -   5        $ 
uxPhysical��5%      $��	 10,1,1,1q�6.   .��6B   
Physical6L   5&      �� 5(   
   $��0��6   $��2��6$   $��Right=�61   	Platform:6X   �� 5)   
   -   5        $ 
uxPlatform��5)      $��1��6&   $��2��66   6E   �� 5*   
   $ 
Horizontal=�6   $��1��6.   $��2��6>   .+�5+      	� -   5        $ uxXbox��5+      $
	 trueY�6*   $��5,1,1,1q�6;   .��6L   XBox6R   	� 5,      -	   5        $
 uxPC��5,      $��10,1,1,1q�6(   .��6;   PC6?   	� 5-      -
   5        $ uxBoardGame��5-      $��10,1,1,1q�6/   .��6B   
Board Game6N   5.      �� 50   
   $��0��6   $��3��6$   $��Right=�61   	Quantity:6X   �� 51   
   $ 
Horizontal=�6   $��1��6.   $��3��6>   .+�52      �� -   5        
 ��Name$
 
uxQuantity��52      $��50��6H    � Minimum$ 1Q�6U    � Maximum$	 100Q�6b    �� TickFrequency$ 1Q�6p    �� IsSnapToTickEnabled .  � Value 6)   �� *GameQuantity+6�   �� 53      $��Right=�6o    �� TextAlignment$ Right=�6�   $��40��6�   ��6   �� $ 
uxQuantity�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   54      �� 56   
   $��0��6   $��5��6$   $��Right=�61   Cost Per Unit:6]   �� 57   
   -   5        $ uxCost��57      $��1��6|   $��4��6�    �� AcceptsReturn .  $
 Left=�6�   $��	0,0,212,1q�6�   $��2��6�   ��6"   �� *GameCostPerUnit+ �� StringFormat$ {0:c}��6�   �� 5<   
   $��0��6   $��7��6$   $��Right=�61   Retail Price Per Unit:6e   �� 5=   
   -   5        $ uxRetailPrice��5=      $��1��6�   $��7��6�    .  $
 Left=�6�   $��	0,0,212,0q�6�   ��6)   �� *GameRetailPerUnit+$ {0:c}��6�   �� 5C   
   $ 
Horizontal=�6   $��1��6.   $��9��6>   $��Right=�6K   .+�5D      �� -   5         ��Name$ uxSubmit��5D      $��10��6(   $��Center=�66   $��10q�6j   .��6v   Submit6~   �� 5E      -   5        $ uxCancel��5E      $��10��6(   $��Center=�66   $��10q�6j   .��6v   Cancel6~   5F      5G      5H      
   M S B A M L   `   `   `  ����H  DGameInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:GameInventoryGameInventory  5   	       GameInventory.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:GameInventory     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��650��6)   .��5	      ��  �� Orientation$ Vertical=�6   .+�5
   
   o� .@�5      m� $��_File��6   .@�5      m� -   5         m�Name$ 	uxFileNew��5      $
��_New��6.   6<   m� 5      -   5        $ uxFileDelete��5      $��_Delete��61   6]   m� 5      -   5        $ uxFileChange��5      $��_Modify��61   6]   m� 5      -   5        $ 
uxFileExit��5      $��E_xit��6/   6>   5      5      �� 5   
   -   5         ��Name$ uxGamesList��5      $	��200��6(    � ContextMenu 5      �� 5      .@�5      m� -   5        $ uxContextFileNew��5      $
��_New��69   6G   m� 5      -   5        $ uxContextFileDelete��5      $��_Delete��6<   6h   m� 5      -   5        $ uxContextFileChange��5      $��_Modify��6<   6h   m� 5      -	   5        $ uxContextFileExit��5      $��E_xit��6:   6b   5       �� View 5      �� 5      .P�5      ��  �� Width$
 Auto��6P    �� DisplayMemberBinding 6%   �� *	GameTitle+.��5      �� -
   5        
 � Tag$ Title��5   /   $�� Game Title ��6V   5      �� 5       $
 Auto��6O    6%   �� *
GameType+.��5!      �� -   5        $
 Type��5!   /   $�� Game Type ��6U   5"      �� 5#      $
 Auto��6S    6%   �� *GamePlatform+.��5$      �� -   5        $ Platform��5$   /   $�� Game Platform ��6Y   5%      �� 5&      $
 Auto��6S    6%   �� *GameQuantity+.��5'      �� -   5        $ Quantity��5'   /   $��
 Quantity ��6Y   5(      �� 5)      $
 Auto��6o    6%   �� *GameCostPerUnit+	 �� StringFormat$	 {0:c}��.��5*      �� -   5        $
 Cost��5*   /   $�� Cost Per Unit ��6U   5+      �� 5,      $
 Auto��6m    6%   �� *GameTotalCost+$	 {0:c}��.��5-      �� -   5        $ 	TotalCost��5-   /   $�� Total Cost ��6Z   5.      �� 5/      $
 Auto��6q    6%   �� *GameRetailPerUnit+$	 {0:c}��.��50      �� -   5        $ Retail��50   /   $�� Retail Per Unit ��6W   51      �� 52      $
 Auto��6o    6%   �� *GameTotalRetail+$	 {0:c}��.��53      �� -   5        $ Total Retail��53   /   $�� Total Retail Value ��6]   54      55      57      58      59      
   M S B A M L   `   `   `  ����B  >eVoting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:eVotingeVoting  5   	       eVoting.YearReg   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:eVoting     5   	     � Title$  YearReg��5   	   $	��450��6   $	��800��6&    � WindowState$ 	Maximized=�62   .��5	      � ��5
   
   �� 5       �� ImageSource$> 8C:\Users\Ogbonna Vitalis\Downloads\vote-1804596_1920.jpg��6   .+�5   
   �� $"��Select Row to Edit or Delete��6   $��Center=�69   $	��383��6V   $��354,26,47,10q�6c   $��Center=�6y   $	��391��6�   �� 5   
   -   5         ��Name$ year_reg_border��5      
���   �$��1q�6>   $��Center=�6R   $	��286��6o   $��21,55,480,78q�6|   $��Center=�6�   $	��291��6�   ._�5      �� -   5         ��Name$ year_reg_label��5      $��Register an Election Year��6,   $��Center=�6P   $��34��6m   $��1,3,112,247q�6y   $��Center=�6�   $	��176��6�   ���	#FFFBF5F5$��14(�6�   $
��Bold"�6�   5      �� 5   
   -   5        $ 
year_label��5      $��Year:��6%   $��Center=�65   $��24��6R   $��45,126,696,269q�6^   $��Center=�6v   $��51��6�   $��12(�6�   $
��Bold"�6�   ���	#FFE88A196�   �� 5   
   -   5         ��Name$ year_reg_button��5      $��Register Year��6*   $��Center=�6B   $��60��6_   $��41,237,502,122q�6k   $��Center=�6�   $	��249��6�   ���	#FFEFF2F9���	#FFEFF2F9$��16(�6�   $��Segoe UI Emoji)�6�   $
��Bold"�6  ���	#FF09E8136,  �� 5   
   -   5         ��Name$
 year��5      $��Center=�6    $��50��6=   $��40,150,504,219q�6I    �� TextWrapping$
 Wrap=�6a   $
��Year��6u   $��Center=�6�   $	��248��6�   $��3q�6�   ���	#FFEFF2F9���	#FFEFF2F9 �� SelectionBrush �	#FFF1F3F5$��16(�6  $��Segoe UI Emoji)�6*  $
��Bold"�6F  	 �� TextAlignment$	 Center=�6X  $��10q�6o  ��6�   Z� 6o     eVoting.MenuHeader  5   
   $
��-4,0q�6   $	��Top=�6*   $��46��6B   z�5      V� 5      .~�5      �� �� 5      �� 5      
 �� Angle$	
 360Q�6&   T� 5      5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ yearDataGrid��5         AlternatingRowBackground �	#FFC4B0B0   AutoGenerateColumns .  $��404,75,86,182q�6j   $��Center=�6�   $��Center=�6�   $	��162��6�   ��6�   Z�    Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6<      Header$ Year ID��6H      
Foreground �	#FF4CE613   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *id+6p     5"      $	 100 6C   $
 Year��6O    6%   �� *	year_name+6O     5#      $	 100 6D   $ Current Year��6P    6%   �� *
is_current+6P   5%      �� 5&   
   -   5        $ year_reg_button_edit��5&      $��	Edit Year��6/   $��Center=�6C   $��35��6`   $��581,294,105,90q�6l   $��Center=�6�   $	��106��6�   ���	#FFEFF2F9���	#FFEFF2F9$��16(�6�   $��Segoe UI Emoji)�6�   $
��Bold"�6  ���	#FF09ABE86-  �� 5'   
   -   5        $ selected_item_label��5'      $��No Selection Made��6-   $��Center=�6I   $��26��6f   $��438,257,126,136q�6r   $��Center=�6�   $	��228��6�   ���	#FFEE2828$��Center=�6�   ���	#FFEEDEDE
���   �$��12(�6  �� 5(   
   -	   5        $ year_reg_button_delete��5(      $��Delete Year��61   $��Center=�6G   $��35��6d   $��424,293,262,91q�6p   $��Center=�6�   $	��106��6�   ���	#FFEFF2F9���	#FFEFF2F9$��16(�6�   $��Segoe UI Emoji)�6�   $
��Bold"�6  ���	#FFE83209 J� RenderTransformOrigin$ 
0.41,0.707&�6M  �� 5)   
   -
   5        $ year_reg_button_current��5)      $��Set as Current Year��62   $��Center=�6P   $��35��6m   $��423,355,102,29q�6y   $��Center=�6�   $	��267��6�   ���	#FFEFF2F9���	#FFEFF2F9$��16(�6�   $��Segoe UI Emoji)�6�   $
��Bold"�6  ���	#FF38EC8A6:  5+      5,      
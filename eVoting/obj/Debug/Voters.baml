   M S B A M L   `   `   `  ����B  >eVoting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:eVotingeVoting  5   	       eVoting.Voters   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:eVoting     5   	     � Title$  Voters��5   	   $	��450��6   $	��800��6%    � WindowState$ 	Maximized=�61   .��5	      � ��5
   
   �� 5       �� ImageSource$ images\vote1.jpg��6   .+�5   
   �� $"��Select Row to Edit or Delete��6   $��Center=�69   $	��581��6V   $��-217,-82,-163,-80q�6c   $��Center=�6~   $
��1172��6�      eVoting.MenuHeader  5   
   $
��-4,0q�6   $	��Top=�6*   $��46��6B   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$	 360Q�6&   T� 5      5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ voterDataGrid��5         AlternatingRowBackground �	#FFC4B0B0   AutoGenerateColumns .  $��-154,-39,-118,23q�6k   $��Center=�6�   $��Center=�6�   $	��435��6  $
��1064��6  ��6�   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6<   	   Header$	 UserID��6H   
   
Foreground
 �	#FF4CE613   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *id+6o     5      $	 100 6D   $	 
First Name��6P    6%   �� *
first_name+6P     5       $	 100 6C   $	 	Last Name��6O    6%   �� *	last_name+6O     5!      $	 100 6G   $	 Date of Birth��6S    6%   �� *date_of_birth+6S     5"      $	 100 6=   $	 
Local Govt��6I    6%   �� *lga+6I     5#      $	 100 6?   $	 State��6K    6%   �� *state+6K     5$      $	 100 6?   $	 Phone Number��6K    6%   �� *phone+6K     5%      $	 100 6?   $	 Email��6K    6%   �� *email+6K     5&      $	 100 6D   $	 Date Registerd��6P    6%   �� *
created_at+6P   5(      �� 5)   
   -   5         ��Name$ selected_item_label��5)      $��No Selection Made��6-   $��Center=�6I   $��26��6f   $��414,425,150,-32q�6r   $��Center=�6�   $	��228��6�   ���	#FFEE2828$��Center=�6�   ���	#FFEEDEDE
���   �$��12(�6  �� 5*   
   -   5         ��Name$ voter_button_delete��5*      $��Delete Voter��6.   $��Center=�6E   $��36��6b   $��665,418,21,-35q�6n   $��Center=�6�   $	��106��6�   ���	#FFEFF2F9���	#FFEFF2F9$��16(�6�   $��Segoe UI Emoji)�6�   $
��Bold"�6  ���	#FFE83209 J� RenderTransformOrigin$ 0.456,2.248&�6K  5.      5/      
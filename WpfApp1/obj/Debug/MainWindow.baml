   M S B A M L   `   `   `  ����  WpfApp1G    AWpfTutorialSamples.Audio_and_Video.AudioVideoPlayerCompleteSample   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$"  Kylyn's sub par video player��5   	    � WindowStartupLocation$ CenterScreen=�6�   ��6.   �� *&$SystemParameters.PrimaryScreenHeight+��6f   �� *%#SystemParameters.PrimaryScreenWidth+ J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Open��5      6Y     5	   
   -   5        $ MediaCommands.Play��5	      6S     5
   
   -   5        $ MediaCommands.Pause��5
      6U     5   
   -   5        $ MediaCommands.Stop��5      6S   .��5      � -   5         � ColumnDefinitions 5   
   �� 5      $
��241* �6   �� 5      $	��51* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   c� $��2��6   .@�5      �� $��ApplicationCommands.Open��6   .��68   Open5      �� 5      5      r� 5   
   -   5        $��mePlayer��5      $��1��6'    r� LoadedBehavior$ Manual=�64    r� Stretch$ Uniform=�6L   $��2��6^   �� 5    
   $��2��6   $��5��6!   ��5!      �� 5"      .R�5#      �  5$      �� 5%      $
��Auto �6/   �� 5&      $
��Auto �6/   �� 5'      $
��Auto �6/   �� 5(      $
��Auto �6/   �� 5)      $��* �6/   �� 5*      $
��Auto �6/   5,      5-      .@�5/      �� $��0��6   $
��Left=�6,   .��50      �� $��MediaCommands.Play��6   .��66   Play52      53      �� 54      $��1��6   $
��Left=�6,   .��55      �� $��MediaCommands.Pause��6   .��67   Pause57      58      �� 59      $��2��6   $
��Left=�6,   .��5:      �� $��MediaCommands.Stop��6   .��66   Stop5<      5=      �� 5>      $��3��6   $��Stretch=�6,   .��5?      �� -   5        $��lblProgressStatus��5?      
00:00:006?   5@      �� 5A      $��4��6   $��Stretch=�6,   .��5B      �� -   5        $��sliProgress��5B      6�   5C      �� 5D      $��5��6   $��Right=�6,   .��5E      �� -	   5        $��blockedTimesCB��5E      $	��150��62   6@   5F      5G      5H      5I      
   M S B A M L   `   `   `  ����   WpfApp1G    AWpfTutorialSamples.Audio_and_Video.AudioVideoPlayerCompleteSample   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$"  Kylyn's sub par video player�� � WindowStartupLocation$ CenterScreen=����� *&$SystemParameters.PrimaryScreenHeight+���� *%#SystemParameters.PrimaryScreenWidth+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$ ApplicationCommands.Open��  -   $ MediaCommands.Play��  -   $ MediaCommands.Pause��  -   $ MediaCommands.Stop��.��� -    � ColumnDefinitions �� $
��241* ��� $	��51* � � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+�c� $��2��.@��� $��ApplicationCommands.Open��.��Open�� r� -   $��mePlayer��$��1�� r� LoadedBehavior$ Manual=� r� Stretch$ Uniform=�$��2���� $��2��$��5������ .R��  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.@��� $��0��$
��Left=�.���� $��MediaCommands.Play��.��Play�� $��1��$
��Left=�.���� $��MediaCommands.Pause��.��Pause�� $��2��$
��Left=�.���� $��MediaCommands.Stop��.��Stop�� $��3��$��Stretch=�.���� -   $��lblProgressStatus��
00:00:00�� $��4��$��Stretch=�.���� -   $��sliProgress���� $��5��$��Right=�.���� -	   $��blockedTimesCB��$	��150��
   M S B A M L   `   `   `  ����B  >Liblaly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Liblaly.ViewLiblaly.View  5   	   %    Liblaly.View.UserBookManageView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Liblaly.View     5   	     � Title$  UserManageView��5   	   $	��450��6    $	��800��6-   .��5	      � $��-1,0,1,0q�6   .+�5
   
   �� -   5         ��Name$ Users��5
   e   $
��Left=�6   $��	19,66,0,0q�6.   $	��Top=�6A   $	��120��6Y   6t   �� 5   
   -   5        $ 	UserBooks��5   g   $
��Left=�6   $��333,116,0,0q�6.   $	��Top=�6C   $	��120��6[   6z   �� 5   
   -   5         ��Name$ UserName��5   d   $
��Left=�6   $��191,169,0,0q�6+   $	��Top=�6@   $	��130��6X   $��24��6v   �� 5   
   -   5        $ Deadline��5   d   $
��Left=�6   $��152,198,0,0q�6+   $	��Top=�6@   $	��144��6X   $��26��6v   �� 5   
   $��Имя��6   $
��Left=�6   $��153,164,0,0q�69   $	��Top=�6N   �� 5   
   $��Дата конца��6   $
��Left=�6%   $��
67,198,0,0q�6@   $	��Top=�6T   �� 5   
   -   5        $ LibBooks��5   f   $
��Left=�6   $��
598,98,0,0q�6.   $	��Top=�6B   $	��120��6Z   6x   �� 5   
   -   5         ��Name$ 
BookSearch��5   �   $
��Left=�6   $��23��6-   $��
414,27,0,0q�69    �� TextWrapping$
 Wrap=�6M   $	��Top=�6a   $	��120��6y   6�   �� 5   
   -   5        $��
Поиск��5      $
��Left=�6!   $��
525,73,0,0q�6<   $	��Top=�6P   $��75��6h    J� RenderTransformOrigin$ 0.5,0.5&�6s   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 39.793Q�6&   T� 5      5      5      �� 5   
   $-��'Список пользователей��6   $
��Left=�6/   $��	19,24,0,0q�6J   $	��Top=�6]   �� 5   
   $$��Окно поиска книг��6   $
��Left=�6+   $��	414,1,0,0q�6F   $	��Top=�6Y   �� 5   
   $4��.Список книг пользователя��6   $
��Left=�63   $��152,112,0,0q�6N   $	��Top=�6c   �� 5   
   $.��(Список доступных книг��6   $
��Left=�60   $��
598,72,0,0q�6K   $	��Top=�6_   �� 5    
   -   5        $ CurrentBookName��5    c   $
��Left=�6   $��
268,50,0,0q�6+   $	��Top=�6?   $	��130��6W   $��24��6|   �� 5!   
   $!��Название книги��6   $
��Left=�6)   $��
166,48,0,0q�6D   $	��Top=�6X   �� 5"   
   -	   5        $
 Type��5"   c   $
��Left=�6   $��
276,81,0,0q�6+   $	��Top=�6?   $	��144��6W   $��26��6q   �� 5#   
   $��Формат��6   $
��Left=�6!   $��
191,81,0,0q�6<   $	��Top=�6P   �� 5$   
   -
   5        $��Продолжить��5$      $
��Left=�6&   $��
46,263,0,0q�6A   $	��Top=�6U   $��75��6m   $��80��6x   6�   �� 5%   
   -   5        $-��'Нажать если все плохо��5%      $
��Left=�61   $��	114,1,0,0q�6L   $	��Top=�6_   $	��145��6w   $��23��6�   6�   �� 5&   
   -   5        $ 
UserSearch��5&   �   $
��Left=�6   $��23��6-   $��
10,164,0,0q�69   $
 Wrap=�6M   $	��Top=�6a   $	��120��6y   6�   �� 5'   
   $6��0Окно поиска пользователей��6   $
��Left=�64   $��
67,133,0,0q�6O   $	��Top=�6c   �� 5(   
   -   5        $��
Поиск��5(      $
��Left=�6!   $��-17,115,0,0q�6<   $	��Top=�6Q   $��75��6i   $ 0.5,0.5&�6t   z�5)      V� 5*      .~�5+      �� �� 5,      �� 5-      $ -90.378Q�6&   T� 5.      5/      51      52      53      
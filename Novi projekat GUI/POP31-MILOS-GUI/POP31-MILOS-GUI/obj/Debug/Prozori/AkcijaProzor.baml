   M S B A M L   `   `   `  ����J  FPOP31-MILOS-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:POP31_MILOS_GUI.ProzoriPOP31_MILOS_GUI.Prozori  5   	   *    $POP31_MILOS_GUI.Prozori.AkcijaProzor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:POP31_MILOS_GUI.Prozori     5   	     � Title$  AkcijaProzor��5   	   $	��400��6   $	��400��6+   
������.��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��dgAkcija��5
      $��Stretch=�6#   $	��220��6A   $��5,5,5,0q�6N   $	��Top=�6_      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .     SelectionMode$ Single=�6     
IsReadOnly . 	   HeadersVisibility$	 Column=�6C  
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5      $ Naziv��6%   $ 1* 6N    64   �� *Naziv+6N     5      $ Pocetak akcije��6%   $ 1* 6Y    6=   �� *	Pocetak+6Y     5      $ Kraj akcije��6%   $ 1* 6S    6:   �� *Kraj+6S   5      �� 5   
   -   5        $��btnDodaj��5      $��Dodaj��6!   $
��Left=�61   $��
50,291,0,0q�6L   $	��Top=�6`   $��75��6x   6�   �� 5   
   -   5        $��	btnIzmeni��5      $��Izmeni��6"   $
��Left=�63   $��171,291,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5   
   -   5        $��	btnObrisi��5      $��Obrisi��6"   $
��Left=�63   $��277,291,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5   
   -   5        $��cbAkcija��5      $��Prikazi aktuelne akcije��6#   $
��Left=�6E   $��171,239,0,0q�6`   $	��Top=�6u   6�   5      5      
   M S B A M L   `   `   `  ����J  FPOP31-MILOS-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:POP31_MILOS_GUI.ProzoriPOP31_MILOS_GUI.Prozori  5   	   +    %POP31_MILOS_GUI.Prozori.ProdajaProzor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:POP31_MILOS_GUI.Prozori     5   	     � Title$  ProdajaProzor��5   	   $	��440��6   $	��400��6,   
������.��5	      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dgProdaja��5      $��Stretch=�6$   $	��250��6B   $��5,5,0,0q�6O   $	��Top=�6`      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .     SelectionMode$ Single=�6     
IsReadOnly . 	   HeadersVisibility$	 Column=�6D  
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5      $ Kupac��6%   $ 1* 6N    64   �� *Kupac+6N     5      $ Broj racuna��6%   $ 1* 6Y    6:   �� *
BrojRacuna+6Y     5      $ Vreme��6%   $ 1* 6V    64   �� *VremeKupovine+6V     5      $
 Cena��6%   $ 1* 6R    63   �� *
UkupnaCena+6R   5      �� 5   
   -   5        $��btnDodaj��5      $��Dodaj��6!   $
��Left=�61   $��
43,274,0,0q�6L   $	��Top=�6`   $��75��6x   6�   �� 5   
   -   5        $��
btnPrikazi��5      $��Prikazi��6#   $
��Left=�65   $��250,274,0,0q�6P   $	��Top=�6e   $��75��6}   6�   5      5      
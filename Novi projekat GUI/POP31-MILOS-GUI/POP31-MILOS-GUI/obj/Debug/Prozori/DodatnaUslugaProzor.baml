   M S B A M L   `   `   `  ����J  FPOP31-MILOS-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:POP31_MILOS_GUI.ProzoriPOP31_MILOS_GUI.Prozori  5   	   1    +POP31_MILOS_GUI.Prozori.DodatnaUslugaProzor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:POP31_MILOS_GUI.Prozori     5   	     � Title$  DodatnaUslugaProzor��5   	   $	��300��6%   $	��450��62   
������.��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��dgDodatnaUsluga��5
      $��Stretch=�6*   $	��220��6H   $��5,5,5,0q�6U   $	��Top=�6f      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .     SelectionMode$ Single=�6!     
IsReadOnly . 	   HeadersVisibility$	 Column=�6J  
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5      $ Naziv��6%   $ 1* 6N    64   �� *Naziv+6N     5      $
 Cena��6%   $ 1* 6L    63   �� *Cena+6L   5      �� 5   
   -   5        $��btnDodaj��5      $��Dodaj��6!   $
��Left=�61   $��
35,241,0,0q�6L   $	��Top=�6`   $��75��6x   6�   �� 5   
   -   5        $��	btnIzmeni��5      $��Izmeni��6"   $
��Left=�63   $��186,241,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5   
   -   5        $��	btnObrisi��5      $��Obrisi��6"   $
��Left=�63   $��340,241,0,0q�6N   $	��Top=�6c   $��75��6{   6�   5      5      
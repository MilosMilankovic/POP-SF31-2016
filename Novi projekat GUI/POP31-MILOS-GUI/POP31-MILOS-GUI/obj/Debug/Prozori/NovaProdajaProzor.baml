   M S B A M L   `   `   `  ����J  FPOP31-MILOS-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:POP31_MILOS_GUI.ProzoriPOP31_MILOS_GUI.Prozori  5   	   /    )POP31_MILOS_GUI.Prozori.NovaProdajaProzor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:POP31_MILOS_GUI.Prozori     5   	     � Title$  NovaProdajaProzor��5   	   $	��500��6#   $	��500��60   
������.��5	      � .+�5
   
   �� $��Kupac:��6   $
��Left=�6!   $��	55,32,0,0q�6<   $	��Top=�6O   �� 5   
   $��Broj racuna:��6   $
��Left=�6'   $��	55,63,0,0q�6B   $	��Top=�6U   �� 5   
   -   5        $��tbKupac��5      $
��Left=�68   $��23��6S   $��
156,36,0,0q�6_    �� TextWrapping$
 Wrap=�6s   $	��Top=�6�   $	��120��6�   ��6!   �� *Kupac+6�   �� 5   
   -   5        $��tbBrojRacuna��5      $
��Left=�6B   $��23��6]   $��
156,66,0,0q�6i   $
 Wrap=�6}   $	��Top=�6�   $	��120��6�   ��6&   �� *
BrojRacuna+6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgPar��5      $��Stretch=�6    $	��150��6>   $��5,5,90,0q�6K   $��Center=�6]      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .     SelectionMode$ Single=�6  	   
IsReadOnly	 . 
   HeadersVisibility$
 Column=�6C     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Namestaj.Id+6Q     5      $ Namestaj��6%   $ 1* 6Z    67   �� *Namestaj.Naziv+6Z     5      $ Jedinicna cena��6%   $ 1* 6h    6=   �� *Namestaj.JedinicnaCena+6h     5      $ Kolicina��6%   $ 1* 6T    67   �� *
Kolicina+6T   5        5   
   -   5        $��dgUsluga��5      $��Stretch=�6#   $	��150��6A   $��5,5,90,0q�6N   $��Bottom=�6`    .   .   .   .   .   .  $ Single=�6  	 . $
 Column=�6F   5        5      $ Id��6%   $
 0.5* 6H    61   �� *Id+6H     5      $ Naziv��6%   $ 1* 6N    64   �� *Naziv+6N     5      $
 Cena��6%   $ 1* 6L    63   �� *Cena+6L   5      �� 5   
   -   5        $��btnDodaj��5      $��Dodaj��6!   $
��Left=�61   $��409,183,0,0q�6L   $	��Top=�6a   $��75��6y   6�   �� 5   
   -   5        $��	btnIzmeni��5      $��Izmeni��6"   $
��Left=�63   $��409,218,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5   
   -   5        $��	btnObrisi��5      $��Obrisi��6"   $
��Left=�63   $��409,253,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5    
   -   5        $��btnUslugaDodaj��5       $��Dodaj��6'   $
��Left=�67   $��409,352,0,0q�6R   $	��Top=�6g   $��75��6   6�   �� 5!   
   -	   5        $��btnUslugaObrisi��5!      $��Obrisi��6(   $
��Left=�69   $��409,387,0,0q�6T   $	��Top=�6i   $��75��6�   6�   �� 5"   
   -
   5        $��btnKupi��5"      $
��Kupi��6    $
��Left=�6/   $��409,432,0,0q�6J   $	��Top=�6_   $��75��6w   6�   5#      5$      
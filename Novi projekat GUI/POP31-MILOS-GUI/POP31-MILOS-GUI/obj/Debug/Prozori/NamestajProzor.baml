   M S B A M L   `   `   `  ����J  FPOP31-MILOS-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:POP31_MILOS_GUI.ProzoriPOP31_MILOS_GUI.Prozori  5   	   ,    &POP31_MILOS_GUI.Prozori.NamestajProzor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:POP31_MILOS_GUI.Prozori     5   	     � Title$  NamestajProzor��5   	   $	��370��6    $	��450��6-   
������.��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgNamestaj��5
      $��Stretch=�6%   $	��220��6C   $��5,5,5,0q�6P   $	��Top=�6a      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .     SelectionMode$ Single=�6     
IsReadOnly . 	   HeadersVisibility$	 Column=�6D  
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5      $ Naziv��6%   $ 1* 6N    64   �� *Naziv+6N     5      $ Sifra��6%   $ 1* 6T    64   ��  �� Path$ Sifra�6T     5      $ Jedinicna cena��6%   $ 1* 6_    6=   �� *JedinicnaCena+6_     5      $ Kolicina u magacinu��6%   $ 1* 6h    6B   �� *KolicinaUMagacinu+6h     5      $ Tip namestaja��6%   $ 1* 6c    6<   �� $ TipNamestaja�6c   5      �� 5   
   -   5        $��btnDodaj��5      $��Dodaj��6!   $
��Left=�61   $��
33,241,0,0q�6L   $	��Top=�6`   $��75��6x   6�   �� 5   
   -   5        $��	btnIzmeni��5      $��Izmeni��6"   $
��Left=�63   $��198,241,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5   
   -   5        $��	btnObrisi��5      $��Obrisi��6"   $
��Left=�63   $��341,241,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5   
   -   5        $��
tbPretraga��5      $
��Left=�6$   $��23��6?   $��
98,286,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��120��6�   6�   �� 5   
   $��	Pretraga:��6   $
��Left=�6$   $��
33,286,0,0q�6?   $	��Top=�6S   �� 5   
   -   5        $��cbIzbor��5       �� SelectedIndex$ 0��6"   $
��Left=�64   $��254,286,0,0q�6O   $	��Top=�6d   $	��120��6|   .@�5      �� .��6   Tip6    �� 5      .��6   Sifra6"   �� 5      .��6   Naziv6"   5      5      5      
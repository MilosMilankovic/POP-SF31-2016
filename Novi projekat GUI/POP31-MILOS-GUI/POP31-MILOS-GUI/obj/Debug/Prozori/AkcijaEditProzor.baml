   M S B A M L   `   `   `  ����J  FPOP31-MILOS-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:POP31_MILOS_GUI.ProzoriPOP31_MILOS_GUI.Prozori  5   	   .    (POP31_MILOS_GUI.Prozori.AkcijaEditProzor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:POP31_MILOS_GUI.Prozori     5   	     � Title$  AkcijaEditProzor��5   	   $	��500��6"   $	��500��6/   
������.��5	      � .+�5
   
   �� $��Naziv:��6   $
��Left=�6!   $��	52,19,0,0q�6<   $	��Top=�6O   �� 5   
   -   5        $��tbNaziv��5      $
��Left=�68   $��23��6S   $��
110,19,0,0q�6_    �� TextWrapping$
 Wrap=�6s   $	��Top=�6�   $	��120��6�   ��6!   �� *Naziv+6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��	dpPocetak��5         FirstDayOfWeek$ Monday=�6&   $
��Left=�6x   $��
203,89,0,0q�6�   $	��Top=�6�      SelectedDate 6>   �� *	Pocetak+ �� StringFormat$ 
dd/MM/yyyy��6�     5   
   -   5        $��dpKraj��5      $ Monday=�6#   $
��Left=�6r   $��203,143,0,0q�6�   $	��Top=�6�    6;   �� *Kraj+$ 
dd/MM/yyyy��6�   �� 5   
   $��Datum pocetka:��6   $
��Left=�6)   $��	52,87,0,0q�6D   $	��Top=�6W   �� 5   
   $��Datum kraja��6   $
��Left=�6&   $��
52,141,0,0q�6A   $	��Top=�6U   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgPar��5      $��Stretch=�6    $��15,174,188.6,96.4q�6>   $	��200��6Y      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .  	   CanUserResizeColumns	 .  
   CanUserResizeRows
 .     SelectionMode$ Single=�6     
IsReadOnly .    HeadersVisibility$ Column=�61     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
NamestajId+6P     5      $ Naziv��6%   $ 1* 6W    64   �� *Namestaj.Naziv+6W     5      $ Popust��6%   $ 1* 6P    65   �� *Popust+6P   5      �� 5   
   -   5        $��btnDodaj��5      $��Dodaj��6!   $
��Left=�61   $��393,233,0,0q�6L   $	��Top=�6a   $��75��6y   6�   �� 5   
   -   5        $��	btnObrisi��5      $��Obrisi��6"   $
��Left=�63   $��393,300,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5   
   -   5        $��btnOk��5      $��Ok��6   $
��Left=�6+   $��
71,421,0,0q�6F   $	��Top=�6Z   $��75��6r   6}   �� 5   
   -   5        $��	btnCancel��5      $��Cancel��6"   $
��Left=�63   $��342,421,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5   
   -	   5        $��	btnIzmeni��5      $��Izmeni��6"   $
��Left=�63   $��393,276,0,0q�6N   $	��Top=�6c   $��75��6{   6�   5      5      
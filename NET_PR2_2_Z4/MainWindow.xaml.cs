using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NET_PR2_2_Z4;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	KontrolerKalkulatora Kontroler = new();
	public MainWindow()
	{
		DataContext= Kontroler;
		InitializeComponent();
	}

	private void Cyfra(object sender, RoutedEventArgs e)
	{
		Kontroler.WprowadźCyfrę(
			((Button)sender).Content.ToString()
			);
	}

	private void Znak(object sender, RoutedEventArgs e)
	{
		Kontroler.ZmieńZnak();
	}

	private void Przecinek(object sender, RoutedEventArgs e)
	{
		Kontroler.WprowadźPrzecinek();
	}

	private void KasowanieZnaku(object sender, RoutedEventArgs e)
	{
		Kontroler.SkasujZnak();
	}

	private void CzyszczenieWyniku(object sender, RoutedEventArgs e)
	{
		Kontroler.WyczyśćWynik();
	}

	private void Czyszczenie(object sender, RoutedEventArgs e)
	{
		Kontroler.WyczyśćWszystko();
	}

	private void DziałanieDwuargumentowe(object sender, RoutedEventArgs e)
	{
		Kontroler.WprowadźDziałanieDwuargumentowe(
			((Button)sender).Content.ToString()
			);
	}

	private void RównaSię(object sender, RoutedEventArgs e)
	{
		Kontroler.WykonajDziałanie();
	}

	private void DziałanieJednoargumentowe(object sender, RoutedEventArgs e)
	{
		Kontroler.WykonajDziałanieJednoargumentowe(
			((Button)sender).Content.ToString()
			);
	}

    private void Odejmowanie_Click(object sender, RoutedEventArgs e)
    {
        Kontroler.WprowadźDziałanieDwuargumentowe(
            ((Button)sender).Content.ToString()
            );

    }

    private void Mnozenie_Click(object sender, RoutedEventArgs e)
    {
        Kontroler.WprowadźDziałanieDwuargumentowe(
            ((Button)sender).Content.ToString()
            );
    }

    private void Potegowanie(object sender, RoutedEventArgs e)
    {
        Kontroler.WprowadźDziałanieDwuargumentowe(
            ((Button)sender).Content.ToString()
            );
    }

    private void Modulo(object sender, RoutedEventArgs e)
    {
        Kontroler.WprowadźDziałanieDwuargumentowe(
           ((Button)sender).Content.ToString()
           );
    } private void Pierwiastek(object sender, RoutedEventArgs e)
    {
        Kontroler.WykonajDziałanieJednoargumentowe(
            ((Button)sender).Content.ToString()
            );
    }

    private void Silnia(object sender, RoutedEventArgs e)
    {
        Kontroler.WykonajDziałanieJednoargumentowe(
          ((Button)sender).Content.ToString()
          );
    }
    private void ObliczanieLog10(object sender, RoutedEventArgs e)
    {
        Kontroler.WykonajDziałanieJednoargumentowe(
          ((Button)sender).Content.ToString()
          );
    }
    private void ObliczanieLog(object sender, RoutedEventArgs e)
    {
        Kontroler.WykonajDziałanieJednoargumentowe(
          ((Button)sender).Content.ToString()
          );
    }
    private void ObliczanieLog2(object sender, RoutedEventArgs e)
    {
        Kontroler.WykonajDziałanieJednoargumentowe(
          ((Button)sender).Content.ToString()
          );
    }
    private void ObliczanieFloor(object sender, RoutedEventArgs e)
    {
        Kontroler.WykonajDziałanieJednoargumentowe(
          ((Button)sender).Content.ToString()
          );
    }
    private void ObliczanieCeil(object sender, RoutedEventArgs e)
    {
        Kontroler.WykonajDziałanieJednoargumentowe(
          ((Button)sender).Content.ToString()
          );
    }
}

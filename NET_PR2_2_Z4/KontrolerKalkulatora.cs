using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;

namespace NET_PR2_2_Z4;
internal class KontrolerKalkulatora : INotifyPropertyChanged
{
	private double?
		lewyArgument = null,
		prawyArgument = null
		;
	private string?
		buforDziałania = null,
		wynik = "0"
		;
	private bool
		flagaDziałania = false
		;

	public string Wynik {
		get => wynik;
		set { 
			wynik = value;
			PropertyChanged?.Invoke(
				this,
				new PropertyChangedEventArgs("Wynik")
				);
		}
	}
	public string Bufory
	{
		get
		{
			if (lewyArgument == null)
				return "";
			else if (buforDziałania == null)
				return $"{lewyArgument}";
			else if (prawyArgument == null)
				return $"{lewyArgument} {buforDziałania}";
			else
				return $"{lewyArgument} {buforDziałania} {prawyArgument} =";
		}
	}
	internal void WprowadźCyfrę(string cyfra)
	{
		if (flagaDziałania)
			Wynik = "0";
        flagaDziałania = false;
        if (Wynik == "0")
			Wynik = cyfra;
		else
			Wynik += cyfra;
	}
	internal void ZmieńZnak()
	{
		if(flagaDziałania)
			Wynik= "0";
		if (Wynik == "0")
			return;
		else if (Wynik[0] == '-')
			Wynik = Wynik.Substring(1);
		else
			Wynik = "-" + Wynik;
	}
	internal void WprowadźPrzecinek()
	{
		if (flagaDziałania)
			Wynik = "0";
		if (Wynik.Contains(','))
			return;
		else
			Wynik += ",";
	}

	internal void SkasujZnak()
	{
		if (flagaDziałania)
			Wynik = "0";
		if (Wynik == "0")
			return;
		else if (
			Wynik == "-0,"
			|| Wynik.Length == 1
			|| (Wynik.Length == 2 && Wynik[0] == '-')
			)
			Wynik = "0";
		else
			Wynik = Wynik.Substring(0,Wynik.Length-1);
	}

	internal void WyczyśćWynik()
	{
		Wynik = "0";
	}

	internal void WyczyśćWszystko()
	{
		WyczyśćWynik();
		lewyArgument = prawyArgument = null;
		buforDziałania = null;
		PropertyChanged?.Invoke(
			this,
			new PropertyChangedEventArgs("Bufory")
			);
	}

	internal void WprowadźDziałanieDwuargumentowe(string? działanie)
	{
		if (lewyArgument == null)
		{
			lewyArgument = Convert.ToDouble(Wynik);
			buforDziałania = działanie;
			PropertyChanged?.Invoke(
				this,
				new PropertyChangedEventArgs("Bufory")
				);
			wynik = "0";
		}
		else if(buforDziałania == null)
		{
			buforDziałania = działanie;
			PropertyChanged?.Invoke(
				this,
				new PropertyChangedEventArgs("Bufory")
				);
			wynik = "0";
		}
		else
		{
			prawyArgument = Convert.ToDouble(Wynik);
			/*PropertyChanged?.Invoke(
				this,
				new PropertyChangedEventArgs("Bufory")
				);*/
			WykonajDziałanie();
			//jakaś flaga?
			prawyArgument = null;
		}
	}

	public void WykonajDziałanie()
	{
		if(prawyArgument == null)
			prawyArgument = Convert.ToDouble(Wynik);
		PropertyChanged?.Invoke(
			this,
			new PropertyChangedEventArgs("Bufory")
			);
        if (buforDziałania == "+")
            Wynik = $"{lewyArgument + prawyArgument}";
        else if (buforDziałania == "-")
            Wynik = $"{lewyArgument - prawyArgument}";
        else if (buforDziałania == "×") 
            Wynik = $"{lewyArgument * prawyArgument}";
        else if (buforDziałania == "÷")
            Wynik = $"{lewyArgument / prawyArgument}";
		else if(buforDziałania == "xʸ")
        {
            double podstawa = lewyArgument ?? 0; 
            double wykładnik = prawyArgument ?? 0; 
            Wynik = $"{Math.Pow(podstawa, wykładnik)}";
        }
		else if (buforDziałania == "%")
		{
			Wynik = $"{lewyArgument % prawyArgument}";

		}
      
        lewyArgument = Convert.ToDouble(Wynik);
        flagaDziałania = true;
    }

	internal void WykonajDziałanieJednoargumentowe(string? działanie)
	{
		if(lewyArgument == null)
			lewyArgument = Convert.ToDouble(Wynik);
		if (działanie == "1/x")
			lewyArgument = 1 / lewyArgument;
        else if(działanie == "√"){
            double podstawa = lewyArgument ?? 0;
            lewyArgument = Math.Sqrt(podstawa);
        }
		else if (działanie == "!")
        {

            double podstawa = lewyArgument ?? 0;
            double wynikSilni = ObliczSilnię((int)podstawa);
		
            lewyArgument = wynikSilni;

        }
        else if (działanie == "log10")
        {
            double podstawa = lewyArgument ?? 0;
            lewyArgument = ObliczLogarytm10(podstawa);
        }
        else if (działanie == "ln")
        {
            double podstawa = lewyArgument ?? 0;
            lewyArgument = ObliczLogarytmNaturalny(podstawa);
        }
        else if (działanie == "log2")
        {
            double podstawa = lewyArgument ?? 0;
            lewyArgument = ObliczLogarytmBinarny(podstawa);
        }
        else if (działanie == "Floor")
        {
            double podstawa = lewyArgument ?? 0;
            lewyArgument = ObliczPodłogę(podstawa);
        }
        else if (działanie == "Ceil")
        {
            double podstawa = lewyArgument ?? 0;
            lewyArgument = ObliczSufit(podstawa);
        }


        Wynik = $"{lewyArgument}";
		flagaDziałania = true;
		buforDziałania = null;
		prawyArgument = null;
		PropertyChanged?.Invoke(
			this,
			new PropertyChangedEventArgs("Bufory")
			);
	}

    private int ObliczSilnię(int liczba)
    {
        if (liczba < 0)
        {
       
            throw new ArgumentException("Silnia jest zdefiniowana tylko dla liczb całkowitych nieujemnych.");
        }
        else if (liczba == 0)
        {
            // Silnia dla 0 == 0
            return 1;
        }
        else
        {
          
            int wynik = 1;
            for (int i = 1; i <= liczba; i++)
            {
                wynik *= i;
            }
            return wynik;
        }
    }

    private double ObliczLogarytm10(double liczba)
    {
        if (liczba <= 0)
        {
            throw new ArgumentException("Logarytm jest zdefiniowany tylko dla liczb dodatnich.");
        }
        return Math.Log10(liczba);
    }

    private double ObliczLogarytmNaturalny(double liczba)
    {
        if (liczba <= 0)
        {
            throw new ArgumentException("Logarytm jest zdefiniowany tylko dla liczb dodatnich.");
        }
        return Math.Log(liczba);
    }

    private double ObliczLogarytmBinarny(double liczba)
    {
        if (liczba <= 0)
        {
            throw new ArgumentException("Logarytm jest zdefiniowany tylko dla liczb dodatnich.");
        }
        return Math.Log(liczba, 2);
    }
    private double ObliczPodłogę(double liczba)
    {
        return Math.Floor(liczba);
    }

    private double ObliczSufit(double liczba)
    {
        return Math.Ceiling(liczba);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}

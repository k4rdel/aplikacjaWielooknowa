using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace aplikacjaWielooknowa
{
    public class Lektura
    {
        public string Tytul { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public KtoraKlasa Klasa { get; set; } = 0;
        public Lektura()
        {

        }
        public Lektura(string tytul, string autor, KtoraKlasa klasa)
        {
            Tytul = tytul;
            Autor = autor;
            Klasa = klasa;
        }
        public override string ToString()
        {
            return Tytul + " " + Autor + " " + Klasa.ToString();
        }
    }

    public enum KtoraKlasa
    {
        pierwsza = 0,
        druga = 1,
        trzecia = 2,
        czwarta = 3,
        piata = 5
    }

    internal class ListaLektur
    {
        public ObservableCollection<Lektura> lektury;
        public ListaLektur()
        {
            lektury = new ObservableCollection<Lektura>();
        }
        public void DodajLekture(Lektura lektura)
        {
            lektury.Add(lektura);
        }
        public void UsunLekture(Lektura lektura)
        {
            lektury.Remove(lektura);
        }
        public void EdytujLekture(int index, Lektura lektura)
        {
            lektury[index] = lektura;
        }
        public void UsunLektureNa(int index)
        {
            if(index >= 0 && index < lektury.Count)
            {
                lektury.RemoveAt(index);    
            }
        }
        public void ZaladujLektury()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                lektury.Clear();
                string[] lines = File.ReadAllLines(openFileDialog.FileName);
                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string tytul = parts[0];
                        string autor = parts[1];
                        if (Enum.TryParse(parts[2], out KtoraKlasa klasa))
                        {
                            lektury.Add(new Lektura(tytul, autor, klasa));
                        }
                    }
                }
            }
        }
        public void ZapiszLektury()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (var lektura in lektury)
                    {
                        writer.WriteLine($"{lektura.Tytul},{lektura.Autor},{lektura.Klasa}");
                    }
                }
            }
        }
    }
}


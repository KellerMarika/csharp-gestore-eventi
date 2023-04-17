using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Conferenza : Evento
    {
        private string relatore;

        public string Relatore
        {
            get => relatore;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) relatore = value;
                else throw new Exception($"il nominativo del relatore inserito '{value}' non è valido");
            }
        }
        private double prezzo;
        public string Prezzo
        {
            get => prezzo.ToString("F2") + " euro";
            set
            {
                try
                {
                    prezzo = Convert.ToDouble (value);
                }
                catch (Exception)
                {
                    throw new Exception($"'{value}' non è un dato valido"); ;
                } 
            }
        }
        

        public Conferenza(string _titolo, DateTime _data, int _capienza, string _relatore, double _prezzo) : base(_titolo, _data, _capienza)
        {
            Relatore = _relatore;
            Prezzo = _prezzo.ToString("F2");
        }
        public Conferenza(string _titolo, DateTime _data, int _capienza, string _relatore, int _prezzo) : base(_titolo, _data, _capienza)
        {
            Relatore = _relatore;
            Prezzo = _prezzo.ToString("F2");
        }

        public string getData() =>Data.ToString("dd/M/yyyy");
        public string getTime() => Data.ToString("HH:mm");

        public override string ToString()
        {
            return base.ToString() +" - " + Relatore +" - "+ Prezzo;
        }

    }

}

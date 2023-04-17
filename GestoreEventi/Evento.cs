using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Evento
    {
        private string titolo;
        public string Titolo {
            get => titolo;     
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) titolo = value;
                else Console.WriteLine($"'{value}' non è un dato valido");
            }
        }
        private DateTime data;
        public DateTime Data
        {
            get => data;
            set
            {
                var data_corrente = DateTime.Now;
                if (data_corrente < value) data = value;
                else Console.WriteLine($"'{value.ToString("dd/MM/yyyy")}' data inserita già passata");
            }
        }

        private int capienza;
        public int Capienza { get => capienza;
            private set
            {
                if (value > 0) capienza = value;
                else Console.WriteLine($"il valore '{value}' inserito per la capienza dell'evento è minore di 0!");
            }
        }
        public int Prenotazioni { get; private set;}


        public int GetDisponibilita() => Capienza - Prenotazioni;

        public Evento(string _titolo, DateTime _data, int _capienza)
        {
            Titolo = _titolo;
            Data = _data;
            Capienza = _capienza;
        }

        public void PrenotaPosti()
        {
            if(Capienza != Prenotazioni)
            {
                Console.Write($"Ci sono {GetDisponibilita()} posti disponibili alla prenotazione. Quanti desideri prenotarne?");
                int posti = Convert.ToInt32(Console.ReadLine());

                if (posti > 0)
                {
                    if (posti <= GetDisponibilita())
                    {
                        Prenotazioni += posti;
                        Console.WriteLine($"'{posti}' prenotazioni effettuate correttamente. posti ancora disponibili: {GetDisponibilita()}");
                    }
                    else
                    {
                        Console.WriteLine($"I posti disponibili sono {GetDisponibilita()}. Si desidera prenotarli tutti?(si|no)");
                        string confirmDelete = Console.ReadLine();
                        if (confirmDelete == "si")
                        {
                            Prenotazioni = Capienza;
                            Console.WriteLine("l'evento è tutto Esaurito!");
                        }
                        else Console.WriteLine("nessuna prenotazione fatta");
                    }
                }
                else Console.WriteLine($"Attenzione: il numero di posti inserito '{posti}' è negativo. nessuna prenotazione portata a termine");
            }
            else Console.WriteLine("Spiacenti, l'evento è tutto Esaurito!");
        }

        public void DisdiciPosti()
        {
            if(Prenotazioni != 0)
            {
                Console.Write($"Ci sono {Prenotazioni} posti prenotati. Quanti desideri Disdirne?");
                int posti = Convert.ToInt32(Console.ReadLine());

                if (posti > 0)
                {
                    if (posti <= Prenotazioni)
                    {
                        Prenotazioni -= posti;
                        Console.WriteLine($"'{posti}' prenotazioni disdette correttamente. ne restano {Prenotazioni}");
                    }
                    else
                    {
                        Console.WriteLine($"I posti prenotati sono {Prenotazioni}. Disdire tutte le prenotazioni?(si|no)");
                        string confirmDelete = Console.ReadLine();
                        if (confirmDelete == "si")
                        {
                            Prenotazioni = 0;
                            Console.WriteLine("le prenotazioni sono azzerate");
                        }
                        else Console.WriteLine("nessuna prenotazione disdetta");
                    }
                }
                else Console.WriteLine($"Attenzione: il numero di posti inserito '{posti}' non è valido. nessuna preotazione è stata disdetta!");
            }
            else { Console.WriteLine("spiacente, non ci sono prenotazioni da cancellare!"); }

        }

        public override string ToString()=> Titolo + " - " + Data.ToString("dd/MM/yyyy");
    }
}

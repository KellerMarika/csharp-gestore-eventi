using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class ProgrammaEventi
    {
        private string titolo;
        public string Titolo
        {
            get => titolo;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) titolo = value;
                else Console.WriteLine($"'{value}' non è un dato valido");
            }
        }

        public List <Evento> Eventi { get; private set; }


        public ProgrammaEventi(string _titolo)
        {
            Titolo = _titolo;
            Eventi = new List <Evento>();
        }


        public void AddEvent(Evento evento)=> Eventi.Add(evento);

        public List<Evento> FiltredEventsByDate(DateTime data)
        {
            List<Evento> filtredList = new List <Evento>();  
            foreach (var evento in Eventi)
            {
                if (evento.Data == data)
                 filtredList.Add(evento);               
            }
            return filtredList;
        }

        public static string GetEvents(List<Evento> events)
        {
            if (events.Count() == 0) return "spiacente, non ci sono eventi in programma per la data inserita!";
            else
            {
                string[] overvieusArray = new string[events.Count()];

                for (int i = 0; i < events.Count(); i++)
                {
                    overvieusArray[i] = "Evento n#" + i + ": " + events[i].ToString() + " -  prenotati " + events[i].Prenotazioni + "/" + events[i].Capienza;
                }
                return String.Join(", ", overvieusArray);
            }
        }

        public int GetEventsCount() => Eventi.Count();
        
        public void ClearEvents()=>  Eventi.Clear();

        public string GetResume()
        {
            string[] overvieusArray = new string[Eventi.Count()];

   
            if (Eventi.Count() > 0)
            {
                for (int i = 0; i < Eventi.Count(); i++)
                {
                    overvieusArray[i] = "Evento n#" + i + ": " + Eventi[i].ToString() + " -  prenotati " + Eventi[i].Prenotazioni + "/" + Eventi[i].Capienza;
                }
                return titolo.ToUpper() + ": " + String.Join(", ", overvieusArray);
            }
            else return titolo.ToUpper() + ": non ci sono eventi in programma!";
        }
    }
}

using System.Security.Cryptography;

namespace GestoreEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Crea un evento.");
            //Console.Write("Inserisci il Titolo dell'evento:");
            //string t1=Console.ReadLine();

            ////bisognerebbe effettuare un controllo anche sui dati inseriti per creare la data
            //int[] d1= new int[3];

            //Console.WriteLine("Scegli la Data");
            //Console.Write("giorno: ");
            //d1[2]=Convert.ToInt32(Console.ReadLine());
            //Console.Write("Mese: ");
            //d1[1] = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Anno: ");
            //d1[0] = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Scegli la Capienza del tuo evento:");
            //int c1 = Convert.ToInt32(Console.ReadLine());

            //Evento e1= new Evento(t1, new DateTime(d1[0], d1[1], d1[2]), c1);

            Evento e1 = new Evento("evento1", new DateTime(2023, 7, 12), 10);

            //Console.WriteLine(e1.Titolo);
            //Console.WriteLine(e1.ToString());
            //Console.WriteLine(e1.Data);
            //Console.WriteLine("capienza: "+e1.Capienza);
            //Console.WriteLine("disponibilità "+e1.GetDisponibilita());


            //Console.WriteLine("desidere effettuare ina prenotazione o disdirne una? (p|d)");
            //string resp1 = Console.ReadLine();
            //if (resp1 == "p") e1.PrenotaPosti();
            //else if (resp1 == "d") e1.DisdiciPosti();

            //Console.WriteLine("capienza: " + e1.Capienza);
            //Console.WriteLine("prenotazioni "+e1.Prenotazioni);
            //Console.WriteLine("disponibilità " + e1.GetDisponibilita());

            //Console.WriteLine("desidere effettuare ina prenotazione o disdirne una? (p|d)");
            //string resp2 = Console.ReadLine();
            //if (resp2 == "p") e1.PrenotaPosti();
            //else if (resp2 == "d") e1.DisdiciPosti();

            //Console.WriteLine("capienza: " + e1.Capienza);
            //Console.WriteLine("prenotazioni " + e1.Prenotazioni);
            //Console.WriteLine("disponibilità " + e1.GetDisponibilita());


                  
            var data = new DateTime(2023, 7, 12);
  
            ProgrammaEventi myProgram= new ProgrammaEventi("Programma eventi");
            myProgram.AddEvent(e1);
            myProgram.AddEvent(new Evento("evento2", new DateTime(2023, 4, 30), 20));
            myProgram.AddEvent (new Evento("evento3", new DateTime(2023, 7, 12), 30));


            List<Evento> filtredList = myProgram.FiltredEventsByDate(new DateTime(2023, 7, 12));

            foreach (var item in filtredList)
            {
                //Console.WriteLine(item.ToString());
                //Console.WriteLine(item.GetDisponibilita());
            }

            string overview = ProgrammaEventi.GetEvents(filtredList);
            Console.WriteLine(overview);

            Console.WriteLine( myProgram.GetEventsCount());
            myProgram.ClearEvents();
            Console.WriteLine( myProgram.GetEventsCount());

            Console.WriteLine( myProgram.GetResume());
 

        }
    }
}
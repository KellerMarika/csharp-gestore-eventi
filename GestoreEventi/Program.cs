using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace GestoreEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MILESTONE 2 -------------------------------------------------------
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


            ////Console.WriteLine(e1.Titolo);
            ////Console.WriteLine(e1.ToString());
            ////Console.WriteLine(e1.Data);
            ////Console.WriteLine("capienza: "+e1.Capienza);
            ////Console.WriteLine("disponibilità "+e1.GetDisponibilita());


            //Console.WriteLine("desidere effettuare ina prenotazione o disdirne una? (p|d)");
            //string resp1 = Console.ReadLine();
            //if (resp1 == "p") e1.PrenotaPosti();
            //else if (resp1 == "d") e1.DisdiciPosti();

            //Console.WriteLine("capienza: " + e1.Capienza);
            //Console.WriteLine("prenotazioni "+e1.Prenotazioni);
            //Console.WriteLine("disponibilità " + e1.GetDisponibilita());


            //MILESTONE 4 --------------------------------------------------------------------


            Console.WriteLine("MILESTONE 4 -----------------------");
            Console.WriteLine("Inserisci un titolo per il tuo Programma di Eventi");
            string ProgramTitle=Console.ReadLine();
            ProgrammaEventi userEventProgram= new ProgrammaEventi(ProgramTitle);
            Console.WriteLine($"quanti eventi desideri aggiungere al programma '{userEventProgram.Titolo}'?");
            int ProgramEventsCount;
            int.TryParse(Console.ReadLine(), out ProgramEventsCount);

            while (userEventProgram.GetEventsCount()< ProgramEventsCount)
            {
                Console.WriteLine($"Crea il tuo {userEventProgram.GetEventsCount()+1}° evento");
                Console.Write("Inserisci il Titolo dell'evento:");
                string t1 = Console.ReadLine();

                //bisognerebbe effettuare un controllo anche sui dati inseriti per creare la data
                int[] d1 = new int[3];

                Console.WriteLine("Scegli la Data");
                Console.Write("giorno: ");
                d1[2] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Mese: ");
                d1[1] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Anno: ");
                d1[0] = Convert.ToInt32(Console.ReadLine());

                Console.Write("Scegli la Capienza del tuo evento:");
                int c1 = Convert.ToInt32(Console.ReadLine());


                try
                {
                    Evento e1 = new Evento(t1, new DateTime(d1[0], d1[1], d1[2]), c1);
                    userEventProgram.AddEvent(e1);
                    Console.WriteLine("EVENTO CREATO CORRETTAMENTE!");
                }
                catch (Exception e)
                {
                    // write to my error log
                    Console.WriteLine("errore: " + e.Message, e.InnerException);
                    Console.WriteLine("OPERAZIONE FALLITA");
                }
              //  finally { Console.WriteLine("EVENTO CREATO CORRETTAMENTOE!"); }

                }
            Console.WriteLine("numero di eventi inseriti: "+userEventProgram.GetEventsCount());
            Console.WriteLine(userEventProgram.GetResume());

            Console.WriteLine("ricerca eventi per data:");
            int[] df = new int[3];

            Console.Write("giorno: ");
            df[2] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Mese: ");
            df[1] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Anno: ");
            df[0] = Convert.ToInt32(Console.ReadLine());

          var data = new DateTime(df[0], df[1], df[2]); 

          List<Evento> filtredList = userEventProgram.FiltredEventsByDate(data);
       
            Console.WriteLine($"ci sono {filtredList.Count()}  Eventi presenti in {userEventProgram.Titolo} che avvengono in data: {data.ToString()}");
            Console.WriteLine(ProgrammaEventi.GetEvents(filtredList));
            userEventProgram.ClearEvents();
        


        }
    }
}
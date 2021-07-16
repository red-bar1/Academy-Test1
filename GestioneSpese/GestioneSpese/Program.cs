using GestioneSpese.Entities;
using GestioneSpese.Factory;
using GestioneSpese.Handler;
using System;
using System.Collections.Generic;
using System.IO;

namespace GestioneSpese
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher fsw = new FileSystemWatcher();

            fsw.Path = @"C:\Users\giulia.tuttobene\Desktop\Academy\Academy 1\CartellaMonitorata";

            //ogni file .txt in path verrà monitorato
            fsw.Filter = "*.txt"; 

            fsw.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            fsw.EnableRaisingEvents = true;

            //Iscrizione all'evento created
            fsw.Created += GestoreWatcher.GestisciFileSpese;
            List<ISpesa> spese = GestoreFile.LoadFromFile();

            Console.ReadKey();

            Console.WriteLine("Inizia la Chain of Responsability");
            var manager = new ManagerHandler();
            var operationalManager = new OperationalManagerHandler();
            var ceo = new CEOHandler();

            //Creo la catena degli handler
            manager.SetNext(operationalManager).SetNext(ceo);

            List<ISpesa> speseApprovate = null;
            foreach (var item in spese)
            {
                var result = manager.Handle(item.Prezzo);
                if (result != null)
                {
                    Console.WriteLine($"\t {result}");
                    if(!result.Equals("Spesa non approvata"))
                    {
                        item.Livello = result;
                        speseApprovate.Add(item);
                    }
                    item.Livello = "Respinta";
                }
            }

            FactorySpese factory = new FactorySpese();
            List<double> rimborsi = factory.GetRimborso(speseApprovate);
            for (int i =0; i<rimborsi.Count; i++)
            {
                Console.WriteLine($"{speseApprovate[i]} - Rimborso: {rimborsi[i]}");
            }

            GestoreFile.SaveFile(spese);
            //ho letto dopo che i rimborsi andavano stampati, li avrei aggiunti come proprietà delle singole spese




        }
    }
}

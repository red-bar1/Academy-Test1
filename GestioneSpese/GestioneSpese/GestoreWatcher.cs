using GestioneSpese.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese
{
    class GestoreWatcher
    {
        public static void GestisciFileSpese(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("E' stato creato un file di nome: {0}", e.Name);
            try
            {
                //Lettura da file
                using (StreamReader reader = File.OpenText(e.FullPath))
                {
                    
                    Console.WriteLine($"Contenuto del file {e.Name}");
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] values = line.Split(";");

                        if (values[1].Equals("Alloggio"))
                        {
                            ISpesa spesa = new SpesaAlloggio
                            {
                                Data = DateTime.Parse(values[0]),
                                Descrizione = values[2],
                                Prezzo = double.Parse(values[3])
                            };
                            Console.WriteLine(spesa);
                            
                        }
                        else if (values[1].Equals("Vitto"))
                        {
                            ISpesa spesa = new SpesaVitto
                            {
                                Data = DateTime.Parse(values[0]),
                                Descrizione = values[2],
                                Prezzo = double.Parse(values[3])
                            };
                            Console.WriteLine(spesa);
                            
                        }
                        else if (values[1].Equals("Viaggio"))
                        {
                            ISpesa spesa = new SpesaViaggio
                            {
                                Data = DateTime.Parse(values[0]),
                                Descrizione = values[2],
                                Prezzo = double.Parse(values[3])
                            };
                            Console.WriteLine(spesa);
                            
                        }
                        else
                        {
                            ISpesa spesa = new SpesaAltro
                            {
                                Data = DateTime.Parse(values[0]),
                                Descrizione = values[2],
                                Prezzo = double.Parse(values[3])
                            };
                            Console.WriteLine(spesa);
                            
                        }
                        
                        line = reader.ReadLine();
                    }

                    Console.WriteLine("\nFine del file");
                    Console.WriteLine("\n");
                    
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }

        }
    }
}

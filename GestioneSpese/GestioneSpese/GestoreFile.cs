using GestioneSpese.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese
{
    public static class GestoreFile
    {
        public static List<ISpesa> LoadFromFile()
        {
            try
            {
                //Lettura da file
                using (StreamReader reader = File.OpenText(@"C:\Users\giulia.tuttobene\Desktop\Academy\Academy 1\ElencoDelleSpese.txt"))
                {
                    List<ISpesa> spese = null;
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
                           
                            spese.Add(spesa);

                        }
                        else if (values[1].Equals("Vitto"))
                        {
                            ISpesa spesa = new SpesaVitto
                            {
                                Data = DateTime.Parse(values[0]),
                                Descrizione = values[2],
                                Prezzo = double.Parse(values[3])
                            };
                            

                        }
                        else if (values[1].Equals("Viaggio"))
                        {
                            ISpesa spesa = new SpesaViaggio
                            {
                                Data = DateTime.Parse(values[0]),
                                Descrizione = values[2],
                                Prezzo = double.Parse(values[3])
                            };
                            

                        }
                        else
                        {
                            ISpesa spesa = new SpesaAltro
                            {
                                Data = DateTime.Parse(values[0]),
                                Descrizione = values[2],
                                Prezzo = double.Parse(values[3])
                            };
                        }

                        line = reader.ReadLine();
                    }
                    return spese;
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;    
            }
        } 


        public static void SaveFile(List<ISpesa> spese, List<ISpesa> speseApprovate)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(@"C:\Users\giulia.tuttobene\Desktop\Academy\Academy 1\spese_elaborate.txt"))
                {
                    foreach (var item in spese)
                    {
                        if (speseApprovate.Contains(item))
                        {
                            writer.WriteLine($"Data: {item.Data.ToShortDateString()};" +
                                $"Categoria: {item.Categoria};" +
                                $"{item.Descrizione};" +
                                $"APPROVATA;" +
                                $"{item.Livello};");
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}

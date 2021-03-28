using ConsoleApp1.Db;
using ConsoleApp1.Models;
using System;
using System.Linq;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1 {
    class Program {
        private static readonly Random random = new Random();
        static void Main(string[] args) {
            MainProcedure mainProcedure = new ();

            var repository = new MySQLWaifusRepository();
            var repositoryMongo = new MongoDBWaifusRepository();

            mainProcedure.mainTask(repositoryMongo);
        }

        class MainProcedure {
            public void mainTask(IWaifusRepository waifusRepository) {
                int opc = 0;

                do {
                    Console.Clear();
                    Console.WriteLine("1.- Añadir Waifu");
                    Console.WriteLine("2.- Obtener Waifus");
                    opc = Int32.Parse(Console.ReadLine());

                    switch (opc) {
                        case 1: {
                                string name = "", anime = "";

                                Console.Write("Nombre: ");
                                name = Console.ReadLine();
                                Console.Write("Source: ");
                                anime = Console.ReadLine();

                                waifusRepository.CreateWaifu( 
                                    new() {
                                        Id = random.Next(1, 5000),
                                        Name = name,
                                        Source = anime,
                                    } 
                                );
                                break;
                            }
                        case 2: {
                                foreach (var waifu in waifusRepository.GetWaifus()) {
                                    Console.WriteLine(waifu);
                                }
                                Console.ReadKey();
                                break;
                            }
                    }

                } while (opc != 3);
            }
        }
    }
}

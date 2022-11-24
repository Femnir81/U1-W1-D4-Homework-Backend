using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_W1_D4_Homework_Backend
{
    internal static class Utente
    {
        private static string User { get; set; } = "Luchino";
        private static string Password { get; set; } = "prova";
        private static bool Logged { get; set; } = false;
        private static List<Accesso> ListaDegliAccessi { get; set; } = new List<Accesso>();
        private static DateTime UltimoAccesso { get; set; }

        public static void Menu()
        {
            Console.WriteLine("1) Login:");
            Console.WriteLine("2) Logout:");
            Console.WriteLine("3) Verifica ora e data di login:");
            Console.WriteLine("4) Lista degli accessi:");
            Console.WriteLine("5) Esci:");

            string scelta = Console.ReadLine();

            if (scelta == "1")
            {
                Login();
            }
            else if (scelta == "2")
            {
                Logout();
            }
            else if (scelta == "3")
            {
                VerificaDataAccesso();
            }
            else if (scelta == "4")
            {
                ListaAccessi();
            }
            else if (scelta == "5")
            {
                Exit();
            }
            else
            {
                Console.WriteLine("Hai digitato il numero sbagliato");
                Menu();
            }
        }

        private static void Login() {
            if (Logged == false)
            {
                Console.WriteLine("Digita il tuo nome utente:");
                string nomeUser = Console.ReadLine();
                if (User != nomeUser)
                {
                    Console.WriteLine("Hai digitato il nome sbagliato.");
                    Login();
                }
                Console.WriteLine("Digita la tua password:");
                string nomePassword = Console.ReadLine();
                if (Password != nomePassword)
                {
                    Console.WriteLine("Hai digitato la password sbagliata.");
                    Login();
                }
                Console.WriteLine("Digita nuovamente la tua password");
                string confermaPassword = Console.ReadLine();
                if (confermaPassword != nomePassword)
                {
                    Console.WriteLine("Hai digitato la password sbagliata.");
                    Login();
                }
                Logged = true;
                UltimoAccesso = DateTime.Now;
                Accesso accessoIniziale= new Accesso();
                accessoIniziale.DataLogin = UltimoAccesso;
                ListaDegliAccessi.Add(accessoIniziale);
                Menu();
            } else
            {
                Console.WriteLine("Sei già loggato");
                Console.WriteLine("");
                Menu();
            }
        }

        private static void Logout() {
            {
                if (Logged == true)
                {
                    Logged = false;
                }
                else
                {
                    Console.WriteLine("Non sei ancora loggato");
                    Console.WriteLine("");                    
                }
                Menu();
            }
        }
        private static void VerificaDataAccesso() {
            if (Logged == true)
            {
                DateTime ora = DateTime.Now;
                TimeSpan tempoTrascorso = ora.Subtract(UltimoAccesso);
                Console.WriteLine($"Il tuo ultimo accesso risale al {UltimoAccesso} e sei connesso da {Math.Round(tempoTrascorso.TotalSeconds)} secondi");
                Console.WriteLine("");
                Menu();
            }
            else
            {
                Console.WriteLine("Non sei loggato, non puoi accedere a questa funzione.");
                Console.WriteLine("");
                Console.ReadLine(); 
                Menu();
            }
        }
        private static void ListaAccessi() {
            if (Logged == true)
            {
                int i = 1;
                foreach (var accesso in ListaDegliAccessi)
                {
                    Console.WriteLine($"{i}) Hai loggato alle ore {accesso.DataLogin}");
                    i++;
                }
                Console.WriteLine("");
                Menu();

            } else {
                Console.WriteLine("Non sei loggato, non puoi accedere a questa funzione.");
                Console.WriteLine("");
                Console.ReadLine();
                Menu();
            }
        }
        public static void Exit() {
            Environment.Exit(0);
        }
    }
}

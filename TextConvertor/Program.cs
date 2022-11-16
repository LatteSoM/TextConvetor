using Newtonsoft.Json;
using System.Text;
using System.Xml.Serialization;
/*C:\Users\Евгений\Desktop\Praka.txt*/
namespace TextConvertor
{
    internal class Program
    {
        public static string adres;
        public static string FinalAdres;
        public static string text;
        

        static void Main()
        {
            Console.InputEncoding = Encoding.Unicode;
            Menu();
        }
         public static void Menu()
        {
            Console.WriteLine("введите путь до файла (вместе с названием) который хотите открыть \r\n" +
                "------------------------------------------------------------------");
            adres = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("сохранить файл в одном из трех форматов (json,xml,txt) - F1. Закрыть прогу - Escape \r\n" +
                "------------------------------------------------------------------");
            text = File.ReadAllText(adres);
            if (adres.Contains("json"))
            {
                Manipulations.JsonOut();
            }
            else if (adres.Contains("xml"))
            {
                Manipulations.XmlOut();
            }
            else if (adres.Contains("txt"))
            {
                Manipulations.TxtOut();
            }
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.F1)
            {
                Console.Clear();
                Convertor();
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("lox");        
            }
        }
        static void Convertor()
        {
            Console.WriteLine("введите путь до файла (вместе с названием) куда вы хотите сохранить \r\n" +
               "------------------------------------------------------------------");
            FinalAdres = Console.ReadLine();

            if (FinalAdres.Contains("json"))
            {
                Manipulations.JsonSave();
            }
            else if (FinalAdres.Contains("xml"))
            {
                Manipulations.XmlSave();
            }
            else
            {
                Manipulations.TxtSave();
            }
        } 
    }
}
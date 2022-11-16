
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace TextConvertor
{
    internal class Manipulations
    {
        public static List<Data> mainList;
        public static void JsonOut()
        {
            mainList = DeserJson();
            foreach (Data value in mainList)
            {
                Console.WriteLine(value.Name);
                Console.WriteLine(value.Long);
                Console.WriteLine(value.High);
            }
        }
        public static void XmlOut() 
        {
            mainList = DeserXml(Program.adres);
            foreach (Data valuE in mainList)
            {
                Console.WriteLine(valuE.Name);
                Console.WriteLine(valuE.Long);
                Console.WriteLine(valuE.High);
            }
        }
        public static void TxtOut()
        {
            mainList = info();
            Console.WriteLine(Program.text);
        }
        public static void JsonSave()
        {
            string a = JsonConvert.SerializeObject(mainList);
            File.WriteAllText(Program.FinalAdres, a);
        }
        public static void XmlSave()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Data>));
            using (FileStream fs = new FileStream(Program.FinalAdres, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, mainList);
            }
        }
        public static void TxtSave()
        {

            List<string> listus = new List<string>();
            foreach (Data valuE in mainList)
            {
                string name = Convert.ToString(valuE.Name);
                listus.Add(name);
                string lang = Convert.ToString(valuE.Long);
                listus.Add(lang);
                string high = Convert.ToString(valuE.High);
                listus.Add(high);
            }
            File.WriteAllLines(Program.FinalAdres, listus);
        }

        static private List<Data> info()
        {

            List<Data> Pramo = new List<Data>();
            string[] lines = File.ReadAllLines(Program.adres);
            for (int i = 0; i < lines.Length; i += 3)
            {
                Pramo.Add(new Data(lines[i], Convert.ToInt32(lines[i + 1]), Convert.ToInt32(lines[i + 2])));
            }
            return Pramo;
        }
        static private List<Data> DeserJson()
        {
            List<Data> json = JsonConvert.DeserializeObject<List<Data>>(Program.text);
            return json;
        }
        static private List<Data> DeserXml(string text)
        {
            List<Data> data;
            XmlSerializer xml = new XmlSerializer(typeof(List<Data>));
            using (FileStream fs = new FileStream(text, FileMode.Open))
            {
                data = (List<Data>)xml.Deserialize(fs);
            }
            return data;
        }
    }
}

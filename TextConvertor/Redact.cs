namespace TextConvertor
{
    internal class Redact
    {
        private static ConsoleKeyInfo key = Console.ReadKey();
        public static void Arrows()
        {
            key = Console.ReadKey();
            bool Billy = true;
            while (Billy == true)
            {
                int pozition = 0;
                Program.Menu();
                while (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        pozition--;
                        if (pozition < 2)
                        {
                            pozition = 8;
                        }
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        pozition++;
                        if (pozition > 8)
                        {
                            pozition = 2;
                        }
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Billy = false;
                        break;
                    }
                    Console.Clear();
                    Program.Menu();
                    Console.SetCursorPosition(0, pozition);
                    Console.WriteLine("->");
                    key = Console.ReadKey();
                }
            }
        }
    }
}

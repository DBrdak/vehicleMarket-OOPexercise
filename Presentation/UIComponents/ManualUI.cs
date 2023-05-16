using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.UIComponents
{
    public class ManualUI : UI
    {
        public static void DisplayManual()
        {
            var str = new StringBuilder();
            DisplayNicely("Instrukcja", ConsoleColor.Yellow);
            str.AppendLine(
                "* Aplikacja służy do wyszukiwania i licytowania pojazdów, zamieszczonych przez innych użytkowników");
            str.AppendLine(
                "* Można również dodawać i usuwać swoje własne ogłoszenia");
            str.AppendLine(
                "* Wyniki są paginowane, można je również sortować oraz filtrować");
            str.AppendLine(
                "* Wartości wyświetlane w nawiasach mogą zostać wpisane przez użytkownika do konsoli w celu przejścia do innej sekcji");
            str.AppendLine(
                "* Zalecam zapoznać się z wartościami enum w Domain.Common.Enums przed przystąpieniem do dodawania nowych ogłoszeń");

            Console.WriteLine(str.ToString());
            Console.WriteLine("Kliknij dowolny przycisk aby wrócić do strony głównej");
            Console.ReadKey();
            Console.Clear();
            DisplayMainPage();
        }
    }
}

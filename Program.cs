
//Teil1

//Lottozahlen
//Erstellen Sie ein int[] lottozahlen mit der Länge 49.
//Schreiben Sie dann einen Code der dieses Array automatisch mit den Zahlen 1 - 49 befüllt.

//Teil2

//Ziehung der Lottozahlen
//Aus dem Array unserer Lottozahlen sollen nun sechs Zahlen zufällig gezogen werden.
//Diese sechs Zahlen müssen in einem neuen Array abgelegt werden. 
//Verwenden Sie auch wieder Random für die Zufällige Ziehung.
//Bei den gezogenen Zahlen darf es zu keiner Dopplung kommen.

//Teil3

//User-Eingabe und Gewinnausgabe
//Der User soll in der Lage sein, sechs Zahlen einzugeben.
//Diese werden in einem Array abgelegt.
//Danach soll überprüft werden, wieviele Zahlen der User im Vergleich zu den gezogenen Lottozahlen richtig getippt hat.
//Geben Sie in der Konsole aus, wieviele Richtige getippt wurden.

//Sollten Sie in der vorherigen Aufgabe zu keiner Lösung gekommen sein, schreiben Sie von Hand ein Array mit gezogenen Zahlen.

using System;
using System.Linq;
class Lotto
{
    static void Main()
    {
        // Lottozahlen von 1 bis 49 erstellen
        int[] lottozahlen = new int[49];
        for (int i = 0; i < lottozahlen.Length; i++)
        {
            lottozahlen[i] = i + 1;
        }
        // Ziehung von 6 zufälligen, eindeutigen Lottozahlen
        int[] gezogeneZahlen = Ziehung(lottozahlen);
        // Gezogene Zahlen ausgeben
        Console.WriteLine("Gezogene Lottozahlen: " + string.Join(", ", gezogeneZahlen));
        // Eingabe der User-Zahlen
        int[] userZahlen = EingabeUserZahlen();
        // User-Zahlen ausgeben
        Console.WriteLine("Deine Zahlen: " + string.Join(", ", userZahlen));
        // Vergleich der Zahlen und Ausgabe des Ergebnisses
        int richtige = VergleicheZahlen(gezogeneZahlen, userZahlen);
        Console.WriteLine($"Du hast {richtige} Richtige!");
    }
    // Methode für die Ziehung der Lottozahlen
    static int[] Ziehung(int[] lottozahlen)
    {
        Random random = new Random();
        int[] gezogeneZahlen = new int[6];
        for (int i = 0; i < gezogeneZahlen.Length; i++)
        {
            int index;
            do
            {
                index = random.Next(0, lottozahlen.Length);
            } while (gezogeneZahlen.Contains(lottozahlen[index]));
            gezogeneZahlen[i] = lottozahlen[index];
        }
        return gezogeneZahlen;
    }
    // Methode zur Eingabe der User-Zahlen
    static int[] EingabeUserZahlen()
    {
        int[] userZahlen = new int[6];
        Console.WriteLine("Bitte gib 6 verschiedene Zahlen zwischen 1 und 49 ein:");
        for (int i = 0; i < userZahlen.Length; i++)
        {
            int zahl;
            do
            {
                Console.Write($"Zahl {i + 1}: ");
                zahl = int.Parse(Console.ReadLine());
            } while (zahl < 1 || zahl > 49 || userZahlen.Contains(zahl));
            userZahlen[i] = zahl;
        }
        return userZahlen;
    }
    // Methode zum Vergleich der gezogenen Zahlen mit den User-Zahlen
    static int VergleicheZahlen(int[] gezogeneZahlen, int[] userZahlen)
    {
        return userZahlen.Count(zahl => gezogeneZahlen.Contains(zahl));
    }
}
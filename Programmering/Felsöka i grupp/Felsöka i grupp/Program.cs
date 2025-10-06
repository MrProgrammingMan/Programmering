namespace Felsöka_i_grupp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // FRÅGA 1
            /*
            int age = 16;

            string name = "Pelle";

            if (name == "Pelle") {
                Console.WriteLine("Hejsan Pelle");
            }
            */
            //////////////////////////////////////////////////////////////////////////////////////////

            // FRÅGA 2

            // Detta program ska räkna ihop  
            // alla tal mellan 1 till 10 
            /*
            int svar = 0;

            for(int i = 0; i < 10; i++ ){
                svar += i;
            }

            Console.WriteLine(svar);
            */

            //////////////////////////////////////////////////////////////////////////////////////////

            // FRÅGA 3

            // Detta program ska beräkna priset för tågresan 
            // Ålder 0-5: Gratis 
            // Ålder 6-10: Pris: 75 
            // Ålder > 65: Pris 50 
            /*
            string age = Console.ReadLine();
            int ageGroup = int.Parse(age); 
            float price = 100;

            if (ageGroup <= 5)
            {
                price = 0;
            }
            else if (ageGroup < 11)
            {
                price = 75f;
            }

            Console.WriteLine("Priset blir " + price);
            */

            //////////////////////////////////////////////////////////////////////////////////////////

            // FRÅGA 4

            // Detta program ska skriva ut alla positiva tal  
            // mellan 0 och 20 
            /*
            int count = 0;

            while( count <= 20 ) {
                Console.WriteLine(count);
                count++; 
            }
            */

            //////////////////////////////////////////////////////////////////////////////////////////

            // FRÅGA 5

            // Detta program beräknar medelvärdet  
            // av tal mellan 1 och 1000 
            /*
            int siffra = 0;

            for (int i = 0; i < 1000; i = i + 1 ) {
                siffra += i;
            }

            Console.WriteLine(siffra / 1000);
            */

            //////////////////////////////////////////////////////////////////////////////////////////

            // FRÅGA 6

            // Detta program skriver ut "Game Over" om 
            // livet är mindre än eller lika med 0  
            // och extraliv är färre än eller lika med 0 
            // ÄNDRA variablerna för hp & extraliv FÖR ATT TESTA 

            /*
            float hp = 0;
            int extraLives = 0;

            if (hp <= 0 && extraLives < 1)
            {
                Console.WriteLine("Game Over");
            }
            */


            //////////////////////////////////////////////////////////////////////////////////////////

            // FRÅGA 7

            // Låter användaren skriva in sin ålder 
            // skriver ut om hen är myndig eller inte 
            /*
            Console.WriteLine("Vad är din ålder?");
            string age = Console.ReadLine();
            int agegroup = int.Parse(age);

            if (agegroup >= 18)
            {
                Console.WriteLine("Du är myndig");
            }
            else
            {
                Console.WriteLine("Du är inte myndig");
            }
            */
        }
    }
}

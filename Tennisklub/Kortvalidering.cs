using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tennisklub
{
    //Denne klasse tager sig af at validere gyldigheden at et kreditkort.
    public class Kortvalidering
    {
        //Denne metode finder kontrolcifret der skal bruges i den sidste process af valideringen.
        public char KontrolCiffer(string nummer)
        {
            return nummer[nummer.Length - 1];          
        }

        //Denne metode fjerner kontrol cifret fra kortnummeret.
        public string FjernKontrolCiffer(string nummer)
        {
            return nummer.Remove(nummer.Length - 1, 1);
        }

        //Denne metode vender kortnummeret om.
        public string VendNummer(string nummer)
        {
            char[] omvendtNummer = nummer.ToCharArray();
            Array.Reverse(omvendtNummer);
            return new string(omvendtNummer);
        }

        //Denne metode doubler alle tal på ulige placeringer i kortnummeret, og hvis de er større end 10 tager den også tværsummen af dem.
        public string NummerDoubler(string nummer)
        {
            for (int i = 0; i < nummer.Length; i += 2)
            {
                int temp = Convert.ToInt32(nummer.Substring(i));
                temp *= 2;
                while (temp > 9)
                {
                    int s = 0;
                    while (temp > 0)
                    {
                        s += temp % 10;
                        temp /= 10;
                    }
                    temp = s;
                }
                string temp2 = temp.ToString();
                nummer.Remove(i).Insert(i, temp2);
            }
            return nummer;
        }

        //Denne metode sammenligner det sidste tale i kortnummeret med kontrolcifret der blev fundet tidligere.
        public bool SidsteCheck(string nummer, char kontrolCiffer)
        {
            int sum = 0;
            for (int i = 0; i < nummer.Length; i++)
            {
                sum += Convert.ToInt32(nummer.Substring(i));
            }

            int endeligtTal = sum % 10;
            if (endeligtTal == kontrolCiffer)
            {
                return true;
            }
            else
                return false;
        }
    }
}
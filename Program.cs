using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTUdemo;

namespace LTUdemo
{
    // See https://aka.ms/new-console-template for more information



    public class Program
    {
       private static string filePath = @"C:\Users\pihber-9\source\repos\Inlämningsuppgift2 ny\Resultat.txt";

        List<SalesPerson> salesPersonList = new List<SalesPerson>();

      //  List<string> lines = File.ReadAllLines(filePath).Tolist();
        public Program()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Vänligen ange hur många säljare du vill registrera");
            Console.WriteLine("---------------------------------------------------------");
            int numberOfInputs = Convert.ToInt32(Console.ReadLine());
            AddToList(numberOfInputs);
            Console.WriteLine(PrintHeader());
            Console.WriteLine("\n");
            PrintList(salesPersonList);
        }

        public void AddToList(int numberOfInputs)
        {
            for (int i = 0; i < numberOfInputs; i++)
            {
                Console.WriteLine("Ange namn:");
                var name = Console.ReadLine();
                Console.WriteLine("Ange personnummer:");
                var ssn = Console.ReadLine();
                Console.WriteLine("Ange distrikt:");
                var district = Console.ReadLine();
                Console.WriteLine("Ange sålda artiklar:");
                var soldArticles = Convert.ToInt32(Console.ReadLine());

                var salesPerson = new SalesPerson
                {
                    Namn = name,
                    persnr = ssn,
                    Distrikt = district,
                    Sålda_artiklar = soldArticles
                };
                salesPersonList.Add(salesPerson);
            }
        }

        public static void PrintList(List<SalesPerson> salePersonList)
        {
            
            var lvlOne = salePersonList.Where(a => a.Sålda_artiklar < 50)
                                       .OrderByDescending(a => a.Sålda_artiklar)
                                       .ToList();
            if (lvlOne.Count > 0)
            {
                foreach (var salesPerson in lvlOne)
                {
                    var tmpLine = $"{salesPerson.Namn} {salesPerson.persnr}  {salesPerson.Distrikt} {salesPerson.Sålda_artiklar}";

                    Console.WriteLine(tmpLine);


                    string[] hack = { tmpLine };

                    File.WriteAllLines(filePath, hack);
                }
                
                  var tmpLine1 = $"{lvlOne.Count} säljare har nått nivå 1: under 50 artiklar";
                
                Console.WriteLine("\n");
                
            }

            var lvlTwo = salePersonList.Where(a => a.Sålda_artiklar > 50 && a.Sålda_artiklar < 100)
                                       .OrderByDescending(a => a.Sålda_artiklar)
                                       .ToList();

            if (lvlTwo.Count > 0)
            {
                foreach (var salesPerson in lvlTwo)
                {
                    var tmpLine2 = $"{salesPerson.Namn} {salesPerson.persnr}  {salesPerson.Distrikt} {salesPerson.Sålda_artiklar}";
                    Console.WriteLine(tmpLine2);


                    string[] hack1 = { tmpLine2 };

                    File.WriteAllLines(filePath, hack1);
                }
                    if (lvlTwo.Count > 0) Console.WriteLine($"{lvlTwo.Count} säljare har nått nivå 2: mellan 50-100 artiklar");
                Console.WriteLine("\n");

            }
            var lvlThree = salePersonList.Where(a => a.Sålda_artiklar >= 100 && a.Sålda_artiklar <= 199)
                                         .OrderByDescending(a => a.Sålda_artiklar)
                                         .ToList();

            if (lvlThree.Count > 0)
            {
                foreach (var salesPerson in lvlThree)
                    Console.WriteLine($"{salesPerson.Namn} {salesPerson.persnr}  {salesPerson.Distrikt} {salesPerson.Sålda_artiklar}");

                Console.WriteLine($"{lvlThree.Count} säljare har nått nivå 3: mellan 100-199 artiklar");
                Console.WriteLine("\n");
            }
            var lvlFour = salePersonList.Where(a => a.Sålda_artiklar > 199)
                                        .OrderByDescending(a => a.Sålda_artiklar)
                                        .ToList();
            if (lvlFour.Count > 0)
            {
                foreach (var salesPerson in lvlFour)
                    Console.WriteLine($"{salesPerson.Namn} {salesPerson.persnr}  {salesPerson.Distrikt} {salesPerson.Sålda_artiklar}");

                Console.WriteLine($"{lvlFour.Count} säljare har nått nivå 4: Över 200 artiklar");
                Console.WriteLine("\n");
            }
        }
        public static string PrintHeader()
        {
            
            return "Namn Persnr Distrikt Antal";
            
        }

    }
}
using System;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course();
            string opt;
            do
            {
                Console.WriteLine("\n1. Qrup elave et");
                Console.WriteLine("2. Butun qruplara bax");
                Console.WriteLine("3. Verilmis point araliigindaki qruplara bax");
                Console.WriteLine("4. Verilmis nomresi qrupa bax");
                Console.WriteLine("5. Verilmis qruplar uzre axtaris et");
                Console.WriteLine("0. Menudan cix");

                Console.Write("\nEmeliyyat secin: ");
                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        string no;
                        do
                        {
                            Console.Write("No: ");

                            no = Console.ReadLine();
                        } while (!CheckNo(no));


                        byte AvgPoint;
                        string AvgPointStr;
                        do
                        {
                            Console.Write("AvgPoint: ");
                            AvgPointStr = Console.ReadLine();

                        } while (!byte.TryParse(AvgPointStr, out AvgPoint) || AvgPoint > 100);


                        Group group = new Group
                        {
                            AvgPoint = AvgPoint,
                            No = no
                        };

                        course.AddGroup(group);
                        break;
                    case "2":
                        foreach (var item in course.gp)
                        {
                            Console.WriteLine($"No: {item.No} - AvgPoint: {item.AvgPoint}");
                        }
                        break;
                    case "3":
                        byte MinPoint;
                        string MinPointStr;
                        do
                        {
                            Console.Write("MinPoint: ");
                            MinPointStr = Console.ReadLine();

                        } while (!byte.TryParse(MinPointStr, out MinPoint));

                        byte MaxPoint;
                        string MaxPointStr;

                        do
                        {
                            Console.Write("MaxPoint: ");
                            MaxPointStr = Console.ReadLine();

                        } while (!byte.TryParse(MaxPointStr, out MaxPoint));

                        var arr = course.GetGroupsByPointRange(MinPoint, MaxPoint);

                        foreach (var item in arr)
                        {
                            Console.WriteLine($"No: {item.No} - AvgPoint: {item.AvgPoint}");
                        }
                        break;
                    case "4":
                        Console.Write("No: ");
                        string wantedNo = Console.ReadLine();
                        var wantedGroup = course.GetGroupByNo(wantedNo);

                        if (wantedGroup == null)
                            Console.WriteLine($"{wantedNo} nomreli qrup yoxdur!");
                        else
                            Console.WriteLine($"No: {wantedGroup.No} - AvgPoint: {wantedGroup.AvgPoint}");
                        break;
                    case "5":
                        Console.Write("Search: ");
                        string search = Console.ReadLine();

                        arr = course.Search(search);

                        foreach (var item in arr)
                        {
                            Console.WriteLine($"No: {item.No} - AvgPoint: {item.AvgPoint}");
                        }

                        break;
                    case "0":
                        Console.WriteLine("proqram bitdi");
                        break;
                    default:
                        Console.WriteLine("\nSeciminiz sehvdir!");
                        break;
                }


            } while (opt != "0");

        }

        static bool CheckNo(string no)
        {
            if (no != null)
            {
                if (no.Length == 4)
                {
                    if (char.IsUpper(no[0]) && char.IsDigit(no[1]) && char.IsDigit(no[2]) && char.IsDigit(no[3]))
                        return true;
                }
            }

            return false;
        }
    
    }
}

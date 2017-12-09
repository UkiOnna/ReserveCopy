using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage;

namespace ReserveCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            int dvdSpeed = 50;
            int dvdMemory = 9000;
            Dvd dvd = new Dvd();
            dvd.SetName("Dvd");
            dvd.SetModel("Modeldvd");
            dvd.SpeedRead = dvdSpeed;
            dvd.SpeedWrite = dvdSpeed;
            dvd.SetMemory(dvdMemory);


            int flashSpeed = 30;
            int flashMemory = 8000;
            Flash flash = new Flash();
            flash.SetName("Flash-usb");
            flash.SetModel("Modelflash");
            flash.SetMemory(flashMemory);
            flash.SetSpeedUsb(flashSpeed);


            int hddSpeed = 150;
            int countSection = 2;
            int amoutSection = 500000;
            Hdd hdd = new Hdd(hddSpeed, countSection, amoutSection);
            hdd.SetName("Hdd");
            hdd.SetModel("HddModel");



            string[] stringsMenu = { "Информация о всех устройствах", "Общая память всех устройств", "Копирование информации на выбранное устройство и рассчет времени копирования", "Рассчет необходимого количества носителей информации для копирования", "Выход" };
            ConsoleMenu menu = new ConsoleMenu(stringsMenu);
            int menuResult;



            do
            {
                menuResult = menu.PrintMenu();
                menuResult++;


                switch (menuResult)
                {
                    case 1:
                        string info = dvd.GetInfo();
                        Console.WriteLine(info);
                        Console.WriteLine("__________________________________________");

                         info = hdd.GetInfo();
                        Console.WriteLine(info);
                        Console.WriteLine("__________________________________________");

                         info = flash.GetInfo();
                        Console.WriteLine(info);
                        Console.WriteLine("__________________________________________");

                        Console.ReadLine();
                        break;

                    case 2:
                        int allMemory = hdd.FreeMemoryInfo() + dvd.FreeMemoryInfo() + flash.FreeMemoryInfo();
                        Console.WriteLine("Общаая память - {0} Мб",allMemory);
                        Console.ReadLine();
                        break;

                    case 3:
                        string[] stringsToDoMenu = { "Узнать время записи на конкретном диске", "Записать информацию на конкретный диск",  "Назад" };
                        ConsoleMenu toDoMenu = new ConsoleMenu(stringsToDoMenu);
                        int toDoMenuResult;
                        Console.WriteLine("Введите размер информации(мб)");
                        int sizeInfo = 0;
                        int.TryParse(Console.ReadLine(), out sizeInfo);
                        bool isCopied;



                        do
                        {
                            toDoMenuResult = toDoMenu.PrintMenu();
                            toDoMenuResult++;


                            switch (toDoMenuResult)
                            {
                                case 2:

                                    string[] stringsChooseMenu = { "Записать на Двд", "Записать на Флэш память", "Записать на Жесткий диск", "Назад" };
                                    ConsoleMenu chooseMenu = new ConsoleMenu(stringsChooseMenu);
                                    int chooseMenuResult;
   

                                    do
                                    {
                                        chooseMenuResult = chooseMenu.PrintMenu();
                                        chooseMenuResult++;


                                        switch (chooseMenuResult)
                                        {
                                            case 1:
                                                isCopied = dvd.CopyData(ref sizeInfo);
                                                if (isCopied)
                                                {
                                                    Console.WriteLine("Информация успешно записана");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Извините недостаточно памяти на диске");
                                                }
                                                Console.ReadLine();
                                                break;

                                            case 2:
                                                isCopied = flash.CopyData(ref sizeInfo);
                                                if (isCopied)
                                                {
                                                    Console.WriteLine("Информация успешно записана");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Извините недостаточно памяти на диске");
                                                }
                                                Console.ReadLine();
                                                break;

                                            case 3:
                                                isCopied = hdd.CopyData(ref sizeInfo);
                                                if (isCopied)
                                                {
                                                    Console.WriteLine("Информация успешно записана");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Извините недостаточно памяти на диске");
                                                }
                                                Console.ReadLine();
                                                break;

                                        }

                                    }
                                    while (chooseMenuResult != stringsChooseMenu.Length);
                                    break;

                                case 1:
                                    string[] stringssChooseMenu = { "Записать на Двд", "Записать на Флэш память", "Записать на Жесткий диск", "Назад" };
                                    ConsoleMenu choosseMenu = new ConsoleMenu(stringssChooseMenu);
                                    int choosseMenuResult;



                                    do
                                    {
                                        choosseMenuResult = choosseMenu.PrintMenu();
                                        choosseMenuResult++;


                                        switch (choosseMenuResult)
                                        {
                                            case 1:
                                                double time = sizeInfo / dvd.SpeedWrite;
                                                Console.WriteLine("Это займет {0} секунд",time);
                                                Console.ReadLine();
                                                break;

                                            case 2:
                                                 time = sizeInfo / flash.GetUsbSpeed();
                                                Console.WriteLine("Это займет {0} секунд", time);
                                                Console.ReadLine();
                                                break;

                                            case 3:
                                                 time = sizeInfo / hdd.GetUsbSpeed();
                                                Console.WriteLine("Это займет {0} секунд", time);
                                                Console.ReadLine();
                                                break;

                                        }



                                    }
                                    while (choosseMenuResult != stringssChooseMenu.Length);
                                    break;
                            }

                            } while (toDoMenuResult != stringsToDoMenu.Length);

                        break;

                    case 4:
                        Console.WriteLine("Введите размер информации(мб)");
                        int.TryParse(Console.ReadLine(), out sizeInfo);


                        if (sizeInfo <= hdd.FreeMemoryInfo())
                        {
                            Console.WriteLine("Вам достаточно жесткого диска");
                        }

                        else if (sizeInfo <= (hdd.FreeMemoryInfo() + dvd.FreeMemoryInfo()))
                        {
                            Console.WriteLine("Вам достаточно жесткого диска и двд диска");
                        }

                        else if(sizeInfo <= (hdd.FreeMemoryInfo() + dvd.FreeMemoryInfo()+flash.FreeMemoryInfo()))
                        {
                            Console.WriteLine("Вам достаточно жесткого диска , двд диска,и флэш памяти");
                        }

                        else
                        {
                            Console.WriteLine("3 дисков недостаточно для копирования информации");
                        }

                        Console.ReadLine();
                        break;

                        
                }

            }
            while (menuResult != stringsMenu.Length);

        }  
        
    }
}

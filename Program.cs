using System;
using VendingMachineProject.Snacks;

namespace VendingMachineProject;

public class Program
{
    static void Main(string[] args)
    {
        Menu vendingMachine = new Menu();

        vendingMachine.Run();
    }

}

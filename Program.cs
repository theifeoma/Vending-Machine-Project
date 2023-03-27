using System;
using VendingMachineProject.Snacks;

namespace VendingMachineProject;

public class Program
{
    static void Main(string[] args)
    {
        VendingMachine vm = new VendingMachine();

        vm.Run();
    }

}

using System;

namespace ElevatorSim
{
    class Program
    {
        static void Main(string[] args)
        {
            Elevator elevator = new Elevator();
            Console.WriteLine("Elevator sim Launched!");

            while (true)
            {
                Console.WriteLine("Enter a floor or exit to exit!");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                if (int.TryParse(input, out int floorRequest))
                {
                    elevator.AddRequest(floorRequest);
                }
                else
                {
                    Console.WriteLine("Invalid input! Enter a valid number!");
                }
            }
            Console.WriteLine("Elevator sim turned off!");
        }
    }
}


// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
namespace ElevatorSim
{
    public enum Direction
    {
        Up,
        Down,
        Idle
    }

    public class Elevator
    {
        public int CurrentFloor { get; private set; }
        public Direction CurrentDirection { get; private set; }
        private Queue<int> requests;

        public Elevator()
        {
            CurrentFloor = 0;
            CurrentDirection = Direction.Idle;
            requests = new Queue<int>();
        }

        public void AddRequest(int floor)
        {
            if (floor < 0)
            {
                Console.WriteLine("Floor doesnt exist!");
                return;
            }
            requests.Enqueue(floor);
            ProcessRequests();
        }

        private void ProcessRequests()
        {
            while (requests.Count > 0)
            {
                int targetFloor = requests.Dequeue();
                MoveToFloor(targetFloor);
            }

            CurrentDirection = Direction.Idle;
        }

        private void MoveToFloor(int floor)
        {
            if (floor == CurrentFloor)
            {
                Console.WriteLine("Elevator is at requested floor!");
                return;
            }

            if (floor > CurrentFloor)
            {
                CurrentDirection = Direction.Up;
                for (int i = CurrentFloor + 1; i <= floor; i++)
                {
                    Console.WriteLine($"Elevator is going upwards! At {i}");
                    CurrentFloor = i;
                }
            }
            else
            {
                CurrentDirection = Direction.Down;
                for (int i = CurrentFloor - 1; i >= floor; i--)
                {
                    Console.WriteLine($"Elevator is going downwards! At {i}");
                    CurrentFloor = i;
                }
            }
            Console.WriteLine($"Elevator arrived to floor {floor}");
        }
    }
}
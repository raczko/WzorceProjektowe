using System;
using System.Collections.Generic;

namespace Pylek
{

    public enum Type { LargeTree, Tree, Bush }

    public interface Plant
    {
        void Display(int positionX, int positionY);
    }

    public class LargeTree : Plant
    {
        public string Texture = "large_tree.png";

        public void Display(int x, int y)
        {
            Console.WriteLine($"Duże drzewo (plik \"{Texture}\") znajduje się na pozycji {x},{y}\n");
        }
    }

    public class Tree : Plant
    {
        public string Texture = "tree.png";

        public void Display(int x, int y)
        {
            Console.WriteLine($"Normalne drzewo (plik \"{Texture}\") znajduje się na pozycji {x},{y}\n");
        }
    }
    public class Bush : Plant
    {
        public string Texture = "bush.png";

        public void Display(int x, int y)
        {
            Console.WriteLine($"Krzak (plik \"{Texture}\") znajduje się na pozycji {x},{y}\n");
        }
    }

    public class PlantFactory
    {
        private Dictionary<Type, Plant> Plants = new Dictionary<Type, Plant>();

        public Plant GetPlant(Type type)
        {
            Plant plant = null;

            if (Plants.ContainsKey(type))
            {
                plant = Plants[type];
                Console.WriteLine("Wykorzystuję istniejący obiekt ");
            }
            else
            {
                switch (type)
                {
                    case Type.LargeTree:
                        plant = new LargeTree();
                        break;
                    case Type.Tree:
                        plant = new Tree();
                        break;
                    case Type.Bush:
                        plant = new Bush();
                        break;
                    default:
                        break;
                }
                Plants.Add(type, plant);
                Console.WriteLine("Tworzę nowy obiekt typu {0}", type);
            }

            return Plants[type];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var factory = new PlantFactory();

            var plant = factory.GetPlant(Type.Tree);
            plant.Display(0, 0);
            plant = factory.GetPlant(Type.LargeTree);
            plant.Display(0, 7);
            plant = factory.GetPlant(Type.Tree);
            plant.Display(3, 16);
            plant = factory.GetPlant(Type.Bush);
            plant.Display(10, 9);
            plant = factory.GetPlant(Type.Tree);
            plant.Display(7, 7);
            plant = factory.GetPlant(Type.LargeTree);
            plant.Display(20, 0);
            plant = factory.GetPlant(Type.Tree);
            plant.Display(3, 28);
            plant = factory.GetPlant(Type.Bush);
            plant.Display(1, 5);
            plant = factory.GetPlant(Type.Tree);
            plant.Display(8, 8);

        }
    }

}
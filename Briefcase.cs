using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DZ_SC_10
{
    delegate void Act(Briefcase briefcase, Item item);
    delegate string InfoBiriefcase(Briefcase briefcase);
    internal class Briefcase 
    {
        private string? color;
        private string? manufacturer;
        private string? textile;
        private int     weight;
        public int      volume   { get; private set; }
        public List<Item>? items { get; private set; }


        public Briefcase(string? color, string? manufactured, string? textile, int weight, int volume, List<Item> items)
        {
            
            this.color        = color;
            this.manufacturer = manufactured;
            this.textile      = textile;
            this.weight       = weight;
            this.volume       = volume;
            this.items        = items;
            this.weight       = weight;
        }

        public event Act? InCase = (Briefcase briefcase, Item item) =>
        {
            Console.WriteLine("Adding new item in briefcase:");
            item.InputItemData();

            if (briefcase.volume >= item.itemVolume)
            {
                briefcase.items?.Add(item);
                briefcase.volume -= item.itemVolume;

                Console.WriteLine($"To briefcase put item {item.name} with a volume {item.itemVolume}\n");
                Console.WriteLine($"Remaining volume in the briefcase:\t{briefcase.volume}\n");
            }
            else
                throw new Exception("Not enough volume!!!");
        };

        public event InfoBiriefcase? InfoBiriefcase = (Briefcase briefcase) =>
        {
            return briefcase.ToString();
        };

        public void PutItemInBriefcase(Item item)
        {
              InCase?.Invoke(this, item);
        }

        public string? PrintInfo()
        {
            return InfoBiriefcase?.Invoke(this);
        }

        public override string ToString()
        {
            return "Briefcase color:\t\t" + color + "\nManufacturer:\t\t\t" + manufacturer + "\nTextil:\t\t\t\t" + textile
                    + "\nWeight:\t\t\t\t" + weight + " kg" + "\nBriefcase volume remaining:\t" +
                    volume + " l." + "\nAmount of items in briefcase:\t"+ items?.Count;
        }
    }
    class Item 
    {
        public string? name       { get; private set; }
        public int     itemVolume { get; private set; }
        
        public Item()
        {
            name       = null;
            itemVolume = 0;
        }
        public Item(string name, int itemVolume) 
        {
            this.name       = name;
            this.itemVolume = itemVolume;
        }

        public void InputItemData()
        {
            Console.Write("Enter item name:\t");
            name = Console.ReadLine();

            Console.Write("Enter item volume:\t");
            itemVolume = Convert.ToInt32(Console.ReadLine());
        }
        
        public override string ToString() 
        {
          return $"Item name:\t{name}\nItem volume:\t{itemVolume} l.";
        }

    }
}

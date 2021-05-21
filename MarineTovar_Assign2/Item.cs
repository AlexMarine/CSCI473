/************************************************************************************
 * Authors: Alex Marine (z1863905) and Tristan Tovar (z1832119)
 * Program: Assignment 2
 * Course: CSCI 473
 * Date: February 11, 2021
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarineTovar_Assign2
{
    /************************************************************************************
     * Class: Item
     * 
     * Summary: This class stores all information regarding item for World of
     *  ConflictCraft. It consists of constants that define the level required to equip
     *  an item, the max primary stat for an item, the max stamina stat for an item, and
     *  the max level a player can reach. The Item class also has private attributes
     *  for the various item stats and identification methods, that are then filled
     *  using constructors. It class implements IComparable and thus has a CompareTo
     *  method, as well as an overridden ToString method.
     ***********************************************************************************/
    class Item : IComparable
    {
        //declare constants
        private static uint MAX_ILVL = 360;
        private static uint MAX_PRIMARY = 200;
        private static uint MAX_STAMINA = 275;
        private static uint MAX_LEVEL = 60;

        //private attributes
        private readonly uint id;
        private string name;
        private ItemType type;
        private uint ilvl;
        private uint primary;
        private uint stamina;
        private uint requirement;
        private string flavor;

        //default constructor
        public Item()
        {
            id = 0;
            name = "";
            type = 0;
            ilvl = 0;
            primary = 0;
            stamina = 0;
            requirement = 0;
            flavor = "";
        }

        //constructor to provide initial values to all attributes
        public Item(uint id, string name, ItemType type, uint ilvl,
            uint primary, uint stamina, uint requirement, string flavor)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.ilvl = ilvl;
            this.primary = primary;
            this.stamina = stamina;
            this.requirement = requirement;
            this.flavor = flavor;
        }

        //public property for ID
        public uint ID
        {
            get { return id;  }
            set { /*readonly*/ }
        }

        //public property for Name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //public property for Type
        public ItemType Type
        {
            get { return type; }
            set
            {
                if (value >= 0 && (int)value <= 12)
                {
                    type = value;
                }
            }
        }

        //public property for Ilvl
        public uint Ilvl
        {
            get { return ilvl; }
            set
            {
                if (value >= 0 && value <= MAX_ILVL)
                {
                    ilvl = value;
                }
            }
        }

        //public property for Primary
        public uint Primary
        {
            get { return primary; }
            set
            {
                if (value >= 0 && value <= MAX_PRIMARY)
                {
                    primary = value;
                }
            }
        }

        //public property for Stamina
        public uint Stamina
        {
            get { return stamina; }
            set
            {
                if (value >= 0 && value <= MAX_STAMINA)
                {
                    stamina = value;
                }
            }
        }

        //public property for Requirement
        public uint Requirement
        {
            get { return requirement; }
            set
            {
                if (value >= 0 && value <= MAX_LEVEL)
                {
                    requirement = value;
                }
            }
        }

        //public property for Flavor
        public string Flavor
        {
            get { return flavor; }
            set { flavor = value; }
        }

        /************************************************************************************
         * Method: SortItems
         * 
         * Summary: Method that is called when user inputs menu option T in Program class.
         *  It will add all possible items into a SortedSet then print them.
         ***********************************************************************************/
        public void SortItems ()
        {
            SortedSet<Item> sortItems = new SortedSet<Item>();

            foreach (var name in Globals.ItemDict)
            {
                sortItems.Add(name.Value);
            }
            foreach (var index in sortItems)
            {
                Console.WriteLine(index); ;
            }
        }

        //CompareTo method for IComparable interface
        public int CompareTo(Object alpha)
        {
            //if object is not null, compare and sort by name
            if (alpha != null) 
            { 
                Item rightOp = alpha as Item; //Typecast the right side operand to the same object as alpha (Type)

                if (rightOp != null) //Check if the Typecast failed
                {
                    return Name.CompareTo(rightOp.Name); //Use default CompareTo method to compare Names
                }
                else
                {
                    throw new ArgumentException("ERROR: [Item] CompareTo argument is not an Item");
                }
            }

            //else, can't compare so throw exception
            else { throw new ArgumentNullException(); }
        }

        //override the ToString method, used when outputting the object to the console
        public override string ToString()
        {
            return "(" + this.Type + ") " + this.Name + " |" + this.Ilvl + "| --" + this.Requirement + "--\n\t\"" + this.Flavor + "\""; 
        }
    }
}
/************************************************************************************
 * Authors: Alex Marine (z1863905) and Tristan Tovar (z1832119)
 * Program: Assignment 3
 * Course: CSCI 473
 * Date: February 25, 2021
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarineTovar_Assign3
{
    /************************************************************************************
     * Class: Guild
     * 
     * Summary: 
     ***********************************************************************************/
    class Guild : IComparable
    {
        //private attributes of Guild
        private uint id;
        private string name;
        private string server;
        private GuildType type; //Casual, Questing, Mythic+, Raiding, PVP

        //default constructor
        public Guild()
        {
            id = 0;
            name = "";
            server = "";
            type = 0;
        }

        //constructor to provide initial values to all attributes
        public Guild(uint id, GuildType type, string name, string server)
        {
            this.id = id;
            this.name = name;
            this.server = server;
            this.type = type;
        }

        //public property for ID
        public uint ID
        {
            get { return id; }
            set { /*read only*/ }
        }

        //public property for Name
        public string Name
        {
            get { return name; }
            set { /*read only*/ }
        }

        //public propety for  Server
        public string Server
        {
            get { return server; }
            set { /*read only*/ }
        }

        //public property for Role
        public GuildType Type
        {
            get { return type; }
            set { /*read only*/ }
        }

        //CompareTo method for IComparable interface
        public int CompareTo(Object alpha)
        {
            //if object is not null, compare and sort by name
            if (alpha != null)
            {
                Guild rightOp = alpha as Guild; //Typecast the right side operand to the same object as alpha (Type)

                if (rightOp != null) //Check if the Typecast failed
                {
                    return Name.CompareTo(rightOp.Name); //Use default CompareTo method to compare Names
                }
                else
                {
                    throw new ArgumentException(" ERROR: [Player] CompareTo argument is not a Guild");
                }
            }
            //else, can't compare so throw exception
            else { throw new ArgumentNullException(); }
        }

        //override the ToString method
        public override string ToString()
        {
            return (string)("<" + this.name + ">");
        }
    }
}

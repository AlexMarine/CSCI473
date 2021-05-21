/************************************************************************************
 * Authors: Alex Marine (z1863905) and Tristan Tovar (z1832119)
 * Program: Assignment 2
 * Course: CSCI 473
 * Date: February 11, 2021
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarineTovar_Assign2
{
    public partial class WOCForm : Form
    {
        public WOCForm()
        {
            InitializeComponent();
        }

        /************************************************************************************
         * Method: WOCForm_Load
         * 
         * Summary: Fill the Player list box with the names of all of the players, their 
         *  class, and their level. Fill the Guild list box with the names of all of the
         *  guilds what server they are on.
         ***********************************************************************************/
        private void WOCForm_Load(object sender, EventArgs e)
        {
            //print every Player in PlayerDict
            foreach (var players in Globals.PlayerDict)
            {
                playersListBox.Items.Add(players.Value);
                playersListBox.DisplayMember = "DisplayName";
            }

            //print every Guild in GuildDict
            foreach (var guilds in Globals.GuildDict)
            {
                string[] token = guilds.Value.Split('-');
                guildsListBox.Items.Add(string.Format("{0,-20}", token[0]) + "\t[" + token[1] + ']');
            }
        }

        /**********************************************************************************************************
         * Method: PrintGuildServerDictForm
         * 
         * Summary: Utility Funtion to get the guildsListBox text back into a value for Globals.GuildDict
         * *********************************************************************************************************/
        private string PrintGuildServerDictForm(string displayForm)
        {
            string[] tokens = displayForm.Split('\t');
            tokens[1] = tokens[1].Substring(1, tokens[1].Length - 2);

            while (tokens[0][tokens[0].Length - 1] == ' ')
            {
                tokens[0] = tokens[0].Substring(0, tokens[0].Length - 1);
            }

            return tokens[0] + '-' + tokens[1];
        }

        /************************************************************************************
         * Method: printGuildRosterButton_Click
         * 
         * Summary: Prints out a player roster for the selected guild.
         ***********************************************************************************/
        private void printGuildRosterButton_Click(object sender, EventArgs e)
        {
            //remove the contents previosuly displayed in outputListBox
            outputListBox.Items.Clear();

            //if an item was selected in the list box
            if (guildsListBox.SelectedIndex != -1)
            {
                string guildSelect = PrintGuildServerDictForm(guildsListBox.Text);
                uint guildSelectId = 0;

                foreach(var guild in Globals.GuildDict)
                {
                    //if the guild value is equal to the selected guild, set the guildID to the key
                    if(guild.Value == guildSelect)
                    {
                        guildSelectId = guild.Key;
                    }
                }

                //if the guildID was successfully found, continue
                if (guildSelectId != 0)
                {
                    //header for guild roster
                    outputListBox.Items.Add("Guild Listing for " + guildSelect);
                    outputListBox.Items.Add("-------------------------------------------------------------");

                    //print every Player in PlayerDict
                    foreach (var players in Globals.PlayerDict)
                    {
                        //output all of the players in the selected guild
                        if (players.Value.GuildID == guildSelectId)
                        {
                            outputListBox.Items.Add(players.Value);
                        }
                    }
                }
                else
                {
                    outputListBox.Items.Add("Guild Id for selection not found, something went wrong. Please try again.");
                }
            }
            else
            {
                outputListBox.Items.Add("No guild selected. Please click on a guild!");
            }
        }

        /************************************************************************************
         * Method: raceComboBox_DropDown
         * 
         * Summary: Populate race combo box with all available races
         ***********************************************************************************/
        private void raceComboBox_DropDown(object sender, EventArgs e)
        {
            //Clear the contents of the combo box
            raceComboBox.Items.Clear();

            //Add every race to the combo box
            raceComboBox.Items.Add(Race.Forsaken);
            raceComboBox.Items.Add(Race.Orc);
            raceComboBox.Items.Add(Race.Tauren);
            raceComboBox.Items.Add(Race.Troll);
        }

        /************************************************************************************
         * Method: classComboBox_DropDown
         * 
         * Summary: Populate the class combo box with all available classes
         ***********************************************************************************/
        private void classComboBox_DropDown(object sender, EventArgs e)
        {
            //Clear the contents of the combo box
            classComboBox.Items.Clear();

            //Add every class to the combo box
            classComboBox.Items.Add(Class.Warrior);
            classComboBox.Items.Add(Class.Mage);
            classComboBox.Items.Add(Class.Druid);
            classComboBox.Items.Add(Class.Priest);
            classComboBox.Items.Add(Class.Warlock);
            classComboBox.Items.Add(Class.Rogue);
            classComboBox.Items.Add(Class.Paladin);
            classComboBox.Items.Add(Class.Hunter);
            classComboBox.Items.Add(Class.Shaman);
        }

        /************************************************************************************
         * Method: serverComboBox_DropDown
         * 
         * Summary: Populate the server combo box with all available servers
         ***********************************************************************************/
        private void serverComboBox_DropDown(object sender, EventArgs e)
        {
            //Clear the contents of the combo box
            serverComboBox.Items.Clear();

            //Add every server to the combo box
            serverComboBox.Items.Add("Beta4Azeroth");
            serverComboBox.Items.Add("TKWasASetback");
            serverComboBox.Items.Add("ZappyBoi");
        }

        /************************************************************************************
         * Method: typeComboBox_DropDown
         * 
         * Summary: Popluate the type combo box with all available types
         ***********************************************************************************/
        private void typeComboBox_DropDown(object sender, EventArgs e)
        {
            //Clear the contents of the combo box
            typeComboBox.Items.Clear();

            //Add every type to the combo box
            typeComboBox.Items.Add("Casual");  
            typeComboBox.Items.Add("Questing");
            typeComboBox.Items.Add("Mythic+");
            typeComboBox.Items.Add("Raiding");
            typeComboBox.Items.Add("PVP");
        }

        /************************************************************************************
         * Method: playersListBox_MouseClick
         * 
         * Summary: When the user selects a player from the players list box, display that
         *  player in the output list box
         ***********************************************************************************/
        private void playersListBox_MouseClick(object sender, MouseEventArgs e)
        {
            //if an item was selectede from the players list box
            if (playersListBox.SelectedItem != null)
            {
                //Clear the contents of the ouput list box
                outputListBox.Items.Clear();

                //Format the player name that was selected
                string playerName = playersListBox.SelectedItem.ToString().Substring(0,15);
                playerName.TrimEnd(' ');

                //go through each name in the player dictionary
                foreach(var player in Globals.PlayerDict)
                {
                    //if the selected name is in the dictionary, set it to the selected item
                    if(player.Value.Name == playerName)
                    {
                        playersListBox.SelectedItem = player.Value.ToString();
                    }
                }

                //Output the selected player in the output list box
                outputListBox.Items.Add(playersListBox.SelectedItem);
            }
        }

        /************************************************************************************
         * Method: guildsListBox_MouseClick
         * 
         * Summary: When the user selects a guild from the guilds list box, display that
         *  guild in the output list box
         ***********************************************************************************/
        private void guildsListBox_MouseClick(object sender, MouseEventArgs e)
        {
            //If an item was selected from the guilds list box
            if (guildsListBox.SelectedItem != null)
            {
                //Clear the contents of the output list box
                outputListBox.Items.Clear();

                //Output the selected guild in the output list box
                outputListBox.Items.Add(guildsListBox.SelectedItem.ToString());
            }
        }

        /************************************************************************************
         * Method: applySearchCriteriaButton_Click
         * 
         * Summary: Read in the user entered searches for the player, guilds, or both. Then,
         *  apply the search criteria and display the corresponding values in the players
         *  and guilds list box. For players, use StartsWith searching. For guilds, must
         *  match exatcly.
         ***********************************************************************************/
        private void applySearchCriteriaButton_Click(object sender, EventArgs e)
        {
            //Clear items currently in all listBoxes
            playersListBox.Items.Clear();
            guildsListBox.Items.Clear();
            outputListBox.Items.Clear();

            //Strings to hold text typed in textBoxes
            string searchGuild = searchGuildTextBox.Text;
            string searchPlayer = searchPlayerTextBox.Text;

            //count how many times a match was found
            int counter = 0;

            //if there is something in the text box, print guilds in that server
            if (!string.IsNullOrEmpty(searchGuildTextBox.Text))
            {
                //go through each guild in the dictionary
                foreach (var guilds in Globals.GuildDict)
                {
                    //token to split up pieces of guild information
                    string[] token = guilds.Value.Split('-');

                    //if the token matches what was typed in the text box
                    if (token[1] == searchGuild)
                    {
                        //write the guild in the list box
                        guildsListBox.Items.Add(string.Format("{0,-20}", token[0]) + "\t[" + token[1] + ']');
                        counter++;
                    }
                }

                //if no matches were found, print all guilds
                if (counter == 0)
                {
                    //go through each guild in the dictionary
                    foreach (var guilds in Globals.GuildDict)
                    {
                        //token to split up pieces of guild information
                        string[] token = guilds.Value.Split('-');

                        //write the guild in the list box
                        guildsListBox.Items.Add(string.Format("{0,-20}", token[0]) + "\t[" + token[1] + ']');
                    }

                    outputListBox.Items.Add("No guilds matched the filtering criteria");
                }
            }
            //if there is nothing, print all guilds in all servers
            else
            {
                //go through each guild in the dictionary
                foreach (var guilds in Globals.GuildDict)
                {
                    //token to split up pieces of guild information
                    string[] token = guilds.Value.Split('-');

                    //write the guild in the list box
                    guildsListBox.Items.Add(string.Format("{0,-20}", token[0]) + "\t[" + token[1] + ']');
                }
            }

            //reset the counter
            counter = 0;

            //if there is something in the text box, print players in that server
            if (!string.IsNullOrEmpty(searchPlayerTextBox.Text))
            {
                //go through each players in the dictionary
                foreach (var players in Globals.PlayerDict)
                {
                    //if the token matches what was typed in the text box
                    if (players.Value.Name.StartsWith(searchPlayer))
                    {
                        //write the player in the list box
                        playersListBox.Items.Add(players.Value);
                        playersListBox.DisplayMember = "DisplayName";
                        counter++;
                    }
                }

                //if no matches were found, print all players
                if (counter == 0)
                {
                    //go through each player in the dictionary
                    foreach (var players in Globals.PlayerDict)
                    {
                        playersListBox.Items.Add(players.Value);
                        playersListBox.DisplayMember = "DisplayName";
                    }

                    outputListBox.Items.Add("No players matched the filtering criteria");
                }
            }
            //if there is nothing, print all players
            else
            {
                //go through each players in the dictionary
                foreach (var players in Globals.PlayerDict)
                {
                    playersListBox.Items.Add(players.Value);
                    playersListBox.DisplayMember = "DisplayName";
                }
            }
        }

        /************************************************************************************
         * Method: addPlayerButton_Click
         * 
         * Summary: The user enters the name of the player to be entered, then selects the
         *  wanted data from the combo boxes. If everything was filled out properly, create
         *  the new player and add them Player Dictionary and players list box.
         ************************************************************************************/
        private void addPlayerButton_Click(object sender, EventArgs e)
        {
            //Clear items currently thr listBox
            outputListBox.Items.Clear();

            //if something is enetered in each of the required fields, continue
            if (playerNameTextBox.Text != "" && raceComboBox.SelectedIndex > -1 && 
                classComboBox.SelectedIndex > -1 && roleComboBox.SelectedIndex > -1)
            {
                //variable declaration for each piece of entered information
                var playerName = playerNameTextBox.Text;
                Race playerRace = (Race)raceComboBox.SelectedItem;
                Class playerClass = (Class)classComboBox.SelectedItem;
                Role playerRole = (Role)roleComboBox.SelectedItem;

                //generate a radom ID for the player
                Random randomID = new Random();
                uint playerID = (uint)randomID.Next(00000000, 100000000);

                //initialize the new player with the enetered information and base stats
                Player newPlayer = new Player(playerID, playerName, playerRace, playerClass, 1, 0, 0);

                //add the new player to the playersListBox and the Player Dictionary
                playersListBox.Items.Add(newPlayer);
                Globals.PlayerDict.Add(playerID, newPlayer);

                //inform of the user that the player was created
                outputListBox.Items.Add(playerName + " has entered The World Of ConflictCraft!");

                //clear all information that was entered
                playerNameTextBox.Text = "";
                raceComboBox.SelectedIndex = -1;
                classComboBox.SelectedIndex = -1;
                roleComboBox.SelectedIndex = -1;
            }
            //else, a field was not filled out properly
            else
            {
                if (playerNameTextBox.Text == "")
                {
                    outputListBox.Items.Add("A player name was not entered!");
                }
                if (raceComboBox.SelectedIndex == -1)
                {
                    outputListBox.Items.Add("A race was not selected!");
                }
                if (classComboBox.SelectedIndex == -1)
                {
                    outputListBox.Items.Add("A class was not selected!");
                }
                if (roleComboBox.SelectedIndex == -1)
                {
                    outputListBox.Items.Add("A role was not selected!");
                }
            }
        }

        /************************************************************************************
         * Method: classComboBox_SelectedValueChanged
         * 
         * Summary: Depending on which class was selected from the class combo box, display
         *  the available roles for that class in the role combo box.
         ***********************************************************************************/
        private void classComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //if an item was selected from the class combo box, continue
            if (classComboBox.SelectedItem != null)
            {
                //clears the dropdown items
                roleComboBox.Items.Clear();

                //the role dropdown items are added based on which class was selected 
                switch (classComboBox.SelectedIndex)
                {
                    case 0: //Warrior
                        roleComboBox.Items.Add(Role.Tank);
                        roleComboBox.Items.Add(Role.DPS);       
                        break;
                    case 1://Mage
                        roleComboBox.Items.Add(Role.DPS);
                        break;
                    case 2: //Druid
                        roleComboBox.Items.Add(Role.Tank);
                        roleComboBox.Items.Add(Role.Healer);
                        roleComboBox.Items.Add(Role.DPS);
                        break;
                    case 3: //Priest
                        roleComboBox.Items.Add(Role.Healer);
                        roleComboBox.Items.Add(Role.DPS);
                        break;
                    case 4://Warlock
                        roleComboBox.Items.Add(Role.DPS);
                        break;
                    case 5://Rogue
                        roleComboBox.Items.Add(Role.DPS);
                        break;
                    case 6: //Paladin
                        roleComboBox.Items.Add(Role.Tank);
                        roleComboBox.Items.Add(Role.Healer);
                        roleComboBox.Items.Add(Role.DPS);
                        break;
                    case 7://Hunter
                        roleComboBox.Items.Add(Role.DPS);
                        break;
                    case 8: //Shaman
                        roleComboBox.Items.Add(Role.Healer);
                        roleComboBox.Items.Add(Role.DPS);
                        break;
                }

                //reset the selected index to 0 for next time
                roleComboBox.SelectedIndex = 0;
            }
        }

        /************************************************************************************
         * Method: addGuildButton_Click
         * 
         * Summary: The user enters the name of the guild to be entered, then selects the
         *  wanted data from the combo boxes. If everything was filled out properly, create
         *  the new guild and add them Guild Dictionary and guilds list box.
         ***********************************************************************************/
        private void addGuildButton_Click(object sender, EventArgs e)
        {
            //Clear items currently thr listBox
            outputListBox.Items.Clear();

            //if something is enetered in each of the required fields, continue
            if (guildNameTextBox.Text != "" && serverComboBox.SelectedIndex > -1 &&
                typeComboBox.SelectedIndex > -1)
            {
                //variable declaration for each piece of entered information
                string guildName = guildNameTextBox.Text;
                string server = serverComboBox.Text;
                server.Trim();
                guildName.Trim();

                //generate a radom ID for the guild
                Random randomID = new Random();
                uint guildID = (uint)randomID.Next(00000000, 100000000);

                //put the new guild in the correct format
                string guilds = guildName + "-" + server;

                //tokenize to get the right spacing and add to the guildsListBox
                string[] token = guilds.Split('-');
                guildsListBox.Items.Add(string.Format("{0,-20}", token[0]) + "\t[" + token[1] + ']');

                //add the new guild to the Guild Dictionary
                Globals.GuildDict.Add(guildID, guilds);

                //inform of the user that the guild was created
                outputListBox.Items.Add(guildName + " was successfully created!");

                //clear all information that was entered
                guildNameTextBox.Text = "";
                serverComboBox.SelectedIndex = -1;
                typeComboBox.SelectedIndex = -1;
            }
            //else, a field was not filled out properly
            else
            {
                if (guildNameTextBox.Text == "")
                {
                    outputListBox.Items.Add("A guild name was not enetered!");
                }
                if (serverComboBox.SelectedIndex == -1)
                {
                    outputListBox.Items.Add("A server was not selected!");
                }
                if (typeComboBox.SelectedIndex == -1)
                {
                    outputListBox.Items.Add("A type was not selected!");
                }
            }
        }

        /**********************************************************************************************
         * Method: leaveGuildButton_Click
         *
         * Summary: User selects a player from the player list box, then clicks on the leave guild
         *  button. The player is then removed from the guild.
         *********************************************************************************************/
        private void leaveGuildButton_Click(object sender, EventArgs e)
        {
            //clear the contents of the output list box
            outputListBox.Items.Clear();

            //if a player was selected in the players list box
            if (playersListBox.SelectedItem != null)
            {
                //Holds the name of the player to leave the guild
                Player leavingPlayer = (Player)playersListBox.SelectedItem;

                //go through each player in the Player Dictionary
                foreach (var player in Globals.PlayerDict)
                {
                    //if the selected player is in the dictionary, continue
                    if (player.Value.Name == leavingPlayer.Name)
                    {
                        //Remove the player from the guild and output a success message
                        player.Value.LeaveGuild();
                        outputListBox.Items.Add(player.Value.Name + " has left their guild!");
                    }
                }
            }
            else
            {
                outputListBox.Items.Add("A player has not been selected!");
            }
        }

        /**************************************************************************************
         * Method: joinGuildButton_Click
         *
         * Summary: User selects a player and guild from their respective list boxes, 
         *  then clicks on the join guild button. The player is then added to that guild.
         *************************************************************************************/
        private void joinGuildButton_Click(object sender, EventArgs e)
        {
            //Clear the contents of the output lsit box
            outputListBox.Items.Clear();

            //if an item was selected in the players and guilds list boxes, continue
            if (playersListBox.SelectedItem != null && guildsListBox.SelectedItem != null)
            {
                //Holds the name of the guild to join and formats it
                string guildJoining = (string)guildsListBox.SelectedItem;
                guildJoining = guildJoining.Substring(0, 20);

                //Go through each guild in the Guild Dictionary
                foreach (var guild in Globals.GuildDict)
                {
                    //tokenize the guilds for formatting
                    string[] tokens = guild.Value.Split('-');

                    //if the selected guild starts with the matching name, continue
                    if (guildJoining.StartsWith(tokens[0]))
                    {
                        //Holds the name of the player to join the guild
                        Player leavingPlayer = (Player)playersListBox.SelectedItem;

                        //Go through each player in the Player Dictionary
                        foreach (var player in Globals.PlayerDict)
                        {
                            //If the player name selected is in the Player Dictionary, continue
                            if (player.Value.Name == leavingPlayer.Name)
                            {
                                //If the player's guildID matches the key, the player is already in the guild
                                if (player.Value.GuildID == guild.Key)
                                {
                                    outputListBox.Items.Add(player.Value.Name + " is already a member of " + tokens[0] + '!');
                                }
                                //The player is not already in the guild, so add them to it
                                else
                                {
                                    player.Value.JoinGuild(guild.Key);
                                    outputListBox.Items.Add(player.Value.Name + " has joined " + tokens[0] + '!');
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                outputListBox.Items.Add("A player or guild is not selected!");
            }
        }

        /**************************************************************************************
         * Method: disbandGuildButton_Click
         * 
         * 
         * Summary: User selects a guild from the guilds lsit box, then clicks on the disband 
         *  guild button. The guild is then disbanded.
         *************************************************************************************/
        private void disbandGuildButton_Click(object sender, EventArgs e)
        {
            //Clear the contents of the output list box
            outputListBox.Items.Clear();

            //If an index was selcted in the guilds list box, continue
            if (guildsListBox.SelectedIndex != -1)
            {
                //string to hold the name of the guild to disband
                string guildSelect = PrintGuildServerDictForm(guildsListBox.Text);
                uint removeID = 0;

                //Go through each guild in the Guild Dictionary
                foreach (var guild in Globals.GuildDict)
                {
                    //if the guild to disband is in the Dictionary, set the ID to removeID
                    if (guild.Value == guildSelect)
                    {
                        removeID = guild.Key;
                    }
                }

                //if and item was selected in the guilds list box, remove it
                if (guildsListBox.SelectedItem != null)
                {
                    guildsListBox.Items.Remove(guildsListBox.SelectedItem);
                }

                //Go through each player in the Player Dictionary
                foreach (var players in Globals.PlayerDict)
                {
                    //if the player's ID matches the ID to remove, remove it
                    if (removeID == players.Value.GuildID)
                    {
                        players.Value.GuildID = 0;
                    }
                }

                //Go through each guild in the Guild Dictionary
                foreach (var guild in Globals.GuildDict)
                {
                    //tokenize the guild name for formatting
                    string[] token = guild.Value.Split('-');

                    //if the guildID matches the ID to be removed, output a success message
                    if (removeID == guild.Key)
                    {
                        outputListBox.Items.Add(token[0] + " has been disbanded!");
                    }
                }
            }
            else
            {
                outputListBox.Items.Add("No guild selected to disband!");
            }
        }
    }
}
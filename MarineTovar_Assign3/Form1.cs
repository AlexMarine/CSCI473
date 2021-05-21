/************************************************************************************
 * Authors: Alex Marine (z1863905) and Tristan Tovar (z1832119)
 * Program: Assignment 3
 * Course: CSCI 473
 * Date: February 25, 2021
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

namespace MarineTovar_Assign3
{
    public partial class WOCForm : Form
    {
        public WOCForm()
        {
            InitializeComponent();
        }

        /************************************************************************************
         * Method: classTypeClassComboBox_DropDown
         * 
         * Summary: Populate the Class Type class combo box with all available classes
         ***********************************************************************************/
        private void classTypeClassComboBox_DropDown(object sender, EventArgs e)
        {
            //Clear the contents of the combo box
            classTypeClassComboBox.Items.Clear();

            //Add every class to the combo box
            classTypeClassComboBox.Items.Add(Class.Warrior);
            classTypeClassComboBox.Items.Add(Class.Mage);
            classTypeClassComboBox.Items.Add(Class.Druid);
            classTypeClassComboBox.Items.Add(Class.Priest);
            classTypeClassComboBox.Items.Add(Class.Warlock);
            classTypeClassComboBox.Items.Add(Class.Rogue);
            classTypeClassComboBox.Items.Add(Class.Paladin);
            classTypeClassComboBox.Items.Add(Class.Hunter);
            classTypeClassComboBox.Items.Add(Class.Shaman);
        }

        /************************************************************************************
         * Method: classTypeServerComboBox_DropDown
         * 
         * Summary: Populate the Class Type server combo box with all available servers
         ***********************************************************************************/
        private void classTypeServerComboBox_DropDown(object sender, EventArgs e)
        {
            //Clear the contents of the combo box
            classTypeServerComboBox.Items.Clear();

            //Add every server to the combo box
            classTypeServerComboBox.Items.Add("Beta4Azeroth");
            classTypeServerComboBox.Items.Add("TKWasASetback");
            classTypeServerComboBox.Items.Add("ZappyBoi");
        }

        /************************************************************************************
         * Method: percentRaceServerComboBox_DropDown
         * 
         * Summary: Populate the Percent Race server combo box with all available servers
         ***********************************************************************************/
        private void percentRaceServerComboBox_DropDown(object sender, EventArgs e)
        {
            //Clear the contents of the combo box
            percentRaceServerComboBox.Items.Clear();

            //Add every server to the combo box
            percentRaceServerComboBox.Items.Add("Beta4Azeroth");
            percentRaceServerComboBox.Items.Add("TKWasASetback");
            percentRaceServerComboBox.Items.Add("ZappyBoi");
        }

        /************************************************************************************
         * Method: roleTypeRoleComboBox_DropDown
         * 
         * Summary: Populate the Role Type role combo box with all available roles
         ***********************************************************************************/
        private void roleTypeRoleComboBox_DropDown(object sender, EventArgs e)
        {
            //Clear the contents of the combo box
            roleTypeRoleComboBox.Items.Clear();

            //Add every type to the combo box
            roleTypeRoleComboBox.Items.Add(Role.Tank);
            roleTypeRoleComboBox.Items.Add(Role.Healer);
            roleTypeRoleComboBox.Items.Add(Role.Damage);
        }

        /************************************************************************************
         * Method: roleTypeServerComboBox_DropDown
         * 
         * Summary: Populate the Role Type servers combo box with all available servers
         ***********************************************************************************/
        private void roleTypeServerComboBox_DropDown(object sender, EventArgs e)
        {
            //Clear the contents of the combo box
            roleTypeServerComboBox.Items.Clear();

            //Add every server to the combo box
            roleTypeServerComboBox.Items.Add("Beta4Azeroth");
            roleTypeServerComboBox.Items.Add("TKWasASetback");
            roleTypeServerComboBox.Items.Add("ZappyBoi");
        }

        /************************************************************************************
         * Method: guildTypeComboBox_DropDown
         * 
         * Summary: Populate the Guild type combo box with all available types
         ***********************************************************************************/
        private void guildTypeComboBox_DropDown(object sender, EventArgs e)
        {
            //Clear the contents of the combo box
            guildTypeComboBox.Items.Clear();

            //Add every type to the combo box
            guildTypeComboBox.Items.Add("Casual");
            guildTypeComboBox.Items.Add("Questing");
            guildTypeComboBox.Items.Add("Mythic+");
            guildTypeComboBox.Items.Add("Raiding");
            guildTypeComboBox.Items.Add("PVP");
        }

        /************************************************************************************
         * Method: roleTypeMinNumericUpDown_DropDown
         * 
         * Summary: If the value of min is greater than the value of max, increment max so
         *  that min does not become greater than max
         ***********************************************************************************/
        private void roleTypeMinNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (roleTypeMinNumericUpDown.Value > roleTypeMaxNumericUpDown.Value)
            {
                ++roleTypeMaxNumericUpDown.Value;
            }
        }

        /************************************************************************************
         * Method: roleTypeMaxNumericUpDown_DropDown
         * 
         * Summary: If the value of max is greater than the value of min, decrement min so
         *  that max does not become less than min
         ***********************************************************************************/
        private void roleTypeMaxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (roleTypeMinNumericUpDown.Value > roleTypeMaxNumericUpDown.Value)
            {
                --roleTypeMinNumericUpDown.Value;
            }
        }

        /************************************************************************************
         * Method: classTypeButton_Click
         * 
         * Summary: When the user click the show results button in the first query, two LINQs
         *  are activated to select each Player in the Player Dictionary with the same class 
         *  as selected in the class ComboBox and selects each Guild in the Guild Dictionary
         *  with the same server as selected in the server ComboBox. The corresponding
         *  players are then outputted in the query ListBox in ascending order of their
         *  levels.
         ***********************************************************************************/
        private void classTypeButton_Click(object sender, EventArgs e)
        {
            //clear the contents in the list box
            queryListBox.Items.Clear();

            //If items in both comboBoxes were selected
            if (classTypeClassComboBox.SelectedIndex != -1 && classTypeServerComboBox.SelectedIndex != -1)
            {
                //Define variables as the Items selected in respective comboBoxes
                Class classes = (Class)classTypeClassComboBox.SelectedItem;
                string server = (string)classTypeServerComboBox.SelectedItem;

                //LINQ to select all Players who have the selected Class
                var classBox =
                    from P in Globals.PlayerDict
                    where P.Value.PlayerClass == classes
                    orderby P.Value.Level ascending
                    select P;

                //LINQ to select all Guild who are in the selected Server
                var serverBox =
                    from G in Globals.GuildDict
                    where G.Value.Server == server
                    select G;

                //Output header for the query ListBox
                queryListBox.Items.Add("All " + classes + " from " + server + "\n");
                queryListBox.Items.Add("--------------------------------------------------------------------------------------------");

                //Go through each player selected from classBox
                foreach (var player in classBox)
                {
                    //Go through each guild selected from serverBox
                    foreach (var guild in serverBox)
                    {
                        //if the guild Key and the player's guild ID match, output them
                        if (guild.Key == player.Value.GuildID)
                        {
                            queryListBox.Items.Add("Name: " + player.Value.Name.PadRight(15) + "(" + player.Value.PlayerClass + " - " 
                                + player.Value.Role + ")\t Race: " + player.Value.Race +"\tLevel: " + player.Value.Level + 
                                "  <" + guild.Value.Name + ">");
                        }
                    }
                }

                //Output the end of the query listBox
                queryListBox.Items.Add("\n");
                queryListBox.Items.Add("END RESULTS\n");
                queryListBox.Items.Add("--------------------------------------------------------------------------------------------");
            }
            //else, either both or one items missing, output error
            else
            {
                queryListBox.Items.Add("Class and/or Server not selected!");
            }
        }

        /************************************************************************************
         * Method: percentRaceButton_Click
         * 
         * Summary: When the user click the show results button in the second query, four 
         *  LINQs are activated. First, all of thr GuildIDs the correspond the server 
         *  selected are selected. Then, all the players who are members of those guilds are 
         *  selected and counted. The number of players that are apart of each race and then 
         *  counted, and in the final LINQ, the percent of each race in the server is 
         *  calculated. The races percent in the server are then outputted to the query box 
         *  with their corresponding percentage.
         ***********************************************************************************/
        private void percentRaceButton_Click(object sender, EventArgs e)
        {
            //clear the contents in the list box
            queryListBox.Items.Clear();

            //If an item in the comboBoxe was selected
            if (percentRaceServerComboBox.SelectedIndex != -1)
            {
                //Define variable as the Items selected in the comboBox
                string server = (string)percentRaceServerComboBox.SelectedItem;

                //LINQ to select all GuildsIDs that are in the selected server
                var getGuildIDs =
                    from G in Globals.GuildDict
                    where G.Value.Server == (string)percentRaceServerComboBox.SelectedItem
                    select G;

                //LINQ to select all Players in the selected server
                var playersInServer =
                    from P in Globals.PlayerDict
                    join G in getGuildIDs
                    on P.Value.GuildID equals G.Value.ID
                    select P;

                //LINQ to select number of players in each race from the selected server
                var countRace =
                    from P in playersInServer
                    group P by P.Value.Race into race
                    select new { Race = race.Key, PlayersInRace = race.Count() };

                //variable that holds the number of players that appears in the selected server
                double numPlayers = playersInServer.Count();

                //LINQ to select the percent of each race from the selected server
                var racePercent =
                    from C in countRace
                    orderby C.Race
                    select new { Race = C.Race, Percent = ((C.PlayersInRace / numPlayers) * 100) };

                //Output header for the query ListBox
                queryListBox.Items.Add("Percent of Each Race from " + server + "\n");
                queryListBox.Items.Add("--------------------------------------------------------------------------------------------");

                //Output the percent each race appears in the selected server
                foreach (var r in racePercent)
                {
                    //If race is forsaken, use only one tab
                    if (r.Race == Race.Forsaken)
                    {
                        queryListBox.Items.Add(String.Format(r.Race + "\t{0:00.00}%", r.Percent));
                    }
                    //else, use two tabs
                    else
                    {
                        queryListBox.Items.Add(String.Format(r.Race + "\t\t{0:00.00}%", r.Percent));
                    }
                }

                //Output the end of the query listBox
                queryListBox.Items.Add("\n");
                queryListBox.Items.Add("END RESULTS\n");
                queryListBox.Items.Add("--------------------------------------------------------------------------------------------");
            }
            //else, server is not filled, output error
            else
            {
                queryListBox.Items.Add("Server not selected!");
            }
        }

        /************************************************************************************
         * Method: roleTypeButton_Click
         * 
         * Summary: When the user click the show results button in the third query, two LINQs
         *  are activated to select each Player in the Player Dictionary with the same role 
         *  as selected in the class ComboBox that also falls into the range of levels 
         *  selected and selects each Guild in the Guild Dictionary with the same server as 
         *  selected in the server ComboBox. The corresponding players are then outputted in 
         *  the query ListBox in ascending order of their levels.
         ***********************************************************************************/
        private void roleTypeButton_Click(object sender, EventArgs e)
        {
            //clear the contents in the list box
            queryListBox.Items.Clear();

            //If items in both comboBoxes were selected
            if (roleTypeRoleComboBox.SelectedIndex != -1 && roleTypeServerComboBox.SelectedIndex != -1)
            {
                //Define variables to hold valuse in the numericUpDowns
                int minLevel = (int)roleTypeMinNumericUpDown.Value;
                int maxLevel = (int)roleTypeMaxNumericUpDown.Value;

                //Define variables as the Items selected in respective comboBoxes
                Role roles = (Role)roleTypeRoleComboBox.SelectedItem;
                string server = (string)roleTypeServerComboBox.SelectedItem;

                //LINQ to select all Players who have the selected role and fall within the level range
                var roleBox =
                    from P in Globals.PlayerDict
                    where (P.Value.Role == roles) &&
                          (P.Value.Level >= minLevel) &&
                          (P.Value.Level <= maxLevel)
                    orderby P.Value.Level ascending
                    select P;

                //LINQ to select all Guild who are in the selected Server
                var serverBox =
                    from G in Globals.GuildDict
                    where G.Value.Server == server
                    select G;

                //Output header for the query ListBox
                queryListBox.Items.Add("All " + roles + " from [" + server + "], Levels " + minLevel + " to " + maxLevel);
                queryListBox.Items.Add("--------------------------------------------------------------------------------------------");

                //Go through each player selected from classBox
                foreach (var player in roleBox)
                {
                    //Go through each guild selected from serverBox
                    foreach (var guild in serverBox)
                    {
                        //if the guild Key and the player's guild ID match, output them
                        if (guild.Key == player.Value.GuildID)
                        {
                            queryListBox.Items.Add("Name: " + player.Value.Name.PadRight(15) + "(" + player.Value.PlayerClass + " - "
                                + player.Value.Role + ")\t Race: " + player.Value.Race + "\tLevel: " + player.Value.Level +
                                "  <" + guild.Value.Name + ">");
                        }
                    }
                }

                //Output the end of the query listBox
                queryListBox.Items.Add("\n");
                queryListBox.Items.Add("END RESULTS\n");
                queryListBox.Items.Add("--------------------------------------------------------------------------------------------");
            }
            //else, either both or one items missing, output error
            else
            {
                queryListBox.Items.Add("Role and/or Server not selected!");
            }
        }

        /************************************************************************************
         * Method: guildTypeButton_Click()
         * 
         * Summary: Prints a LINQ list of all guilds that match the user-selected type, 
         *  groups by server.
         ***********************************************************************************/
        private void guildTypeButton_Click(object sender, EventArgs e)
        {
            //clear the contents in the list box
            queryListBox.Items.Clear();

            //if an item was selected in the guildType combobox
            if(guildTypeComboBox.SelectedIndex != -1)
            {
                //LINQ to select all guilds that are in the specified type and group by server
                var guildByTypesQuery =
                    from G in Globals.GuildDict
                    where G.Value.Type == (GuildType)guildTypeComboBox.SelectedIndex
                    group G by G.Value.Server;

                //print out header for query
                queryListBox.Items.Add("All " + (GuildType)guildTypeComboBox.SelectedIndex + "-Type guilds");
                queryListBox.Items.Add("--------------------------------------------------------------------------------------------");

                //for all guilds selected in the LINQ
                foreach(var groupByServer in guildByTypesQuery)
                {
                    //output the server the guilds are found in
                    queryListBox.Items.Add(groupByServer.Key);

                    //output all the guilds selected and are in the server
                    foreach(var guild in groupByServer)
                    {
                        queryListBox.Items.Add("\t" + guild.Value + "\n");
                    }
                }

                //print out end of query
                queryListBox.Items.Add("\n");
                queryListBox.Items.Add("END OF RESULTS");
                queryListBox.Items.Add("--------------------------------------------------------------------------------------------");
            }
            //else nothing was selected, print out error
            else
            {
                queryListBox.Items.Add("Guild Type not selected!");
            }
        }

        /************************************************************************************
         * Method: playerFillButtion_Click()
         * 
         * Summary: Checks to see which radio button was selected (Tank, Healer, Damage) and
         *  uses the correct LINQ to determine all players that are able to play that role, 
         *  but are currently playing as one of the other two. Outputs the player from the 
         *  LINQ. EX: Select Damage, outputs all tanks and healers that could swap to damage. 
         *  (Note: The LINQs exclude searches for the Mage, Warlock, Rogue, and Hunter 
         *  Classes because they all can only be Damage roles)
         ***********************************************************************************/
        private void playerFillButton_Click(object sender, EventArgs e)
        {
            //clear the contents in the list box
            queryListBox.Items.Clear();

            //if the tank radio button is checked
            if (playerFIllTankRadioButton.Checked)
            {
                //print out header for query
                queryListBox.Items.Add("All Eligible players not fulfilling the Tank Role");
                queryListBox.Items.Add("------------------------------------------------------------------------------------------------");

                //LINQ to select all players who can be a tank but presently aren't
                var playersNotInTankQuery =
                    from P in Globals.PlayerDict
                    where (P.Value.PlayerClass == Class.Warrior
                    || P.Value.PlayerClass == Class.Druid
                    || P.Value.PlayerClass == Class.Paladin)
                    && P.Value.Role != Role.Tank
                    orderby P.Value.Level
                    select P;

                //output all the players who were selected in the query
                foreach (var player in playersNotInTankQuery)
                {
                    queryListBox.Items.Add(player.Value);
                }

                //print out end of query
                queryListBox.Items.Add("\n");
                queryListBox.Items.Add("END RESULTS");
                queryListBox.Items.Add("------------------------------------------------------------------------------------------------");
            }
            //if the healer radio button is checked
            else if (playerFillHealerRadioButton.Checked)
            {
                //print out header for query
                queryListBox.Items.Add("All Eligible players not fulfilling the Healer Role");
                queryListBox.Items.Add("------------------------------------------------------------------------------------------------");

                //LINQ to select all players who can be a healer but presently aren't
                var playersNotInHealerQuery =
                    from P in Globals.PlayerDict
                    where (P.Value.PlayerClass == Class.Druid
                    || P.Value.PlayerClass == Class.Priest
                    || P.Value.PlayerClass == Class.Paladin
                    || P.Value.PlayerClass == Class.Shaman)
                    && P.Value.Role != Role.Healer
                    orderby P.Value.Level
                    select P;

                //output all the players who were selected in the query
                foreach (var players in playersNotInHealerQuery)
                {
                    queryListBox.Items.Add(players.Value);
                }

                //print out end of query
                queryListBox.Items.Add("\n");
                queryListBox.Items.Add("END RESULTS");
                queryListBox.Items.Add("------------------------------------------------------------------------------------------------");
            }
            //if the damage radio button is checked
            else if (playerFIllDamageRadioButton.Checked)
            {
                //print out header for query
                queryListBox.Items.Add("All Eligible players not fulfilling the Damage Role");
                queryListBox.Items.Add("------------------------------------------------------------------------------------------------");

                //LINQ to select all players who can be damage but presently aren't
                var playersNotInDamageQuery =
                    from P in Globals.PlayerDict
                    where (P.Value.PlayerClass == Class.Warrior
                    || P.Value.PlayerClass == Class.Druid
                    || P.Value.PlayerClass == Class.Priest
                    || P.Value.PlayerClass == Class.Paladin
                    || P.Value.PlayerClass == Class.Shaman)
                    && P.Value.Role != Role.Damage
                    orderby P.Value.Level
                    select P;

                //output all the players who were selected in the query
                foreach (var player in playersNotInDamageQuery)
                {
                    queryListBox.Items.Add(player.Value);
                }

                //output end of query
                queryListBox.Items.Add("\n");
                queryListBox.Items.Add("END RESULTS");
                queryListBox.Items.Add("------------------------------------------------------------------------------------------------");
            }
            //else nothing was selected and output error
            else
            {
                queryListBox.Items.Add("An option is not selected!");
            }
        }

        /************************************************************************************
         * Method: percentLevelButton_Click
         * 
         * Summary: Calls a foreach loop to iterate through each entry in the GuildDict 
         *  dictionary, then performs the following actions:
         *  1. Uses a LINQ to get all of the players in the guild, then an additional LINQ 
         *      gets all of the max level players from the previous LINQ
         *  2. Checks if there are players in the guild at all. If there are none, skips 
         *      the entry (omits record)
         *  3. Checks if there are 0 max level players. If true, sets the percentage to 0 
         *      to avoid a divide by zero error
         *  4. Calculates the percentage by dividing the number of max level players by the 
         *      total number of players in the guild
         *  5. Outputs the record
         ***********************************************************************************/
        private void percentLevelButton_Click(object sender, EventArgs e)
        {
            //clear the contents in the list box
            queryListBox.Items.Clear();

            //output the header for the query list box
            queryListBox.Items.Add("Percentage of Max Level Players in All Guilds");
            queryListBox.Items.Add("-----------------------------------------------------------------------------------------------");

            //for every guild in the Guild dictionary
            foreach (var guild in Globals.GuildDict)
            {
                //LINQ to select all players who are in a specific guild
                var playersInGuildQuery =
                    from P in Globals.PlayerDict
                    where P.Value.GuildID == guild.Key
                    select P;

                //LINQ to select all players from the previous LINQ who are max level
                var maxLevelPlayersQuery =
                    from ML in playersInGuildQuery
                    where ML.Value.Level == 60
                    select ML;

                //If there are no playres in the guild (== 0), skip the record
                if (playersInGuildQuery.Count() != 0)
                {
                    //variable to hold the percent of max level players in each guild
                    double percent = 0;

                    //If no players are max level, show 0 percent to avoid divide by zero error
                    if (maxLevelPlayersQuery.Count() == 0)
                    {
                        percent = 0;
                    }
                    else
                    {
                        //calculate the percent of all max level players in each server
                        percent = (double)maxLevelPlayersQuery.Count() / (double)playersInGuildQuery.Count();
                    }

                    //output the stats to the query list box
                    queryListBox.Items.Add(String.Format("{0, -30}", guild.Value) + String.Format("{0, 20: 0.00%}", percent));
                    queryListBox.Items.Add("");
                }

            }

            //output end of query
            queryListBox.Items.Add("END RESULTS");
            queryListBox.Items.Add("------------------------------------------------------------------------------------------------");
        }
    }
}

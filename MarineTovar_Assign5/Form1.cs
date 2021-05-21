/************************************************************************************
 * Authors: Alex Marine (z1863905) and Tristan Tovar (z1832119)
 * Program: Assignment 5
 * Course: CSCI 473
 * Date: April 1, 2021
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
using System.IO;

namespace MarineTovar_Assign5
{
    public partial class PuzzleBoard : Form
    {
        //Used to be able to hide the i cursor
        [System.Runtime.InteropServices.DllImport("user32.dll")] static extern bool HideCaret(System.IntPtr hWnd);

        //variable declaration for width and height of the pictureBox
        public static int W;
        public static int H;

        //Flag for cheating/hint button
        bool cheatFlag = false;

        //variable definitions for what difficulty is selected, start in none so all start false
        bool isEasy = false;
        bool isMedium = false;
        bool isHard = false;

        //variables for timer
        int seconds = 0;
        bool countTime = false;

        //variables to hold data in each of the text boxes on the board
        string a1, a2, a3, a4, a5, a6, a7,
               b1, b2, b3, b4, b5, b6, b7,
               c1, c2, c3, c4, c5, c6, c7,
               d1, d2, d3, d4, d5, d6, d7,
               e1, e2, e3, e4, e5, e6, e7,
               f1, f2, f3, f4, f5, f6, f7,
               g1, g2, g3, g4, g5, g6, g7;


        /************************************************************************************
         * Method: PuzzleBoard
         * 
         * Summary: Initialize all of the components to set up the puzzle board
         ***********************************************************************************/
        public PuzzleBoard()
        {
            InitializeComponent();

            //Define variables to height and width of the picture box
            H = pictureBox.Height;
            W = pictureBox.Width;

            //Add textBoxes/Labels/whatever to a global list
            addToGlobals();

            //Add all easy puzzle textboxes to EasyTextboxesList
            for (int i = 0; i < Globals.textBoxesList.Count; i++)
            {
                switch (i) //any case that matches drops through to be added to list, any case that doesn't match is defaulted
                {
                    case 16: case 17: case 18: case 23: case 24: case 25: case 30: case 31: case 32:
                        Globals.easyTextBoxesList.Add(Globals.textBoxesList[i]);
                        break;

                    default:
                        break;

                }
            }
            //Add all medium puzzle texboxes to mediumTextBoxList
            for (int i = 0; i < Globals.textBoxesList.Count; i++)
            {
                switch (i) //any case that matches drops through to be added to list, any case that doesn't match is defaulted
                {
                    case 8: case 9: case 10: case 11: case 12: case 15:
                    case 16: case 17: case 18: case 19: case 22: case 23:
                    case 24: case 25: case 26: case 29: case 30: case 31:
                    case 32: case 33: case 36: case 37: case 38: case 39:
                    case 40:
                        Globals.mediumTextBoxesList.Add(Globals.textBoxesList[i]);
                        break;

                    default:
                        break;
                }
            }
        }

        /************************************************************************************
         * Method: pictureBox_Paint
         * 
         * Summary: Print the grid onto the form depening on which difficulty was selected.
         ***********************************************************************************/
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            using (Pen myPen = new Pen(Color.WhiteSmoke))
            {
                //if the user selected easy puzzle
                if (isEasy == true)
                {
                    //Draw grid for easy game
                    for (int i = 2; i <= 5; i++)
                    {
                        graphics.DrawLine(myPen, (i * W / 7), ((H / 7) * 2), (i * W / 7), ((H / 7) * 5));
                        graphics.DrawLine(myPen, ((W / 7) * 2), (i * H / 7), ((W / 7) * 5), (i * H / 7));
                    }
                }
                //if the user selected medium puzzle
                else if (isMedium == true)
                {
                    //Draw grid for medium game
                    for (int i = 1; i <= 6; i++)
                    {
                        graphics.DrawLine(myPen, (i * W / 7), ((H / 7) * 1), (i * W / 7), ((H / 7) * 6));
                        graphics.DrawLine(myPen, ((W / 7) * 1), (i * H / 7), ((W / 7) * 6), (i * H / 7));
                    }
                }
                //if the user selected hard puzzle
                else if (isHard == true)
                {
                    //Draw grid for hard game
                    for (int i = 0; i <= 7; i++)
                    {
                        if (i == 7)
                        {
                            graphics.DrawLine(myPen, (i * W / 7) - 1, 0, (i * W / 7) - 1, H);
                            graphics.DrawLine(myPen, 0, (i * H / 7) - 1, W, (i * H / 7) - 1);
                        }
                        else
                        {
                            graphics.DrawLine(myPen, (i * W / 7), 0, (i * W / 7), H);
                            graphics.DrawLine(myPen, 0, (i * H / 7), W, (i * H / 7));
                        }
                    }
                }
            }
        }

        /************************************************************************************
         * Method: pauseResumeButton_Click
         * 
         * Summary: When the game is paused, stop the timer and hide all of the values that
         *  are on the puzzle board. When it is clicked again, start the timer and show the 
         *  values.
         ***********************************************************************************/
        private void pauseResumeButton_Click(object sender, EventArgs e)
        {
            //If not in a puzzle, the pause button does nothing
            if (isEasy == false && isMedium == false && isHard == false) { return; }

            //If button says 'Pause'
            if (pauseResumeButton.Text == "Pause")
            {
                //Change to 'Resume' when clicked and stop timer
                pauseResumeButton.Text = "Resume";
                timer.Stop();

                //store the value in each box in a variable to restore when unpaused
                a1 = textBoxA1.Text; a2 = textBoxA2.Text; a3 = textBoxA3.Text; a4 = textBoxA4.Text;
                a5 = textBoxA5.Text; a6 = textBoxA6.Text; a7 = textBoxA7.Text;
                b1 = textBoxB1.Text; b2 = textBoxB2.Text; b3 = textBoxB3.Text; b4 = textBoxB4.Text;
                b5 = textBoxB5.Text; b6 = textBoxB6.Text; b7 = textBoxB7.Text;
                c1 = textBoxC1.Text; c2 = textBoxC2.Text; c3 = textBoxC3.Text; c4 = textBoxC4.Text;
                c5 = textBoxC5.Text; c6 = textBoxC6.Text; c7 = textBoxC7.Text;
                d1 = textBoxD1.Text; d2 = textBoxD2.Text; d3 = textBoxD3.Text; d4 = textBoxD4.Text;
                d5 = textBoxD5.Text; d6 = textBoxD6.Text; d7 = textBoxD7.Text;
                e1 = textBoxE1.Text; e2 = textBoxE2.Text; e3 = textBoxE3.Text; e4 = textBoxE4.Text;
                e5 = textBoxE5.Text; e6 = textBoxE6.Text; e7 = textBoxE7.Text;
                f1 = textBoxF1.Text; f2 = textBoxF2.Text; f3 = textBoxF3.Text; f4 = textBoxF4.Text;
                f5 = textBoxF5.Text; f6 = textBoxF6.Text; f7 = textBoxF7.Text;
                g1 = textBoxG1.Text; g2 = textBoxG2.Text; g3 = textBoxG3.Text; g4 = textBoxG4.Text;
                g5 = textBoxG5.Text; g6 = textBoxG6.Text; g7 = textBoxG7.Text;

                //Set all text boxes to a question mark to hide puzzle board
                foreach (var textbox in Globals.textBoxesList)
                {
                    textbox.Text = "?";
                }
            }
            //If button says 'Resume'
            else if (pauseResumeButton.Text == "Resume")
            {
                //Change to 'Pause' when clicked and start timer
                pauseResumeButton.Text = "Pause";
                timer.Start();

                //restore the value to each of the text boxes before paused
                textBoxA1.Text = a1; textBoxA2.Text = a2; textBoxA3.Text = a3; textBoxA4.Text = a4;
                textBoxA5.Text = a5; textBoxA6.Text = a6; textBoxA7.Text = a7;
                textBoxB1.Text = b1; textBoxB2.Text = b2; textBoxB3.Text = b3; textBoxB4.Text = b4;
                textBoxB5.Text = b5; textBoxB6.Text = b6; textBoxB7.Text = b7;
                textBoxC1.Text = c1; textBoxC2.Text = c2; textBoxC3.Text = c3; textBoxC4.Text = c4;
                textBoxC5.Text = c5; textBoxC6.Text = c6; textBoxC7.Text = c7;
                textBoxD1.Text = d1; textBoxD2.Text = d2; textBoxD3.Text = d3; textBoxD4.Text = d4;
                textBoxD5.Text = d5; textBoxD6.Text = d6; textBoxD7.Text = d7;
                textBoxE1.Text = e1; textBoxE2.Text = e2; textBoxE3.Text = e3; textBoxE4.Text = e4;
                textBoxE5.Text = e5; textBoxE6.Text = e6; textBoxE7.Text = e7;
                textBoxF1.Text = f1; textBoxF2.Text = f2; textBoxF3.Text = f3; textBoxF4.Text = f4;
                textBoxF5.Text = f5; textBoxF6.Text = f6; textBoxF7.Text = f7;
                textBoxG1.Text = g1; textBoxG2.Text = g2; textBoxG3.Text = g3; textBoxG4.Text = g4;
                textBoxG5.Text = g5; textBoxG6.Text = g6; textBoxG7.Text = g7;
            }
        }

        /************************************************************************************
         * Method: easyButton_Click
         * 
         * Summary: 
         * 1. If a puzzle is currently loaded, save progress to Globals List and 
         *      rewrite the file data in the easy folder. 
         * 2. Reset the data in textboxes. 
         * 3. Set up visuals for an easy puzzle
         * 4. Load a non-completed puzzle from the easy Globals List and start the puzzle's stopwatch
         ***********************************************************************************/
        private void easyButton_Click(object sender, EventArgs e)
        {
            //Problems occur if changing puzzles when paused, so don't let that happen (we can fix this later)
            if (pauseResumeButton.Text == "Resume")
            {
                MessageBox.Show("Resume game before changing puzzles");
                return;
            }

            if (isEasy)//if current puzzle is an easy puzzle, save
            {
                saveEasy(seconds);
            }
            else if(isMedium)
            {
                saveMedium(seconds);
            }
            else if(isHard)
            {
                saveHard(seconds);
            }

            //set isEasy to true, and isMedium and isHard to false
            isEasy = true;
            isMedium = false;
            isHard = false;

            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            reset_TextBoxes_Labels(); //reset the textboxes' data so nothing carries over to the new puzzle

            //set all easy Labels to visible
            foreach (var label in Globals.easyLabelList)
            {
                label.Visible = true;
            }
            //set all medium Labels to not visible
            foreach (var label in Globals.mediumLabelList)
            {
                label.Visible = false;
            }
            //set all hard Labels to not visible
            foreach (var label in Globals.hardLabelList)
            {
                label.Visible = false;
            }

            //set all easy textboxes to visible, then refresh picture box to update visuals
            for (int i = 0; i < Globals.textBoxesList.Count; i++)
            {
                switch (i) //any case that matches drops through to set visibility to true, any case that doesn't match is defaulted
                {
                    case 16: case 17: case 18:
                    case 23: case 24: case 25:
                    case 30: case 31: case 32:
                        Globals.textBoxesList[i].Visible = true;
                        break;

                    default:
                        Globals.textBoxesList[i].Visible = false;
                        break;

                }
            }
            pictureBox.Refresh();

            //Load a puzzle
            loadEasyPuzzle();
        }

        /************************************************************************************
         * Method: mediumButton_Click
         * 
         * Summary: 
         * 1. If a puzzle is currently loaded, save progress to Globals List and 
         *      rewrite the file in the medium folder. 
         * 2. Reset the data in textboxes. 
         * 3. Set up visuals for a medium puzzle
         * 4. Load a non-completed puzzle from the medium Globals List and start the puzzle's stopwatch
         ***********************************************************************************/
        private void mediumButton_Click(object sender, EventArgs e)
        {
            //Problems occur if changing puzzles when paused, so don't let that happen (we can fix this later)
            if (pauseResumeButton.Text == "Resume")
            {
                MessageBox.Show("Resume game before changing puzzles");
                return;
            }

            if (isEasy)//if current puzzle (before swap) is an easy puzzle, save
            {
                saveEasy(seconds);
            }
            else if (isMedium)
            {
                saveMedium(seconds);
            }
            else if (isHard)
            {
                saveHard(seconds);
            }

            //set isMedium to true, and isEasy and isHard to false
            isEasy = false;
            isMedium = true;
            isHard = false;

            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            reset_TextBoxes_Labels(); //reset the textboxes and labels data so nothing carries over to the new puzzle

            //set all easy Labels to not visible
            foreach (var label in Globals.easyLabelList)
            {
                label.Visible = false;
            }
            //set all medium Labels to visible
            foreach (var label in Globals.mediumLabelList)
            {
                label.Visible = true;
            }
            //set all hard Labels to not visible
            foreach (var label in Globals.hardLabelList)
            {
                label.Visible = false;
            }

            //set all medium difficulty textboxes to visible
            for (int i = 0; i < Globals.textBoxesList.Count; i++)
            {
                switch (i) //any case that matches drops through to set visibility to true, any case that doesn't match is defaulted
                {
                    case 8: case 9: case 10: case 11: case 12:
                    case 15: case 16: case 17: case 18: case 19:
                    case 22: case 23: case 24: case 25: case 26:
                    case 29: case 30: case 31: case 32: case 33:
                    case 36: case 37: case 38: case 39: case 40:
                        Globals.textBoxesList[i].Visible = true;
                        break;

                    default:
                        Globals.textBoxesList[i].Visible = false;
                        break;
                }
            }
            pictureBox.Refresh();

            //load a puzzle
            loadMediumPuzzle();
        }

        /************************************************************************************
         * Method: hardButton_Click
         * 
         * Summary: 
         * 1. If a puzzle is currently loaded, save progress to Globals List and 
         *      rewrite the file data in the hard folder. 
         * 2. Reset the data in textboxes. 
         * 3. Set up visuals for a hard puzzle
         * 4. Load a non-completed puzzle from the hard Globals List and start the puzzle's stopwatch
         ***********************************************************************************/
        private void hardButton_Click(object sender, EventArgs e)
        {
            //Problems occur if changing puzzles when paused, so don't let that happen (we can fix this later)
            if (pauseResumeButton.Text == "Resume")
            {
                MessageBox.Show("Resume game before changing puzzles");
                return;
            }

            if (isEasy)//if current puzzle (before puzzle swap) is an easy puzzle, save
            {
                saveEasy(seconds);
            }
            else if (isMedium)
            {
                saveMedium(seconds);
            }
            else if (isHard)
            {
                saveHard(seconds);
            }

            //set isHard to true, and isEasy and isMedium to false
            isEasy = false;
            isMedium = false;
            isHard = true;

            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            reset_TextBoxes_Labels(); //reset the textboxes' data so nothing carries over to the new puzzle

            //set all easy Labels to not visible
            foreach (var label in Globals.easyLabelList)
            {
                label.Visible = false;
            }
            //set all medium Labels to not visible
            foreach (var label in Globals.mediumLabelList)
            {
                label.Visible = false;
            }
            //set all hard Labels to visible
            foreach (var label in Globals.hardLabelList)
            {
                label.Visible = true;
            }

            //set all hard level textboxes to visible (all textboxes), refresh textbox to update visuals
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.Visible = true;
            }
            pictureBox.Refresh();

            //load a puzzle
            loadHardPuzzle();
        }

        /************************************************************************************
         * Method: loadHardPuzzle
         * 
         * Summary: Loads a non completed Hard puzzle into the application
         ***********************************************************************************/
        private void loadHardPuzzle()
        {

            int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete

            if(Globals.HardList[last].CompleteFlag == 1 && isHard)//if last is equal to 1, we are out of new puzzles so they must solve the current one on this difficulty
            {
                MessageBox.Show("You cannot create a new hard puzzle as we have no more to generate. Please finish this puzzle first.", "WOOPSIE!",MessageBoxButtons.OK);
            }

            if (Globals.HardList[last].CompleteFlag == 0) //If the last item in the list is complete, then they are all complete so reset progress of them all to be solved again
            {
                foreach (var puzzle in Globals.HardList)
                {
                    for (int i = 0; i < puzzle.saved.Length; i++)
                    {
                        puzzle.saved[i] = 0;
                    }
                    puzzle.CompleteFlag = 2;
                }
            }

            //Fill initial textboxes
            for (int i = 0; i < 49; i++)
            {
                if (Globals.HardList[last].unsolved[i] != (uint)0)
                {
                    Globals.textBoxesList[i].Text = Globals.HardList[last].unsolved[i].ToString();
                    Globals.textBoxesList[i].ReadOnly = true;
                    Globals.textBoxesList[i].Font = new Font(Globals.textBoxesList[i].Font, FontStyle.Bold);
                }
            }

            //Fill saved data to texboxes
            for (int i = 0; i < 9; i++)
            {
                if (Globals.HardList[last].saved[i] != (uint)0)
                {
                    Globals.textBoxesList[i].Text = Globals.HardList[last].saved[i].ToString();
                }
            }

            //Fill Answer Labels
            fillHardLabels(last);
            //set the timer
            seconds = Globals.HardList[last].PuzzleTime;
            countTime = true;
        }

        /************************************************************************************
         * Method: loadMediumPuzzle
         * 
         * Summary: Loads a non completed Medium puzzle into the application
         ***********************************************************************************/
        private void loadMediumPuzzle()
        {
            int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete

            if (Globals.MediumList[last].CompleteFlag == 1 && isMedium)//if last is equal to 1, we are out of new puzzles so they must solve the current one on this difficulty
            {
                MessageBox.Show("You cannot create a new medium puzzle as we have no more to generate. Please finish this puzzle first.", "WOOPSIE!", MessageBoxButtons.OK);
            }

            if (Globals.MediumList[last].CompleteFlag == 0) //If the last item in the list is complete, then they are all complete so reset progress of them all to be solved again
            {
                foreach (var puzzle in Globals.MediumList)
                {
                    for (int i = 0; i < puzzle.saved.Length; i++)
                    {
                        puzzle.saved[i] = 0;
                    }
                    puzzle.CompleteFlag = 2;
                }
            }

            //Fill initial textboxes
            for (int i = 0; i < 25; i++)
            {
                if (Globals.MediumList[last].unsolved[i] != (uint)0)
                {
                    Globals.mediumTextBoxesList[i].Text = Globals.MediumList[last].unsolved[i].ToString();
                    Globals.mediumTextBoxesList[i].ReadOnly = true;
                    Globals.mediumTextBoxesList[i].Font = new Font(Globals.mediumTextBoxesList[i].Font, FontStyle.Bold);
                }
            }

            //Fill saved data to texboxes
            for (int i = 0; i < 25; i++)
            {
                if (Globals.MediumList[last].saved[i] != (uint)0)
                {
                    Globals.mediumTextBoxesList[i].Text = Globals.MediumList[last].saved[i].ToString();
                }
            }

            //Fill Answer Labels
            fillMediumLabels(last);
            //set the timer
            seconds = Globals.MediumList[last].PuzzleTime;
            countTime = true;
        }

        /************************************************************************************
         * Method: loadEasyPuzzle
         * 
         * Summary: Loads a non completed Easy puzzle into the application
         ***********************************************************************************/
        private void loadEasyPuzzle()
        {
            int last = Globals.EasyList.Count - 1; //get the last item in the list which should always be non complete

            if (Globals.EasyList[last].CompleteFlag == 1 && isEasy)//if last is equal to 1, we are out of new puzzles so they must solve the current one on this difficulty
            {
                MessageBox.Show("You cannot create a new easy puzzle as we have no more to generate. Please finish this puzzle first.", "WOOPSIE!", MessageBoxButtons.OK);
            }

            if (Globals.EasyList[last].CompleteFlag == 0) //If the last item in the list is complete, then they are all complete so reset progress of them all
            {
                foreach (var puzzle in Globals.EasyList)
                {
                    for (int i = 0; i < puzzle.saved.Length; i++)
                    {
                        puzzle.saved[i] = 0;
                    }
                    puzzle.CompleteFlag = 2;
                }
            }

            //Fill initial puzzle data to textboxes & set them to uneditable
            for (int i = 0; i < 9; i++)
            {
                if (Globals.EasyList[last].unsolved[i] != (uint)0)
                {
                    Globals.easyTextBoxesList[i].Text = Globals.EasyList[last].unsolved[i].ToString();
                    Globals.easyTextBoxesList[i].ReadOnly = true;
                    Globals.easyTextBoxesList[i].Font = new Font(Globals.easyTextBoxesList[i].Font, FontStyle.Bold);
                }
            }

            //Fill saved data to texboxes
            for (int i = 0; i < 9; i++)
            {
                if (Globals.EasyList[last].saved[i] != (uint)0)
                {
                    Globals.easyTextBoxesList[i].Text = Globals.EasyList[last].saved[i].ToString();
                }
            }

            //Fill Answer Labels
            fillEasyLabels(last);

            //set the timer
            seconds = Globals.EasyList[last].PuzzleTime;
            countTime = true;
        }

        /************************************************************************************
         * Method: saveHard
         * 
         * Summary: Saves the current hard puzzle by writing its info back to the file 
         ***********************************************************************************/
        private void saveHard(int timer)
        {
            int last = Globals.HardList.Count - 1; //index of the currently active puzzle in the list

            Globals.HardList[last].PuzzleTime = timer;

            bool startedCheck = false;

            //store all current textbox data into the puzzle's saved array
            for (int i = 0; i < 25; i++)
            {
                if (String.IsNullOrEmpty(Globals.textBoxesList[i].Text))//if textbox is null/empty data should be a zero
                {
                    Globals.HardList[last].saved[i] = (uint)0;
                }
                else
                {
                    Globals.HardList[last].saved[i] = Convert.ToUInt32(Globals.textBoxesList[i].Text);
                }
            }

            if (!Globals.HardList[last].saved.SequenceEqual(Globals.HardList[last].unsolved))//Check for a difference to see if the puzzle was started
                startedCheck = true;

            if (startedCheck)//if the puzzle was started, data should be written to file and set completedFlag to saved (1)
            {
                using (StreamWriter puzzleFile = new StreamWriter(Globals.HardList[last].Name))
                {
                    for (int i = 0; i < 49; i += 7)//write the unsolved lines
                    {
                        puzzleFile.WriteLine(Globals.HardList[last].unsolved[i].ToString() + Globals.HardList[last].unsolved[i + 1].ToString() + Globals.HardList[last].unsolved[i + 2].ToString()
                            + Globals.HardList[last].unsolved[i + 3].ToString() + Globals.HardList[last].unsolved[i + 4].ToString() + Globals.HardList[last].unsolved[i + 5].ToString()
                            + Globals.HardList[last].unsolved[i + 6].ToString());
                    }

                    puzzleFile.WriteLine();//write a blank line

                    for (int i = 0; i < 49; i += 7)//write the completed lines
                    {
                        puzzleFile.WriteLine(Globals.HardList[last].completed[i].ToString() + Globals.HardList[last].completed[i + 1].ToString() + Globals.HardList[last].completed[i + 2].ToString()
                            + Globals.HardList[last].completed[i + 3].ToString() + Globals.HardList[last].completed[i + 4].ToString() + Globals.HardList[last].completed[i + 5].ToString()
                            + Globals.HardList[last].completed[i + 6].ToString());
                    }

                    puzzleFile.WriteLine();//write a blank line

                    for (int i = 0; i < 49; i += 7)//write the saved lines
                    {
                        puzzleFile.WriteLine(Globals.HardList[last].saved[i].ToString() + Globals.HardList[last].saved[i + 1].ToString() + Globals.HardList[last].saved[i + 2].ToString()
                            + Globals.HardList[last].saved[i + 3].ToString() + Globals.HardList[last].saved[i + 4].ToString() + Globals.HardList[last].saved[i + 4].ToString()
                            + Globals.HardList[last].saved[i + 4].ToString());
                    }
                    puzzleFile.WriteLine(Globals.HardList[last].PuzzleTime);
                }

                Globals.HardList[last].CompleteFlag = 1;
                //EasyList should update to accomodate flag change, new puzzle should be [last] index
                Globals.HardList.Sort((x, y) => x.CompleteFlag.CompareTo(y.CompleteFlag));
            }
        }

        /************************************************************************************
         * Method: saveMedium
         * 
         * Summary: Saves the current medium puzzle by writing its info back to the file 
         ***********************************************************************************/
        private void saveMedium(int timer)
        {
            int last = Globals.MediumList.Count - 1; //index of the currently active puzzle in the list

            Globals.MediumList[last].PuzzleTime = timer;

            bool startedCheck = false;

            //store all current textbox data into the puzzle's saved array
            for (int i = 0; i < 25; i++)
            {
                if (String.IsNullOrEmpty(Globals.mediumTextBoxesList[i].Text))//if textbox is null/empty data should be a zero
                {
                    Globals.MediumList[last].saved[i] = (uint)0;
                }
                else
                {
                    Globals.MediumList[last].saved[i] = Convert.ToUInt32(Globals.mediumTextBoxesList[i].Text);
                }
            }

            if (!Globals.MediumList[last].saved.SequenceEqual(Globals.MediumList[last].unsolved))//Check for a difference to see if the puzzle was started
                startedCheck = true;

            if (startedCheck)//if the puzzle was started, data should be written to file and set completedFlag to saved (1)
            {
                using (StreamWriter puzzleFile = new StreamWriter(Globals.MediumList[last].Name))
                {
                    for (int i = 0; i < 25; i += 5)//write the unsolved lines
                    {
                        puzzleFile.WriteLine(Globals.MediumList[last].unsolved[i].ToString() + Globals.MediumList[last].unsolved[i + 1].ToString() + Globals.MediumList[last].unsolved[i + 2].ToString()
                            + Globals.MediumList[last].unsolved[i+3].ToString() + Globals.MediumList[last].unsolved[i+ 4].ToString());
                    }

                    puzzleFile.WriteLine();//write a blank line

                    for (int i = 0; i < 25; i += 5)//write the completed lines
                    {
                        puzzleFile.WriteLine(Globals.MediumList[last].completed[i].ToString() + Globals.MediumList[last].completed[i + 1].ToString() + Globals.MediumList[last].completed[i + 2].ToString()
                            + Globals.MediumList[last].completed[i + 3].ToString() + Globals.MediumList[last].completed[i+4].ToString());
                    }

                    puzzleFile.WriteLine();//write a blank line

                    for (int i = 0; i < 25; i += 5)//write the saved lines
                    {
                        puzzleFile.WriteLine(Globals.MediumList[last].saved[i].ToString() + Globals.MediumList[last].saved[i + 1].ToString() + Globals.MediumList[last].saved[i + 2].ToString()
                            + Globals.MediumList[last].saved[i+3].ToString() + Globals.MediumList[last].saved[i+4].ToString());
                    }
                    puzzleFile.WriteLine(Globals.MediumList[last].PuzzleTime);
                }

                Globals.MediumList[last].CompleteFlag = 1;
                //EasyList should update to accomodate flag change, new puzzle should be [last] index
                Globals.MediumList.Sort((x, y) => x.CompleteFlag.CompareTo(y.CompleteFlag));
            }
        }

        /************************************************************************************
         * Method: saveEasy
         * 
         * Summary: Saves the current easy puzzle by writing its info back to the file 
         ***********************************************************************************/
        private void saveEasy(int timer)
        {
            int last = Globals.EasyList.Count - 1; //index of the currently active puzzle in the list

            Globals.EasyList[last].PuzzleTime = timer;

            bool startedCheck = false;

            //store all current textbox data into the puzzle's saved array
            for(int i = 0; i < 9; i++)
            {
                if(String.IsNullOrEmpty(Globals.easyTextBoxesList[i].Text))//if textbox is null/empty data should be a zero
                {
                    Globals.EasyList[last].saved[i] = (uint)0;
                }
                else
                {
                    Globals.EasyList[last].saved[i] = Convert.ToUInt32(Globals.easyTextBoxesList[i].Text);
                }
            }

            if (!Globals.EasyList[last].saved.SequenceEqual(Globals.EasyList[last].unsolved))//Check for a difference to see if the puzzle was started
                startedCheck = true;

            if(startedCheck)//if the puzzle was started, data should be written to file and set completedFlag to saved (1)
            {
                using(StreamWriter puzzleFile = new StreamWriter(Globals.EasyList[last].Name))
                {
                    for(int i = 0; i < 9; i+=3)//write the unsolved lines
                    {
                        puzzleFile.WriteLine(Globals.EasyList[last].unsolved[i].ToString() + Globals.EasyList[last].unsolved[i + 1].ToString() + Globals.EasyList[last].unsolved[i + 2].ToString());
                    }

                    puzzleFile.WriteLine();//write a blank line

                    for (int i = 0; i < 9; i += 3)//write the completed lines
                    {
                        puzzleFile.WriteLine(Globals.EasyList[last].completed[i].ToString() + Globals.EasyList[last].completed[i + 1].ToString() + Globals.EasyList[last].completed[i + 2].ToString());
                    }

                    puzzleFile.WriteLine();//write a blank line

                    for (int i = 0; i < 9; i += 3)//write the saved lines
                    {
                        puzzleFile.WriteLine(Globals.EasyList[last].saved[i].ToString() + Globals.EasyList[last].saved[i + 1].ToString() + Globals.EasyList[last].saved[i + 2].ToString());
                    }
                    puzzleFile.WriteLine(Globals.EasyList[last].PuzzleTime);
                }

                Globals.EasyList[last].CompleteFlag = 1;
                //EasyList should update to accomodate flag change, new puzzle should be [last] index
                Globals.EasyList.Sort((x, y) => x.CompleteFlag.CompareTo(y.CompleteFlag));
            }
        }

        /*************************************************************************************
         * Method: reset_TextBoxes_Labels
         * 
         * Summary: Clear all of the textboxes and Labels
         ************************************************************************************/
        private void reset_TextBoxes_Labels()
        {
            //reset cheat flag
            cheatFlag = false;

            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.ReadOnly = false;
                textbox.Font = new Font(textbox.Font, FontStyle.Regular);
                textbox.Clear(); //clears the contents of the textbox
                textbox.ClearUndo(); //clears the Undo buffer of the textbox (you're starting a new puzzle silly tf you gonna undo)
            }

            foreach (var label in Globals.easyLabelList)
            {
                label.Visible = false;
                label.ForeColor = Color.White;
            }
        }

        /*************************************************************************************
         * Method: resetButton_Click
         * 
         * Summary: Reset the puzzle board to the original state of the puzzle.
         ************************************************************************************/
        private void resetButton_Click(object sender, EventArgs e)
        {
            //Reset the texboxes then set them back to the original state
            reset_TextBoxes_Labels();
            if (isEasy)
            {
                //reset the puzzle's saved time
                Globals.EasyList[Globals.EasyList.Count - 1].PuzzleTime = 0;
                //reload the puzzle
                loadEasyPuzzle();

                //set all easy Labels to visible
                foreach (var label in Globals.easyLabelList)
                {
                    label.Visible = true;
                }
            }
            if (isMedium)
            {
                //reset the puzzle's saved time
                Globals.MediumList[Globals.MediumList.Count - 1].PuzzleTime = 0;
                //reload the puzzle
                loadMediumPuzzle();

                //set all medium Labels to visible
                foreach (var label in Globals.mediumLabelList)
                {
                    label.Visible = true;
                }
            }
            if (isHard)
            {
                //reset the puzzle's saved time
                Globals.HardList[Globals.HardList.Count - 1].PuzzleTime = 0;
                //reload the puzzle
                loadHardPuzzle();

                //set all hard Labels to visible
                foreach (var label in Globals.hardLabelList)
                {
                    label.Visible = true;
                }
            }

            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }
        }

        /************************************************************************************
         * Method: textBox_Validate
         * 
         * Summary: Keypress Function that validates input to only be a single digit 1-9
         ***********************************************************************************/
        private void textBox_Validate(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) || e.KeyChar == '0')
            {
                e.Handled = true;
            }
        }

        /************************************************************************************
         * Method: timer_Tick
         * 
         * Summary: Increment the timer so that it ticks once a second.
         ***********************************************************************************/
        private void timer_Tick(object sender, EventArgs e)
        {
            if (countTime == true)
            {
                timerLabel.Text = seconds.ToString();
                seconds++;
            }
        }

        /************************************************************************************
         * Method: hintButton_Click
         * 
         * Summary: If all of the text boxes are filled, choose the first cell found in a
         *  sequential search that isn't correct, and change it to the correct value. IF not
         *  all of the text boxes are filled, pick one at random and fill in the correct
         *  answer.
         ***********************************************************************************/
        private void hintButton_Click(object sender, EventArgs e)
        {
            //set cheatFlag to true to invalidate time in check_Completion
            cheatFlag = true;
            int i = 0;
            int last; //get the last item in the list which should always be non complete
            List<TextBox> emptyEasy = new List<TextBox>();

            if (isEasy)
            {
                //Get the last element in the list
                last = Globals.EasyList.Count - 1;
                //empty check
                bool emptyBoxesExist = false;

                //check easy texboxes for an empty box, if there is one set the flag to true
                foreach (var textbox in Globals.easyTextBoxesList)
                {
                    //if all of the textboxes are not filled up, highlight a random box and fill in the right answer
                    if (textbox.Text == "")
                    {
                        emptyBoxesExist = true;
                    }
                }

                if(emptyBoxesExist)//if empty textbox exists, fill in a random empty textbox
                {
                    while(true)
                    {
                        //Generate a random index number
                        Random r = new Random();
                        int rInt = r.Next(0, 9);

                        if(Globals.easyTextBoxesList[rInt].Text == "")//if the random text box is empty, fill it and exit function, otherwise skip and generate a new one
                        {
                            Globals.easyTextBoxesList[rInt].BackColor = Color.Yellow;
                            Globals.easyTextBoxesList[rInt].Text = Convert.ToString(Globals.EasyList[last].completed[rInt]);
                            return;
                        }
                    }
                }

                //foreach textbox that are used for an easy puzzle
                foreach (var textbox in Globals.easyTextBoxesList)
                {
                    //if the user's answer is incorrect, highlight it and fill in the right answer
                    if (textbox.Text != Convert.ToString(Globals.EasyList[last].completed[i]))
                    {
                        textbox.BackColor = Color.Yellow;
                        textbox.Text = Convert.ToString(Globals.EasyList[last].completed[i]);
                        return;
                    }
                    i++; //increment the counter
                }
            }
            else if (isMedium)
            {
                //Get the last element in the list
                last = Globals.MediumList.Count - 1;

                //empty check
                bool emptyBoxesExist = false;

                //check easy texboxes for an empty box, if there is one set the flag to true
                foreach (var textbox in Globals.mediumTextBoxesList)
                {
                    //if all of the textboxes are not filled up, highlight a random box and fill in the right answer
                    if (textbox.Text == "")
                    {
                        emptyBoxesExist = true;
                    }
                }

                if (emptyBoxesExist)//if empty textbox exists, fill in a random empty textbox
                {
                    while (true)
                    {
                        //Generate a random index number
                        Random r = new Random();
                        int rInt = r.Next(0, 25);

                        if (Globals.mediumTextBoxesList[rInt].Text == "")//if the random text box is empty, fill it and exit function, otherwise skip and generate a new one
                        {
                            Globals.mediumTextBoxesList[rInt].BackColor = Color.Yellow;
                            Globals.mediumTextBoxesList[rInt].Text = Convert.ToString(Globals.MediumList[last].completed[rInt]);
                            return;
                        }
                    }
                }

                //foreach textbox that are used for a medium puzzle
                foreach (var textbox in Globals.mediumTextBoxesList)
                {
                    //if the user's answer is incorrect, highlight it and fill in the right answer
                    if (textbox.Text != Convert.ToString(Globals.MediumList[last].completed[i]))
                    {
                        textbox.BackColor = Color.Yellow;
                        textbox.Text = Convert.ToString(Globals.MediumList[last].completed[i]);
                        return;
                    }
                    i++; //increment the counter
                }
            }
            else if (isHard)
            {
                //Get the last element in the list
                last = Globals.HardList.Count - 1;

                //empty check
                bool emptyBoxesExist = false;

                //check easy texboxes for an empty box, if there is one set the flag to true
                foreach (var textbox in Globals.textBoxesList)
                {
                    //if all of the textboxes are not filled up, highlight a random box and fill in the right answer
                    if (textbox.Text == "")
                    {
                        emptyBoxesExist = true;
                    }
                }

                if (emptyBoxesExist)//if empty textbox exists, fill in a random empty textbox
                {
                    while (true)
                    {
                        //Generate a random index number
                        Random r = new Random();
                        int rInt = r.Next(0, 49);

                        if (Globals.textBoxesList[rInt].Text == "")//if the random text box is empty, fill it and exit function, otherwise skip and generate a new one
                        {
                            Globals.textBoxesList[rInt].BackColor = Color.Yellow;
                            Globals.textBoxesList[rInt].Text = Convert.ToString(Globals.HardList[last].completed[rInt]);
                            return;
                        }
                    }
                }

                //foreach textbox that are used for a hard puzzle
                foreach (var textbox in Globals.textBoxesList)
                {
                    //if the user's answer is incorrect, highlight it and fill in the right answer
                    if (textbox.Text != Convert.ToString(Globals.HardList[last].completed[i]))
                    {
                        textbox.BackColor = Color.Yellow;
                        textbox.Text = Convert.ToString(Globals.HardList[last].completed[i]);
                        return;
                    }
                    i++; //increment the counter
                }
            }
        }

        /************************************************************************************
         * Method: progressButton_Click
         * 
         * Summary: Highlight the cells where there is an incorrect answer. If no wrong
         *  answers, output a message.
         ***********************************************************************************/
        private void progressButton_Click(object sender, EventArgs e)
        {
            int i = 0;  //counter
            int last; //get the last item in the list which should always be non complete
            bool correct = true; //turn false if there is a mistake
            bool allFilledFlag = true; //checks if every box has been filled

            if (isEasy)
            {
                //Get the last element in the list
                last = Globals.EasyList.Count - 1;

                //foreach textbox that are used for an easy puzzle
                foreach (var textbox in Globals.easyTextBoxesList)
                {
                    //if the textbox has a value entered in it
                    if (textbox.Text != "")
                    {
                        //if the user's answer is incorrect, highlight rpw/column/diagonal where the mistake occured
                        if (textbox.Text != Convert.ToString(Globals.EasyList[last].completed[i]))
                        {
                            textbox.BackColor = Color.LightPink;
                            correct = false;
                        }
                    }
                    //If a textbox if empty set the allFilledFlag to false
                    else if(textbox.Text == "")
                    {
                        allFilledFlag = false;
                    }
                    i++;
                }

                if(correct && allFilledFlag && Globals.EasyList[last].CompleteFlag != 0)
                {
                    puzzle_Completion();
                }
                else if (correct)
                {
                    MessageBox.Show("All cells are correct so far. Keep it up!");
                }
            }
            else if (isMedium)
            {
                //Get the last element in the list
                last = Globals.MediumList.Count - 1;

                //foreach textbox that are used for an easy puzzle
                foreach (var textbox in Globals.mediumTextBoxesList)
                {
                    //if the textbox has a value entered in it
                    if (textbox.Text != "")
                    {
                        //if the user's answer is incorrect, highlight rpw/column/diagonal where the mistake occured
                        if (textbox.Text != Convert.ToString(Globals.MediumList[last].completed[i]))
                        {
                            textbox.BackColor = Color.LightPink;
                            correct = false;
                        }
                    }
                    else if(textbox.Text == "")
                    {
                        allFilledFlag = false;
                    }
                    i++;
                }

                if(correct && allFilledFlag && Globals.MediumList[last].CompleteFlag != 0)
                {
                    puzzle_Completion();
                }
                else if (correct)
                {
                    MessageBox.Show("All cells are correct so far. Keep it up!");
                }
            }
            else if (isHard)
            {
                //Get the last element in the list
                last = Globals.HardList.Count - 1;

                //foreach textbox that are used for an easy puzzle
                foreach (var textbox in Globals.textBoxesList)
                {
                    //if the textbox has a value entered in it
                    if (textbox.Text != "")
                    {
                        //if the user's answer is incorrect, highlight rpw/column/diagonal where the mistake occured
                        if (textbox.Text != Convert.ToString(Globals.HardList[last].completed[i]))
                        {
                            textbox.BackColor = Color.LightPink;
                            correct = false;
                        }
                    }
                    else if(textbox.Text == "")
                    {
                        allFilledFlag = false;
                    }
                    i++;
                }
                if(correct && allFilledFlag && Globals.HardList[last].CompleteFlag != 0)
                {
                    puzzle_Completion();
                }
                else if (correct)
                {
                    MessageBox.Show("All cells are correct so far. Keep it up!");
                }
            }
        }

        /************************************************************************************
         * Method: fillEasyLabels
         * 
         * Summary: Fill in the final answer for each row/column/diagonal, and also in the
         *  progress answer for each of those depnding on what the user has entered for the
         *  easy puzzles.
         ***********************************************************************************/
        private void fillEasyLabels(int last)
        {
            //variables to hold the values of each text box
            Int32 x = 0, y = 0, z = 0, val = 0, answer = 0;

            //Fill in all of the easy labels
            easyR1AnswerLabel.Text = Convert.ToString(Globals.EasyList[last].completed[0] + Globals.EasyList[last].completed[1] + Globals.EasyList[last].completed[2]);
            if (textBoxC3.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxC3.Text, out x); }
            if (textBoxC4.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxC4.Text, out y); }
            if (textBoxC5.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxC5.Text, out z); }
            val = x + y + z;
            easyR1ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(easyR1AnswerLabel.Text, out answer);
            //if the answer and progress labels match, set the progress label to green
            if (easyR1AnswerLabel.Text == easyR1ProgressLabel.Text) { easyR1ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            //if the progress label is greater than the answer, or all boxes have been filled and the labels are not equal, set the progress label to red
            else if ((answer < val) || (textBoxC3.Text != "" && textBoxC4.Text != "" && textBoxC5.Text != ""))
                { easyR1ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            //else, set the progress label to gray
            else { easyR1ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            easyR2AnswerLabel.Text = Convert.ToString(Globals.EasyList[last].completed[3] + Globals.EasyList[last].completed[4] + Globals.EasyList[last].completed[5]);
            if (textBoxD3.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxD3.Text, out x); }
            if (textBoxD4.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxD4.Text, out y); }
            if (textBoxD5.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxD5.Text, out z); }
            val = x + y + z;
            easyR2ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(easyR2AnswerLabel.Text, out answer);
            if (easyR2AnswerLabel.Text == easyR2ProgressLabel.Text) { easyR2ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxD3.Text != "" && textBoxD4.Text != "" && textBoxD5.Text != ""))
                { easyR2ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { easyR2ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            easyR3AnswerLabel.Text = Convert.ToString(Globals.EasyList[last].completed[6] + Globals.EasyList[last].completed[7] + Globals.EasyList[last].completed[8]);
            if (textBoxE3.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxE3.Text, out x); }
            if (textBoxE4.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxE4.Text, out y); }
            if (textBoxE5.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxE5.Text, out z); }
            val = x + y + z;
            easyR3ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(easyR3AnswerLabel.Text, out answer);
            if (easyR3AnswerLabel.Text == easyR3ProgressLabel.Text) { easyR3ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxE3.Text != "" && textBoxE4.Text != "" && textBoxE5.Text != ""))
                { easyR3ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { easyR3ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            easyC1AnswerLabel.Text = Convert.ToString(Globals.EasyList[last].completed[0] + Globals.EasyList[last].completed[3] + Globals.EasyList[last].completed[6]);
            if (textBoxC3.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxC3.Text, out x); }
            if (textBoxD3.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxD3.Text, out y); }
            if (textBoxE3.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxE3.Text, out z); }
            val = x + y + z;
            easyC1ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(easyC1AnswerLabel.Text, out answer);
            if (easyC1AnswerLabel.Text == easyC1ProgressLabel.Text) { easyC1ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxC3.Text != "" && textBoxD3.Text != "" && textBoxE3.Text != ""))
                { easyC1ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { easyC1ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            easyC2AnswerLabel.Text = Convert.ToString(Globals.EasyList[last].completed[1] + Globals.EasyList[last].completed[4] + Globals.EasyList[last].completed[7]);
            if (textBoxC4.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxC4.Text, out x); }
            if (textBoxD4.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxD4.Text, out y); }
            if (textBoxE4.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxE4.Text, out z); }
            val = x + y + z;
            easyC2ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(easyC2AnswerLabel.Text, out answer);
            if (easyC2AnswerLabel.Text == easyC2ProgressLabel.Text) { easyC2ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxC4.Text != "" && textBoxD4.Text != "" && textBoxE4.Text != ""))
                { easyC2ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { easyC2ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            easyC3AnswerLabel.Text = Convert.ToString(Globals.EasyList[last].completed[2] + Globals.EasyList[last].completed[5] + Globals.EasyList[last].completed[8]);
            if (textBoxC5.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxC5.Text, out x); }
            if (textBoxD5.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxD5.Text, out y); }
            if (textBoxE5.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxE5.Text, out z); }
            val = x + y + z;
            easyC3ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(easyC3AnswerLabel.Text, out answer);
            if (easyC3AnswerLabel.Text == easyC3ProgressLabel.Text) { easyC3ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxC5.Text != "" && textBoxD5.Text != "" && textBoxE5.Text != ""))
                { easyC3ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { easyC3ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            easyD1AnswerLabel.Text = Convert.ToString(Globals.EasyList[last].completed[0] + Globals.EasyList[last].completed[4] + Globals.EasyList[last].completed[8]);
            if (textBoxC3.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxC3.Text, out x); }
            if (textBoxD4.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxD4.Text, out y); }
            if (textBoxE5.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxE5.Text, out z); }
            val = x + y + z;
            easyD1ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(easyD1AnswerLabel.Text, out answer);
            if (easyD1AnswerLabel.Text == easyD1ProgressLabel.Text) { easyD1ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxC3.Text != "" && textBoxD4.Text != "" && textBoxE5.Text != ""))
                { easyD1ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { easyD1ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            easyD2AnswerLabel.Text = Convert.ToString(Globals.EasyList[last].completed[6] + Globals.EasyList[last].completed[4] + Globals.EasyList[last].completed[2]);
            if (textBoxE3.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxE3.Text, out x); }
            if (textBoxD4.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxD4.Text, out y); }
            if (textBoxC5.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxC5.Text, out z); }
            val = x + y + z;
            easyD2ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(easyD2AnswerLabel.Text, out answer);
            if (easyD2AnswerLabel.Text == easyD2ProgressLabel.Text) { easyD2ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxE3.Text != "" && textBoxD4.Text != "" && textBoxC5.Text != ""))
                { easyD2ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { easyD2ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }
        }

        /************************************************************************************
         * Method: fillMediumLabels
         * 
         * Summary: Fill in the final answer for each row/column/diagonal, and also in the
         *  progress answer for each of those depnding on what the user has entered for the
         *  medium puzzles.
         ***********************************************************************************/
        private void fillMediumLabels(int last)
        {
            //variables to hold the values of each text box
            Int32 v = 0, w = 0, x = 0, y = 0, z = 0, val = 0, answer = 0;

            //Fill in all of the medium labels
            mediumR1AnswerLabel.Text = Convert.ToString(Globals.MediumList[last].completed[0] + Globals.MediumList[last].completed[1] + Globals.MediumList[last].completed[2] + Globals.MediumList[last].completed[3] + Globals.MediumList[last].completed[4]);
            if (textBoxB2.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxB2.Text, out v); }
            if (textBoxB3.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxB3.Text, out w); }
            if (textBoxB4.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxB4.Text, out x); }
            if (textBoxB5.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxB5.Text, out y); }
            if (textBoxB6.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxB6.Text, out z); }
            val = v + w + x + y + z;
            mediumR1ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(mediumR1AnswerLabel.Text, out answer);
            //if the answer and progress labels match, set the progress label to green
            if (mediumR1AnswerLabel.Text == mediumR1ProgressLabel.Text) { mediumR1ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxB2.Text != "" && textBoxB3.Text != "" && textBoxB4.Text != "" && textBoxB5.Text != "" && textBoxB6.Text != ""))
                { mediumR1ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { mediumR1ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            mediumR2AnswerLabel.Text = Convert.ToString(Globals.MediumList[last].completed[5] + Globals.MediumList[last].completed[6] + Globals.MediumList[last].completed[7] + Globals.MediumList[last].completed[8] + Globals.MediumList[last].completed[9]);
            if (textBoxC2.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxC2.Text, out v); }
            if (textBoxC3.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxC3.Text, out w); }
            if (textBoxC4.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxC4.Text, out x); }
            if (textBoxC5.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxC5.Text, out y); }
            if (textBoxC6.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxC6.Text, out z); }
            val = v + w + x + y + z;
            mediumR2ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(mediumR2AnswerLabel.Text, out answer);
            if (mediumR2AnswerLabel.Text == mediumR2ProgressLabel.Text) { mediumR2ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxC2.Text != "" && textBoxC3.Text != "" && textBoxC4.Text != "" && textBoxC5.Text != "" && textBoxC6.Text != ""))
                { mediumR2ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { mediumR2ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            mediumR3AnswerLabel.Text = Convert.ToString(Globals.MediumList[last].completed[10] + Globals.MediumList[last].completed[11] + Globals.MediumList[last].completed[12] + Globals.MediumList[last].completed[13] + Globals.MediumList[last].completed[14]);
            if (textBoxD2.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxD2.Text, out v); }
            if (textBoxD3.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxD3.Text, out w); }
            if (textBoxD4.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxD4.Text, out x); }
            if (textBoxD5.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxD5.Text, out y); }
            if (textBoxD6.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxD6.Text, out z); }
            val = v + w + x + y + z;
            mediumR3ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(mediumR3AnswerLabel.Text, out answer);
            if (mediumR3AnswerLabel.Text == mediumR3ProgressLabel.Text) { mediumR3ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxD2.Text != "" && textBoxD3.Text != "" && textBoxD4.Text != "" && textBoxD5.Text != "" && textBoxD6.Text != ""))
                { mediumR3ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { mediumR3ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            mediumR4AnswerLabel.Text = Convert.ToString(Globals.MediumList[last].completed[15] + Globals.MediumList[last].completed[16] + Globals.MediumList[last].completed[17] + Globals.MediumList[last].completed[18] + Globals.MediumList[last].completed[19]);
            if (textBoxE2.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxE2.Text, out v); }
            if (textBoxE3.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxE3.Text, out w); }
            if (textBoxE4.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxE4.Text, out x); }
            if (textBoxE5.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxE5.Text, out y); }
            if (textBoxE6.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxE6.Text, out z); }
            val = v + w + x + y + z;
            mediumR4ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(mediumR4AnswerLabel.Text, out answer);
            if (mediumR4AnswerLabel.Text == mediumR4ProgressLabel.Text) { mediumR4ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxE2.Text != "" && textBoxE3.Text != "" && textBoxE4.Text != "" && textBoxE5.Text != "" && textBoxE6.Text != ""))
                { mediumR4ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { mediumR4ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            mediumR5AnswerLabel.Text = Convert.ToString(Globals.MediumList[last].completed[20] + Globals.MediumList[last].completed[21] + Globals.MediumList[last].completed[22] + Globals.MediumList[last].completed[23] + Globals.MediumList[last].completed[24]);
            if (textBoxF2.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxF2.Text, out v); }
            if (textBoxF3.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxF3.Text, out w); }
            if (textBoxF4.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxF4.Text, out x); }
            if (textBoxF5.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxF5.Text, out y); }
            if (textBoxF6.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxF6.Text, out z); }
            val = v + w + x + y + z;
            mediumR5ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(mediumR5AnswerLabel.Text, out answer);
            if (mediumR5AnswerLabel.Text == mediumR5ProgressLabel.Text) { mediumR5ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxF2.Text != "" && textBoxF3.Text != "" && textBoxF4.Text != "" && textBoxF5.Text != "" && textBoxF6.Text != ""))
                { mediumR5ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { mediumR5ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            mediumD1AnswerLabel.Text = Convert.ToString(Globals.MediumList[last].completed[0] + Globals.MediumList[last].completed[6] + Globals.MediumList[last].completed[12] + Globals.MediumList[last].completed[18] + Globals.MediumList[last].completed[24]);
            if (textBoxB2.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxB2.Text, out v); }
            if (textBoxC3.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxC3.Text, out w); }
            if (textBoxD4.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxD4.Text, out x); }
            if (textBoxE5.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxE5.Text, out y); }
            if (textBoxF6.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxF6.Text, out z); }
            val = v + w + x + y + z;
            mediumD1ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(mediumD1AnswerLabel.Text, out answer);
            if (mediumD1AnswerLabel.Text == mediumD1ProgressLabel.Text) { mediumD1ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxB2.Text != "" && textBoxC3.Text != "" && textBoxD4.Text != "" && textBoxE5.Text != "" && textBoxF6.Text != ""))
                { mediumD1ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { mediumD1ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            mediumD2AnswerLabel.Text = Convert.ToString(Globals.MediumList[last].completed[20] + Globals.MediumList[last].completed[16] + Globals.MediumList[last].completed[12] + Globals.MediumList[last].completed[8] + Globals.MediumList[last].completed[4]);
            if (textBoxF2.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxF2.Text, out v); }
            if (textBoxE3.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxE3.Text, out w); }
            if (textBoxD4.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxD4.Text, out x); }
            if (textBoxC5.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxC5.Text, out y); }
            if (textBoxB6.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxB6.Text, out z); }
            val = v + w + x + y + z;
            mediumD2ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(mediumD2AnswerLabel.Text, out answer);
            if (mediumD2AnswerLabel.Text == mediumD2ProgressLabel.Text) { mediumD2ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxF2.Text != "" && textBoxE3.Text != "" && textBoxD4.Text != "" && textBoxC5.Text != "" && textBoxB6.Text != ""))
                { mediumD2ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { mediumD2ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            mediumC1AnswerLabel.Text = Convert.ToString(Globals.MediumList[last].completed[0] + Globals.MediumList[last].completed[5] + Globals.MediumList[last].completed[10] + Globals.MediumList[last].completed[15] + Globals.MediumList[last].completed[20]);
            if (textBoxB2.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxB2.Text, out v); }
            if (textBoxC2.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxC2.Text, out w); }
            if (textBoxD2.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxD2.Text, out x); }
            if (textBoxE2.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxE2.Text, out y); }
            if (textBoxF2.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxF2.Text, out z); }
            val = v + w + x + y + z;
            mediumC1ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(mediumC1AnswerLabel.Text, out answer);
            if (mediumC1AnswerLabel.Text == mediumC1ProgressLabel.Text) { mediumC1ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxB2.Text != "" && textBoxC2.Text != "" && textBoxD2.Text != "" && textBoxE2.Text != "" && textBoxF2.Text != ""))
                { mediumC1ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { mediumC1ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            mediumC2AnswerLabel.Text = Convert.ToString(Globals.MediumList[last].completed[1] + Globals.MediumList[last].completed[6] + Globals.MediumList[last].completed[11] + Globals.MediumList[last].completed[16] + Globals.MediumList[last].completed[21]);
            if (textBoxB3.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxB3.Text, out v); }
            if (textBoxC3.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxC3.Text, out w); }
            if (textBoxD3.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxD3.Text, out x); }
            if (textBoxE3.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxE3.Text, out y); }
            if (textBoxF3.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxF3.Text, out z); }
            val = v + w + x + y + z;
            mediumC2ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(mediumC2AnswerLabel.Text, out answer);
            if (mediumC2AnswerLabel.Text == mediumC2ProgressLabel.Text) { mediumC2ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxB3.Text != "" && textBoxC3.Text != "" && textBoxD3.Text != "" && textBoxE3.Text != "" && textBoxF3.Text != ""))
                { mediumC2ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { mediumC2ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            mediumC3AnswerLabel.Text = Convert.ToString(Globals.MediumList[last].completed[2] + Globals.MediumList[last].completed[7] + Globals.MediumList[last].completed[12] + Globals.MediumList[last].completed[17] + Globals.MediumList[last].completed[22]);
            if (textBoxB4.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxB4.Text, out v); }
            if (textBoxC4.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxC4.Text, out w); }
            if (textBoxD4.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxD4.Text, out x); }
            if (textBoxE4.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxE4.Text, out y); }
            if (textBoxF4.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxF4.Text, out z); }
            val = v + w + x + y + z;
            mediumC3ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(mediumC3AnswerLabel.Text, out answer);
            if (mediumC3AnswerLabel.Text == mediumC3ProgressLabel.Text) { mediumC3ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxB4.Text != "" && textBoxC4.Text != "" && textBoxD4.Text != "" && textBoxE4.Text != "" && textBoxF4.Text != ""))
                { mediumC3ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { mediumC3ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            mediumC4AnswerLabel.Text = Convert.ToString(Globals.MediumList[last].completed[3] + Globals.MediumList[last].completed[8] + Globals.MediumList[last].completed[13] + Globals.MediumList[last].completed[18] + Globals.MediumList[last].completed[23]);
            if (textBoxB5.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxB5.Text, out v); }
            if (textBoxC5.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxC5.Text, out w); }
            if (textBoxD5.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxD5.Text, out x); }
            if (textBoxE5.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxE5.Text, out y); }
            if (textBoxF5.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxF5.Text, out z); }
            val = v + w + x + y + z;
            mediumC4ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(mediumC4AnswerLabel.Text, out answer);
            if (mediumC4AnswerLabel.Text == mediumC4ProgressLabel.Text) { mediumC4ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxB5.Text != "" && textBoxC5.Text != "" && textBoxD5.Text != "" && textBoxE5.Text != "" && textBoxF5.Text != ""))
                { mediumC4ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { mediumC4ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            mediumC5AnswerLabel.Text = Convert.ToString(Globals.MediumList[last].completed[4] + Globals.MediumList[last].completed[9] + Globals.MediumList[last].completed[14] + Globals.MediumList[last].completed[19] + Globals.MediumList[last].completed[24]);
            if (textBoxB6.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxB6.Text, out v); }
            if (textBoxC6.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxC6.Text, out w); }
            if (textBoxD6.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxD6.Text, out x); }
            if (textBoxE6.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxE6.Text, out y); }
            if (textBoxF6.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxF6.Text, out z); }
            val = v + w + x + y + z;
            mediumC5ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(mediumC5AnswerLabel.Text, out answer);
            if (mediumC5AnswerLabel.Text == mediumC5ProgressLabel.Text) { mediumC5ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxB6.Text != "" && textBoxC6.Text != "" && textBoxD6.Text != "" && textBoxE6.Text != "" && textBoxF6.Text != ""))
                { mediumC5ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { mediumC5ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }
        }

        /************************************************************************************
         * Method: fillHardLabels
         * 
         * Summary: Fill in the final answer for each row/column/diagonal, and also in the
         *  progress answer for each of those depnding on what the user has entered for the
         *  hard puzzles.
         ***********************************************************************************/
        private void fillHardLabels(int last)
        {
            //variables to hold the values of each text box
            Int32 t = 0, u = 0, v = 0, w = 0, x = 0, y = 0, z = 0, val = 0, answer = 0;

            //Fill in all of the hard labels
            hardR1AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[0] + Globals.HardList[last].completed[1] + Globals.HardList[last].completed[2] + Globals.HardList[last].completed[3] + Globals.HardList[last].completed[4] + Globals.HardList[last].completed[5] + Globals.HardList[last].completed[6]);
            if (textBoxA1.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxA1.Text, out t); }
            if (textBoxA2.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxA2.Text, out u); }
            if (textBoxA3.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxA3.Text, out v); }
            if (textBoxA4.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxA4.Text, out w); }
            if (textBoxA5.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxA5.Text, out x); }
            if (textBoxA6.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxA6.Text, out y); }
            if (textBoxA7.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxA7.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardR1ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardR1AnswerLabel.Text, out answer);
            //if the answer and progress labels match, set the progress label to green
            if (hardR1AnswerLabel.Text == hardR1ProgressLabel.Text) { hardR1ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxA1.Text != "" && textBoxA2.Text != "" && textBoxA3.Text != "" && textBoxA4.Text != "" && textBoxA5.Text != "" && textBoxA6.Text != "" && textBoxA7.Text != ""))
                { hardR1ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardR1ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            hardR2AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[7] + Globals.HardList[last].completed[8] + Globals.HardList[last].completed[9] + Globals.HardList[last].completed[10] + Globals.HardList[last].completed[11] + Globals.HardList[last].completed[12] + Globals.HardList[last].completed[13]);
            if (textBoxB1.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxB1.Text, out t); }
            if (textBoxB2.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxB2.Text, out u); }
            if (textBoxB3.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxB3.Text, out v); }
            if (textBoxB4.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxB4.Text, out w); }
            if (textBoxB5.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxB5.Text, out x); }
            if (textBoxB6.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxB6.Text, out y); }
            if (textBoxB7.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxB7.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardR2ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardR2AnswerLabel.Text, out answer);
            if (hardR2AnswerLabel.Text == hardR2ProgressLabel.Text) { hardR2ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxB1.Text != "" && textBoxB2.Text != "" && textBoxB3.Text != "" && textBoxB4.Text != "" && textBoxB5.Text != "" && textBoxB6.Text != "" && textBoxB7.Text != ""))
                { hardR2ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardR2ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            hardR3AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[14] + Globals.HardList[last].completed[15] + Globals.HardList[last].completed[16] + Globals.HardList[last].completed[17] + Globals.HardList[last].completed[18] + Globals.HardList[last].completed[19] + Globals.HardList[last].completed[20]);
            if (textBoxC1.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxC1.Text, out t); }
            if (textBoxC2.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxC2.Text, out u); }
            if (textBoxC3.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxC3.Text, out v); }
            if (textBoxC4.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxC4.Text, out w); }
            if (textBoxC5.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxC5.Text, out x); }
            if (textBoxC6.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxC6.Text, out y); }
            if (textBoxC7.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxC7.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardR3ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardR3AnswerLabel.Text, out answer);
            if (hardR3AnswerLabel.Text == hardR3ProgressLabel.Text) { hardR3ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxC1.Text != "" && textBoxC2.Text != "" && textBoxC3.Text != "" && textBoxC4.Text != "" && textBoxC5.Text != "" && textBoxC6.Text != "" && textBoxC7.Text != ""))
                { hardR3ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardR3ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            hardR4AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[21] + Globals.HardList[last].completed[22] + Globals.HardList[last].completed[23] + Globals.HardList[last].completed[24] + Globals.HardList[last].completed[25] + Globals.HardList[last].completed[26] + Globals.HardList[last].completed[27]);
            if (textBoxD1.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxD1.Text, out t); }
            if (textBoxD2.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxD2.Text, out u); }
            if (textBoxD3.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxD3.Text, out v); }
            if (textBoxD4.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxD4.Text, out w); }
            if (textBoxD5.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxD5.Text, out x); }
            if (textBoxD6.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxD6.Text, out y); }
            if (textBoxD7.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxD7.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardR4ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardR4AnswerLabel.Text, out answer);
            if (hardR4AnswerLabel.Text == hardR4ProgressLabel.Text) { hardR4ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxD1.Text != "" && textBoxD2.Text != "" && textBoxD3.Text != "" && textBoxD4.Text != "" && textBoxD5.Text != "" && textBoxD6.Text != "" && textBoxD7.Text != ""))
                { hardR4ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardR4ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            hardR5AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[28] + Globals.HardList[last].completed[29] + Globals.HardList[last].completed[30] + Globals.HardList[last].completed[31] + Globals.HardList[last].completed[32] + Globals.HardList[last].completed[33] + Globals.HardList[last].completed[34]);
            if (textBoxE1.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxE1.Text, out t); }
            if (textBoxE2.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxE2.Text, out u); }
            if (textBoxE3.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxE3.Text, out v); }
            if (textBoxE4.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxE4.Text, out w); }
            if (textBoxE5.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxE5.Text, out x); }
            if (textBoxE6.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxE6.Text, out y); }
            if (textBoxE7.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxE7.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardR5ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardR5AnswerLabel.Text, out answer);
            if (hardR5AnswerLabel.Text == hardR5ProgressLabel.Text) { hardR5ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxE1.Text != "" && textBoxE2.Text != "" && textBoxE3.Text != "" && textBoxE4.Text != "" && textBoxE5.Text != "" && textBoxE6.Text != "" && textBoxE7.Text != ""))
                { hardR5ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardR5ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            hardR6AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[35] + Globals.HardList[last].completed[36] + Globals.HardList[last].completed[37] + Globals.HardList[last].completed[38] + Globals.HardList[last].completed[39] + Globals.HardList[last].completed[40] + Globals.HardList[last].completed[41]);
            if (textBoxF1.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxF1.Text, out t); }
            if (textBoxF2.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxF2.Text, out u); }
            if (textBoxF3.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxF3.Text, out v); }
            if (textBoxF4.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxF4.Text, out w); }
            if (textBoxF5.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxF5.Text, out x); }
            if (textBoxF6.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxF6.Text, out y); }
            if (textBoxF7.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxF7.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardR6ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardR6AnswerLabel.Text, out answer);
            if (hardR6AnswerLabel.Text == hardR6ProgressLabel.Text) { hardR6ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxF1.Text != "" && textBoxF2.Text != "" && textBoxF3.Text != "" && textBoxF4.Text != "" && textBoxF5.Text != "" && textBoxF6.Text != "" && textBoxF7.Text != ""))
                { hardR6ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardR6ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            hardR7AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[42] + Globals.HardList[last].completed[43] + Globals.HardList[last].completed[44] + Globals.HardList[last].completed[45] + Globals.HardList[last].completed[46] + Globals.HardList[last].completed[47] + Globals.HardList[last].completed[48]);
            if (textBoxG1.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxG1.Text, out t); }
            if (textBoxG2.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxG2.Text, out u); }
            if (textBoxG3.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxG3.Text, out v); }
            if (textBoxG4.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxG4.Text, out w); }
            if (textBoxG5.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxG5.Text, out x); }
            if (textBoxG6.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxG6.Text, out y); }
            if (textBoxG7.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxG7.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardR7ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardR7AnswerLabel.Text, out answer);
            if (hardR7AnswerLabel.Text == hardR7ProgressLabel.Text) { hardR7ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxG1.Text != "" && textBoxG2.Text != "" && textBoxG3.Text != "" && textBoxG4.Text != "" && textBoxG5.Text != "" && textBoxG6.Text != "" && textBoxG7.Text != ""))
                { hardR7ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardR7ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            hardD1AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[0] + Globals.HardList[last].completed[8] + Globals.HardList[last].completed[16] + Globals.HardList[last].completed[24] + Globals.HardList[last].completed[32] + Globals.HardList[last].completed[40] + Globals.HardList[last].completed[48]);
            if (textBoxA1.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxA1.Text, out t); }
            if (textBoxB2.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxB2.Text, out u); }
            if (textBoxC3.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxC3.Text, out v); }
            if (textBoxD4.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxD4.Text, out w); }
            if (textBoxE5.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxE5.Text, out x); }
            if (textBoxF6.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxF6.Text, out y); }
            if (textBoxG7.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxG7.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardD1ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardD1AnswerLabel.Text, out answer);
            if (hardD1AnswerLabel.Text == hardD1ProgressLabel.Text) { hardD1ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxA1.Text != "" && textBoxB2.Text != "" && textBoxC3.Text != "" && textBoxD4.Text != "" && textBoxE5.Text != "" && textBoxF6.Text != "" && textBoxG7.Text != ""))
                { hardD1ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardD1ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            hardD2AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[6] + Globals.HardList[last].completed[12] + Globals.HardList[last].completed[18] + Globals.HardList[last].completed[24] + Globals.HardList[last].completed[30] + Globals.HardList[last].completed[36] + Globals.HardList[last].completed[42]);
            if (textBoxA7.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxA7.Text, out t); }
            if (textBoxB6.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxB6.Text, out u); }
            if (textBoxC5.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxC5.Text, out v); }
            if (textBoxD4.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxD4.Text, out w); }
            if (textBoxE3.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxE3.Text, out x); }
            if (textBoxF2.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxF2.Text, out y); }
            if (textBoxG1.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxG1.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardD2ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardD2AnswerLabel.Text, out answer);
            if (hardD2AnswerLabel.Text == hardD2ProgressLabel.Text) { hardD2ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxA7.Text != "" && textBoxB6.Text != "" && textBoxC5.Text != "" && textBoxD4.Text != "" && textBoxE3.Text != "" && textBoxF2.Text != "" && textBoxG1.Text != ""))
                { hardD2ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardD2ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            hardC1AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[0] + Globals.HardList[last].completed[7] + Globals.HardList[last].completed[14] + Globals.HardList[last].completed[21] + Globals.HardList[last].completed[28] + Globals.HardList[last].completed[35] + Globals.HardList[last].completed[42]);
            if (textBoxA1.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxA1.Text, out t); }
            if (textBoxB1.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxB1.Text, out u); }
            if (textBoxC1.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxC1.Text, out v); }
            if (textBoxD1.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxD1.Text, out w); }
            if (textBoxE1.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxE1.Text, out x); }
            if (textBoxF1.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxF1.Text, out y); }
            if (textBoxG1.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxG1.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardC1ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardC1AnswerLabel.Text, out answer);
            if (hardC1AnswerLabel.Text == hardC1ProgressLabel.Text) { hardC1ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxA1.Text != "" && textBoxB1.Text != "" && textBoxC1.Text != "" && textBoxD1.Text != "" && textBoxE1.Text != "" && textBoxF1.Text != "" && textBoxG1.Text != ""))
                { hardC1ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardC1ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            hardC2AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[1] + Globals.HardList[last].completed[8] + Globals.HardList[last].completed[15] + Globals.HardList[last].completed[22] + Globals.HardList[last].completed[29] + Globals.HardList[last].completed[36] + Globals.HardList[last].completed[43]);
            if (textBoxA2.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxA2.Text, out t); }
            if (textBoxB2.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxB2.Text, out u); }
            if (textBoxC2.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxC2.Text, out v); }
            if (textBoxD2.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxD2.Text, out w); }
            if (textBoxE2.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxE2.Text, out x); }
            if (textBoxF2.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxF2.Text, out y); }
            if (textBoxG2.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxG2.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardC2ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardC2AnswerLabel.Text, out answer);
            if (hardC2AnswerLabel.Text == hardC2ProgressLabel.Text) { hardC2ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxA2.Text != "" && textBoxB2.Text != "" && textBoxC2.Text != "" && textBoxD2.Text != "" && textBoxE2.Text != "" && textBoxF2.Text != "" && textBoxG2.Text != ""))
                { hardC2ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardC2ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            hardC3AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[2] + Globals.HardList[last].completed[9] + Globals.HardList[last].completed[16] + Globals.HardList[last].completed[23] + Globals.HardList[last].completed[30] + Globals.HardList[last].completed[37] + Globals.HardList[last].completed[44]);
            if (textBoxA3.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxA3.Text, out t); }
            if (textBoxB3.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxB3.Text, out u); }
            if (textBoxC3.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxC3.Text, out v); }
            if (textBoxD3.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxD3.Text, out w); }
            if (textBoxE3.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxE3.Text, out x); }
            if (textBoxF3.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxF3.Text, out y); }
            if (textBoxG3.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxG3.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardC3ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardC3AnswerLabel.Text, out answer);
            if (hardC3AnswerLabel.Text == hardC3ProgressLabel.Text) { hardC3ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxA3.Text != "" && textBoxB3.Text != "" && textBoxC3.Text != "" && textBoxD3.Text != "" && textBoxE3.Text != "" && textBoxF3.Text != "" && textBoxG3.Text != ""))
                { hardC3ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardC3ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            hardC4AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[3] + Globals.HardList[last].completed[10] + Globals.HardList[last].completed[17] + Globals.HardList[last].completed[24] + Globals.HardList[last].completed[31] + Globals.HardList[last].completed[38] + Globals.HardList[last].completed[45]);
            if (textBoxA4.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxA4.Text, out t); }
            if (textBoxB4.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxB4.Text, out u); }
            if (textBoxC4.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxC4.Text, out v); }
            if (textBoxD4.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxD4.Text, out w); }
            if (textBoxE4.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxE4.Text, out x); }
            if (textBoxF4.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxF4.Text, out y); }
            if (textBoxG4.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxG4.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardC4ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardC4AnswerLabel.Text, out answer);
            if (hardC4AnswerLabel.Text == hardC4ProgressLabel.Text) { hardC4ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxA4.Text != "" && textBoxB4.Text != "" && textBoxC4.Text != "" && textBoxD4.Text != "" && textBoxE4.Text != "" && textBoxF4.Text != "" && textBoxG4.Text != ""))
                { hardC4ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardC4ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            hardC5AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[4] + Globals.HardList[last].completed[11] + Globals.HardList[last].completed[18] + Globals.HardList[last].completed[25] + Globals.HardList[last].completed[32] + Globals.HardList[last].completed[39] + Globals.HardList[last].completed[46]);
            if (textBoxA5.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxA5.Text, out t); }
            if (textBoxB5.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxB5.Text, out u); }
            if (textBoxC5.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxC5.Text, out v); }
            if (textBoxD5.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxD5.Text, out w); }
            if (textBoxE5.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxE5.Text, out x); }
            if (textBoxF5.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxF5.Text, out y); }
            if (textBoxG5.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxG5.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardC5ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardC5AnswerLabel.Text, out answer);
            if (hardC5AnswerLabel.Text == hardC5ProgressLabel.Text) { hardC5ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxA5.Text != "" && textBoxB5.Text != "" && textBoxC5.Text != "" && textBoxD5.Text != "" && textBoxE5.Text != "" && textBoxF5.Text != "" && textBoxG5.Text != ""))
                { hardC5ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardC5ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            hardC6AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[5] + Globals.HardList[last].completed[12] + Globals.HardList[last].completed[19] + Globals.HardList[last].completed[26] + Globals.HardList[last].completed[33] + Globals.HardList[last].completed[40] + Globals.HardList[last].completed[47]);
            if (textBoxA6.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxA6.Text, out t); }
            if (textBoxB6.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxB6.Text, out u); }
            if (textBoxC6.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxC6.Text, out v); }
            if (textBoxD6.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxD6.Text, out w); }
            if (textBoxE6.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxE6.Text, out x); }
            if (textBoxF6.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxF6.Text, out y); }
            if (textBoxG6.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxG6.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardC6ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardC6AnswerLabel.Text, out answer);
            if (hardC6AnswerLabel.Text == hardC6ProgressLabel.Text) { hardC6ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxA1.Text != "" && textBoxB6.Text != "" && textBoxC6.Text != "" && textBoxD6.Text != "" && textBoxE6.Text != "" && textBoxF6.Text != "" && textBoxG6.Text != ""))
                { hardC6ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardC6ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }

            hardC7AnswerLabel.Text = Convert.ToString(Globals.HardList[last].completed[6] + Globals.HardList[last].completed[13] + Globals.HardList[last].completed[20] + Globals.HardList[last].completed[27] + Globals.HardList[last].completed[34] + Globals.HardList[last].completed[41] + Globals.HardList[last].completed[48]);
            if (textBoxA7.Text == "") { t = 0; }
            else { Int32.TryParse(textBoxA7.Text, out t); }
            if (textBoxB7.Text == "") { u = 0; }
            else { Int32.TryParse(textBoxB7.Text, out u); }
            if (textBoxC7.Text == "") { v = 0; }
            else { Int32.TryParse(textBoxC7.Text, out v); }
            if (textBoxD7.Text == "") { w = 0; }
            else { Int32.TryParse(textBoxD7.Text, out w); }
            if (textBoxE7.Text == "") { x = 0; }
            else { Int32.TryParse(textBoxE7.Text, out x); }
            if (textBoxF7.Text == "") { y = 0; }
            else { Int32.TryParse(textBoxF7.Text, out y); }
            if (textBoxG7.Text == "") { z = 0; }
            else { Int32.TryParse(textBoxG7.Text, out z); }
            val = t + u + v + w + x + y + z;
            hardC7ProgressLabel.Text = Convert.ToString(val);

            Int32.TryParse(hardC7AnswerLabel.Text, out answer);
            if (hardC7AnswerLabel.Text == hardC7ProgressLabel.Text) { hardC7ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen; }
            else if ((answer < val) || (textBoxA7.Text != "" && textBoxB7.Text != "" && textBoxC7.Text != "" && textBoxD7.Text != "" && textBoxE7.Text != "" && textBoxF7.Text != "" && textBoxG7.Text != ""))
                { hardC7ProgressLabel.ForeColor = System.Drawing.Color.Red; }
            else { hardC7ProgressLabel.ForeColor = System.Drawing.Color.DarkGray; }
        }

        /************************************************************************************
         * Method: addToGlobals
         * 
         * Summary: adds various items to its respective global list
         ***********************************************************************************/
        private void addToGlobals()
        {
            //Add all Easy Labels to the Easy global list
            Globals.easyLabelList.Add(easyR1AnswerLabel);
            Globals.easyLabelList.Add(easyR2AnswerLabel);
            Globals.easyLabelList.Add(easyR3AnswerLabel);
            Globals.easyLabelList.Add(easyR1ProgressLabel);
            Globals.easyLabelList.Add(easyR2ProgressLabel);
            Globals.easyLabelList.Add(easyR3ProgressLabel);
            Globals.easyLabelList.Add(easyC1AnswerLabel);
            Globals.easyLabelList.Add(easyC2AnswerLabel);
            Globals.easyLabelList.Add(easyC3AnswerLabel);
            Globals.easyLabelList.Add(easyC1ProgressLabel);
            Globals.easyLabelList.Add(easyC2ProgressLabel);
            Globals.easyLabelList.Add(easyC3ProgressLabel);
            Globals.easyLabelList.Add(easyD1AnswerLabel);
            Globals.easyLabelList.Add(easyD2AnswerLabel);
            Globals.easyLabelList.Add(easyD1ProgressLabel);
            Globals.easyLabelList.Add(easyD2ProgressLabel);

            //Add all Medium Labels to the Medium global list
            Globals.mediumLabelList.Add(mediumR1AnswerLabel);
            Globals.mediumLabelList.Add(mediumR2AnswerLabel);
            Globals.mediumLabelList.Add(mediumR3AnswerLabel);
            Globals.mediumLabelList.Add(mediumR4AnswerLabel);
            Globals.mediumLabelList.Add(mediumR5AnswerLabel);
            Globals.mediumLabelList.Add(mediumR1ProgressLabel);
            Globals.mediumLabelList.Add(mediumR2ProgressLabel);
            Globals.mediumLabelList.Add(mediumR3ProgressLabel);
            Globals.mediumLabelList.Add(mediumR4ProgressLabel);
            Globals.mediumLabelList.Add(mediumR5ProgressLabel);
            Globals.mediumLabelList.Add(mediumD1AnswerLabel);
            Globals.mediumLabelList.Add(mediumD1ProgressLabel);
            Globals.mediumLabelList.Add(mediumD2AnswerLabel);
            Globals.mediumLabelList.Add(mediumD2ProgressLabel);
            Globals.mediumLabelList.Add(mediumC1AnswerLabel);
            Globals.mediumLabelList.Add(mediumC2AnswerLabel);
            Globals.mediumLabelList.Add(mediumC3AnswerLabel);
            Globals.mediumLabelList.Add(mediumC4AnswerLabel);
            Globals.mediumLabelList.Add(mediumC5AnswerLabel);
            Globals.mediumLabelList.Add(mediumC1ProgressLabel);
            Globals.mediumLabelList.Add(mediumC2ProgressLabel);
            Globals.mediumLabelList.Add(mediumC3ProgressLabel);
            Globals.mediumLabelList.Add(mediumC4ProgressLabel);
            Globals.mediumLabelList.Add(mediumC5ProgressLabel);

            //Add all Hard Labels to the Medium global list
            Globals.hardLabelList.Add(hardR1AnswerLabel);
            Globals.hardLabelList.Add(hardR2AnswerLabel);
            Globals.hardLabelList.Add(hardR3AnswerLabel);
            Globals.hardLabelList.Add(hardR4AnswerLabel);
            Globals.hardLabelList.Add(hardR5AnswerLabel);
            Globals.hardLabelList.Add(hardR6AnswerLabel);
            Globals.hardLabelList.Add(hardR7AnswerLabel);
            Globals.hardLabelList.Add(hardR1ProgressLabel);
            Globals.hardLabelList.Add(hardR2ProgressLabel);
            Globals.hardLabelList.Add(hardR3ProgressLabel);
            Globals.hardLabelList.Add(hardR4ProgressLabel);
            Globals.hardLabelList.Add(hardR5ProgressLabel);
            Globals.hardLabelList.Add(hardR6ProgressLabel);
            Globals.hardLabelList.Add(hardR7ProgressLabel);
            Globals.hardLabelList.Add(hardD1AnswerLabel);
            Globals.hardLabelList.Add(hardD2AnswerLabel);
            Globals.hardLabelList.Add(hardD1ProgressLabel);
            Globals.hardLabelList.Add(hardD2ProgressLabel);
            Globals.hardLabelList.Add(hardC1AnswerLabel);
            Globals.hardLabelList.Add(hardC2AnswerLabel);
            Globals.hardLabelList.Add(hardC3AnswerLabel);
            Globals.hardLabelList.Add(hardC4AnswerLabel);
            Globals.hardLabelList.Add(hardC5AnswerLabel);
            Globals.hardLabelList.Add(hardC6AnswerLabel);
            Globals.hardLabelList.Add(hardC7AnswerLabel);
            Globals.hardLabelList.Add(hardC1ProgressLabel);
            Globals.hardLabelList.Add(hardC2ProgressLabel);
            Globals.hardLabelList.Add(hardC3ProgressLabel);
            Globals.hardLabelList.Add(hardC4ProgressLabel);
            Globals.hardLabelList.Add(hardC5ProgressLabel);
            Globals.hardLabelList.Add(hardC6ProgressLabel);
            Globals.hardLabelList.Add(hardC7ProgressLabel);

            //Add all textBoxes to the global List
            Globals.textBoxesList.Add(textBoxA1);
            Globals.textBoxesList.Add(textBoxA2);
            Globals.textBoxesList.Add(textBoxA3);
            Globals.textBoxesList.Add(textBoxA4);
            Globals.textBoxesList.Add(textBoxA5);
            Globals.textBoxesList.Add(textBoxA6);
            Globals.textBoxesList.Add(textBoxA7);

            Globals.textBoxesList.Add(textBoxB1);
            Globals.textBoxesList.Add(textBoxB2);
            Globals.textBoxesList.Add(textBoxB3);
            Globals.textBoxesList.Add(textBoxB4);
            Globals.textBoxesList.Add(textBoxB5);
            Globals.textBoxesList.Add(textBoxB6);
            Globals.textBoxesList.Add(textBoxB7);

            Globals.textBoxesList.Add(textBoxC1);
            Globals.textBoxesList.Add(textBoxC2);
            Globals.textBoxesList.Add(textBoxC3);
            Globals.textBoxesList.Add(textBoxC4);
            Globals.textBoxesList.Add(textBoxC5);
            Globals.textBoxesList.Add(textBoxC6);
            Globals.textBoxesList.Add(textBoxC7);

            Globals.textBoxesList.Add(textBoxD1);
            Globals.textBoxesList.Add(textBoxD2);
            Globals.textBoxesList.Add(textBoxD3);
            Globals.textBoxesList.Add(textBoxD4);
            Globals.textBoxesList.Add(textBoxD5);
            Globals.textBoxesList.Add(textBoxD6);
            Globals.textBoxesList.Add(textBoxD7);

            Globals.textBoxesList.Add(textBoxE1);
            Globals.textBoxesList.Add(textBoxE2);
            Globals.textBoxesList.Add(textBoxE3);
            Globals.textBoxesList.Add(textBoxE4);
            Globals.textBoxesList.Add(textBoxE5);
            Globals.textBoxesList.Add(textBoxE6);
            Globals.textBoxesList.Add(textBoxE7);

            Globals.textBoxesList.Add(textBoxF1);
            Globals.textBoxesList.Add(textBoxF2);
            Globals.textBoxesList.Add(textBoxF3);
            Globals.textBoxesList.Add(textBoxF4);
            Globals.textBoxesList.Add(textBoxF5);
            Globals.textBoxesList.Add(textBoxF6);
            Globals.textBoxesList.Add(textBoxF7);

            Globals.textBoxesList.Add(textBoxG1);
            Globals.textBoxesList.Add(textBoxG2);
            Globals.textBoxesList.Add(textBoxG3);
            Globals.textBoxesList.Add(textBoxG4);
            Globals.textBoxesList.Add(textBoxG5);
            Globals.textBoxesList.Add(textBoxG6);
            Globals.textBoxesList.Add(textBoxG7);
        }

        /************************************************************************************
         * Method: check_Completion
         * 
         * Summary:
         *  1. Pauses the timer for recording
         *  2. Checks the puzzle difficulty (isEasy, isMedium, isHard), also marks puzzle as completed on this step
         *  3. Checks if the hint button has been used (cheatFlag). If not, save time to corresponding file
         *  4. displays the fastest and average times to solve a puzzle on that difficulty.
         *  5. Sets all textboxes to readonly so the player cannot make changes
         *  
         ***********************************************************************************/
        private void puzzle_Completion()
        {
            int averageTime = 0;
            string fileName;
            string fileLine;
            string outputMessage;

            //Stop the timer
            countTime = false;

            //decide file to use
            if (isEasy)
            {
                fileName = "easyTime.txt";
                outputMessage = "Congrats on solving an Easy Puzzle!";
                Globals.EasyList[Globals.EasyList.Count - 1].CompleteFlag = 0;//set puzzle's flag to be completed
            }
            else if (isMedium)
            {
                fileName = "mediumTime.txt";
                outputMessage = "Congrats on solving a Medium Puzzle";
                Globals.MediumList[Globals.MediumList.Count - 1].CompleteFlag = 0;//set puzzle's flag to be completed
            }
            else//isHard
            {
                fileName = "hardTime.txt";
                outputMessage = "Congrats on solving a Hard Puzzle";
                Globals.HardList[Globals.HardList.Count - 1].CompleteFlag = 0;//set puzzle's flag to be completed
            }

            //if no cheat button, save time
            if (!cheatFlag)
            {
                using (StreamWriter inFile = new StreamWriter("../../" + fileName, true))
                {
                    inFile.WriteLine(seconds.ToString());
                }
            }

            List<int> times = new List<int>();

            //read times in file to array
            using (StreamReader inFile = new StreamReader("../../"+fileName))
            {
                while((fileLine = inFile.ReadLine()) != null)
                {
                    times.Add(Int32.Parse(fileLine));
                    averageTime += times[times.Count - 1];
                }
            }

            averageTime = averageTime / times.Count;
            times.Sort();

            //display congrats and fastest time / average time
            outputMessage += "\nFastest Recorded Time: " + times[0].ToString() + "Seconds";
            outputMessage += "\nAverage Completion Time: " + averageTime.ToString() + " Seconds";

            MessageBox.Show(outputMessage, "You Solved It!", MessageBoxButtons.OK);

            foreach(var textbox in Globals.textBoxesList)
            {
                textbox.ReadOnly = true;
            }
        }

        /************************************************************************************
         * Method: textBoxA1_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxA1_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxA1.Handle);
            textBoxA1.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxA1_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxA1_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxA2_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxA2_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxA2.Handle);
            textBoxA2.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxA2_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxA2_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxA3_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxA3_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxA3.Handle);
            textBoxA3.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxA3_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxA3_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxA4_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxA4_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxA4.Handle);
            textBoxA4.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxA4_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxA4_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxA5_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxA5_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxA5.Handle);
            textBoxA5.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxA5_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxA5_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxA6_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxA6_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxA6.Handle);
            textBoxA6.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxA6_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxA6_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxA7_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxA7_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxA7.Handle);
            textBoxA7.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxA7_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxA7_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxB1_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxB1_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxB1.Handle);
            textBoxB1.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxB1_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxB1_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxB2_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxB2_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxB2.Handle);
            textBoxB2.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxB2_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxB2_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxB3_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxB3_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxB3.Handle);
            textBoxB3.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxB3_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxB3_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxB4_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxB4_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxB4.Handle);
            textBoxB4.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxB4_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxB4_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxB5_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxB5_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxB5.Handle);
            textBoxB5.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxB5_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxB5_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxB6_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxB6_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxB6.Handle);
            textBoxB6.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxB6_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxB6_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxB7_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxB7_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxB7.Handle);
            textBoxB7.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxB7_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxB7_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxC1_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxC1_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxC1.Handle);
            textBoxC1.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxC1_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxC1_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxC2_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxC2_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxC2.Handle);
            textBoxC2.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxC2_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxC2_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxC3_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxC3_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxC3.Handle);
            textBoxC3.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxC3_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxC3_TextChanged(object sender, EventArgs e)
        {
            if (isEasy)
            {
                int last = Globals.EasyList.Count - 1; //get the last item in the list which should always be non complete
                fillEasyLabels(last);
            }
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxC4_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxC4_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxC4.Handle);
            textBoxC4.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxC4_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxC4_TextChanged(object sender, EventArgs e)
        {
            if (isEasy)
            {
                int last = Globals.EasyList.Count - 1; //get the last item in the list which should always be non complete
                fillEasyLabels(last);
            }
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxC5_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxC5_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxC5.Handle);
            textBoxC5.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxC5_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxC5_TextChanged(object sender, EventArgs e)
        {
            if (isEasy)
            {
                int last = Globals.EasyList.Count - 1; //get the last item in the list which should always be non complete
                fillEasyLabels(last);
            }
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxC6_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxC6_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxC6.Handle);
            textBoxC6.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxC6_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxC6_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxC7_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxC7_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxC7.Handle);
            textBoxC7.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxC7_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxC7_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxD1_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxD1_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxD1.Handle);
            textBoxD1.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxD1_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxD1_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxD2_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxD2_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxD2.Handle);
            textBoxD2.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxD2_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxD2_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxD3_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxD3_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxD3.Handle);
            textBoxD3.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxD3_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxD3_TextChanged(object sender, EventArgs e)
        {
            if (isEasy)
            {
                int last = Globals.EasyList.Count - 1; //get the last item in the list which should always be non complete
                fillEasyLabels(last);
            }
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxD4_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxD4_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxD4.Handle);
            textBoxD4.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxD4_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxD4_TextChanged(object sender, EventArgs e)
        {
            if (isEasy)
            {
                int last = Globals.EasyList.Count - 1; //get the last item in the list which should always be non complete
                fillEasyLabels(last);
            }
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxD5_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxD5_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxD5.Handle);
            textBoxD5.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxD5_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxD5_TextChanged(object sender, EventArgs e)
        {
            if (isEasy)
            {
                int last = Globals.EasyList.Count - 1; //get the last item in the list which should always be non complete
                fillEasyLabels(last);
            }
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxD6_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxD6_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxD6.Handle);
            textBoxD6.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxD6_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxD6_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxD7_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxD7_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxD7.Handle);
            textBoxD7.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxD7_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxD7_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxE1_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxE1_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxE1.Handle);
            textBoxE1.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxE1_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxE1_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxE2_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxE2_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxE2.Handle);
            textBoxE2.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxE2_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxE2_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxE3_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxE3_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxE3.Handle);
            textBoxE3.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxE3_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxE3_TextChanged(object sender, EventArgs e)
        {
            if (isEasy)
            {
                int last = Globals.EasyList.Count - 1; //get the last item in the list which should always be non complete
                fillEasyLabels(last);
            }
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxE4_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxE4_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxE4.Handle);
            textBoxE4.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxE4_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxE4_TextChanged(object sender, EventArgs e)
        {
            if (isEasy)
            {
                int last = Globals.EasyList.Count - 1; //get the last item in the list which should always be non complete
                fillEasyLabels(last);
            }
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxE5_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxE5_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxE5.Handle);
            textBoxE5.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxE5_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxE5_TextChanged(object sender, EventArgs e)
        {
            if (isEasy)
            {
                int last = Globals.EasyList.Count - 1; //get the last item in the list which should always be non complete
                fillEasyLabels(last);
            }
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxE6_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxE6_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxE6.Handle);
            textBoxE6.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxE6_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxE6_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxE7_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxE7_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxE7.Handle);
            textBoxE7.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxE7_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxE7_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxF1_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxF1_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxF1.Handle);
            textBoxF1.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxF1_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxF1_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxF2_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxF2_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxF2.Handle);
            textBoxF2.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxF2_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxF2_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxF3_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxF3_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxF3.Handle);
            textBoxF3.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxF3_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxF3_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxF4_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxF4_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxF4.Handle);
            textBoxF4.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxF4_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxF4_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxF5_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxF5_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxF5.Handle);
            textBoxF5.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxF5_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxF5_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxF6_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxF6_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxF6.Handle);
            textBoxF6.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxF6_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxF6_TextChanged(object sender, EventArgs e)
        {
            if (isMedium)
            {
                int last = Globals.MediumList.Count - 1; //get the last item in the list which should always be non complete
                fillMediumLabels(last);
            }
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxF7_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxF7_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxF7.Handle);
            textBoxF7.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxF7_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxF7_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxG1_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxG1_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxG1.Handle);
            textBoxG1.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxG1_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxG1_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxG2_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxG2_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxG2.Handle);
            textBoxG2.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxG2_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxG2_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxG3_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxG3_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxG3.Handle);
            textBoxG3.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxG3_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxG3_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxG4_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxG4_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxG4.Handle);
            textBoxG4.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxG4_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxG4_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxG5_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxG5_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxG5.Handle);
            textBoxG5.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxG5_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxG5_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxG6_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxG6_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxG6.Handle);
            textBoxG6.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxG6_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxG6_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }

        /************************************************************************************
         * Method: textBoxG7_Click
         * 
         * Summary: Sets up the focus of the selected text box by highlighting it and
         *  removing the caret.
         ***********************************************************************************/
        private void textBoxG7_Click(object sender, EventArgs e)
        {
            //Change all of the textbox colors to white
            foreach (var textbox in Globals.textBoxesList)
            {
                textbox.BackColor = Color.White;
            }

            //Remove the caret of the selected box and highlight it
            HideCaret(textBoxG7.Handle);
            textBoxG7.BackColor = Color.LightBlue;
        }

        /************************************************************************************
         * Method: textBoxG7_TextChanged
         * 
         * Summary: Depending on the difficulty of the puzzle, fill in the labels
         ***********************************************************************************/
        private void textBoxG7_TextChanged(object sender, EventArgs e)
        {
            if (isHard)
            {
                int last = Globals.HardList.Count - 1; //get the last item in the list which should always be non complete
                fillHardLabels(last);
            }
        }
    }
}

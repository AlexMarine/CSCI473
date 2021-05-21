/************************************************************************************
 * Authors: Alex Marine (z1863905) and Tristan Tovar (z1832119)
 * Program: Assignment 6
 * Course: CSCI 473
 * Date: April 15, 2021
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MarineTovar_Assign6
{
    public partial class BarChart : Form
    {
        //variable declaration for Portal form
        Form portal = new Portal();

        public Series numMeaning = new Series();

        /************************************************************************************
         * Method: BarChart
         * 
         * Summary: Set up all of the components for the Bar Chart so that it can display
         *  the data on the chart.
         ***********************************************************************************/
        public BarChart()
        {
            InitializeComponent();

            readData();

            numMeaning.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            //Set the names of the series and make the lines thicker
            numMeaning.Name = "Numbers";

            //add the series data to the chart
            Bar1.Series.Add(numMeaning);
        }

        /************************************************************************************
         * Method: readData
         * 
         * Summary: Split the data in the text file and store each section into a
         *  corresponding string array that we will make data points out of.
         ***********************************************************************************/
        public void readData()
        {
            string line;
            using (StreamReader inFile = new StreamReader("../../barGraphData.txt"))
            {
                while((line = inFile.ReadLine())!=null)
                {
                    string[] tokens = line.Split(',');
                    numMeaning.Points.AddXY(tokens[0], int.Parse(tokens[1]));
                }
            }
        }

        /************************************************************************************
         * Method: barChartPortalButton_Click
         * 
         * Summary: When the user clicks the portal button, show the portal form and close
         *  the PieChart form.
         ***********************************************************************************/
        private void barChartPortalButton_Click(object sender, EventArgs e)
        {
            //Close the BarChart form and show the Portal form
            portal.Show();
            Close();
        }

        /************************************************************************************
         * Method: BarChart_FormClosing
         * 
         * Summary: When the user closes the PieChart form, show the poral form.
         ***********************************************************************************/
        private void BarChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Show the Portal form
            portal.Show();
        }
    }
}

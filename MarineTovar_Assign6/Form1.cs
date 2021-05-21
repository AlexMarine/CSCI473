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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MarineTovar_Assign6
{
    public partial class Portal : Form
    {
        public Portal()
        {
            InitializeComponent();
        }

        /************************************************************************************
         * Method: linegraphButton_Click
         * 
         * Summary: When the user clicks to open the line graph, hide the portal form and
         *  display the line graph form
         ***********************************************************************************/
        private void lineGraphButton_Click(object sender, EventArgs e)
        {
            //variable declaration for LineGraph form
            var lineGraph = new LineGraph();

            //Hide the portal form and show the LineGraph form
            Hide();
            lineGraph.Show();
        }

        /************************************************************************************
         * Method: barChartButton_Click
         * 
         * Summary: When the user clicks to open the bar chart, hide the portal form and
         *  display the bar chart form
         ***********************************************************************************/
        private void barChartButton_Click(object sender, EventArgs e)
        {
            //variable declaration for BarChart form
            var barChart = new BarChart();

            //Hide the portal form and show the BarChart form
            Hide();
            barChart.Show();
        }

        /************************************************************************************
         * Method: pieChartButton_Click
         * 
         * Summary: When the user clicks to open the pie chart, hide the portal form and
         *  display the pie chart form
         ***********************************************************************************/
        private void pieChartButton_Click(object sender, EventArgs e)
        {
            //variable declaration for PieChart form
            var pieChart = new PieChart();

            //Hide the portal form and show the PieChart form
            Hide();
            pieChart.Show();
        }

        /************************************************************************************
         * Method: radarButton_Click
         * 
         * Summary: When the user clicks to open the radar chart, hide the portal form and
         *  display the radar chart form
         ***********************************************************************************/
        private void radarButton_Click(object sender, EventArgs e)
        {
            //variable declaration for radar chart form
            var radar = new radarChart();

            //Hide the portal form and show the radar chart form
            Hide();
            radar.Show();
        }

        /************************************************************************************
         * Method: exitButton_Click
         * 
         * Summary: When the user clicks the exit button, close all of the forms
         ***********************************************************************************/
        private void exitButton_Click(object sender, EventArgs e)
        {
            //Close the application to avoid errors
            System.Windows.Forms.Application.Exit();
        }

        /************************************************************************************
         * Method: pieChartButton_Click
         * 
         * Summary: When the user clicks to close the portal form, exit out of everything
         *  just in case.
         ***********************************************************************************/
        private void Portal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Close the application to avoid errors
            System.Windows.Forms.Application.Exit();
        }
    }
}

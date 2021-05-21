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
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace MarineTovar_Assign6
{
    public partial class LineGraph : Form
    {
        //variable declaration for Portal form
        Form portal = new Portal();
        
        //variable declaration for Series in line graph
        public static Series HotDogPoints = new Series();
        public static Series HamburgerPoints = new Series();
        public static Series PizzaPoints = new Series();

        /************************************************************************************
         * Method: LineGraph
         * 
         * Summary: Set up all of the components for the Line Graph so that it can display
         *  the data on the chart.
         ***********************************************************************************/
        public LineGraph()
        {
            //Initialize all of the components for the form
            InitializeComponent();

            //call method to read data in from file
            readData();

            //Set the chart types of the series to Line
            HotDogPoints.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            HamburgerPoints.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            PizzaPoints.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            //Set the names of the series and make the lines thicker
            HotDogPoints.Name = "Hot Dogs";
            HotDogPoints.BorderWidth = 2;
            HamburgerPoints.Name = "Hamburgers";
            HamburgerPoints.BorderWidth = 2;
            PizzaPoints.Name = "Pizzas";
            PizzaPoints.BorderWidth = 2;

            //add the series data to the chart
            line.Series.Add(HotDogPoints);
            line.Series.Add(HamburgerPoints);
            line.Series.Add(PizzaPoints);
        }

        /************************************************************************************
         * Method: readData
         * 
         * Summary: Split the data in the text file and store each section into a
         *  corresponding string array that we will make data points out of.
         ***********************************************************************************/
        public void readData()
        {
            //Read in the data from the text file
            string line;
            using (StreamReader inFile = new StreamReader("../../lineGraphData.txt"))
            {
                //While there is still data in the text file
                while ((line = inFile.ReadLine()) != null)
                {
                    //Split the line at a tab
                    string[] food = line.Split('\t');

                    //Add each segment of data to a string
                    string hotDog = food[0];
                    string hamburger = food[1];
                    string pizza = food[2];

                    //Split each data point at a colon
                    string[] hotDogSales = hotDog.Split(' ');
                    string[] hamburgerSales = hamburger.Split(' ');
                    string[] pizzaSales = pizza.Split(' ');

                    //Make data points out of the data from the text file
                    HotDogPoints = makePoints(hotDogSales);
                    HamburgerPoints = makePoints(hamburgerSales);
                    PizzaPoints = makePoints(pizzaSales);
                }
            }
        }

        /************************************************************************************
         * Method: makePoints
         * 
         * Summary: Take each set of data and splits them into x and y values that will be
         *  returned to the series so that they can be plotted as data points.
         ***********************************************************************************/
        public Series makePoints(string[] data)
        {
            //Initialize series where we will add the data points to
            Series series = new Series();

            //For each piece of data in the array
            for (int i = 0; i < data.Length; i++)
            {
                //Split each data point at the comma
                string[] sales = data[i].Split(',');

                //Store the x and y values in variables
                int x = int.Parse(sales[0]);
                int y = int.Parse(sales[1]);

                //Add the x and y values to the series
                series.Points.AddXY(x, y);
            }

            //return the series so we can graph the points
            return series;
        }

        /************************************************************************************
         * Method: lineGraphPortalButton_Click
         * 
         * Summary: When the user clicks the portal button, show the portal form and close
         *  the LineGraph form.
         ***********************************************************************************/
        private void lineGraphPortalButton_Click(object sender, EventArgs e)
        {
            //Close the LineGrah form and show the Portal form
            portal.Show();
            Close();
        }

        /************************************************************************************
         * Method: LineGraph_FormClosing
         * 
         * Summary: When the user closes the LineGraph form, show the poral form.
         ***********************************************************************************/
        private void LineGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Show the Portal form
            portal.Show();
        }
    }
}

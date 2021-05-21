/************************************************************************************
 * Authors: Alex Marine (z1863905) and Tristan Tovar (z1832119)
 * Program: Assignment 4
 * Course: CSCI 473
 * Date: March 18, 2021
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarineTovar_Assign4
{
    public static class GraphicsExtensions
    {
        /************************************************************************************
         * Method: DrawCircle
         * 
         * Summary: Method to draw the circle on the graph
         ***********************************************************************************/
        public static void DrawCircle(this Graphics g, Pen pen,
                                      float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        /************************************************************************************
         * Method: DrawCircle
         * 
         * Summary: Method to fill in the circle on the graph
         ***********************************************************************************/
        public static void FillCircle(this Graphics g, Brush brush,
                                      float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }
    }
}

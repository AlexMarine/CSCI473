/************************************************************************************
 * Authors: Alex Marine (z1863905) and Tristan Tovar (z1832119)
 * Program: Assignment 4
 * Course: CSCI 473
 * Date: March 18, 2021
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

namespace MarineTovar_Assign4
{
    public partial class GCForm : Form
    {
        //variable declaration for drawing field parameters and set to default values
        private static int xMin = -20;        //the lowest x-coordinate
        private static int xMax = 20;        //the highest x-coordinate
        private static int xInterval = 1;  //the distance between ticks on the x-axis
        private static int yMin = -20;        //the lowest y-coordinate
        private static int yMax = 20;        //the highest y-coordinate
        private static int yInterval = 1;   //the distance between ticks on the y-ais

        //variable declaration for width and height of the pictureBox
        public static int W;
        public static int H;

        //variable declaration for values in equations
        float mLinear;
        float bLinear;
        float aQuadratic;
        float bQuadratic;
        float cQuadratic;
        float aCubic;
        float bCubic;
        float cCubic;
        float dCubic;
        float hCircle;
        float kCircle;
        float rCircle;

        //Pen Objects to create the colors of the graphed equations
        Pen linearPen = new Pen(Color.White);
        Pen quadraticPen = new Pen(Color.Red);
        Pen cubicPen = new Pen(Color.Green);
        Pen circlePen = new Pen(Color.Blue);

        /************************************************************************************
         * Method: GCForm
         * 
         * Summary: Intitialoze component and define variables to hold the width and height
         *  of the picture box.
         ***********************************************************************************/
        public GCForm()
        {
            InitializeComponent();

            //Define W and L for width and height of our pictureBox respectively
            W = pictureBox.Width;
            H = pictureBox.Height;
        }

        /************************************************************************************
         * Method: graphButton_Click
         * 
         * Summary: Check that each or the values that are entered in the equation text boxes
         *  are valid inputs. If one is not, do not graph it and output an error message and 
         *  leave the method. If they are valid, refresh the picture box.
         ***********************************************************************************/
        private void graphButton_Click(object sender, EventArgs e)
        {
            //clear out the rich text box
            richTextBox.Clear();

            //variable to check if value input is an int
            bool isDouble = true;

            //Parse variable to double and check if it is valid
            if (linearTextBoxM.Text != "")
            {
                isDouble = float.TryParse(linearTextBoxM.Text, out mLinear);
                if (isDouble == false)
                {
                    //Output error message and leave function
                    richTextBox.AppendText("ERROR: First value in linear can not be graphed");
                    return;
                }
            }
            //Parse variable to double and check if it is valid
            if (linearTextBoxB.Text != "")
            {
                isDouble = float.TryParse(linearTextBoxB.Text, out bLinear);
                if (isDouble == false)
                {
                    //Output error message and leave function
                    richTextBox.AppendText("ERROR: First value in linear can not be graphed");
                    return;
                }
            }
            //Parse variable to double and check if it is valid
            if (quadraticTextBoxA.Text != "")
            {
                isDouble = float.TryParse(quadraticTextBoxA.Text, out aQuadratic);
                if (isDouble == false)
                {
                    //Output error message and leave function
                    richTextBox.AppendText("ERROR: First value in quadratic can not be graphed");
                    return;
                }
            }
            //Parse variable to double and check if it is valid
            if (quadraticTextBoxB.Text != "")
            {
                isDouble = float.TryParse(quadraticTextBoxB.Text, out bQuadratic);
                if (isDouble == false)
                {
                    //Output error message and leave function
                    richTextBox.AppendText("ERROR: Second value in quadratic can not be graphed");
                    return;
                }
            }
            //Parse variable to double and check if it is valid
            if (quadraticTextBoxC.Text != "")
            {
                isDouble = float.TryParse(quadraticTextBoxC.Text, out cQuadratic);
                if (isDouble == false)
                {
                    //Output error message and leave function
                    richTextBox.AppendText("ERROR: Third value in quadratic can not be graphed");
                    return;
                }
            }
            //Parse variable to double and check if it is valid
            if (cubicTextBoxA.Text != "")
            {
                isDouble = float.TryParse(cubicTextBoxA.Text, out aCubic);
                if (isDouble == false)
                {
                    //Output error message and leave function
                    richTextBox.AppendText("ERROR: First value in cubic can not be graphed");
                    return;
                }
            }
            //Parse variable to double and check if it is valid
            if (cubicTextBoxB.Text != "")
            {
                isDouble = float.TryParse(cubicTextBoxB.Text, out bCubic);
                if (isDouble == false)
                {
                    //Output error message and leave function
                    richTextBox.AppendText("ERROR: Second value in cubic can not be graphed");
                    return;
                }
            }
            //Parse variable to double and check if it is valid
            if (cubicTextBoxC.Text != "")
            {
                isDouble = float.TryParse(cubicTextBoxC.Text, out cCubic);
                if (isDouble == false)
                {
                    //Output error message and leave function
                    richTextBox.AppendText("ERROR: Third value in cubic can not be graphed");
                    return;
                }
            }
            //Parse variable to double and check if it is valid
            if (cubicTextBoxD.Text != "")
            {
                isDouble = float.TryParse(cubicTextBoxD.Text, out dCubic);
                if (isDouble == false)
                {
                    //Output error message and leave function
                    richTextBox.AppendText("ERROR: Fourth value in cubic can not be graphed");
                    return;
                }
            }
            //Parse variable to double and check if it is valid
            if (circleTextBoxH.Text != "")
            {
                isDouble = float.TryParse(circleTextBoxH.Text, out hCircle);
                if (isDouble == false)
                {
                    //Output error message and leave function
                    richTextBox.AppendText("ERROR: First value in circle can not be graphed");
                    return;
                }
            }
            //Parse variable to double and check if it is valid
            if (circleTextBoxK.Text != "")
            {
                isDouble = float.TryParse(circleTextBoxK.Text, out kCircle);
                if (isDouble == false)
                {
                    //Output error message and leave function
                    richTextBox.AppendText("ERROR: Second value in circle can not be graphed");
                    return;
                }
            }
            //Parse variable to double and check if it is valid
            if (circleTextBoxR.Text != "")
            {
                isDouble = float.TryParse(circleTextBoxR.Text, out rCircle);
                if (isDouble == false)
                {
                    //Output error message and leave function
                    richTextBox.AppendText("ERROR: Third value in circle can not be graphed");
                    return;
                }
            }

            pictureBox.Refresh();
        }

        /************************************************************************************
         * Method: pictureBox_Paint
         * 
         * Summary: Change the scope of the graph based on the values that are entered into
         *  the drawing field parameters. For each of the different equations that can be
         *  graphed, if all of the fields are filled out in their equation, graph the
         *  function.
         ***********************************************************************************/
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //find the distance between the x points ****NOTE!!!: ALL DISTANCES ARE MEASURED AS ABSOLUTE VALUES if you need a min/max to go negative include the - sign!!
            int xDistance = Math.Abs(xMax-xMin);
            int xTicks = xDistance / xInterval;

            //find the distance between the y points
            int yDistance = Math.Abs(yMax-yMin);
            int yTicks = yDistance / yInterval;

            //find the number of pixels between each tick
            int xTickPixels = W / xTicks;
            int yTickPixels = H / yTicks;

            //find the number of pixels between each unit (tickpixel / unit label interval = pixels per unit
            float xUnitPixels = (float)xTickPixels / (float)xInterval;
            float yUnitPixels = (float)yTickPixels / (float)yInterval;

            using (Pen myPen = new Pen(Color.PapayaWhip))
            {
                //Both axes are present
                if (xMin <= 0 && xMax >= 0 && yMin <= 0 && yMax >= 0)
                {
                    //Find the distance of each x min/max
                    int xMinDistance = (Math.Abs(xMin) / xInterval) * xTickPixels; //distance in pixels = number of min ticks * pixels per tick
                    int xMaxDistance = (Math.Abs(xMax) / xInterval) * xTickPixels; //same as xMinDistance

                    //Find the distance of each y min/max
                    int yMinDistance = (Math.Abs(yMin) / yInterval) * yTickPixels; //distance in pixels = number of min ticks * pixels per tick
                    int yMaxDistance = (Math.Abs(yMax) / yInterval) * yTickPixels; //same as yMinDistance
                    
                    //Translate the coordinate origin to match the graph (0,0 of the picture box becomes 0,0 of the graph)
                    g.TranslateTransform(xMinDistance, yMaxDistance);
                    //invert the y coordinate so negatives actually go down
                    g.ScaleTransform(1.0F, -1.0F);

                    //Draw the y-axis and x-axis
                    if(xMax == 0) // if xMax = 0, subtract y-axis draw by 1 pixel otherwise it shows off screen 
                    {
                    g.DrawLine(myPen, -1, -yMinDistance, -1, yMaxDistance); //y
                    }
                    else
                    {
                        g.DrawLine(myPen, 0, -yMinDistance, 0, yMaxDistance); //y
                    }
                    if(yMin == 0) //same reason as above, add x-axis draw by 1 pixel
                    {
                        g.DrawLine(myPen, -(xMinDistance), 1, xMaxDistance, 1); //x
                    }
                    else
                    {
                        g.DrawLine(myPen, -(xMinDistance), 0, xMaxDistance, 0); //x
                    }
                    
                    //Draw tick marks for x-axis minimums
                    for (int i = 1; i <= (Math.Abs(xMin) / xInterval); i++)
                    {
                        g.DrawLine(myPen, -(i*xTickPixels), -3, -(i*xTickPixels), 3);
                    }
                    //Draw tick marks for x-axis maximums
                    for (int i = 1; i <= (Math.Abs(xMax) / xInterval); i++)
                    {
                        g.DrawLine(myPen, (i * xTickPixels), -3, (i * xTickPixels), 3);
                    }
                    //Draw tick marks for y-axis minimums
                    for (int i = 1; i <= (Math.Abs(yMin) / yInterval); i++)
                    {
                        g.DrawLine(myPen, -3, -(i * yTickPixels), 3, -(i * yTickPixels));
                    }
                    //Draw tick marks for y-maximums
                    for (int i = 1; i <= (Math.Abs(yMax) / yInterval); i++)
                    {
                        g.DrawLine(myPen, -3, (i * yTickPixels), 3, (i * yTickPixels));
                    }
                    //Draw right and bottom most interval lines
                    g.DrawLine(myPen, (xMaxDistance-1), -3, (xMaxDistance-1), 3); //if we don't subtract 1 it doesn't show up
                    g.DrawLine(myPen, -3, -(yMinDistance-1), 3, -(yMinDistance-1));

                    //Update the labels
                    midTopLabel.Text = yMax.ToString();
                    midBottomLabel.Text = yMin.ToString();
                    midRightLabel.Text = xMax.ToString();
                    midLeftLabel.Text = xMin.ToString();
                    yTopLeftLabel.Text = "";
                    yTopRightLabel.Text = "";
                    yBottomLeftLabel.Text = "";
                    yBottomRightLabel.Text = "";
                    xTopLeftLabel.Text = "";
                    xTopRightLabel.Text = "";
                    xBottomLeftLabel.Text = "";
                    xBottomRightLabel.Text = "";
                }
                //y-axis at left of graph and x-axis at bottom (neither present)
                else if (xMin > 0 && yMin > 0)
                {
                    //set the x and y origin values to bottom left corner
                    g.TranslateTransform(0, H);
                    //invert the y coordinate so negatives actually go down
                    g.ScaleTransform(1.0F, -1.0F);

                    //Draw tick marks for x-axis
                    for (int i = 0; i < xTicks; i++)
                    {
                        g.DrawLine(myPen, (i*xTickPixels), -3, (i*xTickPixels), 3);
                    }
                    //Draw tick marks for y-axis
                    for (int i = 0; i < yTicks; i++)
                    {
                        g.DrawLine(myPen, -3, (i*yTickPixels), 3, (i*yTickPixels));
                    }

                    //Update the labels
                    midTopLabel.Text = "";
                    midBottomLabel.Text = "";
                    midRightLabel.Text = "";
                    midLeftLabel.Text = "";
                    yTopLeftLabel.Text = yMax.ToString();
                    yTopRightLabel.Text = "";
                    yBottomLeftLabel.Text = yMin.ToString();
                    yBottomRightLabel.Text = "";
                    xTopLeftLabel.Text = "";
                    xTopRightLabel.Text = "";
                    xBottomLeftLabel.Text = xMin.ToString();
                    xBottomRightLabel.Text = xMax.ToString(); ;
                }
                //y-axis at right of graph and x-axis at bottom (neither present)
                else if (xMax < 0 && yMin > 0)
                {
                    //set the x and y origin values to bottom right, subtract 1 otherwise the ticks in the intersection don't show
                    g.TranslateTransform(W-1, H-1);
                    //invert the y coordinate so negatives actually go down
                    g.ScaleTransform(1.0F, -1.0F);

                    //Draw tick marks for x-axis
                    for (int i = 0; i < xTicks; i++)
                    {
                        g.DrawLine(myPen, -(i*xTickPixels), -3, -(i*xTickPixels), 3);
                    }
                    //Draw tick marks for y-axis
                    for (int i = 0; i < yTicks; i++)
                    {
                        g.DrawLine(myPen, -3, (i*yTickPixels), 3, (i*yTickPixels));
                    }

                    //Update the labels
                    midTopLabel.Text = "";
                    midBottomLabel.Text = "";
                    midRightLabel.Text = "";
                    midLeftLabel.Text = "";
                    yTopLeftLabel.Text = "";
                    yTopRightLabel.Text = yMax.ToString();
                    yBottomLeftLabel.Text = "";
                    yBottomRightLabel.Text = yMin.ToString(); ;
                    xTopLeftLabel.Text = "";
                    xTopRightLabel.Text = "";
                    xBottomLeftLabel.Text = xMin.ToString();
                    xBottomRightLabel.Text = xMax.ToString();
                }
                //y-axis at right of graph and x-axis at top (neither present)
                else if (xMax < 0 && yMax < 0)
                {
                    //set the x and y origin values to top right, subtract 1 otherwise the x-tick in the intersection doesn't show
                    g.TranslateTransform(W-1,0);
                    //invert the y coordinate so negatives actually go down
                    g.ScaleTransform(1.0F, -1.0F);

                    //Draw tick marks for x-axis
                    for (int i = 0; i < xTicks; i++)
                    {
                        g.DrawLine(myPen, -(i*xTickPixels), -3, -(i*xTickPixels), 3);
                    }
                    //Draw tick marks for y-axis
                    for (int i = 0; i < yTicks; i++)
                    {
                        g.DrawLine(myPen, -3, -(i*yTickPixels), 3, -(i*yTickPixels));
                    }

                    //Update the labels
                    midTopLabel.Text = "";
                    midBottomLabel.Text = "";
                    midRightLabel.Text = "";
                    midLeftLabel.Text = "";
                    yTopLeftLabel.Text = "";
                    yTopRightLabel.Text = yMax.ToString();
                    yBottomLeftLabel.Text = "";
                    yBottomRightLabel.Text = yMin.ToString();
                    xTopLeftLabel.Text = xMin.ToString();
                    xTopRightLabel.Text = xMax.ToString();
                    xBottomLeftLabel.Text = "";
                    xBottomRightLabel.Text = "";
                }
                //y-axis at left of graph and x-axis at top
                else if (xMin > 0 && yMax < 0)
                {
                    //set the x and y origin values to top left
                    g.TranslateTransform(0, 0);
                    //invert the y coordinate so negatives actually go down
                    g.ScaleTransform(1.0F, -1.0F);

                    //Draw tick marks for x-axis
                    for (int i = 0; i < xTicks; i++)
                    {
                        g.DrawLine(myPen, (i*xTickPixels), -3, (i*xTickPixels), 3);
                    }
                    //Draw tick marks for y-axis
                    for (int i = 0; i < yTicks; i++)
                    {
                        g.DrawLine(myPen, -3, -(i*yTickPixels), 3, -(i*yTickPixels));
                    }

                    //Update the labels
                    midTopLabel.Text = "";
                    midBottomLabel.Text = "";
                    midRightLabel.Text = "";
                    midLeftLabel.Text = "";
                    yTopLeftLabel.Text = yMax.ToString();
                    yTopRightLabel.Text = "";
                    yBottomLeftLabel.Text = yMin.ToString();
                    yBottomRightLabel.Text = "";
                    xTopLeftLabel.Text = xMin.ToString();
                    xTopRightLabel.Text = xMax.ToString();
                    xBottomLeftLabel.Text = "";
                    xBottomRightLabel.Text = "";
                }
                //x-axis at bottom of graph (only y-axis present)
                else if (yMin > 0)
                {
                    //Find the distance of each x min/max
                    int xMinDistance = (Math.Abs(xMin) / xInterval) * xTickPixels; //distance in pixels = number of min ticks * pixels per tick

                    //Find the distance of each y min/max
                    int yMinDistance = (Math.Abs(yMin) / yInterval) * yTickPixels; //distance in pixels = number of min ticks * pixels per tick
                    int yMaxDistance = (Math.Abs(yMax) / yInterval) * yTickPixels; //same as yMinDistance

                    //Draw tick marks for x-axis minimums, done before origin translation because its easier to draw before
                    for (int i = 1; i <= (Math.Abs(xMin) / xInterval); i++)
                    {
                        g.DrawLine(myPen, (xMinDistance-(i * xTickPixels)), H-3, xMinDistance-(i * xTickPixels), H+3);
                    }

                    //Draw tick marks for x-axis maximums (you have to subtract xMinDistance by 1 or the final tick sometimes won't show
                    for (int i = 1; i <= (Math.Abs(xMax) / xInterval); i++)
                    {
                        g.DrawLine(myPen, ((xMinDistance-1) + (i * xTickPixels)), H - 3, (xMinDistance-1) + (i * xTickPixels), H + 3);
                    }

                    //Translate the coordinate origin to match the graph (0,0 of the picture box becomes 0,0 of the graph)
                    g.TranslateTransform(xMinDistance, yMaxDistance);
                    //invert the y coordinate so negatives actually go down
                    g.ScaleTransform(1.0F, -1.0F);

                    //Draw the y-axis
                    g.DrawLine(myPen, 0, -yMinDistance, 0, yMaxDistance+yMinDistance);

                    //Draw tick marks for y-maximums
                    for (int i = 1; i <= (Math.Abs(yMax) / yInterval); i++)
                    {
                        g.DrawLine(myPen, -3, (i * yTickPixels), 3, (i * yTickPixels));
                    }

                    //Update the labels
                    midTopLabel.Text = yMax.ToString();
                    midBottomLabel.Text = yMin.ToString();
                    midRightLabel.Text = "";
                    midLeftLabel.Text = "";
                    yTopLeftLabel.Text = "";
                    yTopRightLabel.Text = "";
                    yBottomLeftLabel.Text = "";
                    yBottomRightLabel.Text = "";
                    xTopLeftLabel.Text = "";
                    xTopRightLabel.Text = "";
                    xBottomLeftLabel.Text = xMin.ToString();
                    xBottomRightLabel.Text = xMax.ToString();
                }
                //x-axis at top of graph (only y-axis present)
                else if (yMax < 0)
                {
                    //Find the distance of each x min/max
                    int xMinDistance = (Math.Abs(xMin) / xInterval) * xTickPixels; //distance in pixels = number of min ticks * pixels per tick

                    //Find the distance of each y min/max
                    int yMinDistance = (Math.Abs(yMin) / yInterval) * yTickPixels; //distance in pixels = number of min ticks * pixels per tick
                    int yMaxDistance = (Math.Abs(yMax) / yInterval) * yTickPixels; //same as yMinDistance

                    //Draw tick marks for x-axis minimums, done before change of origin to make markings easier
                    for (int i = 1; i <= (Math.Abs(xMin) / xInterval); i++)
                    {
                        g.DrawLine(myPen, (xMinDistance - (i * xTickPixels)), -3, xMinDistance - (i * xTickPixels), 3);
                    }

                    //Draw tick marks for x-axis maximums (you have to subtract xMinDistance by 1 or the final tick sometimes won't show
                    for (int i = 1; i <= (Math.Abs(xMax) / xInterval); i++)
                    {
                        g.DrawLine(myPen, ((xMinDistance - 1) + (i * xTickPixels)), -3, (xMinDistance - 1) + (i * xTickPixels), 3);
                    }

                    //Translate the coordinate origin to match the graph (0,0 of the picture box becomes 0,0 of the graph)
                    g.TranslateTransform(xMinDistance, -yMaxDistance);
                    //invert the y coordinate so negatives actually go down
                    g.ScaleTransform(1.0F, -1.0F);

                    //Draw the y-axis
                    g.DrawLine(myPen, 0, -yMinDistance, 0, yMaxDistance + yMinDistance);

                    //Draw tick marks for y-minimums
                    for (int i = 1; i <= (Math.Abs(yMin) / yInterval); i++)
                    {
                        g.DrawLine(myPen, -3, -(i * yTickPixels), 3, -(i * yTickPixels));
                    }

                    //Update the labels
                    midTopLabel.Text = yMax.ToString();
                    midBottomLabel.Text = yMin.ToString();
                    midRightLabel.Text = "";
                    midLeftLabel.Text = "";
                    yTopLeftLabel.Text = "";
                    yTopRightLabel.Text = "";
                    yBottomLeftLabel.Text = "";
                    yBottomRightLabel.Text = "";
                    xTopLeftLabel.Text = xMin.ToString();
                    xTopRightLabel.Text = xMax.ToString();
                    xBottomLeftLabel.Text = "";
                    xBottomRightLabel.Text = "";
                }
                //y-axis at left of graph (only x-axis is present)
                else if (xMin > 0)
                {
                    //Find the distance of each x min/max
                    int xMinDistance = (Math.Abs(xMin) / xInterval) * xTickPixels; //distance in pixels = number of min ticks * pixels per tick
                    int xMaxDistance = (Math.Abs(xMax) / xInterval) * xTickPixels; //same as xMinDistance

                    //Find the distance of each y min/max
                    int yMinDistance = (Math.Abs(yMin) / yInterval) * yTickPixels; //distance in pixels = number of min ticks * pixels per tick
                    int yMaxDistance = (Math.Abs(yMax) / yInterval) * yTickPixels; //same as yMinDistance

                    //Draw tick marks for y-axis minimums, done before origin translation because its easier to draw before
                    for (int i = 1; i <= (Math.Abs(yMin) / yInterval); i++)
                    {
                        g.DrawLine(myPen, -3, (yMinDistance - (i * yTickPixels)), 3, yMinDistance - (i * yTickPixels));
                    }

                    //Draw tick marks for y-axis maximums (you have to subtract yMinDistance by 1 or the final tick sometimes won't show
                    for (int i = 1; i <= (Math.Abs(yMax) / yInterval); i++)
                    {
                        g.DrawLine(myPen, -3, ((yMinDistance - 1) + (i * yTickPixels)), 3, (yMinDistance - 1) + (i * yTickPixels));
                    }

                    //Translate the coordinate origin to match the graph (0,0 of the picture box becomes 0,0 of the graph)
                    g.TranslateTransform(-xMinDistance, yMaxDistance);
                    //invert the y coordinate so negatives actually go down
                    g.ScaleTransform(1.0F, -1.0F);

                    //Draw the x-axis
                    g.DrawLine(myPen, -xMinDistance, 0, xMinDistance+xMaxDistance, 0);

                    //Draw tick marks for x-maximums
                    for (int i = 1; i <= (Math.Abs(xMax) / xInterval); i++)
                    {
                        g.DrawLine(myPen, (i * xTickPixels),-3, (i * xTickPixels), 3);
                    }

                    //Update the labels
                    midTopLabel.Text = "";
                    midBottomLabel.Text = "";
                    midRightLabel.Text = xMax.ToString();
                    midLeftLabel.Text = xMin.ToString();
                    yTopLeftLabel.Text = yMax.ToString();
                    yTopRightLabel.Text = "";
                    yBottomLeftLabel.Text = yMin.ToString();
                    yBottomRightLabel.Text = "";
                    xTopLeftLabel.Text = "";
                    xTopRightLabel.Text = "";
                    xBottomLeftLabel.Text = "";
                    xBottomRightLabel.Text = "";
                }
                //y-axis at right of graph (only x-axis is present)
                else if (xMax < 0)
                {
                    //Find the distance of each x min/max
                    int xMinDistance = (Math.Abs(xMin) / xInterval) * xTickPixels; //distance in pixels = number of min ticks * pixels per tick
                    int xMaxDistance = (Math.Abs(xMax) / xInterval) * xTickPixels; //same as xMinDistance

                    //Find the distance of each y min/max
                    int yMinDistance = (Math.Abs(yMin) / yInterval) * yTickPixels; //distance in pixels = number of min ticks * pixels per tick
                    int yMaxDistance = (Math.Abs(yMax) / yInterval) * yTickPixels; //same as yMinDistance

                    //Draw tick marks for y-axis minimums, done before change of origin to make markings easier
                    for (int i = 1; i <= (Math.Abs(yMin) / yInterval); i++)
                    {
                        g.DrawLine(myPen, W-3, (yMinDistance - (i * yTickPixels)), W+3, yMinDistance - (i * yTickPixels));
                    }

                    //Draw tick marks for y-axis maximums (you have to subtract xMinDistance by 1 or the final tick sometimes won't show
                    for (int i = 1; i <= (Math.Abs(yMax) / yInterval); i++)
                    {
                        g.DrawLine(myPen, W-3, ((yMinDistance - 1) + (i * yTickPixels)), W+3, (yMinDistance - 1) + (i * yTickPixels));
                    }

                    //Translate the coordinate origin to match the graph (0,0 of the picture box becomes 0,0 of the graph)
                    g.TranslateTransform(xMinDistance, yMaxDistance);
                    //invert the y coordinate so negatives actually go down
                    g.ScaleTransform(1.0F, -1.0F);

                    //Draw the x-axis
                    g.DrawLine(myPen, -xMinDistance, 0, xMaxDistance+xMinDistance, 0);

                    //Draw tick marks for x-minimums
                    for (int i = 1; i <= (Math.Abs(xMin) / xInterval); i++)
                    {
                        g.DrawLine(myPen, -(i * xTickPixels), -3, -(i * xTickPixels), 3);
                    }

                    //Update the labels
                    midTopLabel.Text = "";
                    midBottomLabel.Text = "";
                    midRightLabel.Text = xMax.ToString();
                    midLeftLabel.Text = xMin.ToString();
                    yTopLeftLabel.Text = "";
                    yTopRightLabel.Text = yMax.ToString();
                    yBottomLeftLabel.Text = "";
                    yBottomRightLabel.Text = yMin.ToString();
                    xTopLeftLabel.Text = "";
                    xTopRightLabel.Text = "";
                    xBottomLeftLabel.Text = "";
                    xBottomRightLabel.Text = "";
                }
            }

            //If every text box is filled out, graph the linear equation
            if (linearTextBoxM.Text != "" && linearTextBoxB.Text != "" )
            {
                //number of points to graph (# of x units) = total with pixels / pixels per unit
                int units = W / (int)xUnitPixels;
                //Create an array of Point Structs
                PointF[] points = new PointF[units + 1];
                //Create a temp variable that will be our x-coordinate sampler
                float x = (float)xMin;
                //Flag to check if any Point exists in the range
                bool oobFlag = true;
                for (int i = 0; i <= units; i++)
                {
                    float solvedForY = (mLinear * x) + bLinear;
                    points[i] = new PointF(x * xUnitPixels, solvedForY * yUnitPixels);
                    if (solvedForY <= yMax && solvedForY >= yMin)
                    {
                        oobFlag = false;
                    }
                    x++;
                }
                if (oobFlag)//if out of bounds has never been unchecked in the for loop, display error
                {
                    richTextBox.AppendText("LINEAR ERROR: No point of the equation is within the specified graph parameters.\n");
                }
                else //else, draw the graph
                {
                    e.Graphics.DrawCurve(linearPen, points);
                }
            }

            //if every text box is filled out, graph the circle equation
            if (circleTextBoxH.Text != "" && circleTextBoxK.Text != "" && circleTextBoxR.Text != "")
            {
                if(rCircle == 0) // error check the radius
                {
                    richTextBox.AppendText("CIRCLE ERROR: Radius cannot be equal to zero.\n");
                }
                else if(hCircle < xMin-(rCircle-1) || hCircle > xMax+(rCircle-1) || kCircle < yMin-(rCircle-1) || kCircle > yMax+(rCircle-1)) //error check if coordinates go offscreen 
                {
                    richTextBox.AppendText("CIRCLE ERROR: out of bounds, not enough circle will graph.\n");
                }
                else if((hCircle<xMin&&kCircle<xMin)||(hCircle > xMax && kCircle > xMax) ||(hCircle < xMin && kCircle > xMax) ||(hCircle > xMax && kCircle < xMin)) //checks if both coordinates go offscreen
                {
                    richTextBox.AppendText("CIRCLE ERROR: out of bounds, not enough circle will graph.\n");
                }
                else //no errors, then graph
                {
                    float x = hCircle * xUnitPixels;
                    float y = kCircle * yUnitPixels;                    
                    float rx = rCircle * xUnitPixels;
                    float ry = rCircle * yUnitPixels;
                    g.DrawEllipse(circlePen, x - rx, y-ry, rx*2, ry*2);
                }
            }

            //If every text box is filled out, graph the quadratic equation
            if (quadraticTextBoxA.Text != "" && quadraticTextBoxB.Text != "" && quadraticTextBoxC.Text != "")
            {
                //number of points to graph (# of x units) = total with pixels / pixels per unit
                int units = W / (int)xUnitPixels;
                //Create an array of Point Structs
                PointF[] points = new PointF[units+1];
                //Create a temp variable that will be our x-coordinate sampler
                float x = (float)xMin;
                //Flag to check if any Point exists in the range
                bool oobFlag = true;
                for(int i = 0; i <= units; i++)
                {
                    float solvedForY = (aQuadratic*x*x) + (bQuadratic*x) + cQuadratic;
                    points[i] = new PointF(x * xUnitPixels, solvedForY * yUnitPixels);
                    if(solvedForY <= yMax && solvedForY >= yMin)
                    {
                        oobFlag = false;
                    }
                    x++;
                }
                if(oobFlag)//if out of bounds has never been unchecked in the for loop, display error
                {
                    richTextBox.AppendText("QUADRATIC ERROR: No point of the equation is within the specified graph parameters.\n");
                }
                else //else, draw the graph
                {
                    e.Graphics.DrawCurve(quadraticPen, points);
                }
             }

            //If every text box is filled out, graph the cubic equation
            if (cubicTextBoxA.Text != "" && cubicTextBoxB.Text != "" && cubicTextBoxC.Text != "" && cubicTextBoxD.Text != "")
            {
                //number of points to graph (# of x units) = total with pixels / pixels per unit
                int units = W / (int)xUnitPixels;
                //Create an array of Point Structs
                PointF[] points = new PointF[units + 1];
                //Create a temp variable that will be our x-coordinate sampler
                float x = (float)xMin;
                //Flag to check if any Point exists in the range
                bool oobFlag = true;
                for (int i = 0; i <= units; i++)
                {
                    float solvedForY = (aCubic * x * x * x) + (bCubic * x * x) + (cCubic * x) + dCubic;
                    points[i] = new PointF(x * xUnitPixels, solvedForY * yUnitPixels);
                    if (solvedForY <= yMax && solvedForY >= yMin)
                    {
                        oobFlag = false;
                    }
                    x++;
                }
                if (oobFlag)//if out of bounds has never been unchecked in the for loop, display error
                {
                    richTextBox.AppendText("CUBIC ERROR: No point of the equation is within the specified graph parameters.\n");
                }
                else //else, draw the graph
                {
                    e.Graphics.DrawCurve(cubicPen, points);
                }
            }
        }

        /************************************************************************************
         * Method: drawFieldApplyButton_Click
         * 
         * Summary: Check that each or the values that are entered in the draw field text 
         *  boxes are valid inputs. If one is not, do not apply and output an error message 
         *  and leave the method. If they are valid, refresh the picture box.
         ***********************************************************************************/
        private void drawFieldApplyButton_Click(object sender, EventArgs e)
        {
            //clear out the rich text box
            richTextBox.Clear();

            //variable to check if value input is an int
            bool isInt = true;

            //Parse variable to int and check if it is valid
            isInt = int.TryParse(xMinTextBox.Text, out xMin);
            if (isInt == false)
            {
                //Output error message and leave function
                richTextBox.AppendText("ERROR: X-Minimum value can not be graphed");
                return;
            }
            //Parse variable to int and check if it is valid
            isInt = int.TryParse(xMaxTextBox.Text, out xMax);
            if (isInt == false)
            {
                //Output error message and leave function
                richTextBox.AppendText("ERROR: X-Maximum value can not be graphed");
                return;
            }
            //Parse variable to int and check if it is valid
            isInt = int.TryParse(xIntervalTextBox.Text, out xInterval);
            if (isInt == false)
            {
                //Output error message and leave function
                richTextBox.AppendText("ERROR: X-Interval value can not be graphed");
                return;
            }
            //Parse variable to int and check if it is valid
            isInt = int.TryParse(yMinTextBox.Text, out yMin);
            if (isInt == false)
            {
                //Output error message and leave function
                richTextBox.AppendText("ERROR: Y-Minimum value can not be graphed");
                return;
            }
            //Parse variable to int and check if it is valid
            isInt = int.TryParse(yMaxTextBox.Text, out yMax);
            if (isInt == false)
            {
                //Output error message and leave function
                richTextBox.AppendText("ERROR: Y-Maximum value can not be graphed");
                return;
            }
            //Parse variable to int and check if it is valid
            isInt = int.TryParse(yIntervalTextBox.Text, out yInterval);
            if (isInt == false)
            {
                //Output error message and leave function
                richTextBox.AppendText("ERROR: Y-Interval value can not be graphed");
                return;
            }
            //if numbers that are impossible to graph are entered
            if ((xMin >= xMax) || (yMin >= yMax) || (xInterval <= 0) || (yInterval <= 0))
            {
                //Output error message and leave function
                richTextBox.AppendText("ERROR: Values entered can not be graphed");
                return;
            }

            //Refresh the graph to update it
            pictureBox.Refresh();
        }

        /************************************************************************************
         * Method: linearColorButton_Click
         * 
         * Summary: Set the color that the user selected as the color that will be used to
         *  graph the linear equation.
         ***********************************************************************************/
        private void linearColorButton_Click(object sender, EventArgs e)
        {
            //If the user didn't hit cancel
            if (equationColorDialog.ShowDialog() != DialogResult.Cancel)
            {
                linearPen.Color = equationColorDialog.Color;
            }
        }

        /************************************************************************************
         * Method: quadraticColorButton_Click
         * 
         * Summary: Set the color that the user selected as the color that will be used to
         *  graph the qudaratic equation.
         ***********************************************************************************/
        private void quadraticColorButton_Click(object sender, EventArgs e)
        {
            //If the user didn't hit cancel
            if (equationColorDialog.ShowDialog() != DialogResult.Cancel)
            {
                quadraticPen.Color = equationColorDialog.Color;
            }
        }

        /************************************************************************************
         * Method: cubicColorButton_Click
         * 
         * Summary: Set the color that the user selected as the color that will be used to
         *  graph the cubic equation.
         ***********************************************************************************/
        private void cubicColorButton_Click(object sender, EventArgs e)
        {
            //If the user didn't hit cancel
            if (equationColorDialog.ShowDialog() != DialogResult.Cancel)
            {
                cubicPen.Color = equationColorDialog.Color;
            }
        }

        /************************************************************************************
         * Method: circleColorButton_Click
         * 
         * Summary: Set the color that the user selected as the color that will be used to
         *  graph the circle equation.
         ***********************************************************************************/
        private void circleColorButton_Click(object sender, EventArgs e)
        {
            //If the user didn't hit cancel
            if (equationColorDialog.ShowDialog() != DialogResult.Cancel)
            {
                circlePen.Color = equationColorDialog.Color;
            }
        }
    }
}

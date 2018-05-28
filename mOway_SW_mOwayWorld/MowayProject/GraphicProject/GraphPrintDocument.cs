using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections.Generic;

using Moway.Project.GraphicProject.GraphLayout;

namespace Moway.Project.GraphicProject
{
    public class GraphPrintDocument : PrintDocument, iPrintDocument
    {
        #region Attributes

        private PrintRange range = PrintRange.AllPages;
        private GraphDiagram presentFunction;
        private string projectName;
        private string projectOwner;
        private List<GraphDiagram> functions;
        private int functionIndex = 0;
        private Font font = new Font(FontFamily.GenericSansSerif, 12F);
        private StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);

        #endregion

        #region Properties

        #endregion

        public GraphPrintDocument(string projectName, string projectOwner, GraphDiagram presentFunction, List<GraphDiagram> functions)
        {
            this.projectName = projectName;
            this.projectOwner = projectOwner;
            this.presentFunction = presentFunction;
            this.functions = functions;
            this.PrintPage += new PrintPageEventHandler(PrinterDocument_PrintPage);
        }

        public void Print(PrintRange range)
        {
            this.range = range;
            this.Print();
        }

        #region Print Event

        /// <summary>
        /// Print a page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PrinterDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (this.range == PrintRange.AllPages)
            {
                //The page marked with the index is printed
                PrintFunction(this.functions[this.functionIndex], e);
                this.functionIndex++;
                //If there are any functions indicated to print another page
                if (this.functionIndex == this.functions.Count)
                    e.HasMorePages = false;
                else
                    e.HasMorePages = true;
            }
            else
            {
                //Only the current page is printed
                PrintFunction(this.presentFunction, e);
                e.HasMorePages = false;
            }
        }

        #endregion

        #region Private methods

        //Prints a page with a diagram
        private void PrintFunction(GraphDiagram function, PrintPageEventArgs e)
        {
            //Gets the image and rotates it if necessary
            Image functionImage = (Image)function.DiagramBitmap;
            if ((function.AreaFormat == AreaFormat.A3_Horizontal) || (function.AreaFormat == AreaFormat.A4_Horizontal))
                functionImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            //The name of the project is printed
            e.Graphics.DrawString(this.projectName, font, new SolidBrush(Color.Black), new PointF(40, 30));
            //The current date is printed
            stringFormat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(DateTime.Now.ToShortDateString(), font, new SolidBrush(Color.Black), new PointF(e.PageSettings.PaperSize.Width / 2, 30), stringFormat);
            //The name of the project creator is printed
            stringFormat.Alignment = StringAlignment.Far;
            e.Graphics.DrawString(this.projectOwner, font, new SolidBrush(Color.Black), new PointF(e.PageSettings.PaperSize.Width - 40, 30), stringFormat);
            //The function image is printed
            e.Graphics.DrawImage(functionImage, new Rectangle(40, 50, e.PageSettings.PaperSize.Width - 80, e.PageSettings.PaperSize.Height - 80));
        }

        #endregion
    }
}

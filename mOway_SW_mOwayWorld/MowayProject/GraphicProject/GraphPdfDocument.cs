using System;
using System.IO;
using System.Drawing.Imaging;

using Root.Reports;
using Moway.Project.GraphicProject.GraphLayout;

namespace Moway.Project.GraphicProject
{
    public class GraphPdfDocument : Report
    {
        #region Attributes

        private string projectName;
        private string projectOwner;
        private GraphDiagram function;

        #endregion

        public GraphPdfDocument(string projectName, string projectOwner, GraphDiagram function)
            : base()
        {
            this.projectName = projectName;
            this.projectOwner = projectOwner;
            this.function = function;
        }

        #region Public methods

        protected override void Create()
        {
            new Page(this);
            this.sAuthor = this.projectOwner;
            this.sTitle = this.projectName;
            switch (this.function.AreaFormat)
            {
                case AreaFormat.A3_Vertical:
                    page_Cur.rWidthMM = 297;
                    page_Cur.rHeightMM = 420;
                    break;
                case AreaFormat.A3_Horizontal:
                    page_Cur.SetLandscape();
                    page_Cur.rWidthMM = 420;
                    page_Cur.rHeightMM = 297;
                    break;
                case AreaFormat.A4_Vertical:
                    page_Cur.rWidthMM = 210;
                    page_Cur.rHeightMM = 297;
                    break;
                case AreaFormat.A4_Horizontal:
                    page_Cur.SetLandscape();
                    page_Cur.rWidthMM = 297;
                    page_Cur.rHeightMM = 210;
                    break;
            }
            //The temporary image of the diagram is created
            string tempFile = Path.GetTempFileName();
            ImageCodecInfo jpgCodec = ProjectManager.GetEncoder("image/jpeg");
            //Parameters are configured 
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
            //The image is saved
            this.function.DiagramBitmap.Save(tempFile, jpgCodec, encoderParameters);
            //the zoom is calculated
            double zoom = (page_Cur.rWidth - 60) / this.function.Surface.Width;
            //Puts the title bar
            FontProp font = new FontPropMM(new FontDef(this, FontDef.StandardFont.Helvetica), 3);

            //The Project Name is included
            page_Cur.Add(30, 50, new RepString(font, this.projectName));
            //The date is included
            page_Cur.AddCB(50, new RepString(font, DateTime.Now.ToShortDateString()));
            //The name of the creator is included
            page_Cur.AddRight(page_Cur.rWidth - 30, 50, new RepString(font, this.projectOwner));
            //Puts the picture in the PDF
            page_Cur.AddCB(page_Cur.rHeight - 40, new RepImage(tempFile, this.function.Surface.Width * zoom, this.function.Surface.Size.Height * zoom));
        }

        #endregion
    }
}

using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;

using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.GraphLayout
{
    /// <summary>
    /// Represents a graphical layer of the GraphDrawing
    /// </summary>
    public class GraphLayer
    {
        #region Constants

        public const int HORIZONTAL_STEP = 16;
        public const int VERTICAL_STEP = 18;

        #endregion

        #region Attributes

        /// <summary>
        /// Surface of the Layer
        /// </summary>
        private Surface surface;
        /// <summary>
        /// Layer graphic Element list 
        /// </summary>
        private SpriteCollection elements = new SpriteCollection();
        /// <summary>
        /// Layer Visibility
        /// </summary>
        private bool visible = true;
        private Point location = new Point(0, 0);

        #endregion

        #region Properties

        /// <summary>
        /// Surface of the Layer
        /// </summary>
        public Surface Surface
        {
            get
            {
                if (this.visible)
                    return this.surface;
                else return null;
            }
        }
        /// <summary>
        /// Layer Visibility
        /// </summary>
        public bool Visible
        {
            get { return this.visible; }
            set { this.visible = value; }
        }
        /// <summary>
        /// List of graphic elements contained in the layer
        /// </summary>
        public List<GraphElement> Elements
        {
            get
            {
                //A new list is created so that an outside modification does not affect internally
                List<GraphElement> elements = new List<GraphElement>();
                foreach (Sprite sprite in this.elements)
                    if (sprite is GraphElement)
                        elements.Add((GraphElement)sprite);
                return elements;
            }
        }
        public Point Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        #endregion

        #region Events

        /// <summary>
        /// Surface Image Change Event
        /// </summary>
        public event EventHandler SurfaceChanged;

        #endregion

        /// <summary>
        /// Builder for the layer
        /// </summary>
        /// <param name="size">Initial size for the layer</param>
        public GraphLayer(Size size)
        {
            this.InitSurface(size);
        }

        public GraphLayer(Size size, List<GraphElement> graphElements)
        {
            this.InitSurface(size);
            this.AddElements(graphElements);
        }

        #region Public methods

        public void ChangeSize(Size size)
        {
            InitSurface(size);
            this.BlitElements();
        }

        private Size InitSurface(Size size)
        {
            this.surface = new Surface(size);
            //The transparency is set up
            this.surface.Transparent = true;
            this.surface.TransparentColor = GraphDiagram.TRASPARENT_COLOR;
            this.surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            return size;
        }
        
        public GridPoint[,] GetGridPoints()
        {
            GridPoint[,] gridStatus = new GridPoint[this.surface.Width / HORIZONTAL_STEP, this.surface.Height / VERTICAL_STEP];
            for (int i = 0; i < this.surface.Width / HORIZONTAL_STEP; i++)
                for (int j = 0; j < this.surface.Height / VERTICAL_STEP; j++)
                    gridStatus[i, j] = new GridPoint(new Point(7 + i * HORIZONTAL_STEP, 8 + j * VERTICAL_STEP), GridState.Free);
            foreach (GraphElement element in this.elements)
                if (!(element is GraphArrow))
                    if (element is GraphConditional)
                        for (int i = (element.Rectangle.Left / HORIZONTAL_STEP) + 1; i <= (element.Rectangle.Right - 11) / HORIZONTAL_STEP; i++)
                            for (int j = (element.Rectangle.Top / VERTICAL_STEP) + 1; j <= (element.Rectangle.Bottom - 11) / VERTICAL_STEP; j++)
                                gridStatus[i, j].State = GridState.Busy;
                    else if ((element is GraphStart) || (element is GraphFinish))
                        for (int i = (element.Rectangle.Left / HORIZONTAL_STEP); i <= element.Rectangle.Right / HORIZONTAL_STEP; i++)
                            for (int j = (element.Rectangle.Top / VERTICAL_STEP); j <= element.Rectangle.Bottom / VERTICAL_STEP; j++)
                                gridStatus[i, j].State = GridState.Busy;
                    else
                        for (int i = (element.Rectangle.Left / HORIZONTAL_STEP) + 1; i <= element.Rectangle.Right / HORIZONTAL_STEP; i++)
                            for (int j = (element.Rectangle.Top / VERTICAL_STEP) + 1; j <= element.Rectangle.Bottom / VERTICAL_STEP; j++)
                                gridStatus[i, j].State = GridState.Busy;
            return gridStatus;
        }

        /// <summary>
        /// Updates the Surface of the layer
        /// </summary>
        public void UpdateSurface()
        {
            this.BlitElements();
            //The event is always launched
            if (this.SurfaceChanged != null)
                this.SurfaceChanged(this, new EventArgs());
        }

        private void BlitElements()
        {
            //Only updates if the layer is visible
            if (this.visible)
            {
                SpriteCollection arrows = new SpriteCollection();
                SpriteCollection otherElements = new SpriteCollection();
                this.surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                foreach (Sprite element in this.elements)
                    if (!(element is GraphElement))
                        otherElements.Add(element);
                    else
                        if (element is GraphArrow)
                            arrows.Add(element);
                        else
                            this.surface.Blit(element);
                this.surface.Blit(arrows);
                this.surface.Blit(otherElements);
            }
        }

        /// <summary>
        /// Checks whether an element intersects with any graphic element in the layer
        /// </summary>
        /// <param name="element">Item to check</param>
        /// <returns>True If yes, False if there is no intersection</returns>
        public bool IntersectsWith(GraphElement element)
        {
            foreach (Sprite sprite in this.elements)
                if (sprite.IntersectsWith(element))
                    return true;
            return false;
        }

        /// <summary>
        /// Cleans all elements of the layer
        /// </summary>
        public void Clear()
        {
            this.elements.Clear();
        }

        /// <summary>
        /// Cleans all elements of the layer and hides it
        /// </summary>
        public void ClearAndHide()
        {
            this.Clear();
            this.visible = false;
        }

        public void Add(Sprite sprite)
        {
            this.elements.Add(sprite);
        }

        public void Remove(Sprite sprite)
        {
            this.elements.Remove(sprite);
        }

        /// <summary>
        /// Adds a graphic element to the layer
        /// </summary>
        /// <param name="element"></param>
        public void AddElement(GraphElement element)
        {
            this.elements.Add(element);
        }

        public void AddElements(List<GraphElement> elements)
        {
            foreach (GraphElement element in elements)
                this.elements.Add(element);
        }

        /// <summary>
        /// Removes a graphic element from the layer
        /// </summary>
        /// <param name="element">Element to eliminate</param>
        public void RemoveElement(GraphElement element)
        {
            this.elements.Remove(element);
        }

        /// <summary>
        /// Removes a list of graphic elements from the layer
        /// </summary>
        /// <param name="elements"></param>
        public void RemoveElements(List<GraphElement> elements)
        {
            foreach (GraphElement element in elements)
                this.elements.Remove(element);
        }

        #endregion
    }
}

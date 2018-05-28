using System;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Graphics.Primitives;

using Moway.Project.GraphicProject.Actions;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.GraphLayout.Elements
{
    public class GraphArrow : GraphElement
    {
        #region Constants

        private const int MIN_DISPLACEMENT = 6;

        #endregion

        #region Attributes

        private Connector initConnector;
        private SpriteCollection segments = new SpriteCollection();

        #endregion

        #region Properties

        public List<Point> Locations
        {
            get
            {
                List<Point> locations = new List<Point>();
                foreach (ArrowSegment segment in segments)
                    locations.Add(segment.StartPoint);
                locations.Add(((ArrowSegment)segments[segments.Count - 1]).EndPoint);
                return locations;
            }
        }
        public Connector InitConnector { get { return this.initConnector; } }
        public Connector FinalConnector { get { return this.next; } }
        public override bool Selected
        {
            get
            {
                return base.Selected;
            }
            set
            {
                if (this.selected != value)
                {
                    this.selected = value;
                    foreach (ArrowSegment segment in this.segments)
                        segment.Selected = value;
                    this.UpdateSurface();
                }
            }
        }
        public override GraphElement Next
        {
            get
            {
                if (this.next == null)
                    return null;
                else
                    return (GraphElement)this.next.Parent;
            }
        }
        public override List<GraphElement> Previous
        {
            get
            {
                List<GraphElement> prevElements = new List<GraphElement>();
                foreach (Connector connector in this.previous)
                        prevElements.Add(connector.Parent);
                return prevElements;
            }
        }
        public override Point Center
        {
            get { return base.Center; }
            set
            {
                Point difference = new Point(this.Center.X - value.X, this.Center.Y - value.Y);
                base.Center = value;
                foreach (ArrowSegment segment in this.segments)
                {
                    segment.StartPoint = new Point(segment.StartPoint.X - difference.X, segment.StartPoint.Y - difference.Y);
                    segment.EndPoint = new Point(segment.EndPoint.X - difference.X, segment.EndPoint.Y - difference.Y);
                }
            }
        }

        #endregion

        public GraphArrow(Connector initialConnector, Connector finalConnector, SpriteCollection segments)
        {
            // the connectors for the arrow are saved and the elements are saved
            
            this.initConnector = initialConnector;
            this.previous.Add(initConnector);
            this.next = finalConnector;
            //the Arrow element is created
            this.element = new Arrow();
            this.key = "arrow";

            List<Point> locations = new List<Point>();
            foreach (ArrowSegment segment in segments)
                locations.Add(segment.StartPoint);
            locations.Add(((ArrowSegment)segments[segments.Count - 1]).EndPoint);

            //the segments that make up the arrow are created
            this.CreateArrowSurface(locations);
        }

        public GraphArrow(Connector initialConnector, Connector finalConnector, GridPoint[,] gridPoints)
        {
            //the connectors for the arrow are saved and the elements are saved
            this.initConnector = initialConnector;
            this.previous.Add(initConnector);
            this.next = finalConnector;
            //the Arrow element is created
            this.element = new Arrow();
            this.key = "arrow";

            // the optimized route for the arrow is loaded without intermediate points
            
            List <Point> locations = this.GetPathPoints(gridPoints);
            //the segments that make up the arrow are created
            this.CreateArrowSurface(locations);
        }
        
        public GraphArrow(string key, string idElement, XmlElement xmlElement, List<GraphElement> graphElements, List<Element> elements, SortedList<string, XmlElement> id_XmlElements, SortedList<string, GraphElement> id_GraphElements, SortedList<string, Variable> variables)
        {
            this.element = new Arrow();
            this.key = key;
            Point position = new Point(-1, -1);

            List<Point> locations = new List<Point>();

            foreach (XmlElement nodo in xmlElement)
            {
                switch (nodo.Name)
                {
                    case "position":
                        position = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "previous":
                        if ((nodo.ChildNodes[0].Name == "elementId") && (nodo.ChildNodes[1].Name == "connectorId"))
                        {
                            GraphElement prevElement = null;
                            try
                            {
                                prevElement = id_GraphElements[nodo.ChildNodes[0].InnerText];
                            }
                            catch
                            {
                                prevElement = GraphDiagram.CreateGraphElement(id_XmlElements[nodo.ChildNodes[0].InnerText], graphElements, elements, id_XmlElements, id_GraphElements, variables);
                                graphElements.Add(prevElement);
                                id_GraphElements.Add(nodo.ChildNodes[0].InnerText, prevElement);
                                elements.Add(prevElement.Element);
                            }
                            this.initConnector = prevElement.GetConnector(System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                            this.previous.Add(this.initConnector);
                            if (this.previous[0].Parent is GraphConditional)
                                if (this.GetOutLine(id_XmlElements[nodo.ChildNodes[0].InnerText], idElement) == ConditionalOut.True)
                                    ((GraphConditional)this.previous[0].Parent).AddNext(this.initConnector, this, ConditionalOut.True);
                                else
                                    ((GraphConditional)this.previous[0].Parent).AddNext(this.initConnector, this, ConditionalOut.False);
                            else
                                this.previous[0].Parent.AddNext(this.initConnector, this);
                        }
                        break;
                    case "next":
                        if ((nodo.ChildNodes[0].Name == "elementId") && (nodo.ChildNodes[1].Name == "connectorId"))
                        {
                            GraphElement nextElement = null;
                            try
                            {
                                nextElement = (GraphElement)id_GraphElements[nodo.ChildNodes[0].InnerText];
                            }
                            catch
                            {
                                nextElement = GraphDiagram.CreateGraphElement(id_XmlElements[nodo.ChildNodes[0].InnerText], graphElements, elements, id_XmlElements, id_GraphElements, variables);
                                graphElements.Add(nextElement);
                                id_GraphElements.Add(nodo.ChildNodes[0].InnerText, nextElement);
                                elements.Add(nextElement.Element);
                            }
                            this.next = nextElement.GetConnector(System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                            this.next.Parent.AddPrevious(this.next, this);
                        }
                        break;
                    case "points":
                        foreach (XmlElement location in nodo.ChildNodes)
                            if ((location.ChildNodes[0].Name == "x") && (location.ChildNodes[1].Name == "y"))
                                locations.Add(new Point(System.Convert.ToInt32(location.ChildNodes[0].InnerText), System.Convert.ToInt32(location.ChildNodes[1].InnerText)));
                        break;
                    default:
                        throw new GraphException("Error al crear GraphStart");
                }
            }
            CreateArrowSurface(locations);
            this.Center = position;
        }

        #region Public methods

        public void ReplaceSegment(LineSegment segment, List<Point> points)
        {
            List<Point> locations = new List<Point>();
            //there must be more than two points for there to be a modification
            if (points.Count > 2)
            {
                for (int i = 0; i < this.segments.Count; i++)
                {
                    // if the segment to replace...
                    if (this.segments[i] == segment)
                    {
                        //the previous segment is analyzed with the initial position
                        if (this.segments[i - 1] is LineSegment)
                        {
                            //the last entered point is deleted
                            locations.RemoveAt(locations.Count - 1);
                            points[0] = ((ArrowSegment)this.segments[i - 1]).StartPoint;
                            if ((points[0].X == points[1].X) && (points[0].Y == points[1].Y))
                                points.RemoveAt(0);
                            this.segments.RemoveAt(i - 1);
                            i--;
                        }
                        // the next element is analyzed
                        if (this.segments[i + 1] is LineSegment)
                        {
                            points[points.Count - 1] = ((ArrowSegment)this.segments[i + 1]).EndPoint;
                            if ((points[points.Count - 1].X == points[points.Count - 2].X) && (points[points.Count - 1].Y == points[points.Count - 2].Y))
                                points.RemoveAt(points.Count - 1);
                            this.segments.RemoveAt(i + 1);
                        }
                        //the segment to be replaced is deleted
                        this.segments.RemoveAt(i);
                        //new positions are included
                        locations.AddRange(points);
                    }
                    else
                        locations.Add(((ArrowSegment)this.segments[i]).StartPoint);
                }
                //the last point is added
                                locations.Add(((ArrowSegment)this.segments[this.segments.Count - 1]).EndPoint);

                this.CreateArrowSurface(locations);
            }
        }

        public override bool EnableNextConnectors()
        {
            return false;
        }

        public bool EnableModifiers()
        {
            foreach (ArrowSegment segment in this.segments)
                segment.EnableModifiers();
            this.UpdateArrow();
            return true;
        }

        public void DisableModifiers()
        {
            foreach (ArrowSegment segment in this.segments)
                segment.DisableModifiers();
            this.UpdateArrow();
        }

        public ArrowModifier GetModifier(Point location)
        {
            ArrowModifier modifier = null;
            Point relativePoint = new Point(location.X - this.Position.X, location.Y - this.Position.Y);
            foreach (ArrowSegment segment in this.segments)
            {
                modifier = segment.GetModifier(relativePoint);
                if (modifier != null)
                    return modifier;
            }
            return null;
        }

        public ArrowSegment GetSegment(Point location)
        {
            Point relativePoint = new Point(location.X - this.Position.X, location.Y - this.Position.Y);
            foreach (ArrowSegment segment in this.segments)
                if (segment.IntersectsWith(relativePoint))
                    return segment;
            return null;
        }

        public override Connector GetConnector(Point location)
        {
            Point relativePoint = new Point(location.X - this.Position.X, location.Y - this.Position.Y);
            foreach (ArrowSegment segment in this.segments)
            {
                if (segment is StartSegment)
                {
                    if (segment.GetModifier(relativePoint) != null)
                        return this.initConnector;
                }
                else if (segment is EndSegment)
                {
                    if (segment.GetModifier(relativePoint) != null)
                        return this.FinalConnector;
                }
            }
            return null;
        }

        public override GraphElement Clone()
        {
            throw new GraphException("This method can't be called");
        }

        public GraphElement Clone(List<GraphElement> elements, List<GraphElement> clonedElements, Hashtable element_clone)
        {
            //you get the previous element of the arrow
            GraphElement prevElement = (GraphElement)element_clone[this.Previous[0]];
            if (prevElement == null)
            {
                prevElement = this.Previous[0].Clone();
                clonedElements.Add(prevElement);
                element_clone.Add(this.Previous[0], prevElement);
            }
            //you get the next element of the arrow
            GraphElement nextElement = (GraphElement)element_clone[this.Next];
            if (nextElement == null)
            {
                if (this.Next is GraphArrow)
                    nextElement = ((GraphArrow)this.Next).Clone(elements, clonedElements, element_clone);
                else
                    nextElement = this.Next.Clone();
                clonedElements.Add(nextElement);
                element_clone.Add(this.Next, nextElement);
            }

            Connector initConnector = prevElement.GetConnector(this.initConnector.Side);
            Connector finConnector = nextElement.GetConnector(this.next.Side);

            GraphArrow clone = new GraphArrow(initConnector, finConnector, this.segments);

            if (prevElement is GraphConditional)
            {
                if (((GraphConditional)this.initConnector.Parent).NextTrue == this)
                    ((GraphConditional)prevElement).AddNext(initConnector, clone, ConditionalOut.True);
                else
                    ((GraphConditional)prevElement).AddNext(initConnector, clone, ConditionalOut.False);
            }
            else
                prevElement.AddNext(initConnector, clone);
            nextElement.AddPrevious(finConnector, clone);

            return clone;
        }

        public override void SaveInFile(XmlWriter file, int elementId, Hashtable elementsId)
        {
            file.WriteElementString("id", elementId.ToString());
            file.WriteElementString("key", this.key);

            file.WriteStartElement("arrow");
            file.WriteStartElement("position");
            file.WriteElementString("x", this.Center.X.ToString());
            file.WriteElementString("y", this.Center.Y.ToString());
            file.WriteEndElement();
            file.WriteStartElement("previous");
            foreach (Connector connector in this.previous)
            {
                int id;
                if (elementsId.ContainsKey(connector.Parent))
                    id = (int)elementsId[connector.Parent];
                else
                {
                    id = GraphDiagram.GetElementId();
                    elementsId.Add(connector.Parent, id);
                }
                file.WriteElementString("elementId", id.ToString());
                file.WriteElementString("connectorId", connector.IdConnector.ToString());
            }
            file.WriteEndElement();

            file.WriteStartElement("next");
            if (this.Next != null)
            {
                int id;
                if (elementsId.ContainsKey(this.Next))
                    id = (int)elementsId[this.Next];
                else
                {
                    id = GraphDiagram.GetElementId();
                    elementsId.Add(this.Next, id);
                }
                file.WriteElementString("elementId", id.ToString());
                file.WriteElementString("connectorId", this.next.IdConnector.ToString());
            }
            file.WriteEndElement();

            file.WriteStartElement("points");
            foreach (ArrowSegment segment in this.segments)
            {
                file.WriteStartElement("position");
                file.WriteElementString("x", segment.StartPoint.X.ToString());
                file.WriteElementString("y", segment.StartPoint.Y.ToString());
                file.WriteEndElement();
            }
            //the last position is saved
            file.WriteStartElement("position");
            file.WriteElementString("x", ((ArrowSegment)this.segments[this.segments.Count-1]).EndPoint.X.ToString());
            file.WriteElementString("y", ((ArrowSegment)this.segments[this.segments.Count - 1]).EndPoint.Y.ToString());
            file.WriteEndElement();
            file.WriteEndElement();

            file.WriteEndElement();
        }

        public override bool IntersectsWith(Point point)
        {
            if (base.IntersectsWith(point))
            {
                Point relativePoint = new Point(point.X - this.Position.X, point.Y - this.Position.Y);
                foreach (ArrowSegment segment in this.segments)
                    if (segment.IntersectsWith(relativePoint))
                        return true;
            }
            return false;
        }

        public override bool ContainsIn(Rectangle rectangle)
        {
            if ((this.Left >= rectangle.Left) && (this.Right <= rectangle.Right) && (this.Top >= rectangle.Top) && (this.Bottom <= rectangle.Bottom))
                return true;
            return false;
        }

        private void UpdateArrow()
        {
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            foreach (ArrowSegment segment in this.segments)
                this.Surface.Blit(segment);
        }

        public void UpdateArrow(List<Point> locations)
        {
            this.CreateArrowSurface(locations);
        }

        public void UpdateArrow(GridPoint[,] gridPoints)
        {
            this.segments.Clear();
            this.rectangles.Clear();
            List<Point> locations = this.GetPathPoints(gridPoints);
            CreateArrowSurface(locations);
        }

        #endregion

        #region Private methods

        private ConditionalOut GetOutLine(XmlElement conditional, string idNext)
        {
            foreach (XmlElement nodo in conditional)
            {
                switch (nodo.Name)
                {
                    case "conditional":
                        foreach (XmlElement property in nodo.ChildNodes)
                        {
                            switch (property.Name)
                            {
                                case "nextTrue":
                                    if ((property.ChildNodes.Count > 0) && (property.ChildNodes[0].Name == "elementId") && (property.ChildNodes[0].InnerText == idNext))
                                        return ConditionalOut.True;
                                    break;
                                case "nextFalse":
                                    if ((property.ChildNodes.Count > 0) && (property.ChildNodes[0].Name == "elementId") && (property.ChildNodes[0].InnerText == idNext))
                                        return ConditionalOut.False;
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            throw new GraphException("Error");
        }

        private GraphElement GetClone(GraphElement element, List<GraphElement> elements, List<GraphElement> clonedElements, Hashtable element_clone)
        {
            GraphElement cloneElement = (GraphElement)element_clone[element];
            if (cloneElement == null)
            {
                if (element is GraphArrow)
                    cloneElement = ((GraphArrow)element).Clone(elements, clonedElements, element_clone);
                else
                    cloneElement = element.Clone();
                clonedElements.Add(cloneElement);
                element_clone.Add(element, cloneElement);
            }
            return cloneElement;
        }

        private List<Point> GetPathPoints(GridPoint[,] gridPoints)
        {
            List<Point> locations = new List<Point>();
            // you get the arrow path
            List<GridPoint> path = GraphDiagram.GetGridPath(gridPoints, GraphDiagram.GetNearGridPoint(this.initConnector), this.initConnector.Side, GraphDiagram.GetNearGridPoint(this.next));

            locations.Add(this.initConnector.AbsCenter);
            locations.Add(path[0].Location); //one must always be kept so that the beginning and end of the arrow are created
            //If the arrow path has more than one element, it seeks to minimize the sectors
            if (path.Count != 1)
            {
                int presentX = locations[1].X;
                int presentY = locations[1].Y;
                for (int i = 2; i < path.Count; i++)
                    if ((path[i].Location.X != presentX) && (path[i].Location.Y != presentY))
                    {
                        locations.Add(path[i - 1].Location);
                        presentX = path[i - 1].Location.X;
                        presentY = path[i - 1].Location.Y;
                    }
                locations.Add(path[path.Count - 1].Location);
            }
            locations.Add(this.next.AbsCenter);
            return locations;
        }

        private void CreateArrowSurface(List<Point> locations)
        {
            Point minPoint = GraphDiagram.MinPoint(locations);
            Point maxPoint = GraphDiagram.MaxPoint(locations);

            this.Position = new Point(minPoint.X - 5, minPoint.Y - 5);

            this.segments.Clear();
            for (int i = 0; i < locations.Count - 1; i++)
            {
                if (i == 0)
                    this.segments.Add(new StartSegment(this.initConnector, (Point)locations[i], (Point)locations[i + 1], this.Position));
                else if (i < locations.Count - 2)
                    this.segments.Add(new LineSegment((Point)locations[i], (Point)locations[i + 1], (Point)locations[i - 1], this.Position));
                else
                    this.segments.Add(new EndSegment(this.next, (Point)locations[i], (Point)locations[i + 1], (Point)locations[i - 1], this.Position));
            }

            Size size = new Size(maxPoint.X - minPoint.X + 10, maxPoint.Y - minPoint.Y + 10);
            this.Surface = new Surface(size);
            //the color of transparency is indicated
            this.Transparent = true;
            this.TransparentColor = GraphDiagram.TRASPARENT_COLOR;
            this.UpdateSurface();
        }

        private void UpdateSurface()
        {
            //it is painted the transparency color
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            //all the segments of the arrow are drawn
            foreach (Sprite sprite in this.segments)
                this.Surface.Blit(sprite);
        }

        #endregion

    }
}

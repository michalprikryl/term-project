using System.Collections.Generic;
using System.Xml.Serialization;

namespace WebAPI.Models.DataAPI
{
    public class InputXML
    {
        public MxGraphModel Graph { get; set; }
    }

    [XmlRoot(ElementName = "mxCell")]
    public class MxCell
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "parent")]
        public string Parent { get; set; }
        [XmlElement(ElementName = "mxGeometry")]
        public MxGeometry MxGeometry { get; set; }
        [XmlAttribute(AttributeName = "style")]
        public string Style { get; set; }
        [XmlAttribute(AttributeName = "edge")]
        public string Edge { get; set; }
        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
        [XmlAttribute(AttributeName = "target")]
        public string Target { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "vertex")]
        public string Vertex { get; set; }
        [XmlAttribute(AttributeName = "connectable")]
        public string Connectable { get; set; }
    }

    [XmlRoot(ElementName = "mxGeometry")]
    public class MxGeometry
    {
        [XmlAttribute(AttributeName = "relative")]
        public string Relative { get; set; }
        [XmlAttribute(AttributeName = "as")]
        public string As { get; set; }
        [XmlAttribute(AttributeName = "x")]
        public string X { get; set; }
        [XmlAttribute(AttributeName = "y")]
        public string Y { get; set; }
        [XmlAttribute(AttributeName = "width")]
        public string Width { get; set; }
        [XmlAttribute(AttributeName = "height")]
        public string Height { get; set; }
        [XmlElement(ElementName = "mxPoint")]
        public List<MxPoint> MxPoint { get; set; }
        [XmlElement(ElementName = "Array")]
        public Array Array { get; set; }
    }

    [XmlRoot(ElementName = "mxPoint")]
    public class MxPoint
    {
        [XmlAttribute(AttributeName = "x")]
        public string X { get; set; }
        [XmlAttribute(AttributeName = "y")]
        public string Y { get; set; }
        [XmlAttribute(AttributeName = "as")]
        public string As { get; set; }
    }

    [XmlRoot(ElementName = "Array")]
    public class Array
    {
        [XmlElement(ElementName = "mxPoint")]
        public List<MxPoint> MxPoint { get; set; }
        [XmlAttribute(AttributeName = "as")]
        public string As { get; set; }
    }

    [XmlRoot(ElementName = "root")]
    public class Root
    {
        /// <summary>
        /// obsahuje jednotlive nodes
        /// </summary>
        [XmlElement(ElementName = "mxCell")]
        public List<MxCell> MxCells { get; set; }
    }

    [XmlRoot(ElementName = "mxGraphModel")]
    public class MxGraphModel
    {
        [XmlElement(ElementName = "root")]
        public Root Root { get; set; }
        [XmlAttribute(AttributeName = "dx")]
        public string Dx { get; set; }
        [XmlAttribute(AttributeName = "dy")]
        public string Dy { get; set; }
        [XmlAttribute(AttributeName = "grid")]
        public string Grid { get; set; }
        [XmlAttribute(AttributeName = "gridSize")]
        public string GridSize { get; set; }
        [XmlAttribute(AttributeName = "guides")]
        public string Guides { get; set; }
        [XmlAttribute(AttributeName = "tooltips")]
        public string Tooltips { get; set; }
        [XmlAttribute(AttributeName = "connect")]
        public string Connect { get; set; }
        [XmlAttribute(AttributeName = "arrows")]
        public string Arrows { get; set; }
        [XmlAttribute(AttributeName = "fold")]
        public string Fold { get; set; }
        [XmlAttribute(AttributeName = "page")]
        public string Page { get; set; }
        [XmlAttribute(AttributeName = "pageScale")]
        public string PageScale { get; set; }
        [XmlAttribute(AttributeName = "pageWidth")]
        public string PageWidth { get; set; }
        [XmlAttribute(AttributeName = "pageHeight")]
        public string PageHeight { get; set; }
        [XmlAttribute(AttributeName = "background")]
        public string Background { get; set; }
    }
}

using System;
using System.Text.RegularExpressions;

namespace GLibrary.Models.Builders
{
    public class StringUtils
    {
        private const string START = "start";
        private const string END = "end";
        private const string ACTIVITY = "activity";
        private const string FORK = "forkJoin";
        private const string CONDITION = "condition";

        public static ActivityDiagramNodes ParseNodeTypeFromXmlStyle(string style)
        {
            Regex regex = new Regex("type=[a-zA-Z]+");
            Match match = regex.Match(style);

            return XmlStyleToNodeName(match.Groups[0].ToString().Substring(match.Groups[0].ToString().IndexOf("=") + 1));
        }

        public static ActivityDiagramEdge ParseEdgeTypeFromXmlText(string text)
        {
            return XMLTextToEdgeName(text);
        }

        private static ActivityDiagramNodes XmlStyleToNodeName(string xmlStyle)
        {
            if (xmlStyle == START)
            {
                return ActivityDiagramNodes.InitialNode;
            }
            else if (xmlStyle == END)
            {
                return ActivityDiagramNodes.FinalNode;
            }
            else if (xmlStyle == ACTIVITY)
            {
                return ActivityDiagramNodes.ActionNode;
            }
            else if (xmlStyle == FORK)
            {
                return ActivityDiagramNodes.ForkNode;
            }
            else if (xmlStyle == CONDITION)
            {
                return ActivityDiagramNodes.DecisionNode;
            }

            return ActivityDiagramNodes.Empty;
        }

        private static ActivityDiagramEdge XMLTextToEdgeName(string xmlText)
        {
            if (string.IsNullOrEmpty(xmlText))
            {
                return ActivityDiagramEdge.ActivityEdge;
            }
            else if (xmlText[0] == '[' && xmlText[xmlText.Length - 1] == ']')
            {
                return ActivityDiagramEdge.ConditionEdge;
            }
            else if (xmlText == "interrupt")
            {
                return ActivityDiagramEdge.InterruptEdge;
            }
            else
            {
                return ActivityDiagramEdge.NamedActivityEdge;
            }

            //neni potreba
            //return ActivityDiagramEdge.Empty; 
        }

        private static string GetTypeFromStyleProperty(string style)
        {
            return Regex.Match(style, "type=[a-zA-Z]+").Value.Split('=', StringSplitOptions.RemoveEmptyEntries)[1];
        }
    }
}

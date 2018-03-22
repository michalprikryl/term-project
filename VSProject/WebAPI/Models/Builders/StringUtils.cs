using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAPI.Models.Builders
{
    public class StringUtils
    {

        private const String START = "start";
        private const String END = "end";
        private const String ACTIVITY = "activity";
        private const String FORK = "forkJoin";
        private const String CONDITION = "condition";

        public static ActivityDiagramNodes ParseNodeTypeFromXmlStyle(String style)
        {
            Regex regex = new Regex("type=[a-zA-Z]+");
            Match match = regex.Match(style);

            return XmlStyleToNodeName(match.Groups[0].ToString().Substring(match.Groups[0].ToString().IndexOf("=") + 1));
        }

        private static ActivityDiagramNodes XmlStyleToNodeName(String xmlStyle)
        {
            if (xmlStyle == START)
            {
                return ActivityDiagramNodes.InitialNode;
            }
            else if (xmlStyle == END) {
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
            else if (xmlStyle == FORK)
            {
                return ActivityDiagramNodes.DecisionNode;
            }

            return ActivityDiagramNodes.Empty;
        }
    }
}

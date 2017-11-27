// Write your JavaScript code.

function send_to_API() {
    //jQuery.support.cors = true;

    //$.ajax({
    //    url: "http://localhost:62438/api/values/",
    //    method: "post",
    //    contentType: "text/xml;charset=utf-8",
    //    dataType: "xml",
    //   // accept: "text/xml;charset=utf-8",
    //    //data: { "": '<TestXML xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><Text>text</Text><AdditionalData>nejake data</AdditionalData></TestXML>' },
    //    //data: { "": '<?xml version="1.0"?><TestXML xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><Text>nic</Text><AdditionalData>some other data</AdditionalData></TestXML>'},
    //    data: { "": '<TestXML><Text>nic</Text><AdditionalData>some other data</AdditionalData></TestXML>' },
    //    success: function (result) {
    //        $("#result").innerText(result.response);
    //    }
    //});

    //$.ajax({
    //    url: "http://localhost:62438/api/values/",
    //    method: "post",
    //    contentType: "application/json;charset=utf-8",
    //    //dataType: "json",
    //    accept: "application/json;charset=utf-8",
    //    data: { "Text": 'nic', "AdditionalData": 'some other data' },
    //    success: function (result) {
    //        $("#result").innerText(result.response);
    //    }
    //});

    var xml = '<?xml version="1.0" encoding="UTF-8"?> <mxGraphModel dx="1413" dy="591" grid="1" gridSize="10" guides="1" tooltips="1" connect="1" arrows="1" fold="1" page="1" pageScale="1" pageWidth="827" pageHeight="1169" background="#ffffff"> <root> <mxCell id="0" /> <mxCell id="1" parent="0" /> <mxCell id="4" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="2" target="3"> <mxGeometry relative="1" as="geometry" /> </mxCell> <mxCell id="2" value="začátek práce" style="rounded=1;whiteSpace=wrap;html=1;" vertex="1" parent="1"> <mxGeometry x="310" y="80" width="120" height="60" as="geometry" /> </mxCell> <mxCell id="6" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0;entryY=0.5;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="3" target="5"> <mxGeometry relative="1" as="geometry" /> </mxCell> <mxCell id="10" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0;entryY=0.5;jettySize=auto;orthogonalLoop=1;exitX=0;exitY=0.5;" edge="1" parent="1" source="3" target="2"> <mxGeometry relative="1" as="geometry"> <mxPoint x="310" y="230" as="sourcePoint" /> <mxPoint x="246" y="130" as="targetPoint" /> <Array as="points"> <mxPoint x="246" y="250" /> <mxPoint x="246" y="110" /> </Array> </mxGeometry> </mxCell> <mxCell id="3" value="" style="rhombus;whiteSpace=wrap;html=1;" vertex="1" parent="1"> <mxGeometry x="334" y="210" width="80" height="80" as="geometry" /> </mxCell> <mxCell id="9" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0;entryY=0.5;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="5" target="8"> <mxGeometry relative="1" as="geometry" /> </mxCell> <mxCell id="5" value="úspěšné dokončení" style="rounded=1;whiteSpace=wrap;html=1;" vertex="1" parent="1"> <mxGeometry x="520" y="220" width="120" height="60" as="geometry" /> </mxCell> <mxCell id="7" value="[yes]" style="text;html=1;resizable=0;points=[];autosize=1;align=left;verticalAlign=top;spacingTop=-4;fontSize=17;fontStyle=1;fontFamily=Garamond;" vertex="1" parent="1"> <mxGeometry x="440" y="220" width="40" height="20" as="geometry" /> </mxCell> <mxCell id="8" value="" style="ellipse;html=1;shape=endState;fillColor=#000000;strokeColor=#ff0000;" vertex="1" parent="1"> <mxGeometry x="700" y="240" width="30" height="30" as="geometry" /> </mxCell> <mxCell id="11" value="[No]" style="text;html=1;resizable=0;points=[];autosize=1;align=left;verticalAlign=top;spacingTop=-4;" vertex="1" parent="1"> <mxGeometry x="270" y="220" width="40" height="20" as="geometry" /> </mxCell> </root> </mxGraphModel>';

    var dataXML = {
        Data: xml,
        DataFormat: 'json'
    };

    $.ajax({
        type: 'POST',
        url: "http://localhost:60000/api/values/",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(dataXML),
        success: function (result) {
            if (result !== null) {
                document.getElementById("result").innerHTML = JSON.stringify(result);
            } else {
                document.getElementById("result").innerHTML = "NULL";
            }
        }
    });
}

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

    //var xml = '<?xml version="1.0" encoding="UTF-8"?> <mxGraphModel dx="1413" dy="591" grid="1" gridSize="10" guides="1" tooltips="1" connect="1" arrows="1" fold="1" page="1" pageScale="1" pageWidth="827" pageHeight="1169" background="#ffffff"> <root> <mxCell id="0" /> <mxCell id="1" parent="0" /> <mxCell id="4" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="2" target="3"> <mxGeometry relative="1" as="geometry" /> </mxCell> <mxCell id="2" value="začátek práce" style="rounded=1;whiteSpace=wrap;html=1;" vertex="1" parent="1"> <mxGeometry x="310" y="80" width="120" height="60" as="geometry" /> </mxCell> <mxCell id="6" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0;entryY=0.5;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="3" target="5"> <mxGeometry relative="1" as="geometry" /> </mxCell> <mxCell id="10" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0;entryY=0.5;jettySize=auto;orthogonalLoop=1;exitX=0;exitY=0.5;" edge="1" parent="1" source="3" target="2"> <mxGeometry relative="1" as="geometry"> <mxPoint x="310" y="230" as="sourcePoint" /> <mxPoint x="246" y="130" as="targetPoint" /> <Array as="points"> <mxPoint x="246" y="250" /> <mxPoint x="246" y="110" /> </Array> </mxGeometry> </mxCell> <mxCell id="3" value="" style="rhombus;whiteSpace=wrap;html=1;" vertex="1" parent="1"> <mxGeometry x="334" y="210" width="80" height="80" as="geometry" /> </mxCell> <mxCell id="9" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0;entryY=0.5;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="5" target="8"> <mxGeometry relative="1" as="geometry" /> </mxCell> <mxCell id="5" value="úspěšné dokončení" style="rounded=1;whiteSpace=wrap;html=1;" vertex="1" parent="1"> <mxGeometry x="520" y="220" width="120" height="60" as="geometry" /> </mxCell> <mxCell id="7" value="[yes]" style="text;html=1;resizable=0;points=[];autosize=1;align=left;verticalAlign=top;spacingTop=-4;fontSize=17;fontStyle=1;fontFamily=Garamond;" vertex="1" parent="1"> <mxGeometry x="440" y="220" width="40" height="20" as="geometry" /> </mxCell> <mxCell id="8" value="" style="ellipse;html=1;shape=endState;fillColor=#000000;strokeColor=#ff0000;" vertex="1" parent="1"> <mxGeometry x="700" y="240" width="30" height="30" as="geometry" /> </mxCell> <mxCell id="11" value="[No]" style="text;html=1;resizable=0;points=[];autosize=1;align=left;verticalAlign=top;spacingTop=-4;" vertex="1" parent="1"> <mxGeometry x="270" y="220" width="40" height="20" as="geometry" /> </mxCell> </root> </mxGraphModel>';

    var xml = '<mxGraphModel dx="1426" dy="839" grid="1" gridSize="10" guides="1" tooltips="1" connect="1" arrows="1" fold="1" page="1" pageScale="1" pageWidth="827" pageHeight="1169" background="#ffffff"> <root> <mxCell id="0"/> <mxCell id="1" parent="0"/> <mxCell id="8" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="2" target="3"> <mxGeometry relative="1" as="geometry"/> </mxCell> <mxCell id="2" value="" style="type=start;ellipse;html=1;shape=startState;fillColor=#000000;strokeColor=#000000;" vertex="1" parent="1"> <mxGeometry x="180" y="120" width="30" height="30" as="geometry"/> </mxCell> <mxCell id="9" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="3" target="4"> <mxGeometry relative="1" as="geometry"/> </mxCell> <mxCell id="3" value="Activity" style="type=activity;rounded=1;whiteSpace=wrap;html=1;arcSize=40;fillColor=#ccffff;strokeColor=#000000;" vertex="1" parent="1"> <mxGeometry x="140" y="190" width="120" height="40" as="geometry"/> </mxCell> <mxCell id="10" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="4" target="7"> <mxGeometry relative="1" as="geometry"/> </mxCell> <mxCell id="11" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0.5;entryY=0;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="4" target="6"> <mxGeometry relative="1" as="geometry"/> </mxCell> <mxCell id="4" value="" style="type=condition;rhombus;whiteSpace=wrap;html=1;fillColor=#ccffff;strokeColor=#000000;" vertex="1" parent="1"> <mxGeometry x="155" y="290" width="80" height="40" as="geometry"/> </mxCell> <mxCell id="5" value="" style="type=end;ellipse;html=1;shape=endState;fillColor=#000000;strokeColor=#000000;" vertex="1" parent="1"> <mxGeometry x="325" y="510" width="30" height="30" as="geometry"/> </mxCell> <mxCell id="14" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0.25;entryY=0.5;entryPerimeter=0;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="6" target="12"> <mxGeometry relative="1" as="geometry"/> </mxCell> <mxCell id="6" value="Activity" style="type=activity;rounded=1;whiteSpace=wrap;html=1;arcSize=40;fillColor=#ccffff;strokeColor=#000000;" vertex="1" parent="1"> <mxGeometry x="135" y="370" width="120" height="40" as="geometry"/> </mxCell> <mxCell id="15" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0.75;entryY=0.5;entryPerimeter=0;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="7" target="12"> <mxGeometry relative="1" as="geometry"/> </mxCell> <mxCell id="7" value="Activity" style="type=activity;rounded=1;whiteSpace=wrap;html=1;arcSize=40;fillColor=#ccffff;strokeColor=#000000;" vertex="1" parent="1"> <mxGeometry x="340" y="300" width="120" height="40" as="geometry"/> </mxCell> <mxCell id="16" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0.5;entryY=0;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="12" target="5"> <mxGeometry relative="1" as="geometry"/> </mxCell> <mxCell id="12" value="" style="type=forkJoin;shape=line;html=1;strokeWidth=6;strokeColor=#000000;" vertex="1" parent="1"> <mxGeometry x="280" y="440" width="150" height="10" as="geometry"/> </mxCell> </root> </mxGraphModel>';

    var dataXML = {
        Data: xml,
        DataFormat: 'xml'
    };

    $.ajax({
        type: 'POST',
        url: "http://localhost:60000/api/upload/",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(dataXML),
        success: function (result) {
            if (result !== null) {
                document.getElementById("result").innerHTML = JSON.stringify(result);

                console.log(result.data);
            } else {
                document.getElementById("result").innerHTML = "NULL";
            }
        }
    });
}


function add_pattern() {
    var pattern = {
        Text: 'some pattern',
        Name: 'pat',
        JSON: '{"menu": { "id": "file", "value": "File", "popup": { "menuitem": [ {"value": "New", "onclick": "CreateNewDoc()"}, {"value": "Open", "onclick": "OpenDoc()"}, {"value": "Close", "onclick": "CloseDoc()"} ] } }}'
    };

    $.ajax({
        type: 'POST',
        url: "http://localhost:60000/api/pattern/",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(pattern),
        success: function (result) {
            if (result !== null) {
                document.getElementById("result").innerHTML = JSON.stringify(result);

                console.log(result.data);
            } else {
                document.getElementById("result").innerHTML = "NULL";
            }
        }
    });
}

function get_patterns() {
    $.get("http://localhost:60000/api/pattern/", function (data, status) {
        document.getElementById("result").innerHTML = JSON.stringify(data);
    });
}

function get_first_pattern() {
    $.get("http://localhost:60000/api/pattern/11", function (data, status) {
        document.getElementById("result").innerHTML = JSON.stringify(data);
    });
}

function drop_pattern() {
    $.ajax({
        type: 'DELETE',
        url: "http://localhost:60000/api/pattern/3",
        success: function (result) {
            if (result !== null) {
                document.getElementById("result").innerHTML = JSON.stringify(result);

                console.log(result.data);
            } else {
                document.getElementById("result").innerHTML = "NULL";
            }
        }
    });
}

function update_pattern() {
    var pattern = {
        Text: 'some pattern update',
        Name: 'pat update'
    };

    $.ajax({
        type: 'PUT',
        url: "http://localhost:60000/api/pattern/1",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(pattern),
        success: function (result) {
            if (result !== null) {
                document.getElementById("result").innerHTML = JSON.stringify(result);

                console.log(result.data);
            } else {
                document.getElementById("result").innerHTML = "NULL";
            }
        }
    });
}

function get_pattern_types() {
    $.get("http://localhost:60000/api/patterntype/", function (data, status) {
        document.getElementById("result").innerHTML = JSON.stringify(data);
    });
}

function get_first_pattern_type() {
    $.get("http://localhost:60000/api/patterntype/1", function (data, status) {
        document.getElementById("result").innerHTML = JSON.stringify(data);
    });
}

function check_diagram_proper() {
    var xml = '<mxGraphModel dx="1426" dy="839" grid="1" gridSize="10" guides="1" tooltips="1" connect="1" arrows="1" fold="1" page="1" pageScale="1" pageWidth="827" pageHeight="1169" background="#ffffff"> <root> <mxCell id="0"/> <mxCell id="1" parent="0"/> <mxCell id="8" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="2" target="3"> <mxGeometry relative="1" as="geometry"/> </mxCell> <mxCell id="2" value="" style="type=start;ellipse;html=1;shape=startState;fillColor=#000000;strokeColor=#000000;" vertex="1" parent="1"> <mxGeometry x="180" y="120" width="30" height="30" as="geometry"/> </mxCell> <mxCell id="9" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="3" target="4"> <mxGeometry relative="1" as="geometry"/> </mxCell> <mxCell id="3" value="Activity" style="type=activity;rounded=1;whiteSpace=wrap;html=1;arcSize=40;fillColor=#ccffff;strokeColor=#000000;" vertex="1" parent="1"> <mxGeometry x="140" y="190" width="120" height="40" as="geometry"/> </mxCell> <mxCell id="10" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="4" target="7"> <mxGeometry relative="1" as="geometry"/> </mxCell> <mxCell id="11" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0.5;entryY=0;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="4" target="6"> <mxGeometry relative="1" as="geometry"/> </mxCell> <mxCell id="4" value="" style="type=condition;rhombus;whiteSpace=wrap;html=1;fillColor=#ccffff;strokeColor=#000000;" vertex="1" parent="1"> <mxGeometry x="155" y="290" width="80" height="40" as="geometry"/> </mxCell> <mxCell id="5" value="" style="type=end;ellipse;html=1;shape=endState;fillColor=#000000;strokeColor=#000000;" vertex="1" parent="1"> <mxGeometry x="325" y="510" width="30" height="30" as="geometry"/> </mxCell> <mxCell id="14" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0.25;entryY=0.5;entryPerimeter=0;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="6" target="12"> <mxGeometry relative="1" as="geometry"/> </mxCell> <mxCell id="6" value="Activity" style="type=activity;rounded=1;whiteSpace=wrap;html=1;arcSize=40;fillColor=#ccffff;strokeColor=#000000;" vertex="1" parent="1"> <mxGeometry x="135" y="370" width="120" height="40" as="geometry"/> </mxCell> <mxCell id="15" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0.75;entryY=0.5;entryPerimeter=0;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="7" target="12"> <mxGeometry relative="1" as="geometry"/> </mxCell> <mxCell id="7" value="Activity" style="type=activity;rounded=1;whiteSpace=wrap;html=1;arcSize=40;fillColor=#ccffff;strokeColor=#000000;" vertex="1" parent="1"> <mxGeometry x="340" y="300" width="120" height="40" as="geometry"/> </mxCell> <mxCell id="16" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0.5;entryY=0;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="12" target="5"> <mxGeometry relative="1" as="geometry"/> </mxCell> <mxCell id="12" value="" style="type=forkJoin;shape=line;html=1;strokeWidth=6;strokeColor=#000000;" vertex="1" parent="1"> <mxGeometry x="280" y="440" width="150" height="10" as="geometry"/> </mxCell> </root> </mxGraphModel>';
    check_diagram(xml);
}

function check_diagram_bad() {
    var xml = '<?xml version="1.0" encoding="UTF-8"?> <mxGraphModel dx="1413" dy="591" grid="1" gridSize="10" guides="1" tooltips="1" connect="1" arrows="1" fold="1" page="1" pageScale="1" pageWidth="827" pageHeight="1169" background="#ffffff"> <root> <mxCell id="0" /> <mxCell id="1" parent="0" /> <mxCell id="4" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="2" target="3"> <mxGeometry relative="1" as="geometry" /> </mxCell> <mxCell id="2" value="začátek práce" style="rounded=1;whiteSpace=wrap;html=1;" vertex="1" parent="1"> <mxGeometry x="310" y="80" width="120" height="60" as="geometry" /> </mxCell> <mxCell id="6" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0;entryY=0.5;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="3" target="5"> <mxGeometry relative="1" as="geometry" /> </mxCell> <mxCell id="10" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0;entryY=0.5;jettySize=auto;orthogonalLoop=1;exitX=0;exitY=0.5;" edge="1" parent="1" source="3" target="2"> <mxGeometry relative="1" as="geometry"> <mxPoint x="310" y="230" as="sourcePoint" /> <mxPoint x="246" y="130" as="targetPoint" /> <Array as="points"> <mxPoint x="246" y="250" /> <mxPoint x="246" y="110" /> </Array> </mxGeometry> </mxCell> <mxCell id="3" value="" style="rhombus;whiteSpace=wrap;html=1;" vertex="1" parent="1"> <mxGeometry x="334" y="210" width="80" height="80" as="geometry" /> </mxCell> <mxCell id="9" style="edgeStyle=orthogonalEdgeStyle;rounded=0;html=1;entryX=0;entryY=0.5;jettySize=auto;orthogonalLoop=1;" edge="1" parent="1" source="5" target="8"> <mxGeometry relative="1" as="geometry" /> </mxCell> <mxCell id="5" value="úspěšné dokončení" style="rounded=1;whiteSpace=wrap;html=1;" vertex="1" parent="1"> <mxGeometry x="520" y="220" width="120" height="60" as="geometry" /> </mxCell> <mxCell id="7" value="[yes]" style="text;html=1;resizable=0;points=[];autosize=1;align=left;verticalAlign=top;spacingTop=-4;fontSize=17;fontStyle=1;fontFamily=Garamond;" vertex="1" parent="1"> <mxGeometry x="440" y="220" width="40" height="20" as="geometry" /> </mxCell> <mxCell id="8" value="" style="ellipse;html=1;shape=endState;fillColor=#000000;strokeColor=#ff0000;" vertex="1" parent="1"> <mxGeometry x="700" y="240" width="30" height="30" as="geometry" /> </mxCell> <mxCell id="11" value="[No]" style="text;html=1;resizable=0;points=[];autosize=1;align=left;verticalAlign=top;spacingTop=-4;" vertex="1" parent="1"> <mxGeometry x="270" y="220" width="40" height="20" as="geometry" /> </mxCell> </root> </mxGraphModel>';
    check_diagram(xml);
}

function check_diagram(xml) {
    var dataXML = {
        Data: xml,
        DataFormat: 'xml'
    };

    $.ajax({
        type: 'POST',
        url: "http://localhost:60000/api/check/",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(dataXML),
        success: function (result) {
            if (result !== null) {
                document.getElementById("result").innerHTML = JSON.stringify(result);

                console.log(result.data);
            } else {
                document.getElementById("result").innerHTML = "NULL";
            }
        }
    });
}
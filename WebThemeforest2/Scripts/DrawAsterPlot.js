var myDataset = [{ "day": "1", "hour": "1", "value": "16" }];
var value_range = [];
var value_count = [];
var data_range = [];
var buckets = 9;
var colors_ori = ["#ffffd9", "#edf8b1", "#c7e9b4", "#7fcdbb", "#41b6c4", "#1d91c0", "#225ea8", "#253494", "#081d58"];
var colors = ['#ffffcc', '#ffeda0', '#fed976', '#feb24c', '#fd8d3c', '#fc4e2a', '#e31a1c', '#bd0026', '#800026'];
var maximumValue = 0.0;


function getSelectedArea(s) {
    var cookieName = "nimoSelectedArea";
    var retval = "014";
    //var sel = document.cookie;
    if (s.indexOf(";") > 0) {
        //split string
        var re = /\s*;\s*/;
        var nameList = s.split(re);
        var length = nameList.length;
        for (var i = 0; i < length; i++) {
            if (nameList[i].indexOf(cookieName) != -1) {
                retval = getSelectedArea(nameList[i]);
                break;
            }
        }
    }
    else {
        if (s.indexOf(cookieName) != -1) {
            var re = /\s*=\s*/;
            var nameList = s.split(re);
            if (nameList.length == 2) {
                retval = nameList[1];
            }
        }
    }
    return retval;
}

function getSelectedDate(s) {
    var cookieName = "nimoSelectedDate";
    var retval = "";
    //var sel = document.cookie;
    if (s.indexOf(";") > 0) {
        //split string
        var re = /\s*;\s*/;
        var nameList = s.split(re);
        var length = nameList.length;
        for (var i = 0; i < length; i++) {
            if (nameList[i].indexOf(cookieName) != -1) {
                retval = getSelectedDate(nameList[i]);
                break;
            }
        }
    }
    else {
        if (s.indexOf(cookieName) != -1) {
            var re = /\s*=\s*/;
            var nameList = s.split(re);
            if (nameList.length == 2) {
                retval = nameList[1];
            }
        }
    }
    return retval;
}

var setRangeValue = function () {
    var minValue = d3.min(myDataset, function (d) { return d.value; });
    var maxValue = d3.max(myDataset, function (d) { return d.value; });
    var range = maxValue - minValue;
    var range_width = range / buckets;
    for (var i = 0; i < buckets; i++) {
        value_range.push(minValue + i * range_width);
    }

}

var setRangeCount = function () {
    var length = myDataset.length;
    maximumValue = 0;

    for (var i = 1; i < buckets; i++) {
        var count = 0;
        for (var j = 0; j < length; j++) {
            var myValue = myDataset[j].value;
            if (myValue >= value_range[i - 1] && myValue < value_range[i])
                count = count + 1;
        }
        value_count.push(count);
    }
    //last
    var count = 0;
    for (var j = 0; j < length; j++) {
        var myValue = myDataset[j].value;
        if (myValue >= value_range[buckets - 1])
            count = count + 1;
    }
    value_count.push(count);

    //generate list
    for (var i = 0; i < buckets; i++) {
        var val = { id: i + 1, order: i + 1, score: value_count[i], weight: 1, color: colors[i], label: ">=" + Math.round(value_range[i]).toString() };
        data_range.push(val);
        if (val.score > maximumValue) {
            maximumValue = val.score;
        }

    }

}

function getAverage() {
    var length = myDataset.length;
    var score = 0.0;
    for (var i = 0; i < length; i++) {
        score = score + myDataset[i].value;
    }
    score = score / length;
    return Math.round(score);
}

function getColor(n) {
    var length = value_range.length;
    var myColor = "";
    for (var i = 0; i < length; i++) {
        if (n > value_range[length - i - 1]) {
            myColor = colors[length - i - 1];
            break;
        }
    }
    if (myColor == "") {
        myColor = colors[0];
    }
    return myColor;
}

var width = 200,
   height = 200,
   radius = Math.min(width, height) / 2,
   innerRadius = 0.3 * radius;

var data = [
        { "id": "FIS", "order": "1.1", "score": "59", "weight": "1", "color": "#9E0041", "label": "Fisheries" },
        { "id": "MAR", "order": "1.3", "score": "24", "weight": "1", "color": "#C32F4B", "label": "Mariculture" },
        { "id": "AO", "order": "2", "score": "98", "weight": "1", "color": "#E1514B", "label": "Artisanal Fishing Opportunities" },
        { "id": "NP", "order": "3", "score": "60", "weight": "1", "color": "#F47245", "label": "Natural Products" },
        { "id": "CS", "order": "4", "score": "74", "weight": "1", "color": "#FB9F59", "label": "Carbon Storage" },
        { "id": "CP", "order": "5", "score": "70", "weight": "1", "color": "#FEC574", "label": "Coastal Protection" },
        { "id": "TR", "order": "6", "score": "42", "weight": "1", "color": "#FAE38C", "label": "Tourism &  Recreation" },
        { "id": "LIV", "order": "7.1", "score": "77", "weight": "1", "color": "#EAF195", "label": "Livelihoods" },
        { "id": "SPP", "order": "10.3", "score": "83", "weight": "1", "color": "#5E4EA1", "label": "Species" }
];

///////////////////////////////////////////////////////////////////////////////////////////////

var myTip;

function chartMouseOver(d, i) {
    debugger;
    var coba = "test";
    myTip.show;
    //if (bool == false) {
    //    d3.select("h2").text(d.properties.KABKOT);
    //    d3.select(this).attr("class", "features");
    //    d3.select(this).style("fill", "#008080");
    //}           
    //else {
    //    d3.select(this).attr("class", "features");
    //    d3.select(this).style("fill", "#008080");
    //}
}

//alert("debug aster 1");

var selectedArea = getSelectedArea(document.cookie);
var selectedDate = getSelectedDate(document.cookie);
var dataPost = { "DATE_STAMP_STRING": selectedDate, "AREA": selectedArea, "PARAM_ID": 1 };

$.ajax({
    type: "POST",
    //type: "GET",
    url: url_api,
    contentType: "application/json",
    dataType: "json",
    data: JSON.stringify(dataPost),
    crossOrigin: false,
    success: function (dataset) {
        myDataset = dataset.Items;
        setRangeValue();
        setRangeCount();

        var pie = d3.layout.pie()
                    .sort(null)
                    .value(function (d) {
                        return d.width;
                    });

        myTip = d3.tip()
        .attr('class', 'd3-tip')
        .offset([0, 0])
        .html(function (d) {
            return d.data.label + ": " + d.data.score.toFixed(2) + "";
        });

        var arc = d3.svg.arc()
        .innerRadius(innerRadius)
        .outerRadius(function (d) {
            return (radius - innerRadius) * (d.data.score / 100.0) + innerRadius;
        });

        var outlineArc = d3.svg.arc()
        .innerRadius(innerRadius)
        .outerRadius(radius);

        var svg = d3.select("#AsterPlot").append("svg")
        .attr("width", width)
        .attr("height", height)
        .append("g")
        .attr("transform", "translate(" + width / 2 + "," + height / 2 + ")");

        svg.call(myTip);

        //data_range = data;

        //debugger;

        data_range.forEach(function (d) {
            d.id = d.id;
            d.order = +d.order;
            d.color = d.color;
            d.weight = +d.weight;
            d.score = d.score / maximumValue * (radius - innerRadius) * 1.1;
            d.width = +d.weight;
            d.label = d.label;
        });
        // for (var i = 0; i < data.score; i++) { console.log(data[i].id) }

        var path = svg.selectAll(".solidArc")
        .data(pie(data_range))
        .enter().append("path")
        .attr("fill", function (d) {
            return d.data.color;
        })
        .attr("class", "solidArc")
        .attr("stroke", "gray")
        .attr("d", arc)
        .on('mouseover', myTip.show)
        .on('mouseout', myTip.hide);

        //debugger;

        var outerPath = svg.selectAll(".outlineArc")
        .data(pie(data_range))
        .enter().append("path")
        .attr("fill", "none")
        .attr("stroke", "gray")
        .attr("class", "outlineArc")
        .attr("d", outlineArc);


        // calculate the weighted mean score
        var score = getAverage();

        svg.append("svg:text")
        .attr("class", "aster-score")
        .attr("dy", ".35em")
        .attr("text-anchor", "middle") // text-align: right
        .text(Math.round(score));

    }
});


///////////////////////////////////////////////////////////////////////////////////////////////



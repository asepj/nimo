

function HeatAndBar(data) {
    var myDataset = [{ "day": "1", "hour": "1", "value": "16" }];

    var myDatasetDay = [];
    var daySelected = 0;
    var hourSelected = 0;
    var chart;

    var margin = { top: 25, right: 0, bottom: 0, left: 30 },
        width = 650 - margin.left - margin.right, //700 & 275
        height = 375 - margin.top - margin.bottom,
        gridSize = Math.floor(width / 25),
        legendElementWidth = gridSize * 2,
        buckets = 9,

        colors = ['#ffffe5', '#fff7bc', '#fee391', '#fec44f', '#fe9929', '#ec7014', '#cc4c02', '#993404', '#662506'], // alternatively colorbrewer.YlGnBu[9]
        colors_ori = ["#ffffd9", "#edf8b1", "#c7e9b4", "#7fcdbb", "#41b6c4", "#1d91c0", "#225ea8", "#253494", "#081d58"], // alternatively colorbrewer.YlGnBu[9]
        value_range = [],
        value_range_1000 = [],
        defaultdays = [],
        days = ["Mo", "Tu", "We", "Th", "Fr", "Sa", "Su"],
        times = ["12a", "1a", "2a", "3a", "4a", "5a", "6a", "7a", "8a", "9a", "10a", "11a", "12p", "1p", "2p", "3p", "4p", "5p", "6p", "7p", "8p", "9p", "10p", "11p"];
    datasets = ["data.tsv", "data2.tsv"];

    //for (var z = 0 ; z < defaultdays.length ; z++) {
    //    if (dateday == defaultdays.indexOf(defaultdays[z])) {
    //        days.push(defaultdays[z]);
    //    }
    //}

    //for (var t = 1 ; t < (defaultdays.length) ; t++) {
    //    var x = (dateday + t) % 7;
    //    days.push(defaultdays[x]);

    //}

    var svg = d3.select("#heatMapChart1")
        .attr("preserveAspectRatio", "xMinYMin meet")
        .attr("viewBox", "0 0 600 400")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
        .append("g")
        .attr("transform", "translate(" + margin.left + "," + margin.top + ")");



    var dayLabels = svg.selectAll(".dayLabel")
        .data(days)
        .enter().append("text")
          .text(function (d) { return d; })
          .attr("x", 0)
          .attr("y", function (d, i) { return i * gridSize; })
          .style("text-anchor", "end")
          .attr("transform", "translate(-6," + gridSize / 1.5 + ")")
          .attr("class", function (d, i) { return ((i >= 0 && i <= 4) ? "dayLabel mono axis axis-workweek" : "dayLabel mono axis"); });





    var timeLabels = svg.selectAll(".timeLabel")
        .data(times)
        .enter().append("text")
          .text(function (d) { return d; })
          .attr("x", function (d, i) { return i * gridSize; })
          .attr("y", 0)
          .style("text-anchor", "middle")
          .attr("transform", "translate(" + gridSize / 2 + ", -6)")
          .attr("class", function (d, i) { return ((i >= 7 && i <= 16) ? "timeLabel mono axis axis-worktime" : "timeLabel mono axis"); });

    var setRangeValue = function () {
        var minValue = d3.min(myDataset, function (d) { return d.value; });
        var maxValue = d3.max(myDataset, function (d) { return d.value; });
        var range = maxValue - minValue;
        var range_width = range / buckets;
        for (var i = 0; i < buckets; i++) {
            value_range.push(minValue + i * range_width);
            value_range_1000.push(minValue / 1000.0 + i * range_width / 1000.0);
        }

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

    var heatmapChart2 = function (tsvFile) {


        var data = myDataset;

        setRangeValue();
        var minValue = d3.min(data, function (d) { return d.value; });
        var maxValue = d3.max(data, function (d) { return d.value; });

        var colorScale = d3.scale.quantile()
        .domain([minValue, buckets - 1, maxValue])
        .range(colors);

        var cards = svg.selectAll(".hour")
            .data(data, function (d) { return d.day + ':' + d.hour; });

        cards.append("title");

        cards.enter().append("rect")
            .attr("x", function (d) { return (d.hour - 1) * gridSize; })
            .attr("y", function (d) { return (d.day - 1) * gridSize; })
            .attr("rx", 4)
            .attr("ry", 4)
            .attr("class", "hour bordered")
            .attr("width", gridSize - 1)
            .attr("height", gridSize - 1)
            .style("fill", function (d) { return getColor(d.value); })
            .on("click", function (d) {
                //  alert("value = " + d.value.toString())

                // alert(d.day+" "+(d.hour-1)+" ");
                var hourArea = d.hour - 1;
                var idArea = $("#noKota").text();
                // var modal = document.getElementById('myModal1');
                var dayArea = d.day;
                var datapost = {};
                var day_hour = "(day " + dayArea + ", hour " + hourArea + ")";
                $('#day-hour').text(day_hour);


                var SelectedDate = $("#dashboard-report-range span").html();

                var fields = SelectedDate.split('-'); //split start date and end date
                // alert(fields[0]+" "+fields[1]);
                //change format date//
                var FirstDateStart = moment(fields[0], "MMMM D, YYYY").format("YYYY-MM-DD");
                var FirstDateEnd = moment(fields[1], "MMMM D, YYYY").format("YYYY-MM-DD");
				debugger ;

                // alert(FirstDateStart+" "+FirstDateEnd);

                datapost.ID_UNIT_USAHA = idArea;
                datapost.FHOUR = hourArea;
                datapost.daynumber = dayArea;
                datapost.start_date = FirstDateStart;
                datapost.end_date = FirstDateEnd;



                GetTableDemandHourly(datapost,day_hour);
                // modal.style.display = "block";

                 // $('#myModal1').modal('show');

                // $('#show_data_demand').show();
            //     setTimeout(function () {
            //         $('#show_data_demand').hide();

            // $("#title").html("<h5 style='background-color:#0099ff;width:100%;height:30%;color:white;'><i class='fa fa-globe'></i>Heatmap utilization Table" + day_hour + "</h5>");

            //     }, 12000);
            })
            .on("mouseover", function (d) {

                var labelbarchart;
                d3.select(this).style("stroke", "red");

                hourSelected = d3.select(this).attr("x") / gridSize + 1;
                daySelected = d3.select(this).attr("y") / gridSize + 1;

                //document.getElementById("labelselected2").innerHTML = "Hourly Utilization Profile";
                document.getElementById("labelselected").innerHTML = "Day : " + days[daySelected - 1] + " /" + " Hour : " + times[hourSelected - 1];

                document.getElementById("labelheat").innerHTML = " <span id='titlebar'><strong> value = " + d.value.toFixed(2) + " MMSCFD</strong> </span>";


                updateBarChart();
            })
            .on("mouseout", function (d) {
                d3.select(this).style("stroke", "#E6E6E6");
            });

        cards.select("title").text(function (d) { return d.value; });

        cards.exit().remove();

        var legend = svg.selectAll(".legend")
             .data(value_range_1000, function (d) { return d; });

        legend.enter().append("g")
            .attr("class", "legend");

        legend.append("rect")
          .attr("x", function (d, i) { return legendElementWidth * i; })
          .attr("y", (7.5) * gridSize)
          .attr("width", legendElementWidth)
          .attr("height", gridSize / 2)
          .style("fill", function (d, i) { return colors[i]; });

        legend.append("text")
          .attr("class", "mono")
          .text(function (d, i) { return "≥ " + Math.round(value_range[i]); })
          .attr("x", function (d, i) { return legendElementWidth * i; })
          .attr("y", 8.5 * gridSize);

        legend.exit().remove();

    };

    function getDay(n) {
        var length = myDataset.length;
        var myData = [];
        for (var i = 0; i < length; i++) {
            if (myDataset[i].day == n) {
                myData.push(myDataset[i].value);
            }
        }
        return myData;
    }

    var populateDaily = function () {

        daySelected = 0;

        var minDay = d3.min(myDataset, function (d) { return d.day; });
        var maxDay = d3.max(myDataset, function (d) { return d.day; });
        myDatasetDay = [];
        for (i = minDay; i <= maxDay; i++) {
            var item = getDay(i);
            myDatasetDay.push(item);
        }

    }
    var barChart = function () {
        if (myDatasetDay != "") {

            var move = [];
            var myData = myDatasetDay[daySelected];
            var times2 = ["00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"];
            for (var i = 0; i < myData.length; i++) {
                var val = { id: times2[i], score: myData[i] };
                move.push(val);
            }


            //var width = 530 - margin.left - margin.right,
            //height = 280 - margin.top - margin.bottom;

            var margin = { top: 20, right: 20, bottom: 70, left: 15 },
            width = 320 - margin.left - margin.right,
            height = 250 - margin.top - margin.bottom;

            var x = d3.scale.ordinal().rangeRoundBands([0, width], .05);

            var y = d3.scale.linear().range([height, 0]);

            var xAxis = d3.svg.axis()
            .scale(x)
            .orient("bottom")
            //.tickFormat(d3.time.format("%Y-%m"));

            var yAxis = d3.svg.axis()
                .scale(y)
                .orient("left")

            var svg = d3.select("#heatMapBarChart2").append("svg")
                .attr("id", "heatjoinbar")
                .attr("style", "margin-bottom:-270px;")
                .attr("width", width + margin.left + margin.right)
                .attr("height", height + margin.top + margin.bottom)
                .append("g")
                .attr("transform",
                      "translate(" + margin.left + "," + margin.top + ")");

            move.forEach(function (d) {
                d.id = d.id;
                d.score = +d.score;

            });

            x.domain(move.map(function (d) { return d.id; }));
            y.domain([0, d3.max(move, function (d) { return d.score; })]);

            svg.append("g")
                .attr("class", "x axis")
                .attr("transform", "translate(0," + height + ")")
                //.call(xAxis)
              .selectAll("text")
                .style("text-anchor", "end")
                .attr("dx", "-.8em")
                .attr("dy", "-.55em")
                .attr("transform", "rotate(-90)");

            svg.append("g")
                .attr("class", "y axis")
                //.call(yAxis)
              .append("text")
                .attr("transform", "rotate(-90)")
                .attr("y", 6)
                .attr("dy", ".71em")
                .style("text-anchor", "end")
                .text("");

            svg.selectAll("bar")
                .data(move)
                .enter().append("rect")
                 .attr("class", "bar")
                .style("fill", "teal")
                .attr("x", function (d) { return x(d.id); })
                .attr("width", x.rangeBand())
                .attr("y", function (d) { return y(d.score); })
                .attr("id", function (d, i) { return "h" + i.toString() })
                .attr("height", function (d) { return height - y(d.score); });


        }


    }


    function scaleBetween(unscaledNum, minAllowed, maxAllowed, min, max) {
        return (maxAllowed - minAllowed) * (unscaledNum - min) / (max - min) + minAllowed;
    }


    var updateBarChart = function () {

        $('#heatMapBarChart2').show();
        var myData = myDatasetDay[daySelected - 1];
        var data = myDataset;
        var panjang = myData.length;
        //var maxData = Math.max(...myData);
        //var minData = Math.min(...myData);

        //var maxData = Math.max.apply(Math,myData);
        var minValue = d3.min(data, function (d) { return d.value; });
        var maxValue = d3.max(data, function (d) { return d.value; });
        // var minData = Math.min.apply(Math,myData);
        //alert(maxData +" batas "+maxValue);


        //var yScale = d3.scale.linear()
        //.domain([0, d3.max(myData)])
        //.range([h, 0]);


        //translate(200,0) translate(-100, -100) rotate(45, 100, 100)
        for (var i = 0; i < panjang; i++) {
            var myID = "#h" + i.toString();
            //var myVal = "height: " + Math.floor(myData[i] * 2).toString() + "px" + ";"; // default by me

            //var myVal = "height: " + Math.floor(maxData / (myData[i].toFixed(1) / (myData[i].toFixed(1) / (16 / 9)))).toString() + "%" + ";";
            var myValunscale = myData[i];
            myValunscale = myValunscale.toFixed(1);
            var scaled = scaleBetween(myValunscale, 50, 125, minValue, maxValue);
            //alert(scaled);
            //scaled = scaled.ToFixed(1);
            var myValscale = "height: " + scaled.toString() + "px" + ";";
            $(myID).attr({
                //"height":"",
                "y": 0,
                //"transform": "rotate(180, 100, 100)",
                "style": myValscale + "fill:teal;"

            });
            $('#heatjoinbar').attr('transform', 'scale(1 -1) translate(0 -200)');
            $('#heatjoinbar').attr('style', 'margin-top:-850px');


            if (i == hourSelected - 1) {
                $(myID).attr({
                    "style": myValscale + " " + "fill: red;"
                });
            }
        }
    }
    function update(data) {
        //select all bars on the graph, take them out, and exit the previous data set. 
        //then you can add/enter the new data set
        var bars = chart.selectAll(".bar")
                        .remove()
        //now actually give each rectangle the corresponding data
        bars.enter()
            .append("rect")
            .attr("class", "bar")
            .attr("x", function (d, i) { return i * barWidth + 1 })
            .attr("y", function (d) { return yChart(d.watch_time_minutes); })
            .attr("height", function (d) { return height - yChart(d.watch_time_minutes); })
            .attr("width", barWidth - 1)
            .attr("fill", function (d) {
                if (d.viewer_gender === "FEMALE") {
                    return "rgb(251,180,174)";
                } else {
                    return "rgb(179,205,227)";
                }
            });

    }//end update

    myDataset = data;
    populateDaily();
    heatmapChart2("");
    barChart();
    $('#heatMapBarChart2').hide();
}

function piechart(totalflow, totalflowarea) {

    var freqData = [
              { State: 'AL', freq: { Usedcapacity: Math.ceil(totalflow), UnutilizedCapacity: Math.ceil(totalflowarea) } }
    ];

    
    function dashboard(id, fData) {
        var barColor = 'steelblue';
        function segColor(c) { return { Usedcapacity: "teal", UnutilizedCapacity: "#95A5A6" }[c]; } //#45B6DF

        // compute total for each state.
        fData.forEach(function (d) { d.total = d.freq.Usedcapacity + d.freq.UnutilizedCapacity; });

        // function to handle pieChart.
        function pieChart(pD) {

            var pC = {}, pieDim = { w: 120, h: 120 }; //tadinya 200
            pieDim.r = Math.min(pieDim.w, pieDim.h) / 2;

            // create svg for pie chart.
            var piesvg = d3.select(id).append("svg")
              .attr("width", pieDim.w).attr("height", pieDim.h).append("g")
              .attr("transform", "translate(" + pieDim.w / 2 + "," + pieDim.h / 2 + ")");

            // create function to draw the arcs of the pie slices.
            var arc = d3.svg.arc().outerRadius(pieDim.r - 10).innerRadius(0);

            // create a function to compute the pie slice angles.
            var pie = d3.layout.pie().sort(null).value(function (d) { return d.freq; });

            // Draw the pie slices.
            piesvg.selectAll("path").data(pie(pD)).enter().append("path").attr("d", arc)
                .each(function (d) { this._current = d; })
                .style("fill", function (d) { return segColor(d.data.type); })


            var text = piesvg.selectAll('text')
                          .data(pie(tF))
                          .enter()
                          .append("text")
                          .attr("transform", function (d) {
                              return "translate(" + arc.centroid(d) + ")";
                          })

                          .attr("text-anchor", "middle")
                          .text(function (d) {
                              return getPercented(d, tF)
                          })

            function getPercented(d, tF) { // Utility function to compute percentage.
                return d3.format("%")(d.data.freq / d3.sum(tF.map(function (v) { return v.freq; })));
            }




            pC.update = function (nD) {
                piesvg.selectAll("path").data(pie(nD)).transition().duration(500)
                    .attrTween("d", arcTween);
            }

            // Animating the pie-slice requiring a custom function which specifies
            // how the intermediate paths should be drawn.
            function arcTween(a) {
                var i = d3.interpolate(this._current, a);
                this._current = i(0);
                return function (t) { return arc(i(t)); };
            }
            return pC;
        }

        // function to handle legend.
        function legend(lD) {
            var leg = {};

            // create table for legend.
            var legend = d3.select(id).append("table").attr('class', 'legend');

            // create one row per segment.
            var tr = legend.append("tbody").selectAll("tr").data(lD).enter().append("tr");

            // create the first column for each segment.
            tr.append("td").append("svg").attr("width", '10').attr("height", '10').append("rect")
                .attr("width", '10').attr("height", '10')
                .attr("fill", function (d) { return segColor(d.type); });

            // create the second column for each segment.
            tr.append("td").html(function (d, i) { return "<span id='barlegend" + i + "' style='font-size:12px'>" + d.type + "</span>"; });

            // create the third column for each segment.
            // tr.append("td").attr("class", 'legendFreq')
            //     .text(function (d) { return d3.format(",")(d.freq); }); 
            tr.append("td").html(function (d, i) { return "<span id='legendFreq" + i + "' style='font-size:12px'>" + d.freq + "</span>"; });


            //// create the fourth column for each segment.
            //tr.append("td").attr("class", 'legendPerc')
            //    .text(function (d) { return getLegend(d, lD); });


            tr.append("td").attr("class", 'satuan')
                  .style("font-size", "12px")
                  .text(function (d) { return "mmscfd"; });

            // Utility function to be used to update the legend.
            leg.update = function (nD) {
                // update the data attached to the row elements.
                var l = legend.select("tbody").selectAll("tr").data(nD);

                // update the frequencies.
                l.select(".legendFreq").text(function (d) { return d3.format(",")(d.freq); });

                // update the percentage column.
                l.select(".legendPerc").text(function (d) { return getLegend(d, nD); });
            }

            function getLegend(d, aD) { // Utility function to compute percentage.
                return d3.format("%")(d.freq / d3.sum(aD.map(function (v) { return v.freq; })));
            }

            return leg;
        }

        // calculate total frequency by segment for all state.
        var tF = ['Usedcapacity', 'UnutilizedCapacity'].map(function (d) {
            return { type: d, freq: d3.sum(fData.map(function (t) { return t.freq[d]; })) };
        });

        // calculate total frequency by state for all segment.
        var sF = fData.map(function (d) { return [d.State, d.total]; });

        //  var hG = histoGram(sF), // create the histogram.
        pieChart(tF); // create the pie-chart.
        legend(tF);  // create the legend.
    }
    dashboard('#PieChart1', freqData);
}



function map() {
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
    var area = "";
    //Map dimensions (in pixels)
    var width = 550, //500
        height = 250; //250

    //Map projection
    var projection = d3.geo.mercator()
        .scale(2900)
        .center([107.81547105, -6.1597182]) //projection center
        .translate([width / 2, height / 2]) //translate to center the map in view

    //Generate paths based on projection
    var path = d3.geo.path()
        .projection(projection);

    //Create an SVG
    var svg = d3.select("#map5")
        .attr("preserveAspectRatio", "xMinYMin meet")
        .attr("viewBox", "0 0 600 400")
        .attr("width", width)
        .attr("height", height);

    //Group for the map features
    var features = svg.append("g")
        // .attr("class", "features")
        .attr("fill", "#008080");

    //Create zoom/pan listener
    //Change [1,Infinity] to adjust the min/max zoom scale
    var zoom = d3.behavior.zoom()
        .scaleExtent([1, 5])
        .on("zoom", zoomed);

    var bool = false;
    var kota_clicked;

    svg.call(zoom);

    d3.json(url_api_overview_map3, function (error, geodata) {
        //if (error) return console.log(error); //unknown error, check the console

        //console.log(geodata);
        //var jakarta = geodata.geometries[1].properties.KABKOTNO;
        //alert(jakarta);
        //alert(jakarta);

        //Create a path for each map feature in the data
        var tes1 = features.selectAll("path")
           .data(topojson.feature(geodata, geodata.objects.Indonesia).features) //generate features from TopoJSON
           .enter()
           .append("path")
           .style("fill", colorCountry)
           .attr("d", path)
           .on("click", clicked)
           .on("mouseover", mouseoverit)
           .on("mouseout", mouseoutit);


    });

    function colorCountry() {
        var choi = $("h4").text();
        if (choi == "DKI Jakarta") {
            d3.select(this).style("fill", "yellow");
        }
    }



    // Add optional onMouserVer events for features here
    // d.properties contains the attributes (e.g. d.properties.name, d.properties.population)
    function mouseoverit(d, i) {

        if (bool == false) {

            d3.select("h3").text(d.properties.KABKOT);
            var currentState = this;
            //d3.select(this).attr("class", "features");

            d3.select(this).style("fill", "#FFC300");
            //alert(d.properties.KABKOT);



        }
        else {


            d3.select("h3").text(d.properties.KABKOT);
            d3.select(this).attr("class", "features");
            d3.select(this).style("fill", "#FFC300");
        }


    }

    function mouseoutit(d, i) {

        if (bool == false) {
            d3.select("h3").text("");
            d3.select(this).attr("class", "features");
            //d3.select(this).attr("class", "features");
            d3.select(this).style("fill", "#008080");
        }

        else {

            if (kota_clicked == d.properties.KABKOT) {
                d3.select("h3").text("");
                d3.select(this).attr("class", "features");
                d3.select(this).style("fill", "yellow");
            }

            else {
                d3.select("h3").text("");
                d3.select(this).style("fill", "#008080");
            }


        }




    }

    // Add optional onClick events for features here
    // d.properties contains the attributes (e.g. d.properties.name, d.properties.population)
    function clicked(d, i) {

        $('#heatMapChart1').empty();
        $('#heatMapBarChart2').empty();
        $('#PieChart1').empty();
        $('#AsterPlot1').empty();
        $('#graphic').empty();
        //$('#heatMapBarChart2').prepend($("<div id='labelselected2' style='margin-left:40px;'></div>"));
        $('#titlebar').empty();

        //$('#heatMapBarChart2').prepend($("<div id='labelselected2' style='margin-left:40px;'></div>"));
        $('#heatMapBarChart2').prepend($("<div id='labelselected' style='margin-left:20px;margin-bottom:-50px;'></div>"));
        $('#lblValue').append($("<div id='labelheat'></div>"));
        $('#labelselected').before("<strong>Hourly Utilization Profile </strong>");
        //$('#graphic').before("<strong>Flow Profile </strong>");
        //features.selectAll("path")
        //.attr("fill", "green");

        d3.selectAll('path').style('fill', null);
        d3.select(this).style("fill", "green");

        //d.selectAll("path")
        //.attr("fill", "green");

        d3.select("h4").html("<strong>" + d.properties.KABKOT + "</strong>");
        d3.select("h3").text(d.properties.KABKOT);
        d3.select("h5").text(d.properties.KABKOTNO);
        d3.select(this).attr("class", "features");
        d3.select(this).style("fill", "yellow");

        var nimoSelectedArea = d.properties.KABKOTNO;

        var nimoSelectedDate = $("#dashboard-report-range span").html();

        //var fields = nimoSelectedDate.split('-');
        ////alert(fields[0]+" "+fields[1]);

        //var dt = new Date(fields[0]);

        //var GetDay = dt.getDay();

        //alert("getDay() : " + dt.getDay() ); 



        document.cookie = "nimoSelectedArea=" + nimoSelectedArea;
        document.cookie = "nimoSelectedDate=" + nimoSelectedDate;

        var selectedArea = getSelectedArea(document.cookie);

        var selectedDate = getSelectedDate(document.cookie);

        var dataPost = { "DATE_STAMP_STRING": selectedDate, "AREA": selectedArea, "PARAM_ID": 1 };
        //var Model = { DATE_STAMP_STRING: nimoSelectedDate, AREA: nimoSelectedArea };
        //var bool = true;

        var dataPostArea = {};
        dataPostArea.AREA = selectedArea;

        kota_clicked = d.properties.KABKOT;

        bool = true;
        var capMax = 0;

        $.ajax({
            //type: "POST",
            type: "POST",
            url: url_api_dashboard2,
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(dataPostArea),
            crossOrigin: false,
            success: function (data) {

                debugger;
                if (data.CAPACITY_MAX == "") {
                    $('#heatMapChart1').empty();
                    $('#heatMapBarChart2').empty();
                    $('#PieChart1').empty();
                    $('#AsterPlot1').empty();
                    $('#graphic').empty();
                    //$('#heatMapBarChart2').prepend($("<div id='labelselected2' style='margin-left:40px;'></div>"));
                    $('#titlebar').empty();

                    $('#titleAU').hide();
                    $('#titleFP').hide();

                    alert("Data not exist, please select another Area");
                }
                else {
                    capMax = data.CAPACITY_MAX;
                    //alert(capMax);

                    $.ajax({
                        type: "POST",
                        //type: "GET",
                        url: url_api_dashboard,
                        contentType: "application/json",
                        dataType: "json",
                        data: JSON.stringify(dataPost),
                        crossOrigin: false,
                        success: function (data) {






                            $('#titleAU').show();
                            $('#titleFP').show();


                            HeatAndBar(data.Items);
                            //data.TotalFlow = data.TotalFlow.toFixed(3);
                            var totalflowHourly = data.MaxTotalFlow;
                            var totalFlowText = totalflowHourly.toFixed(0);
                            totalflowHourly = totalflowHourly.toFixed(3);

                            capMax = capMax - totalflowHourly;
                            var capMaxOver = capMax;
                            capMaxOver = capMaxOver.toFixed(0);
                            capMax = capMax.toFixed(3);

                            var textPie = 'Unutilized Capacity';
                            if (capMax < 0) {
                                totalflowHourly = 100;
                                capMax = 0;
                                textPie = "Over Capacity";

                            }
                            piechart(totalflowHourly, capMax);

                            if (textPie == "Over Capacity") {

                                $('#legendFreq0').text(totalFlowText);
                                $('#legendFreq1').text(capMaxOver);

                            }

                            $('#barlegend0').text('Used Capacity');
                            $('#barlegend1').text(textPie);
                            //anotherpietest(data.TotalFlow, data.TotalFlowAllArea);
                            //asterchart(data.Items);
                            //anotheraster(data.Items);
                            barreplaceaster(data.Items);

                        }


                    });
                }
            }
        });


    }

    //Update map on zoom/pan
    function zoomed() {
        features.attr("transform", "translate(" + zoom.translate() + ")scale(" + zoom.scale() + ")")
            .selectAll("path").style("stroke-width", 1 / zoom.scale() + "px");
    }
}

function anotheraster(data) {
    var value_range = [];
    var value_count = [];
    var data_range = [];
    var buckets = 9;
    var colors_ori = ["#ffffd9", "#edf8b1", "#c7e9b4", "#7fcdbb", "#41b6c4", "#1d91c0", "#225ea8", "#253494", "#081d58"];
    var colors = ['#ffffcc', '#ffeda0', '#fed976', '#feb24c', '#fd8d3c', '#fc4e2a', '#e31a1c', '#bd0026', '#800026'];
    var maximumValue = 0.0;

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
    function gambar() {
        var pie = d3.layout.pie()
    .sort(null)
    .value(function (d) { return d.width; });

        var tip = d3.tip()
          .attr('class', 'd3-tip')
          .offset([0, 0])
          .html(function (d) {
              return d.data.label + ": <span style='color:orangered'>" + d.data.score + "</span>";
          });

        var arc = d3.svg.arc()
          .innerRadius(innerRadius)
          .outerRadius(function (d) {
              return (radius - innerRadius) * (d.data.score / maximumValue) + innerRadius;
          });

        var outlineArc = d3.svg.arc()
                .innerRadius(innerRadius)
                .outerRadius(radius);

        var svg = d3.select("#AsterPlot1").append("svg")
            .attr("width", width)
            .attr("height", height)
            .append("g")
            .attr("transform", "translate(" + width / 2 + "," + height / 2 + ")");

        svg.call(tip);

        data_range.forEach(function (d) {
            d.id = d.id;
            d.order = +d.order;
            d.color = d.color;
            d.weight = +d.weight;
            d.score = +d.score;
            d.width = +d.weight;
            d.label = d.label;
        });
        // for (var i = 0; i < data.score; i++) { console.log(data[i].id) }

        var path = svg.selectAll(".solidArc")
            .data(pie(data_range))
          .enter().append("path")
            .attr("fill", function (d) { return d.data.color; })
            .attr("class", "solidArc")
            .attr("stroke", "gray")
            .attr("d", arc)
            .on('mouseover', tip.show)
            .on('mouseout', tip.hide);

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
    myDataset = data;
    setRangeValue();
    setRangeCount();
    gambar();
}

function barreplaceaster(data) {
    var value_range = [];
    var value_count = [];
    var data_range = [];
    var buckets = 9;
    //var colors_ori = ["#ffffd9", "#edf8b1", "#c7e9b4", "#7fcdbb", "#41b6c4", "#1d91c0", "#225ea8", "#253494", "#081d58"];
    //var colors = ['#ffffcc', '#ffeda0', '#fed976', '#feb24c', '#fd8d3c', '#fc4e2a', '#e31a1c', '#bd0026', '#800026'];
    var maximumValue = 0.0;

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
            var val = { id: i + 1, order: i + 1, score: value_count[i], weight: 1, label: ">=" + Math.round(value_range[i]).toString() };
            data_range.push(val);
            if (val.score > maximumValue) {
                maximumValue = val.score;
            }

        }

        var count = 0;
        for (var i = 0; i < buckets; i++) {
            count += value_count[i];
        }

        var margin = {
            top: 15,
            right: -250, //25
            bottom: 15,
            left: 50 //60
        };
        //var width = 560 - margin.left - margin.right,
        //  height = 300 - margin.top - margin.bottom;

        //var width = 530 - margin.left - margin.right,
        //  height =280 - margin.top - margin.bottom;

        var width = 370 - margin.left - margin.right,
         height = 230 - margin.top - margin.bottom;

        var colors = d3.scale.ordinal().range(['#ffffe5', '#fff7bc', '#fee391', '#fec44f', '#fe9929', '#ec7014', '#cc4c02', '#993404', '#662506']);

        data_range.forEach(function (d) {
            d.id = d.id;
            d.order = +d.order;
            d.color = d.color;
            d.weight = +d.weight;
            d.score = +d.score;
            d.width = +d.weight;
            d.label = d.label;

        });

        //for( var el in data_range ) {

        //        sum += parseFloat( data_range[el] );
        //    }

        //alert(count);

        var tip = d3.tip()
        .attr('class', 'd3-tip')
        .offset([-10, 0])
        .html(function (d) {
            return "<strong><span style='color:white;'>" + ((d.score / (count)) * 100).toFixed(2) + "%" + "</span>";
        })

        var svg = d3.select("#graphic")
            .attr("preserveAspectRatio", "xMinYMin meet")
            .attr("viewBox", "0 0 600 400")

            .attr("width", width + margin.left + margin.right)
            .attr("height", height + margin.top + margin.bottom)
            .append("g")
            .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

        svg.call(tip);

        var x = d3.scale.linear()
            .range([0, width / 2])
            .domain([0, d3.max(data_range, function (d) {
                return d.score;
            })]);

        var y = d3.scale.ordinal()
            .rangeRoundBands([height, 0], .1)
            .domain(data_range.map(function (d) {
                return d.label;
            }));

        //make y axis to show bar names
        var yAxis = d3.svg.axis()
            .scale(y)
            //no tick marks
            .tickSize(0)
            .orient("left");

        var gy = svg.append("g")
            .attr("class", "yaxis")
            .call(yAxis)

        var bars = svg.selectAll(".bar")
            .data(data_range)
            .enter()
            .append("g")
            .on('mouseover', tip.show)
            .on('mouseout', tip.hide)

        //append rects
        bars.append("rect")
            .attr("class", "bar")
            .attr("y", function (d) {
                return y(d.label);
            })
            .attr("height", y.rangeBand())
            .attr("x", 0)
            .style("fill", function (d, i) { return colors(i); })
            .attr("width", function (d) {
                return x(d.score);
            });

        //add a value label to the right of each bar
        bars.append("text")
            .attr("class", "label")
            //y position of the label is halfway down the bar
            .attr("y", function (d) {
                return y(d.label) + y.rangeBand() / 2 + 4;
            })
        //x position is 3 pixels to the right of the bar
            .attr("x", function (d) {
                return x(d.score) + 3;
            })
        //.text(function (d) {
        //    return d.score;
        //});

        function type(d) {
            d.score = +d.score;
            return d;
        }

    }

    myDataset = data;
    setRangeValue();
    setRangeCount();
    //set up svg using margin conventions - we'll need plenty of room on the left for labels   
}

function GetTableDemandHourly(datapost1,day_hour) {
    
     $('#show_data_demand').show();

    $.ajax({
        type: "POST",
        url: url_api_tbl_dummy + "/ByHour",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(datapost1),
        crossOrigin: false,
        success: function (data) {
       
            $(function () {
                //  var dataGrid = $('#gridContainer').dxDataGrid('instance');
                // dataGrid.refresh();
                //setting pagger devexpress default
                // pager: {
                //       showPageSizeSelector: true,
                //       allowedPageSizes: [5, 10, 20],
                //       showInfo: true
                //   },

                $("#gridContainer").dxDataGrid({
                    dataSource: data,
                    filterRow: { visible: true },
                    headerFilter: { visible: true },
                    paging: {
                        pageSize: 10
                    },
                    pager: {
                        showPageSizeSelector: true,
                        allowedPageSizes: [10],
                        showInfo: true
                    },
                    loadPanel: {
                        enabled: true // or false | "auto"
                    },
                    onContentReady: function () {
                        $(".dx-datagrid-table").addClass("table table-striped table-bordered table-hover");
                        $(".dx-datagrid-headers").addClass("warna");
                    },
                    "export": {
                        enabled: true,
                        fileName: "Data",
                        allowExportSelectedData: false
                    },
                    columns: [{
                        dataField: "IDREFPELANGGAN",
                        caption: "IDREFPELANGGAN",
                        // alignment: "left",
                        // width: 100,
                    },
                    {
                        dataField: "NAMA",
                        caption: "Nama",
                        // alignment: "left",

                    },
                    {
                        dataField: "kontrak_perjam",
                        caption: "Kontrak",
                        alignment: "left",
                        // width:250,
                        cellTemplate: function (element, info) {
                            var color = "black";
                            var kontrak = info.value.toFixed(4);
                            element.append("<span style='color:" + color + "'>" + kontrak + "</span>");
                        }
                    },
                        {
                            dataField: "TOTAL_FDVC",
                            caption: "Utilization",
                            alignment: "left",
                            cellTemplate: function (element, info) {
                                var color = "black";
                                var totalfdvc = info.value.toFixed(4);
                                element.append("<span style='color:" + color + "'>" + totalfdvc + "</span>");
                            }

                        },

                          {
                              dataField: "persen_utilisasi",
                              caption: "Persen Utilisasi",
                              alignment: "left",
                              // width:200,
                              cellTemplate: function (element, info) {
                                  var persen = info.value.toFixed(2);

                                  element.append("<span style='color:black'>" + persen + "%</span>");
                              }
                          },
                        {
                            dataField: "persen_utilisasi",
                            caption: "",
                            alignment: "left",
                            // width:200,
                            cellTemplate: function (element, info) {
                                var color = "blue";
                                var persen = info.value.toFixed(2);
                                if (info.text > 100) {
                                    color = "red";
                                }

                                element.append("<div class='progress' style='margin-bottom:-5px'>" +
                        "<div class='progress-bar' role='progressbar' aria-valuenow='100' aria-valuemin='0' aria-valuemax='100' style='width:" + persen + "%;background-color:" + color + ";'>");
                            }
                        }



                    ]


                });
            });

                  //batas success  
                   setTimeout(function () {
                   
                    var modal = document.getElementById('myModal1');
                    modal.style.display = "block";
                    $('#show_data_demand').hide();
                    $("#title").html("<h5 style='background-color:#0099ff;width:100%;height:30%;color:white;'><i class='fa fa-globe'></i>Heatmap utilization Table" + day_hour + "</h5>");
                   
                }, 2000);


        }
    });

    $("#myClose1").click(function () {
        $("#myModal1").css("display", "none");
        var grid = $('#gridContainer').dxDataGrid('instance');
        // grid.option('dataSource', []);
        grid.option('dataSource', null);
        grid.refresh();
        // $("#gridContainer").empty();

    });


}



var tes = { "DATE_STAMP_STRING": "July 3, 2017 - July 10, 2017", "AREA": "011", "PARAM_ID": 1 }
var dataPostArea = {};
dataPostArea.AREA = "011";
var capMax = 0;

$.ajax({
    //type: "POST",
    type: "POST",
    url: url_api_dashboard2,
    contentType: "application/json",
    dataType: "json",
    data: JSON.stringify(dataPostArea),
    crossOrigin: false,
    success: function (data) {

        //capMax = data.CAPACITY_MAX;
        //alert(capMax);

        ajax(data.CAPACITY_MAX);


    }
});


function ajax(max) {
    $.ajax({
        type: "POST",
        //type: "GET",
        url: url_api_dashboard,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(tes),
        crossOrigin: false,
        success: function (data) {
            $('#heatMapChart1').empty();
            $('#heatMapBarChart2').empty();
            $('#PieChart1').empty();
            $('#AsterPlot1').empty();
            $('#graphic').empty();

            //$('#heatMapBarChart2').prepend($("<div id='labelselected2' style='margin-left:40px;'></div>"));
            $('#heatMapBarChart2').prepend($("<div id='labelselected' style='margin-left:20px;margin-bottom:-50px;'></div>"));
            $('#lblValue').append($("<div id='labelheat'></div>"));
            $('#labelselected').before("<strong>Hourly Utilization Profile</strong>");
            //$('#graphic').before("<span><strong>Flow Profile </strong></span>");




            HeatAndBar(data.Items);
            barreplaceaster(data.Items);


            //var totalflowHourly = (data.TotalFlow / 24) / 7;

            var totalflowHourly = data.MaxTotalFlow;
            var totalFlowText = totalflowHourly.toFixed(0);
            totalflowHourly = totalflowHourly.toFixed(3);

            debugger;
            max = max - totalflowHourly;
            var capMaxOver = max;
            capMaxOver = capMaxOver.toFixed(0);
            max = max.toFixed(3);
            var textPie = 'Unutilized Capacity';
            if (max < 0) {
                totalflowHourly = 100;
                max = 0;
                textPie = "Over Capacity";

            }

            piechart(totalflowHourly, max);
            if (textPie == "Over Capacity") {

                $('#legendFreq0').text(totalFlowText);
                $('#legendFreq1').text(capMaxOver);
            }

            $('#barlegend0').text('Used Capacity');
            $('#barlegend1').text(textPie);

            //anotherpietest(data.TotalFlow, data.TotalFlowAllArea);
            //asterchart(data.Items);
            //anotheraster(data.Items);

            map();

        }
    });


}

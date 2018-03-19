
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


        'use strict';

        var selectedArea = getSelectedArea(document.cookie);
        var selectedDate = getSelectedDate(document.cookie);
        //alert(selectedArea);
        //alert(selectedDate);
        var dataPost = { "DATE_STAMP_STRING": selectedDate, "AREA": selectedArea, "PARAM_ID": 1 };
        //var tes = { "DATE_STAMP_STRING": "July 7, 2017 - July 14, 2017", "AREA": "014", "PARAM_ID": 1 };
        //debugger;
        //alert(dataPost.AREA);

        $.ajax({
            type: "POST",
            //type: "GET",
            url: "http://localhost:32271/api/CapacityUtilization",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(dataPost),
            crossOrigin: false,
            success: function (data) {

                var freqData = [
                         { State: 'AL', freq: { location: data.TotalFlow, remaining: data.TotalFlowAllArea } }

                ];

                dashboard('#PieChart1', freqData);

                //(function (d3) {

                //    var dataset = [
                //      { label: 'Area: ' + '014', count: data.TotalFlow, Color: '#feb24c' },
                //      { label: 'All', count: data.TotalFlowAllArea, Color: '#fd8d3c' }
                //    ];


                //    var width = 200;
                //    var height = 200;
                //    var radius = Math.min(width, height) / 2;

                //    debugger;
                //   // var color = d3.scaleOrdinal(d3.schemeCategory20b);
                //    var myTip2 = d3.tip()
                //    .attr('class', 'd3-tip')
                //    .offset([0, 0])
                //    .html(function (d) {
                //        return d.data.count;
                //    });

                //    var svg = d3.select('#PieChart1')
                //      .append('svg')
                //      .attr('width', width)
                //      .attr('height', height)
                //      .append('g')
                //      .attr('transform', 'translate(' + (width / 2) +
                //        ',' + (height / 2) + ')');

                //    svg.call(myTip2);

                //    var arc = d3.svg.arc()
                //      .innerRadius(0)
                //      .outerRadius(radius);

                //    var pie = d3.layout.pie()
                //      .value(function (d) { return d.count; })
                //      .sort(null);

                //    var path = svg.selectAll('path')
                //      .data(pie(dataset))
                //      .enter()
                //      .append('path')
                //      .attr('d', arc)
                //      .attr('fill', function (d) {
                //          return d.data.Color;
                //      })
                //    .on('mouseover', myTip2.show)
                //    .on('mouseout', myTip2.hide);

                //})(window.d3);



              
                }
            });

        function dashboard(id, fData) {
            var barColor = 'steelblue';
            function segColor(c) { return { location: "#45B6DF", remaining: "#E9EDEF" }[c]; }

            // compute total for each state.
            fData.forEach(function (d) { d.total = d.freq.location + d.freq.remaining; });

            // function to handle pieChart.
            function pieChart(pD) {
                var pC = {}, pieDim = { w: 200, h: 200 };
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


                // create function to update pie-chart. This will be used by histogram.
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
                tr.append("td").text(function (d) { return d.type; });

                // create the third column for each segment.
                tr.append("td").attr("class", 'legendFreq')
                    .text(function (d) { return d3.format(",")(d.freq); });

                // create the fourth column for each segment.
                tr.append("td").attr("class", 'legendPerc')
                    .text(function (d) { return getLegend(d, lD); });

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
            var tF = ['location', 'remaining'].map(function (d) {
                return { type: d, freq: d3.sum(fData.map(function (t) { return t.freq[d]; })) };
            });

            // calculate total frequency by state for all segment.
            var sF = fData.map(function (d) { return [d.State, d.total]; });

          //  var hG = histoGram(sF), // create the histogram.
             pieChart(tF); // create the pie-chart.
             legend(tF);  // create the legend.
        }
   

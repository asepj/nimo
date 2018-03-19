var DashboardHeatmap = function () {
    return {
        initChart: function (selectArea) {

            //alert(selectArea);

            var myDataset = [{ "day": "1", "hour": "1", "value": "16" }];

            var myDatasetDay = [];
            var daySelected = 0;
            var hourSelected = 0;
            var chart;

            var margin = { top: 25, right: 0, bottom: 0, left: 30 },
                width = 820 - margin.left - margin.right,
                height = 300 - margin.top - margin.bottom,
                gridSize = Math.floor(width / 24),
                legendElementWidth = gridSize * 2,
                buckets = 9,
          
                colors = ['#ffffe5', '#fff7bc', '#fee391', '#fec44f', '#fe9929', '#ec7014', '#cc4c02', '#993404', '#662506'], // alternatively colorbrewer.YlGnBu[9]
                colors_ori = ["#ffffd9", "#edf8b1", "#c7e9b4", "#7fcdbb", "#41b6c4", "#1d91c0", "#225ea8", "#253494", "#081d58"], // alternatively colorbrewer.YlGnBu[9]
                value_range = [],
                value_range_1000 = [],
                days = ["Mo", "Tu", "We", "Th", "Fr", "Sa", "Su"],
                times = ["12a", "1a", "2a", "3a", "4a", "5a", "6a", "7a", "8a", "9a", "10a", "11a", "12p", "1p", "2p", "3p", "4p", "5p", "6p", "7p", "8p", "9p", "10p", "11p"];
            datasets = ["data.tsv", "data2.tsv"];

            var svg = d3.select("#heatMapChart1").append("svg")
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
                        alert("value = " + d.value.toString())
                    })
                    .on("mouseover", function (d) {

                        var labelbarchart;
                        d3.select(this).style("stroke", "red");

                        hourSelected = d3.select(this).attr("x") / gridSize +1;
                        daySelected = d3.select(this).attr("y") / gridSize + 1;

                        document.getElementById("labelselected").innerHTML = "Day : "+ days[daySelected-1] + " /" +" Hour : "+times[hourSelected-1];
                       
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
                  .attr("y", height - gridSize)
                  .attr("width", legendElementWidth)
                  .attr("height", gridSize / 2)
                  .style("fill", function (d, i) { return colors[i]; });

                legend.append("text")
                  .attr("class", "mono")
                  .text(function (d, i) { return "≥ " + Math.round(value_range[i]); })
                  .attr("x", function (d, i) { return legendElementWidth * i; })
                  .attr("y", height + gridSize - gridSize);

                legend.exit().remove();

                //alert("legend end...");

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

            var barChart = function () {

                debugger;
                if (myDatasetDay != "") {
                    var myData = myDatasetDay[daySelected];

                    var myChart = d3.select("#heatMapBarChart1").selectAll("div")
                        .data(myData) // <— The answer is here!
                        .enter()
                        .append("div")
                        .attr("class", "bar")
                        .attr("id", function (d, i) { return "h" + i.toString() })
                        .style("height", function (d) {
                            var barHeight = d;
                            return barHeight + "px";
                        })
                }

            }


            var updateBarChart = function () {

                var myData = myDatasetDay[daySelected - 1];
                var panjang = myData.length;

                for (var i = 0; i < panjang; i++) {
                    var myID = "#h" + i.toString();
                    var myVal = "height: " + (myData[i]).toString() + "px" + ";";
                    $(myID).attr({
                        "style": myVal
                    });
                    if (i == hourSelected - 1) {
                        $(myID).attr({
                            "style": myVal + " " + "background-color: red;"
                        });
                    }
                }
            }

            function getSelectedArea(s) {
                var cookieName = "nimoSelectedArea";
                var retval = "011";
                if (s.indexOf(";") > 0) {
                    var re = /\s*;\s*/; 
                    var nameList = s.split(re);
                    var length = nameList.length;
                    for (var i = 0; i < length; i++) {
                        if (nameList[i].indexOf(cookieName) != -1) {
                            //alert(nameList[i]);
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

            var dataPost = { "DATE_STAMP_STRING": $("#dashboard-report-range span").html(), "AREA": getSelectedArea(document.cookie), "PARAM_ID": 1 };
            
            debugger;
            $.ajax({
                type: "POST",
                //type: "GET",
                url: "http://localhost:32271/api/CapacityUtilization",
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify(dataPost),
                crossOrigin: false,
                success: function (data) {
                    myDataset = data.Items;
                    populateDaily();
                    heatmapChart2("");
                    barChart();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            }); 
            
        },

        updateChart: function (selectArea) {

            var chart;

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


            var dataPost = { "DATE_STAMP_STRING": $("#dashboard-report-range span").html(), "AREA": selectArea, "PARAM_ID": 1 };

            $.ajax({
                type: "POST",
                //type: "GET",
                url: "http://localhost:32271/api/CapacityUtilization",
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify(dataPost),
                crossOrigin: false,
                success: function (data) {
                    update(data.Items);
                }
            });

        }

    }


}
();






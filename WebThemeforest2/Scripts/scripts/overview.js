
"use strict"
/// <reference path="C:\Users\yogiekusumahn\documents\visual studio 2015\Projects\overview\Overview\Models/data/total_tangerang.js" />
/// <reference path="C:\Users\yogiekusumahn\documents\visual studio 2015\Projects\overview\Overview\Models/data/total_tangerang.js" />
var lat = -6.309031; //-6.378127;
var lng = 107.134833; //107.108776;
var zoom = 11;
var m3_per_hour_to_mmscfd = 0.000815249;

// Layers variable
var demands;
var pipelines;
var heatmapLayer;
// Legend variables
var legendPipelines;
var legendDemands;
//var heatmapLegend;

// Variable to hold points and its intensity
var demandFlowrates = [];

// variable to hold demand flowrate maximum and minimum
var minDemandFlowrate, maxDemandFlowrate;
var demandValueRange = [];

// variable to hold pipe flowrate value
var pipeFlowrate = [];
// variable to hold pipe flowrate maximum and minimum
var minPipeFlowrate, maxPipeFlowrate;
var pipeValueRange = [];
var percents;

// Color bucket
var colorBucket = ['#ffffcc', '#ffeda0', '#fed976', '#feb24c', '#fd8d3c', '#fc4e2a', '#e31a1c', '#bd0026', '#800026'];
var brewDemand, fromDemand, toDemand, labelsDemand;
var brewPipeline, fromPipeline, toPipeline, labelsPipeline;

var months = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December'
];

// Create map
var map = new L.Map('map', {
    center: new L.LatLng(lat, lng),
    zoom: zoom
    //layers: [baseLayer, heatmapLayer]
});

// Create google map base layer
var googleBaseLayer = L.gridLayer.googleMutant({
    type: 'roadmap',
    styles: [
        { elementType: 'labels', stylers: [{ visibility: 'on' }] }
    ]
});

// Add base layer to map
googleBaseLayer.addTo(map);

// Add sidebar plugin
var sidebar = L.control.sidebar('sidebar').addTo(map);

//  Add slider control for controling data
var d = new Date();
//var currentMonth = d.getMonth();
var currentMonth = 0;
var currentMonthYear = months[currentMonth] + '-' + (d.getFullYear()-1);
var monthlySlider = L.control.slider(function(value) {
				console.log(value);
				var d = new Date();
				showDemandHeatmap(months[value] + '-' + (d.getFullYear()-1));
			}, {
		position: 'bottomleft',
		collapsed: false,
		min: 0,
		max: 11,
		step: 1,
		value: currentMonth,
		getValue: function (value){ 
			var d = new Date();
			return months[value] + '-' + (d.getFullYear()-1);
		},
		step:1,
		size: '250px',
		orientation:'horizontal',
		id: 'slider'
	}
);

// Create control layer to control layers appeareances
var controlLayers = L.control.layers(null, null, {
    position: "topright", // suggested: bottomright for CT (in Long Island Sound); topleft for Hartford region
    collapsed: false // false = open by default
}).addTo(map);


// Create heatmap layer 
var heatmapConfig = {
	radius: 40,
	"maxOpacity": 1,
	"scaleRadius": false,
	"useLocalExtrema": false,
	blur: 0.9,
	latField: 'lat',
	lngField: 'lng',
	valueField: 'value',
	onExtremaChange: function (extremeData) {
		heatmapLegend.updateLegend(extremeData);
	}

};

heatmapLayer = new HeatmapOverlay(heatmapConfig);
controlLayers.addOverlay(heatmapLayer, "Demand Map");

// Create heatmap legend
var heatmapLegend = L.control.heatmapControl({ position: "bottomright" });
    map.addControl(heatmapLegend);

// Get data demands from file
var d = [];
//var promise = $.getJSON("data/demandJakarta.js");
var promise = $.getJSON(url_api_overview_map);
function showDemandHeatmap(month) 
{
	promise.then(function (data) {
		// add GeoJSON layer to the map once the file is loaded
		demands = L.geoJson(data, {
/* 			filter: function (feature, latlng) {
				//return feature.properties.MONTHLY === "January-2016";
				console.log(month);
				return feature.properties.MONTHLY === month;
			}, */
			pointToLayer: function (feature, latlng) {
				return L.circleMarker(latlng, { opacity: 0 });
			},
			onEachFeature: function (feature, layer) {
					var mmscfd = feature.properties.Demand * m3_per_hour_to_mmscfd;
					layer.bindPopup(feature.properties.FacilityName + "</br>Flowrate: <b>" +
										mmscfd+ "</b>" );
					demandFlowrates.push([feature.geometry.coordinates[1],feature.geometry.coordinates[0], feature.properties.FacilityName, mmscfd]);
					d.push(mmscfd);
				
/* 				var mmscfd = feature.properties.TOTAL_MONTHLY * m3_per_hour_to_mmscfd;
				layer.bindPopup(feature.properties.NAMA + "</br>Flowrate: <b>" +
									mmscfd + "</b>");
				demandFlowrates.push([feature.geometry.coordinates[1], feature.geometry.coordinates[0], feature.properties.NAMA, mmscfd]);
				d.push(mmscfd); */
			}
		});

		console.log(demandFlowrates);
		// Get pipe flow rate maximum and minimum
		minDemandFlowrate = Math.min.apply(null, d);
		maxDemandFlowrate = Math.max.apply(null, d);

		// Loop through demand flowarates to set its intentsity for heatmap
		var demandPointsIntensity = [];
		for (var j = 0; j < demandFlowrates.length; j++) {
			var percentIntensity = demandFlowrates[j][3] / 1;
			var ob = {
				lat: demandFlowrates[j][0],
				lng: demandFlowrates[j][1],
				value: percentIntensity

			};

			demandPointsIntensity.push(ob);
			//console.log("Loop " + j + ";" + demandFlowrates[j][1] + "," + demandFlowrates[j][0] + "," + demandFlowrates[j][3] + "," +  maxDemandFlowrate + "," + percentIntensity );
		}

		var testData = {
			max: maxDemandFlowrate * 1.0,
			data: demandPointsIntensity
		};

		console.log(testData);

		// Set heatmap layer data
		heatmapLayer.setData(testData);
				
		demands.setStyle({ opacity: 0, fillOpacity: 0 });
		//			controlLayers.addOverlay(demands, "Demand Map Value");
		//			demands.addTo(map);

		map.fitBounds(demands.getBounds(), { padding: [50, 50] });
		
	})
};

showDemandHeatmap(currentMonthYear);

// Load data pipeline
promise = $.getJSON(url_api_overview_map2);
promise.then(function (data) {
    // add GeoJSON layer to the map once the file is loaded
    pipelines = L.geoJson(data, {
        //style: pipelineStyle,
        onEachFeature: function (feature, layer) {
            layer.bindPopup("Pipeline: <b>" + feature.properties.FacNam1005 + "</b></br>Flowrate: <b>" +
                                feature.properties.PipeC20721 + "</b>");
            pipeFlowrate.push(feature.properties.PipeC20721);
        }
    });

    // Get pipe flow rate maximum and minimum
    minPipeFlowrate = Math.min.apply(null, pipeFlowrate);
    maxPipeFlowrate = Math.max.apply(null, pipeFlowrate);

    // create classybrew object
    brewPipeline = new classyBrew();
    // pass array to our classybrew series
    brewPipeline.setSeries(pipeFlowrate);
    // define number of classes
    brewPipeline.setNumClasses(4);
    // set color ramp code
    brewPipeline.setColorCode("YlOrRd");
    // classify by passing in statistical method
    // i.e. equal_interval, jenks, quantile
    brewPipeline.classify("jenks");

    // Set range value
    //pipeValueRange = setRangeValue(minPipeFlowrate, maxPipeFlowrate);
    //console.log(pipeValueRange);

    // Set style for pipeline
    var pipelineStyle = function (feature) {
        //var color = getColor(feature.properties.PipeC20721, pipeValueRange);
        var color = brewPipeline.getColorInRange(feature.properties.PipeC20721);
        return { color: color, weight: 3, opacity: 0.8 };
    };

    pipelines.setStyle(pipelineStyle);

    if (!L.Browser.ie && !L.Browser.opera && !L.Browser.edge) {
        pipelines.bringToFront();
    }

    //pipelines.addTo(mymap);
    controlLayers.addOverlay(pipelines, "Saturated Map");
    map.fitBounds(pipelines.getBounds(), { padding: [50, 50] });

    // Create pipeline legend
    legendPipelines = L.control({ position: 'bottomright' });
    legendPipelines.onAdd = function (map) {
        var div = L.DomUtil.create('div', 'info  legendPipelines');
		//var fromPipeline, toPipeline;
		
        percents = brewPipeline.getBreaks();
        labelsPipeline = [];
        console.log(percents);
		
        for (var i = 0; i < percents.length; i++) {
            fromPipeline = percents[i];
            toPipeline = percents[i + 1];
            console.log("fromPipeline:" + fromPipeline + ";toPipeline:" + toPipeline);
            if (toPipeline) {
                labelsPipeline.push(
                    '<i style="background:' + brewPipeline.getColorInRange(fromPipeline) + '"></i> ' +
                    fromPipeline.toFixed(2) + ' &ndash; ' + toPipeline.toFixed(2));
            }
        }
        //console.log(labelsPipeline);
        div.innerHTML = '<strong>Saturation Map</strong> <br><br>' + labelsPipeline.join('<br>');
        console.log(div.innerHTML);
        return div;
    };

});

map.on('overlayadd', function (eventLayer) {
    if (eventLayer.name === "Saturated Map") {
        //this.removeControl('otherLegend');
        legendPipelines.addTo(map);
    }
    else {
        //legendDemands.addTo(map);
        //map.addControl(heatmapLegend);
		monthlySlider.addTo(map);
        demands.addTo(map);
    }

});

map.on('overlayremove', function (eventLayer) {
    if (eventLayer.name === "Saturated Map") {
        //this.removeControl('otherLegend');
        map.removeControl(legendPipelines);
    }
    else {
        //map.removeControl(legendDemands);
        //map.removeControl(heatmapLegend);
        demands.removeFrom(map);
		map.removeControl(monthlySlider);
    }

});

// Demand map settings
//		document.getElementById('demandRadius').addEventListener('input', function () {
//			var wg = parseInt(this.value, 10);
//			var st = {};
//			st = {"radius": wg};
//			//demands.setStyle(st);
//			//debugger;
//			heatmapLayer.setStyle(st);
//		});
//		
//		document.getElementById('demandOpacity').addEventListener('input', function () {
//			var wg = parseFloat(this.value, 10);
//			var st = {};
//			//st = {opacity: wg, fillOpacity: wg};
//			st = {"opacity": wg};
//			//demands.setStyle(st);
//			heatmapLayer.setStyle(st);
//		});
//		
//		document.getElementById('demandBlur').addEventListener('input', function () {
//			var wg = parseFloat(this.value, 10);
//			var st = {};
//			//st = {opacity: wg, fillOpacity: wg};
//			st = {"blur": wg};
//			//demands.setStyle(st);
//			heatmapLayer.setStyle(st);
//		});

// Pipeline map settings
document.getElementById('pipelineWeight').addEventListener('input', function () {
    var wg = parseInt(this.value, 10);
    var st = {};
    st = { weight: wg };
    pipelines.setStyle(st);
});

document.getElementById('pipelineOpacity').addEventListener('input', function () {
    var wg = parseFloat(this.value, 10);
    var st = {};
    st = { opacity: wg, fillOpacity: wg };
    pipelines.setStyle(st);
});


function setPipelinePalette(val) {
    console.log("palette changed!! " + val);
    // set color ramp code
    brewPipeline.setColorCode(val);
    // refresh pipeline map
	refreshPipelineMap();
}

function setPipelineClassification(val) {
    console.log("Breaks changed!! " + val);
    // set color ramp code
	//brewPipeline.setSeries(pipeFlowrate);
    brewPipeline.classify(val);
	console.log(brewPipeline);
    // refresh pipeline map
	refreshPipelineMap();
}

function refreshPipelineMap() {
	var st = function (feature) {
        //var color = getColor(feature.properties.PipeC20721, pipeValueRange);
        var color = brewPipeline.getColorInRange(feature.properties.PipeC20721);
        return { color: color};
    };
    pipelines.setStyle(st);
    legendPipelines.remove(map);
    legendPipelines.addTo(map);
}

function setDemandExtrema(val){
	console.log("set Extrema");
    //heatmapLayer.setStyle(heatmapConfig);

}

function setRangeValue(minValue, maxValue) {
    var range = maxValue - minValue;
    var range_width = range / colorBucket.length;
    var value_range = [];
    for (var i = 0; i < colorBucket.length; i++) {
        value_range.push(minValue + i * range_width);
    }
    return value_range;
}

function getColor(n, valRange) {
    var length = valRange.length;
    var myColor = "";
    for (var i = 0; i < length; i++) {
        if (n > valRange[length - i - 1]) {
            myColor = colorBucket[length - i - 1];
            break;
        }
    }
    if (myColor === "") {
        myColor = colorBucket[0];
    }
    return myColor;
}
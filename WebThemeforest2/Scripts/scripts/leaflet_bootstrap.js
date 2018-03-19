/* global L */ // JS Hint

"use strict";

var mymap;
var lat = -6.309031; //-6.378127;
var lng = 107.134833; //107.108776;
var zoom = 6;

// Layers variable
var karawang;
var jakarta;

// variable to hold pipe flowrate value
var pipeFlowRate = [];
// variable to hold pipe flowrate maximum and minimum
var	minPipeFlowRate, maxPipeFlowRate;
var colorBucket = ['#ffffcc','#ffeda0','#fed976','#feb24c','#fd8d3c','#fc4e2a','#e31a1c','#bd0026','#800026'],
value_range = [];

// Variable to hold points and its intensity
var addressPoints = [];

// Heat map layer
var heatMapLayer;

function initmap() {
    // set up the map

	mymap = L.map('map', {
		center: [lat, lng],
		zoom: zoom
	});

	var googleBaseLayer = L.gridLayer.googleMutant({
		type: 'roadmap',
		styles: [
			{elementType: 'labels', stylers: [{visibility: 'on'}]}
		]
	});

	googleBaseLayer.addTo(mymap);
	
	var controlLayers = L.control.layers( null, null, {
		  position: "topright", // suggested: bottomright for CT (in Long Island Sound); topleft for Hartford region
		  collapsed: true // false = open by default
	}).addTo(mymap);
	
	
	var geojsonMarkerOptions = {
			radius: 5,
			fillColor: "#ff7800",
			color: "#ff7800",
			weight: 1,
			opacity: 0.5,
			fillOpacity: 0.3
		};
	
	var heatMapOptions = {
		max: 1,
		radius: 25,
		blur: 15,
		minOpacity: 0.5
	};
	
	var promise = $.getJSON("http://localhost:32271/Scripts/scripts/Demand_Karawang.json");
	promise.then(function(data){
		// add GeoJSON layer to the map once the file is loaded
		jakarta = L.geoJson(data, {
//			filter: function(feature, latlng) {
//				return feature.properties.MONTHLY === "January-2016";
//			},
			pointToLayer: function (feature, latlng) {
				return L.circleMarker(latlng, geojsonMarkerOptions);
			},
			onEachFeature: function (feature, layer) {
				layer.bindPopup(feature.properties.FacilityName + "</br>Flowrate: <b>" +
									feature.properties.Demand+ "</b>" );
				
				addressPoints.push([feature.geometry.coordinates[1],feature.geometry.coordinates[0]]);
			}
		});
		console.log(addressPoints);
		//jakarta.addTo(mymap);
		//controlLayers.addOverlay(jakarta, "Demand Map");
		heatMapLayer = L.heatLayer(addressPoints, heatMapOptions);
		controlLayers.addOverlay(heatMapLayer, "Demand Map");
		mymap.fitBounds(jakarta.getBounds(),{ padding: [50,50]});
	});
	
	// Karawang pipeline style
//	var pipelineStyle = {
//			"color": "#ff7800",
//			"weight": 3,
//			"opacity": 0.65
//	};
	
	// load karawang GeoJSON from an external file
	promise = $.getJSON("http://localhost:32271/Scripts/scripts/KarawangFacilities.json");
	promise.then(function(data){
		// add GeoJSON layer to the map once the file is loaded
		karawang = L.geoJson(data, {
			//style: pipelineStyle,
			onEachFeature: function (feature, layer) {
				layer.bindPopup("Pipeline: <b>" + feature.properties.FacNam1005 + "</b></br>Flowrate: <b>" +
									feature.properties.PipeC20721 + "</b>");
				pipeFlowRate.push(feature.properties.PipeC20721);
			}
		});

		// Get pipe flow rate maximum and minimum
		minPipeFlowRate = Math.min.apply(null, pipeFlowRate);
		maxPipeFlowRate = Math.max.apply(null, pipeFlowRate);
		
		// Set range value
		setRangeValue(minPipeFlowRate, maxPipeFlowRate);
		console.log(value_range);
		
		// Set style for pipeline
		var pipelineStyle = function(feature){
			var color = getColor(feature.properties.PipeC20721);
			return {color: color, weight: 15, opacity: 0.65};
		};

		karawang.setStyle(pipelineStyle);
		
		//karawang.addTo(mymap);
		controlLayers.addOverlay(karawang, "Saturated Map");
		mymap.fitBounds(karawang.getBounds(),{ padding: [50,50]});
	});
	
//	document.getElementById('weight').addEventListener('input', function () {
//		var wg = parseInt(this.value, 10);
//		var st = {};
//		st = {weight: wg};
//		karawang.setStyle(st);
//	});
//	
//	document.getElementById('opacity').addEventListener('input', function () {
//		var wg = parseInt(this.value, 10);
//		var st = {};
//		st = {opacity: wg};
//		karawang.setStyle(st);
//	});
//	
	// Saturated map settings
	['weight', 'opacity'].forEach(function (value) {
			document.getElementById(value).addEventListener('input', function () {
				var style = {};
				style[value] = parseFloat(this.value);
				console.log(style[value]);
			karawang.setStyle(style);
		});
	});
	
	// Demand map settings
	['radius', 'minOpacity', 'blur'].forEach(function (value) {
			document.getElementById(value).addEventListener('input', function () {
				var style = {};
				style[value] = parseFloat(this.value);
				console.log(style[value]);
			heatMapLayer.setOptions(style);
		});
	});
	
}

function setRangeValue(minValue, maxValue){
	var range = maxValue - minValue;
	var range_width = range / colorBucket.length;
	value_range.length = 0;
	for (var i = 0; i < colorBucket.length; i++) {
		  value_range.push(minValue + i * range_width);
	}
}

function getColor(n) {
	var length = value_range.length;
	var myColor = "";
	for (var i = 0; i < length; i++) {
		if (n > value_range[length - i - 1]) {
			myColor = colorBucket[length - i - 1];
			break;
		}
	}
	if (myColor === "") {
		myColor = colorBucket[0];
	}
	return myColor;
}

initmap();




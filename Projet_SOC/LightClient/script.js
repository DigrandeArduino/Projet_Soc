function drawLine(coordinates, color, size, map, type){
	var coords = coordinates;
	var line = new ol.geom.LineString(coords);
	line.transform('EPSG:4326', 'EPSG:3857');

	var start = new ol.Feature({
	geometry: line,
	name: 'Line'
	});

	var line_final = new ol.style.Style({
	stroke: new ol.style.Stroke({
	color: color,
	width: size
	})
	});

	var source = new ol.source.Vector({
	features: [start]
	});

	var vector = new ol.layer.Vector({
	source: source,
	style: [line_final]
	});

	if(type==="a"){
		vector_start = vector;
		is_a_set = true;
	}
	if(type==="b"){
		vector_bike = vector;
		is_b_set = true;
	}
	if(type==="c"){
		vector_end = vector;
		is_c_set = true;
	}

	/*map.addLayer(vector);
	map.removeLayer(vector);*/
}

function callAPI(url, requestType, start, end, isCoord, finishHandler) {
    var fullUrl = url+"?start="+start+"&end="+end+"&isCoord="+isCoord;
    var caller = new XMLHttpRequest();
    caller.open(requestType, fullUrl, true);
    caller.setRequestHeader ("Accept", "application/json");
    caller.onload=finishHandler;
    caller.send();
}

var instruct_start = "start";
var instruct_bike = "bike";
var instruct_end = "end";
var start = "none";

var vector_start;
var vector_bike;
var vector_end;
var is_a_set = false;
var is_b_set = false;
var is_c_set = false;

function displayValue(){
	console.log(this.status);
    if (this.status!==200) {
        console.log("bad request");
    } else {
    response = JSON.parse(this.responseText);

    if(is_a_set){
    	is_a_set = false;
    	map.removeLayer(vector_start);
    }

    if(is_b_set){
    	is_b_set = false;
    	map.removeLayer(vector_bike);
    }

    if(is_c_set){
    	is_c_set = false;
    	map.removeLayer(vector_end);
    }

    var start = response.pathStartToStation;
    drawLine(start,'#000CFF',4,map,"a");
    map.addLayer(vector_start);

    instruct_start = response.startStep;
    if(response.footIsBetter!=="yes"){
    	var bike = response.pathBikeToStation;
    	drawLine(bike,'#007107',6,map,"b");
    	map.addLayer(vector_bike);
    	var end = response.pathStartToEnd;
    	drawLine(end,'#000CFF',4,map,"c");
    	map.addLayer(vector_end);
    	instruct_bike = response.bikeStep;
    	instruct_end = response.endStep;
    }
    else {
    	instruct_bike = instruct_start;
    	instruct_end = instruct_start;
    }

    var sub_title = document.getElementById("pathway");
    sub_title.textContent = "List of the pathway [duration : "+response.total_time+" s] :";
    
    var start_zoom = [response.startCoord[1],response.startCoord[0]]
    startPath();

    map.setView(new ol.View({
            center: ol.proj.fromLonLat(start_zoom),
            zoom: 15
        }));
    }
}

function startPath(){
	var parragraphe = document.getElementById("instruc");
	if(instruct_start==="start"){
		parragraphe.textContent = "Enter a start position and a destination...";
	}
	else{
		parragraphe.textContent = "Go to the first station :\n"
		for (var i = 0; i < instruct_start.length; i++) {
			parragraphe.textContent += "Distance : "+instruct_start[i].distance+"m, Time : "+instruct_start[i].duration+"s, Do : "+instruct_start[i].instruction+"\n";
		}
	}
	parragraphe.setAttribute('style', 'white-space: pre-line;');
}

function bikePath(){
	var parragraphe = document.getElementById("instruc");
	if(instruct_bike==="bike"){
		parragraphe.textContent = "Enter a start position and a destination...";
	}
	else{
		parragraphe.textContent = "Biking to the final station :\n"
		for (var i = 0; i < instruct_bike.length; i++) {
			parragraphe.textContent += "Distance : "+instruct_bike[i].distance+"m, Time : "+instruct_bike[i].duration+"s, Do : "+instruct_bike[i].instruction+"\n";
		}
	}
	parragraphe.setAttribute('style', 'white-space: pre-line;');
}

function endPath(){
	var parragraphe = document.getElementById("instruc");
	if(instruct_end==="end"){
		parragraphe.textContent = "Enter a start position and a destination...";
	}
	else{
		parragraphe.textContent = "Go to the destination :\n"
		for (var i = 0; i < instruct_end.length; i++) {
			parragraphe.textContent += "Distance : "+instruct_end[i].distance+"m, Time : "+instruct_end[i].duration+"s, Do : "+instruct_end[i].instruction+"\n";
		}
	}
	parragraphe.setAttribute('style', 'white-space: pre-line;');
}

function getPosition(){
	if (window.navigator.geolocation) {
		var location;
		window.navigator.geolocation.getCurrentPosition(getUserCoord,console.log);
	} 
}

function getUserCoord(value){
	start = value.coords.latitude+","+value.coords.longitude;
	var val = document.getElementById("a3");
	val.value = "Position set";
}

function search(){
	var parra = document.getElementById("instruc");
	var input_start = document.getElementById("a3").value;
	var input_end = document.getElementById("a5").value;
	input_start = input_start.replace(' ','+');
	input_end = input_end.replace(' ','+');
	var isCoord = "no";
	if(input_start==="Position+set"){
		isCoord = "yes";
		input_start = start;
	}
	if(input_start==="" || input_end===""){
		parra.textContent = "You need a start position and a destination !"
	}
	else{
		parra.textContent = "Please wait..."
		console.log(input_start);
		console.log(input_end);
		console.log(isCoord);
		callAPI("http://localhost:8733/Design_Time_Addresses/RoutingBikes/ServiceRest/getPath",'GET',input_start,input_end, isCoord,displayValue);
	}
}


/*
Rue Barsotti Marseille
Boulevard Magnan Marseille*/
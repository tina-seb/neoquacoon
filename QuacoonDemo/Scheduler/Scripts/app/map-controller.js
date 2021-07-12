$(document).ready(function () {
        var map = L
        .map('mapid')
        .setView([39.7, -86], 8);   // center position + zoom

            var link = {type: "LineString", coordinates: [[-82.9988, 39.9612], [-73.935242, 40.730610]] } // Change these data to see how the great circle reacts

            L.tileLayer(
                'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a>',
                maxZoom: 6,
            }).addTo(map);

            // Add a svg layer to the map
            L.svg().addTo(map);

            // Create data for circles:
            var markers = [
                {long: -82.9988, lat: 39.9612 }, // columbus
                {long: -73.935242, lat: 40.730610 }, // New York
                {long: -87, lat: 41 }, // Chicago
                {long: 3.075, lat: 50.640 }, // Lille
                {long: -3.83, lat: 48 }, // Morlaix
            ];

            // Create data for circles:
            var pickup = [
                {long: -86.148003, lat: 39.791000 }, // Indiana
            ];

            // Select the svg area and add circles:
            d3.select("#mapid")
                .select("svg")
                .selectAll("myCircles")
                .data(markers)
                .enter()
                .append("circle")
                .attr("cx", function (d) { return map.latLngToLayerPoint([d.lat, d.long]).x })
                .attr("cy", function (d) { return map.latLngToLayerPoint([d.lat, d.long]).y })
                .attr("r", 14)
                .style("fill", "red")
                .attr("stroke", "red")
                .attr("stroke-width", 3)
                .attr("fill-opacity", .4)


            // Select the svg area and add circles:
            d3.select("#mapid")
                .select("svg")
                .selectAll("myCircles")
                .data(pickup)
                .enter()
                .append("circle")
                .attr("cx", function (d) { return map.latLngToLayerPoint([d.lat, d.long]).x })
                .attr("cy", function (d) { return map.latLngToLayerPoint([d.lat, d.long]).y })
                .attr("r", 14)
                .style("fill", "blue")
                .attr("stroke", "blue")
                .attr("stroke-width", 3)
                .attr("fill-opacity", .4)

            // Function that update circle position if something change
            function update() {
            d3.selectAll("circle")
                .attr("cx", function (d) { return map.latLngToLayerPoint([d.lat, d.long]).x })
                .attr("cy", function (d) { return map.latLngToLayerPoint([d.lat, d.long]).y })
        }

            // If the user change the map (zoom or drag), I update circle position:
            map.on("moveend", update)


    var svg = d3.select("svg"),
        width = +svg.attr("width"),
        height = +svg.attr("height");

    // Map and projection
   /* var projection = d3.geoMercator()
        .scale(85)
        .translate([width / 2, height / 2 * 1.3]) */

    var projection = d3.geoMercator()

    var link = { type: "LineString", coordinates: [[-82.9988, 39.9612], [-73.935242, 40.730610]] } // Change these data to see how the great circle reacts

    // A path generator
    var path = d3.geoPath()
        .projection(projection)

    // Load world shape

    //https://raw.githubusercontent.com/holtzy/D3-graph-gallery/master/DATA/world.geojson
    //https://raw.githubusercontent.com/shawnbot/topogram/master/data/us-states.geojson
     d3.json("https://raw.githubusercontent.com/PublicaMundi/MappingAPI/master/data/geojson/us-states.json", function (data) {
   // d3.json("https://raw.githubusercontent.com/holtzy/D3-graph-gallery/master/DATA/world.geojson", function (data) {
        // Draw the map
      /*  svg.append("g")
            .selectAll("path")
            .data(data.features)
            .enter().append("path")
            .attr("fill", "black")
            .attr("d", d3.geoPath()
                .projection(projection)
            )
            .style("stroke", "#fff")
            .style("stroke-width", 0) */

        // Add the path
        svg.append("path")
            .attr("d", path(link))
            .style("fill", "none")
            .style("stroke", "yellow")
            .style("stroke-width", 4)

    });

}); 




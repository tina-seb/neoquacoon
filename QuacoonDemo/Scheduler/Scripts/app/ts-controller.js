$(document).ready(function () {
    alert(" in loadSVG");
    // The svg


    var svg = d3.select("svg"),
        width = +svg.attr("width"),
        height = +svg.attr("height");

    // Map and projection
    var projection = d3.geoMercator()
        .scale(100)
      //  .translate([width / 2, height / 2 * 1.3])

    // Create data: coordinates of start and end
   // var link = { type: "LineString", coordinates: [[100, 60], [-60, -30]] } // Change these data to see how the great circle reacts

    var link = { type: "LineString", coordinates: [[-82.9988, 39.9612], [-60, -30]] } // Change these data to see how the great circle reacts

   // var link1 = { type: "LineString", coordinates: [[-155.54211, 19.08348], [77.837451, 35.49401]] } // Change these data to see how the great circle reacts

    // A path generator
    var path = d3.geoPath()
        .projection(projection)

    // Create data: coordinates of start and end
    //var link1 = { type: "LineString", coordinates: [[200, 120], [-120, -60]] } // Change these data to see how the great circle reacts

    // Load world shape

    //https://raw.githubusercontent.com/holtzy/D3-graph-gallery/master/DATA/world.geojson
    //https://raw.githubusercontent.com/shawnbot/topogram/master/data/us-states.geojson
    // d3.json("https://raw.githubusercontent.com/PublicaMundi/MappingAPI/master/data/geojson/us-states.json", function (data) {
    d3.json("https://raw.githubusercontent.com/holtzy/D3-graph-gallery/master/DATA/world.geojson", function (data) {
        // Draw the map
        svg.append("g")
            .selectAll("path")
            .data(data.features)
            .enter().append("path")
            .attr("fill", "black")
            .attr("d", d3.geoPath()
                .projection(projection)
            )
            .style("stroke", "#fff")
            .style("stroke-width", 0)

        // Add the path
        svg.append("path")
            .attr("d", path(link))
            .style("fill", "none")
            .style("stroke", "yellow")
            .style("stroke-width", 4)

        // Add the path
        svg.append("path")
            .attr("d", path(link1))
            .style("fill", "none")
            .style("stroke", "red")
            .style("stroke-width", 4)

    });

}); 




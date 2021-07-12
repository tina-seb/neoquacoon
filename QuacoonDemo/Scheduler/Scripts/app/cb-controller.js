$(document).ready(function () {
    $('#qtable td').click(function () {
        var id = $(this).attr('id');
        var col = $(this).css('background-color');

        if ($(this).css('background-color') == "rgb(0, 0, 128)") $(this).css('background-color', 'white');
        else if ($(this).css('background-color') != "rgb(0, 0, 128)") $(this).css('background-color', 'navy');

    });

    $('#qbutton').click(function () {
        setTimeout(function () {
            $('#select1').delay("slow").css('background-color', 'navy');

        }, 2000); 
        setTimeout(function () {
            $('#select2').delay("slow").css('background-color', 'navy');

        }, 2000); 
        setTimeout(function () {
            $('#select3').delay("slow").css('background-color', 'navy');

        }, 2000); 
        setTimeout(function () {
            $('#select4').delay("slow").css('background-color', 'navy');

        }, 2000); 
        setTimeout(function () {
            $('#select5').delay("slow").css('background-color', 'navy');

        }, 2000); 
        setTimeout(function () {
            $('#select6').delay("slow").css('background-color', 'navy');

        }, 2000); 
        setTimeout(function () {
            $('#select7').delay(2000).css('background-color', 'navy');

        }, 2000); 
        setTimeout(function () {
            $('#select8').delay(2000).css('background-color', 'navy');

        }, 2000); 
        setTimeout(function () {
            $('#select9').delay(2000).css('background-color', 'navy');

        }, 2000); 
        setTimeout(function () {
            $('#select10').delay(2000).css('background-color', 'navy');

        }, 2000); 
        setTimeout(function () {
            $('#select11').delay(2000).css('background-color', 'navy');

        }, 2000); 
        setTimeout(function () {
            $('#select12').delay(2000).css('background-color', 'navy');

        }, 2000); 
        setTimeout(function () {
            $('#select13').delay(2000).css('background-color', 'navy');

        }, 2000); 
        setTimeout(function () {
            $('#select14').delay(2000).css('background-color', 'navy');

        }, 2000); 
        setTimeout(function () {
            $('#select15').delay(2000).css('background-color', 'navy');

        }, 2000); 

        setTimeout(function () {
            $("#timetaken").css("visibility", "visible");

        }, 5000); 

    });

    $('#submitbutton').click(function () {
        var correct_count = 0;
        if ($('#Sarah_1').css('background-color') == "rgb(0, 0, 128)") correct_count = correct_count + 1;
        if ($('#Sarah_6').css('background-color') == "rgb(0, 0, 128)") correct_count = correct_count + 1;
        if ($('#Sarah_10').css('background-color') == "rgb(0, 0, 128)") correct_count = correct_count + 1;

        if ($('#Tina_2').css('background-color') == "rgb(0, 0, 128)") correct_count = correct_count + 1;
        if ($('#Tina_9').css('background-color') == "rgb(0, 0, 128)") correct_count = correct_count + 1;
        if ($('#Tina_14').css('background-color') == "rgb(0, 0, 128)") correct_count = correct_count + 1;

        if ($('#Alyssa_4').css('background-color') == "rgb(0, 0, 128)") correct_count = correct_count + 1;
        if ($('#Alyssa_12').css('background-color') == "rgb(0, 0, 128)") correct_count = correct_count + 1;
        if ($('#Alyssa_15').css('background-color') == "rgb(0, 0, 128)") correct_count = correct_count + 1;

        if ($('#Aaron_3').css('background-color') == "rgb(0, 0, 128)") correct_count = correct_count + 1;
        if ($('#Aaron_8').css('background-color') == "rgb(0, 0, 128)") correct_count = correct_count + 1;
        if ($('#Aaron_13').css('background-color') == "rgb(0, 0, 128)") correct_count = correct_count + 1;

        if ($('#Joe_5').css('background-color') == "rgb(0, 0, 128)") correct_count = correct_count + 1;
        if ($('#Joe_7').css('background-color') == "rgb(0, 0, 128)") correct_count = correct_count + 1;
        if ($('#Joe_11').css('background-color') == "rgb(0, 0, 128)") correct_count = correct_count + 1;

        var accuracy = (correct_count / 15) * 100;
        $("#accuracy").css("visibility", "visible");
        $('#accuracyspan').text(accuracy);
    });

});

/*$(document).ready(function () {
    alert(" in loadSVG");
    // The svg


    var svg = d3.select("svg"),
        width = +svg.attr("width"),
        height = +svg.attr("height");

    // Map and projection
    var projection = d3.geoMercator()
        .scale(85)
        .translate([width / 2, height / 2 * 1.3])

    // Create data: coordinates of start and end
   // var link = { type: "LineString", coordinates: [[100, 60], [-60, -30]] } // Change these data to see how the great circle reacts

    var link = { type: "LineString", coordinates: [[100, 60], [-60, -30]] } // Change these data to see how the great circle reacts

    var link1 = { type: "LineString", coordinates: [[-155.54211, 19.08348], [77.837451, 35.49401]] } // Change these data to see how the great circle reacts

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

}); */




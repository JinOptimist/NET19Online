$(document).ready(function () {
    let currentLatitude;
    let currentLongitude;

    init();
    $('.location').change(function () {
        const coordinateStr = $('.location').val(); // "[53, 27]"
        if (!coordinateStr) {
            updateTemperature(currentLatitude, currentLongitude);
        } else {
            const [latitude, longitude] = JSON.parse(coordinateStr); // [53, 27]
            updateTemperature(latitude, longitude);
        }
    })

    function init() {
        google.charts.load('current', { 'packages': ['corechart'] });
        navigator.geolocation.getCurrentPosition(
            function (position) {

                currentLatitude = position.coords.latitude;
                currentLongitude = position.coords.longitude;

                console.log(`latitude ${currentLatitude}`);
                console.log(`longitude ${currentLongitude}`);
                updateTemperature(currentLatitude, currentLongitude);
            },
            function () {
                console.log("Error");
            });
    }

    function updateTemperature(latitude, longitude) {
        $('.current-temperature').text('***');

        $.get(`/api/Weather/GetWeather?latitude=${latitude}&longitude=${longitude}`)
            .then(function (weatherData) {
                $('.current-temperature').text(weatherData.currentTemperature);
                drawChart(weatherData);
            });
    }

    function drawChart(weatherData) {
        const processedData = weatherData
            .temperatures
            .map(x=> [x[0], x[1] - 0]);
        // Create the data table.
        var data = google.visualization.arrayToDataTable([
            ['Hour', 'Temperature'],
            ...processedData
        ]);


        // Set chart options
        var options = {
            title: 'Temperature',
            curveType: 'function',
            legend: { position: weatherData.unitsOfMeasurement }
        };

        // Instantiate and draw our chart, passing in some options.
        var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
        chart.draw(data, options);
    }
});
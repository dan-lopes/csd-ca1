function drawChart() {

    let systolic = parseInt($("#BP_Systolic").val());
    let diastolic = parseInt($('#BP_Diastolic').val());

    let data_systolic = google.visualization.arrayToDataTable([
        ['Label', 'Value'],
        ['Systolic', systolic ]
    ]);

    let data_diastolic = google.visualization.arrayToDataTable([
        ['Label', 'Value'],
        ['Diastolic', diastolic ]
    ]);

    let options_systolic = {
        width: 300, height: 200,
        min: 70, max: 190,
        greenFrom: 90, greenTo: 120,
        yellowFrom: 120, yellowTo: 140,
        redFrom: 140, redTo: 190,
        majorTicks: 0,
        minorTicks: 0
    };

    let options_diastolic = {
        width: 300, height: 200,
        min: 40, max: 100,
        greenFrom: 60, greenTo: 80,
        yellowFrom: 80, yellowTo: 90,
        redFrom: 90, redTo: 100,
        majorTicks: 0,
        minorTicks: 0
    };

    let chart_systolic = new google.visualization.Gauge(document.getElementById('chart_div_systolic'));
    let chart_diastolic = new google.visualization.Gauge(document.getElementById('chart_div_diastolic'));

    chart_systolic.draw(data_systolic, options_systolic);
    chart_diastolic.draw(data_diastolic, options_diastolic);
}
window.generateHistogram = (element, config) =>
{
    let chartElement = document.getElementById(element).getContext('2d');
    new Chart(chartElement, config);
}

window.destroyHistogram = (element) =>
{
    let chart = Chart.getChart(element);
    if (chart != undefined)
    {
        chart.destroy();
    }
}
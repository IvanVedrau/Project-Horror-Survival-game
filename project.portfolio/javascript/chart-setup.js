document.addEventListener('DOMContentLoaded', function() {
    let frameworksEnginesChart, languagesChart, programmingLanguagesChart, toolsChart;

    const updateCharts = () => {
        const isDarkMode = document.body.classList.contains('dark');
        
        const fontColor = 'rgba(92, 98, 236)'; 
        //const fontColor = isDarkMode ? 'white' : 'black';  // Set font color based on dark mode const fontColor = 'rgba(92, 98, 236)'; 

        const commonOptions = {
            responsive: true,
            maintainAspectRatio: false,
            indexAxis: 'y',
            plugins: {
                legend: {
                    display: false
                }
            },
            scales: {
                x: {
                    beginAtZero: true,
                    suggestedMax: 100,
                    display: true,
                    ticks: {
                        color: fontColor  // Dynamic font color
                    }
                },
                y: {
                    grid: {
                        drawBorder: false,
                        display: false
                    },
                    ticks: {
                        color: fontColor, // Dynamic font color
                        display: true
                    }
                }
            }
        };

        // Destroy existing charts if they exist
        if (frameworksEnginesChart) frameworksEnginesChart.destroy();
        if (languagesChart) languagesChart.destroy();
        if (programmingLanguagesChart) programmingLanguagesChart.destroy();

        const frameworksEnginesCtx = document.getElementById('frameworksEnginesChart').getContext('2d');
        frameworksEnginesChart = new Chart(frameworksEnginesCtx, {
            type: 'bar',
            data: {
                labels: ['Unity', 'Unreal Engine'],
                datasets: [{
                    label: 'Proficiency Level',
                    data: [60, 20],
                    backgroundColor: 'rgba(92, 98, 236)',
                    borderColor: 'black',
                    borderWidth: 1,
                    barThickness: 100,
                }]
            },
            options: commonOptions
        });

        const languagesCtx = document.getElementById('languagesChart').getContext('2d');
        languagesChart = new Chart(languagesCtx, {
            type: 'bar',
            data: {
                labels: ['English', 'German', 'Russian', 'Finnish', 'Swedish', 'Belarusian'],
                datasets: [{
                    label: 'Proficiency Level',
                    data: [80, 20, 95, 50, 10, 95],
                    backgroundColor: 'rgba(92, 98, 236)',
                    borderColor: 'black',
                    borderWidth: 1,
                    barThickness: calculateBarThickness(6),
                }]
            },
            options: commonOptions
        });

        const programmingLanguagesCtx = document.getElementById('programmingLanguagesChart').getContext('2d');
        programmingLanguagesChart = new Chart(programmingLanguagesCtx, {
            type: 'bar',
            data: {
                labels: ['C++', 'C#', 'HTML', 'CSS', 'JavaScript'],
                datasets: [{
                    label: 'Self-evaluated Proficiency Level',
                    data: [30, 30, 50, 50, 10],
                    backgroundColor: 'rgba(92, 98, 236)',
                    borderColor: 'black',
                    borderWidth: 1,
                    barThickness: calculateBarThickness(5),
                }]
            },
            options: commonOptions
        });

        const toolsCtx = document.getElementById('toolsChart').getContext('2d');
toolsChart = new Chart(toolsCtx, {
    type: 'bar',
    data: {
        labels: ['Visual Studio', 'Git', 'Photoshop', 'Blender'],
        datasets: [{
            label: 'Proficiency Level',
            data: [40, 20, 40, 30],
            backgroundColor: 'rgba(92, 98, 236)',
            borderColor: 'black',
            borderWidth: 1,
            barThickness: calculateBarThickness(4),
        }]
    },
    options: commonOptions 
});


        function calculateBarThickness(numberOfItems) {
            const baseThickness = 20;
            const maxThickness = 50;
            let calculatedThickness = baseThickness + (100 / numberOfItems);
            return Math.min(calculatedThickness, maxThickness);
        }
    };

    updateCharts();  // Call this function initially to setup charts

    // Toggle dark mode and update charts
    const btnDarkMode = document.querySelector(".dark-mode-btn");
    btnDarkMode.onclick = function () {
        document.body.classList.toggle("dark");
        updateCharts();  // Update charts whenever dark mode is toggled

        const isDark = document.body.classList.contains('dark');
        localStorage.setItem('darkMode', isDark ? 'dark' : 'light');
    };
});

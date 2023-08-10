let genderCount = [0, 0];
let majorName = [];
let majorCount = {};
let majorCountArr = [];
let majorNameArr = [];
//asynchronous javascript

//major Count
$.ajax({
    url: "https://localhost:7123/api/educations"
}).done((result) => {
    $.each(result.data, (key, val) => {
        //major Count
        majorName.push(val.major);
    });

    majorName.forEach((element) => {
        majorCount[element] = (majorCount[element] || 0) + 1;
    });

    for (const key in majorCount) {
        majorNameArr.push(key);
        majorCountArr.push(majorCount[key]);
    }

    //genderChart
    const ctx = $('#majorChart');
    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: majorNameArr,
            datasets: [{
                label: 'Major',
                data: majorCountArr,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(255, 159, 64, 0.2)',
                    'rgba(255, 205, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(201, 203, 207, 0.2)'
                ],
                borderColor: [
                    'rgb(255, 99, 132)',
                    'rgb(255, 159, 64)',
                    'rgb(255, 205, 86)',
                    'rgb(75, 192, 192)',
                    'rgb(54, 162, 235)',
                    'rgb(153, 102, 255)',
                    'rgb(201, 203, 207)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        },
    });
});


//gender Count
$.ajax({
    url: "https://localhost:7123/api/employees/"
}).done((result) => {
    $.each(result.data, (key, val) => {
        //gender Count
        val.gender === 0 ? genderCount[0]++ : genderCount[1]++;
    });
    //genderChart
    const ctx = $('#genderChart');
    new Chart(ctx, {
        type: 'pie',
        data: {
            labels: [
                'Female',
                'Male'
            ],
            datasets: [{
                label: 'Count',
                data: genderCount,
                backgroundColor: [
                    'rgb(255, 99, 132)',
                    'rgb(54, 162, 235)'
                ]
            }]
        }
    });
});
    

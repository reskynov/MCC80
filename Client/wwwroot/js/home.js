let genderCount = [0, 0];
let majorName = [];
let majorCount = [];
//asynchronous javascript

//major Count
$.ajax({
    url: "https://localhost:7123/api/educations"
}).done((result) => {
    $.each(result.data, (key, val) => {
        //major Count
        majorName.push(val.major);
    });
    majorName.forEach((element, index) => {
        majorCount[index] = (majorCount[index] || 0) + 1;
    });
    console.log(majorCount)
    //genderChart
    //const ctx = $('#genderChart');
    //new Chart(ctx, {
    //    type: 'pie',
    //    data: {
    //        labels: [
    //            'Female',
    //            'Male'
    //        ],
    //        datasets: [{
    //            label: 'Count',
    //            data: genderCount,
    //            backgroundColor: [
    //                'rgb(255, 99, 132)',
    //                'rgb(54, 162, 235)'
    //            ]
    //        }]
    //    }
    //});
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
    

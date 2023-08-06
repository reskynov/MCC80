//asynchronous javascript
$.ajax({
    url: "https://swapi.dev/api/people/"
}).done((result) => {
    let temp = "";
    let no = 1;
    $.each(result.results, (key, val) => {
        temp += `<tr>
                    <th>${no++}</th>
                    <td>${val.name}</td>
                    <td>${val.gender}</td>
                    <td>${val.birth_year}</td>
                    <td>${val.height}</td>
                    <td>${val.mass}</td>
                </tr>`
    })
    $("#tableSW").html(temp);
});

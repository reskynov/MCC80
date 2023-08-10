
$(document).ready(function () {
    //tambah data
    $('#submitButton').bind('click', function (e) {
        e.preventDefault();
        let newEmployee = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
        //ini ngambil value dari tiap inputan di form nya
        newEmployee.FirstName = $("#firstName").val();
        newEmployee.LastName = $("#lastName").val();
        newEmployee.BirthDate = $("#birthDate").val();
        newEmployee.Gender = parseInt($('input[name="options"]:checked').val());
        newEmployee.HiringDate = $("#hiringDate").val();
        newEmployee.Email = $("#email").val();
        newEmployee.PhoneNumber = $("#phoneNumber").val();
        console.log(newEmployee)
        //newEmployee.Degree = $("#degree").val();
        //newEmployee.Major = $("#major").val();
        //newEmployee.GPA = $("#gpa").val();
        //newEmployee.UniversityCode = $("#universityCode").val();
        //newEmployee.UniversityName = $("#universityName").val();
        //newEmployee.Password = $("#password").val();
        //newEmployee.ConfirmPassword = $("#confirmPassword").val();
        //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
        $.ajax({
            url: "https://localhost:7123/api/employees",
            type: "POST",
            data: JSON.stringify(newEmployee),
            dataType: "json",
            contentType: "application/json"
            //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
        }).done((result) => {
            alert("Success");
            location.reload();
        }).fail((error) => {
            console.log(error)
            alert("Failed");
        });
    });
});

//Tampilkan data
let table = new DataTable('#employeeTable', {
    ajax: {
        url: "https://localhost:7123/api/employees",
        dataSrc: "data",
        dataType: "JSON"
    },
    columns: [
        {
            "data": "no",
            render: function (data, type, row, meta) {
                return meta.row + 1;
            }
        },
        { data: "nik" },
        { data: "firstName" },
        {
            data: 'gender',
            render: function (data, type, row) {
                return data === 0 ? "Female" : "Male";
            }
        },
        {
            data: 'birthDate',
            render: function (data, type, row) {
                // Parse the date string to a JavaScript Date object
                const dateBirth = new Date(data);

                // Format the date as "DD/MM/YYYY"
                return dateBirth.toLocaleDateString('en-GB');
            }
        },
        { data: "email" },
        { data: "phoneNumber" },
        {
            data: 'hiringDate',
            render: function (data, type, row) {
                // Parse the date string to a JavaScript Date object
                const dateBirth = new Date(data);

                // Format the date as "DD/MM/YYYY"
                return dateBirth.toLocaleDateString('en-GB');
            }
        },
        {
            data: '',
            render: function (data, type, row) {
                let actionButton = `<button type="button" onclick="deleteEmployee(${row.guid})" data-bs-toggle="modal" data-bs-target="#modalDeleteEmployee" class="btn btn-danger">Delete</button>`;
                return actionButton;
            }
        }
    ],
    dom: 'Blfrtip',
    buttons: [
        'copy', 'csv', 'excel', 'pdf', 'print', 
        { extend: 'colvis', text: 'Show/Hide columns', className: 'btn btn-primary' }
    ]
});

//delete data
function deleteEmployee(guidEmployee) {
    $.ajax({
        url: "https://localhost:7123/api/employees/?guid=" + guidEmployee,
        type: "DELETE"
    }).done((result) => {
        alert("Success");
        location.reload();
    }).fail((error) => {
        console.log(error)
        alert("Failed");
    });
}
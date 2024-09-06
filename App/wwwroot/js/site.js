function Response(data) {
    if (data['validationError'] == true) {
        var message = '<ul>';
        data['message'].forEach(function (element) {
            element.errors.forEach(function (error) {
                message += '<li>' + error.errorMessage + '</li>';
            });
        });
        message += '</ul>';
        Swal.fire({
            title: 'Warning!',
            html: message,
            icon: 'warning',
            confirmButtonColor: 'rgb(150, 41, 65)',
            confirmButtonText: 'Ok',
        });
    }
    else if (data['error'] == true) {
        Swal.fire({
            title: 'Warning!',
            html: data['message'],
            icon: 'warning',
            confirmButtonColor: 'rgb(150, 41, 65)',
            confirmButtonText: 'Ok',
        });
    }
    else {
        Swal.fire({
            title: 'Success',
            html: data['message'],
            confirmButtonColor: 'rgb(150, 41, 65)',
            confirmButtonText: 'Ok',
        });
        loadData();
    }
}

setInterval(function () {
    $.ajax({
        url: '/Accountant/UpdateLastSeen',
        type: 'POST',
        dataType: 'json',
        success: function (response) {
            console.log("updated login " + response);
        }
    });
},5000)
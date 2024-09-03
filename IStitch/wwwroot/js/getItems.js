function getItems()
{
    var number = $('#PhoneNumber').val();
    $.ajax({
        url: '/ServiceOrder/getCustomerServices',
        type: 'POST',
        data: { phoneNumber: number },
        success: function (result) {
            $('#Container').html(result);
        },
        error: function () {
            alert("An error occurred while processing your request.");
        }

    });
}
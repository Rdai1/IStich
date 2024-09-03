$(document).ready(function ()
{
    $('#CategoryName').change(function () {
        var categoryName = $(this).val();
        if (categoryName) {
            $.ajax({
                url: '/ServiceOrder/GetServicesByCategory',
                type: 'POST',
                data: { Category: categoryName },
                success: function (result) {
                    $('#serviceDropdownContainer').html(result);
                }
            });
        } else {
            $('#serviceDropdownContainer').html('<select id="serviceSelect" name="SerName" class="form-control"><option value="">-- Select Service --</option></select>');
        }
    });
});


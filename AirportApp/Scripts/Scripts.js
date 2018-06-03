
$(document).ready(function () {

    //setInterval("$('#BodyContent').load('Airport/AirportList')",10);  

    $(document.body).on('change', '#Country', function () {
        var country = $('#Country').val();     
        $.ajax({
            type: "POST",
            url: "/Airport/AirportListBasedOnCountrySelection",
            contentType: "application/json; charset=utf-8",
            data: '{"ISO":"' + country + '"}',
            dataType: "html",
            success: function (data) {
                $("#CountryList").html(data);
            }
        });
    });  


    $("#FindDistance").click(function (e) {
        var source = $('#Source').val();
        var destination = $('#Destination').val();        
            $.ajax({
                type: "POST",
                url: "/Airport/CalculateDistance",
                contentType: "application/json; charset=utf-8",
                data: '{"Source":"' + source + '","Destination":"' + destination + '"}',
                dataType: "Json",
                success: function (data) {
                    $("#Distance").html(data.DistanceBetween +' KM');
                }               
            });
    });
});  

function updateCity(id) {
    var cityName = $("#cityEdit_" + id).val()
    $.ajax({
        url: "/ConfigureCities/UpdateCity",
        type: "POST",
        data: {
            id: id,
            cityName: cityName
        }
    })
}
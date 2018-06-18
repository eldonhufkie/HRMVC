app.service("HomeController", function ($http) {

    //get All Adverts
    this.getAdverts = function () {
        return $http.get('/Home/GetAdvertList')
    };

    // get Advert by advertId
    this.getAdvert = function (advertId) {
        var response = $http({
            method: "post",
            url: "Home/GetAdvertById/",
            params: {
                id: JSON.stringify(advertId)
            }
        });
        return response;
    }

    // Update Advert 
    this.updateAdvert = function (advert) {
        var response = $http({
            method: "post",
            url: "Home/UpdateAdvert",
            data: JSON.stringify(advert),
            dataType: "json"
        });
        return response;
    }

    // Add Advert
    this.AddAdvert = function (advert) {
        var response = $http({
            method: "post",
            url: "Home/AddAdvert",
            data: JSON.stringify(advert),
            dataType: "json"
        });
        return response;
    }

    //Delete Advert
    this.DeleteAdvert = function (advertId) {
        var response = $http({
            method: "post",
            url: "Home/DeleteAdvert",
            params: {
                advertId: JSON.stringify(advertId)
            }
        });
        return response;
    }
});

//app.controller('HomeController',
//    function ($scope, $http) {
//        $http.get('/Home/GetAdvertList').then(function (d) {
//            $scope.ads = d.data;
//        },
//            function (error) {
//                alert('Failed');
//            });
//    });


//app.controller('HomeController',
//    function ($scope, $http) {
//        $http.get('/Home/AjaxGetList').then(function (d) {
//            $scope.ads = d.data;
//        },
//            function (error) {
//                alert('Failed');
//            });
//    }

//);
app.controller("HomeController", function ($scope, crudAJService) {
    $scope.divAdvert = false;
    GetAllAdverts();
    //To Get all book records  
    function GetAllAdverts() {
        debugger;
        var getAdvertData = crudAJService.getAdverts();
        getAdvertData.then(function (book) {
            $scope.books = book.data;
        }, function () {
            alert('Error in getting book records');
        });
    }

    $scope.editAdvert = function (book) {
        var getAdvertData = crudAJService.getAdvert(book.Id);
        getAdvertData.then(function (_book) {
            $scope.book = _book.data;
            $scope.bookId = book.Id;
            $scope.bookTitle = book.Title;
            $scope.bookAuthor = book.Author;
            $scope.bookPublisher = book.Publisher;
            $scope.bookIsbn = book.Isbn;
            $scope.Action = "Update";
            $scope.divAdvert = true;
        }, function () {
            alert('Error in getting book records');
        });
    }

    $scope.AddUpdateAdvert = function () {
        var Advert = {
            Title: $scope.bookTitle,
            Author: $scope.bookAuthor,
            Publisher: $scope.bookPublisher,
            Isbn: $scope.bookIsbn
        };
        var getAdvertAction = $scope.Action;

        if (getAdvertAction == "Update") {
            Advert.Id = $scope.bookId;
            var getAdvertData = crudAJService.updateAdvert(Advert);
            getAdvertData.then(function (msg) {
                GetAllAdverts();
                alert(msg.data);
                $scope.divAdvert = false;
            }, function () {
                alert('Error in updating book record');
            });
        } else {
            var getAdvertData = crudAJService.AddAdvert(Advert);
            getAdvertData.then(function (msg) {
                GetAllAdverts();
                alert(msg.data);
                $scope.divAdvert = false;
            }, function () {
                alert('Error in adding book record');
            });
        }
    }

    $scope.AddAdvertDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.divAdvert = true;
    }

    $scope.deleteAdvert = function (book) {
        var getAdvertData = crudAJService.DeleteAdvert(book.Id);
        getAdvertData.then(function (msg) {
            alert(msg.data);
            GetAllAdverts();
        }, function () {
            alert('Error in deleting book record');
        });
    }

    function ClearFields() {
        $scope.bookId = "";
        $scope.bookTitle = "";
        $scope.bookAuthor = "";
        $scope.bookPublisher = "";
        $scope.bookIsbn = "";
    }
    $scope.Cancel = function () {
        $scope.divAdvert = false;
    };
});
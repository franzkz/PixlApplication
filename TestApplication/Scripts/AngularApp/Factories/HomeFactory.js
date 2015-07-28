var HomeFactory = function ($http) {

    var HomeFactory = {};

    HomeFactory.getOrders = function (data) {
        return $http.get('api/pixlapi/getorders', {
            params: data
        });
    };

    return (HomeFactory);
}

HomeFactory.$inject = ['$http'];
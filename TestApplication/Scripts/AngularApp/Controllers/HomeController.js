var HomeController = function($scope, HomeFactory) {
    $scope.model = {
        orders: [],
        errorMessage: undefined,
        skip: 0,
        take: 10,
        AccessToken: '',
        endList: false,
        isAjaxInProgress: true //We  initially  load  data  so set  the  isAjaxInProgress  =  true; 
    };

    //Load orderss
    $scope.getOrderList = function(next) {
        $scope.model.isAjaxInProgress = true;
        if ($scope.model.AccessToken === '') {
            $scope.model.AccessToken = document.getElementById('accessToken').value;
        }
        if (!$scope.model.endList) {
            if (next) {
                $scope.model.skip += $scope.model.take;
            }

            var data = {
                accessToken: $scope.model.AccessToken,
                take: $scope.model.take,
                skip: $scope.model.skip
            };

            HomeFactory.getOrders(data)
                .success(function(prod) {
                    for (var i = 0; i < prod.Result.length; i++) {
                        $scope.model.orders.push(prod.Result[i]);
                    }
                    $scope.model.isAjaxInProgress = false;
                    if (prod.Result.length < $scope.model.take) {
                        $scope.model.endList = true;
                    }
                })
                .error(function(error) {
                    $scope.model.errorMessage = 'Unable to load data: ' + error.message;
                    $scope.model.isAjaxInProgress = false;
                });
        }
    }
}
HomeController.$inject = ['$scope', 'HomeFactory'];
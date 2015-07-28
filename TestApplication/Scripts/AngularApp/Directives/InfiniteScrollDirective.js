var infiniteScrollDirective = function ($window, $document) {
    return {
        restrict: 'A',
        link: function ($scope, $element, attrs) {
            var $win = angular.element($window);
            var document = $document[0];
            var wrapper = document.getElementsByClassName('wrapper')[0];

            function windowHeight() {
                var height = document.documentElement.clientHeight;
                return height;
            }

            function scrollTop() {
                var scroll = window.pageYOffset || document.documentElement.scrollTop;
                return scroll;
            }

            function clientHeight() {
                return wrapper.clientHeight - 20;
            }

            function onScroll() {
                var needScroll = (windowHeight() + scrollTop() - clientHeight()) > 0;

                if (needScroll) {
                    $scope.$apply(attrs.infiniteScroll);
                }
            }

            function onDestroy() {
                $win.unbind('scroll', onScroll);
            }

            $scope.$on('$destroy', onDestroy);

            $win.bind('scroll', onScroll);
        }
    };
};
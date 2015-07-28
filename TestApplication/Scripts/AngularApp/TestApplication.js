var TestApplication = angular.module('TestApplication',
    []);

TestApplication.controller('HomeController', HomeController);
TestApplication.factory('HomeFactory', HomeFactory);
TestApplication.directive('infiniteScroll', infiniteScrollDirective);

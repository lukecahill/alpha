﻿// script.js

// create the module and name it scotchApp
// also include ngRoute for all our routing needs
var app = angular.module('alphaApp', ['ngRoute', 'ui.bootstrap']);

// configure our routes
app.config(function ($routeProvider, $locationProvider) {

    //$locationProvider.html5Mode(true);
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'app/components/pages/home.html',
            controller: 'mainController'
        })

        // route for the about page
        .when('/about', {
            templateUrl: 'app/components/pages/about.html',
            controller: 'aboutController'
        })

        // route for the contact page
        .when('/games', {
            templateUrl: 'app/components/pages/games.html',
            controller: 'gamesController'
        })

        // route for the publishers page
        .when('/games/:gameId', {
            templateUrl: '../app/components/details/gameDetails.html',
            controller: 'gameIdController'
        })

        // route for the contact page
        .when('/publishers', {
            templateUrl: 'app/components/pages/publishers.html',
            controller: 'publisherController'
        })

        // route for the publishers page
        .when('/publishers/:publisherId', {
            templateUrl: 'app/components/details/publisherDetails.html',
            controller: 'publisherIdController'
        })

        // route for the contact page
        .when('/accessories', {
            templateUrl: 'app/components/pages/accessories.html',
            controller: 'accessoriesController'
        })

        // route for the contact page
        .when('/addons', {
            templateUrl: 'app/components/pages/addons.html',
            controller: 'addonsController'
        })

        // route for the contact page
        .when('/contact', {
            templateUrl: 'app/components/pages/contact.html',
            controller: 'contactController'
        })

        .otherwise({ redirectTo: '/' });
});

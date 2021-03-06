﻿var app = angular.module('alphaApp', ['ngRoute', 'ngAnimate','ui.bootstrap']);

// configure routes
app.config([ '$routeProvider', function ($routeProvider) {

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

        // route for the game summary page
        .when('/games', {
            templateUrl: 'app/components/pages/games.html',
            controller: 'gamesController'
        })

        // route for the games details page
        .when('/games/:gameId', {
            templateUrl: '../app/components/details/gameDetails.html',
            controller: 'gameIdController'
        })

        // route for the publishers summary page
        .when('/publishers', {
            templateUrl: 'app/components/pages/publishers.html',
            controller: 'publisherController'
        })

        // route for the publishers details page
        .when('/publishers/:publisherId', {
            templateUrl: 'app/components/details/publisherDetails.html',
            controller: 'publisherIdController'
        })

        // route for the accessories summary page
        .when('/accessories', {
            templateUrl: 'app/components/pages/accessories.html',
            controller: 'accessoriesController'
        })

        // route for the accessory details page
        .when('/accessories/:accessoryId', {
            templateUrl: 'app/components/details/accessoryDetails.html',
            controller: 'accessoryIdController'
        })

        // route for the addons summary page
        .when('/addons', {
            templateUrl: 'app/components/pages/addons.html',
            controller: 'addonsController'
        })

        // route for the addons details page
        .when('/addons/:addonId', {
            templateUrl: 'app/components/details/addonDetails.html',
            controller: 'addonIdController'
        })

        // route for the contact page
        .when('/contact', {
            templateUrl: 'app/components/pages/contact.html',
            controller: 'contactController'
        })

        // route for the login page
        .when('/login', {
            templateUrl: 'app/components/pages/login.html',
            controller: 'loginController'
        })

        // route for the register page
        .when('/register', {
            templateUrl: 'app/components/pages/register.html',
            controller: 'registerController'
        })

        // default to redirect to the home page.
        .otherwise({ redirectTo: '/' });
}]);

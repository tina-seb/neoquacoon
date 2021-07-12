angular.module('CardApp', ["chart.js"])
    .controller('CardCtrl', function ($scope, $http) {

        $scope.hideValue = true;
        $scope.cards = [];
        $scope.recos = [];

        $scope.budget = [
            {
            'name': 'Select Your Budget',
            'value': 'Select Your Budget'
            },
            {
                'name': '$0-$10',
                'value': '$0-$10'
            },
            {
            'name': '$10-$100',
            'value': '$10-$100'
        }, {
            'name': '$100-$1000',
            'value': '$100-$1000'
        }, {
            'name': '$1000-$10000',
            'value': '$1000-$10000'
        }, {
            'name': '$10000-$100000',
            'value': '$10000-$100000'
        }, {
            'name': '>$100000',
            'value': '>$100000'
        }];

        $scope.cart = {
            'tier': $scope.budget[0]
        };

        $scope.term = [{
            'name': 'Select Your Goal',
            'value': 'Select Your Goal'
        },
            {
            'name': 'Short Term Profit',
            'value': 'Short Term Profit'
        }, {
            'name': 'Long Term Profit',
            'value': 'Long Term Profit'
        }, {
            'name': 'Collectible',
            'value': 'Collectible'
        }];

        $scope.gart = {
            'fier': $scope.term[0]
        };


        /*$scope.init = function () {
            $http.get("api/reco/").then(function (response) {
                $scope.cards = response.data;
        })
            .catch(function (response) {
            })
            .finally(function () {
               
            });
        }; */

        $scope.filterreco = function () {

            document.getElementById("recoHeader").innerHTML = "";
            $scope.hideValue = false;

            var budget = $scope.cart.tier.name;
            var goal = $scope.gart.fier.name;

            if (budget == "Select Your Budget") {
                alert("Please select a budget first.");
                $scope.hideValue = true;
                return false;
            }

            if (goal == "Select Your Goal") {
                alert("Please select a goal first.");
                $scope.hideValue = true;
                return false;
            }


                var api_string = "api/filter?id=" + budget + ":" + goal;

                $http.get(api_string).then(function (response) {
                    $scope.cards = response.data;
                    if ($scope.cards != null && $scope.cards != []) {
                        document.getElementById("recoHeader").innerHTML = "Your Recommendations";
                    }
                })
                    .catch(function (response) {
                    })
                    .finally(function () {
                        $scope.hideValue = true;
                    });
        }; 

        $scope.getAdvancedView = function (card) {
            $scope.data = [[card.One, card.Two, card.Three, card.Four, card.Five, card.Six]];
        }

        function getRandomArbitrary(min, max) {
            return Math.random() * (max - min) + min;
        }

        $scope.labels = ["2020", "2021", "2022", "2023", "2024", "2025", "2026"];
        $scope.series = ['Series A'];
        $scope.data = [
            [getRandomArbitrary(1, 2), getRandomArbitrary(3, 5), getRandomArbitrary(6, 7), getRandomArbitrary(8, 10), getRandomArbitrary(11, 13), getRandomArbitrary(13, 15), getRandomArbitrary(15, 17)]
        ];
        $scope.onClick = function (points, evt) {
            console.log(points, evt);
        };
        $scope.datasetOverride = [{ yAxisID: 'y-axis-1' }, { yAxisID: 'y-axis-2' }];
        $scope.options = {
            scales: {
                yAxes: [
                    {
                        id: 'y-axis-1',
                        type: 'linear',
                        display: true,
                        position: 'left'
                    },
                    {
                        id: 'y-axis-2',
                        type: 'linear',
                        display: true,
                        position: 'right'
                    }
                ]
            }
        };

    });





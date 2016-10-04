module app.directives {

    function personInfo(): ng.IDirective {
        var directive: ng.IDirective = {
            templateUrl: 'app/templates/personInfo.html',
            scope: {
                person: '='
            }
        }
        return directive;
    }

    angular.module("app.directives").directive("personInfo", personInfo);
}
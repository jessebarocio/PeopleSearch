module app.directives {

    // Directive for rendering a Person object.
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
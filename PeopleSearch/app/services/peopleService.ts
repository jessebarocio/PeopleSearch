module app.services {

    export class PeopleService {

        searchByName(searchStr: string): ng.IHttpPromise<app.models.Person[]> {
            return this.$http.get("api/people/search/" + searchStr);
        }

        static $inject = ["$http"];
        constructor(private $http: ng.IHttpService) {

        }
    }

    angular.module("app.services").service("PeopleService", PeopleService);
}
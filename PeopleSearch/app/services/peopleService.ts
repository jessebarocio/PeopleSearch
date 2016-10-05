module app.services {

    // Service responsible for communication with the people API.
    export class PeopleService {

        searchByName(searchStr: string): ng.IHttpPromise<app.models.Person[]> {
            return this.$http.get("people/search/" + searchStr);
        }

        addPerson(person: app.models.Person): ng.IHttpPromise<app.models.Person> {
            return this.$http.post("people", person);
        }

        static $inject = ["$http"];
        constructor(private $http: ng.IHttpService) {

        }
    }

    angular.module("app.services").service("PeopleService", PeopleService);
}
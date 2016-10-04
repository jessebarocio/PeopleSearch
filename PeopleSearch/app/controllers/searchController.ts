module app.controllers {

    class SearchController {
        people: app.models.Person[];
        searchStr: string;

        search() {
            this.PeopleService.searchByName(this.searchStr)
                .then((response) => {
                    this.people = response.data;
                });
        }

        static $inject = ["PeopleService"];
        constructor(private PeopleService: app.services.PeopleService) {

        }
    }

    angular.module("PeopleSearch").controller("SearchController", SearchController);
}
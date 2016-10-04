module app.controllers {

    class SearchController {
        searching: boolean = false;
        people: app.models.Person[];
        searchStr: string;

        search() {
            // Clear existing search results
            this.people = [];
            // This will toggle some sort of UI state indicating a search is in progress
            this.searching = true;
            this.PeopleService.searchByName(this.searchStr)
                .then((response) => {
                    // Simulate a 3-second search
                    this.$timeout(3000).then((val) => {
                        // Hide the progress bar
                        this.searching = false;
                        this.people = response.data;
                    });
                });
        }

        static $inject = ["PeopleService", "$timeout"];
        constructor(private PeopleService: app.services.PeopleService,
                    private $timeout: ng.ITimeoutService) {

        }
    }

    angular.module("PeopleSearch").controller("SearchController", SearchController);
}
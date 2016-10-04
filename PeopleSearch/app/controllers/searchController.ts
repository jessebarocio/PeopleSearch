module app.controllers {

    class SearchController {
        searching: boolean = false;
        error: boolean = false;
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
                    this.$timeout(3000)
                        .then((val) => {
                            // Request succeeded. 
                            this.people = response.data;
                            // Hide the search progress bar
                            this.searching = false;
                        });
                }).catch((reason) => {
                    // Toggle an error state on the UI
                    this.error = true;
                    // Hide the search progress bar
                    this.searching = false;
                });
        }

        static $inject = ["PeopleService", "$timeout"];
        constructor(private PeopleService: app.services.PeopleService,
            private $timeout: ng.ITimeoutService) {

        }
    }

    angular.module("PeopleSearch").controller("SearchController", SearchController);
}
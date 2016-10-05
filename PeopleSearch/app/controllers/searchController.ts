module app.controllers {

    class SearchController {
        // UI state
        searching: boolean = false;
        error: boolean = false;
        // Data
        people: app.models.Person[];
        searchStr: string;

        search() {
            // Clear existing search results and errors
            this.people = [];
            this.error = false;
            // This will toggle something on the UI indicating a search is in progress
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
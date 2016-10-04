module app.controllers {

    class SearchController {
        showProgress: boolean = false;
        people: app.models.Person[];
        searchStr: string;

        search() {
            // Toggle the progress bar while waiting for result from server
            this.showProgress = true;
            this.PeopleService.searchByName(this.searchStr)
                .then((response) => {
                    // Simulate a 3-second search
                    this.$timeout(3000).then((val) => {
                        // Hide the progress bar
                        this.showProgress = false;
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
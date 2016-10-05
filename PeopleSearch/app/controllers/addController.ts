module app.controllers {

    class AddController {
        // UI state
        error: boolean = false;
        // Data
        person: app.models.Person = new app.models.Person();

        savePerson() {
            this.PeopleService.addPerson(this.person)
                .then((response) => {
                    window.location.hash = "/search";
                })
                .catch((err) => {
                    this.error = true;
                });
        }

        static $inject = ["PeopleService"];
        constructor(private PeopleService: app.services.PeopleService) {

        }
    }

    angular.module("PeopleSearch").controller("AddController", AddController);
}
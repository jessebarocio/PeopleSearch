module app.models {

    export interface Person {
        PersonId: number;
        FirstName: string;
        LastName: string;
        Address: string;
        City: string;
        State: string;
        Zip: string;
        Age: number;
        Interests: string;
    }
}
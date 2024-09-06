//A Person is a Class
var Person = /** @class */ (function () {
    //Constructor
    function Person(theFirstName, theLastName, theAge) {
        this.firstName = theFirstName;
        this.lastName = theLastName;
        this.age = theAge;
    }
    //Some member functions
    Person.prototype.greetFormally = function () {
        return 'Good Afternoon ' + this.firstName + ' ' + this.lastName + '.';
    };
    Person.prototype.greetInformally = function () {
        if (this.age > 48) {
            return 'Hello' + this.firstName + 'ya boomer.';
        }
        else {
            return 'Sup ' + this.firstName.charAt(0) + '.';
        }
    };
    return Person;
}());

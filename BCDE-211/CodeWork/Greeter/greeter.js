//
var Student = /** @class */ (function () {
    function Student(firstName, middleInitial, lastName) {
        this.firstName = firstName;
        this.middleInitial = middleInitial;
        this.lastName = lastName;
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
    return Student;
}());
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
            return 'Hello' + ' ' + this.firstName + ' ya boomer.';
        }
        else {
            return 'Sup ' + this.firstName.charAt(0) + '.';
        }
    };
    return Person;
}());
//
function personGreeter(person) {
    return person.greetInformally();
}
function studentGreeter(person) {
    return "Hello, " + person.firstName + " " + person.lastName;
}
//
var user = new Student("Jane", "M.", "User");
var aPerson = new Person('John', 'Doe', 69);
var elementMain = document.getElementsByTagName('main')[0];
elementMain.innerHTML = studentGreeter(user) + '<br>';
elementMain.innerHTML += personGreeter(aPerson);

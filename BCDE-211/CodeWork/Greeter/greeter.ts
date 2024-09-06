//
class Student {
    fullName: string;
    constructor(public firstName: string, public middleInitial: string, public lastName: string) {
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
}

//A Person is a Class
class Person {

    //Attributes
    private firstName: string
    private lastName: string
    private age: number

    //Constructor
    constructor(theFirstName: string, theLastName: string, theAge: number) {
        this.firstName = theFirstName
        this.lastName = theLastName
        this.age = theAge
    }

    //Some member functions
    public greetFormally(): string {
        return 'Good Afternoon ' + this.firstName + ' ' + this.lastName + '.'
    }

    public greetInformally(): string {
        if (this.age > 48) {
            return 'Hello' + ' ' + this.firstName + ' ya boomer.'
        } else {
            return 'Sup ' + this.firstName.charAt(0) + '.'
        }
    }
}


//
function personGreeter(person: Person) {
    return person.greetInformally();
}

function studentGreeter(person: Student) {
    return "Hello, " + person.firstName + " " + person.lastName;
}



//
let user = new Student("Jane", "M.", "User");
let aPerson = new Person('John', 'Doe', 69)  

let elementMain = document.getElementsByTagName('main')[0]
elementMain.innerHTML = studentGreeter(user) + '<br>';
elementMain.innerHTML += personGreeter(aPerson);
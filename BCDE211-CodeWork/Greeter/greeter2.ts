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
            return 'Hello' + this.firstName + 'ya boomer.'
        } else {
            return 'Sup ' + this.firstName.charAt(0) + '.'
        }
    }
}
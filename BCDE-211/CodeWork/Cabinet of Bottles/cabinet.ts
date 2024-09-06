class Cabinet {

    private allMyBottles
    private bottleCount

    constructor() {

        this.allMyBottles = []
        this.bottleCount = 0

    }

    public addBottle(bottleName, bottleType, bottleFlavour, bottleAge): void {

        let aNewBottle = new Bottle(bottleName, bottleType, bottleFlavour, bottleAge)
        if (!aNewBottle) {
            return
        } else {
            this.allMyBottles.push(aNewBottle)
            this.bottleCount += 1
        }
    }

    public getCount(): number {
        return this.bottleCount
    }

    public getAllMyBottles(): string {
        var returnstring = ""

        for (const Bottle of this.allMyBottles) {
            returnstring += 'The Bottle ' + Bottle.name + ' is a ' + Bottle.type + ' spirits and has a flavour of ' + Bottle.flavour + ' and is aged for a minimum time of ' + Bottle.age + ' years <br><br>'
        }

        return returnstring
    }
}
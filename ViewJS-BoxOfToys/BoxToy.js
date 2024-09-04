/* globals View */
class Toy {
  constructor (newName, newColor, newCost) {
    this.name = newName
    this.color = newColor
    this.cost = newCost
  }
  toString () {
    let result = `${this.name} ( ${this.color} ) @ $${this.cost.toFixed(2)}`
    return result
  }
}
class Box { // eslint-disable-line no-unused-vars
  constructor () {
    this.toyCount = 0
    this.allMyToys = []
  }
  addToy (newName, newColor, newCost) {
    let aNewToy = new Toy(newName, newColor, newCost)
    this.allMyToys.push(aNewToy)
    this.toyCount += 1
  }
  sortToys () {
    this.allMyToys.sort(function (a, b) {
      if (a.name < b.name) {
        return -1
      }
      if (a.name > b.name) {
        return 1
      } // a must be equal to b
      return 0
    })
  }
  toString () {
    this.sortToys()
    let result = `This toybox has ${this.toyCount} toys${View.NEWLINE()}`
    for (let aToy of this.allMyToys) {
      result += View.TAB() + aToy + View.NEWLINE()
    }
    return result
  }
}
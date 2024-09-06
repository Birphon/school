/* globals describe it xdescribe xit beforeEach expect BiomeList localStorage STORAGE_KEY */
describe('BiomeList', function () {
  var theBiomeList

  function getNames (allAchievements) {
    const allNames = []
    for (const aAchievement of allAchievements) {
      allNames.push(aAchievement.name)
    }
    return allNames
  }

  beforeEach(function () {
    theBiomeList = new BiomeList()
  })

  describe('adding achievements', function () {
    // FEATURE 1. Create a whole that acts as a Facade for parts
    // FEATURE 2. Add a part
    describe('when a single achievement with a name of "a new achievement" is added', function () {
      let theAchievement
      beforeEach(function () {
        // Name|NameSpace|NumID|Dimension|BiomeKey|Desc|Icon
        // "Ocean"|5|0|1|5|"water"|50
        theBiomeList.addAchievement("Ocean", 5, 0, 1, 5, "water", 50)
        theAchievement = theBiomeList.allMyAchievements[0]
      })
      describe('the added single achievement', function () {
        it('should have a GUID/UUID string for ID', function () {
          expect(theAchievement.id).toBeInstanceOf(String)
        })
  
        it('should not be completed', function () {
          expect(theAchievement.completed).toBeFalsy()
        })
  
        it('should have a name of "a new biome"', function () {
          expect(theAchievement.name).toBe('Ocean')
        })
  
        it('should have a Biome Key', function () {
          expect(theAchievement.nameID).toBe(5)
        })
  
        it('should have a numerical id which is a number', function () {
          expect(theAchievement.numID).toBe(0)
        })
  
        it('should have a dimension - Overworld (1) | Hell (2) | Nether (3)', function () {
          expect(theAchievement.dimension).toBe(1)
        })
  
        it('should have a biome description', function () {
          expect(theAchievement.desc).toBe('water')
        })
  
        it('should have an icon', function () {
          expect(theAchievement.ico).toBe(50)
        })
      })

      describe('the biomesList app', function () {
        it('should have one achievement', function () {
          expect(theBiomeList.allMyAchievements.length).toBe(1)
        })

        it('should have 1 active achievement remaining', function () {
          expect(theBiomeList.remaining()).toBe(1)
        })

        it('should not be "all done"', function () {
          expect(theBiomeList.getAllDone()).toBeFalsy()
        })
      })
    })

    describe('when three achievements are added', function () {
      it('should have 3 achievements', function () {
        theBiomeList.addAchievement('1st')
        theBiomeList.addAchievement('2nd')
        theBiomeList.addAchievement('3rd')
        expect(theBiomeList.allMyAchievements.length).toBe(3)
      })
    })
  })

  // FEATURE 6. Save all parts to LocalStorage
  describe('save', function () {
    it('should save an achievement in localStorage when it kas a single item', function () {
      localStorage.clear()
      theBiomeList = new BiomeList()
      theBiomeList.addAchievement('a new achievement')
      theBiomeList.save()
      var itemJSON = localStorage.getItem(STORAGE_KEY)
      expect(itemJSON).toBeTruthy()
    })

    it('should have the correct JSON for the correct achievement in localStorage', function () {
      localStorage.clear()
      theBiomeList = new BiomeList()
      theBiomeList.addAchievement('a new achievement')
      theBiomeList.save()
      var itemJSON = localStorage.getItem(STORAGE_KEY)
      expect(itemJSON).toBe('[{"id": "", "name":"a new achievement","completed":false}]')
    })
  })

  // FEATURE 7. Load all parts from LocalStorage
  describe('load', function () {
    it('should load an achievement from localStorage when it has a single achievement', function () {
      // save something
      localStorage.clear()
      theBiomeList = new BiomeList()
      theBiomeList.addAchievement('a new biome')
      theBiomeList.save()
      // the start the model again
      theBiomeList = new BiomeList()
      // and load
      theBiomeList.load()
      var itemJSON = localStorage.getItem(STORAGE_KEY)
      expect(itemJSON).toBeTruthy()
    })

    it('should have the correct JSON for the loaded item', function () {
      // save something
      localStorage.clear()
      theBiomeList = new BiomeList()
      theBiomeList.addAchievement('a new achievement')
      theBiomeList.save()
      // the start the model again
      theBiomeList = new BiomeList()
      // and load
      theBiomeList.load()
      var itemJSON = localStorage.getItem(STORAGE_KEY)
      expect(itemJSON).toBe('[{"id": "","name":"a new achievement","completed":false}]')
    })
  })

  
  // FEATURE 3. Sort parts
  describe('sorting achievements', function () {
    it('should put achievements into alphabetic name order', function () {
      var theBiomeList = new BiomeList()
      theBiomeList.addAchievement('c')
      theBiomeList.addAchievement('a')
      theBiomeList.addAchievement('b')
      theBiomeList.sortAchievements()
      const actualOrderedAchievementNames = getNames(theBiomeList.allMyAchievements)
      const expectedSortedAchievementNames = ['a', 'b', 'c']
      expect(expectedSortedAchievementNames).toEqual(actualOrderedAchievementNames)
    })
  })
  
  describe('sorting by dimension', function () { // Broken
    it('should put achievements into dimension name order', function () {
      var theBiomeList = new BiomeList()
      theBiomeList.addAchievement(2)
      theBiomeList.addAchievement(1)
      theBiomeList.addAchievement(3)
      theBiomeList.sortAchievements()
      const actualOrderedAchievementNames = getNames(theBiomeList.allMyAchievements)
      const expectedSortedAchievementNames = [1,2,3]
      expect(expectedSortedAchievementNames).toEqual(actualOrderedAchievementNames)
    })
  })
  
  describe('sorting by BiomeKey', function () { // Broken
    it('should put achievements into alphabetic BiomeKey order', function () {
      var theBiomeList = new BiomeList()
      theBiomeList.addAchievement(2)
      theBiomeList.addAchievement(1)
      theBiomeList.addAchievement(3)
      theBiomeList.sortAchievements()
      const actualOrderedAchievementNames = getNames(theBiomeList.allMyAchievements)
      const expectedSortedAchievementNames = [1,2,3]
      expect(expectedSortedAchievementNames).toEqual(actualOrderedAchievementNames)
    })
  })
  
  describe('sorting by Numerical ID', function () { // Broken
    it('should put achievements into numerical id order', function () {
      var theBiomeList = new BiomeList()
      theBiomeList.addAchievement(2)
      theBiomeList.addAchievement(1)
      theBiomeList.addAchievement(3)
      theBiomeList.sortAchievements()
      const actualOrderedAchievementNames = getNames(theBiomeList.allMyAchievements)
      const expectedSortedAchievementNames = [1,2,3]
      expect(expectedSortedAchievementNames).toEqual(actualOrderedAchievementNames)
    })
  })
  
  describe('sorting by Namespace ID', function () {// Broken
    it('should put achievements into namespace id order', function () {
      var theBiomeList = new BiomeList()
      theBiomeList.addAchievement(2)
      theBiomeList.addAchievement(1)
      theBiomeList.addAchievement(3)
      theBiomeList.sortAchievements()
      const actualOrderedAchievementNames = getNames(theBiomeList.allMyAchievements)
      const expectedSortedAchievementNames = [1,2,3]
      expect(expectedSortedAchievementNames).toEqual(actualOrderedAchievementNames)
    })
  })

  // FEATURE 4. Filter parts
  describe('filtering achievements', function () {
    var theBiomeList = new BiomeList()
    theBiomeList.addAchievement('a')
    theBiomeList.addAchievement('b')
    theBiomeList.addAchievement('c')
    theBiomeList.allMyAchievements[1].completed = true

    it('should be able to return only active/remaining achievements', function () {
      const expectedActiveCount = 2
      const expectedActiveAchievementNames = ['a', 'c']
      const actualActiveList = theBiomeList.getActiveAchievements()
      const actualActiveCount = actualActiveList.length
      const actualActiveAchievementNames = getNames(actualActiveList)

      expect(actualActiveCount).toBe(expectedActiveCount)
      expect(actualActiveAchievementNames).toEqual(expectedActiveAchievementNames)
    })

    it('should be able to return only completed achievements', function () {
      const expectedCompletedCount = 1
      const expectedCompletedAchievementNames = ['b']
      const actualCompletedList = theBiomeList.getCompletedAchievements()
      const actualCompletedCount = actualCompletedList.length
      const actualCompletedAchievementNames = getNames(actualCompletedList)
      expect(actualCompletedCount).toBe(expectedCompletedCount)
      expect(actualCompletedAchievementNames).toEqual(expectedCompletedAchievementNames)
    })

    it('should correctly calculate the number of remaining achievements', function () {
      const expectedRemainingCount = 2
      const actualRemainingCount = theBiomeList.remaining()
      expect(actualRemainingCount).toBe(expectedRemainingCount)
    })
  })

  // FEATURE 5. Delete a selected part
  describe('deleting a achievement', function () {
    var theBiomeList = new BiomeList()
    theBiomeList.addAchievement('a')
    theBiomeList.addAchievement('b')
    theBiomeList.addAchievement('c')
    theBiomeList.removeAchievement('b')
    it('should remove that achievement', function () {
      const expectedAchievementNames = ['a', 'c']
      const actualAchievementNames = getNames(theBiomeList.allMyAchievements)
      expect(actualAchievementNames).toEqual(expectedAchievementNames)
    })

    it('should reduce the achievement count', function () {
      const expectedRemainingCount = 2
      const actualRemainingCount = theBiomeList.allMyAchievements.length
      expect(actualRemainingCount).toBe(expectedRemainingCount)
    })
  })

  describe('removing all completed achievements', function () {
    var theBiomeList = new BiomeList()
    theBiomeList.addAchievement('a')
    theBiomeList.addAchievement('b')
    theBiomeList.addAchievement('c')
    theBiomeList.addAchievement('d')
    theBiomeList.allMyAchievements[1].completed = true
    theBiomeList.allMyAchievements[2].completed = true
    theBiomeList.removeCompleted()
    it('should remove all of the completed achievements', function () {
      const expectedAchievementNames = ['a', 'd']
      const actualAchievementNames = getNames(theBiomeList.allMyAchievements)
      expect(actualAchievementNames).toEqual(expectedAchievementNames)
    })

    it('should reduce the achievement count', function () {
      const expectedRemainingCount = 2
      const actualRemainingCount = theBiomeList.allMyAchievements.length
      expect(actualRemainingCount).toBe(expectedRemainingCount)
    })
  })

  // FEATURE 8. Update/edit a part
  describe('editing a achievement', function () {
    var theBiomeList = new BiomeList()
    theBiomeList.addAchievement('a')
    theBiomeList.addAchievement('b')
    theBiomeList.addAchievement('c')
    theBiomeList.startEditing(theBiomeList.allMyAchievements[1])
    theBiomeList.allMyAchievements[1].name = 'bb'
    theBiomeList.doneEditing(theBiomeList.allMyAchievements[1])
    it('should change the name of that achievement', function () {
      expect(theBiomeList.allMyAchievements[1].name).toBe('bb')
    })
  })

  // FEATURE 9. Discard /revert edits to a part
  describe('discarding edits to a achievement', function () {
    it('should not change the name of that achievement', function () {
      var theBiomeList = new BiomeList()
      theBiomeList.addAchievement('a')
      theBiomeList.addAchievement('b')
      theBiomeList.addAchievement('c')
      theBiomeList.startEditing(theBiomeList.allMyAchievements[1])
      theBiomeList.allMyAchievements[1].name = 'bb'
      theBiomeList.cancelEditing(theBiomeList.allMyAchievements[1])
      expect(theBiomeList.allMyAchievements[1].name).toBe('b')
    })
  })

  // FEATURE 10. Validate inputs
  describe('validating inputs to a achievement', function () {
    it('should not allow empty names', function () {
      var theBiomeList = new BiomeList()
      theBiomeList.addAchievement('a')
      theBiomeList.addAchievement('')
      theBiomeList.addAchievement('  ')
      theBiomeList.addAchievement('b')
      const expectedAchievementNames = ['a', 'b']
      const actualAchievementNames = getNames(theBiomeList.allMyAchievements)
      console.log(actualAchievementNames)
      console.log(expectedAchievementNames)
      expect(actualAchievementNames).toEqual(expectedAchievementNames)
    })
  })

  // FEATURE 11. A calculation within a part
  // NOT IMPLEMENTED!, therefore NOT TESTED!
  xdescribe('a ??? calculation within a part', function () {
    xit('should do the ???? calculation correctly', function () {
      expect(true).toBeTrue()
    })
  })

  // CALCULATOR
  /*
  describe('looking at percentages', function() {
    it('should have a Completed Percentage', function () {

    })

    it('should have a Not Completed Percentage', function () {
      
    })

    it('should have a Total Percentage of 100%', function () {
      
    })
  })
  */

  // FEATURE 12. A calculation across many parts
  describe('working out if all achievements are done', function () {
    it('should return true for an empty list', function () {
      var theBiomeList = new BiomeList()
      expect(theBiomeList.getAllDone()).toBeTrue()
    })

    it('should return false for a list with active achievements in it', function () {
      var theBiomeList = new BiomeList()
      theBiomeList.addAchievement('a')
      theBiomeList.addAchievement('b')
      expect(theBiomeList.getAllDone()).toBeFalse()
    })

    it('should return true for a list with only completed achievements in it', function () {
      var theBiomeList = new BiomeList()
      theBiomeList.addAchievement('a')
      theBiomeList.addAchievement('b')
      theBiomeList.allMyAchievements[0].completed = true
      theBiomeList.allMyAchievements[1].completed = true
      expect(theBiomeList.getAllDone()).toBeTrue()
    })
  })

  describe('counting active achievements', function () {
    it('should return the correct number of remaining achievements as achievements are added or completed', function () {
      var theBiomeList = new BiomeList()
      expect(theBiomeList.remaining()).toBe(0)
      theBiomeList.addAchievement('a')
      expect(theBiomeList.remaining()).toBe(1)
      theBiomeList.addAchievement('b')
      expect(theBiomeList.remaining()).toBe(2)
      theBiomeList.addAchievement('c')
      expect(theBiomeList.remaining()).toBe(3)
      theBiomeList.allMyAchievements[1].completed = true
      expect(theBiomeList.remaining()).toBe(2)
    })
  })

  // FEATURE 13. Provide default values
  describe('the default value for new achievements', function () {
    it('should allocate a sequentially incrementing id to all new achievements', function () {
      var theBiomeList = new BiomeList()
      for (let expectedId = 1; expectedId < 5; expectedId += 1) {
        theBiomeList.addAchievement('another achievement')
        var actualId = theBiomeList.allMyAchievements[theBiomeList.allMyAchievements.length - 1].id
        expect(actualId).toBe(expectedId)
      }
    })

    it('should make all new achievements not completed', function () {
      var theBiomeList = new BiomeList()
      theBiomeList.addAchievement('a')
      const actualCompleted = theBiomeList.allMyAchievements[0].completed
      expect(actualCompleted).toBeFalse()
    })
  })

  // FEATURE 14. Find a part given a search criterion
  describe('finding a achievement', function () {
    it('should find nothing with an empty biome list', function () {
      var theBiomeList = new BiomeList()
      const actualFoundAchievement = theBiomeList.findAchievement('a')
      expect(actualFoundAchievement).toBeUndefined()
    })

    it('should find the only achievement with a name when that name is unique', function () {
      var theBiomeList = new BiomeList()
      theBiomeList.addAchievement('a')
      theBiomeList.addAchievement('b')
      theBiomeList.addAchievement('c')
      const actualFoundAchievement = theBiomeList.findAchievement('b')
      expect(actualFoundAchievement).toBeDefined()
      const expectedFoundName = 'b'
      const actualFoundName = actualFoundAchievement.name
      expect(actualFoundName).toBe(expectedFoundName)
    })

    it('should find the first achievement with that name when there is more than one achievement with the same name', function () {
      var theBiomeList = new BiomeList()
      theBiomeList.addAchievement('a')
      theBiomeList.addAchievement('b')
      theBiomeList.addAchievement('b')
      theBiomeList.addAchievement('c')
      const actualFoundAchievement = theBiomeList.findAchievement('b')
      expect(actualFoundAchievement).toBeDefined()
      const expectedFoundName = 'b'
      const actualFoundName = actualFoundAchievement.name
      expect(actualFoundName).toBe(expectedFoundName)
      const expectedFoundId = 2
      const actualFoundId = actualFoundAchievement.id
      expect(actualFoundId).toBe(expectedFoundId)
    })
  })
})

/* globals localStorage */

// FEATURE 13. Provide default values
const STORAGE_KEY = 'travelAchievement'
/*
  TODO: Sort Function Fixes
  TODO:LET = ID [array len change] COUNT  -- Kinda done -- GUID/UUID
    Dont Save ID's
    Generate new IDs on Load
*/

// trying to make a constant object
// code should always call from here to get the key
const BiomeKey = function() {
  return {
    1: "End",
    2: "Nether",
    3: "Hills",
    4: "Void",
    5: "Ocean",
    6: "Desert",
    7: "Savana",
    8: "Badlands",
    9: "Plateau",
    10: "Mushroom",
    11: "Beach",
    12: "River",
    13: "Jungle",
    14: "Swamp",
    15: "Forest",
    16: "Plains",
    17: "Shore",
    18: "Taiga",
    19: "Mountains",
    20: "Misc"
  }[this.newBiomeKey]
}

const imgList = function() {
  return {
    1: "badlands",
    2: "badlands_plateau",
    4: "bamboo_jungle",
    5: "bamboo_jungle_hills",
    6: "basalt_deltas",
    7: "beach",
    8: "birch_forest",
    9: "birch_forest_hills",
    10: "cold_ocean",
    11: "crimson_forest",
    12: "dark_forest",
    13: "dark_forest_hills",
    14: "deep_cold_ocean",
    15: "deep_frozen_ocean",
    16: "deep_lukewarm_ocean",
    17: "deep_ocean",
    18: "deep_warm_ocean",
    19: "desert",
    20: "desert_hills",
    21: "desert_lakes",
    22: "end_barrens",
    23: "end_highlands",
    24: "end_midlands",
    25: "eroded_badlands",
    26: "flower_forest",
    27: "forest",
    28: "frozen_ocean",
    29: "frozen_river",
    30: "giant_spruce_taiga",
    31: "giant_spruce_taiga_hills",
    32: "giant_tree_taiga",
    33: "giant_tree_taiga_hills",
    34: "gravelly_mountains",
    35: "ice_spikes",
    36: "jungle",
    37: "jungle_edge",
    38: "jungle_hills",
    39: "lukewarm_ocean",
    40: "modified_badlands_plateau",
    41: "modified_gravelly_mountains",
    42: "modified_jungle",
    43: "modified_jungle_edge",
    44: "modified_wooded_badlands_plateau",
    45: "mountain_edge",
    46: "mountains",
    47: "mushroom_field_shore",
    48: "mushroom_fields",
    49: "nether_wastes",
    50: "ocean",
    51: "plains",
    52: "river",
    53: "savanna",
    54: "savanna_plateau",
    55: "shattered_savanna",
    56: "shattered_savanna_plateau",
    57: "small_end_islands",
    58: "snowy_beach",
    59: "snowy_mountains",
    60: "snowy_taiga",
    61: "snowy_taiga_hills",
    62: "snowy_taiga_mountains",
    63: "snowy_tundra",
    64: "soul_sand_valley",
    65: "stone_shore",
    66: "sunflower_plains",
    67: "swamp",
    68: "swamp_hills",
    69: "taiga",
    70: "taiga_hills",
    71: "taiga_mountains",
    72: "tall_birch_forest",
    73: "tall_birch_hills",
    74: "the_end",
    75: "the_void",
    76: "warm_ocean",
    77: "warped_forest",
    78: "wooded_badlands_plateau",
    79: "wooded_hills",
    80: "wooded_mountains"
  }[this.newIcon]
}

const dimensionGroup = function() {
  return {
    1: "Overworld",
    2: "Nether",
    3: "End"
  }[this.newDimension];
}

function uuidv4() {
  return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
    var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
    return v.toString(16);
  });
}

let newId = (uuidv4())

// FEATURE 2. Add a part
class Achievement { // eslint-disable-line no-unused-vars
  // NOT IMPLEMENTED :-(
  constructor (newId, newName, newNameSpace, newNumID, newDimension , newBiomeKey, newDesc, newIcon) {
    this.id = newId

    this.name = newName
    this.completed = false // FEATURE 13. Provide default values

    this.nameID = newNameSpace          // The Namespace ID
    this.numID = newNumID               // The Numerical ID
    this.dimension  = newDimension      // What world the biome appears in i.e. Overworld, Nether, Hell
    this.BiomeKey = newBiomeKey         // This is for Classification to group it i.e. there are 10 ocean types so if sorted by this it would group them together

    // This if for when we make the UI
    this.desc = newDesc           // Description of the Biome
    this.ico = newIcon            // Image or Image pathway of the Biome - undecided
  }
}

// FEATURE 1. Create a whole that acts as a Facade for parts
class BiomeList { // eslint-disable-line no-unused-vars
  constructor () {
    this.allMyAchievements = []
    // the following 3 attibutes are used to support editing a achievement
    this.editedItem = null
    this.editedAchievementIndex = null
    this.beforeEditNameCache = ''
  }

  // FEATURE 15. Get all parts
  getAllAchievements () {
    return this.allMyAchievements
  }

  // FEATURE 12. A calculation across many parts ! a weak example !
  // FEATURE 4. Filter parts
  getActiveAchievements () {
    return this.allMyAchievements.filter(achievement => !achievement.completed)
  }

  // FEATURE 12. A calculation across many parts ! a weak example !
  // FEATURE 4. Filter parts
  getCompletedAchievements () {
    let Com = 0
    return this.allMyAchievements.filter(function (achievement) {
      Com+1
      return achievement.completed
    })
  }

  getNotCompletedAchievements () {
    let notCom = 0
    return this.allMyAchievements.filter(function (achievement) {
      notCom+1
      return !achievement.completed
    })
  }

  getPercents(){
    let comPercent = ((this.allMyAchievements / this.getCompletedAchievements(Com)*100))
    let notComPercent = ((this.allMyAchievements / this.getNotCompletedAchievements(notCom)*100))
  }

  // FEATURE 7. Load all parts from LocalStorage
  load () {
    // FEATURE 13. Provide default values
    return JSON.parse(localStorage.getItem(STORAGE_KEY) || '[]')
  }

  //  FEATURE 6. Save all parts to LocalStorage
  save () {
    localStorage.setItem(STORAGE_KEY, JSON.stringify(this.allMyAchievements))
  }
  // FEATURE 2. Add a part
  addAchievement (newName, newNameSpace, newNumID, newDimension, newBiomeKey, newDesc, newIcon) {

    // FEATURE 13. Provide default values

    const aNewAchievement = new Achievement(newId, newName, newNameSpace, newNumID, newDimension , newBiomeKey, newDesc, newIcon)
    
    this.allMyAchievements.push(aNewAchievement)
    console.log(this.allMyAchievements);
  }

  // FEATURE 12. A calculation across many parts
  remaining () {
    return this.getActiveAchievements().length
  }

  // FEATURE 12. A calculation across many parts
  getAllDone () {
    return this.remaining() === 0
  }

  setAllDone () {
    this.allMyAchievements.forEach(function (achievement) {
      achievement.completed = true
    })
  }

  // FEATURE 5. Delete a selected part
  removeAchievement (targetAchievementName) {
    const index = this.allMyAchievements.findIndex(achievement => achievement.name === targetAchievementName)
    this.allMyAchievements.splice(index, 1)
  }

  // FEATURE 8. Update/edit a part
  // copies the achievement and name 
  startEditing (achievement) {
    this.beforeEditCache = achievement.name
    this.editedAchievement = achievement
  }

  // FEATURE 8. Update/edit a part
  doneEditing (achievement) {
    // FEATURE 10. Validate inputs
    if (!achievement) {
      return
    }
    this.editedAchievement = null
    achievement.name = achievement.name.trim()
    if (!achievement.name) {
      this.removeAchievement(achievement)
    }
  }

  // FEATURE 9. Discard /revert edits to a part
  cancelEditing (achievement) {
    this.editedAchievement = null
    achievement.name = this.beforeEditCache
  }

  // FEATURE 5. Delete a selected part
  removeCompleted () {
    this.allMyAchievements = this.getActiveAchievements()
  }

  // FEATURE 3. Sort parts

  sortAchievements () {
    this.allMyAchievements.sort(function (a, b) {
      if (a.name < b.name) {
        return -1
      }
      if (a.name > b.name) {
        return 1
      }
      // a must be equal to b
      return 0
    })
  }
  
  sortCompleted () {
    this.allMyAchievements.sort(function (a, b) {
      if (a.completed < b.completed) {
        return -1
      }
      if (a.completed > b.completed) {
        return 1
      }
      // a must be equal to b
      return 0
    })
  }
  
  sortDimension  () {
    this.allMyAchievements.sort(function (a, b) {
      if (a.dimension  < b.dimension ) {
        return -1
      }
      if (a.dimension  > b.dimension ) {
        return 1
      }
      // a must be equal to b
      return 0
    })
  }
  
  sortBiomeKey () {
    this.BiomeKey.sort(function(a,b){return a-b});
  }
  
  sortNumericalID () {
    this.allMyAchievements.sort(function (a, b) {
      if (a.numID < b.numID) {
        return -1
      }
      if (a.numID > b.numID) {
        return 1
      }
      // a must be equal to b
      return 0
    })
  }
  
  sortNamespaceID () {
    this.allMyAchievements.sort(function (a, b) {
      if (a.nameID < b.nameID) {
        return -1
      }
      if (a.nameID > b.nameID) {
        return 1
      }
      // a must be equal to b
      return 0
    })
  }

  // FEATURE 14. Find a part given a search criterion
  // NOTE: finds only FIRST match!
  findAchievement (targetName) {
    return this.allMyAchievements.find((achievement) => achievement.name === targetName)
  }
}

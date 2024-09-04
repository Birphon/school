"""
Author: Jared Ireland - jai0095 - Created Most of it
Author: Luc Roghi - lcr0059 - actually changed it over to python use "minor changes"
For: BCDE311 Assignment2
"""
import sqlite3


# https://docs.python.org/3/library/sqlite3.html

class Database:
    def __init__(self):
        self.db_name = 'ZombiesInMyPocket.db'
        self.mydb = sqlite3.connect(self.db_name)
        self.cursor = self.mydb.cursor()

    def open_db(self):
        self.mydb = sqlite3.connect(self.db_name)

    def close_db(self):
        self.mydb.close()

    def setup_db(self):
        self.cursor.execute('''CREATE TABLE if not exists Saves (id INT AUTO_INCREMENT PRIMARY KEY, hp INT, atk INT "
                         "item1  TEXT, item2  TEXT, currentLocation  TEXT, previousLocation  TEXT, "
                         "hasTotem BOOL, time INT)''')  # MISSING: DevCards - Drawn / Undrawn | LEVEL

        self.cursor.execute('''CREATE TABLE if not exists DevCard(id INT AUTO_INCREMENT PRIMARY KEY, item  TEXT, event_one "
                         " TEXT, e1_consequence  TEXT, event_two  TEXT, e2_consequence  TEXT, event_three "
                         " TEXT, e3_consequence  TEXT, charges  TEXT, played BOOL)''')

        self.cursor.execute('''CREATE TABLE if not exists Tiles(name  TEXT, effect  TEXT, type BOOL, doorNorth "
                         "BOOL, doorEast BOOL, doorSouth BOOL, doorWest BOOL, played BOOL)''')

        self.cursor.execute('''CREATE TABLE if not exists Items(id INT AUTO_INCREMENT PRIMARY KEY,name TEXT,
        weapon BOOL,effect TEXT,desc TEXT, combo_use BOOL, hp INT, attack_score INT)''')

        self.cursor.execute('''CREATE TABLE if not exists CombineItems(id INT AUTO_INCREMENT PRIMARY KEY,name TEXT,
        weapon BOOL,effect TEXT,desc TEXT, combo_use BOOL)''')

        self.insert_dev_card_data()
        self.insert_tile_data()
        self.insert_item_data()

    def insert_dev_card_data(self):
        dc_data = [
            ("Oil", "Nothing", "None", "Item", "None", "Zombies", "6", "1", False),
            ("Gasoline", "Zombies", "4", "Health", "-1", "Item", "None", "1", False),
            ("Board With Nails", "Item", "None", "Zombies", "4", "Health", "-1", "Unlimited", False),
            ("Machete", "Zombies", "4", "Health", "-1", "Zombies", "6", "Unlimited", False),
            ("Grisly Femur", "Item", "None", "Zombies", "5", "Health", "-1", "Unlimited", False),
            ("Golf Club", "Health", "-1", "Zombies", "4", "Nothing", "None", "Unlimited", False),
            ("Chainsaw", "Zombies", "3", "Nothing", "None", "Zombies", "5", "2", False),
            ("Can of Soda", "Health", "1", "Item", "", "Zombies", "4", "1", False),
            ("Candle", "Nothing", "None", "Health", "1", "Zombies", "4", "Unlimited", False)
        ]
        self.cursor.executemany('INSERT INTO DevCard(item,event_one,e1_consequence,event_two,e2_consequence,event_three'
                                ',e3_consequence,charges,played) VALUES(?,?,?,?,?,?,?,?,?)', dc_data)

    def insert_tile_data(self):
        tile_data = [
            # Tile Name, Action, Type, Door N, Door E, Door S, Door W, Been Played
            ("Graveyard", "Bury Totem", "Outdoor", True, True, False, False, False),
            ("Yard", "None", "Outdoor", True, True, True, False, False),
            ("Sitting Area", "None", "Outdoor", True, True, True, False, False),
            ("Yard", "None", "Outdoor", True, True, True, False, False),
            ("Yard", "None", "Outdoor", True, True, True, False, False),
            ("Patio", "None", "Outdoor", True, True, False, True, False),
            ("Garage", "None", "Outdoor", False, True, True, False, False),
            ("Garden", "Health", "Outdoor", True, True, True, False, False),
            ("Bathroom", "None", "Indoor", False, False, False, True, False),
            ("Family Room", "None", "Indoor", True, False, True, True, False),
            ("Kitchen", "Health", "Indoor", True, False, True, True, False),
            ("Dining Room", "None", "Indoor", True, True, True, True, False),
            ("Storage", "Draw", "Indoor", False, False, False, True, False),
            ("Bedroom", "None", "Indoor", False, False, True, True, False),
            ("Evil Temple", "Find Totem", "Indoor", True, False, True, False, False),
            ("Foyer", "None", "Indoor", True, False, False, False, False)
        ]
        self.cursor.executemany('INSERT INTO Tiles VALUES(?,?,?,?,?,?,?,?)', tile_data)

    def insert_item_data(self):
        item_data = [
            {"Oil", False, "One Time Use", "Throw as you run away to avoid taking damage./nCombine with Candle to "
                                           "kill all zombies on one tile without taking damage.\nOne Time Use.", True,
             0, 0},
            {"Gasoline", False, "One Time Use", "Combine with the Candle to kill all zombies without taking "
                                                "damage./nCombine with Chainsaw to give two more Chainsaw uses.\nOne "
                                                "time use", True, 0, 0},
            {"Cand of Soda", False, "Health +2", "Its a can of Soda", False, 2, 0},
            {"Grisly Femur", True, "Attack Score +1", "A Femur or a Club?", False, 0, 1},
            {"Board w/ Nails", True, "Attack Score +1", "A Wooden Board with Nails in it", False, 0, 1},
            {"Golf Club", True, "Attack Score +1", "A Driving Club, the owners must have played golf", False, 0, 1},
            {"Candle", False, "", "Combine with Oil or Gas to kill all zombies on one tile without taking damage",
             True, 0, 0},
            {"Chainsaw", True, "Attack Score +3", "A Chainsaw with only 50% of fuel./nOnly has enough fuel for 2 "
                                                  "battles - find some more gasoline to use it for longer", True, 3, 0},
            {"Machete", True, "Attack Score +2", "A broad blade", False, 0, 2},
            # Below are "Combo Items"
            {"Molotov (Gas)", True, "One Time Use", "Candle and Gas being combined together./n All zombies on this "
                                                    "tile will die without you taking damage!", False, 0, 0},
            {"Molotov (Oil)", True, "One Time Use", "Candle and Oil being combined together./n All zombies on this "
                                                    "tile will die without you taking damage!", False, 0, 0},
        ]
        self.cursor.executemany('INSERT INTO Items(name,weapon,effect,desc,combo_use) VALUES(?,?,?,?,?)', item_data)

    # FIXME This probs doesn't work - Should push all the Combo_Use=True stuff into Combine_Data[]
    def combine_items(self):
        if self.get_item_data().combo_use(True):
            combine_data = []
            self.cursor.executemany('INSERT INTO CombineItems(name,weapon,effect,desc,combo_use) VALUES(?,?,?,?,?)',
                                    combine_data)

    def get_dev_card_data(self):
        self.cursor.execute("SELECT * FROM DevCard")
        return self.cursor.fetchall()

    def get_tile_data(self):
        self.cursor.execute("SELECT * FROM Tiles")
        return self.cursor.fetchall()

    def get_item_data(self):
        self.cursor.execute("SELECT * FROM Items")
        return self.cursor.fetchall()

    def get_combine_items(self):
        self.cursor.execute("SELECT * FROM CombineItems")
        return self.cursor.fetchall()

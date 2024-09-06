"""
Author: Luc Roghi - lcr0059
For: BCDE311 Assignment2

Initializes a level object containing all the information of the level

Based on the example within:
https://www.tutorialspoint.com/python-program-to-create-a-doubly-linked-list-from-a-ternary-tree

Dependencies:
    player.py: Contains the player Class
    map_node.py: Contains the MapNode Class
    Random: Only need the randint function to generate a random integer

I Need To: (Tried the to do tag, it is weird with GIT)
    -Add checks to stop execution of functions when not possible
    -Add logic to connect rooms that will have adjacent doors
    -Optimize the current code to make it easier for team to contribute
    -Implement the database class in order to properly populate the map and item cards
    -Write proper documentation on how this works
    -Implement map card rotation to ensure door alignment
"""
from random import randint
from map_node import MapNode
from player import Player
from database import Database


class Level:
    def __init__(self):
        self.player = Player()
        # Supposed to pull cards from database, currently just a test list
        # Tuples are for the doors: Order is (up, right, down, left)
        game_storage = Database()
        game_storage.setup_db()
        self.mapCards = game_storage.get_tile_data()
        print(self.mapCards)
        self.itemCards = []
        # Beginning of the tree (None as the map has not been initialized)
        self.root = None

    def initialize_map(self):
        # Set up the initial room as well as the beginning of the tree
        # Assigns the tree to the player current location as an alias for naming convention simplicity
        foyer_tile = self.assign_map_node(self.mapCards[-1])
        self.root = foyer_tile
        self.player.currentLocation = self.root

    def assign_map_node(self, tile_data):
        name, action, type, door_up, door_right, door_down, door_left, been_played = tile_data
        new_tile = MapNode(name, action, type, 0, door_up, door_right, door_down, door_left, been_played)
        return new_tile

    def pick_new_room(self):
        # Picks a random tuple from mapCards to get all the data of a room. Returns a tuple
        return self.mapCards[randint(1, len(self.mapCards) - 1)]

    def add_new_room_up(self):
        # If the room has a door going up and is currently not connected, pick a new card and connect it
        new_room = self.assign_map_node(self.pick_new_room())
        if new_room.door_up == 1 and self.player.currentLocation.room_up is None:
            new_room.been_played = True
            self.player.currentLocation.room_up = new_room
            self.player.currentLocation.room_up.room_down = self.player.currentLocation

    def add_new_room_right(self):
        # If the room has a door going right and is currently not connected, pick a new card and connect it
        new_room = self.assign_map_node(self.pick_new_room())
        if new_room.door_right == 1 and self.player.currentLocation.room_right is None:
            new_room.been_played = True
            self.player.currentLocation.room_right = new_room
            self.player.currentLocation.room_right.room_left = self.player.currentLocation

    def add_new_room_down(self):
        # If the room has a door going down and is currently not connected, pick a new card and connect it
        new_room = self.assign_map_node(self.pick_new_room())
        if new_room.door_down == 1 and self.player.currentLocation.room_down is None:
            new_room.been_played = True
            self.player.currentLocation.room_down = new_room
            self.player.currentLocation.room_down.room_up = self.player.currentLocation

    def add_new_room_left(self):
        # If the room has a door going left and is currently not connected, pick a new card and connect it
        new_room = self.assign_map_node(self.pick_new_room())
        if new_room.door_left == 1 and self.player.currentLocation.room_left is None:
            new_room.been_played = True
            self.player.currentLocation.room_left = new_room
            self.player.currentLocation.room_left.room_right = self.player.currentLocation

    def move_player_up(self):
        # If a room is connected going up, update player location to that room
        if self.player.currentLocation.room_up is not None:
            self.player.currentLocation = self.player.currentLocation.room_up

    def move_player_right(self):
        # If a room is connected going right, update player location to that room
        if self.player.currentLocation.room_right is not None:
            self.player.currentLocation = self.player.currentLocation.room_right

    def move_player_down(self):
        # If a room is connected going down, update player location to that room
        if self.player.currentLocation.room_down is not None:
            self.player.currentLocation = self.player.currentLocation.room_down

    def move_player_left(self):
        # If a room is connected going left, update player location to that room
        if self.player.currentLocation.room_left is not None:
            self.player.currentLocation = self.player.currentLocation.room_left


if __name__ == "__main__":
    # Main loop regarding the tree traversal logic. Still need to add a lot of checks and logic regarding placement
    # and movement
    mainLevel = Level()
    mainLevel.initialize_map()

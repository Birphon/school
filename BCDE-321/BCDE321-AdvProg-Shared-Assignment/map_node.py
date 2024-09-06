"""
Author: Luc Roghi - lcr0059
For: BCDE311 Assignment2
"""


class MapNode:
    def __init__(self, room_name, action, type, zombie_number, door_up, door_right, door_down, door_left, been_played):
        self.room_name = room_name
        self.action = action
        self.type = type
        self.zombie_number = zombie_number
        self.door_up = door_up
        self.door_right = door_right
        self.door_down = door_down
        self.door_left = door_left
        self.room_up = None
        self.room_right = None
        self.room_down = None
        self.room_left = None
        self.been_played = been_played


if __name__ == "__main__":
    pass

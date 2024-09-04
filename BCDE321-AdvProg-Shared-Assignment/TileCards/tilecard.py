# Author:Jiaxi Liu jil0708


import csv
import string

import pandas as pd
from tileaction import Effect as e


def get_tile_data(path):
    # pd.read_excel can change to pd.read_sql
    dn = pd.read_excel(path)
    for i in dn["Name"]:
        cards = Tiles(i)
        cards.card_content()
    return cards

    # hope return list[graveyard, effect1, outdoor, [1,1,0,0]]
    # or dict {name:"graveyard", effect:"bury totem",type:"outdoor",position:[1,1,0,0]}


class Tiles:
    # 16 tiles
    tile_name: str
    # type outdoor and indoor
    tile_type: str
    tile_action: e
    tile_structure: []

    # 1 means door, 0 means wall
    # tile_border : list[1,1,0,0] == list[N,E,S,W] right rotation should be list[0,1,1,0]

    def __init__(self, tile_name):
        self.tile_name = tile_name
        match tile_name:
            case "Graveyard":
                self.tile_name = "Graveyard"
                self.tile_type = "Outdoor"
                self.tile_action = e.bury_totem()
                self.tile_structure = [1, 1, 0, 0]
            case "Yard":
                self.tile_name = "Yard"
                self.tile_type = "Outdoor"
                self.tile_action = e.none_effect()
                self.tile_structure = [1, 1, 1, 0]
            case "Sitting Area":
                self.tile_name = "Sitting Area"
                self.tile_type = "Outdoor"
                self.tile_action = e.none_effect()
                self.tile_structure = [1, 1, 1, 0]
            case "Patio":
                self.tile_name = "Patio"
                self.tile_type = "Outdoor"
                self.tile_action = e.none_effect()
                self.tile_structure = [1, 1, 0, 1]
            case "Garage":
                self.tile_name = "Garage"
                self.tile_type = "Outdoor"
                self.tile_action = e.none_effect()
                self.tile_structure = [0, 1, 1, 0]
            case "Garden":
                self.tile_name = "Garden"
                self.tile_type = "Outdoor"
                self.tile_action = e.add_health()
                self.tile_structure = [1, 1, 1, 0]
            case "Bathroom":
                self.tile_name = "Bathroom"
                self.tile_type = "Indoor"
                self.tile_action = e.none_effect()
                self.tile_structure = [0, 0, 0, 1]
            case "Family Room":
                self.tile_name = "Family Room"
                self.tile_type = "Indoor"
                self.tile_action = e.none_effect()
                self.tile_structure = [1, 0, 1, 1]
            case "Kitchen":
                self.tile_name = "Kitchen"
                self.tile_type = "Indoor"
                self.tile_action = e.add_health()
                self.tile_structure = [1, 0, 1, 1]
            case "Dining Room":
                self.tile_name = "Dining Room"
                self.tile_type = "Indoor"
                self.tile_action = e.none_effect()
                self.tile_structure = [1, 1, 1, 1]
            case "Storage":
                self.tile_name = "Storage"
                self.tile_type = "Indoor"
                self.tile_action = e.draw()
                self.tile_structure = [0, 0, 0, 1]
            case "Bedroom":
                self.tile_name = "Bedroom"
                self.tile_type = "Indoor"
                self.tile_action = e.none_effect()
                self.tile_structure = [0, 0, 1, 1]
            case "Evil Temple":
                self.tile_name = "Evil Temple"
                self.tile_type = "Indoor"
                self.tile_action = e.find_totem()
                self.tile_structure = [1, 0, 1, 0]
            case "Foyer":
                self.tile_name = "Foyer"
                self.tile_type = "Indoor"
                self.tile_action = e.none_effect()
                self.tile_structure = [0, 0, 0, 1]

    def card_content(self):
        print(self.tile_name)
        print(self.tile_structure)


if __name__ == "__main__":
    p = "./Tiles.xlsx"
    data = get_tile_data(p)

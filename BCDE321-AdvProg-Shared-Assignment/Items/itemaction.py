from player import Player as p
from map_node import MapNode as m
import item


class ItemAction(p):
    def oli_action(self):
        p.flee()
        p.health = p.health + 1
        print(f'you avoid damage. so player now has {p.health}')

    # def gasoline_action(self):


    def board_action(self):
        p.attack += 1

    def machete_action(self):
        p.attack += 2

    def grisly_action(self):
        p.attack += 1

    def golf_action(self):
        p.attack += 1

    def chainsaw_action(self):
        if item.item_limitation > 0:
            p.attack += 3


    def soda_action(self):
        p.health += 2

    def candle_action(self):
        pass
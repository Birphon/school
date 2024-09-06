from player import Player as p
from map_node import MapNode as m


def NoneAction():
    print('There no effect')
    pass


def HealAction(int):
    p.health += int
    pass


def ZombieAction(int):
    m.zombie_number = int
    pass


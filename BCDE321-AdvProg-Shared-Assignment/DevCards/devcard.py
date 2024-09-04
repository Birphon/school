# Author:Jiaxi Liu jil0708
import pandas as pd
import numpy as np
import dev_action
from Items.item import Item


def get_dev_data(path):
    dn = pd.read_excel(path)
    for i in range(9):
        cards = [dn.iloc[i]]
        print(cards)
    for i in dn["item"]:
        dev_card_name = i
        print(dev_card_name)


class DevCard:
    # time_action = 9 | 10 | 11
    dev_card_name: str
    time_nine_action: object
    time_ten_action: object
    time_eleven_action: object

    def __init__(self, dev_card_name):
        self.dev_card_name = dev_card_name
        match dev_card_name:
            case "Oil":
                self.dev_card_name = "Oil"
                self.time_nine_action = dev_action.NoneAction()
                self.time_ten_action = Item.DrawItem()
                self.time_eleven_action = dev_action.HealAction(-1)
            case "Gasoline":
                self.dev_card_name = "Gasoline"
                self.time_nine_action = dev_action.ZombieAction(4)
                self.time_ten_action = dev_action.HealAction(-1)
                self.time_eleven_action = Item.DrawItem()
            case "Board With Nails":
                self.dev_card_name = "Board With Nails"
                self.time_nine_action = Item.DrawItem()
                self.time_ten_action = dev_action.ZombieAction(4)
                self.time_eleven_action = dev_action.HealAction(-1)
            case "Grisly Femur":
                self.dev_card_name = "Grisly Femur"
                self.time_nine_action = Item.DrawItem()
                self.time_ten_action = dev_action.ZombieAction(5)
                self.time_eleven_action = dev_action.HealAction(-1)
            case "Golf Club":
                self.dev_card_name = "Golf Club"
                self.time_nine_action = dev_action.HealAction(-1)
                self.time_ten_action = dev_action.ZombieAction(-1)
                self.time_eleven_action = dev_action.NoneAction()
            case "Chainsaw":
                self.dev_card_name = "Chainsaw"
                self.time_nine_action = dev_action.ZombieAction(3)
                self.time_ten_action = dev_action.NoneAction()
                self.time_eleven_action = dev_action.ZombieAction(5)
            case "Can of Soda":
                self.dev_card_name = "Can of Soda"
                self.time_nine_action = dev_action.HealAction(1)
                self.time_ten_action = Item.DrawItem()
                self.time_eleven_action = dev_action.ZombieAction(4)
            case "Candle":
                self.dev_card_name = "Candle"
                self.time_nine_action = dev_action.NoneAction()
                self.time_ten_action = dev_action.HealAction(1)
                self.time_eleven_action = dev_action.ZombieAction(4)

    def CardDuck(self):
        # card list for test
        card_list = [0, 1, 2, 3, 4, 5, 6, 7, 8]
        return card_list


if __name__ == "__main__":
    p = "./DevCards.xlsx"
    get_dev_data(p)

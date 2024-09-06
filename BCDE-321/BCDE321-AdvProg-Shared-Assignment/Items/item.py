# Author:Jiaxi Liu jil0708
from DevCards.devcard import DevCard
from player import Player as p
from Items.itemaction import ItemAction
from Items.comboitem import ComboItem
import random


class Item:
    item_name: str
    item_index: int
    item_action: object
    item_limitation: int
    item_combo: ComboItem | None

    def __init__(self, item_name):
        self.item_name = item_name
        match item_name:
            case "Oil":
                self.item_name = "Oil"
                self.item_index = 0
                self.item_action = ItemAction.oli_action()
                self.item_limitation = 1
                self.item_combo = ComboItem.oli_with_candle()
            case "Gasoline":
                self.item_name = "Gasoline"
                self.item_index = 1
                self.item_action = ComboItem.gas_with_chainsaw()  #combo with chainsaw
                self.item_limitation = 1
                self.item_combo = ComboItem.gas_with_candle()   # combo with candle
            case "Board With Nails":
                self.item_name = "Board With Nails"
                self.item_index = 2
                self.item_action = ItemAction.board_action()
                self.item_limitation = 99
                self.item_combo = None
            case "Machete":
                self.item_name = "Machete"
                self.item_index = 3
                self.item_action = ItemAction.machete_action()
                self.item_limitation = 99
                self.item_combo = None
            case "Grisly Femur":
                self.item_name = "Grisly Femur"
                self.item_index = 4
                self.item_action = ItemAction.grisly_action()
                self.item_limitation = 99
                self.item_combo = None
            case "Golf Club":
                self.item_name = "Golf Club"
                self.item_index = 5
                self.item_action = ItemAction.golf_action()
                self.item_limitation = 99
                self.item_combo = None
            case "Chainsaw":
                self.item_name = "Chainsaw"
                self.item_index = 6
                self.item_action = ItemAction.chainsaw_action()
                self.item_limitation = 2
                self.item_combo = ComboItem.gas_with_chainsaw()   # gasoline
            case "Can of Soda":
                self.item_name = "Can of Soda"
                self.item_index = 7
                self.item_action = ItemAction.soda_action()
                self.item_limitation = 1
                self.item_combo = None
            case "Candle":
                self.item_name = "Candle"
                self.item_index = 8
                self.item_action = ItemAction.candle_action()
                self.item_limitation = 1
                self.item_combo = ComboItem.gas_with_candle()    # oil and gasoline

    def DrawItem(self):
        p.current_item.append(random.choice(DevCard.CardDuck()))



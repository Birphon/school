import player as p
from Items.item import Item

class ComboItem:
    def gas_with_candle(self, comboitem):
        if comboitem == (1 or 8):
            # need to judge gas.index and candle.index in current_item or not
            item_list = set(p.current_item)
            if 1 and 8 in item_list:
                p.current_location.zombie_number = 0
                print(f"the fire killed zombies, player didn't get hit. the player now has {p.health}")
            # else:
            #     print("you cant use gas with candle")
        else:
            return

    def oli_with_candle(self, comboitem):
        if comboitem == (0 or 8):
            # need to judge gas.index and candle.index in current_item or not
            item_list = set(p.current_item)
            if 0 and 8 in item_list:
                p.current_location.zombie_number = 0
                print(f"the fire killed zombies, player didn't get hit. the player now has {p.health}")
            # else:
            #     print("you cant use oli with candle")
        else:
            return

    def gas_with_chainsaw(self, comboitem):
        if comboitem == 6:
            item_list = set(p.current_item)
            if 1 and 6 in item_list:
                Item.item_limitation += 1
                print("chainsaw's use limitation add 1")






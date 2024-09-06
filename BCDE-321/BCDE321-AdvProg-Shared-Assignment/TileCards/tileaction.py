import player as p
import game as g


class Effect:
    def none_effect(self):
        print("nothing happen")

    def bury_totem(self, choice=""):
        if p.self_totem:
            print("Do you want bury the totem to save world  Y/N")
            choice = input()
            if choice == "Y" or "y":
                print("you win!! you saved the world")
                g.game_end
        else:
            print("you need find totem at Dining room")

            # p.bury_totem

    def add_health(self):
        print("Nice you got cured, health + 1")
        p.health += 1

    def draw(self):
        print("you find an item")

    def find_totem(self):
        print("Nice,you find the totem")
        p.self_totem == True
        # i think player may have a init attrbute totem==False

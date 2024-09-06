"""
derived from
https:#www.dofactory.com/net/abstract-factory-design-pattern
"""
from abc import ABC, abstractmethod


# The 'AbstractProductA' abstract class
class Herbivore(ABC):
    @abstractmethod
    def eat(self):
        pass


# The 'ProductA1' class
class Wildebeest(Herbivore):
    def eat(self):
        return "Wildebeest eats grasses."


# The 'ProductA2' class
class Bison(Herbivore):
    def eat(self):
        return "Bison eats sedges."


# The 'AbstractProductB' abstract class
class Carnivore(ABC):
    @abstractmethod
    def eat(self, herbivore):
        pass


# The 'ProductB1' class
class Lion(Carnivore):
    def eat(self, herbivore):
        # Eat Wildebeest
        return f'Lion eats {type(herbivore).__name__}.'


# The 'ProductB2' class
class Wolf(Carnivore):
    def eat(self, herbivore):
        # Eat Bison
        return f'Wolf eats {type(herbivore).__name__}.'


# The 'Client' class
class AnimalWorld:
    def run_food_chain(self, continent):
        carnivore = herbivore = None
        if continent == "Africa":
            carnivore = Lion()
        elif continent == "America":
            carnivore = Wolf()
        if continent == "Africa":
            herbivore = Wildebeest()
        elif continent == "America":
            herbivore = Bison()

        print(carnivore.eat(herbivore))
        print(herbivore.eat())


if __name__ == "__main__":
    # The expected output:
    # Lion eats Wildebeest.
    # Wildebeest eats grasses.
    #
    # Wolf eats Bison.
    # Bison eats sedges.
    
    # Create and run the African animal world
    AnimalWorld().run_food_chain("Africa")
    print()

    # Create and run the American animal world
    AnimalWorld().run_food_chain("America")

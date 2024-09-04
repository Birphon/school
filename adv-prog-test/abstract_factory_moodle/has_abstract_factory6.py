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


# The 'AbstractFactory' abstract class
class ContinentFactory(ABC):
    @abstractmethod
    def create_herbivore(self):
        pass

    @abstractmethod
    def create_carnivore(self):
        pass


# The 'ConcreteFactory1' class
class AfricaFactory(ContinentFactory):
    def create_herbivore(self):
        return Wildebeest()

    def create_carnivore(self):
        return Lion()


# The 'ConcreteFactory2' class
class AmericaFactory(ContinentFactory):
    def create_herbivore(self):
        return Bison()

    def create_carnivore(self):
        return Wolf()


# The 'Client' class
class AnimalWorld:
    def __init__(self, factory):
        self.__herbivore = factory.create_herbivore()
        self.__carnivore = factory.create_carnivore()

    def run_food_chain(self):
        print(self.__carnivore.eat(self.__herbivore))
        print(self.__herbivore.eat())


if __name__ == "__main__":
    # The expected output:
    # Lion eats Wildebeest.
    # Wildebeest eats grasses.
    #
    # Wolf eats Bison.
    # Bison eats sedges.

    # Create and run the African animal world
    africa = AfricaFactory()
    world = AnimalWorld(africa)
    world.run_food_chain()
    print()

    # Create and run the American animal world
    america = AmericaFactory()
    world = AnimalWorld(america)
    world.run_food_chain()

""" Example of AFTER applying Composite design pattern """

# !/usr/bin/env python

from abc import ABCMeta, abstractmethod

__author__ = 'xul'


# abstract class as the interface between client and composite
class Component(metaclass=ABCMeta):
    @abstractmethod
    def __init__(self, val, type):
        self._value = val
        self._type = type

    def add(self, component):
        pass

    @abstractmethod
    def traverse(self):
        pass


class Primitive(Component):
    def __init__(self, val):
        Component.__init__(self, val, type="LEAF")

    def traverse(self):
        print('\t{}\t{}'.format(self._value, self._type))


class Composite(Component):
    def __init__(self, val):
        Component.__init__(self, val, type="INTERIOR")
        self.__children = []

    def add(self, component):
        self.__children.append(component)

    def traverse(self):
        print('{}\t{}'.format(self._value, self._type))
        for each_child in self.__children:
            each_child.traverse()


if __name__ == '__main__':
    # The expected output:
    # 1	INTERIOR
    # 2	INTERIOR
    # 	5	LEAF
    # 	6	LEAF
    # 3	INTERIOR
    # 	7	LEAF
    # 	4	LEAF

    first = Composite(1)
    second = Composite(2)
    third = Composite(3)

    first.add(second)
    first.add(third)
    first.add(Primitive(4))
    second.add(Primitive(5))
    second.add(Primitive(6))
    third.add(Primitive(7))
    first.traverse()

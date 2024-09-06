# https://www.python.org/dev/peps/pep-0263/

# !/usr/bin/env python

from abc import ABCMeta, abstractmethod

__author__ = 'xul'


class Component(metaclass=ABCMeta):
    @abstractmethod
    def __init__(self, name, type_):
        self._name = name
        self._type = type_

    def add(self, component):
        pass

    @abstractmethod
    def traverse(self, level=0):
        # print("\t"*level + self.__name + "\t" + self.type)
        # print('{}{:20}\t{}'.format("\t" * level, self._name, self._type))
        s = "\t" * level
        print(f'{s}{self._name:20}\t{self._type}')


class File(Component):
    def __init__(self, name):
        Component.__init__(self, name, type_="File")

    def traverse(self, level=0):
        super(File, self).traverse(level)


class Folder(Component):
    def __init__(self, name):
        Component.__init__(self, name, type_="Folder")
        self.__children = []

    def add(self, component):
        self.__children.append(component)

    def traverse(self, level=0):
        super(Folder, self).traverse(level)
        for child in self.__children:
            child.traverse(level + 1)


if __name__ == '__main__':
    file_system: Component = Folder("Pools")
    next_ = Folder("FC")
    file_system.add(next_)

    current = next_
    next_ = Folder("School of Computing")
    current.add(next_)

    current = next_
    next_ = Folder("BICT")
    current.add(next_)

    current = next_
    next_ = Folder("PR301")
    current.add(next_)
    next_ = File("TheSecretMessage.txt")
    current.add(next_)

    file_system.traverse()

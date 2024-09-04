# https://www.codeproject.com/Articles/472800/Composite-Design-Pattern-in-Java

# !/usr/bin/env python

from abc import ABCMeta, abstractmethod

__author__ = 'xul'


class Employee(metaclass=ABCMeta):
    @abstractmethod
    def __init__(self, name, title, salary):
        self._name = name
        self._title = title
        self._salary = salary

    def add(self, employee):
        pass

    def remove(self, employee):
        pass

    # def get_subordinate(self, i):
    #     pass

    @property
    def name(self):
        return self._name

    @property
    def title(self):
        return self._title

    @property
    def salary(self):
        return self._salary

    @abstractmethod
    def to_string(self, tab):
        print("{}Name: {}, Title: {}, Salary: {}".format(
            tab, self._name, self._title, self._salary))


class Junior(Employee):
    def __init__(self, name, title, salary):
        super().__init__(name, title, salary)

    def to_string(self, tab):
        super().to_string(tab)


class Senior(Employee):
    def __init__(self, name, title, salary):
        super().__init__(name, title, salary)
        self.__subordinates = []

    def add(self, employee):
        self.__subordinates.append(employee)

    def remove(self, employee):
        self.__subordinates.remove(employee)

    # def get_subordinate(self, i):
    #     return self._subordinates[i]

    def to_string(self, tab):
        super().to_string(tab)
        for an_employee in self.__subordinates:
            an_employee.to_string('\t' + tab)


if __name__ == '__main__':
    # The expected output:
    # Name: John, Title: CEO, Salary: 30000
    # 	Name: Robert, Title: Head Sales, Salary: 20000
    # 		Name: Richard, Title: Sales, Salary: 10000
    # 		Name: Rob, Title: Sales, Salary: 10000
    # 	Name: Michel, Title: Head Marketing, Salary: 20000
    # 		Name: Laura, Title: Marketing, Salary: 10000
    # 		Name: Bob, Title: Marketing, Salary: 10000
    #
    # Name: John, Title: CEO, Salary: 30000
    # 	Name: Michel, Title: Head Marketing, Salary: 20000
    # 		Name: Laura, Title: Marketing, Salary: 10000
    # 		Name: Bob, Title: Marketing, Salary: 10000

    ceo = Senior("John", "CEO", 30000)
    head_sales = Senior("Robert", "Head Sales", 20000)
    head_marketing = Senior("Michel", "Head Marketing", 20000)

    ceo.add(head_sales)
    ceo.add(head_marketing)

    sales_executive1 = Junior("Richard", "Sales", 10000)
    sales_executive2 = Junior("Rob", "Sales", 10000)

    head_sales.add(sales_executive1)
    head_sales.add(sales_executive2)

    clerk1 = Junior("Laura", "Marketing", 10000)
    clerk2 = Junior("Bob", "Marketing", 10000)

    head_marketing.add(clerk1)
    head_marketing.add(clerk2)

    # print all _subordinates of the organization
    ceo.to_string('')

    print()

    ceo.remove(head_sales)
    ceo.to_string('')

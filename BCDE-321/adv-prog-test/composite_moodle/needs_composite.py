class Junior(object):
    def __init__(self, name, title, salary):
        self.__name = name
        self.__title = title
        self.__salary = salary

    # Using @property decorator
    @property
    # Getter method
    def name(self):
        return self.__name

    @property
    def title(self):
        return self.__title

    @property
    def salary(self):
        return self.__salary

    def to_string(self, tab):
        print("{}Name: {}, Title: {}, Salary: {}".format(
            tab, self.__name, self.__title, self.__salary))


class Senior(object):
    def __init__(self, name, title, salary):
        self.__name = name
        self.__title = title
        self.__salary = salary
        self.__subordinates = []

    @property
    def name(self):
        return self.__name

    @property
    def title(self):
        return self.__title

    @property
    def salary(self):
        return self.__salary

    def add(self, employee):
        self.__subordinates.append(employee)

    def remove(self, employee):
        self.__subordinates.remove(employee)

    # def get_subordinate(self, i):
    #     return self._subordinates[i]

    def print_all_to_string(self, tab):
        print("{}Name: {}, Title: {}, Salary: {}".format(
            tab, self.__name, self.__title, self.__salary))

        for an_employee in self.__subordinates:
            if '_Senior__subordinates' in an_employee.__dict__.keys():
                an_employee.print_all_to_string('\t' + tab)
            else:
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
    ceo.print_all_to_string('')

    print()

    ceo.remove(head_sales)
    ceo.print_all_to_string('')

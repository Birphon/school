""" Example of BEFORE applying composite pattern """


class Primitive(object):
    def __init__(self, val):
        self.__value = val
        self.__type = "LEAF"

    def report_type(self):
        return self.__type

    def print_val(self):
        print('\t{}\t{}'.format(self.__value, self.__type))


class Composite(object):
    def __init__(self, val):
        self.__value = val
        self.__type = "INTERIOR"
        self.__children = []

    def report_type(self):
        return self.__type

    def add(self, composite):
        self.__children.append(composite)

    def traverse(self):
        print('{}\t{}'.format(self.__value, self.__type))
        for eachChild in self.__children:
            if eachChild.report_type() == "LEAF":
                eachChild.print_val()
            elif eachChild.report_type() == "INTERIOR":
                eachChild.traverse()


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

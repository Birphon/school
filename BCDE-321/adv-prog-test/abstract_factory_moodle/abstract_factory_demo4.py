from abc import ABCMeta, abstractmethod


class Computer(metaclass=ABCMeta):
    @abstractmethod
    def do_use(self):
        pass


class DesktopComputer(Computer):
    def do_use(self):
        print("This is the functionality of desktop computer")


class LaptopComputer(Computer):
    def do_use(self):
        print("This is the functionality of laptop computer")


class Telephone(metaclass=ABCMeta):
    @abstractmethod
    def do_use(self):
        pass


class LandlinePhone(Telephone):
    def do_use(self):
        print("This is the functionality of landline phone")


class MobilePhone(Telephone):
    def do_use(self):
        print("This is the functionality of mobile phone")


class Company(metaclass=ABCMeta):
    @abstractmethod
    def build_computer(self):
        pass

    @abstractmethod
    def build_telephone(self):
        pass


class CompanyA(Company):
    def build_computer(self):
        return DesktopComputer()

    def build_telephone(self):
        return LandlinePhone()


class CompanyB(Company):
    def build_computer(self):
        return LaptopComputer()

    def build_telephone(self):
        return MobilePhone()


def test_products(factory):
    computer = factory.build_computer()
    computer.do_use()
    telephone = factory.build_telephone()
    telephone.do_use()


if __name__ == "__main__":
    # The expected output:
    # This is the functionality of desktop computer
    # This is the functionality of landline phone
    # This is the functionality of laptop computer
    # This is the functionality of mobile phone

    test_products(CompanyA())
    test_products(CompanyB())

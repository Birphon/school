"""
Derived from
https://itnext.io/easy-patterns-composite-8b28aa1f158
"""


class Employee:
    def __init__(self, name, salary):
        self.__name = name
        self.__salary = salary

    def get_salary_info(self, indentation):
        return [[f'{" " * 4 * indentation}{self.__name}', self.__salary, 1]]


class Organization:
    def __init__(self, name):
        self.__name = name
        self.__salary = 0
        self.__employees = []

    def add_employee(self, employee):
        self.__employees.append(employee)
        return self

    def get_salaries_info(self, indentation=0):
        result = []
        num_employee = 0

        for employee in self.__employees:
            employee_salary_info = None
            if isinstance(employee, Employee):
                employee_salary_info = employee.get_salary_info(
                    indentation + 1)
            elif isinstance(employee, Organization):
                employee_salary_info = employee.get_salaries_info(
                    indentation + 1)

            self.__salary += employee_salary_info[0][1]
            num_employee += employee_salary_info[0][2]
            result += employee_salary_info

        return [[f'{" " * 4 * indentation}{self.__name}',
                 self.__salary, num_employee]] + result


if __name__ == '__main__':
    # The expected output:
    # Starship's employee salary cost is: $8000.00
    #     Assurance Management's employee salary cost is: $4500.00
    #         Ekayn's employee salary cost is: $2000.00
    #         Selesk's employee salary cost is: $1500.00
    #         Trestel's employee salary cost is: $1000.00
    #     Personnel Management's employee salary cost is: $3500.00
    #         Yerdem's employee salary cost is: $2000.00
    #         Layks's employee salary cost is: $1500.00
    #
    # Starship's average employee salary cost is: $1600.00

    organization = Organization("Starship")

    assurance_management = Organization("Assurance Management")
    assurance_management.add_employee(Employee('Ekayn', 2000)) \
        .add_employee(Employee("Selesk", 1500)) \
        .add_employee(Employee("Trestel", 1000))
    organization.add_employee(assurance_management)

    personnel_management = Organization("Personnel Management")
    personnel_management.add_employee(Employee("Yerdem", 2000)) \
        .add_employee(Employee("Layks", 1500))

    organization.add_employee(personnel_management)

    organization_salary_info = organization.get_salaries_info()

    for employee in organization_salary_info:
        print(f"{employee[0]}'s employee salary cost is: "
              f"${employee[1]:.2f}")

    print()

    # Get average salary of an organization employees
    ave_salary = organization_salary_info[0][1] \
        / organization_salary_info[0][2]
    print(
        f"{organization_salary_info[0][0]}'s average employee salary cost is: "
        f'${ave_salary:.2f}')

"""
REPLACE THIS LINE WITH YOUR NAME
"""

from abc import ABCMeta, abstractmethod


# There are two families of related products
# AbstractProductA
class StartParaTag(metaclass=ABCMeta):
    @abstractmethod
    def show(self):
        pass


# ConcreteProductA1
class XHTMLStartParaTag(StartParaTag):
    def show(self):
        return "<p>"


# ConcreteProductA2
class HTMLStartParaTag(StartParaTag):
    def show(self):
        return "<P>"


# AbstractProductB
class EndParaTag(metaclass=ABCMeta):
    @abstractmethod
    def show(self):
        pass


# ConcreteProductB1
class XHTMLEndParaTag(EndParaTag):
    def show(self):
        return "</p>"


# ConcreteProductB2
class HTMLEndParaTag(EndParaTag):
    def show(self):
        return ""


"""
The CLIENT code below currently has to make too many decisions
and know all about the food choices

Change things by applying the ABSTRACT FACTORY pattern
so the client only has to decide the type of feast
and does not need to know the details of feast preparation.

To make things simpler can you please ..
get rid of the constants (too much to remember)
get rid of the case statements (too difficult to maintain)

"""
XHTML = 1
HTML = 2


def markup(type, text):
    start_tag = end_tag = None
    if type == XHTML:
        start_tag = XHTMLStartParaTag()
    elif type == HTML:
        start_tag = HTMLStartParaTag()
    if type == XHTML:
        end_tag = XHTMLEndParaTag()
    elif type == HTML:
        end_tag = HTMLEndParaTag()
    print(start_tag.show() + text + end_tag.show())


if __name__ == "__main__":
    # Expected output:
    # ***xhtml***
    # <p>This is a test</p>
    # <p>This is a another test</p>
    # ***html***
    # <P>This is a test
    # <P>This is a another test

    print("***xhtml***")
    markup(XHTML, "This is a test")
    markup(XHTML, "This is a another test")
    print("***html***")
    markup(HTML, "This is a test")
    markup(HTML, "This is a another test")

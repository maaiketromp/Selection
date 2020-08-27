# Selection
A generic SelectionClass that generates a list of objects with a data source and factory.

This solution is part of a webbase framework, made as an assingment for a Software Development course.
It is a demonstration of how the factory pattern can be implemented.

# Problem
For a content management system I need a way to create new forms, edit existing forms on a website.
I also need a way to create new menu items for the same website.
The database stores meta data for these formfields, menuitems and more.
Now I make Lists of Formfields and lists of MenuItems, but I would like a generic solution, that quickly and easily makes a collection for me.

# Requirements
The selection needs to be generic.
The selection of type T takes a factory and model with type parameter T to create the selection.
The selection will contain a property SelectionList, that can be retrieved after the Selection object is instantiated.

# Solution
A generic Selectionclass constructor takes a model and factory as arguments.
In the constructor the selection is formed.
The model has one method: getSelection, that returns a query resultobject called IResultTable
For each row in the ResultTable the getInstance method of the factory is called, and returns a newly instantiated and populated object.


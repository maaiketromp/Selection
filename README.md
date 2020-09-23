# Selection
A generic SelectionClass that generates a list of objects with a data source and factory.

This solution is part of a webbase framework, made as an assingment for a Software Development course.
It is a also a demonstration of how the factory pattern can be implemented in relation to other classes.

# Problem
The backend of my content management application needs to create several selections of objects. These objects display forms, tables, menu items and more general, any element on a page. Data and meta-data for these elements is stored in a database. Now the programmer needs a way to get this information from the database and store it in the appropriate object, and place this object in a list. He could make a MenuItemModel, ElementModel, DisplayModel and dito factories, and solve the problem in custom code. That would mean slightly different code in each individual case. That is a bad idea, that calls for a generic solution that unites model and factory and produces a list of objects.

# Requirements
The selection needs to be generic, with a generic type parameter, indicating which type is in the selection.
The selection of type T takes a factory and model with type parameter T to create the selection.
The selection will contain a property SelectionList, that can be retrieved after the Selection object is instantiated.

# Solution
The Selectionclass is a class with a generic type parameter that takes a model and factory as dependency injections.
1. The selection is formed in a private initialization function in the class.
1. The model has an interface that determines the format of the information returned from the database.
1. The factory provides for each row of data the corresponding object, and the data is put in the object. 
1. The list of objects is then stored in the selection, to be retrieved when needed.



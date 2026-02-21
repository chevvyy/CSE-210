Overview

The Laser Order Calculator is a console-based C# application that simulates pulling order data from Google Sheets, parsing order items, filtering relevant orders, and generating a cut list for a table laser system.

The program demonstrates the principles of:
1. Abstraction
2. Encapsulation
3. Inheritance
4. Polymorphism
It runs as a cross-platform .NET console application.


Program Structure

    1. Data Layer

        Files:

        ISheetsClient.cs

        MockSheetsClient.cs

        OrderService.cs

        Purpose:

        ISheetsClient defines how sheet data is read (abstraction).

        MockSheetsClient simulates Google Sheets data.

        OrderService retrieves open orders and completed order IDs.

        This layer is responsible only for retrieving raw data.


    2. Domain Model

        Files:

        Order.cs

        OrderItem.cs

        CustomItem.cs

        RailItem.cs

        ShelfItem.cs

        StandardItem.cs

        Purpose:

        Order represents a single order.

        OrderItem is an abstract base class for all item types.

        Derived classes represent specific item types.

        This layer represents the core business objects.


    3. Logic Layer

        Files:

        OrderParser.cs

        OrderFilter.cs

        CutListBuilder.cs

        SimpleTokens.cs

        Purpose:

        OrderParser converts raw text into typed objects.

        OrderFilter removes completed orders and selects relevant ones.

        CutListBuilder builds the flattened cut list.

        SimpleTokens parses key/value strings.

        This layer processes and transforms data.


    4. Presentation Layer

        Files:

        Program.cs

        App.cs

        ConsoleView.cs

        Purpose:

        Program is the entry point.

        App orchestrates program flow.

        ConsoleView handles all console output and user interaction.

        This layer controls interaction and display only.


Object-Oriented Principles Demonstrated

    Abstraction

        ISheetsClient defines a contract for reading sheet data.

        OrderItem is an abstract base class.

        Derived item classes implement their own parsing behavior.

        Abstraction separates what something does from how it does it.


    Encapsulation

        All member variables are private and follow _underscoreCamelCase.

        Public properties expose controlled access.

        Order.Items is exposed as IReadOnlyList to prevent external modification.

        Each class manages its own internal data safely.


    Inheritance

        OrderItem contains shared attributes:

        Quantity

        Width

        Height

        Area calculation

        CustomItem, RailItem, ShelfItem, and StandardItem inherit from it.

        Shared behavior is placed in the base class and reused by child classes.


    Polymorphism

        The program uses method overriding:

        Parse() is overridden in each item type.

        Category() is overridden.

        IsInteresting() is virtual in the base class and overridden in specific types.

        This allows the program to treat all items as OrderItem while still executing type-specific behavior.


How to Run

    Open the solution in Visual Studio or VS Code.

    Build the project.

    Run the program.

    Use the console menu:

    Show interesting orders

    Show cut list

    Refresh data

    Exit

    The program runs without runtime errors.
﻿using DesignPatterns.Behavior.Observer;
using DesignPatterns.Behavior.Strategy;
using DesignPatterns.Creation.FactoryMethod;
using DesignPatterns.Structural.Adapter;
using DesignPatterns.Structural.Bridge;
using DesignPatterns.Structural.Decorator;
using DesignPatterns.Structural.Facade;
using DesignPatterns.Structural.Proxy;

// -------------------------------------------------------------------------------------------------------
// Behavior patterns
// -------------------------------------------------------------------------------------------------------

// Observer pattern - Instead of poll/pull do a push
// Define a subscription mechanism to notify objects observing a change
ObserverPatternExample.Run();

// Strategy pattern - Defines a family of algorithms, encapsulates each and one and makes them interchangeable
// Decouple the business logic from algorithms whose inner logic is unimportant
// We are only interested in the output of the algorithm and not the inner logic of it 
// Plug-n-play algorithms
StrategyPatternExample.Run();

// -------------------------------------------------------------------------------------------------------
// Creation patterns
// -------------------------------------------------------------------------------------------------------

// Factory method pattern - provide an interface for creating objects in a superclass,
// but allows subclasses to alter the type of objects that will be created
// abstracts the object instantiation from client application 
FactoryMethodPatternExample.Run();

// -------------------------------------------------------------------------------------------------------
// Structural
// -------------------------------------------------------------------------------------------------------

// Bridge pattern - split a large class or a set of closely related classes into two separate hierarchies
// —abstraction and implementation— which can be developed independently of each other
BridgePatternExample.Run();

// Adapter pattern - Allow objects with incompatible interfaces to collaborate
AdapterPatternExample.Run();

// Decorator pattern - Attach new behaviors to objects by placing these objects inside special
// wrapper objects that contain the behaviors
DecoratorPatternExample.Run();

// Facade pattern - Provide a simplified interface to a library, a framework, or any other complex set of classes.
FacadePatternExample.Run();

// Proxy pattern - provide a substitute or placeholder for another object. A proxy controls access to the original object,
// allowing you to perform something either before or after the request gets through to the original object
ProxyPatternExample.Run();

Console.ReadLine();




# Javascript

## Questions
### Javascript genral
- What are some primitive types javascript support?
    - boolean, number, string, undefined, null, big int, symbol
- What are 3 different variable scopes in JS?
    - block, function, global
- What's the difference between let and const?
    - const cannot be reassigned a value

### Connecting JS and HTML: DOM and Events
- What is Document Object Model (DOM)?
    - Document is represented as a tree of nodes, where each node contains objects
    - Allows programs to access and manipulate HTML document content, structure, and presentation
- List 3 different ways to select an element from the DOM
    - getElementById, getElementsByClassName, querySelector, querySelectorAll
- List the steps to have new elements appear on a webpage
    - document.createElement("div");
    - created.textContent = "text";
    - document.body.appendChild(created);
- List at least 5 web browser events
    - onClick, onFocus, onBlur, onHover, onMouseEnter, onMouseLeave
- What are event listeners?
    - Functions that listen for specific events to occur on a webpage
    - When event happens, function is triggered
- What is bubbling and capturing in event? 
    - Bubbling refers to when an event triggered on an child element travels up the DOM tree to its parent elements
    - Capturing is when an event starts at the top of the DOM and travels down to the target element
    - Both are phases of event propagation
    - Allows for more controlled event handling on nested elements

### Asynchronous JS
- What do you use to make HTTP calls in javascript?
    - Async Fetch API
- What is Promise? How do you handle success/error cases?
    - Similar to a Task in C#
    - Resolve for success, reject for error
- How is JSON different from javascript objects?
    - JSON is a string representation of a JavaScript object and is static
    - JS objects can be manipulated and are in-memory data

### Object Oriented Javascript
- How do you create class defn in javascript? 
    - class keyword
- How do you create constructor in class defn?
    - constructor keyword
- How do you define class fields? (!the syntax is quite a bit different from C#!)
    - variable name (optionally assign a value)
    - no type definition in vanilla JS
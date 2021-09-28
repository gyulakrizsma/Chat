# Chat

This project solves the Chat challenge found here: https://github.com/arminwrobel/hiring-challenges/tree/master/fullstack-engineer

## Technology choices

### SignalR

To write a chat application, a real-time information presentation is preferrable. For that you can choose to implement a pulling mechanism which logic would in a certain time frame ask for new messages in the chat. This is not an elegant solution in this case, not to mention that it has performance limitations as well. For these use cases I would use the websockets protocol and for that in the Microsoft world the SignalR framework is the ideal choice. Therefore I have implemented an ASP NET 5 WebApi application which implements a Chat hub, which satisfies the Chat functionality uses cases. 

### ASP NET 5 WebApi

For getting the messages in a chronological order and to add a new message I thought that a REST API would be needed. These use cases are different from the Chat capabilities  of being able to send a message and broadcast that throughout the connected clients. Therefore I have created a simple `ChatApi` to satisfy the above mentioned use cases.

### AutoMapper

Distinguishing between the actual domain models and the Data Transfer Objects are necessary. I have seen multiple applications where the API just sends the actual domain model to the client. I think it is a bad practice. The client should get from an API exactly what the client needs and nothing more. To solve this problem of mapping DTOs to domain models, I have introduced the `AutoMapper` C# library.

### MediatR

I find the Command Query Responsibility Segregation (CQRS) pattern a very clean way of isolating the Queries from the Commands. With this solution if needed then the Queries or the Commands could be scaled separately from each other depending on the requirements of the application. With the MediatR library in C# the CQRS pattern could be implemented in a very clean way. I am aware that for this small application it could be an overkill to use CQRS and introduce complexity instead but for demo purposes and for a bigger application I would definitely use this pattern. With the usage of the MediatR library the Api Controllers are very simple and clean.

### Architecture

For this application I chose to use an Onion Architecture. I am a huge advocate of Domain Driven Design and it synergises perfectly with the CQRS pattern (Event Sourcing) and the Onion Architecture. Most probably it is again an overkill for this small system but that is how I would approach a bigger project. It cleanly separates the code in my opinion.

### AngularJS

To build a simple Chat application I wanted to use AngularJS. It allowed me to quickly put together a simple Frontend for this application. I followed the style guide of John Papa to write Clean Code in AngularJS. https://github.com/johnpapa/angular-styleguide/blob/master/a1/README.md

## What would I do differently if I had more time

- I would definitely write much more error handling in the Frontend. Because of the time constraint I don't handle errors in the FE which is bad practice in general. 
- I would probably introduce Typescript in the FE as well to have type support and catch errors or typos during development time.
- FE Infrastructure: I would probably introduce either gulp or webpack in the FE to be able to use less files in the FE and generate them immediately. Additionally I would introduce FE bundling and minification as well to further optimize the performance of the application.
- More testing: Although I have introduced Unit tests for the project, Integration testing would be needed and E2E tests as well.


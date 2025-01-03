# HTTP, REST

## HTTP
- What does HTTP stand for? What is it?
	- Hypertext Transfer Protocol is a request-response between client and server
- Describe req/res cycle
- Describe parts of HTTP Request and Response
- What is header?
	- Metadata
- what is method/request verb and give examples of them.
- What do you put in request body?
- What is a response code?
- Describe 5 categories of response codes and what they mean in general
	- 100 Continue
		- Initial part of request has been received and not yet been acted on
	- 300 Multiple Choices
		- More than one possible response

## REST
- What is REST?
- What does it mean for an API to be RESTful?
- Describe the following guiding principles/constraints:
	- Client-Server
	- Stateless
	- Cache
	- Uniform Interface
		- All resources are manipulated using a standard set of HTTP methods
		- Ensures consistency in how clients interact with a server
	- Layered System
		- APIs deployed on one server, data stored on another, and requests authenticated on a third
		- Client is unaware if connected to end server or intermediary
	- Code on Demand
		- Obsolete
		- Sends executable software code from server to client
# ShoppingBasketService

This service is an Azure function. 
It has 3 functions exposed
  1. GetProducts
  2. GetDeliveryFee and
  3. PlaceOrder
  
Architecture is an onion arhitecture with the outermost layer being the Function followed by Application and Domain.

It uses Command Query Repository Pattern (CQRS) for sending requests into the application layer.

It is a very simplified form of Domain Drivern Design (complete DDD implementation can be done if required).




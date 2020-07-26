# ShoppingBasketService

This service is an Azure function. 
It has 3 functions exposed
  1. GetProducts
  2. GetDeliveryFee and
  3. PlaceOrder
  
Architecture is an onion arhitecture with the outermost layer being the Function followed by Application and Domain.
(onion arhitecture: https://www.thinktocode.com/2018/08/16/onion-architecture/)

It uses Command Query Repository Pattern (CQRS) (https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) 
for sending requests into the application layer.

It is a very simplified Anemic form of Domain Drivern Design (complete DDD implementation can be done if required).
(DDD: https://martinfowler.com/tags/domain%20driven%20design.html)




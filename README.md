# ShopMicroServices

Thanks For The Opportunity.

This is  my Solution. 
See The Architecture Image Below.

As Requested From the Question, I set up a Service bus (RabbitMq) Through the **MassTransit** and **MassTransit.RabbitMq** Nugget Packages and the Two Services I expanded on are The **CartService** 
and the **ProductInventoryService**. They Communicate Through a Fan exanchage. The Other services are empty and just describe how the microservice would look like.

The **ProductInventoryService** Publisheds a message to the broker when a product is added to its own the db.
A Consumer is SetUp in The CartService that receives the productAdded message from the broker and creates a replica product twin to its own Db. The CartService Uses this product twin to perforn the 
add to cart operation.

I Also Created the Controller and Repositories that performs AddToCart in The CartService. 

I Also Created Locally Two SqlServer Databases with EntityFrameWorkCore For the ProductInventoryService and TheProductService.

I Also Integrated RabbitMq to Both ProductInventoryService and CartService. I Provided A reference docker-compose file that will be use to pull and run
the rabbitMq image.

**Defining The Design Pattern** :  
The Main Design Pattern I'm using is The Bridge Pattern under the Structural patterns where I decouple an abstraction from its implementation so that the two can vary independently.

This is The Architecture Image Below.

Thanks again for the oppurtunity.

![microservice architechture (1)](https://user-images.githubusercontent.com/79382311/189484453-25f2b964-3909-4766-a74c-ec37e8fa1ff6.jpg)

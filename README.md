## Catalog

### Setting Up The Project:
This project uses a MongoDB docker image for its database and persistent storage. The preferred GUI for interacting with the database is MongoDB Compass (optional).
It also uses Postman API Platform for sending requests, as Swagger has been disabled in app settings. The links for downloading these resources are listed below:
- [Download Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Download MongoDB Compass](https://www.mongodb.com/try/download/compass) (optional)
- [Download Postman API](https://www.postman.com/downloads/)

Once the downloads are complete, go ahead and pull the project to local system. As this is a .NET project, any IDE with .NET SDK installed will work. 
(Visual Studio and Visual Studio Code are preferred).

### Launching MongoDB using Docker Desktop:
The next step is to launch an instance of MongoDB using Docker Desktop. Using terminal of choice, enter the following code:
```
docker run -d --name <nameofproject> -p 27017:27017 -v <nameofdatabase>:/data/db mongo
```

### Interacting with the API:
The last step is to interact with your REST API. To do this, run the project from local repository.
Once the project is running, open Postman API. In the address bar, type the following:
```
https://localhost:5001/items
```
Now you're ready to interact with the API!

### Request Types:
At first, your database will be empty because you haven't added any items. Test out the API in the following request sequence for the best experience.
#### POST
Start with a POST request to add some items to the Catalog. Make sure to send a raw JSON object in the body using the following format:
```
{
  "name" : "<Name of Object>" (string)
  "price" : (decimal or int)
}
```
This will generate your item with a Guid as ID, the name and price you specified, and the date of creation.
#### GET
A GET request will return all the items you added to your database using the POST method.
#### GET {with id}
If you paste the id of item at the end of a GET request, you can retrieve that specific item.
#### PUT {with id}
A PUT request with the id of the item, and a raw JSON like the one shown in the POST method will allow you to modify that existing item to change its name or price.
#### DELETE {with id}
A DELETE request with the id of the item will allow you to delete that particular item.

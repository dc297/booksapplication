# Books Application

A dotnet API application with Angular Front End to demonstrate the usage of:

    - Entity Framework v2.1.2

    - Redis v5.0.0

    - MongoDB v4.0

    - ElasticSearch v6.2.4

    - PostgreSQL v11.0

    - dotnet v2.1

    - Angular v7.0.0


This is a simple application to maintain details about books divided into 4 parts:

    1. The home page fetches all the books present in the PostgreSQL database and their cover images present in MongoDB.

    2. The Search page fetches suggestions and search results from ElasticSearch.

    3. Add page allows you to add a book and it's cover. The book details are added to PostgreSQL and ElasticSearch. The cover is added to MongoDB with it's key saved to PostgreSQL. Each add increments the book counter in redis and if a new author is added, it increments the author count in redis as well.

    4. The stats page fetches Number of requests from your IP, books count and authors count from Redis. Each request increments the number of requestes from your IP counter in redis. I have used a middleware in dotnet application to increment request count in redis.

# Building/Running the app:

## Prerequisites

### 1. Git
	1. Install git from this link : https://git-scm.com/downloads
	
Install Git

Windows: Enable Hyper-V - https://docs.microsoft.com/en-us/virtualization/hyper-v-on-windows/quick-start/enable-hyper-v

Install Docker from https://www.docker.com/products/docker-desktop
Test docker installation by running > docker ps



Download and install .NET core SDK from https://www.microsoft.com/net/download



Clone the repo from https://github.com/dc297/booksapplication/

Install nodejs and npm from https://nodejs.org/en/

Steps to build/run from source:
1. Change directory to booksapplication/BooksApplication/
2. Deploy postgresql, elasticsearch, mongodb and redis on Docker by executing the following command > docker-compose up
3. Build the application by executing > dotnet build 
4. Run npm i
5. Run the application by executing run.bat

Steps to deploy the app on docker:
1. Change directory to booksapplication/
2. Deploy  postgresql, elasticsearch, mongodb, redis and the application by executing > docker-compose up
3. The above step uses a image hosted on docker hub to run the app.

Steps to deploy the app on Kubernetes Cluster(using minikube):

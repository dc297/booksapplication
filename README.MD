# Books Application

A dotnet API application with Angular Front End to demonstrate the usage of:

    - Entity Framework v2.1.2

    - Redis v5.0.0

    - MongoDB v4.0

    - ElasticSearch v6.2.4

    - PostgreSQL v11.0

    - dotnet v2.1

    - Angular v7.0.0

Before running the application, make sure you have installed Docker and it is running on your machine. For getting started with Docker, follow this link : https://www.docker.com/products/docker-desktop

Test your docker installation following the steps on this link : https://docs.docker.com/get-started/#test-docker-installation

Running using docker-compose:

    1. cd to DockerHubCompose

    2. Run docker-compose up

    3. Wait for the application to start

    4. The application will be available at http://localhost:60834

This is a simple application to maintain details about books divided into 4 parts:

    1. The home page fetches all the books present in the PostgreSQL database and their cover images present in MongoDB.

    2. The Search page fetches suggestions and search results from ElasticSearch.

    3. Add page allows you to add a book and it's cover. The book details are added to PostgreSQL and ElasticSearch. The cover is added to MongoDB with it's key saved to PostgreSQL. Each add increments the book counter in redis and if a new author is added, it increments the author count in redis as well.

    4. The stats page fetches Number of requests from your IP, books count and authors count from Redis. Each request increments the number of requestes from your IP counter in redis. I have used a middleware in dotnet application to increment request count in redis.


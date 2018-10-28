# Books Application

A dotnet API application with Angular Front End to demonstrate the usage of:

    - Entity Framework v2.1.2

    - Redis v5.0.0

    - MongoDB v4.0

    - ElasticSearch v6.2.4

    - PostgreSQL v11.0

    - .NET core v2.1

    - Angular v7.0.0


This is a simple application to maintain details about books divided into 4 parts:

    1. The home page fetches all the books present in the PostgreSQL database and their cover images present in MongoDB.

    2. The Search page fetches suggestions and search results from ElasticSearch.

    3. Add page allows you to add a book and it's cover. The book details are added to PostgreSQL and ElasticSearch. The cover is added to MongoDB with it's key saved to PostgreSQL. Each add increments the book counter in redis and if a new author is added, it increments the author count in redis as well.

    4. The stats page fetches Number of requests from your IP, books count and authors count from Redis. Each request increments the number of requestes from your IP counter in redis. I have used a middleware in dotnet application to increment request count in redis.

# Building/Running the app:

A video demonstration is available here : https://goo.gl/EvP3fZ

## Prerequisites

### 1. Git

	1. 
		1.1 Ubuntu: Install git by executing > sudo apt-get install git
		1.2 Others: Install git from the following URL : https://git-scm.com/downloads
	
### 2. Docker

	1. Install Docker from the following links : [https://docs.docker.com/install/]
	
	2. Test docker installation by executing > docker version
	
	3. Test if docker-compose is installed by executing > docker-compose version
	
	4. If docker-compose is not installed, install it by following Step #3

### 3. Docker-Compose

	1. Depending on your operating system, you might need to install docker-compose separately. Install it from the following URL : [https://docs.docker.com/compose/install/#install-compose]
	
### 4. .NET Core 2.1

	1. Download and install .NET core SDK from [https://www.microsoft.com/net/download]
	
	2. Check .Net version by executing > dotnet --version

### 5. Nodejs and npm

	1. Install nodejs and npm from [https://nodejs.org]
	
	2. Check node installation by executing > node -v
	
### 6. Clone the repo from https://github.com/dc297/booksapplication/

	1. Execute git clone https://github.com/dc297/booksapplication/ to clone the repo

## Now you are ready to build/run from source or deploy to docker. If you want to deploy to a kubernetes cluster install the requisites below

### 7. kubectl

	1. Install kubectl from the following link : [https://kubernetes.io/docs/tasks/tools/install-kubectl/#install-kubectl]
	2. Test kubectl installation by executing > kubectl version
	
### 8. minikube

	1. Install minikube from the following link : [https://github.com/kubernetes/minikube/releases]
	2. Check minikube installation by executing > minikube version
	3. Start minikube
		2.1 On Ubuntu, use the following command : > minikube start --vm-driver=none --logtostderr
### 9. Helm

	1. Download and install helm from the following link : [https://github.com/helm/helm/releases]
	2. Check helm installation by executing > helm version
	3. Add binaries to path so that they are executable from Terminal/Command line


## Steps to build/run from source:

	1. Change directory to booksapplication/BooksApplication/
	
	2. When using Ubuntu, we need to increase the max value of map_count for elasticsearch. Execute > sudo sysctl -w vm.max_map_count=262144
	
	2. Deploy postgresql, elasticsearch, mongodb and redis on Docker by executing the following command > docker-compose up
	
	3. Open another terminal. Change directory to booksapplication/BooksApplication
	
	4. Build the application by executing > dotnet build 
	
	5. Install required node modules by executing > npm i
	
	6. Run the application by executing run.bat or run.sh
	
	7. By default, the application will be available at [http://localhost:5000]

## Steps to deploy the app on docker:

	1. Change directory to booksapplication/
	
	2. Deploy  postgresql, elasticsearch, mongodb, redis and the application by executing > docker-compose up
	
	3. The above step uses a image hosted on docker hub to run the app.
	
	4. The application will be accessible on [http://localhost:60834] by default. You can change this by editing the docker-compose.yml file in this directory.

## Steps to deploy the app on Kubernetes Cluster(using minikube):

	1. Change directory to booksapplication/helm
	
	2. Execute > helm init
	
	3. Depending on your operating system, you might need to install socat to deploy using helm. Execute the following command to install socat > sudo apt-get install socat
	
	4. Execute the following command to deploy to a kubernetes cluster > helm install --name booksapplication ./mychart --set service.type=NodePort
	
	5. You can get the url for the application from the output of above command. Once the application starts, it will be available for use at that url
	
	6. Use minikube dashboard to monitor your pods. Start the dashboard by executing > minikube dashboard
	
	7. You might need to manually restart the booksapplication pod because sometimes the database takes more time to start than the application itself. I need to add a check to throw an exception if all the required services are not available yet.

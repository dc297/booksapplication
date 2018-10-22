FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base

# Setup NodeJs
#RUN apt-get update && \
#    apt-get install -y wget && \
#    apt-get install -y gnupg2 && \
#    wget -qO- https://deb.nodesource.com/setup_8.x | bash - && \
#    apt-get install -y build-essential nodejs
# End setup

WORKDIR /app
EXPOSE 60834
EXPOSE 44370

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY BooksApplication/BooksApplication.csproj BooksApplication/
RUN dotnet restore BooksApplication/BooksApplication.csproj
COPY . .
WORKDIR /src/BooksApplication

RUN dotnet build BooksApplication.csproj -c Release -o /app

FROM node:8
COPY ./BooksApplication/package*.json ./
RUN npm i

FROM build AS publish
RUN dotnet publish BooksApplication.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BooksApplication.dll", "--urls", "http://*:5000;http://*:5001"]

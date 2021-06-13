# A Service for calculating distances between 2 airports

### Building

#### Using dotnet CLI

`dotnet build`

#### Using docker

`docker build . -t airport-distance`

#### Using docker-compose

`docker-compose build`

### Running

#### Using dotnet CLI

`dotnet run`

#### Using docker

`docker run -p 8888:80 -e ASPNETCORE_ENVIRONMENT=Development airport-distance`

#### Using docker-compose

`docker-compose up`

### Additional

Service exposes a swagger-ui on `~/swagger` URL

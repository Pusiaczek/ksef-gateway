db-start:
	docker compose -f ./docker/docker-compose.yaml up -d
 
db-stop:
	docker compose -f ./docker/docker-compose.yaml down
 
start:
	dotnet watch run --project src/KsefGateway.csproj

build:
	dotnet build src/KsefGateway.csproj
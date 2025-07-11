# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["AirportWarehouse/AirportWarehouse.csproj", "AirportWarehouse/"]
COPY ["AirportWarehouse.Core/AirportWarehouse.Core.csproj", "AirportWarehouse.Core/"]
COPY ["AirportWarehouse.Infrastructure/AirportWarehouse.Infrastructure.csproj", "AirportWarehouse.Infrastructure/"]
RUN dotnet restore "./AirportWarehouse/AirportWarehouse.csproj"
COPY . .
WORKDIR "/src/AirportWarehouse"
RUN dotnet build "./AirportWarehouse.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AirportWarehouse.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
USER root
RUN apt-get update && apt-get install -y curl
COPY --from=publish /app/publish .
USER app

ENTRYPOINT ["dotnet", "AirportWarehouse.dll"]
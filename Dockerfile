FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AirportWarehouse/AirportWarehouse.csproj", "./"]
RUN dotnet restore "AirportWarehouse.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "AirportWarehouse/AirportWarehouse.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build as publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AirportWarehouse/AirportWarehouse.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "AirportWarehouse.dll"]



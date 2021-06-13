FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["airport-distance.csproj", "./"]
RUN dotnet restore "airport-distance.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "airport-distance.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "airport-distance.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "airport-distance.dll"]

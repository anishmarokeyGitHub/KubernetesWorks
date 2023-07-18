FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["ANVR.ServiceB-API/ANVR.ServiceB-API.csproj", "ANVR.ServiceB-API/"]
RUN dotnet restore "ANVR.ServiceB-API/ANVR.ServiceB-API.csproj"
COPY . .
WORKDIR "/src/ANVR.ServiceB-API"
RUN dotnet build "ANVR.ServiceB-API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "ANVR.ServiceB-API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ANVR.ServiceB-API.dll"]

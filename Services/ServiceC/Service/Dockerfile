FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["ANVR.ServiceC-API/ANVR.ServiceC-API.csproj", "ANVR.ServiceC-API/"]
RUN dotnet restore "ANVR.ServiceC-API/ANVR.ServiceC-API.csproj"
COPY . .
WORKDIR "/src/ANVR.ServiceC-API"
RUN dotnet build "ANVR.ServiceC-API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "ANVR.ServiceC-API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ANVR.ServiceC-API.dll"]

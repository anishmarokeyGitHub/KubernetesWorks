FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["ANVR.ServiceA-API/ANVR.ServiceA-API.csproj", "ANVR.ServiceA-API/"]
RUN dotnet restore "ANVR.ServiceA-API/ANVR.ServiceA-API.csproj"
COPY . .
WORKDIR "/src/ANVR.ServiceA-API"
RUN dotnet build "ANVR.ServiceA-API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "ANVR.ServiceA-API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ANVR.ServiceA-API.dll"]

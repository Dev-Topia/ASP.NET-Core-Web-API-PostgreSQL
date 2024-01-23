# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# WORKDIR /app
# EXPOSE 80

# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /src
# COPY ["WebApiWithPostgreSQL.csproj", ""]
# RUN dotnet restore "./WebApiWithPostgreSQL.csproj"
# COPY . .
# WORKDIR "/src/."
# RUN dotnet build "WebApiWithPostgreSQL.csproj" -c Release -o /app/build  

# FROM build AS publish
# RUN dotnet publish "WebApiWithPostgreSQL.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "WebApiWithPostgreSQL.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
COPY . /src
WORKDIR /src
RUN ls
RUN dotnet build "WebApiWithPostgreSQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiWithPostgreSQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiWithPostgreSQL.dll"]


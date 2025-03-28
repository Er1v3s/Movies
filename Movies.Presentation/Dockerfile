## See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
## This stage is used when running from VS in fast mode (Default for Debug configuration)
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#
## This stage is used to build the service project
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["Movies.Presentation/Movies.Presentation.csproj", "Movies.Presentation/"]
#RUN dotnet restore "./Movies.Presentation/Movies.Presentation.csproj"
#COPY . .
#WORKDIR "/src/Movies.Presentation"
#RUN dotnet build "./Movies.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
## This stage is used to publish the service project to be copied to the final stage
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./Movies.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
## This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Movies.Presentation.dll"]

FROM mcr.microsoft.com/mssql/server:2019-latest
RUN apt-get update && apt-get install -y mssql-tools unixodbc-dev
ENV PATH="$PATH:/opt/mssql-tools/bin"


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

EXPOSE 3000
EXPOSE 3001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development

WORKDIR /src

COPY ["Movies.Presentation/Movies.Presentation.csproj", "Movies.Presentation/"]
COPY ["Movies.Infrastructure/Movies.Infrastructure.csproj", "Movies.Infrastructure/"]
COPY ["Movies.Domain/Movies.Domain.csproj", "Movies.Domain/"]
COPY ["Movies.Application/Movies.Application.csproj", "Movies.Application/"]
COPY ["Movies.Contracts/Movies.Contracts.csproj", "Movies.Contracts/"]

RUN dotnet restore "./Movies.Presentation/Movies.Presentation.csproj"

COPY . .

WORKDIR "/src/Movies.Presentation"

RUN dotnet build "./Movies.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Development

RUN dotnet publish "./Movies.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Movies.Presentation.dll"]
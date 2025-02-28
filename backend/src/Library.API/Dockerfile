FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Library.API/Library.API.csproj", "src/Library.API/"]
COPY ["src/Library.Infrastructure/Library.Infrastructure.csproj", "src/Library.Infrastructure/"]
COPY ["src/Library.Domain/Library.Domain.csproj", "src/Library.Domain/"]
COPY ["src/Library.Application/Library.Application.csproj", "src/Library.Application/"]
RUN dotnet restore "src/Library.API/Library.API.csproj"
COPY . .
WORKDIR "/src/src/Library.API"
RUN dotnet build "Library.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Library.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Library.API.dll"]

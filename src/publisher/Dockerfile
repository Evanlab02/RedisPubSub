FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["Program.cs", "Worker.cs", "publisher.csproj", "appsettings.json", "/src/"]
RUN dotnet restore "./publisher.csproj"

ARG BUILD_CONFIGURATION=Release
RUN dotnet build "./publisher.csproj" -c "$BUILD_CONFIGURATION" -o /app/build/ && \
    dotnet publish "./publisher.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

COPY --from=build /app/publish .
ENTRYPOINT [ "dotnet", "publisher.dll" ]

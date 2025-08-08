# Usar la imagen base de .NET 9 runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Usar la imagen de SDK de .NET 9 para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["LoginAPI/LoginAPI.csproj", "LoginAPI/"]
RUN dotnet restore "LoginAPI/LoginAPI.csproj"
COPY . .
WORKDIR "/src/LoginAPI"
RUN dotnet build "LoginAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoginAPI.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoginAPI.dll"]

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Fcg.Notifications.Api/Fcg.Notifications.Api.csproj Fcg.Notifications.Api/
RUN dotnet restore Fcg.Notifications.Api/Fcg.Notifications.Api.csproj

COPY . .
RUN dotnet publish Fcg.Notifications.Api/Fcg.Notifications.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

USER app

EXPOSE 8080
ENTRYPOINT ["dotnet", "Fcg.Notifications.Api.dll"]

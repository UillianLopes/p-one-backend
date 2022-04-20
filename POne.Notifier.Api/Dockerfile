FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 443 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["POne.Notifier.Api/POne.Notifier.Api.csproj", "POne.Notifier.Api/"]
RUN dotnet restore "POne.Notifier.Api\POne.Notifier.Api.csproj"
COPY . .
WORKDIR "/src/POne.Notifier.Api"
RUN dotnet build "POne.Notifier.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POne.Notifier.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POne.Notifier.Api.dll"]

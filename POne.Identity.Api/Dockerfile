FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

EXPOSE 443 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["POne.Identity.Api/POne.Identity.Api.csproj", "POne.Identity.Api/"]
RUN dotnet restore "POne.Identity.Api\POne.Identity.Api.csproj"
COPY . .
WORKDIR "/src/POne.Identity.Api"
RUN dotnet build "POne.Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POne.Identity.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POne.Identity.Api.dll"]

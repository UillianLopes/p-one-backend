FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 6000 6001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["POne.Financial.Api/POne.Financial.Api.csproj", "POne.Financial.Api/"]
RUN dotnet restore "POne.Financial.Api\POne.Financial.Api.csproj"
COPY . .
WORKDIR "/src/POne.Financial.Api"
RUN dotnet build "POne.Financial.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POne.Financial.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POne.Financial.Api.dll"]

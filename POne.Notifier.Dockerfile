FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
EXPOSE 80 443

# Copy everything
COPY . ./

# Restore as distinct layers
RUN dotnet restore "POne.Notifier.Api/POne.Notifier.Api.csproj"

# Build and publish a release
RUN dotnet publish -c Debug -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "POne.Notifier.Api.dll"]
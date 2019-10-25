FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Rebus.Consumer/Rebus.Consumer.csproj", "Rebus.Consumer/"]
RUN dotnet restore "Rebus.Consumer/Rebus.Consumer.csproj"
COPY . .
WORKDIR "/src/Rebus.Consumer"
RUN dotnet build "Rebus.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rebus.Consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rebus.Consumer.dll"]
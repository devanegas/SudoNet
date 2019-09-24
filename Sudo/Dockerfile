FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Sudo/Sudo.csproj", "Sudo/"]
RUN dotnet restore "Sudo/Sudo.csproj"
COPY . .
WORKDIR /src/Sudo/
RUN dotnet build "Sudo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sudo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sudo.dll"]
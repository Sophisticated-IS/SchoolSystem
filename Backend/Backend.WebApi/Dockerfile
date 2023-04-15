FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Backend/Backend.WebApi/Backend.WebApi.csproj", "Backend/Backend.WebApi/"]
COPY ["Backend/Backend.Application/Backend.Application.csproj", "Backend/Backend.Application/"]
COPY ["Backend/Backend.Domain/Backend.Domain.csproj", "Backend/Backend.Domain/"]
COPY ["Backend/Backend.Persistence/Backend.Persistence.csproj", "Backend/Backend.Persistence/"]
RUN dotnet restore "Backend/Backend.WebApi/Backend.WebApi.csproj"
COPY . .
WORKDIR "/src/Backend/Backend.WebApi"
RUN dotnet build "Backend.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Backend.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.WebApi.dll"]

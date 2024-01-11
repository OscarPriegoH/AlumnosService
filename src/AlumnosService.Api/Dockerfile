#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/AlumnosService.Api/AlumnosService.API.csproj", "src/AlumnosService.Api/"]
COPY ["src/AlumnosService.Persistence/AlumnosService.Persistence.csproj", "src/AlumnosService.Persistence/"]
COPY ["src/AlumnosService.Application/AlumnosService.Application.csproj", "src/AlumnosService.Application/"]
COPY ["src/AlumnosService.Domain/AlumnosService.Domain.csproj", "src/AlumnosService.Domain/"]
RUN dotnet restore "src/AlumnosService.Api/AlumnosService.API.csproj"
COPY . .
WORKDIR "/src/src/AlumnosService.Api"
RUN dotnet build "AlumnosService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AlumnosService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlumnosService.API.dll"]
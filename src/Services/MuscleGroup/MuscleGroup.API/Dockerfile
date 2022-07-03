#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/MuscleGroup/MuscleGroup.API/MuscleGroups.API.csproj", "Services/MuscleGroup/MuscleGroup.API/"]
RUN dotnet restore "Services/MuscleGroup/MuscleGroup.API/MuscleGroups.API.csproj"
COPY . .
WORKDIR "/src/Services/MuscleGroup/MuscleGroup.API"
RUN dotnet build "MuscleGroups.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MuscleGroups.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MuscleGroups.API.dll"]
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TasksAPI.Services/TasksAPI.Services.csproj", "TasksAPI.Services/"]
COPY ["TasksAPI.Application/TasksAPI.Application.csproj", "TasksAPI.Application/"]
COPY ["TasksAPI.Domain/TasksAPI.Domain.csproj", "TasksAPI.Domain/"]
COPY ["TasksAPI.Data/TasksAPI.Data.csproj", "TasksAPI.Data/"]
COPY ["TasksAPI.Messages/TasksAPI.Messages.csproj", "TasksAPI.Messages/"]
RUN dotnet restore "TasksAPI.Services/TasksAPI.Services.csproj"
COPY . .
WORKDIR "/src/TasksAPI.Services"
RUN dotnet build "TasksAPI.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TasksAPI.Services.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TasksAPI.Services.dll"]
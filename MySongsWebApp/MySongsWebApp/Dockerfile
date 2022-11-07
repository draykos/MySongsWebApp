#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MySongsWebApp/MySongsWebApp.csproj", "MySongsWebApp/"]
RUN dotnet restore "MySongsWebApp/MySongsWebApp.csproj"
COPY . .
WORKDIR "/src/MySongsWebApp"
RUN dotnet build "MySongsWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MySongsWebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MySongsWebApp.dll"]
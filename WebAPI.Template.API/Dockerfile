#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebAPI.Template.API/WebAPI.Template.API.csproj", "WebAPI.Template.API/"]
RUN dotnet restore "WebAPI.Template.API/WebAPI.Template.API.csproj"
COPY . .
WORKDIR "/src/WebAPI.Template.API"
RUN dotnet build "WebAPI.Template.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI.Template.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.Template.API.dll"]
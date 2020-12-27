#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["VideoChat.Web/VideoChat.Web.csproj", "VideoChat.Web/"]
RUN dotnet restore "VideoChat.Web/VideoChat.Web.csproj"
COPY . .
WORKDIR "/src/VideoChat.Web"
RUN dotnet build "VideoChat.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VideoChat.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VideoChat.Web.dll"]
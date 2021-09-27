#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Chat.Web/Chat.Web.csproj", "Chat.Web/"]
COPY ["Chat.Application/Chat.Application.csproj", "Chat.Application/"]
COPY ["Chat.Domain/Chat.Domain.csproj", "Chat.Domain/"]
COPY ["Chat.Persistence/Chat.Persistence.csproj", "Chat.Persistence/"]
RUN dotnet restore "Chat.Web/Chat.Web.csproj"
COPY . .
WORKDIR "/src/Chat.Web"
RUN dotnet build "Chat.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Chat.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Chat.Web.dll"]
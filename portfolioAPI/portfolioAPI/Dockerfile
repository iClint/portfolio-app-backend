FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["portfolioAPI/portfolioAPI.csproj", "portfolioAPI/"]
RUN dotnet restore "portfolioAPI/portfolioAPI.csproj"
COPY . .
WORKDIR "/src/portfolioAPI"
RUN dotnet build "portfolioAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "portfolioAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "portfolioAPI.dll"]

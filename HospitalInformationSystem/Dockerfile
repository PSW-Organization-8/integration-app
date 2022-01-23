FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base

RUN groupadd -g 5000 appuser && \
    useradd  -u 5000 -g appuser appuser

USER appuser:appuser

WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["IntegrationAPI/IntegrationAPI.csproj", "IntegrationAPI/"]
COPY ["IntegrationClassLib/IntegrationClassLib.csproj", "IntegrationClassLib/"]
RUN dotnet restore "IntegrationAPI/IntegrationAPI.csproj"
COPY . .
WORKDIR "/src/IntegrationAPI"
RUN dotnet build "IntegrationAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IntegrationAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IntegrationAPI.dll"]
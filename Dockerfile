# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Professor/Professor.csproj", "Professor/"]
RUN dotnet restore "Professor/Professor.csproj"
COPY . .
WORKDIR /src/Professor
RUN dotnet publish "Professor.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Professor.dll"]

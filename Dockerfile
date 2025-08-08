FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["AIInterviewCoach.csproj", "./"]
RUN dotnet restore "AIInterviewCoach.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "AIInterviewCoach.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "AIInterviewCoach.dll"]

# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY AIInterviewCoach.csproj .
RUN dotnet restore AIInterviewCoach.csproj

# Copy the rest of the app and build
COPY . .
RUN dotnet publish AIInterviewCoach.csproj -c Release -o /app/publish

# Use the ASP.NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "AIInterviewCoach.dll"]


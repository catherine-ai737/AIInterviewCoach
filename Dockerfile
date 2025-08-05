# ----------------------------
# 1. Build stage
# ----------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything and restore
COPY . ./
RUN dotnet restore "./AIInterviewCoach/AIInterviewCoach.csproj"
RUN dotnet publish "./AIInterviewCoach/AIInterviewCoach.csproj" -c Release -o /app/out

# ----------------------------
# 2. Runtime stage
# ----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expose default port
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "AIInterviewCoach.dll"]

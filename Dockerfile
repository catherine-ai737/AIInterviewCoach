# ===============================
# 1. Build stage
# ===============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything to the container
COPY . .

# Restore and publish
RUN dotnet restore "AIInterviewCoach/AIInterviewCoach.csproj"
RUN dotnet publish "AIInterviewCoach/AIInterviewCoach.csproj" -c Release -o /app/publish

# ===============================
# 2. Runtime stage
# ===============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port (optional)
EXPOSE 80

ENTRYPOINT ["dotnet", "AIInterviewCoach.dll"]

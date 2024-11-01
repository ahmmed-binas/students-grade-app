# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project files and restore any dependencies
COPY . ./
RUN dotnet publish -c Release -o out

# Use the ASP.NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expose the port and set the entrypoint for the application
EXPOSE 80
ENTRYPOINT ["dotnet", "SchoolGradesWebApp.dll"]

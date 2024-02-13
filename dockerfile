# Use the ASP.NET Core runtime image as base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use the ASP.NET Core SDK image as build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the csproj file and restore Telerik UI from local source
COPY ["LectureRoomMgt.csproj", "LectureRoomMgt/"]
#RUN dotnet restore "LectureRoomMgt.csproj" --source ./nugetpackages
RUN dotnet restore --source ./nugetpackages --source https://api.nuget.org/v3/index.json
#working-directory: ${{ github.workspace }}
# Copy the source code
COPY . .

# Install remaining dependencies from public NuGet repository
RUN dotnet restore --source https://api.nuget.org/v3/index.json

# Build your ASP.NET Core application
RUN dotnet build "LectureRoomMgt/LectureRoomMgt.csproj" -c Release -o /app/build

# Use the build output from the previous stage
FROM build AS publish
RUN dotnet publish "LectureRoomMgt/LectureRoomMgt.csproj" -c Release -o /app/publish

# Use the base image for the final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LectureRoomMgt.dll"]

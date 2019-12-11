FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS builder
WORKDIR /app
 
# copy csproj and restore as distinct layers
COPY ./quickstart/*.csproj ./
RUN dotnet restore
 
# copy everything else and build
COPY ./quickstart/. ./
RUN dotnet publish -c Release -o out
 
# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY --from=builder /app/out .
ENTRYPOINT ["dotnet", "quickstart.dll"]
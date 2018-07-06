FROM microsoft/dotnet:2.1.301-sdk-alpine AS builder
WORKDIR /app
 
# copy csproj and restore as distinct layers
COPY ./quickstart/*.csproj ./
RUN dotnet restore
 
# copy everything else and build
COPY ./quickstart/. ./
RUN dotnet publish -c Release -o out
 
# build runtime image
FROM microsoft/dotnet:2.1.1-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=builder /app/out .
ENTRYPOINT ["dotnet", "quickstart.dll"]
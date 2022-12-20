FROM mcr.microsoft.com/dotnet/sdk:7.0 AS builder
RUN dotnet nuget add source /NugetPackages --name internal
WORKDIR /Gateway
COPY ./ ./
WORKDIR /Gateway/src/Gateway.Console
ENTRYPOINT ["dotnet", "run"]

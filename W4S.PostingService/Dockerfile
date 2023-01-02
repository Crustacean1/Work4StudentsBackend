FROM mcr.microsoft.com/dotnet/sdk:7.0 AS builder
ARG MODE=Release
RUN dotnet nuget add source http://172.104.241.57/repository/nuget-hosted/ --name nexus
WORKDIR /Service
COPY ./ ./
RUN dotnet build -c $MODE -o build

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS production
WORKDIR /Service
COPY --from=builder /Service/build .

ENTRYPOINT ["dotnet", "PostingService.Console.dll"]

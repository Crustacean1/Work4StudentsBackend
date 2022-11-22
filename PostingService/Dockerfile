FROM mcr.microsoft.com/dotnet/sdk:7.0 AS builder
WORKDIR /PostingService
COPY ./ ./
RUN dotnet build -o ./bin

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS release
WORKDIR /PostingService
COPY --from=builder /PostingService/bin /PostingService
ENTRYPOINT ["dotnet", "PostingService.Console.dll"]

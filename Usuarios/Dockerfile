FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


RUN dotnet restore
RUN dotnet dev-certs https --trust

EXPOSE 8080

ENTRYPOINT ["dotnet", "watch", "run", "--no-launch-profile"]

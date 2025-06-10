
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dev
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./

EXPOSE 7257

ENTRYPOINT ["dotnet", "watch", "run", "--no-launch-profile", "--urls", "http://0.0.0.0:7257"]

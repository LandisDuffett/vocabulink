FROM mcr.microsoft.com/dotnet/core/sdk:3.1.401

WORKDIR /app

COPY . .

CMD ASPNETCORE_URL$=http://*:$PORT dotnet Keepr.dll
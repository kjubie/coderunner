#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apt-get update
RUN apt-get -y install curl gnupg
RUN curl -sL https://deb.nodesource.com/setup_10.x  | bash -
RUN apt-get -y install nodejs
RUN npm install

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["FHTW.CodeRunner.Services/FHTW.CodeRunner.Services.csproj", "FHTW.CodeRunner.Services/"]
COPY ["FHTW.CodeRunner.Services.DTOs/FHTW.CodeRunner.Services.DTOs.csproj", "FHTW.CodeRunner.Services.DTOs/"]
COPY ["FHTW.CodeRunner.BusinessLogic.Interfaces/FHTW.CodeRunner.BusinessLogic.Interfaces.csproj", "FHTW.CodeRunner.BusinessLogic.Interfaces/"]
COPY ["FHTW.CodeRunner.BusinessLogic.Entities/FHTW.CodeRunner.BusinessLogic.Entities.csproj", "FHTW.CodeRunner.BusinessLogic.Entities/"]
COPY ["FHTW.CodeRunner.Services.Interfaces/FHTW.CodeRunner.Services.Interfaces.csproj", "FHTW.CodeRunner.Services.Interfaces/"]
COPY ["FHTW.CodeRunner.BusinessLogic/FHTW.CodeRunner.BusinessLogic.csproj", "FHTW.CodeRunner.BusinessLogic/"]
COPY ["FHTW.CodeRunner.DataAccess.Sql/FHTW.CodeRunner.DataAccess.Sql.csproj", "FHTW.CodeRunner.DataAccess.Sql/"]
COPY ["FHTW.CodeRunner.DataAccess.Entities/FHTW.CodeRunner.DataAccess.Entities.csproj", "FHTW.CodeRunner.DataAccess.Entities/"]
COPY ["FHTW.CodeRunner.DataAccess.Interfaces/FHTW.CodeRunner.DataAccess.Interfaces.csproj", "FHTW.CodeRunner.DataAccess.Interfaces/"]
RUN dotnet restore "FHTW.CodeRunner.Services/FHTW.CodeRunner.Services.csproj"
COPY . .
WORKDIR "/src/FHTW.CodeRunner.Services"
RUN dotnet build "FHTW.CodeRunner.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FHTW.CodeRunner.Services.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FHTW.CodeRunner.Services.dll"]
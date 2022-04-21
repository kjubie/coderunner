#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
RUN apt-get update -yq \
    && apt-get -yq install curl gnupg git \
    && curl -sL https://deb.nodesource.com/setup_12.x | bash \
	&& apt-get -yq install nodejs
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
RUN apt-get update -yq \
    && apt-get -yq install curl gnupg git \
    && curl -sL https://deb.nodesource.com/setup_12.x | bash \
	&& apt-get -yq install nodejs
WORKDIR /src
COPY ["FHTW.CodeRunner.Services/FHTW.CodeRunner.Services.csproj", "FHTW.CodeRunner.Services/"]
COPY ["FHTW.CodeRunner.Services.DTOs/FHTW.CodeRunner.Services.DTOs.csproj", "FHTW.CodeRunner.Services.DTOs/"]
COPY ["FHTW.CodeRunner.BusinessLogic.Interfaces/FHTW.CodeRunner.BusinessLogic.Interfaces.csproj", "FHTW.CodeRunner.BusinessLogic.Interfaces/"]
COPY ["FHTW.CodeRunner.BusinessLogic.Entities/FHTW.CodeRunner.BusinessLogic.Entities.csproj", "FHTW.CodeRunner.BusinessLogic.Entities/"]
COPY ["FHTW.CodeRunner.Services.Interfaces/FHTW.CodeRunner.Services.Interfaces.csproj", "FHTW.CodeRunner.Services.Interfaces/"]
COPY ["FHTW.CodeRunner.BusinessLogic/FHTW.CodeRunner.BusinessLogic.csproj", "FHTW.CodeRunner.BusinessLogic/"]
COPY ["FHTW.CodeRunner.Migrations/FHTW.CodeRunner.Migrations.csproj", "FHTW.CodeRunner.Migrations/"]
COPY ["FHTW.CodeRunner.DataAccess.Sql/FHTW.CodeRunner.DataAccess.Sql.csproj", "FHTW.CodeRunner.DataAccess.Sql/"]
COPY ["FHTW.CodeRunner.DataAccess.Entities/FHTW.CodeRunner.DataAccess.Entities.csproj", "FHTW.CodeRunner.DataAccess.Entities/"]
COPY ["FHTW.CodeRunner.DataAccess.Interfaces/FHTW.CodeRunner.DataAccess.Interfaces.csproj", "FHTW.CodeRunner.DataAccess.Interfaces/"]
RUN dotnet restore "FHTW.CodeRunner.Services/FHTW.CodeRunner.Services.csproj"
COPY ["FHTW.CodeRunner.Services/ClientApp/", "ClientApp"]
COPY . .
WORKDIR "/src/FHTW.CodeRunner.Services"
RUN dotnet build "FHTW.CodeRunner.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FHTW.CodeRunner.Services.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/ClientApp /app/ClientApp
COPY --from=build /src/FHTW.CodeRunner.Services/dev-key.pfx /app
WORKDIR /app/ClientApp
RUN npm install
WORKDIR /app
ENTRYPOINT ["dotnet", "FHTW.CodeRunner.Services.dll"]
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
COPY ["src/FHTW.CodeRunner.Services/FHTW.CodeRunner.Services.csproj", "src/FHTW.CodeRunner.Services/"]
COPY ["src/FHTW.CodeRunner.Services.DTOs/FHTW.CodeRunner.Services.DTOs.csproj", "src/FHTW.CodeRunner.Services.DTOs/"]
COPY ["src/FHTW.CodeRunner.BusinessLogic.Interfaces/FHTW.CodeRunner.BusinessLogic.Interfaces.csproj", "src/FHTW.CodeRunner.BusinessLogic.Interfaces/"]
COPY ["src/FHTW.CodeRunner.BusinessLogic.Entities/FHTW.CodeRunner.BusinessLogic.Entities.csproj", "src/FHTW.CodeRunner.BusinessLogic.Entities/"]
COPY ["src/FHTW.CodeRunner.Services.Interfaces/FHTW.CodeRunner.Services.Interfaces.csproj", "src/FHTW.CodeRunner.Services.Interfaces/"]
COPY ["src/FHTW.CodeRunner.BusinessLogic/FHTW.CodeRunner.BusinessLogic.csproj", "src/FHTW.CodeRunner.BusinessLogic/"]
COPY ["src/FHTW.CodeRunner.Migrations/FHTW.CodeRunner.Migrations.csproj", "src/FHTW.CodeRunner.Migrations/"]
COPY ["src/FHTW.CodeRunner.DataAccess.Sql/FHTW.CodeRunner.DataAccess.Sql.csproj", "src/FHTW.CodeRunner.DataAccess.Sql/"]
COPY ["src/FHTW.CodeRunner.DataAccess.Entities/FHTW.CodeRunner.DataAccess.Entities.csproj", "src/FHTW.CodeRunner.DataAccess.Entities/"]
COPY ["src/FHTW.CodeRunner.DataAccess.Interfaces/FHTW.CodeRunner.DataAccess.Interfaces.csproj", "src/FHTW.CodeRunner.DataAccess.Interfaces/"]
RUN dotnet restore "src/FHTW.CodeRunner.Services/FHTW.CodeRunner.Services.csproj"
COPY ["src/FHTW.CodeRunner.Services/ClientApp/", "src/ClientApp"]
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

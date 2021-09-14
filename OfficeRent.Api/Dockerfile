FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["OfficeRent.Api/OfficeRent.Api.csproj", "OfficeRent.Api/"]
RUN dotnet restore "OfficeRent.Api/OfficeRent.Api.csproj"
COPY . .
WORKDIR "/src/OfficeRent.Api"
RUN dotnet build "OfficeRent.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OfficeRent.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OfficeRent.Api.dll"]

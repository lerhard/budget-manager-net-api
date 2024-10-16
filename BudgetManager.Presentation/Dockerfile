FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
ARG BUILD_CONFIGURATION=Debug
WORKDIR /Api
COPY . ./
RUN dotnet restore
RUN dotnet publish -c $BUILD_CONFIGURATION -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /Api
COPY --from=build-env /Api/out .
EXPOSE 8080
EXPOSE 8081
ENTRYPOINT ["dotnet", "BudgetManagerApi.dll"]
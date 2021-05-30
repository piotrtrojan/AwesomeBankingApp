#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["AwesomeBankingApp.Api/AwesomeBankingApp.Api.csproj", "AwesomeBankingApp.Api/"]
COPY ["AwesomeBankingApp.Loan.Validator/AwesomeBankingApp.Loan.Validator.csproj", "AwesomeBankingApp.Loan.Validator/"]
COPY ["AwesomeBankingApp.Bootstrap/AwesomeBankingApp.Bootstrap.csproj", "AwesomeBankingApp.Bootstrap/"]
COPY ["AwesomeBankingApp.Loan.Web/AwesomeBankingApp.Loan.Web.csproj", "AwesomeBankingApp.Loan.Web/"]
COPY ["AwesomeBankingApp.Loan/AwesomeBankingApp.Loan.csproj", "AwesomeBankingApp.Loan/"]
RUN dotnet restore "AwesomeBankingApp.Api/AwesomeBankingApp.Api.csproj"
COPY . .
WORKDIR "/src/AwesomeBankingApp.Api"
RUN dotnet build "AwesomeBankingApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AwesomeBankingApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AwesomeBankingApp.Api.dll"]
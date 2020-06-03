#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
#COPY ["Kongsli.Ndc2020.Jokes.Api/Kongsli.Ndc2020.Jokes.Api.csproj", "Kongsli.Ndc2020.Jokes.Api/"]
#COPY ["Kongsli.Ndc2020.Jokes.Tests/Kongsli.Ndc2020.Jokes.Tests.csproj", "Kongsli.Ndc2020.Jokes.Tests/"]
#RUN dotnet restore "Kongsli.Ndc2020.Jokes.Api/Kongsli.Ndc2020.Jokes.Api.csproj"
#RUN dotnet restore "Kongsli.Ndc2020.Jokes.Tests/Kongsli.Ndc2020.Jokes.Tests.csproj"
COPY . .
RUN dotnet restore Kongsli.Ndc2020.Jokes.sln
#WORKDIR "/src/Kongsli.Ndc2020.Jokes.Api"
#RUN dotnet build "Kongsli.Ndc2020.Jokes.Api.csproj" -c Release -o /app/build
LABEL test=true
RUN dotnet tool install dotnet-reportgenerator-globaltool --version 4.5.8 --tool-path /tools
WORKDIR "/src/Kongsli.Ndc2020.Jokes.Tests"
RUN dotnet test --results-directory /testresults --logger "trx;LogFileName=test_results.xml" /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=/testresults/coverage/ /p:Exclude="[xunit.*]*%2c[StackExchange.*]*" "Kongsli.Ndc2020.Jokes.Tests.csproj"
#RUN /tools/reportgenerator "-reports:/testresults/coverage/coverage.cobertura.xml" "-targetdir:/testresults/coverage/reports" "-reporttypes:HTMLInline;HTMLChart"

FROM build AS publish
WORKDIR "/src/Kongsli.Ndc2020.Jokes.Api"
RUN dotnet publish "Kongsli.Ndc2020.Jokes.Api.csproj" -c Release -o /app/publish

FROM base AS final
LABEL prod=true
WORKDIR /app
COPY --from=publish /app/publish .
HEALTHCHECK CMD curl --fail http://localhost:5000/health || exit
ENTRYPOINT ["dotnet", "Kongsli.Ndc2020.Jokes.Api.dll"]
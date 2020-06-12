FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . .
RUN dotnet restore Kongsli.Ndc2020.Jokes.sln
LABEL test=true
WORKDIR "/src/Kongsli.Ndc2020.Jokes.Tests"
RUN dotnet test --results-directory /testresults \
    --logger trx "Kongsli.Ndc2020.Jokes.Tests.csproj" || touch "../test_failure"

FROM build AS publish
WORKDIR "/src/Kongsli.Ndc2020.Jokes.Api"
RUN test -f "../test_failure" && exit 1; \
    dotnet publish "Kongsli.Ndc2020.Jokes.Api.csproj" -c Release -o /app/publish

FROM base AS final
LABEL prod=true
WORKDIR /app
COPY --from=publish /app/publish .
HEALTHCHECK CMD curl --fail http://localhost:80/health || exit
ENTRYPOINT ["dotnet", "Kongsli.Ndc2020.Jokes.Api.dll"]
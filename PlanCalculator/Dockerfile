FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
RUN apt update && \
    apt install unzip && \
    curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l /vsdbg
WORKDIR /app
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["PlanCalculator.csproj","./"]
RUN dotnet restore "./PlanCalculator.csproj"
COPY . .
RUN dotnet build "PlanCalculator.csproj" -c Debug -o /app
FROM build AS publish
RUN dotnet publish "PlanCalculator.csproj" -c Debug -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet","PlanCalculator.dll"]
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore "ProductMicroservice.csproj"
COPY . .
RUN dotnet build "ProductMicroservice.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProductMicroservice.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductMicroservice.dll"]
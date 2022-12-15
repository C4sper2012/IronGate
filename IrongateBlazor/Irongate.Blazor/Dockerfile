FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["Irongate.Blazor/Irongate.Blazor.csproj", "Irongate.Blazor/"]
COPY ["Irongate.Service/Irongate.Service.csproj", "Irongate.Service/"]
RUN dotnet restore "Irongate.Blazor/Irongate.Blazor.csproj"
COPY . .
WORKDIR "/src/Irongate.Blazor"

RUN dotnet build "Irongate.Blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Irongate.Blazor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Irongate.Blazor.dll"]

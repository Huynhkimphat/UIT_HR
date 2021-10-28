FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "HR_UIT.Web/HR_UIT.Web.csproj" --disable-parallel
WORKDIR "/src/HR_UIT.Web"
RUN dotnet build "HR_UIT.Web.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/HR_UIT.Web"
RUN dotnet publish "HR_UIT.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "run", "HRUITWeb.dll"]

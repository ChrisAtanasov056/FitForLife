#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Web/FitForLife.Web/FitForLife.Web.csproj", "Web/FitForLife.Web/"]
COPY ["Services/FitForLife.Services.Mapping/FitForLife.Services.Mapping.csproj", "Services/FitForLife.Services.Mapping/"]
COPY ["Data/FitForLife.Data.Models/FitForLife.Data.Models.csproj", "Data/FitForLife.Data.Models/"]
COPY ["Data/FitForLife.Data.Common/FitForLife.Data.Common.csproj", "Data/FitForLife.Data.Common/"]
COPY ["Web/FitForLife.Web.ViewModels/FitForLife.Web.ViewModels.csproj", "Web/FitForLife.Web.ViewModels/"]
COPY ["Data/FitForLife.Data/FitForLife.Data.csproj", "Data/FitForLife.Data/"]
COPY ["FitForLife.Common/FitForLife.Common.csproj", "FitForLife.Common/"]
COPY ["Services/FitForLife.Services.Data/FitForLife.Services.Data.csproj", "Services/FitForLife.Services.Data/"]
RUN dotnet restore "Web/FitForLife.Web/FitForLife.Web.csproj"
COPY . .
WORKDIR "/src/Web/FitForLife.Web"
RUN dotnet build "FitForLife.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FitForLife.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FitForLife.dll"]
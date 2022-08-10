FROM mcr.microsoft.com/dotnet/core/sdk:3.1

ARG LBHPACKAGESTOKEN
ENV LBHPACKAGESTOKEN=$LBHPACKAGESTOKEN
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Hackney.Shared.PatchesAndAreas/Hackney.Shared.PatchesAndAreas.csproj ./
COPY /nuget.config /root/.nuget/NuGet/NuGet.Config
RUN dotnet restore ./Hackney.Shared.PatchesAndAreas.csproj

# Copy everything else and build
COPY ./Hackney.Shared.PatchesAndAreas ./
RUN dotnet build -c Release -o out ./Hackney.Shared.PatchesAndAreas.csproj
RUN dotnet publish -c Release -o out ./Hackney.Shared.PatchesAndAreas.csproj

EXPOSE ${PORT:-3000}
CMD ASPNETCORE_URLS=http://+:${PORT:-3000} dotnet ./out/Hackney.Shared.PatchesAndAreas.dll

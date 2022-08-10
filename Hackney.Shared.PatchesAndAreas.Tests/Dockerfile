FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

ARG LBHPACKAGESTOKEN
ENV LBHPACKAGESTOKEN=$LBHPACKAGESTOKEN
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Hackney.Shared.PatchesAndAreas.sln ./
COPY ./Hackney.Shared.PatchesAndAreas/Hackney.Shared.PatchesAndAreas.csproj ./Hackney.Shared.PatchesAndAreas/
COPY ./Hackney.Shared.PatchesAndAreas.Tests/Hackney.Shared.PatchesAndAreas.Tests.csproj ./Hackney.Shared.PatchesAndAreas.Tests/
COPY /nuget.config /root/.nuget/NuGet/NuGet.Config

RUN dotnet restore ./Hackney.Shared.PatchesAndAreas/Hackney.Shared.PatchesAndAreas.csproj
RUN dotnet restore ./Hackney.Shared.PatchesAndAreas.Tests/Hackney.Shared.PatchesAndAreas.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out Hackney.Shared.PatchesAndAreas.Tests/Hackney.Shared.PatchesAndAreas.Tests.csproj

CMD dotnet test

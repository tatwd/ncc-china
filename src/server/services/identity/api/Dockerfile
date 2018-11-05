FROM microsoft/dotnet:sdk AS build
WORKDIR /src
COPY ./src/server/. .

WORKDIR /src/services/identity/api
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /src/services/identity/api/out .
ENTRYPOINT [ "dotnet", "Ncc.China.Services.Identity.Api.dll" ]
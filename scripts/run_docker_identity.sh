./scripts/run_mysql.sh

sleep 10

echo "[Service] Start running identity api ..."
dotnet run --project src/server/services/identity/api/Ncc.China.Services.Identity.Api.csproj
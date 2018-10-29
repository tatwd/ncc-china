./scripts/run_mongo.sh

sleep 3

echo "[Service] Start running postsys api ..."
dotnet run --project src/server/services/postsys/api/Ncc.China.Services.Postsys.Api.csproj
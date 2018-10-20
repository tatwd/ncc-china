# must run this shell in project root directory
# pwd=$(pwd)

# echo "You are on $pwd"

# stop all docker containers
docker stop $(docker ps -q)

# run identity service db
./scripts/run_mysql.sh

sleep 3

# run post service db
./scripts/run_mongo.sh
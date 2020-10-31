echo "[Docker] Start to stop all docker containers ..."
docker stop $(docker ps -q)

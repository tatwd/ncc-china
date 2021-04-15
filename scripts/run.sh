#!/bin/bash

identity_db="ncc.identity"
postsys_db="ncc.postsys"

function get_docker_container_id {
 docker container ls -a -f name="$1" -q
}

function run_db {
	echo -n "Start MongoDB on port 27017..."
	local db1_id=$(get_docker_container_id $postsys_db)
	if [ ! -n "$db1_id" ]; then
		docker run --name $postsys_db \
			-p 27017:27017 \
			--network $net_name \
			-e MONGO_INITDB_ROOT_USERNAME=root \
			-e MONGO_INITDB_ROOT_PASSWORD=test123 \
			-d mongo \
			&& echo "Done!"
	else
		docker restart $db1_id && echo "Done!"
	fi

	echo -n "Start MySQL on port 3306..."
	local db2_id=$(get_docker_container_id $identity_db)
	if [ ! -n "$db2_id" ]; then
		docker run --name $identity_db \
			-p 3306:3306 \
			-e MYSQL_ROOT_PASSWORD=test123 \
			--network $net_name \
			-d mysql:5.7 \
			&& echo "Done!"
	else
		docker restart $db2_id && echo "Done!"
	fi
}

function run_api_identity {
	echo "Start docker container 'test_api_identity'"
  local id=$(get_docker_container_id test_api_identity)
  if [ ! -n "$id" ]; then
	  docker run --name "test_api_identity" --rm -p "5001:80" \
		--network $net_name -d "ncc_api:identity"
  else
    docker restart test_api_identity && echo "Done!"
  fi
}

function run_api_postsys {
	echo "Start docker container 'test_api_postsys'"
  local id=$(get_docker_container_id "test_api_postsys")
  if [ ! -n "$id" ]; then
  	docker run --name "test_api_postsys" --rm -p "5002:80" \
	  	--network $net_name -d "ncc_api:postsys"
  else
    docker restart test_api_postsys && echo "Done!"
  fi
}

function run_api_postsys_comment {
	echo "Start docker container 'test_api_postsys_comment'"
  local id=$(get_docker_container_id "test_api_postsys_comment")
  if [ ! -n "$id" ]; then
    docker run --name "test_api_postsys_comment" --rm -p "5003:80" \
      -v "$PWD/build/api_postsys_comment/config.prod.js:/app/config.js" \
      --network $net_name -d "ncc_api:postsys_comment"
  else
    docker restart test_api_postsys_comment && echo "Done!"
  fi
}

function run_api_gateway {
	echo "Start docker container 'test_api_gateway'"
  local id=$(get_docker_container_id "test_api_gateway")
  if [ ! -n "$id" ]; then
    docker run --name "test_api_gateway" --rm -p "6660:80" \
      --network $net_name \
      -v "$PWD/build/api_gateway/ocelot.prod.json:/app/ocelot.json" \
      -d "ncc_api:gateway"
  else
    docker restart test_api_gateway && echo "Done!"
  fi
}

# docker network setup
net_name="my-net"
net_id=$(docker network ls -f name=$net_name -q)
if [ ! -n "$net_id" ]; then
	net_id=$(docker network create -d bridge $net_name)
fi
echo "Used network id is $net_id"

run_db

echo "Sleep 10s..."
sleep 10


case $1 in
	1) run_api_identity
	;;
	2) run_api_postsys
	;;
	3) run_api_postsys_comment
	;;
	0) run_api_gateway
	;;
	*) run_api_identity \
	  && run_api_postsys \
	  && run_api_postsys_comment \
	  && run_api_gateway
	;;
esac

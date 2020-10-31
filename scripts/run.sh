#!/bin/bash

identity_db="ncc.identity"
postsys_db="ncc.postsys"

function run_db() {
	echo -n "Start MongoDB on port 27017..."
	local db1_id=$(docker container ls -a -f name=$postsys_db -q)
	if [ ! -n "$db1_id" ]; then
		docker run --name $postsys_db \
			-p 27017:27017 \
			--network $net_name \
			-d mongo \
			&& echo "Done!"
	else
		docker start $db1_id && echo "Done!"
	fi

	echo -n "Start MySQL on port 3306..."
	local db2_id=$(docker container ls -a -f name=$identity_db -q)
	if [ ! -n "$db2_id" ]; then
		docker run --name $identity_db \
			-p 3306:3306 \
			-e MYSQL_ROOT_PASSWORD=test123 \
			--network $net_name \
			-d mysql:5.6 \
			&& echo "Done!"
	else
		docker start $db2_id && echo "Done!"
	fi
}

function run_api_identity() {
	echo "Start docker container 'test_api_identity'"
	docker run --name "test_api_identity" --rm -p "5001:80" \
		--network $net_name -d "ncc_api:identity"

}

function run_api_postsys() {
	echo "Start docker container 'test_api_postsys'"
	docker run --name "test_api_postsys" --rm -p "5002:80" \
		--network $net_name -d "ncc_api:postsys"

}

function run_api_postsys_comment() {
	echo "Start docker container 'test_api_postsys_comment'"
	docker run --name "test_api_postsys_comment" --rm -p "5003:80" \
		-v "$PWD/build/api_postsys_comment/config.prod.js:/app/config.js" \
		--network $net_name -d "ncc_api:postsys_comment"
}

function run_api_gateway() {
	echo "Start docker container 'test_api_gateway'"
	docker run --name "test_api_gateway" --rm -p "6660:80" \
		--network $net_name \
		-v "$PWD/build/api_gateway/ocelot.prod.json:/app/ocelot.json" \
		-d "ncc_api:gateway"

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

run_api_identity \
	&& run_api_postsys \
	&& run_api_postsys_comment \
	&& run_api_gateway

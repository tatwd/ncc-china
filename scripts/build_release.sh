#!/bin/bash

build_dir="$PWD/build"
server_dir="src/server"
services_dir_prefix="$server_dir/services"

identity_db="ncc.identity"
postsys_db="ncc.postsys"

function build_identity_api() {
	local api_name="api_identity"
	local csproj="$services_dir_prefix/identity/api/Ncc.China.Services.Identity.Api.csproj"

	echo "=> Start to build $api_name ..."
	dotnet publish -c Release -p:PublishReadyToRun=true -o "$build_dir/$api_name" "$csproj" \
		&& echo "=> Finished!"
}

function build_postsys_api() {
	local api_name="api_postsys"
	local csproj="$services_dir_prefix/postsys/api/Ncc.China.Services.Postsys.Api.csproj"

	echo "=> Start to build $api_name ..."
	dotnet publish -c Release -p:PublishReadyToRun=true -o "$build_dir/$api_name" "$csproj" \
		&& echo "=> Finished!"
}

function build_postsys_comment_api() {
	local api_name="api_postsys_comment"
	local proj_dir="$services_dir_prefix/postsys_comment"

	echo "=> Start build $api_name ..."
	echo -n "=> Find 'build/$api_name' dir ..."
	if [ ! -d "build/$api_name" ]; then
		mkdir -p "build/$api_name"
	fi
	echo "OK!"

	# copy all files and dir exinclude `node_modules` dir
	ls $proj_dir \
		| grep -v "node_modules" \
		| xargs -i cp -r $proj_dir/{} $build_dir/$api_name \
		&& echo "=> Finished!"
}

function build_gateway_api() {
	local api_name="api_gateway"
	local version="v1"
	local csproj="$server_dir/api_gateway/$version/Ncc.China.ApiGateway.csproj"

	echo "=> Start to build $api_name:$version ..."
	dotnet publish -c Release -p:PublishReadyToRun=true -o "$build_dir/$api_name" "$csproj" \
		&& echo "=> Finished!"
}

case $1 in
	1) build_identity_api
	;;
	2) build_postsys_api
	;;
	3) build_postsys_comment_api
	;;
	0) build_gateway_api
	;;
	*) build_identity_api \
		&& build_postsys_api \
		&& build_postsys_comment_api \
		&& build_gateway_api
	;;
esac

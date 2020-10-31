#!/bin/bash

build_dir="$PWD/build"

function build_image() {
	docker build -t "$1" -f "$build_dir/$2/Dockerfile.release" "$build_dir/$2"
}

function build_identity_api_image() {
	local image_name="ncc_api:identity"
	local api_name="api_identity"
	build_image $image_name $api_name
}

function build_postsys_api_image() {
	local image_name="ncc_api:postsys"
	local api_name="api_postsys"
	build_image $image_name $api_name
}

function build_postsys_comment_api_image() {
	local image_name="ncc_api:postsys_comment"
	local api_name="api_postsys_comment"
	build_image $image_name $api_name
}

function build_gateway_api_image() {
	local image_name="ncc_api:gateway"
	local api_name="api_gateway"
	build_image $image_name $api_name
}

case $1 in
	1) build_identity_api_image
	;;
	2) build_postsys_api_image
	;;
	3) build_postsys_comment_api_image
	;;
	0) build_gateway_api_image
	;;
	*) build_identity_api_image \
		&& build_postsys_api_image \
		&& build_postsys_comment_api_image \
		&& build_gateway_api_image
	;;
esac

docker image prune -f

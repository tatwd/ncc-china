container_name="ncc.postsys"
out_port=27017
mongodb_img_tag="latest"

echo "[Docker] Start running MongoDB on port $out_port ..."
docker run --rm --name $container_name -p $out_port:27017 -d mongo:$mongodb_img_tag
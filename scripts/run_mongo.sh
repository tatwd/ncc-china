container_name="ncc.postsys"
out_port=27017
mongodb_img_tag="latest"

echo "[Docker] Start running MongoDB on port $out_port ..."
docker run --name $container_name -p $out_port:27017 -d \
    -e MONGO_INITDB_ROOT_USERNAME=root \
    -e MONGO_INITDB_ROOT_PASSWORD=test123 \
    mongo:$mongodb_img_tag

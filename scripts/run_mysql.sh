container_name="ncc.identity"
out_port=3306
mysql_img_tag="latest"
passwd="test123"

echo "[Docker] Start running MySQL on port $out_port ..."
docker run -d --rm  -p $out_port:3306 --name $container_name -e MYSQL_ROOT_PASSWORD=$passwd mysql:$mysql_img_tag
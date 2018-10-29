echo "[Service] Start running postsys_comment api ..."

cd src/server/services/postsys_comment
if [ ! -d "node_modules"  ]; then
  npm install
fi
npm run dev
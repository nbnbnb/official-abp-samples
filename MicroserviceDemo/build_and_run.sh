profile=${1}
git reset --hard 
git clean -df
git pull
docker-compose -f aliyun-docker-compose.yml build
docker-compose -f aliyun-docker-compose.yml --env-file ./.env.${profile} up --force-recreat -d
docker image prune -f
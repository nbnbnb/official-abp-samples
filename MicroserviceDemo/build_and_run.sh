profile="$1" 
git reset --hard 
git clean -df
git pull
docker-compose -f docker-compose-aliyun.yml build
docker-compose -f docker-compose-aliyun.yml --env-file ./.env.${profile} up --force-recreat -d
docker image prune -f
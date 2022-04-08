git reset --hard 
git clean -df
git pull
docker-compose -f docker-compose-aliyun.yml build
docker-compose -f docker-compose-aliyun.yml down
docker-compose -f docker-compose-aliyun.yml --env-file ./.env.arm up --force-recreat -d
docker image prune -f
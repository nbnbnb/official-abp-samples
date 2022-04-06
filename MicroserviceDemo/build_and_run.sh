git reset --hard 
git clean -df
git pull
docker image prune -f
docker-compose -f docker-compose-aliyun.yml down
docker-compose -f docker-compose-aliyun.yml --env-file ./.env.arm build
docker-compose -f docker-compose-aliyun.yml --env-file ./.env.arm -f docker-compose-aliyun.yml up --force-recreat -d
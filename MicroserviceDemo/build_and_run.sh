git reset --hard 
git clean -df
git pull
docker-compose -f arm-docker-compose.yml build
docker-compose -f arm-docker-compose.yml --env-file ./.env.arm up --force-recreat -d
docker image prune -f
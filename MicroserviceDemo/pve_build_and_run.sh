git reset --hard 
git clean -df
git pull
docker-compose -f pve-docker-compose.yml build
docker-compose -f pve-docker-compose.yml --env-file ./.env.pve up --force-recreat -d
docker image prune -f
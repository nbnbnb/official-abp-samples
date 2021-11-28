docker container prune -f
docker image prune -f
docker-compose -f docker-compose-local.yml build
docker-compose -f docker-compose-local.yml down
docker-compose -f docker-compose-local.yml up -d
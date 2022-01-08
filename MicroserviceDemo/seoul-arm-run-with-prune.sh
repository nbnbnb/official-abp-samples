docker-compose -f docker-compose-arm.yml build
docker-compose -f docker-compose-arm.yml down
docker-compose -f docker-compose-arm.yml up -d
docker container prune -f
docker image prune -f
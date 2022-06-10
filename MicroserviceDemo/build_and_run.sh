#!/usr/bin/env bash

profile=${1}

echo "profile: ${profile}"
  
/usr/bin/git reset --hard 
/usr/bin/git clean -df
/usr/bin/git pull


docker-compose -f aliyun-docker-compose.yml build
docker-compose -f aliyun-docker-compose.yml --env-file ./.env.${profile} up -d
docker image prune -f
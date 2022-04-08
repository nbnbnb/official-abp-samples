#!/bin/bash

echo "Deploy Param01 $1" 
echo "Deploy Param02 $2" 

docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:$2
docker-compose --env-file ./.env.arm -f docker-compose-aliyun.yml up -d --force-recreat $1



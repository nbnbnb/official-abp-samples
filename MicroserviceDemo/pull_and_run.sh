#!/bin/bash

profile=${1}

docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-authserver-host
docker-compose -f aliyun-docker-compose.yml --env-file .env.${profile} up --force-recreat auth-server -d

docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-backendadminapp-host
docker-compose -f aliyun-docker-compose.yml --env-file .env.${profile} up --force-recreat backend-admin-app -d

docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-publicwebsite-host
docker-compose -f aliyun-docker-compose.yml --env-file .env.${profile} up --force-recreat public-website -d

docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-identityservice-host
docker-compose -f aliyun-docker-compose.yml --env-file .env.${profile} up --force-recreat identity-service -d

docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-tenantmanagementservice-host
docker-compose -f aliyun-docker-compose.yml --env-file .env.${profile} up --force-recreat tenant-management-service -d

docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-bloggingservice-host
docker-compose -f aliyun-docker-compose.yml --env-file .env.${profile} up --force-recreat logging-service -d

docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-productservice-host
docker-compose -f aliyun-docker-compose.yml --env-file .env.${profile} up --force-recreat product-service -d

docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-internalgateway-host
docker-compose -f aliyun-docker-compose.yml --env-file .env.${profile} up --force-recreat internal-gateway -d

docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-backendadminappgateway-host
docker-compose -f aliyun-docker-compose.yml --env-file .env.${profile} up --force-recreat backend-admin-app-gateway -d

docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-publicwebsitegateway-host
docker-compose -f aliyun-docker-compose.yml --env-file .env.${profile} up --force-recreat public-website-gateway -d

docker image prune -f
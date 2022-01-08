#!/bin/bash

docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-authserver-host
docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-backendadminapp-host
docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-publicwebsite-host
docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-identityservice-host
docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-tenantmanagementservice-host
docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-bloggingservice-host
docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-productservice-host
docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-internalgateway-host
docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-backendadminappgateway-host
docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-publicwebsitegateway-host

docker-compose -f docker-compose-arm.yml down
docker-compose -f docker-compose-arm.yml up -d

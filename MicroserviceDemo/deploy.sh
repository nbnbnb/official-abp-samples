#!/bin/bash

docker pull registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:$2

docker-compose -f docker-compose-arm.yml down $1
docker-compose -f docker-compose-arm.yml up -d $1

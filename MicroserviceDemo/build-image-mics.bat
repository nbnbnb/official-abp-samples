@echo off

echo 'Build AuthServer.Host'
echo %date%  %time% '------- start '-------'
docker build -f applications\AuthServer.Host\Dockerfile -t registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-authserver-host .
echo %date%  %time% '-------  end  '-------'

echo 'Build BackendAdminApp.Host'
echo %date%  %time% '------- start '-------'
docker build -f applications\BackendAdminApp.Host\Dockerfile -t registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-backendadminapp-host .
echo %date%  %time% '-------  end  '-------'

echo 'Build PublicWebSite.Host'
echo %date%  %time% '------- start '-------'
docker build -f applications\PublicWebSite.Host\Dockerfile -t registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-publicwebsite-host .
echo %date%  %time% '-------  end  '-------'

echo 'Build IdentityService.Host'
echo %date%  %time% '------- start '-------'
docker build -f microservices\IdentityService.Host\Dockerfile -t registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-identityservice-host .
echo %date%  %time% '-------  end  '-------'

echo 'Build TenantManagementService.Host'
echo %date%  %time% '------- start '-------'
docker build -f microservices\TenantManagementService.Host\Dockerfile -t registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-tenantmanagementservice-host .
echo %date%  %time% '-------  end  '-------'

echo 'Build BloggingService.Host'
echo %date%  %time% '------- start '-------'
docker build -f microservices\BloggingService.Host\Dockerfile -t registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-bloggingservice-host .
echo %date%  %time% '-------  end  '-------'

echo 'Build ProductService.Host'
echo %date%  %time% '------- start '-------'
docker build -f microservices\ProductService.Host\Dockerfile -t registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-productservice-host .
echo %date%  %time% '-------  end  '-------'

echo 'Build InternalGateway.Host'
echo %date%  %time% '------- start '-------'
docker build -f gateways\InternalGateway.Host\Dockerfile -t registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-tnternalgateway-host .
echo %date%  %time% '-------  end  '-------'

echo 'Build BackendAdminAppGateway.Host'
echo %date%  %time% '------- start '-------'
docker build -f gateways\BackendAdminAppGateway.Host\Dockerfile -t registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-backendadminappgateway-host .
echo %date%  %time% '-------  end  '-------'

echo 'Build PublicWebSiteGateway.Host'
echo %date%  %time% '------- start '-------'
docker build -f gateways\PublicWebSiteGateway.Host\Dockerfile -t registry.cn-hangzhou.aliyuncs.com/zhangjj/demo:abp-publicwebsitegateway-host .
echo %date%  %time% '-------  end  '-------'

echo pause
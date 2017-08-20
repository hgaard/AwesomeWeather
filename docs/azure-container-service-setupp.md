# Deploying to azure container service

## Create container registry

From [here](https://docs.microsoft.com/en-us/azure/container-service/kubernetes/container-service-tutorial-kubernetes-prepare-acr)

```
az group create --name awesomeWeather --location australiaeast
```

```
az acr create --resource-group awesomeWeather --name hgaardContainerRegistry --sku Basic --admin-enabled true
```

```
az acr show --name hgaardContainerRegistry --query loginServer ==> "hgaardcontainerregistry.azurecr.io"
```

```
az acr credential show --name hgaardContainerRegistry --query passwords[0].value ==> 'not working'
```

### Upload to local azure repo

```
docker login --username=hgaardContainerRegistry --password==JFzBl6U=hgCKr3J9tuHiQh40tx4JrZw hgaardcontainerregistry.azurecr.io
```

```
docker tag awesomeweather_web hgaardcontainerregistry.azurecr.io/awesomeweather_web:first
```

```
docker push hgaardcontainerregistry.azurecr.io/awesomeweather_web:first
```

```
az acr repository list --name=hgaardContainerRegistry --username=hgaardContainerRegistry --password==JFzBl6U=hgCKr3J9tuHiQh40tx4JrZw --output table
```

```
az acr repository show-tags --name=hgaardContainerRegistry --username=hgaardContainerRegistry --password==JFzBl6U=hgCKr3J9tuHiQh40tx4JrZw --repository awesomeweather_web --output table
```

### Upload to docker hub

```
docker login --username=hgaard --password=6KarTmig hub.docker.com
```

```
docker tag awesomeweather hgaard/awesomeweather:latest
```

```
docker push hgaard/awesomeweather:latest
```


## Kubernetes cluster

### Create Kubernetes cluster

```
az acs create --orchestrator-type=kubernetes --resource-group awesomeWeather --name=myK8SCluster --generate-ssh-keys
```

### Install kubectl

```
sudo az acs kubernetes install-cli 
```

### Connect with kubectl

#### Connect 

```
az acs kubernetes get-credentials --resource-group=awesomeWeather --name=myK8SCluster
```

#### get nodes

```
kubectl get nodes
```


## Run app in kuberbetes

Create from manifest

```
kubectl create -f ./kubernetes-manifest.yml
```
# dapr batch sample

## description

batch job system by dapr

## used env and library

* vscode remote container
* dapr
* dapper

## setup

1. open vscore remote container
1. exec vscode terminal `dotnet restore`

## run

```
dapr run --app-id dapr-batch --app-port 5000 --placement-host-address dapr-placement:50010 --components-path $HOME/.dapr/components --log-level info -- dotnet run --project batch/batch.csproj
```

## useage

```
dapr publish --publish-app-id dapr-batch --pubsub batch-param --topic job-a-params --data '{"Order": 1}'
dapr publish --publish-app-id dapr-batch --pubsub batch-param --topic job-b-params --data '{}'
dapr publish --publish-app-id dapr-batch --pubsub batch-param --topic job-c-params --data '{}'
dapr publish --publish-app-id dapr-batch --pubsub batch-param --topic job-d-params --data '{}'
```
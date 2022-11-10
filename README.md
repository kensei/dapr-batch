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
curl -d @test/job-a-params.json -H "Content-Type: application/json" http://localhost:5000/JobEnqueueA
curl -d @test/job-empty-params.json -H "Content-Type: application/json" http://localhost:5000/JobEnqueueB
curl -d @test/job-empty-params.json -H "Content-Type: application/json" http://localhost:5000/JobEnqueueC
curl -d @test/job-empty-params.json -H "Content-Type: application/json" http://localhost:5000/JobEnqueueD
```
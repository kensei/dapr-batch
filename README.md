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

## migrate

mysql password is docker-compose.yml

```
mysql -uroot -p -hdapr-batch_devcontainer_mysql_1 < .devcontainer/docker/mysql/initdb.d/0_create_database.sql
mysql -uroot -p -hdapr-batch_devcontainer_mysql_1 test < .devcontainer/docker/mysql/initdb.d/1_create_table.sql 
```

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
# dapr batch sample

## description

batch job system by dapr

## used env and library

* vscode remote container
* dapr
* dapper

## setup

## migration

## run

```
cd batch
dapr run --app-id batch --app-port 5001 --placement-host-address dapr-placement:50010 --components-path $HOME/.dapr/components --log-level info -- dotnet run
```

## useage

``:
```

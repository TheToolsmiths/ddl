$ROOT_DIR = (Resolve-Path "$PSScriptRoot/../../")

docker build -t "ddl_antlr:latest" "$ROOT_DIR/scripts/spec/docker"
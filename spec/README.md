# TheToolsmith's DDL Spec

## Spec file

The spec file is defined at `./spec/Ddl.g4`

## Windows development

Setup docker with WSL 1:
https://nickjanetakis.com/blog/setting-up-docker-for-windows-and-wsl-to-work-flawlessly

WSL 2 is in development ATM, and might have a different workflow in the future.

## Build docker image

From the repository root invoke
```
./scripts/build_docker.sh
```
to build the docker image used to compile the spec

## Invoke ANTLR4 docker image
Still from the repository root invoke
```
./scripts/build_spec.sh
```
to invoke ANTLR4 and compile the spec
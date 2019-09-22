#!/bin/bash

ABSOLUTE_PATH="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)/$(basename "${BASH_SOURCE[0]}")"
ABSOLUTE_DIR="$(dirname $ABSOLUTE_PATH)"
ROOT_DIR="$(realpath "$ABSOLUTE_DIR/..")"

docker build -t "ddl_antlr" "$ROOT_DIR/scripts/spec/docker"
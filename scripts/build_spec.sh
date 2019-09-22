#!/bin/bash

ABSOLUTE_PATH="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)/$(basename "${BASH_SOURCE[0]}")"
ABSOLUTE_DIR="$(dirname $ABSOLUTE_PATH)"
ROOT_DIR="$(realpath "$ABSOLUTE_DIR/..")"

mkdir -p "$ROOT_DIR/build/spec"
docker run -v "$ROOT_DIR/build/spec":"/antlr-out" -v "$ROOT_DIR/spec":"/antlr" ddl_antlr:latest -o /antlr-out /antlr/Ddl.g4
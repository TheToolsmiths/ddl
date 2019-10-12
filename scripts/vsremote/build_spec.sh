#!/usr/bin/bash

ABSOLUTE_PATH="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)/$(basename "${BASH_SOURCE[0]}")"
ABSOLUTE_DIR="$(dirname $ABSOLUTE_PATH)"
ROOT_DIR="$(realpath "$ABSOLUTE_DIR/../..")"

mkdir -p "$ROOT_DIR/build/spec"
java -Xmx500M -cp "/usr/local/lib/antlr-${ANTLR_VERSION}-complete.jar:$CLASSPATH" org.antlr.v4.Tool -o "$ROOT_DIR/build/spec" "$ROOT_DIR/spec/Ddl.g4"

rm -rf "$ROOT_DIR/spec/.antlr"
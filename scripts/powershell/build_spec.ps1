$ROOT_DIR = (Resolve-Path "$PSScriptRoot/../../")

$buildSpecPath = Join-Path $ROOT_DIR "/build/spec/"
$specPath = Join-Path $ROOT_DIR "/spec/"

if (Test-Path $buildSpecPath) {
    Remove-Item -Force -Recurse -Path $buildSpecPath
}

New-Item -Path $buildSpecPath -ItemType Directory | Out-Null

docker run -v "$($buildSpecPath):/antlr-out" -v "$($specPath):/antlr" ddl_antlr:latest -o /antlr-out /antlr/DdlParser.g4
#!/usr/bin/env bash
# Build, test, and optionally publish the Test3 API.
# Usage: scripts/build.sh [--publish] [--configuration Release|Debug]
set -euo pipefail

DOTNET="${DOTNET_EXEC:-dotnet}"
CONFIGURATION="Release"
PUBLISH=false
REPO_ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"

while [[ $# -gt 0 ]]; do
  case $1 in
    --publish) PUBLISH=true; shift ;;
    --configuration) CONFIGURATION="$2"; shift 2 ;;
    *) echo "Unknown argument: $1" >&2; exit 1 ;;
  esac
done

echo "==> Restoring packages..."
"$DOTNET" restore "$REPO_ROOT/Test3.slnx"

echo "==> Building (${CONFIGURATION})..."
"$DOTNET" build "$REPO_ROOT/Test3.slnx" \
  --configuration "$CONFIGURATION" \
  --no-restore \
  -warnaserror

echo "==> Running tests..."
"$DOTNET" test "$REPO_ROOT/Test3.slnx" \
  --configuration "$CONFIGURATION" \
  --no-build \
  --logger "console;verbosity=minimal"

if [[ "$PUBLISH" == "true" ]]; then
  echo "==> Publishing..."
  "$DOTNET" publish "$REPO_ROOT/src/Test3.Api/Test3.Api.csproj" \
    --configuration "$CONFIGURATION" \
    --output "$REPO_ROOT/publish" \
    --no-build
fi

echo "==> Done."

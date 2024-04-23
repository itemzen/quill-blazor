#!/bin/bash

if [ -z ${1+x} ]; then
    echo "Please run this script with the version suffix as first argument (e.g. 1)"
    exit 1
fi

VERSION_SUFFIX="${1}"

dotnet pack Quill.Blazor/Quill.Blazor.csproj -c Release --version-suffix "r${VERSION_SUFFIX}"

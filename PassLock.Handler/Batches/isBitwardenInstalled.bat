@echo off
bw --help >nul 2>&1 && (
    echo true
) || (
    echo false
)
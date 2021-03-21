@echo off
npm -v >nul 2>&1 && (
    echo true
) || (
    echo false
)
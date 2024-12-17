@echo off
echo Delete file ThreadsInfo.txt
del ThreadsInfo.txt

if exist example.txt (
    echo file deleted.
) else (
    echo file no deleted.
)

set EXE_NAME=ProjectTwo.Core.exe

for %%p in (4 8 16 32) do (
    echo Running with %%p processes...
    mpiexec -n %%p %EXE_NAME%
    exit
)pause
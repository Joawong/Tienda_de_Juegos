@echo off
start cmd /k "cd API && dotnet run --launch-profile https"
timeout /t 3 >nul
start cmd /k "cd tienda-videojuegos-web && npm run dev"
timeout /t 4 >nul

start http://localhost:5173
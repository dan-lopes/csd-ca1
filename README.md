# bp
Blood Pressure Calculator
ASP.Net Core

docker run --rm -v $(pwd):/app -w /app mcr.microsoft.com/dotnet/sdk:5.0 dotnet publish -c release -o out -r osx-x64 --self-contained false
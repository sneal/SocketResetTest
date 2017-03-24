# SocketResetTest
App to test socket resets from .NET 4.x. This application will do an HTTP GET every 1 second against `https://www.google.com` for 5 minutes by default.

## Deploying to CF

This repo includes the prebuilt console app executable, so you can just go ahead and clone this repo and `cf push` from any OS without needing to build. If you'd like to recompile you'll need a Windows box and Visual Studio 2015+.

## Configuration

Edit the manifest.yml environment vars to adjust the run length and target URL to perform an HTTP GET against.

```
RUN_TIME_IN_SECONDS: 360
URL_TO_GET: "https://www.google.com"
```

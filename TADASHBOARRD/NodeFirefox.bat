set HUB_HOST = 192.168.190.158
set HUB_PORT = 9090
set BROWSER  = firefox

java -jar selenium-server-standalone-2.53.0.jar -role node -hub http://%HUB_HOST%:%HUB_PORT%/grid/register -browser browserName=BROWSER, version=47, maxInstances = 5, platform=WINDOWS -port %NODE_PORT%
pause
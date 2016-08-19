set HUB_HOST = 192.168.190.158
set HUB_PORT = 9090
set BROWSER  = firefox
set NODE_PORT = 3535

java -jar selenium-server-standalone-2.53.0.jar -role node -hub http://%HUB_HOST%:%HUB_PORT%/grid/register -browser browserName=%BROWSER%, version=47 -port %NODE_PORT%
java -jar selenium-server-standalone-2.53.0.jar -role node -hub http://192.168.190.158:9090/grid/register -browser browserName=firefox, version=47 -port 3535


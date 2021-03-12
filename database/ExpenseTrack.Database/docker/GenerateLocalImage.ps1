 param (
    [Parameter(Mandatory=$true)][string]$SA_PASSWORD,
    [Parameter(Mandatory=$true)][string]$APP_USER_PASSWORD,
    [Parameter(Mandatory=$true)][string]$IMAGE_TAG
 )

Write-Host "Building Image"

docker build -t sql.integration.dbtemp:latest .

Write-Host "Running Image"

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=$SA_PASSWORD" -p 1934:1433 --name sql.integration.temp -d sql.integration.dbtemp:latest

Write-Host "Initializing Database"

docker exec sql.integration.temp sh -c "/opt/scripts/initialize.sh '$APP_USER_PASSWORD'"

Write-Host "Generating Final Image"

docker commit sql.integration.temp sql.integration.database:$IMAGE_TAG

Write-Host "Tear down intermediate containers"

docker stop sql.integration.temp

docker rm sql.integration.temp
#!/bin/bash
while getopts s:a:t: flag
do
    case "${flag}" in
        s) SA_PASSWORD=${OPTARG};;
        a) APP_USER_PASSWORD=${OPTARG};;
        t) IMAGE_TAG=${OPTARG};;
    esac
done

echo "Building Image"

docker build -t sql.integration.dbtemp:latest .

echo "Running Image"

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=$SA_PASSWORD" -p 1934:1433 --name sql.integration.temp -d sql.integration.dbtemp:latest

echo "Initializing Database"

docker exec sql.integration.temp sh -c "/opt/scripts/initialize.sh '$APP_USER_PASSWORD'"

echo "Generating Final Image"

docker commit sql.integration.temp sql.integration.database:$IMAGE_TAG

echo "Tear down intermediate containers"

docker stop sql.integration.temp

docker rm sql.integration.temp



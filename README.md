# sql-integration

## Building a local database image

### Via Bash Script

````
database/ExpenseTrack.Database/docker/generate-local-image.sh -s '<sa-password>' -a '<app-user-password>' -t <tag>
````

### Via Powershell Script

````
database\ExpenseTrack.Database\docker\GenerateLocalImage.ps1 -SA_PASSWORD '<sa-password>' -APP_USER_PASSWORD '<app-user-password>' -IMAGE_TAG '<tag>'
````

## Running the local image

The datbase project contains a Docker compose file for running the database locally.

````
docker-compose -f docker-compose-local.yml up -d

````

The database can be stopped via:

````
docker-compose -f docker-compose-local.yml down

````

## Connecting to the local database

The local database can be connected to through SQL Server Management Studio via:

localhost,<port-number>

The port number is set in the Docker compose file


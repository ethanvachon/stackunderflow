dotnet login
heroku login
heroku container:login

dotnet publish -c Release
docker build -t stackunderflow . -f Dockerfile
docker tag stackunderflow registry.heroku.com/stackunderflow-app/web
docker push registry.heroku.com/stackunderflow-app/web
heroku container:release web -a stackunderflow-app
echo press any key
read end
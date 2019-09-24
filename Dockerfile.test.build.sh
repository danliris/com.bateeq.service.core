docker build -f Dockerfile.test.build -t com-Bateeq-service-core-webapi:test-build .
docker create --name com-Bateeq-service-core-webapi-test-build com-Bateeq-service-core-webapi:test-build
mkdir bin
docker cp com-Bateeq-service-core-webapi-test-build:/out/. ./bin/publish
docker build -f Dockerfile.test -t com-Bateeq-service-core-webapi:test .

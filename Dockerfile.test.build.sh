docker build -f Dockerfile.test.build -t com-bateeq-service-core-webapi:test-build .
docker create --name com-bateeq-service-core-webapi-test-build com-bateeq-service-core-webapi:test-build
mkdir bin
docker cp com-bateeq-service-core-webapi-test-build:/out/. ./bin/publish
docker build -f Dockerfile.test -t com-bateeq-service-core-webapi:test .

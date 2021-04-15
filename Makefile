all: images
	./scripts/run.sh

web: apis
	cd ./src/client/nuxt-web && yarn && yarn build && yarn start

web-dev: apis
	cd ./src/client/nuxt-web && yarn && yarn dev

web-pre:
	cd ./src/client/nuxt-web && yarn && yarn dev

apis: images
	./scripts/run.sh

images: dist
	./scripts/build_images.sh

dist: build-apis

build-apis:
	./scripts/build_release.sh

api-identity: build-identity-image
	./scripts/run.sh 1

build-identity-image: build-identity
	./scripts/build_images.sh 1

build-identity:
	./scripts/build_release.sh 1

test:
	dotnet test

.PHONY: clean
clean:
	./scripts/stop.sh
	rm -rf build/

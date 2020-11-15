all: images
	./scripts/run.sh


images: dist
	./scripts/build_images.sh

dist:
	./scripts/build_release.sh
	cd ./src/client/nuxt-web && yarn && yarn build

web: apis
	cd ./src/client/nuxt-web && yarn start

web-dev: apis
	cd ./src/client/nuxt-web && yarn dev

apis:
	./scripts/run.sh

test:
	dotnet test

.PHONY: clean
clean:
	./scripts/stop.sh
	rm -rf build/

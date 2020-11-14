apis: images
	./scripts/run.sh

images: dist
	./scripts/build_images.sh

dist:
	./scripts/build_release.sh

test:
	dotnet test

test-web:
	cd ./src/client/nuxt-web && yarn && yarn dev

.PHONY: clean
clean:
	./scripts/stop.sh
	rm -rf build/

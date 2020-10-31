apis: images
	./scripts/run.sh

images: dist
	./scripts/build_images.sh

dist:
	./scripts/build_release.sh

test:
	dotnet test

.PHONY: clean
clean:
	./scripts/stop.sh
	rm -rf build/

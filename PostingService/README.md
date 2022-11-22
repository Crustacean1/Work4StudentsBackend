# Service for managing posted job offers and applications

## How to develop:
Ensure that docker stack is up and running and the `posting` service is stopped

When using database use connection string defined in environment variable `CONNECTION_STRING` for docker compatibility reasons

Use Visual Studio as usual, project file is in same directory as this README

## How to deploy:
- Bring down docker stack
- Build docker stack with `--no-cache` option to compile changes
- Bring stack up


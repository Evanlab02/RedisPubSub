# Redis PubSub - Distributed Cache with Replication

Repository to play around with the Redis PubSub functionality.

**NOTE: This project is very early in development.**

## Goal

This repository demonstrates building a distributed cache system using Redis Pub/Sub functionality. Here, four services utilize four separate caches, with three services only allowing reads. The fourth service allows both reads and writes, replicating changes to other caches upon writes.

The project is purely to learn more about publish/subscribe patterns.

Detailed documentation is available at https://evanlab-gme8r.ondigitalocean.app/redisps/

### Key Features

- Implements a distributed cache using Redis Pub/Sub.
- Simulates four services: three read-only and one read-write.
- Replicates write operations to all caches.

## Getting Started

### Pre-requisites

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/install/)

### Start the project

1. Clone the repository
2. Run the following command to start the project and build the Docker images:

```bash
docker compose up --build
```

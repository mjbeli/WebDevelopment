<p align="center">
  <a href="http://nestjs.com/" target="blank"><img src="https://nestjs.com/img/logo-small.svg" width="200" alt="Nest Logo" /></a>
</p>

[circleci-image]: https://img.shields.io/circleci/build/github/nestjs/nest/master?token=abc123def456
[circleci-url]: https://circleci.com/gh/nestjs/nest
  
## Description

[Nest](https://github.com/nestjs/nest) framework TypeScript starter repository.

## Installation

```bash
$ npm install
```

## Running the app

```bash
# development
$ npm run start

# watch mode
$ npm run start:dev

# production mode
$ npm run start:prod
```

## Test

```bash
# unit tests
$ npm run test

# e2e tests
$ npm run test:e2e

# test coverage
$ npm run test:cov
```

## Project Structure

Lets focus in files important to the develpment process and set aside the differents configuration files like package.json, tsconfig.json, .eslintrs.js, ...
All important files for development are inside `\src` folder.


`main.ts` has the function that executes at the start and declare a nest application using a module.

```typescript
import { NestFactory } from '@nestjs/core'; // import nest factory from nest
import { AppModule } from './app.module'; // import module from file

async function bootstrap() {
  const app = await NestFactory.create(AppModule); // --> create a nest application from this module
  await app.listen(3000); // --> run the nest application
}
bootstrap();
```

`app.module.ts` is the file where the module is declared and contains all the controllers and the services:

```typescript
import { Module } from '@nestjs/common';
// --> In the future import here the controllers and the services

@Module({
  imports: [],
  // --> In the future here declare the controllers and the services
})
export class AppModule {}
```



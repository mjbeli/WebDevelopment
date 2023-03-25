<p align="center">
  <a href="http://nestjs.com/" target="blank"><img src="https://nestjs.com/img/logo-small.svg" width="200" alt="Nest Logo" /></a>
</p>

[circleci-image]: https://img.shields.io/circleci/build/github/nestjs/nest/master?token=abc123def456
[circleci-url]: https://circleci.com/gh/nestjs/nest
  
#### Description

[Nest](https://github.com/nestjs/nest) framework TypeScript starter repository.

#### Installation

```bash
$ npm install
```

#### Running the app

(!) Inside the project folder

```bash
# development
$ npm run start

# watch mode
$ npm run start:dev

# production mode
$ npm run start:prod
```
 Alternative owth yarn be like: 
 yarn start
 yarn start:dev
 yarn start:prod

#### Test

```bash
# unit tests
$ npm run test

# e2e tests
$ npm run test:e2e

# test coverage
$ npm run test:cov
```

## 01 - Project Structure

Lets focus in files important to the develpment process and set aside the differents configuration files like package.json, tsconfig.json, .eslintrs.js, ...
All important files for development are inside `\src` folder.


`main.ts` has the function that executes at the start and declare a nest application using a module.

```typescript
import { NestFactory } from '@nestjs/core'; // import nest factory from nest
import { AppModule } from './app.module'; // import module from local file

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
  // --> In the future here declare the controllers, services, imports and exports
})
export class AppModule {}
```


## 02 - Modules

The module is the basic unit of organization for NestJS. In an NestJS application exists at least one module, the root module. 
It's common to create a folder for each module, and a module for feature.

A module is defined with the `@Module` decorator in a class. This decorator helps Nest to organize the application structure.

#### 02.01 - Properties of @Module decorator

Can pass this properties to the @Module decorator:
 - providers: an array of providers that will be available inside the module using dependency injection.
 - controllers: an array of controllers to be instantiated inside the module.
 - exports: array of providers to export. Other modules that import this module will have access to the providers declared here.
 - imports: array of modules required by this module. Any providers exported in these modules will be available in the current module.

```typescript
@Module({
  providers: [ServiceFileName],
  contollers: [ControllerFileName]
  imports: [
    ClassNameModule1,
    ClassNameModule2,
    ClassNameModule3
  ],
  exports:[ ServiceFileName ]  
})
```

#### 02.02 - Creating a module with NestJS CLI

We can create a module file by file, but we can also use the NestJS CLI to automatic generate a typical schema module.

Make sure you launch this command inside the 'src' folder.

```bash
nest g module module-name
```

g stands for 'generate' and can receive several parameters, for more info type `nest g --help`

This command creates a new folder, a new module file inside that folder and update the 'app.module.ts' file to include the new module inside the Nest root module.


## 03 - Controllers

Controllers are responsibles to handle incoming request and returning responses.

Each controller is bound to a specific path, for example tasksController is bounded to /tasks.

Controller contains differents handlers as get, post, delete each of them can be an endpoint.

Controllers can use dependency injection to use providers.

#### 03.01 - Defining a controller

A controller is a class with the `@Controller` decorator. This decorator accepts a string that is the path that will be handled by the controller:

You can create a controller using this command inside the 'src' folder:
```bash
nest g controller controller-name
```

If you want to generate without test:
```bash
nest g controller controller-name --no-spec
```

This will create a new file for the controller (created automatic inside the module folder with the same name of the controller) and update the module file to add the new controller.

#### 03.02 - Defining a handler

A handler is a method inside a controller class that use decorators such as ´@Get´, ´@Post´, ´@Delete´. The handlers are the actions of a controller:

```typescript
@Controller('/tasks')
export class TasksController {
  @Get()
  getAllTasks(){
    //...
  }

  @Post()
  createTask(){
    //...
  }
}
```

And to add a endpoint to the controller that use the service:
```typescript
// Defining an end point to our controller, in this case a Get request receive in tasks controller with 'getAllTasks' action name with by managed by this endpoint
// http://localhost:3000/tasks/getAllTasks
@Get('getAllTasks')
getAllTasks() {
  return this.tasksService.getAllTasks();
}
```

An endpoint with parameters:
```typescript
// In this case all request to tasks controller being a Post request will invoke this endpoint. --> POST : http://localhost:3000/tasks
// Note that there isn't path argument in Post annotation.
// With @Body annotation NestJS will inject automatic the variable in the body with name title to the title parameter.
@Post()
createTask(
  @Body('title') title: string,
  @Body('description') description: string,
): Task {
  return this.tasksService.createTask(title, description);
}
```

The same endpoint but using a DTO class. Note that due to the empty parameter in ´@Body()´, the entire object received throught the body will be mapped into the DTO object:
```typescript
@Post()
createTask(@Body() createTaskDtoObject: CreateTaskDto): Task {
  return this.tasksService.createTask(createTaskDtoObject);
}
```

Here is the way to define a handler with path parameter. 
Inside the ´@Get()´ decorator we can define the path parameters with a colon ´:´ before the name of the parameter.
To receive the path parameter inside the handler we can use the ´@Param()´ decorator with the same name defined in the ´@Get´ decorator, then declare the variable (name and type) that will be mapped into and would be acccesible inside the method.

```typescript
// End point with a path parameter
@Get('/:id')
getTaskById(@Param('id') id: string): Task {
  return this.tasksService.getTaskById(id);
}
```

```typescript
// Defining search tasks due to a filter (if filter doesn't exists then return all tasks)
// Query parameters are received by the url and will map the parameters with the dfinition of the DTO.
// http://localhost:3000/tasks?status=OPEN&search=never
@Get('')
getTasks(@Query() filterDto: GetTaskFilterDto): Task[] {
  if (Object.keys(filterDto).length) {
    return this.tasksService.getTasksByFilter(filterDto);
  } else {
    return this.tasksService.getAllTasks();
  }
}
```



## 04 - Providers & Services

#### 04.01 - Providers

Providers are classes, plain values or sync/async functions decorated with ´@Injectable´. Can be injected into constructors using dependency injection.

To be accesible inside a module (this means to be injectable), the providers must be declared inside:
```typescript
@Module({
  providers: [ServiceFileName],
  // ...
})
```

#### 04.02 - Services

Not all providers are services, but all services are declared as providers.
Services are Singleton classes with the decorator ´@Injectable()´ and provided to a module. Yes, here we are talking about singleton design pattern.
In NestJS services are the main source of business logic.


Any component in NetJS can inject a provider (any element decorated with ´@Injectable´). 
NetJS use constructor dependency injection, that will be accessible as a class property.

You can create a service using this command inside the 'src' folder:

```bash
nest g service service-name --no-spec
```

This command create a service file with this content:
```typescript
// File tasks.service.ts
import { Injectable } from '@nestjs/common';

@Injectable()
export class TasksService {}
```

And add the new services into the module:
```typescript
// File tasks.module.ts
import { Module } from '@nestjs/common';
import { TasksController } from './tasks.controller';
import { TasksService } from './tasks.service';

@Module({
  controllers: [TasksController],
  providers: [TasksService],
})
export class TasksModule {}
```

To add the service to the controller:

```typescript
// File tasks.controller.ts
import { Controller } from '@nestjs/common';
import { TasksService } from './tasks.service';

@Controller('tasks')
export class TasksController {
  constructor(private tasksService: TasksService) {}
  // Note that adding an accessor (like private, public,...) ahead of the constructor parameter NetJS will automatic create 
  // a private atribute inside the class and assign it the value received in the constructor.
}
```


## 05 - Validation & Error Handling

#### 05.01 - Validation Pipeline

 - Pipes operates in arguments of the action/handler, just befor the handler itself.
 - Pipes can perform data validation & data transformation.
 - Pipes can throw exceptions that will be handled by NestJs and parsed into error response.

Samples:
`ValidationPipeline` validates the compatibilityof an entire object against a class (DTO). If any property cann't be mapped, the validation will fail.
`ParseIntPipe` validates an argument is a number: the argument is transformed to a Number ans passed to the handler.

Custom Pipes Validation

 - Pipes ara classes with `@Injectable()` decorator and must implement `PipeTransform` interface.
 - The `transform()` method is called by NestJs to validate and tranforms the arguments.
 - Whatever is returned by `tranform()` method will ve passed to the handler. Exceptions will be returned to the client.

There are different types of Pipes:
 - Handler-level
 - Parameter-level
 - Global --> defined at application level and applied to all incoming request.


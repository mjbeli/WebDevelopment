import { Controller, Get, Post, Delete, Body, Param } from '@nestjs/common';
import { TasksService } from './tasks.service';
import { Task } from './task.model';
import { CreateTaskDto } from './dto/create-task.dto';

@Controller('tasks')
export class TasksController {
  constructor(private tasksService: TasksService) {}

  // Note that adding an accessor (like private, public,...) ahead of the constructor parameter NetJS will automatic create
  // a private attribute inside the class and assign it the value received in the constructor.

  // So the code above it's similar to:
  /*
    export class TasksController {
        tasksService: TasksService;
        constructor(tasksService: TasksService) {
            this.tasksService = tasksService;
        }
    }
  */

  // Defining an end point to our controller, in this case all Get request receive in tasks controller with 'getAllTasks' action name with by managed by this endpoint
  @Get('getAllTasks')
  getAllTasks(): Task[] {
    return this.tasksService.getAllTasks();
  }

  // End point with a path parameter
  @Get('/:id')
  getTaskById(@Param('id') id: string): Task {    
    return this.tasksService.getTaskById(id);
  }

  // In this case all request to tasks controller being a Post request will invoke this endpoint.
  // Note that there isn't path argument in Post annotation.
  // With @Body annotation NestJS will inject automatic the variable in the body with name title to the title parameter.
  @Post()
  createTask(@Body() createTaskDtoObject: CreateTaskDto): Task {
    return this.tasksService.createTask(createTaskDtoObject);
  }

  @Delete('/:id')
  deleteTaskById(@Param('id') id: string): boolean {
    return this.tasksService.deleteTaskById(id);
  }
}

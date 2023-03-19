import { Controller, Get, Post, Delete, Put, Body, Param, Query } from '@nestjs/common';
import { TasksService } from './tasks.service';
import { Task, TaskStatus } from './task.model';
import { CreateTaskDto } from './dto/create-task.dto';
import { GetTaskFilterDto } from './dto/get-task-filter.dto';

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

  // Defining an end point to our controller, search tasks due to a filter (if filter doesn't exists then return all tasks)
  // Query parameters are received by the url like
  // http://localhost:3000/tasks?status=OPEN&search=never
  @Get('')
  getTasks(@Query() filterDto: GetTaskFilterDto): Task[] {
    if (Object.keys(filterDto).length) {
      return this.tasksService.getTasksByFilter(filterDto);
    } else {
      return this.tasksService.getAllTasks();
    }
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

  @Put('/:id/status')
  updateStatusTaskById(
    @Param('id') id: string,
    @Body('status') status: TaskStatus,
  ): Task {
    return this.tasksService.updateStatusTaskById(id, status);
  }
}

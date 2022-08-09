import { Controller, Get } from '@nestjs/common';
import { TasksService } from './tasks.service';

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

  // Defining an end point to our controller, in this case all Get request receive in tasks controller with action name with by managed by this endpoint
  @Get('getAllTasks')
  getAllTasks() {
    return this.tasksService.getAllTasks();
  }
}

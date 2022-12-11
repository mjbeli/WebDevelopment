import { Injectable } from '@nestjs/common';
import { Task, TaskStatus } from './task.model';
import { v4 as uuid } from 'uuid';
import { CreateTaskDto } from './dto/create-task.dto';

@Injectable()
export class TasksService {
  private tasks: Task[] = [];

  // By default in TypeScript a method without an accessor is public.
  getAllTasks(): Task[] {
    return this.tasks;
  }

  createTask(createTaskDtoObject: CreateTaskDto): Task {
    const { title, description } = createTaskDtoObject;

    const task: Task = {
      id: uuid(),
      title: title,
      description: description,
      status: TaskStatus.READY,
    };
    this.tasks.push(task);
    return task;
  }
}
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

  getTaskById(id: string): Task {
    return this.tasks.find((item) => item.id == id);
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

  deleteTaskById(id: string): boolean {
    const index = this.tasks.findIndex((item) => item.id == id);
    if (index > -1) {
      this.tasks.splice(index, 1);
      return true;
    }
    return false;
  }

  updateStatusTaskById(id: string, status: TaskStatus): Task {
    const index = this.tasks.findIndex((item) => item.id == id);
    if (index > -1) {
      this.tasks[index].status = status;
      return this.tasks[index];
    }
    return null;
  }
}

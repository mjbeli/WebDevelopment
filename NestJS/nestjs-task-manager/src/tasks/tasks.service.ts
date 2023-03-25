import { Injectable } from '@nestjs/common';
import { Task, TaskStatus } from './task.model';
import { v4 as uuid } from 'uuid';
import { CreateTaskDto } from './dto/create-task.dto';
import { GetTaskFilterDto } from './dto/get-task-filter.dto';
import { NotFoundException } from '@nestjs/common/exceptions/not-found.exception';

@Injectable()
export class TasksService {
  private tasks: Task[] = [];

  // By default in TypeScript a method without an accessor is public.
  getAllTasks(): Task[] {
    return this.tasks;
  }

  getTaskById(id: string): Task {
    const myTask = this.tasks.find((item) => item.id == id);
    if (!myTask) {
      throw new NotFoundException('Task not found');
    }
    return myTask;
  }

  getTasksByFilter(filterDto: GetTaskFilterDto): Task[] {
    // Map the attributes of filter Dto into independent variables. Must have the same name!
    const { status, search } = filterDto;

    let tasks = this.getAllTasks();
    if (status) {
      tasks = tasks.filter((item) => item.status === status);
    }
    if (search) {
      tasks = tasks.filter((item) => {
        if (item.title.includes(search) || item.description.includes(search)) {
          return true;
        }
        return false;
      });
    }
    return tasks;
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

import { Injectable } from '@nestjs/common';

@Injectable()
export class TasksService {
  private tasks = [{ name: 'task1', type: 'boring' }];

  // By default in TypeScript a method without an accessor is public.
  getAllTasks() {
    return this.tasks;
  }
}

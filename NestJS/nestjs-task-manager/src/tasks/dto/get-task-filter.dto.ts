import { TaskStatus } from '../task.model';

// Both filters, status and search will be optional (mark with ?)
export class GetTaskFilterDto {
  status?: TaskStatus;
  search?: string;
}

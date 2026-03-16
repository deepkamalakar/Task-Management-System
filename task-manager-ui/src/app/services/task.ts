import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  apiUrl = 'https://localhost:5001/api/tasks';

  constructor(private http: HttpClient) { }

  getTasks(){
    return this.http.get(this.apiUrl);
  }

  addTask(task:any){
    return this.http.post(this.apiUrl, task);
  }

  deleteTask(id:number){
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

}
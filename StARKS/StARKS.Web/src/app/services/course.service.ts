import { Observable } from 'rxjs/Rx';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class CourseService {

  constructor(private http: Http) { }

  getAll(): Observable<any> {
    return this.http
      .get('http://localhost:61845/courses')
      .map(response => response.json() as starks.Course[]);
  }
}

import { Observable } from 'rxjs/Rx';
import { Http, RequestOptions } from '@angular/http';
import { Injectable } from '@angular/core';
import { Response } from '@angular/http';

@Injectable()
export class CourseService {

  constructor(private http: Http) { }

  getAll(): Observable<starks.Course[]> {
    return this.http.get('http://localhost:61845/courses').map(response => response.json() as starks.Course[]);
  }

  get(id: number): Observable<starks.Course> {
    return this.http
      .get('http://localhost:61845/courses/' + id)
      .map(response => response.json() as starks.Course);
  }

  add(course: starks.Course): Observable<starks.Course> {
    return this.http
      .post('http://localhost:61845/courses', course)
      .map(response => response.json() as starks.Course);
  }

}

import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class MarksService {

  constructor(private http: Http) { }

  // [HttpGet("{courseId}/students/{studentId}", Name = "GetMark")]

  getAll(): Observable<any> {
    return this.http
      .get('http://localhost:61845/marks')
      .map(response => response.json() as starks.Mark[]);
  }
  get(studentId: number, courseCode: number): Observable<starks.Mark> {
    return this.http
      .get('http://localhost:61845/marks/' + courseCode + '/students/' + studentId)
      .map(response => response.json() as starks.Mark);
  }

  add(course: starks.Course): Observable<starks.Course> {
    return this.http
      .post('http://localhost:61845/courses', course)
      .map(response => response.json() as starks.Course);
  }
  update(course: starks.Course): Observable<void> {
    return this.http
      .put('http://localhost:61845/courses/' + course.code, course)
      .map(response => response.json());
  }

  delete(code: number): Observable<void> {
    return this.http
      .delete('http://localhost:61845/courses/' + code)
      .map(response => response.json());
  }

}

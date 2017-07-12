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

  get(code: number): Observable<starks.Course> {
    return this.http
      .get('http://localhost:61845/courses/' + code)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as starks.Course);
  }

  add(course: starks.Course): Observable<starks.Course> {
    return this.http
      .post('http://localhost:61845/courses', course)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as starks.Course);
  }
  update(course: starks.Course): Observable<void> {
    return this.http
      .put('http://localhost:61845/courses/' + course.code, course)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json());
  }

  delete(code: number): Observable<void> {
    return this.http
      .delete('http://localhost:61845/courses/' + code)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json());
  }
}

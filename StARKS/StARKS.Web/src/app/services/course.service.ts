import { Observable } from 'rxjs/Rx';
import { Http, RequestOptions } from '@angular/http';
import { Injectable } from '@angular/core';
import { Response, Headers } from '@angular/http';

@Injectable()
export class CourseService {

  handleError: any;

  course: starks.Course;

  constructor(private http: Http) { }

  getAll(): Observable<any> {
    return this.http.get('http://localhost:61845/courses').map(response => response.json() as starks.Course[]);
  }

  saveCourse(course: starks.Course): Observable<any> {
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.post('http://localhost:61845/courses', JSON.stringify(course), options).map((response: Response) => {
      return response.json();
    }).catch((error: Response | any) => {
      console.log(error.statusText);
      return Observable.throw(error);
    });
  }
}

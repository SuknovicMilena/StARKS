import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class MarksService {

  constructor(private http: Http) { }

  getAll(studentId: number): Observable<any> {
    return this.http
      .get(`http://localhost:61845/students/${studentId}/marks`)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as starks.Mark[]);
  }

  get(studentId: number, courseCode: number): Observable<starks.Mark> {
    return this.http
      .get(`http://localhost:61845/students/${studentId}/marks/courses/${courseCode}`)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as starks.Mark);
  }

  add(mark: starks.Mark): Observable<starks.Mark> {
    return this.http
      .post(`http://localhost:61845/students/${mark.studentId}/marks/courses/${mark.courseCode}`, mark)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as starks.Mark);
  }

  update(mark: starks.Mark): Observable<void> {
    return this.http
      .put(`http://localhost:61845/students/${mark.studentId}/marks/courses/${mark.courseCode}`, mark)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json());
  }

  delete(studentId: number, courseCode: number): Observable<void> {
    return this.http
      .delete(`http://localhost:61845/students/${studentId}/marks/courses/${courseCode}`)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json());
  }

}

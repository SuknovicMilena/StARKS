import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class StudentService {

  constructor(private http: Http) { }

  getAll(): Observable<any> {
    return this.http
      .get('http://localhost:61845/students')
      .map(response => response.json() as starks.Student[]);
  }

}

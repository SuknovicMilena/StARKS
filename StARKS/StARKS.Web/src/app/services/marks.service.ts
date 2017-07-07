import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class MarksService {

  constructor(private http: Http) { }

  getAll(): Observable<any> {
    return this.http
      .get('http://localhost:61845/marks')
      .map(response => response.json() as starks.Mark[]);
  }

}

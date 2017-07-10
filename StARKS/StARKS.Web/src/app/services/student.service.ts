import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class StudentService {

  constructor(private http: Http) { }

  getAll(): Observable<starks.Student[]> {
    return this.http
      .get('http://localhost:61845/students')
      .map(response => response.json() as starks.Student[]);
  }

  get(id: number): Observable<starks.Student> {
    return this.http
      .get('http://localhost:61845/students/' + id)
      .map(response => {
        let studentObj = response.json();
        studentObj.dateOfBirth = new Date(studentObj.dateOfBirth);
        return studentObj as starks.Student;
      });
  }

  add(student: starks.Student): Observable<starks.Student> {
    return this.http
      .post('http://localhost:61845/students', student)
      .map(response => response.json() as starks.Student);
  }

  update(student: starks.Student): Observable<void> {
    return this.http
      .put('http://localhost:61845/students/' + student.id, student)
      .map(response => response.json());
  }

  delete(id: number): Observable<void> {
    return this.http
      .delete('http://localhost:61845/students/' + id)
      .map(response => response.json());
  }

}

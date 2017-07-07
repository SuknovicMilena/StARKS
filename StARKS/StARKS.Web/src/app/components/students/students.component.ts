import { Component, OnInit } from '@angular/core';
import { StudentService } from './../../services/student.service';

@Component({
  selector: 'students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  students: starks.Student[];

  constructor(private studentService: StudentService) { }

  ngOnInit() {
    this.studentService.getAll().subscribe((students: starks.Student[]) => {
      this.students = students;
    });
  }

  edit() {

  }

}

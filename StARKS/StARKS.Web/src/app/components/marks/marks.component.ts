import { Component, OnInit } from '@angular/core';
import { MarksService } from './../../services/marks.service';

@Component({
  selector: 'marks',
  templateUrl: './marks.component.html',
  styleUrls: ['./marks.component.css']
})
export class MarksComponent implements OnInit {

  marks: starks.Mark[];
  constructor(private marksService: MarksService) { }

  ngOnInit() {
    this.marksService.getAll().subscribe((marks: starks.Mark[]) => {
      this.marks = marks;
    });
  }

  edit() {

  }
}

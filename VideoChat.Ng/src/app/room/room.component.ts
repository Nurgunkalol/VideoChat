import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.scss']
})
export class RoomComponent implements OnInit {
  token: string;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.forEach((params) => {
      this.token = params.token;
    })
  }

}

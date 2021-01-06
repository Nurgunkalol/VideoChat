import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.scss']
})
export class RoomComponent implements OnInit {
  token: string;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.pipe(
      map((params) => {
        this.token = params.token;
      }),
      switchMap(() => navigator.mediaDevices.getUserMedia({ video: true, audio: true })))
      .subscribe((stream) => {
        console.log(stream);
      });
  }

}

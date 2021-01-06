import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RoomService } from './room.service';

@Component({
  selector: 'app-room-create',
  templateUrl: './room-create.component.html',
  styleUrls: ['./room-create.component.scss']
})
export class RoomCreateComponent implements OnInit {

  constructor(private roomService: RoomService,
    private router: Router) { }

  ngOnInit() {
  }

  createRoom() {
    this.roomService.createRoom()
      .subscribe((token) => {
        this.router.navigate(['/', token]);
      }, error => {
        console.log('dasdasd', error);
      })
  }
}

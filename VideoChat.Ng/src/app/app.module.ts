import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RoomCreateComponent } from './room/room-create.component';
import { RoomComponent } from './room/room.component';
import { WebcamModule } from 'ngx-webcam';
import { RoomService } from './room/room.service';

@NgModule({
  declarations: [
    AppComponent,
    RoomComponent,
    RoomCreateComponent
  ],
  imports: [
    BrowserModule,
    WebcamModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [RoomService],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RoomCreateComponent } from './room/room-create.component';
import { RoomComponent } from './room/room.component';


const routes: Routes = [
  { path: '', redirectTo: '/create', pathMatch: 'full' },
  { path: 'create', component: RoomCreateComponent },
  { path: ':token', component: RoomComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

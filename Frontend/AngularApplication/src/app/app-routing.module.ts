import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  { path: 'users', component: UsersComponent }
];

@NgModule({
  imports: [
     [RouterModule.forRoot(routes)],
    
  ],
  exports: [RouterModule],
  declarations: []
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResultNewComponent } from './result-new/result-new.component';
import { ResultEditComponent } from './result-edit/result-edit.component';
import { ResultListComponent } from './result-list/result-list.component';

const routes: Routes = [
  {path:'teacher', children: [
    {path: 'allResult', component: ResultListComponent},
    {path: 'newResult', component: ResultNewComponent},
    {path: 'editResult/:id', component: ResultEditComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TeacherRoutingModule { }

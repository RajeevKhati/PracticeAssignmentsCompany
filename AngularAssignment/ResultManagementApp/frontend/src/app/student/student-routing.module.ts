import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResultDetailsComponent } from './result-details/result-details.component';
import { ResultFindComponent } from './result-find/result-find.component';

const routes: Routes = [
  {path: 'student', children: [
    {path:'findResult', component: ResultFindComponent},
    {path: 'getResult', component: ResultDetailsComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentRoutingModule { }

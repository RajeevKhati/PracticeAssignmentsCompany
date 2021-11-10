import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ReactiveFormsModule} from '@angular/forms';

import { StudentRoutingModule } from './student-routing.module';
import { ResultFindComponent } from './result-find/result-find.component';
import { ResultDetailsComponent } from './result-details/result-details.component';
import { MaterialModule } from '../material/material.module';

import { ResultService } from '../services/result.service';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    ResultFindComponent,
    ResultDetailsComponent
  ],
  imports: [
    CommonModule,
    StudentRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers:[ResultService]
})
export class StudentModule { }

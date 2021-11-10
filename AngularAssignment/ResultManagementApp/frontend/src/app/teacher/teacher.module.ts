import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ReactiveFormsModule} from '@angular/forms';

import { TeacherRoutingModule } from './teacher-routing.module';
import { ResultListComponent } from './result-list/result-list.component';
import { ResultNewComponent } from './result-new/result-new.component';
import { ResultEditComponent } from './result-edit/result-edit.component';
import { MaterialModule } from '../material/material.module';

import { ResultService } from '../services/result.service';
import { HttpClientModule } from '@angular/common/http';
import { DeleteDialogComponent } from './result-list/delete-dialog/delete-dialog.component';


@NgModule({
  declarations: [
    ResultListComponent,
    ResultNewComponent,
    ResultEditComponent,
    DeleteDialogComponent
  ],
  imports: [
    CommonModule,
    TeacherRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers:[ResultService]
})
export class TeacherModule { }

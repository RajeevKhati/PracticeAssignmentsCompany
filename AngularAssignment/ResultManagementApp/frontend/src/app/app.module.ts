import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { HomeComponent } from './home/home.component';
import { TeacherModule } from './teacher/teacher.module';
import { StudentModule } from './student/student.module';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { DeleteDialogComponent } from './teacher/result-list/delete-dialog/delete-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    TeacherModule,
    StudentModule,
    AppRoutingModule
  ],
  providers: [],
  entryComponents: [
    DeleteDialogComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

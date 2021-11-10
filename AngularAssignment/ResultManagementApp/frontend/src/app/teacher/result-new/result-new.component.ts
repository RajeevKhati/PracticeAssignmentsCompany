import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ResultService } from 'src/app/services/result.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Location } from '@angular/common';

@Component({
  selector: 'app-result-new',
  templateUrl: './result-new.component.html',
  styleUrls: ['./result-new.component.css'],
})
export class ResultNewComponent implements OnInit {
  newResultForm: FormGroup;
  minDate: Date;
  maxDate: Date;

  constructor(
    private fb: FormBuilder,
    private _resultService: ResultService,
    private _router: Router,
    private _snackBar: MatSnackBar,
    private _location: Location
  ) {
    this.newResultForm = this.fb.group({
      rollNumber: ['', [Validators.required]],
      name: ['', [Validators.required]],
      dateOfBirth: ['', [Validators.required]],
      score: ['', [Validators.required]],
    });

    const currentYear = new Date().getFullYear();
    this.minDate = new Date(currentYear - 90, 0, 1);
    this.maxDate = new Date(currentYear - 3, 11, 31);
  }

  ngOnInit(): void {}

  onSubmit(): void {
    console.log(this.newResultForm.value);
    if (this.newResultForm.valid) {
      this._resultService.addResult(this.newResultForm.value).subscribe(
        (res) => {
          console.log(res);
          this._snackBar.open(res.message, 'X', {
            duration: 3000,
            horizontalPosition: 'center',
            verticalPosition: 'top',
          });
          this._router.navigateByUrl('/teacher/allResult');
        },
        (err) => {
          console.log(err);
          this._snackBar.open(err, 'X', {
            duration: 5000,
            horizontalPosition: 'center',
            verticalPosition: 'top',
          });
        }
      );
    }
  }

  goBack(): void {
    this._location.back();
  }
}

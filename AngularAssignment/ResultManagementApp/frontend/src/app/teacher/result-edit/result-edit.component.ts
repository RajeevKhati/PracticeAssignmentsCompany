import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IResult } from 'src/app/models/result.model';
import { ResultService } from 'src/app/services/result.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-result-edit',
  templateUrl: './result-edit.component.html',
  styleUrls: ['./result-edit.component.css'],
})
export class ResultEditComponent implements OnInit {
  editResultForm: FormGroup;

  minDate: Date;
  maxDate: Date;

  constructor(
    private fb: FormBuilder,
    private _resultService: ResultService,
    private _route: ActivatedRoute,
    private _router: Router,
    private _snackBar: MatSnackBar
  ) {
    this.editResultForm = this.fb.group({
      rollNumber: ['', [Validators.required]],
      name: ['', [Validators.required]],
      dateOfBirth: ['', [Validators.required]],
      score: ['', [Validators.required]],
      id: [],
    });

    _resultService.getResult(_route.snapshot.params.id).subscribe(
      (resultJson) => {
        let resultById: IResult = resultJson.data;
        this.editResultForm.setValue({
          rollNumber: resultById.rollNumber,
          name: resultById.name,
          dateOfBirth: resultById.dateOfBirth,
          score: resultById.score,
          id: resultById.id,
        });
      },
      (err) => {
        console.log(err);
        this._snackBar.open(err, 'X', {
          duration: 5000,
          horizontalPosition: 'center',
          verticalPosition: 'top',
        });
        this._router.navigateByUrl('/teacher/allResult');
      }
    );

    const currentYear = new Date().getFullYear();
    this.minDate = new Date(currentYear - 90, 0, 1);
    this.maxDate = new Date(currentYear - 3, 11, 31);
  }

  ngOnInit(): void {}

  onSubmit(): void {
    console.log(this.editResultForm.value);
    if (this.editResultForm.valid) {
      this._resultService.updateResult(this.editResultForm.value).subscribe(
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
}

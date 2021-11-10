import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, NavigationExtras } from '@angular/router';
import { ResultService } from 'src/app/services/result.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-result-find',
  templateUrl: './result-find.component.html',
  styleUrls: ['./result-find.component.css'],
})
export class ResultFindComponent implements OnInit {
  findResultForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private _resultService: ResultService,
    private _router: Router,
    private _snackBar: MatSnackBar
  ) {
    this.findResultForm = this.fb.group({
      rollNumber: ['', [Validators.required]],
      dateOfBirth: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {}

  onSubmit(): void {
    console.log(this.findResultForm.value);
    let searchCriteria = this.findResultForm.value;
    if (this.findResultForm.valid) {
      this._resultService.findResultByCriteria(searchCriteria).subscribe(
        (res) => {
          console.log(res);
          let navigationExtras: NavigationExtras = {
            state: res.data,
          };
          this._snackBar.open(res.message, 'X', {
            duration: 3000,
            horizontalPosition: 'center',
            verticalPosition: 'top',
          });
          this._router.navigate(['/student/getResult'], navigationExtras);
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

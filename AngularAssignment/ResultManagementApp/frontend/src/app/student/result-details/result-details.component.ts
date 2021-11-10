import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IResult } from 'src/app/models/result.model';
import { Location } from '@angular/common';

@Component({
  selector: 'app-result-details',
  templateUrl: './result-details.component.html',
  styleUrls: ['./result-details.component.css'],
})
export class ResultDetailsComponent implements OnInit {
  searchedResult: IResult;

  constructor(private _router: Router, private _location:Location) {
    this.searchedResult = this._router.getCurrentNavigation()?.extras
      .state as IResult;
  }

  ngOnInit(): void {}

  goBack():void{
    this._location.back();
  }
}

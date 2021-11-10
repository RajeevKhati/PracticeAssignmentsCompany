import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { IResult } from 'src/app/models/result.model';
import { ResultService } from 'src/app/services/result.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-result-list',
  templateUrl: './result-list.component.html',
  styleUrls: ['./result-list.component.css'],
})
export class ResultListComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    'rollNumber',
    'name',
    'dateOfBirth',
    'score',
    'action',
  ];

  resultTable!: MatTableDataSource<IResult>;

  @ViewChild(MatTable) table!: MatTable<MatTableDataSource<IResult>>;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private _resultService: ResultService,
    private _router: Router,
    private _snackBar: MatSnackBar,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this._resultService.getAllResult().subscribe(
      (resultJson) => {
        console.log(resultJson);
        this.resultTable = new MatTableDataSource(resultJson.data);
      },
      (err) => console.log(err)
    );
  }

  deleteResult(id: number): void {
    const deleteDialogRef = this.dialog.open(DeleteDialogComponent);

    deleteDialogRef.afterClosed().subscribe((isDelete) => {
      if (isDelete) {
        this._resultService.deleteResult(id).subscribe(
          (resultJson) => {
            console.log(resultJson);
            let index = this.resultTable.data.findIndex((res) => res.id === id);
            this.resultTable.data.splice(index, 1);
            this.table.renderRows();
            this.resultTable.sort = this.sort;
            this.resultTable.paginator = this.paginator;
            this._snackBar.open(resultJson.message, 'X', {
              duration: 3000,
              horizontalPosition: 'center',
              verticalPosition: 'top',
            });
          },
          (err) => {
            console.log(err);
          }
        );
      }
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.resultTable.filter = filterValue.trim().toLowerCase();
  }

  ngAfterViewInit() {
    this.resultTable.sort = this.sort;
    this.resultTable.paginator = this.paginator;
  }
}

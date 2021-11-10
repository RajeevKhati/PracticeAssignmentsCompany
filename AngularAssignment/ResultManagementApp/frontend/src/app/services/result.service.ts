import { Injectable } from '@angular/core';
import { IResult } from '../models/result.model';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class ResultService {

    private readonly baseUrl = 'http://localhost:3000/api/results';

    constructor(private httpClient: HttpClient) { }

    //fetching all results from backend
    getAllResult(): Observable<any> {
        return this.httpClient.get<any>(this.baseUrl)
            .pipe(catchError(this.handleError));
    }

    //fetching result from backend based on given id
    getResult(id: number): Observable<any> {
        return this.httpClient.get<any>(`${this.baseUrl}/${id}`)
            .pipe(catchError(this.handleError));
    }

    //adding a new result to the database by calling post method on backend
    addResult(result: IResult): Observable<any> {
        return this.httpClient.post<IResult>(this.baseUrl, result, {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        })
            .pipe(catchError(this.handleError));
    }

    //updating existing result
    updateResult(result: IResult): Observable<any> {
        return this.httpClient.put<void>(`${this.baseUrl}/${result.id}`, result, {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        })
            .pipe(catchError(this.handleError));
    }

    //delete a result based on id
    deleteResult(id: number): Observable<any> {
        return this.httpClient.delete<void>(`${this.baseUrl}/${id}`)
            .pipe(catchError(this.handleError));
    }

    //find result based on criteria object which must contain rollNumber and dateOfBirth.
    findResultByCriteria(criteria: {}): Observable<any> {
        return this.httpClient.get<any>(this.baseUrl, { params: criteria })
            .pipe(catchError(this.handleError));
    }

    //Handling error
    private handleError(errorResponse: HttpErrorResponse) {
        if (errorResponse.error instanceof ErrorEvent) {
            console.error('Client Side Error :', errorResponse.error.message);
        } else {
            console.error('Server Side Error :', errorResponse);
            return throwError(errorResponse.error.message);
        }
        return throwError('There is a problem with the service. We are notified & working on it. Please try again later.');
    }
}

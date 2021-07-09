import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AutoresService {

  baseURL = `http://localhost:54886/api/`;

  constructor(protected http: HttpClient) { }

  getAllAutores():Observable<any[]> { 
    try {
      return this.http.get<any[]>( `${this.baseURL}Autores`)
    } catch (error) {
        console.log(error);
        throw error;
      }
  }
}

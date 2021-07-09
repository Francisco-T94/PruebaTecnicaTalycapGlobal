import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class LibrosService {

  baseURL = `http://localhost:54886/api/`;

  constructor(protected http: HttpClient) { }

  getAllLibros():Observable<any[]> { 
    try {
      return this.http.get<any[]>( `${this.baseURL}Libros`)
    } catch (error) {
        console.log(error);
        throw error;
      }
  }

  getLibrosByIdAutor(IdAutor:any):Observable<any[]> { 
    try {
      return this.http.get<any[]>( `${this.baseURL}Libros/GetLibrosByIdAutor/${IdAutor}`)
    } catch (error) {
        console.log(error);
        throw error;
      }
  }

  getLibrosByRangeDate( fechaInicio:any, fechaFin:any):Observable<any[]> { 
    try {
      return this.http.get<any[]>( `${this.baseURL}Libros/GetLibrosByRangeDate/${fechaInicio}/${fechaFin}`)
    } catch (error) {
        console.log(error);
        throw error;
      }
  }
}

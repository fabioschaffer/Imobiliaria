import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ICaracteristica } from '../interfaces/ICaracteristica';

@Injectable({
  providedIn: 'root'
})
export class CaracteristicaService {

  apiUrl: string = environment.apiUrl + '/Caracteristica';

  constructor(private http: HttpClient) { }

  obterTodas(): Observable<ICaracteristica[]> {
    return this.http.get<ICaracteristica[]>(this.apiUrl);
  }
}
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ITipoImovel } from '../interfaces/ITipoImovel';

@Injectable({
  providedIn: 'root'
})
export class TipoImovelService {

  apiUrl: string = environment.apiUrl + '/imovel/tipo';

  constructor(private http: HttpClient) { }

  obterTodos(): Observable<ITipoImovel[]> {
    return this.http.get<ITipoImovel[]>(this.apiUrl);
  }
}
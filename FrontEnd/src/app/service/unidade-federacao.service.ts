import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { UnidadeFederacao } from '../interfaces/unidade-federacao.interface';

@Injectable({
  providedIn: 'root'
})
export class UnidadeFederacaoService {

  apiUrl: string = environment.apiUrl + '/UnidadeFederacao';

  constructor(private http: HttpClient) { }

  criar(unidadeFederacao: UnidadeFederacao) : Observable<number>{
    return this.http.post<number>(this.apiUrl, unidadeFederacao);
  }

  // obterTodas() : Observable<Categoria[]> {
  //   return this.http.get<Categoria[]>(this.apiUrl);
  // }
}

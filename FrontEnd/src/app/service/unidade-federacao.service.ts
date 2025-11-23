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

  criar(unidadeFederacao: UnidadeFederacao): Observable<number> {
    return this.http.post<number>(this.apiUrl, unidadeFederacao);
  }

  editar(unidadeFederacao: UnidadeFederacao): Observable<boolean> {
    return this.http.put<boolean>(`${this.apiUrl}/${unidadeFederacao.id}`, unidadeFederacao);
  }

  obterTodas(): Observable<UnidadeFederacao[]> {
    return this.http.get<UnidadeFederacao[]>(this.apiUrl);
  }

  obterUma(id: number): Observable<UnidadeFederacao> {
    return this.http.get<UnidadeFederacao>(`${this.apiUrl}/${id}`);
  }

  excluir(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${id}`);
  }
}
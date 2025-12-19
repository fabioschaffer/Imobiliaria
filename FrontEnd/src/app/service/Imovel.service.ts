import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { UnidadeFederacao } from '../interfaces/unidade-federacao.interface';
import { IImovel, IImovelPaginacao } from '../interfaces/IImovel';

@Injectable({
  providedIn: 'root'
})
export class ImovelService {

  apiUrl: string = environment.apiUrl + '/Imovel';

  constructor(private http: HttpClient) { }

  criar(imovel: IImovel): Observable<number> {
    return this.http.post<number>(this.apiUrl, imovel);
  }

  editar(imovel: IImovel): Observable<boolean> {
    return this.http.put<boolean>(`${this.apiUrl}/${imovel.id}`, imovel);
  }

  obterTodos(pagina: number): Observable<IImovelPaginacao[]> {
    return this.http.get<IImovelPaginacao[]>(`${this.apiUrl}?pagina=${pagina}`);
  }

  obterUm(id: number): Observable<IImovel> {
    return this.http.get<IImovel>(`${this.apiUrl}/${id}`);
  }

  excluir(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${id}`);
  }
}
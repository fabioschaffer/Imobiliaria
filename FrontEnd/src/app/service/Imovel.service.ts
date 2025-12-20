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

  obter(
    pagina: number,
    quartos?: number,
    valorinicial?: number,
    valorfinal?: number
  ): Observable<IImovelPaginacao[]> {
    let params = `?pagina=${pagina}`;
    if (quartos !== undefined) {
      params += `&quartos=${quartos}`;
    }
    if (valorinicial !== undefined) {
      params += `&valorinicial=${valorinicial}`;
    }
    if (valorfinal !== undefined) {
      params += `&valorfinal=${valorfinal}`;
    }
    return this.http.get<IImovelPaginacao[]>(`${this.apiUrl}${params}`);
  }

  obterUm(id: number): Observable<IImovel> {
    return this.http.get<IImovel>(`${this.apiUrl}/${id}`);
  }

  excluir(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${id}`);
  }
}
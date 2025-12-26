import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ImovelService } from '../service/Imovel.service';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { IImovel, IImovelPaginacao } from '../interfaces/IImovel';
import { PaginacaoComponent } from '../../Componentes/Paginacao/paginacao.component';
import { LINHAS_POR_PAGINA } from '../../Componentes/Paginacao/paginacao.configuracao';
import { DuasDecimaisDirective } from '../../Diretivas/duas-decimais.diretiva';
import { somenteNumerosDirective } from '../../Diretivas/somente-numeros.diretiva';

@Component({
  selector: 'app-pesquisa-imovel.component',
  imports: [ReactiveFormsModule, CommonModule, PaginacaoComponent, DuasDecimaisDirective, somenteNumerosDirective],
  templateUrl: './pesquisa-imovel.component.html',
  styleUrl: './pesquisa-imovel.component.scss',
  standalone: true,
})
export class PesquisaImovelComponent {

  Imovel: IImovelPaginacao[] = [];
  loading: boolean = false;
  pesquisaRealizada: boolean = false;

  filtrosForm: FormGroup;

  constructor(
    private ImovelService: ImovelService,
    private cdr: ChangeDetectorRef,
    private router: Router
  ) {

    this.filtrosForm = new FormGroup({
      quartos: new FormControl(''),
      valorInicial: new FormControl(''),
      valorFinal: new FormControl('')
    });


  }

  ngOnInit(): void {
    //this.carregarImoveis();
  }

  carregarImoveis(pagina: number = 1): void {
    this.loading = true;
    const { quartos, valorInicial, valorFinal } = this.filtrosForm.value;
    this.ImovelService.obter(pagina, quartos, valorInicial, valorFinal).subscribe({
      next: (ufs) => {
        this.Imovel = ufs;
        this.totalLinhas = ufs[0]?.totalLinhas || 0;
        this.totalPaginas = Math.ceil(this.totalLinhas / LINHAS_POR_PAGINA);
        this.loading = false;
        this.pesquisaRealizada = true;
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.loading = false;
        console.error(err);
      },
    });
  }

  Novo() {
    this.router.navigate(['interno/imovel/cadastro']);
  }

  Editar(id: number) {
    this.router.navigate(['interno/imovel/cadastro'], { queryParams: { imovelId: id, visualizacao: true } });
  }

  Excluir(imovel: IImovel) {
    const confirmado = window.confirm(`Tem certeza que deseja excluir ID "${imovel.id}"?`);
    if (!confirmado) return;

    this.ImovelService.excluir(imovel.id).subscribe({
      next: () => {
        alert('Excluído com sucesso!');
        this.carregarImoveis();
      },
      error: (err) => {
        console.error(err);
        alert('Erro ao excluir');
      },
    });
  }

  totalLinhas = 100;
  totalPaginas = Math.ceil(this.totalLinhas / LINHAS_POR_PAGINA);
  paginaAtual = 1;

  onPageChange(pagina: number): void {
    this.paginaAtual = pagina;
    this.carregarDados();
  }

  carregarDados(): void {
    this.carregarImoveis(this.paginaAtual);
  }
  // irParaLogin() {
  //   this.router.navigate(['/login']);
  // }
}

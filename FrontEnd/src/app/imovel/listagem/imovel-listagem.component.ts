import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ImovelService } from '../../service/Imovel.service';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { IImovel } from '../../interfaces/IImovel';
import { PaginacaoComponent } from "../../../Componentes/Paginacao/paginacao.component";

@Component({
  selector: 'app-imovel-listagem.component',
  templateUrl: './imovel-listagem.component.html',
  styleUrl: './imovel-listagem.component.scss',
    standalone: true,
  imports: [ReactiveFormsModule, CommonModule, PaginacaoComponent],
})
export class ImovelListagemComponent {
  Imovel: IImovel[] = [];
  loading: boolean = false;

  constructor(
    private ImovelService: ImovelService,
    private cdr: ChangeDetectorRef,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.carregarLista();
  }

  carregarLista() {
    this.loading = true;
    this.ImovelService.obterTodos()
      .subscribe({
        next: (ufs) => {
          this.Imovel = ufs;
          this.loading = false;
          this.cdr.detectChanges();
        },
        error: (err) => {
          this.loading = false;
          console.error(err);
        }
      });
  }

  Novo() {
    this.router.navigate(['/imovel/cadastro']);
  }

  Editar(id: number) {
    this.router.navigate(
      ['/imovel/cadastro'],
      { queryParams: { imovelId: id } }
    );

  }

  Excluir(imovel: IImovel) {

    const confirmado = window.confirm(
      `Tem certeza que deseja excluir ID "${imovel.id}"?`
    );

    if (!confirmado) return;

    this.ImovelService.excluir(imovel.id).subscribe({
      next: () => {
        alert('Excluído com sucesso!');
        this.carregarLista();
      },
      error: err => {
        console.error(err);
        alert('Erro ao excluir');
      }
    });

  }


  currentPage = 1;
  totalPages = 50;

  onPageChange(page: number): void {
    this.currentPage = page;
    this.carregarDados();
  }

  carregarDados(): void {
    console.log('Página atual:', this.currentPage);
    // chamada à API:
    // GET /items?page=this.currentPage
  }

}
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UnidadeFederacaoService } from '../../service/unidade-federacao.service';
import { UnidadeFederacao } from '../../interfaces/unidade-federacao.interface';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-unidade-federacao-listagem.component',
  templateUrl: './unidade-federacao-listagem.component.html',
  styleUrl: './unidade-federacao-listagem.component.scss',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
})
export class UnidadeFederacaoListagemComponent {
  unidadesFederacao: UnidadeFederacao[] = [];

  constructor(
    private unidadeFederacaoService: UnidadeFederacaoService,
    private cdr: ChangeDetectorRef,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.carregarLista();
  }

  carregarLista() {
    this.unidadeFederacaoService.obterTodas()
      .subscribe(ufs => {
        console.log(ufs);
        this.unidadesFederacao = ufs;
        this.cdr.detectChanges();
      });

  }

  Novo() {
    this.router.navigate(['/unidadefederacaocadastro']);
  }

  Editar(id: number) {
    this.router.navigate(
      ['/unidadefederacaocadastro'],
      { queryParams: { id: id } }
    );

  }

  Excluir(uf: UnidadeFederacao) {

    const confirmado = window.confirm(
      `Tem certeza que deseja excluir "${uf.nome}"?`
    );

    if (!confirmado) return;

    this.unidadeFederacaoService.excluir(uf.id).subscribe({
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

}
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ImovelService } from '../../service/Imovel.service';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { IImovel } from '../../interfaces/IImovel';

@Component({
  selector: 'app-imovel-listagem.component',
  templateUrl: './imovel-listagem.component.html',
  styleUrl: './imovel-listagem.component.scss',
    standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
})
export class ImovelListagemComponent {
  Imovel: IImovel[] = [];

  constructor(
    private ImovelService: ImovelService,
    private cdr: ChangeDetectorRef,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.carregarLista();
  }

  carregarLista() {
    this.ImovelService.obterTodos()
      .subscribe(ufs => {
        console.log(ufs);
        this.Imovel = ufs;
        this.cdr.detectChanges();
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

}
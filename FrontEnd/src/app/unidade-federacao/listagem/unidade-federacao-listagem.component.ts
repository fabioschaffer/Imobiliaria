import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UnidadeFederacaoService } from '../../service/unidade-federacao.service';
import { UnidadeFederacao } from '../../interfaces/unidade-federacao.interface';
import { CommonModule } from '@angular/common';

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
    private unidadeFederacaoService: UnidadeFederacaoService
  ) { }

  ngOnInit(): void {
    this.unidadeFederacaoService.obterTodas()
      .subscribe(ufs => {
        console.log(ufs);
        return this.unidadesFederacao = ufs;
      });
  }
}
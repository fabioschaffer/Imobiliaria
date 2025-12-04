import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { somenteNumerosDirective } from '../../../Diretivas/somente-numeros.diretiva';
import { DuasDecimaisDirective } from '../../../Diretivas/duas-decimais.diretiva';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'imovel-cadastro.component',
  standalone: true,
  imports: [ReactiveFormsModule, somenteNumerosDirective, DuasDecimaisDirective, CommonModule],
  templateUrl: './imovel-cadastro.component.html',
  styleUrl: './imovel-cadastro.component.scss',
})
export class ImovelCadastroComponent {
  dadosIniciaisForm: FormGroup;

  caracteristicas: { descricao: string; valor: number }[] = [
    { descricao: 'Item 1', valor: 100 },
    { descricao: 'Item 2', valor: 200 },
    { descricao: 'Item 3', valor: 300 }
  ];

  constructor() {
    this.dadosIniciaisForm = new FormGroup({
      tipo: new FormControl('', Validators.required),
      area: new FormControl('', Validators.required),
      quartos: new FormControl('', Validators.required),
      vagasGaragem: new FormControl('', Validators.required),
      valor: new FormControl('', Validators.required),
    });
  }


}
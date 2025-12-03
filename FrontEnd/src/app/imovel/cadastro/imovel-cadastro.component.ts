import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'imovel-cadastro.component',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './imovel-cadastro.component.html',
  styleUrl: './imovel-cadastro.component.scss',
})
export class ImovelCadastroComponent {
  dadosIniciaisForm: FormGroup;

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
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UnidadeFederacaoService } from '../../service/unidade-federacao.service';

@Component({
  selector: 'app-unidade-federacao-cadastro.component',
  templateUrl: './unidade-federacao-cadastro.component.html',
  styleUrl: './unidade-federacao-cadastro.component.scss',
  standalone: true,
  imports: [ReactiveFormsModule],
})
export class UnidadeFederacaoCadastroComponent {

  camposForm: FormGroup;

  constructor(private service: UnidadeFederacaoService) {
    this.camposForm = new FormGroup({
      nome: new FormControl('', Validators.required),
    });
  }

  salvar() {
    this.camposForm.markAllAsTouched();

    if (this.camposForm.valid) {
      this.service
        .criar(this.camposForm.value)
        .subscribe({
          next: categoria => {
            console.log('Salva com sucesso!', categoria);
            this.camposForm.reset();
          },
          error: erro => console.error('Ocorreu um erro: ', erro)
        });
    }
  }

}

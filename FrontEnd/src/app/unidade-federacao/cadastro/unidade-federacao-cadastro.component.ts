import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UnidadeFederacaoService } from '../../service/unidade-federacao.service';
import { ActivatedRoute } from '@angular/router';
import { UnidadeFederacao } from '../../interfaces/unidade-federacao.interface';

@Component({
  selector: 'app-unidade-federacao-cadastro.component',
  templateUrl: './unidade-federacao-cadastro.component.html',
  styleUrl: './unidade-federacao-cadastro.component.scss',
  standalone: true,
  imports: [ReactiveFormsModule],
})
export class UnidadeFederacaoCadastroComponent {

  id: number | null = null;

  camposForm: FormGroup;

  constructor(private service: UnidadeFederacaoService, private route: ActivatedRoute) {
    this.camposForm = new FormGroup({
      nome: new FormControl('', Validators.required),
    });
  }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.id = params['id'];

      if (this.id != null) {
        this.service.obterUma(this.id)
          .subscribe(uf => {
            this.camposForm.patchValue({
              nome: uf.nome,
            });
          });

      }

    });
  }

  salvar() {
    this.camposForm.markAllAsTouched();

    if (this.camposForm.valid) {

      let uf: UnidadeFederacao = {
        id: this.id ?? 0,
        nome: this.camposForm.value.nome,
      };

      if (this.id == null) {

        this.service
          .criar(uf)
          .subscribe({
            next: categoria => {

              alert('Criado com sucesso!');


              this.camposForm.reset();
            },
            error: erro => console.error('Ocorreu um erro: ', erro)
          });
      } else {

        this.service
          .editar(uf)
          .subscribe({
            next: sucesso => {

              alert('Alterado com sucesso!');

              this.camposForm.reset();
            },
            error: erro => console.error('Ocorreu um erro: ', erro)
          });

      }

    }
  }

}

import { ChangeDetectorRef, Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { somenteNumerosDirective } from '../../../Diretivas/somente-numeros.diretiva';
import { DuasDecimaisDirective } from '../../../Diretivas/duas-decimais.diretiva';
import { CommonModule } from '@angular/common';
import { ICaracteristica } from '../../interfaces/ICaracteristica';
import { CaracteristicaService } from '../../service/caracteristica.service';
import { ActivatedRoute, Router } from '@angular/router';
import { TipoImovelService } from '../../service/tipo-imovel.service';
import { ITipoImovel } from '../../interfaces/ITipoImovel';
import { IImovel } from '../../interfaces/IImovel';
import { ImovelService } from '../../service/Imovel.service';
import { ToastComponent } from "../../../Componentes/Toast/toast.component";
import { ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'imovel-cadastro.component',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule, somenteNumerosDirective, DuasDecimaisDirective, CommonModule, ToastComponent],
  templateUrl: './imovel-cadastro.component.html',
  styleUrl: './imovel-cadastro.component.scss',
})
export class ImovelCadastroComponent {
  imovelId: number | null = null;

  @ViewChild(ToastComponent) toast!: ToastComponent;

  public Math = Math;
  dadosIniciaisForm: FormGroup;

  caracteristicas: ICaracteristica[] = [];
  tiposImovel: ITipoImovel[] = [];

  constructor(
    private imovelService: ImovelService,
    private caracteristicaService: CaracteristicaService,
    private tipoImovelService: TipoImovelService,
    private cdr: ChangeDetectorRef,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.dadosIniciaisForm = new FormGroup({
      tipo: new FormControl('', Validators.required),
      area: new FormControl('', Validators.required),
      quartos: new FormControl('', Validators.required),
      vagasGaragem: new FormControl('', Validators.required),
      valor: new FormControl('', Validators.required),
    });
  }

  ngOnInit(): void {
    this.carregarCaracteristicas();
    this.carregarTiposImovel();
  }

  carregarCaracteristicas() {
    this.caracteristicaService.obterTodas()
      .subscribe(caracteristicas => {
        this.caracteristicas = caracteristicas;
        this.cdr.detectChanges();
      });
  }

  carregarTiposImovel() {
    this.tipoImovelService.obterTodos()
      .subscribe(tiposImovel => {
        this.tiposImovel = tiposImovel;
        this.cdr.detectChanges();
      });
  }

  carregarImovel() {

    //TODO: Concluir método de carregar imóvel para edição.

    this.route.queryParams.subscribe(params => {
      this.imovelId = params['imovelId'];

      if (this.imovelId != null) {
        this.imovelService.obterUma(this.imovelId)
          .subscribe(uf => {
            this.dadosIniciaisForm.patchValue({
              //nome: uf.nome,
            });
          });
      }
    });
  }

  Salvar() {

    const selecionadas = this.caracteristicas.filter(c => c.selecionado);
    console.log(selecionadas);
    return;


    this.toast.show('Salvando... Aguarde!');

    this.dadosIniciaisForm.markAllAsTouched();

    if (this.dadosIniciaisForm.valid) {

      let imovel: IImovel = {
        id: this.imovelId ?? 0,
        tipoImovel: Number(this.dadosIniciaisForm.value.tipo),
        area: Number(this.dadosIniciaisForm.value.area),
        quartos: Number(this.dadosIniciaisForm.value.quartos),
        vagasGaragem: Number(this.dadosIniciaisForm.value.vagasGaragem),
        valor: Number(this.dadosIniciaisForm.value.valor),
        caracteristicas: [], // You might want to populate this based on your form or other logic
      };

      if (this.imovelId == null) {
        this.imovelService
          .criar(imovel)
          .subscribe({
            next: imovelCriado => {

              //alert('Criado com sucesso!');
              this.toast.show('Imóvel criado com sucesso!');


              this.dadosIniciaisForm.reset();
            },
            error: erro => console.error('Ocorreu um erro: ', erro)
          });
      } else {
        this.imovelService
          .editar(imovel)
          .subscribe({
            next: sucesso => {

              alert('Alterado com sucesso!');

              this.dadosIniciaisForm.reset();
            },
            error: erro => console.error('Ocorreu um erro: ', erro)
          });

      }

    }
  }

}
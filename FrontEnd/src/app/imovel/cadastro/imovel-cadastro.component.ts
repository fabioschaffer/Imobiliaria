import { ChangeDetectorRef, Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { somenteNumerosDirective } from '../../../Diretivas/somente-numeros.diretiva';
import { DuasDecimaisDirective } from '../../../Diretivas/duas-decimais.diretiva';
import { CommonModule } from '@angular/common';
import { CaracteristicaService } from '../../service/caracteristica.service';
import { ActivatedRoute, Router } from '@angular/router';
import { TipoImovelService } from '../../service/tipo-imovel.service';
import { ITipoImovel } from '../../interfaces/ITipoImovel';
import { IImovel } from '../../interfaces/IImovel';
import { ImovelService } from '../../service/Imovel.service';
import { ToastComponent } from "../../../Componentes/Toast/toast.component";
import { ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IImovelCaracteristica } from '../../interfaces/IImovelCaracteristica';

@Component({
  selector: 'imovel-cadastro.component',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule, somenteNumerosDirective, DuasDecimaisDirective, CommonModule, ToastComponent],
  templateUrl: './imovel-cadastro.component.html',
  styleUrl: './imovel-cadastro.component.scss',
})
export class ImovelCadastroComponent {
  getTitulo() {
    if (this.visualizando) {
      return 'Imóvel - Visualização';
    } else if (this.imovelId != null) {
      return 'Imóvel - Edição';
    } else {
      return 'Imóvel - Inclusão';
    }
  }
  imovelId: number | null = null;
  visualizando: boolean = false;

  @ViewChild(ToastComponent) toast!: ToastComponent;

  public Math = Math;
  dadosIniciaisForm: FormGroup;

  caracteristicas: IImovelCaracteristica[] = [];
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
    this.carregarTiposImovel();
    this.carregarImovel();
    if (this.visualizando) {
      this.dadosIniciaisForm.disable();
    }
  }

  carregarCaracteristicas(selecionadas: IImovelCaracteristica[]) {
    this.caracteristicaService.obterTodas()
      .subscribe(caracteristicas => {
        caracteristicas.forEach(element => {
          const selecionado = selecionadas.find(s => s.caracteristicaId === element.id);
          this.caracteristicas.push({
            imovelCaracteristicaId: selecionado?.imovelCaracteristicaId ?? 0,
            caracteristicaId: element.id,
            descricao: element.descricao,
            acao: 0,
            selecionado: selecionado != undefined
          });
        });
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
    this.route.queryParams.subscribe(params => {
      this.imovelId = params['imovelId'];
      this.visualizando = params['visualizacao'] === 'true';
      this.cdr.detectChanges();
      if (this.imovelId != null) {
        this.imovelService.obterUm(this.imovelId)
          .subscribe(imovel => {
            console.log('imovel', imovel);
            this.dadosIniciaisForm.patchValue({
              tipo: imovel.tipoImovel.toString(),
              area: imovel.area,
              quartos: imovel.quartos,
              vagasGaragem: imovel.vagasGaragem,
              valor: imovel.valor
            });
            this.carregarCaracteristicas(imovel.caracteristicas);
          });
      }
      else {
        this.carregarCaracteristicas([]);
      }
    });
  }

  Salvar() {
    this.toast.show('Salvando... Aguarde!');
    this.dadosIniciaisForm.markAllAsTouched();
    if (this.dadosIniciaisForm.valid) {
      let imovel: IImovel = {
        id: Number(this.imovelId ?? 0),
        tipoImovel: Number(this.dadosIniciaisForm.value.tipo),
        area: Number(this.dadosIniciaisForm.value.area),
        quartos: Number(this.dadosIniciaisForm.value.quartos),
        vagasGaragem: Number(this.dadosIniciaisForm.value.vagasGaragem),
        valor: Number(this.dadosIniciaisForm.value.valor),
        caracteristicas: this.caracteristicas.map(c => ({
          imovelCaracteristicaId: c.imovelCaracteristicaId,
          caracteristicaId: c.caracteristicaId,
          descricao: c.descricao,
          acao: (c.selecionado && c.imovelCaracteristicaId == 0) ? 1 :
            (!c.selecionado && c.imovelCaracteristicaId > 0) ? 3 :
              0,
        } as IImovelCaracteristica))
      };

      if (this.imovelId == null) {
        this.imovelService
          .criar(imovel)
          .subscribe({
            next: imovelCriado => {
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
              this.toast.show('Imóvel alterado com sucesso!');
            },
            error: erro => console.error('Ocorreu um erro: ', erro)
          });

      }

    }
  }

}
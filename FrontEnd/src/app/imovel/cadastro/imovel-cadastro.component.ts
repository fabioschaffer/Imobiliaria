import { ChangeDetectorRef, Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { somenteNumerosDirective } from '../../../Diretivas/somente-numeros.diretiva';
import { DuasDecimaisDirective } from '../../../Diretivas/duas-decimais.diretiva';
import { CommonModule } from '@angular/common';
import { ICaracteristica } from '../../interfaces/ICaracteristica';
import { CaracteristicaService } from '../../service/caracteristica.service';
import { Router } from '@angular/router';

@Component({
  selector: 'imovel-cadastro.component',
  standalone: true,
  imports: [ReactiveFormsModule, somenteNumerosDirective, DuasDecimaisDirective, CommonModule],
  templateUrl: './imovel-cadastro.component.html',
  styleUrl: './imovel-cadastro.component.scss',
})
export class ImovelCadastroComponent {
  public Math = Math;
  dadosIniciaisForm: FormGroup;

  caracteristicas: ICaracteristica[] = [];

  constructor(private caracteristicaService: CaracteristicaService,
    private cdr: ChangeDetectorRef,
    private router: Router
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
    this.carregarLista();
  }

  carregarLista() {
    this.caracteristicaService.obterTodas()
      .subscribe(caracteristicas => {
        console.log(caracteristicas);
        this.caracteristicas = caracteristicas;
        this.cdr.detectChanges();
      });

  }

}
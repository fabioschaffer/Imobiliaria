import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pesquisa-imovel.component',
  imports: [],
  templateUrl: './pesquisa-imovel.component.html',
  styleUrl: './pesquisa-imovel.component.scss',
})
export class PesquisaImovelComponent {

  constructor(private router: Router) { }

  irParaLogin() {
    this.router.navigate(['/login']);
  }
}

import { Component, signal } from '@angular/core';
import { RouterOutlet, RouterLink, Router } from '@angular/router';
import { AuthService } from '../../../security/auth.service';

@Component({
  selector: 'app-inicial.component',
  imports: [RouterOutlet, RouterLink],
  templateUrl: './inicial.component.html',
  styleUrl: './inicial.component.scss',
})
export class InicialComponent {
  protected readonly title = signal('FrontEnd');

  constructor(private router: Router, private authService: AuthService) {
  }


  LogOut() {
    this.authService.logout();
    this.router.navigate(['/externo/pesquisa-imovel']);
  }

}

import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login.component',
  imports: [],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  constructor(private router: Router) { }

  entrar() {
    // aqui depois você pode validar login/token
    this.router.navigate(['/interno/inicial']);
  }
}

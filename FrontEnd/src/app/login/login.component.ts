import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../security/auth.service';

@Component({
  selector: 'app-login.component',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  standalone: true,
  imports: [ReactiveFormsModule],
})
export class LoginComponent {

  camposForm: FormGroup;


  constructor(private router: Router, private authService: AuthService) {
    this.camposForm = new FormGroup({
      login: new FormControl('', Validators.required),
      senha: new FormControl('', Validators.required),
    });
  }

  entrar() {
    this.authService.login(this.camposForm.value.login, this.camposForm.value.senha)
      .subscribe({
        next: () => this.router.navigate(['/interno/inicial']),
        error: () => alert('Login inválido')
      });
  }

}
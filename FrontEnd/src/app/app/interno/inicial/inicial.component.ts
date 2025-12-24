import { Component, signal } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';

@Component({
  selector: 'app-inicial.component',
  imports: [RouterOutlet, RouterLink],
  templateUrl: './inicial.component.html',
  styleUrl: './inicial.component.scss',
})
export class InicialComponent {
  protected readonly title = signal('FrontEnd');
}

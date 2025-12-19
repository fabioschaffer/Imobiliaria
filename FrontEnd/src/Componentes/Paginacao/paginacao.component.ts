import { CommonModule } from '@angular/common';
import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-paginacao',
  templateUrl: './paginacao.component.html',
  styleUrls: ['./paginacao.component.scss'],
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
})
export class PaginacaoComponent implements OnChanges {
  @Input() totalPaginas = 0;
  @Input() paginaAtual = 1;
  @Input() maximoPaginasVisiveis = 5;

  @Output() pageChange = new EventEmitter<number>();

  pages: number[] = [];

  ngOnChanges(): void {
    this.buildPages();
  }

  private buildPages(): void {
    const half = Math.floor(this.maximoPaginasVisiveis / 2);
    let start = Math.max(1, this.paginaAtual - half);
    let end = Math.min(this.totalPaginas, start + this.maximoPaginasVisiveis - 1);

    if (end - start + 1 < this.maximoPaginasVisiveis) {
      start = Math.max(1, end - this.maximoPaginasVisiveis + 1);
    }

    this.pages = [];
    for (let i = start; i <= end; i++) {
      this.pages.push(i);
    }
  }

  goTo(page: number): void {
    if (page < 1 || page > this.totalPaginas || page === this.paginaAtual) {
      return;
    }
    this.pageChange.emit(page);
  }
}
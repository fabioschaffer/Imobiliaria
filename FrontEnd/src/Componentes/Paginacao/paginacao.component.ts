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

  @Input() totalPages = 0;
  @Input() currentPage = 1;
  @Input() maxVisiblePages = 5;

  @Output() pageChange = new EventEmitter<number>();

  pages: number[] = [];

  ngOnChanges(): void {
    this.buildPages();
  }

  private buildPages(): void {
    const half = Math.floor(this.maxVisiblePages / 2);
    let start = Math.max(1, this.currentPage - half);
    let end = Math.min(this.totalPages, start + this.maxVisiblePages - 1);

    if (end - start + 1 < this.maxVisiblePages) {
      start = Math.max(1, end - this.maxVisiblePages + 1);
    }

    this.pages = [];
    for (let i = start; i <= end; i++) {
      this.pages.push(i);
    }
  }

  goTo(page: number): void {
    if (page < 1 || page > this.totalPages || page === this.currentPage) {
      return;
    }
    this.pageChange.emit(page);
  }
}

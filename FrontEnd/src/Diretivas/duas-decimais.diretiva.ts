import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
    selector: '[duasDecimais]'
})
export class DuasDecimaisDirective {

    constructor(private el: ElementRef) { }

    @HostListener('keypress', ['$event'])
    onKeyPress(event: KeyboardEvent) {
        const char = event.key;
        const value = this.el.nativeElement.value;

        if (!/^[0-9,.]$/.test(char)) {
            event.preventDefault();
        }

        // Permitir apenas um ponto
        if (char === '.' && value.includes('.')) {
            event.preventDefault();
            return;
        }

        // Permitir apenas uma vírgula
        if (char === ',' && value.includes(',')) {
            event.preventDefault();
            return;
        }
    }

    @HostListener('blur')
    onBlur() {
        let value = this.el.nativeElement.value;
        if (value) {
            let retorno = this.formatNumber(value);
            this.el.nativeElement.value = retorno;
        }
    }

    private formatNumber(value: string | number): string {
        let valueAsNumber = typeof value === 'string' ? parseFloat(value.replace('.', '').replace(',', '.')) : value;
        let formatado = new Intl.NumberFormat('pt-BR', {
            minimumFractionDigits: 2,
            maximumFractionDigits: 2
        }).format(valueAsNumber);
        return formatado;
    }


}
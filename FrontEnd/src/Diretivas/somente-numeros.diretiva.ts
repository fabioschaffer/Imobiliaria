import { Directive, HostListener } from '@angular/core';

@Directive({
    selector: '[somenteNumeros]'
})
export class somenteNumerosDirective {

    @HostListener('keypress', ['$event'])
    onKeyPress(event: KeyboardEvent) {
        const char = event.key;

        if (!/^[0-9]$/.test(char)) {
            event.preventDefault();
        }
    }
}
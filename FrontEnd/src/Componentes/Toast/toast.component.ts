import { ChangeDetectorRef, Component } from '@angular/core';

@Component({
    selector: 'app-toast',
    templateUrl: 'toast.component.html',
    styleUrls: ['toast.component.scss']
})
export class ToastComponent {

    public message = '';
    public visible = false;

    constructor(private cdr: ChangeDetectorRef) { }

    show(message: string) {
        this.message = message;
        this.visible = true;
        this.cdr.detectChanges();

        setTimeout(() => {
            this.visible = false;
            this.cdr.detectChanges();
        }, 3000); // fecha sozinho
    }
}

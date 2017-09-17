import { Component, ElementRef, Renderer  } from '@angular/core';
import { NotesDataService } from './notes.data.service'
import { Router } from '@angular/router';

export class NewNoteItemModel {
    constructor(public title: string, text: any, lifetime: string) {}
}

@Component({
    selector: 'new-note-form',
    templateUrl: './new-note.component.html',
    providers: [NotesDataService],
    styles: [`
        input.ng-touched.ng-invalid {border:solid red 2px;}
        input.ng-touched.ng-valid {border:solid green 2px;}
    `]
})
export class NewNoteComponent {
    lifetimeitems: string[] = ["Never", "10 minutes", "1 hour", "1 day", "1 week", "1 month"];
    _errorMessage: string;
    _hasErrors: boolean = false;

    constructor(private _notesDataService: NotesDataService,
        private router: Router,
        private el: ElementRef,
        private renderer: Renderer) {
    }

    htmlEntities(str: any) {
        return String(str).replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
    }

    addNote(title: string, noteText: string, lifetime: string) {
        var model = { title: title, noteText : noteText, lifetime:lifetime };
        this._notesDataService.post(model).subscribe(data => {
            this._hasErrors = false;
            this._errorMessage = "";
            this.router.navigate(['./notes']);
        }, error => {
            this._hasErrors = true;
            this._errorMessage = error._body;
            console.info(error);
        });
    }
}
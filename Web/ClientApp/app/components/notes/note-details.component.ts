import { Component, OnInit } from '@angular/core';
import { NotesDataService } from './notes.data.service'
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

export class NoteDetailsItemModel {
    constructor(public id: string, public title: string, public text: string, public lifetime: string, public createDateTime: string) {}
}

@Component({
    selector: 'note-details',
    templateUrl: './note-details.component.html',
    providers: [NotesDataService],
    styles: [
        `
        input.ng-touched.ng-invalid {border:solid red 2px;}
        input.ng-touched.ng-valid {border:solid green 2px;}
    `
    ]
})
export class NoteDetailsComponent implements OnInit {
    _loadedNote: NoteDetailsItemModel;

    lifetimeitems: string[] = ["Never", "10 minutes", "1 hour", "1 day", "1 week", "1 month"];
    _errorMessage: string;
    _hasErrors: boolean = false;

    constructor(private _notesDataService: NotesDataService, private route: ActivatedRoute, private router: Router) {}

    ngOnInit() {
        this.route.params.subscribe(params => {
            let id = params['id'];
            this.loadNote(id);
        });
    }

    loadNote(id: string) {
        this._notesDataService.getById(id)
            .subscribe(note => {
                    this._loadedNote =
                    new NoteDetailsItemModel(note.id, note.title, note.text, note.lifetime, note.createDateTime);
                },
                error => {
                    console.error(error);
                    this.router.navigate(['./page-not-found']);
                });
    }
}
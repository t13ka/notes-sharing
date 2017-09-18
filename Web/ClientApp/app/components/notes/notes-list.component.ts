import { Component, Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Headers, Http } from '@angular/http';
import { NoteItemModel } from '../models/NoteItemModel';
import { NotesDataService } from './notes.data.service'

@Component({
    selector: 'notes-list',
    templateUrl: './notes-list.component.html',
    //styleUrls: ['./notes-list.component.css'],
    providers: [NotesDataService]
})
@Injectable()
export class NotesListComponent implements OnInit {
    _notesCollection: NoteItemModel[];
    _http: Http;
    _baseUrl: string;
    _errorMessage: string;
    _hasErrors: boolean = false;

    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private _notesDataService: NotesDataService, private router: Router) {}

    ngOnInit() {
        this.loadNotes();
    }

    loadNotes(): void {
        this._notesDataService.getAll()
            .subscribe(notes => {
                this._notesCollection = notes;
            }, error => {
                this._hasErrors = true;
                this._errorMessage = "There was an error performing the request.";
                console.error(error);
            });
    }

    newNote() {
        this.router.navigate(['./new-note']);
    }
}
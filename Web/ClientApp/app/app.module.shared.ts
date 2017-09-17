import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { NotesListComponent } from './components/notes/notes-list.component';
import { NewNoteComponent } from './components/notes/new-note.component';
import { NoteDetailsComponent } from './components/notes/note-details.component';
import { PageNotFoundComponent } from './components/notes/page-not-found.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        NotesListComponent,
        NewNoteComponent,
        NoteDetailsComponent,
        PageNotFoundComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        BrowserModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'notes', pathMatch: 'full' },
            { path: 'notes', component: NotesListComponent },
            { path: 'new-note', component: NewNoteComponent },
            { path: 'notes/:title', component: NoteDetailsComponent },
            { path: 'page-not-found', component: PageNotFoundComponent },
            { path: '**', component: PageNotFoundComponent }
        ])
    ],
})
export class AppModuleShared {
}

import { Injectable, Inject } from '@angular/core';
import { Headers, Http, Response, RequestOptions} from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { NoteItemModel } from '../models/NoteItemModel';


@Injectable()
export class NotesDataService{
    private _notesCollection: NoteItemModel[];
    private _http: Http;
    private _baseUrl: string;
    private _url: string;

    private _headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this._http = http;
        this._baseUrl = baseUrl;
        this._url = this._baseUrl + "api/notes";
    }

    getAll(): Observable<any> {
        return this._http.get(this._url)
            .map((response: Response) => <any>response.json() as NoteItemModel[])
            //.do(data => console.log(JSON.stringify(data)))
            .catch(this.handleError);
    }

    getById(id: string): Observable<any> {
        var url = this._url + "/" + id;

        return this._http.get(url)
            .map((response: Response) => <any>response.json() as NoteItemModel)
            .catch(this.handleError);
    }

    post(model: any): Observable<any> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this._http.post(this._url, model, options)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}
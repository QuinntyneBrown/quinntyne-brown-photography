import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { ContestEntry } from "./contest-entry.model";
import { Observable } from "rxjs";


@Injectable()
export class ContestEntryService {
    constructor(private _http: Http) { }

    public add(entity: ContestEntry) {
        return this._http
            .post(`${this._baseUrl}/api/contestentry/add`, entity)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get() {
        return this._http
            .get(`${this._baseUrl}/api/contestentry/get`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getById(options: { id: number }) {
        return this._http
            .get(`${this._baseUrl}/api/contestentry/getById?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public remove(options: { id: number }) {
        return this._http
            .delete(`${this._baseUrl}/api/contestentry/remove?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get _baseUrl() { return ""; }

}

import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { PollAnswer } from "./poll-answer.model";
import { Observable } from "rxjs";


@Injectable()
export class PollAnswerService {
    constructor(private _http: Http) { }

    public add(entity: PollAnswer) {
        return this._http
            .post(`${this._baseUrl}/api/pollanswer/add`, entity)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get() {
        return this._http
            .get(`${this._baseUrl}/api/pollanswer/get`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getById(options: { id: number }) {
        return this._http
            .get(`${this._baseUrl}/api/pollanswer/getById?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public remove(options: { id: number }) {
        return this._http
            .delete(`${this._baseUrl}/api/pollanswer/remove?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get _baseUrl() { return ""; }

}

import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { PollQuestion } from "./poll-question.model";
import { Observable } from "rxjs";


@Injectable()
export class PollQuestionService {
    constructor(private _http: Http) { }

    public add(entity: PollQuestion) {
        return this._http
            .post(`${this._baseUrl}/api/pollquestion/add`, entity)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get() {
        return this._http
            .get(`${this._baseUrl}/api/pollquestion/get`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getById(options: { id: number }) {
        return this._http
            .get(`${this._baseUrl}/api/pollquestion/getById?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public remove(options: { id: number }) {
        return this._http
            .delete(`${this._baseUrl}/api/pollquestion/remove?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get _baseUrl() { return ""; }

}

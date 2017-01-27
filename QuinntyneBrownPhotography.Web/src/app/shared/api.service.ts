import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { environment } from "../environment";
import { Observable } from "rxjs";

@Injectable()
export class ApiService {
    constructor(private _http: Http) { }

    public getArticleBySlug(options: { slug: string }) {
        return this._http
            .get(`${this._baseUrl}/api/article/getBySlug?slug=${options.slug}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });        
    }

    public login(options: { username: string, password: string }) {
        return this._http
            .post(`${this._baseUrl}/api/token`, options)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }
    
    public get _baseUrl() { return environment.baseUrl; }

}

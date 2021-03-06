import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { DigitalAsset } from "./digital-asset.model";
import { Observable } from "rxjs";


@Injectable()
export class DigitalAssetService {
    constructor(private _http: Http) { }

    public add(entity: DigitalAsset) {
        return this._http
            .post(`${this._baseUrl}/api/digitalasset/add`, entity)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get() {
        return this._http
            .get(`${this._baseUrl}/api/digitalasset/get`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getById(options: { id: number }) {
        return this._http
            .get(`${this._baseUrl}/api/digitalasset/getById?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public remove(options: { id: number }) {
        return this._http
            .delete(`${this._baseUrl}/api/digitalasset/remove?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get _baseUrl() { return ""; }

}

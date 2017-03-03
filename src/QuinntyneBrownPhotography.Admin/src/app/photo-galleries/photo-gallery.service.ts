import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { PhotoGallery } from "./photoGallery.model";
import { Observable } from "rxjs";


@Injectable()
export class PhotoGalleryService {
    constructor(private _http: Http) { }

    public add(entity: PhotoGallery) {
        return this._http
            .post(`${this._baseUrl}/api/photogallery/add`, entity)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get() {
        return this._http
            .get(`${this._baseUrl}/api/photogallery/get`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getById(options: { id: number }) {
        return this._http
            .get(`${this._baseUrl}/api/photogallery/getById?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public remove(options: { id: number }) {
        return this._http
            .delete(`${this._baseUrl}/api/photogallery/remove?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get _baseUrl() { return ""; }

}

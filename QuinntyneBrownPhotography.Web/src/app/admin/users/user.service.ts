import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { User } from "./user.model";
import { Observable } from "rxjs";


@Injectable()
export class UserService {
    constructor(private _http: Http) { }

    public get _baseUrl() { return ""; }

}

﻿import { Injectable } from "@angular/core";

@Injectable()
export class CurrentUserService {
    constructor() { }

    isLoggedIn: boolean;
}
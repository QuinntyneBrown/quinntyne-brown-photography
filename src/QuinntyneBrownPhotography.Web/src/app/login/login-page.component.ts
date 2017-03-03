import { Component, ChangeDetectionStrategy, Input } from "@angular/core";
import { ApiService, Storage } from "../shared";
import { LoginRedirectService } from "./login-redirect.service";

@Component({
    template: require("./login-page.component.html"),
    styles: [require("./login-page.component.scss")],
    selector: "login-page"
})
export class LoginPageComponent {
    constructor(
        private _apiService: ApiService,
        private _loginRedirectService: LoginRedirectService, 
        private _storage: Storage
    ) { }

    public username: string = "";
    public password: string = "";

    public tryToLogin() {
        this._apiService.login({
            username: this.username,
            password: this.password
        }).subscribe((token: any) => {
            if (token) {
                this._storage.put({ name: "token", value: token });
                this._loginRedirectService.redirectPreLogin()
            }
        });
    }
}

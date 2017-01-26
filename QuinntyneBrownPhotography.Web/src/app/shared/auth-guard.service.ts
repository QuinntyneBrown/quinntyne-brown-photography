import { Injectable } from '@angular/core';
import {
    CanActivate,
    CanActivateChild,
    CanLoad,
    Route,
    Router,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
} from '@angular/router';
import { CurrentUserService } from "./current-user.service";

@Injectable()
export class AuthGuardService implements CanActivate, CanActivateChild, CanLoad {
    deniedMessage: string = "Unauthorized Access Denied";

    constructor(
        private _currentUserService: CurrentUserService,
        private _router: Router) {
        
    }

    canLoad(route: Route) {
        return this._currentUserService.isLoggedIn;
    }

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ) {
        return true;
    }

    canActivateChild(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ) {
        return this.canActivate(route, state);
    }


}
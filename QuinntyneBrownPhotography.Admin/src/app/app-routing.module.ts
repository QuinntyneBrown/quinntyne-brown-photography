﻿import { Routes, RouterModule } from '@angular/router';

import { AuthGuardService } from "./shared";

export const routes: Routes = [
    {
        path: '',
        component: null,
    }
];

export const RoutingModule = RouterModule.forRoot([
    ...routes
]);

export const routedComponents = [

];
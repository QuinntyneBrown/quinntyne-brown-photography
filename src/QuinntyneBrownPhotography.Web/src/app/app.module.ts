import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { RouterModule  } from '@angular/router';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import "./rxjs-extensions";

import { SharedModule } from "./shared";

import { AppComponent } from './app.component';
import { AppHeaderComponent } from "./app-header.component";

import {
    RoutingModule,    
    routedComponents
} from "./app-routing.module";

const declarables = [
    AppComponent,
    AppHeaderComponent,
    routedComponents
];


const providers = [

];

@NgModule({
    imports: [
        RoutingModule,
        SharedModule,
        BrowserModule,
        HttpModule,
        CommonModule,
        FormsModule,
        RouterModule
    ],
    providers: providers,
    declarations: [declarables],
    exports: [declarables],
    bootstrap: [AppComponent]
})
export class AppModule { }


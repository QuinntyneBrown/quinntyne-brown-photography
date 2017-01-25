import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { LoginComponent } from './login.component';

const declarables = [LoginComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class LoginModule { }

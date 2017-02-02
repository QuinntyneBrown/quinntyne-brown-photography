import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { TenantsComponent } from './tenants.component';

const declarables = [TenantsComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class TenantsModule { }

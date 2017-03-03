import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { SharedComponent } from './shared.component';

const declarables = [SharedComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class SharedModule { }

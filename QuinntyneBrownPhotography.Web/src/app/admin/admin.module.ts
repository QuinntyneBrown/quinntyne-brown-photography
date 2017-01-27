import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { AdminHeaderComponent } from "./admin-header.component";

const declarables = [
    AdminHeaderComponent
];

const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class AdminModule { }

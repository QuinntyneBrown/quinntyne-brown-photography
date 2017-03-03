import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { ProductPageComponent } from './product-page.component';

const declarables = [ProductPageComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class CatalogModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { SearchComponent } from './search.component';

const declarables = [SearchComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class SearchModule { }

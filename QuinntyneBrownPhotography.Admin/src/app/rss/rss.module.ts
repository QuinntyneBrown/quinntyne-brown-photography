import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { RssComponent } from './rss.component';

const declarables = [RssComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class RssModule { }

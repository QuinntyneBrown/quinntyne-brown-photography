import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { ArticleComponent } from './article.component';

const declarables = [ArticleComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class ArticleModule { }

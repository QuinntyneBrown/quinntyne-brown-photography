import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { PollComponent } from './poll.component';

const declarables = [PollComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class PollModule { }

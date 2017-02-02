import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { UserManagementComponent } from './user-management.component';

const declarables = [UserManagementComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class UserManagementModule { }

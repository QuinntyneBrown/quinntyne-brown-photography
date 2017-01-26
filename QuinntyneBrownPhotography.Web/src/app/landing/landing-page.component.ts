import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { ApiService } from "../shared";

@Component({
    template: require("./landing-page.component.html"),
    styles: [require("./landing-page.component.scss")],
    selector: "landing-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class LandingPageComponent implements OnInit { 
    constructor(private _apiService: ApiService) {

    }

    ngOnInit() {

    }
}

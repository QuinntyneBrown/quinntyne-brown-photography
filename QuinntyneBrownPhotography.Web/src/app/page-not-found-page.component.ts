import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./page-not-found-page.component.html"),
    styles: [require("./page-not-found-page.component.scss")],
    selector: "page-not-found-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class PageNotFoundPageComponent implements OnInit { 
    ngOnInit() {

    }
}

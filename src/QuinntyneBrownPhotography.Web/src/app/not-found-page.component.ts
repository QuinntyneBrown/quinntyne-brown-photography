import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./not-found-page.component.html"),
    styles: [require("./not-found-page.component.scss")],
    selector: "not-found-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class NotFoundPageComponent implements OnInit { 
    ngOnInit() {

    }
}

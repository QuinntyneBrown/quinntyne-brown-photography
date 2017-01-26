import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./contest-entry-page.component.html"),
    styles: [require("./contest-entry-page.component.scss")],
    selector: "contest-entry-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ContestEntryPageComponent implements OnInit { 
    ngOnInit() {

    }
}

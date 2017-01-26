import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./contact-page.component.html"),
    styles: [require("./contact-page.component.scss")],
    selector: "contact-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ContactPageComponent implements OnInit { 
    ngOnInit() {

    }
}

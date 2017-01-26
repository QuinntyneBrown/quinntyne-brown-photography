import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./upload-page.component.html"),
    styles: [require("./upload-page.component.scss")],
    selector: "upload-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class UploadPageComponent implements OnInit { 
    ngOnInit() {

    }
}

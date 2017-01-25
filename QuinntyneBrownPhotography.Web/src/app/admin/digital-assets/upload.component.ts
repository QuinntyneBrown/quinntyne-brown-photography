import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./upload.component.html"),
    styles: [require("./upload.component.scss")],
    selector: "upload",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class UploadComponent implements OnInit { 
    ngOnInit() {

    }
}

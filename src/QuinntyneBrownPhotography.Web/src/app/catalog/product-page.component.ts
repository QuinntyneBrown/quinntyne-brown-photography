import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./product-page.component.html"),
    styles: [require("./product-page.component.scss")],
    selector: "product-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProductPageComponent implements OnInit { 
    ngOnInit() {

    }
}

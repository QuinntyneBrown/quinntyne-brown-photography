import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./article-page.component.html"),
    styles: [require("./article-page.component.scss")],
    selector: "article-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ArticlePageComponent implements OnInit { 
    ngOnInit() {

    }
}

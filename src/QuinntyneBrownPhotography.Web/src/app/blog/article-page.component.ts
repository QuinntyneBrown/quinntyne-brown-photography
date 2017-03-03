import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { ApiService } from "../shared";

@Component({
    template: require("./article-page.component.html"),
    styles: [require("./article-page.component.scss")],
    selector: "article-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ArticlePageComponent implements OnInit { 
    constructor(
        private _apiService: ApiService
    ) {
    }

    ngOnInit() {

    }
}

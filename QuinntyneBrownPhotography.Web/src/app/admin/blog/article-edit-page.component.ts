import { Component, Input, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { ArticleService } from "./article.service";

@Component({
    template: require("./article-edit-page.component.html"),
    styles: [require("./article-edit-page.component.scss")],
    selector: "article-edit-page"
})
export class ArticleEditPageComponent { 
    constructor(
        private _articleService: ArticleService,
        private _router: Router,
        private _activatedRoute: ActivatedRoute
    ) { }

    ngOnInit() { }

    public onSubmit($event: any) {
        
        
    }

    public onCancel() {

    }
}

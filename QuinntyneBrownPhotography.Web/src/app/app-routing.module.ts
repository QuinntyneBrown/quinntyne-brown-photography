import { Routes, RouterModule } from '@angular/router';
import { AboutPageComponent } from "./about";
import { AdminPageComponent } from "./admin";
import { ArticlePageComponent } from "./blog";
import { ProductPageComponent } from "./catalog";
import { ContactPageComponent } from "./contact";
import { LandingPageComponent } from "./landing";
import { LoginPageComponent } from "./login";

export const routes: Routes = [
    {
        path: '',
        component: LandingPageComponent,
    },
    {
        path: 'about',
        component: AboutPageComponent
    },
    {
        path: 'admin',
        component: AdminPageComponent
    },
    {
        path: 'contact',
        component: ContactPageComponent
    },
    {
        path: 'article/:slug',
        component: ArticlePageComponent
    },
    {
        path: 'product/:slug',
        component: ProductPageComponent
    },
    {
        path: 'login',
        component: LoginPageComponent
    }
];

export const RoutingModule = RouterModule.forRoot([
    ...routes
]);

export const routedComponents = [
    AboutPageComponent,
    AdminPageComponent,
    ContactPageComponent,
    ArticlePageComponent,
    ProductPageComponent,
    LandingPageComponent,
    LoginPageComponent
];
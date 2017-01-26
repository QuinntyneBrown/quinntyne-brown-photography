import { environment } from "./environments/environment";
import { enableProdMode } from "@angular/core";
import { AppModule } from "./app";
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

if (environment.production) {
    enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule)
    .catch(err => console.error(err));
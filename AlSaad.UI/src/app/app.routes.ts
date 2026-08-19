import { Routes } from '@angular/router';
import { LoginComponent } from './features/authentication/login/loginComponent';
import { Home } from './features/home/home';
import { Registeration } from './features/authentication/registeration/registeration';

export const routes: Routes = [ { path: '', redirectTo: 'login', pathMatch: 'full' },
     { path: 'login', component: LoginComponent },
      { path: 'home', component: Home },{
        path: 'register',component: Registeration} ];

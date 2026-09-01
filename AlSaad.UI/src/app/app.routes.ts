import { Routes } from '@angular/router';
import { LoginComponent } from './core/features/authentication/login/loginComponent';
import { Home } from './core/features/home/home';
import { Registeration } from './core/features/authentication/registeration/registeration';
import { Mainlayout } from './core/shared/mainlayout/mainlayout';
import { Maker } from '../app/core/cars/maker/maker';
import { Models } from '../app/core/cars/models/models';
import { Cart } from '../app/core/features/cart/cart';
import { Part } from './core/cars/part/part';
export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: Registeration },
  {
    path: '',
    component: Mainlayout,
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: Home },
      { path: 'makers', component: Maker },
      { path: 'models', component: Models },
      { path: 'carts', component: Cart },
      { path: 'parts', component: Part },
    ]
  }
];

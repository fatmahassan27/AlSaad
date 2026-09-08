import { Routes } from '@angular/router';
import { LoginComponent } from './core/features/authentication/login/loginComponent';
import { Home } from './core/features/home/home';
import { Registeration } from './core/features/authentication/registeration/registeration';
import { Mainlayout } from './core/shared/mainlayout/mainlayout';
import { Maker } from '../app/core/cars/maker/maker';
import { Models } from '../app/core/cars/models/models';
import { Cart } from '../app/core/features/cart/cart';
import { Part } from './core/cars/part/part';
import { Account } from './core/features/account/account';
import { Products } from './core/features/products/products';
import { Requisitions } from './core/features/requisitions/requisitions';
import { RequisitionDetails } from './core/features/requisition-details/requisition-details';
import { ProductCategories } from './core/features/product-categories/product-categories';
import { CategoryDetails } from './core/features/category-details/category-details';
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
      { path: 'account', component: Account },
      {
        path: 'inventory',
        children: [
          { path: '', redirectTo: 'products', pathMatch: 'full' },
          { path: 'products', component: Products },
          { path: 'categories', component: ProductCategories },
          { path: 'categories/:id', component: CategoryDetails },
          { path: 'requisitions', component: Requisitions },
          { path: 'requisitions/:id', component: RequisitionDetails },
        ]
      },
    ]
  }
];